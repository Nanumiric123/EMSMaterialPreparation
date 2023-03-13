﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace EMSMaterialPreparation.GETProductionInfo {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    // CODEGEN: The optional WSDL extension element 'Policy' from namespace 'http://schemas.xmlsoap.org/ws/2004/09/policy' was not handled.
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PROD_SCHED", Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZWM_MY_I_PROD_SCHED : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CallZWM_MY_I_PROD_SCHEDOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ZWM_MY_I_PROD_SCHED() {
            this.Url = global::EMSMaterialPreparation.Properties.Settings.Default.EMSMaterialPreparation_GETProductionInfo_ZWM_MY_I_PROD_SCHED;
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
        public event CallZWM_MY_I_PROD_SCHEDCompletedEventHandler CallZWM_MY_I_PROD_SCHEDCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:sap-com:document:sap:rfc:functions:ZWM_MY_I_PROD_SCHED:ZWM_MY_I_PROD_SCHEDReq" +
            "uest", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ZWM_MY_I_PROD_SCHEDResponse", Namespace="urn:sap-com:document:sap:rfc:functions")]
        public ZWM_MY_I_PROD_SCHEDResponse CallZWM_MY_I_PROD_SCHED([System.Xml.Serialization.XmlElementAttribute(Namespace="urn:sap-com:document:sap:rfc:functions")] ZWM_MY_I_PROD_SCHED1 ZWM_MY_I_PROD_SCHED) {
            object[] results = this.Invoke("CallZWM_MY_I_PROD_SCHED", new object[] {
                        ZWM_MY_I_PROD_SCHED});
            return ((ZWM_MY_I_PROD_SCHEDResponse)(results[0]));
        }
        
        /// <remarks/>
        public void CallZWM_MY_I_PROD_SCHEDAsync(ZWM_MY_I_PROD_SCHED1 ZWM_MY_I_PROD_SCHED) {
            this.CallZWM_MY_I_PROD_SCHEDAsync(ZWM_MY_I_PROD_SCHED, null);
        }
        
        /// <remarks/>
        public void CallZWM_MY_I_PROD_SCHEDAsync(ZWM_MY_I_PROD_SCHED1 ZWM_MY_I_PROD_SCHED, object userState) {
            if ((this.CallZWM_MY_I_PROD_SCHEDOperationCompleted == null)) {
                this.CallZWM_MY_I_PROD_SCHEDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCallZWM_MY_I_PROD_SCHEDOperationCompleted);
            }
            this.InvokeAsync("CallZWM_MY_I_PROD_SCHED", new object[] {
                        ZWM_MY_I_PROD_SCHED}, this.CallZWM_MY_I_PROD_SCHEDOperationCompleted, userState);
        }
        
        private void OnCallZWM_MY_I_PROD_SCHEDOperationCompleted(object arg) {
            if ((this.CallZWM_MY_I_PROD_SCHEDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CallZWM_MY_I_PROD_SCHEDCompleted(this, new CallZWM_MY_I_PROD_SCHEDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZWM_MY_I_PROD_SCHED1 {
        
        private string iMODELNOField;
        
        private string iPRODENDField;
        
        private string iPRODORDERField;
        
        private string iPRODSTARTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IMODELNO {
            get {
                return this.iMODELNOField;
            }
            set {
                this.iMODELNOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IPRODEND {
            get {
                return this.iPRODENDField;
            }
            set {
                this.iPRODENDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IPRODORDER {
            get {
                return this.iPRODORDERField;
            }
            set {
                this.iPRODORDERField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string IPRODSTART {
            get {
                return this.iPRODSTARTField;
            }
            set {
                this.iPRODSTARTField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZWM_MY_I_FM_BARCODE_MS {
        
        private string tYPEField;
        
        private string mESSAGEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TYPE {
            get {
                return this.tYPEField;
            }
            set {
                this.tYPEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MESSAGE {
            get {
                return this.mESSAGEField;
            }
            set {
                this.mESSAGEField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZWM_MY_I_PROD_SCHED_S {
        
        private string mODEL_NOField;
        
        private string pRODUCTION_ORDERField;
        
        private decimal oRDER_QUANTITYField;
        
        private string bASIC_START_DATEField;
        
        private string sCHEDULED_START_DATEField;
        
        private string cOMPONENTField;
        
        private decimal rEQUIREMENT_QUANTITYField;
        
        private string fROM_LOCATIONField;
        
        private string tO_LOCATIONField;
        
        private decimal wITHDRAWN_QUANTITYField;
        
        private string rEQUIREMENT_DATEField;
        
        private string pRODUCTION_LOTField;
        
        private string lINEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MODEL_NO {
            get {
                return this.mODEL_NOField;
            }
            set {
                this.mODEL_NOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PRODUCTION_ORDER {
            get {
                return this.pRODUCTION_ORDERField;
            }
            set {
                this.pRODUCTION_ORDERField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal ORDER_QUANTITY {
            get {
                return this.oRDER_QUANTITYField;
            }
            set {
                this.oRDER_QUANTITYField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BASIC_START_DATE {
            get {
                return this.bASIC_START_DATEField;
            }
            set {
                this.bASIC_START_DATEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SCHEDULED_START_DATE {
            get {
                return this.sCHEDULED_START_DATEField;
            }
            set {
                this.sCHEDULED_START_DATEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string COMPONENT {
            get {
                return this.cOMPONENTField;
            }
            set {
                this.cOMPONENTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal REQUIREMENT_QUANTITY {
            get {
                return this.rEQUIREMENT_QUANTITYField;
            }
            set {
                this.rEQUIREMENT_QUANTITYField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FROM_LOCATION {
            get {
                return this.fROM_LOCATIONField;
            }
            set {
                this.fROM_LOCATIONField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TO_LOCATION {
            get {
                return this.tO_LOCATIONField;
            }
            set {
                this.tO_LOCATIONField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal WITHDRAWN_QUANTITY {
            get {
                return this.wITHDRAWN_QUANTITYField;
            }
            set {
                this.wITHDRAWN_QUANTITYField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string REQUIREMENT_DATE {
            get {
                return this.rEQUIREMENT_DATEField;
            }
            set {
                this.rEQUIREMENT_DATEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PRODUCTION_LOT {
            get {
                return this.pRODUCTION_LOTField;
            }
            set {
                this.pRODUCTION_LOTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LINE {
            get {
                return this.lINEField;
            }
            set {
                this.lINEField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZWM_MY_I_PROD_SCHEDResponse {
        
        private ZWM_MY_I_PROD_SCHED_S[] iTEMField;
        
        private ZWM_MY_I_FM_BARCODE_MS mSGField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZWM_MY_I_PROD_SCHED_S[] ITEM {
            get {
                return this.iTEMField;
            }
            set {
                this.iTEMField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ZWM_MY_I_FM_BARCODE_MS MSG {
            get {
                return this.mSGField;
            }
            set {
                this.mSGField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void CallZWM_MY_I_PROD_SCHEDCompletedEventHandler(object sender, CallZWM_MY_I_PROD_SCHEDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CallZWM_MY_I_PROD_SCHEDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CallZWM_MY_I_PROD_SCHEDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ZWM_MY_I_PROD_SCHEDResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ZWM_MY_I_PROD_SCHEDResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591