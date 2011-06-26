﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.235.
// 
#pragma warning disable 1591

namespace Apsoil.ApsoilWeb {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://www.apsim.info/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SoilNamesOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateAllSoilsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SoilXMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback PAWOperationCompleted;
        
        private System.Threading.SendOrPostCallback PAWCOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConvertSoilSampleXMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateSoilSample1XMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateSoilSample2XMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback SoilChartPNGOperationCompleted;
        
        private System.Threading.SendOrPostCallback SoilChartWithSamplePNGOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service() {
            this.Url = global::Apsoil.Properties.Settings.Default.Apsoil_ApsoilWeb_Service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SoilNamesCompletedEventHandler SoilNamesCompleted;
        
        /// <remarks/>
        public event UpdateAllSoilsCompletedEventHandler UpdateAllSoilsCompleted;
        
        /// <remarks/>
        public event SoilXMLCompletedEventHandler SoilXMLCompleted;
        
        /// <remarks/>
        public event PAWCompletedEventHandler PAWCompleted;
        
        /// <remarks/>
        public event PAWCCompletedEventHandler PAWCCompleted;
        
        /// <remarks/>
        public event ConvertSoilSampleXMLCompletedEventHandler ConvertSoilSampleXMLCompleted;
        
        /// <remarks/>
        public event CreateSoilSample1XMLCompletedEventHandler CreateSoilSample1XMLCompleted;
        
        /// <remarks/>
        public event CreateSoilSample2XMLCompletedEventHandler CreateSoilSample2XMLCompleted;
        
        /// <remarks/>
        public event SoilChartPNGCompletedEventHandler SoilChartPNGCompleted;
        
        /// <remarks/>
        public event SoilChartWithSamplePNGCompletedEventHandler SoilChartWithSamplePNGCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/SoilNames", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] SoilNames() {
            object[] results = this.Invoke("SoilNames", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void SoilNamesAsync() {
            this.SoilNamesAsync(null);
        }
        
        /// <remarks/>
        public void SoilNamesAsync(object userState) {
            if ((this.SoilNamesOperationCompleted == null)) {
                this.SoilNamesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSoilNamesOperationCompleted);
            }
            this.InvokeAsync("SoilNames", new object[0], this.SoilNamesOperationCompleted, userState);
        }
        
        private void OnSoilNamesOperationCompleted(object arg) {
            if ((this.SoilNamesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SoilNamesCompleted(this, new SoilNamesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/UpdateAllSoils", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateAllSoils(string Contents) {
            this.Invoke("UpdateAllSoils", new object[] {
                        Contents});
        }
        
        /// <remarks/>
        public void UpdateAllSoilsAsync(string Contents) {
            this.UpdateAllSoilsAsync(Contents, null);
        }
        
        /// <remarks/>
        public void UpdateAllSoilsAsync(string Contents, object userState) {
            if ((this.UpdateAllSoilsOperationCompleted == null)) {
                this.UpdateAllSoilsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateAllSoilsOperationCompleted);
            }
            this.InvokeAsync("UpdateAllSoils", new object[] {
                        Contents}, this.UpdateAllSoilsOperationCompleted, userState);
        }
        
        private void OnUpdateAllSoilsOperationCompleted(object arg) {
            if ((this.UpdateAllSoilsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateAllSoilsCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/SoilXML", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SoilXML(string Name) {
            object[] results = this.Invoke("SoilXML", new object[] {
                        Name});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SoilXMLAsync(string Name) {
            this.SoilXMLAsync(Name, null);
        }
        
        /// <remarks/>
        public void SoilXMLAsync(string Name, object userState) {
            if ((this.SoilXMLOperationCompleted == null)) {
                this.SoilXMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSoilXMLOperationCompleted);
            }
            this.InvokeAsync("SoilXML", new object[] {
                        Name}, this.SoilXMLOperationCompleted, userState);
        }
        
        private void OnSoilXMLOperationCompleted(object arg) {
            if ((this.SoilXMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SoilXMLCompleted(this, new SoilXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/PAW", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double PAW(string SoilName, string SoilSampleXML, string CropName) {
            object[] results = this.Invoke("PAW", new object[] {
                        SoilName,
                        SoilSampleXML,
                        CropName});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void PAWAsync(string SoilName, string SoilSampleXML, string CropName) {
            this.PAWAsync(SoilName, SoilSampleXML, CropName, null);
        }
        
        /// <remarks/>
        public void PAWAsync(string SoilName, string SoilSampleXML, string CropName, object userState) {
            if ((this.PAWOperationCompleted == null)) {
                this.PAWOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPAWOperationCompleted);
            }
            this.InvokeAsync("PAW", new object[] {
                        SoilName,
                        SoilSampleXML,
                        CropName}, this.PAWOperationCompleted, userState);
        }
        
        private void OnPAWOperationCompleted(object arg) {
            if ((this.PAWCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PAWCompleted(this, new PAWCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/PAWC", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public double PAWC(string SoilName, string CropName) {
            object[] results = this.Invoke("PAWC", new object[] {
                        SoilName,
                        CropName});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void PAWCAsync(string SoilName, string CropName) {
            this.PAWCAsync(SoilName, CropName, null);
        }
        
        /// <remarks/>
        public void PAWCAsync(string SoilName, string CropName, object userState) {
            if ((this.PAWCOperationCompleted == null)) {
                this.PAWCOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPAWCOperationCompleted);
            }
            this.InvokeAsync("PAWC", new object[] {
                        SoilName,
                        CropName}, this.PAWCOperationCompleted, userState);
        }
        
        private void OnPAWCOperationCompleted(object arg) {
            if ((this.PAWCCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PAWCCompleted(this, new PAWCCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/ConvertSoilSampleXML", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConvertSoilSampleXML(string SoilSampleXML) {
            object[] results = this.Invoke("ConvertSoilSampleXML", new object[] {
                        SoilSampleXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConvertSoilSampleXMLAsync(string SoilSampleXML) {
            this.ConvertSoilSampleXMLAsync(SoilSampleXML, null);
        }
        
        /// <remarks/>
        public void ConvertSoilSampleXMLAsync(string SoilSampleXML, object userState) {
            if ((this.ConvertSoilSampleXMLOperationCompleted == null)) {
                this.ConvertSoilSampleXMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConvertSoilSampleXMLOperationCompleted);
            }
            this.InvokeAsync("ConvertSoilSampleXML", new object[] {
                        SoilSampleXML}, this.ConvertSoilSampleXMLOperationCompleted, userState);
        }
        
        private void OnConvertSoilSampleXMLOperationCompleted(object arg) {
            if ((this.ConvertSoilSampleXMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConvertSoilSampleXMLCompleted(this, new ConvertSoilSampleXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/CreateSoilSample1XML", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CreateSoilSample1XML(System.DateTime SampleDate, string[] DepthStrings, string SWUnits, double[] SW, double[] NO3, double[] NH4) {
            object[] results = this.Invoke("CreateSoilSample1XML", new object[] {
                        SampleDate,
                        DepthStrings,
                        SWUnits,
                        SW,
                        NO3,
                        NH4});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CreateSoilSample1XMLAsync(System.DateTime SampleDate, string[] DepthStrings, string SWUnits, double[] SW, double[] NO3, double[] NH4) {
            this.CreateSoilSample1XMLAsync(SampleDate, DepthStrings, SWUnits, SW, NO3, NH4, null);
        }
        
        /// <remarks/>
        public void CreateSoilSample1XMLAsync(System.DateTime SampleDate, string[] DepthStrings, string SWUnits, double[] SW, double[] NO3, double[] NH4, object userState) {
            if ((this.CreateSoilSample1XMLOperationCompleted == null)) {
                this.CreateSoilSample1XMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateSoilSample1XMLOperationCompleted);
            }
            this.InvokeAsync("CreateSoilSample1XML", new object[] {
                        SampleDate,
                        DepthStrings,
                        SWUnits,
                        SW,
                        NO3,
                        NH4}, this.CreateSoilSample1XMLOperationCompleted, userState);
        }
        
        private void OnCreateSoilSample1XMLOperationCompleted(object arg) {
            if ((this.CreateSoilSample1XMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateSoilSample1XMLCompleted(this, new CreateSoilSample1XMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/CreateSoilSample2XML", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CreateSoilSample2XML(System.DateTime SampleDate, string[] DepthStrings, double[] OC, double[] EC, double[] PH, double[] CL) {
            object[] results = this.Invoke("CreateSoilSample2XML", new object[] {
                        SampleDate,
                        DepthStrings,
                        OC,
                        EC,
                        PH,
                        CL});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CreateSoilSample2XMLAsync(System.DateTime SampleDate, string[] DepthStrings, double[] OC, double[] EC, double[] PH, double[] CL) {
            this.CreateSoilSample2XMLAsync(SampleDate, DepthStrings, OC, EC, PH, CL, null);
        }
        
        /// <remarks/>
        public void CreateSoilSample2XMLAsync(System.DateTime SampleDate, string[] DepthStrings, double[] OC, double[] EC, double[] PH, double[] CL, object userState) {
            if ((this.CreateSoilSample2XMLOperationCompleted == null)) {
                this.CreateSoilSample2XMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateSoilSample2XMLOperationCompleted);
            }
            this.InvokeAsync("CreateSoilSample2XML", new object[] {
                        SampleDate,
                        DepthStrings,
                        OC,
                        EC,
                        PH,
                        CL}, this.CreateSoilSample2XMLOperationCompleted, userState);
        }
        
        private void OnCreateSoilSample2XMLOperationCompleted(object arg) {
            if ((this.CreateSoilSample2XMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateSoilSample2XMLCompleted(this, new CreateSoilSample2XMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/SoilChartPNG", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] SoilChartPNG(string SoilName) {
            object[] results = this.Invoke("SoilChartPNG", new object[] {
                        SoilName});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void SoilChartPNGAsync(string SoilName) {
            this.SoilChartPNGAsync(SoilName, null);
        }
        
        /// <remarks/>
        public void SoilChartPNGAsync(string SoilName, object userState) {
            if ((this.SoilChartPNGOperationCompleted == null)) {
                this.SoilChartPNGOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSoilChartPNGOperationCompleted);
            }
            this.InvokeAsync("SoilChartPNG", new object[] {
                        SoilName}, this.SoilChartPNGOperationCompleted, userState);
        }
        
        private void OnSoilChartPNGOperationCompleted(object arg) {
            if ((this.SoilChartPNGCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SoilChartPNGCompleted(this, new SoilChartPNGCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.apsim.info/SoilChartWithSamplePNG", RequestNamespace="http://www.apsim.info/", ResponseNamespace="http://www.apsim.info/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] SoilChartWithSamplePNG(string SoilName, string SoilSampleXML) {
            object[] results = this.Invoke("SoilChartWithSamplePNG", new object[] {
                        SoilName,
                        SoilSampleXML});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void SoilChartWithSamplePNGAsync(string SoilName, string SoilSampleXML) {
            this.SoilChartWithSamplePNGAsync(SoilName, SoilSampleXML, null);
        }
        
        /// <remarks/>
        public void SoilChartWithSamplePNGAsync(string SoilName, string SoilSampleXML, object userState) {
            if ((this.SoilChartWithSamplePNGOperationCompleted == null)) {
                this.SoilChartWithSamplePNGOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSoilChartWithSamplePNGOperationCompleted);
            }
            this.InvokeAsync("SoilChartWithSamplePNG", new object[] {
                        SoilName,
                        SoilSampleXML}, this.SoilChartWithSamplePNGOperationCompleted, userState);
        }
        
        private void OnSoilChartWithSamplePNGOperationCompleted(object arg) {
            if ((this.SoilChartWithSamplePNGCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SoilChartWithSamplePNGCompleted(this, new SoilChartWithSamplePNGCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SoilNamesCompletedEventHandler(object sender, SoilNamesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SoilNamesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SoilNamesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateAllSoilsCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SoilXMLCompletedEventHandler(object sender, SoilXMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SoilXMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SoilXMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void PAWCompletedEventHandler(object sender, PAWCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PAWCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PAWCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void PAWCCompletedEventHandler(object sender, PAWCCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PAWCCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PAWCCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ConvertSoilSampleXMLCompletedEventHandler(object sender, ConvertSoilSampleXMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConvertSoilSampleXMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConvertSoilSampleXMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CreateSoilSample1XMLCompletedEventHandler(object sender, CreateSoilSample1XMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateSoilSample1XMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateSoilSample1XMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CreateSoilSample2XMLCompletedEventHandler(object sender, CreateSoilSample2XMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateSoilSample2XMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateSoilSample2XMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SoilChartPNGCompletedEventHandler(object sender, SoilChartPNGCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SoilChartPNGCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SoilChartPNGCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SoilChartWithSamplePNGCompletedEventHandler(object sender, SoilChartWithSamplePNGCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SoilChartWithSamplePNGCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SoilChartWithSamplePNGCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591