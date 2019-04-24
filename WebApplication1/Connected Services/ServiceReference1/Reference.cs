﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceCustomer", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class ServiceCustomer : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompanyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContactNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContactTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustomerIDField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CompanyName {
            get {
                return this.CompanyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CompanyNameField, value) != true)) {
                    this.CompanyNameField = value;
                    this.RaisePropertyChanged("CompanyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContactName {
            get {
                return this.ContactNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactNameField, value) != true)) {
                    this.ContactNameField = value;
                    this.RaisePropertyChanged("ContactName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContactTitle {
            get {
                return this.ContactTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactTitleField, value) != true)) {
                    this.ContactTitleField = value;
                    this.RaisePropertyChanged("ContactTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustomerID {
            get {
                return this.CustomerIDField;
            }
            set {
                if ((object.ReferenceEquals(this.CustomerIDField, value) != true)) {
                    this.CustomerIDField = value;
                    this.RaisePropertyChanged("CustomerID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.EditingWcfService")]
    public interface EditingWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EditingWcfService/GetValue", ReplyAction="http://tempuri.org/EditingWcfService/GetValueResponse")]
        string GetValue(int x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EditingWcfService/GetValue", ReplyAction="http://tempuri.org/EditingWcfService/GetValueResponse")]
        System.Threading.Tasks.Task<string> GetValueAsync(int x);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EditingWcfService/GetCustomers", ReplyAction="http://tempuri.org/EditingWcfService/GetCustomersResponse")]
        WebApplication1.ServiceReference1.ServiceCustomer[] GetCustomers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EditingWcfService/GetCustomers", ReplyAction="http://tempuri.org/EditingWcfService/GetCustomersResponse")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.ServiceCustomer[]> GetCustomersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EditingWcfService/GetResults", ReplyAction="http://tempuri.org/EditingWcfService/GetResultsResponse")]
        Telerik.Web.UI.SearchBoxData GetResults();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/EditingWcfService/GetResults", ReplyAction="http://tempuri.org/EditingWcfService/GetResultsResponse")]
        System.Threading.Tasks.Task<Telerik.Web.UI.SearchBoxData> GetResultsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface EditingWcfServiceChannel : WebApplication1.ServiceReference1.EditingWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EditingWcfServiceClient : System.ServiceModel.ClientBase<WebApplication1.ServiceReference1.EditingWcfService>, WebApplication1.ServiceReference1.EditingWcfService {
        
        public EditingWcfServiceClient() {
        }
        
        public EditingWcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EditingWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EditingWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EditingWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetValue(int x) {
            return base.Channel.GetValue(x);
        }
        
        public System.Threading.Tasks.Task<string> GetValueAsync(int x) {
            return base.Channel.GetValueAsync(x);
        }
        
        public WebApplication1.ServiceReference1.ServiceCustomer[] GetCustomers() {
            return base.Channel.GetCustomers();
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.ServiceCustomer[]> GetCustomersAsync() {
            return base.Channel.GetCustomersAsync();
        }
        
        public Telerik.Web.UI.SearchBoxData GetResults() {
            return base.Channel.GetResults();
        }
        
        public System.Threading.Tasks.Task<Telerik.Web.UI.SearchBoxData> GetResultsAsync() {
            return base.Channel.GetResultsAsync();
        }
    }
}