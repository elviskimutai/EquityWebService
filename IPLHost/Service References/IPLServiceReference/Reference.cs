﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPLHost.IPLServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="IPLResponse", Namespace="http://schemas.datacontract.org/2004/07/IPLRest")]
    [System.SerializableAttribute()]
    public partial class IPLResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CaptureTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CardExpiryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CashbackField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrencyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MsgField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PanField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PinField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RRNField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RespCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SchemeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SignField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StanField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TransactionTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((object.ReferenceEquals(this.AmountField, value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AuthCode {
            get {
                return this.AuthCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthCodeField, value) != true)) {
                    this.AuthCodeField = value;
                    this.RaisePropertyChanged("AuthCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CaptureType {
            get {
                return this.CaptureTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.CaptureTypeField, value) != true)) {
                    this.CaptureTypeField = value;
                    this.RaisePropertyChanged("CaptureType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardExpiry {
            get {
                return this.CardExpiryField;
            }
            set {
                if ((object.ReferenceEquals(this.CardExpiryField, value) != true)) {
                    this.CardExpiryField = value;
                    this.RaisePropertyChanged("CardExpiry");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cashback {
            get {
                return this.CashbackField;
            }
            set {
                if ((object.ReferenceEquals(this.CashbackField, value) != true)) {
                    this.CashbackField = value;
                    this.RaisePropertyChanged("Cashback");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Currency {
            get {
                return this.CurrencyField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrencyField, value) != true)) {
                    this.CurrencyField = value;
                    this.RaisePropertyChanged("Currency");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MID {
            get {
                return this.MIDField;
            }
            set {
                if ((object.ReferenceEquals(this.MIDField, value) != true)) {
                    this.MIDField = value;
                    this.RaisePropertyChanged("MID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Msg {
            get {
                return this.MsgField;
            }
            set {
                if ((object.ReferenceEquals(this.MsgField, value) != true)) {
                    this.MsgField = value;
                    this.RaisePropertyChanged("Msg");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pan {
            get {
                return this.PanField;
            }
            set {
                if ((object.ReferenceEquals(this.PanField, value) != true)) {
                    this.PanField = value;
                    this.RaisePropertyChanged("Pan");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pin {
            get {
                return this.PinField;
            }
            set {
                if ((object.ReferenceEquals(this.PinField, value) != true)) {
                    this.PinField = value;
                    this.RaisePropertyChanged("Pin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RRN {
            get {
                return this.RRNField;
            }
            set {
                if ((object.ReferenceEquals(this.RRNField, value) != true)) {
                    this.RRNField = value;
                    this.RaisePropertyChanged("RRN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RespCode {
            get {
                return this.RespCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.RespCodeField, value) != true)) {
                    this.RespCodeField = value;
                    this.RaisePropertyChanged("RespCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Scheme {
            get {
                return this.SchemeField;
            }
            set {
                if ((object.ReferenceEquals(this.SchemeField, value) != true)) {
                    this.SchemeField = value;
                    this.RaisePropertyChanged("Scheme");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sign {
            get {
                return this.SignField;
            }
            set {
                if ((object.ReferenceEquals(this.SignField, value) != true)) {
                    this.SignField = value;
                    this.RaisePropertyChanged("Sign");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Stan {
            get {
                return this.StanField;
            }
            set {
                if ((object.ReferenceEquals(this.StanField, value) != true)) {
                    this.StanField = value;
                    this.RaisePropertyChanged("Stan");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tid {
            get {
                return this.TidField;
            }
            set {
                if ((object.ReferenceEquals(this.TidField, value) != true)) {
                    this.TidField = value;
                    this.RaisePropertyChanged("Tid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransactionType {
            get {
                return this.TransactionTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TransactionTypeField, value) != true)) {
                    this.TransactionTypeField = value;
                    this.RaisePropertyChanged("TransactionType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SaleRequest", Namespace="http://schemas.datacontract.org/2004/07/IPLRest")]
    [System.SerializableAttribute()]
    public partial class SaleRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CashBackField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TillNOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TransKeyField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((object.ReferenceEquals(this.AmountField, value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CashBack {
            get {
                return this.CashBackField;
            }
            set {
                if ((object.ReferenceEquals(this.CashBackField, value) != true)) {
                    this.CashBackField = value;
                    this.RaisePropertyChanged("CashBack");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TillNO {
            get {
                return this.TillNOField;
            }
            set {
                if ((object.ReferenceEquals(this.TillNOField, value) != true)) {
                    this.TillNOField = value;
                    this.RaisePropertyChanged("TillNO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TransKey {
            get {
                return this.TransKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.TransKeyField, value) != true)) {
                    this.TransKeyField = value;
                    this.RaisePropertyChanged("TransKey");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReversalRequest", Namespace="http://schemas.datacontract.org/2004/07/IPLRest")]
    [System.SerializableAttribute()]
    public partial class ReversalRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RRNField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((object.ReferenceEquals(this.AmountField, value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RRN {
            get {
                return this.RRNField;
            }
            set {
                if ((object.ReferenceEquals(this.RRNField, value) != true)) {
                    this.RRNField = value;
                    this.RaisePropertyChanged("RRN");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IPLServiceReference.IIPLService")]
    public interface IIPLService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIPLService/sale", ReplyAction="http://tempuri.org/IIPLService/saleResponse")]
        IPLHost.IPLServiceReference.IPLResponse sale(string amount, string cashBack, string tillNO, string transKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIPLService/reversal", ReplyAction="http://tempuri.org/IIPLService/reversalResponse")]
        IPLHost.IPLServiceReference.IPLResponse reversal(string amount, string rrn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIPLService/execSale", ReplyAction="http://tempuri.org/IIPLService/execSaleResponse")]
        IPLHost.IPLServiceReference.IPLResponse execSale(IPLHost.IPLServiceReference.SaleRequest req);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIPLService/execReversal", ReplyAction="http://tempuri.org/IIPLService/execReversalResponse")]
        IPLHost.IPLServiceReference.IPLResponse execReversal(IPLHost.IPLServiceReference.ReversalRequest req);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IIPLServiceChannel : IPLHost.IPLServiceReference.IIPLService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IPLServiceClient : System.ServiceModel.ClientBase<IPLHost.IPLServiceReference.IIPLService>, IPLHost.IPLServiceReference.IIPLService {
        
        public IPLServiceClient() {
        }
        
        public IPLServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IPLServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IPLServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IPLServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public IPLHost.IPLServiceReference.IPLResponse sale(string amount, string cashBack, string tillNO, string transKey) {
            return base.Channel.sale(amount, cashBack, tillNO, transKey);
        }
        
        public IPLHost.IPLServiceReference.IPLResponse reversal(string amount, string rrn) {
            return base.Channel.reversal(amount, rrn);
        }
        
        public IPLHost.IPLServiceReference.IPLResponse execSale(IPLHost.IPLServiceReference.SaleRequest req) {
            return base.Channel.execSale(req);
        }
        
        public IPLHost.IPLServiceReference.IPLResponse execReversal(IPLHost.IPLServiceReference.ReversalRequest req) {
            return base.Channel.execReversal(req);
        }
    }
}
