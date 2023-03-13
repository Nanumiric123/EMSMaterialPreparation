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

namespace EMSMaterialPreparation.GET_STOCK_PASMY_EMS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="EMS_STOCK", Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZIM_GET_EMS_STOCK : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CallZIM_GET_EMS_STOCKOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ZIM_GET_EMS_STOCK() {
            this.Url = global::EMSMaterialPreparation.Properties.Settings.Default.EMSMaterialPreparation_GET_STOCK_PASMY_EMS_ZIM_GET_EMS_STOCK;
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
        public event CallZIM_GET_EMS_STOCKCompletedEventHandler CallZIM_GET_EMS_STOCKCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:sap-com:document:sap:rfc:functions:ZIM_GET_EMS_STOCK:ZIM_GET_EMS_STOCKRequest" +
            "", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ZIM_GET_EMS_STOCKResponse", Namespace="urn:sap-com:document:sap:rfc:functions")]
        public ZIM_GET_EMS_STOCKResponse CallZIM_GET_EMS_STOCK([System.Xml.Serialization.XmlElementAttribute(Namespace="urn:sap-com:document:sap:rfc:functions")] ZIM_GET_EMS_STOCK1 ZIM_GET_EMS_STOCK) {
            object[] results = this.Invoke("CallZIM_GET_EMS_STOCK", new object[] {
                        ZIM_GET_EMS_STOCK});
            return ((ZIM_GET_EMS_STOCKResponse)(results[0]));
        }
        
        /// <remarks/>
        public void CallZIM_GET_EMS_STOCKAsync(ZIM_GET_EMS_STOCK1 ZIM_GET_EMS_STOCK) {
            this.CallZIM_GET_EMS_STOCKAsync(ZIM_GET_EMS_STOCK, null);
        }
        
        /// <remarks/>
        public void CallZIM_GET_EMS_STOCKAsync(ZIM_GET_EMS_STOCK1 ZIM_GET_EMS_STOCK, object userState) {
            if ((this.CallZIM_GET_EMS_STOCKOperationCompleted == null)) {
                this.CallZIM_GET_EMS_STOCKOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCallZIM_GET_EMS_STOCKOperationCompleted);
            }
            this.InvokeAsync("CallZIM_GET_EMS_STOCK", new object[] {
                        ZIM_GET_EMS_STOCK}, this.CallZIM_GET_EMS_STOCKOperationCompleted, userState);
        }
        
        private void OnCallZIM_GET_EMS_STOCKOperationCompleted(object arg) {
            if ((this.CallZIM_GET_EMS_STOCKCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CallZIM_GET_EMS_STOCKCompleted(this, new CallZIM_GET_EMS_STOCKCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class ZIM_GET_EMS_STOCK1 {
        
        private string i_YEARField;
        
        private string lGORTField;
        
        private string pART_NUMField;
        
        private string pLANTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string I_YEAR {
            get {
                return this.i_YEARField;
            }
            set {
                this.i_YEARField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LGORT {
            get {
                return this.lGORTField;
            }
            set {
                this.lGORTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PART_NUM {
            get {
                return this.pART_NUMField;
            }
            set {
                this.pART_NUMField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PLANT {
            get {
                return this.pLANTField;
            }
            set {
                this.pLANTField = value;
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
    public partial class ZIM_GET_EMS_STOCK_S {
        
        private string mATNRField;
        
        private string wERKSField;
        
        private string lGORTField;
        
        private string lGPBEField;
        
        private decimal lABSTField;
        
        private decimal bSTRFField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string WERKS {
            get {
                return this.wERKSField;
            }
            set {
                this.wERKSField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LGORT {
            get {
                return this.lGORTField;
            }
            set {
                this.lGORTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LGPBE {
            get {
                return this.lGPBEField;
            }
            set {
                this.lGPBEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal LABST {
            get {
                return this.lABSTField;
            }
            set {
                this.lABSTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal BSTRF {
            get {
                return this.bSTRFField;
            }
            set {
                this.bSTRFField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZIM_GET_EMS_STOCKResponse {
        
        private ZIM_GET_EMS_STOCK_S[] iTEMField;
        
        private ZWM_MY_I_FM_BARCODE_MS mSGField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZIM_GET_EMS_STOCK_S[] ITEM {
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
    public delegate void CallZIM_GET_EMS_STOCKCompletedEventHandler(object sender, CallZIM_GET_EMS_STOCKCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CallZIM_GET_EMS_STOCKCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CallZIM_GET_EMS_STOCKCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ZIM_GET_EMS_STOCKResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ZIM_GET_EMS_STOCKResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591