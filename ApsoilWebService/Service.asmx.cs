﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Xml;

using Steema.TeeChart.Styles;
using System.IO;
using System.Drawing;
using ApsimFile;
using CSGeneral;
using Graph;

namespace Apsoil
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://www.apsim.info/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Service : System.Web.Services.WebService
    {
        private List<string> _SoilNames;
        private SqlConnection Connection;

        public Service()
        {
            Open();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Close();
        }

        /// <summary>
        /// Open the SoilsDB ready for use.
        /// </summary>
        private void Open()
        {
            // Create a connection to the database.

            // The first string is the debug version to run from Dean's computer.
            //string ConnectionString = "Server=www.apsim.info\\SQLEXPRESS;Database=APSoil;Trusted_Connection=True;";
            string ConnectionString = "Server=APSRUNET2\\SQLEXPRESS;Database=APSoil;Trusted_Connection=True;User ID=APSRUNET2\\apsrunet;password=CsiroDMZ!";

            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        /// <summary>
        /// Close the SoilsDB connection
        /// </summary>
        private void Close()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection = null;
            }
        }

        /// <summary>
        /// Get a list of names from table.
        /// </summary>
        [WebMethod]
        public List<string> SoilNames()
        {
            if (_SoilNames == null)
            {
                _SoilNames = new List<string>();

                SqlCommand Command = new SqlCommand("SELECT Name FROM Soils", Connection);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                    _SoilNames.Add(Reader["Name"].ToString());
                Reader.Close();
            }
            return _SoilNames;
        }

        /// <summary>
        /// Update all soils to the specified .soils content.
        /// </summary>
        [WebMethod]
        public void UpdateAllSoils(string Contents)
        {
            // Delete all soils.
            SqlCommand Cmd = new SqlCommand("DELETE FROM Soils", Connection);
            Cmd.ExecuteNonQuery();

            // Load in the XML
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(Contents);

            // Insert all soils into database.
            InsertFolderIntoDB(Doc.DocumentElement);
        }

        /// <summary>
        /// Recursively insert all soils into database.
        /// </summary>
        private void InsertFolderIntoDB(XmlNode FolderNode)
        {
            foreach (XmlNode SoilNode in XmlHelper.ChildNodes(FolderNode, "Soil"))
                AddSoil(XmlHelper.FullPath(SoilNode), SoilNode.OuterXml);

            foreach (XmlNode ChildFolderNode in XmlHelper.ChildNodes(FolderNode, "Folder"))
                InsertFolderIntoDB(ChildFolderNode);
        }

        /// <summary>
        /// Add a soil to the DB, updating the existing one if necessary.
        /// </summary>
        private void AddSoil(string Name, string XML)
        {
            string SQL;
            if (SoilNames().Contains(Name))
                SQL = "UPDATE Soils SET XML = @XML WHERE Name = @Name";
            else
                SQL = "INSERT INTO Soils (Name, XML) VALUES (@Name, @XML)";

            SqlCommand Cmd = new SqlCommand(SQL, Connection);
            Cmd.Parameters.Add(new SqlParameter("@Name", Name));
            Cmd.Parameters.Add(new SqlParameter("@XML", XML));
            Cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Return the soil node for the specified soil. Will return
        /// null if soil was found.
        /// </summary>
        [WebMethod]
        public string SoilXML(string Name)
        {
            SqlCommand Command = new SqlCommand("SELECT XML FROM Soils WHERE Name = @Name", Connection);
            Command.Parameters.Add(new SqlParameter("@Name", Name));
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                XmlDocument Doc = new XmlDocument();
                Doc.LoadXml(Reader["XML"].ToString());
                Reader.Close();
                return Doc.OuterXml;
            }

            Reader.Close();
            return "";
        }

        /// <summary>
        /// Return the PAW (SW - CropLL) for the specified soil.
        /// </summary>
        [WebMethod]
        public double PAW(string SoilName, string SoilSampleXML, string CropName)
        {
            // Load in the soil XML
            XmlDocument SoilDoc = new XmlDocument();
            SoilDoc.LoadXml(SoilXML(SoilName));

            // Load the sample XML into the Soil XML
            XmlDocument SampleDoc = new XmlDocument();
            SampleDoc.LoadXml(SoilSampleXML);
            SoilDoc.DocumentElement.AppendChild(SoilDoc.ImportNode(SampleDoc.DocumentElement, true));

            // Return the PAW in mm
            Soil.Variable PAW = Soil.Get(SoilDoc.DocumentElement, CropName + " PAW");
            PAW.Units = "mm";
            return MathUtility.Sum(PAW.Doubles);
        }

        /// <summary>
        /// Return the PAWC (DUL - CropLL) for the specified soil.
        /// </summary>
        [WebMethod]
        public double PAWC(string SoilName, string CropName)
        {
            // Load in the soil XML
            XmlDocument SoilDoc = new XmlDocument();
            SoilDoc.LoadXml(SoilXML(SoilName));

            // Return the PAWC in mm
            Soil.Variable PAWC = Soil.Get(SoilDoc.DocumentElement, CropName + " PAWC");
            PAWC.Units = "mm";
            return MathUtility.Sum(PAWC.Doubles);
        }

        /// <summary>
        /// Convert the soil sample XML to the new format.
        /// </summary>
        [WebMethod]
        public string ConvertSoilSampleXML(string SoilSampleXML)
        {
            string OldSoilFormat = "<folder version=\"7\">" +
                                   "<soil name=\"test\">" +
                                   SoilSampleXML +
                                   "</soil>" +
                                   "</folder>";
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(OldSoilFormat);

            ApsimFile.APSIMChangeTool.Upgrade(Doc.DocumentElement);
            return XmlHelper.FindByType(Doc.DocumentElement, "soil/sample").OuterXml;
        }

        /// <summary>
        /// Create soil sample 1 XML
        /// </summary>
        [WebMethod]
        public string CreateSoilSample1XML(DateTime SampleDate, string[] DepthStrings, string SWUnits, double[] SW, double[] NO3, double[] NH4)
        {
            string SoilXML = "<soil name=\"test\">" +
                             "<Sample name=\"Soil sample 1\">" +
                                 "<Date type=\"date\" description=\"Sample date:\" />" +
                                 "<Layer>" +
                                 "   <Thickness units=\"mm\"></Thickness>" +
                                 "   <NO3 units=\"ppm\"></NO3>" +
                                 "   <NH4 units=\"ppm\"></NH4>" +
                                 "   <SW units=\"mm/mm\"></SW>" +
                                 "</Layer>" +
                              "</Sample>" +
                              "</soil>";
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(SoilXML);

            double[] ThicknessMM = SoilUtility.ToThickness(DepthStrings);
            ThicknessMM = MathUtility.Multiply_Value(ThicknessMM, 10);
            Soil.Set(Doc.DocumentElement, new Soil.Variable("SW", SWUnits, SW, ThicknessMM, Doc.DocumentElement));
            Soil.Set(Doc.DocumentElement, new Soil.Variable("NO3", "ppm", NO3, ThicknessMM, Doc.DocumentElement));
            Soil.Set(Doc.DocumentElement, new Soil.Variable("NH4", "ppm", NH4, ThicknessMM, Doc.DocumentElement));

            // Set the sample date.
            XmlNode SampleNode = XmlHelper.Find(Doc.DocumentElement, "Soil sample 1");
            XmlHelper.SetValue(SampleNode, "Date", SampleDate.ToString("dd/MM/yyyy"));
            return SampleNode.OuterXml;
        }

        /// <summary>
        /// Create soil sample 2 XML
        /// </summary>
        [WebMethod]
        public string CreateSoilSample2XML(DateTime SampleDate, string[] DepthStrings, double[] OC, double[] EC, double[] PH, double[] CL)
        {
            string SoilXML = "<soil name=\"test\">" +
                             "<Sample name=\"Soil sample 2\">" +
                                 "<Date type=\"date\" description=\"Sample date:\" />" +
                                 "<Layer>" +
                                 "   <Thickness units=\"mm\"></Thickness>" +
                                 "   <OC units=\"Walkley Black %\"></OC>" +
                                 "   <EC units=\"1:5 dS/m\"></EC>" +
                                 "   <PH units=\"1:5 water\"></PH>" +
                                 "   <CL units=\"mg/kg\"></CL>" +
                                 "</Layer>" +
                              "</Sample>" +
                              "</soil>";
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(SoilXML);

            double[] ThicknessMM = SoilUtility.ToThickness(DepthStrings);
            ThicknessMM = MathUtility.Multiply_Value(ThicknessMM, 10);
            Soil.Set(Doc.DocumentElement, new Soil.Variable("OC", "Walkley Black %", OC, ThicknessMM, Doc.DocumentElement));
            Soil.Set(Doc.DocumentElement, new Soil.Variable("EC", "1:5 dS/m", EC, ThicknessMM, Doc.DocumentElement));
            Soil.Set(Doc.DocumentElement, new Soil.Variable("PH", "1:5 water", PH, ThicknessMM, Doc.DocumentElement));
            Soil.Set(Doc.DocumentElement, new Soil.Variable("CL", "mg/kg", CL, ThicknessMM, Doc.DocumentElement));

            // Set the sample date.
            XmlNode SampleNode = XmlHelper.Find(Doc.DocumentElement, "Soil sample 2");
            XmlHelper.SetValue(SampleNode, "Date", SampleDate.ToString("dd/MM/yyyy"));
            return SampleNode.OuterXml;
        }

        /// <summary>
        /// Return the bytes of a soil chart in PNG format. Google Earth uses this.
        /// </summary>
        [WebMethod]
        public byte[] SoilChartPNG(string SoilName)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(SoilXML(SoilName));
            XmlNode SoilNode = Doc.DocumentElement;
            XmlNode WaterNode = XmlHelper.Find(SoilNode, "Water");

            SoilGraphUI Graph = CreateSoilGraph(SoilNode, WaterNode, false);

            // Make first 3 LL series active.
            int Count = 0;
            foreach (Series S in Graph.Chart.Series)
            {
                if (S.Title.Contains(" LL"))
                {
                    S.Active = true;
                    Count++;
                    if (Count == 3)
                        break;
                }
            }
            Graph.Chart.Legend.CheckBoxes = false;

            MemoryStream MemStream = new MemoryStream(10000);
            Graph.Chart.Export.Image.PNG.Height = 450;
            Graph.Chart.Export.Image.PNG.Width = 350;
            Graph.Chart.Export.Image.PNG.Save(MemStream);

            return MemStream.ToArray();
        }

        /// <summary>
        /// Create and return a soil graph
        /// </summary>
        private static SoilGraphUI CreateSoilGraph(XmlNode SoilNode, XmlNode WaterNode, bool WithSW)
        {
            DataTable Table = new DataTable();
            Table.TableName = "Water";
            List<string> VariableNames = Soil.ValidVariablesForProfileNode(WaterNode);
            VariableNames.RemoveAt(0);
            VariableNames.Insert(0, "DepthMidPoints (mm)");

            if (WithSW)
                VariableNames.Add("SW (mm/mm)");
            else
                foreach (string Crop in Soil.Crops(SoilNode))
                    VariableNames.Add(Crop + " LL(mm/mm)");

            Soil.WriteToTable(SoilNode, Table, VariableNames);

            SoilGraphUI Graph = new SoilGraphUI();
            Graph.SoilNode = SoilNode;
            Graph.OnLoad(null, "", WaterNode.OuterXml);
            Graph.DataSources.Add(Table);
            Graph.OnRefresh();
            return Graph;
        }

        /// <summary>
        /// Return the bytes of a soil chart in PNG format. Google Earth uses this.
        /// </summary>
        [WebMethod]
        public byte[] SoilChartWithSamplePNG(string SoilName, string SoilSampleXML)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(SoilXML(SoilName));
            XmlNode SoilNode = Doc.DocumentElement;
            XmlNode WaterNode = XmlHelper.Find(SoilNode, "Water");

            // Add in the soil sample.
            XmlDocument SampleDoc = new XmlDocument();
            SampleDoc.LoadXml(SoilSampleXML);
            Doc.DocumentElement.AppendChild(Doc.ImportNode(SampleDoc.DocumentElement, true));

            SoilGraphUI Graph = CreateSoilGraph(SoilNode, WaterNode, true);

            // Add in the SW line.
            Series SWSeries = Graph.AddSeries(Graph.DataSources[0], "SW (mm/mm)");
            SWSeries.Color = Color.Cyan;
            SWSeries.Active = true;

            Graph.PopulateSeries();
            Graph.Chart.Legend.CheckBoxes = false;

            MemoryStream MemStream = new MemoryStream(10000);
            Graph.Chart.Export.Image.PNG.Height = 550;
            Graph.Chart.Export.Image.PNG.Width = 550;
            Graph.Chart.Export.Image.PNG.Save(MemStream);

            return MemStream.ToArray();
        }


    }
}
