﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalPages2.HoursReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HoursReference.OfficeHoursServiceSoap")]
    public interface OfficeHoursServiceSoap {
        
        // CODEGEN: Generating message contract since element name profName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddOfficeHours", ReplyAction="*")]
        FinalPages2.HoursReference.AddOfficeHoursResponse AddOfficeHours(FinalPages2.HoursReference.AddOfficeHoursRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddOfficeHours", ReplyAction="*")]
        System.Threading.Tasks.Task<FinalPages2.HoursReference.AddOfficeHoursResponse> AddOfficeHoursAsync(FinalPages2.HoursReference.AddOfficeHoursRequest request);
        
        // CODEGEN: Generating message contract since element name profName from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetOfficeHours", ReplyAction="*")]
        FinalPages2.HoursReference.GetOfficeHoursResponse GetOfficeHours(FinalPages2.HoursReference.GetOfficeHoursRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetOfficeHours", ReplyAction="*")]
        System.Threading.Tasks.Task<FinalPages2.HoursReference.GetOfficeHoursResponse> GetOfficeHoursAsync(FinalPages2.HoursReference.GetOfficeHoursRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddOfficeHoursRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddOfficeHours", Namespace="http://tempuri.org/", Order=0)]
        public FinalPages2.HoursReference.AddOfficeHoursRequestBody Body;
        
        public AddOfficeHoursRequest() {
        }
        
        public AddOfficeHoursRequest(FinalPages2.HoursReference.AddOfficeHoursRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddOfficeHoursRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string profName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string profTime;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string profLocation;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string taName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string taTime;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string taLocation;
        
        public AddOfficeHoursRequestBody() {
        }
        
        public AddOfficeHoursRequestBody(string profName, string profTime, string profLocation, string taName, string taTime, string taLocation) {
            this.profName = profName;
            this.profTime = profTime;
            this.profLocation = profLocation;
            this.taName = taName;
            this.taTime = taTime;
            this.taLocation = taLocation;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddOfficeHoursResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddOfficeHoursResponse", Namespace="http://tempuri.org/", Order=0)]
        public FinalPages2.HoursReference.AddOfficeHoursResponseBody Body;
        
        public AddOfficeHoursResponse() {
        }
        
        public AddOfficeHoursResponse(FinalPages2.HoursReference.AddOfficeHoursResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddOfficeHoursResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string AddOfficeHoursResult;
        
        public AddOfficeHoursResponseBody() {
        }
        
        public AddOfficeHoursResponseBody(string AddOfficeHoursResult) {
            this.AddOfficeHoursResult = AddOfficeHoursResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetOfficeHoursRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetOfficeHours", Namespace="http://tempuri.org/", Order=0)]
        public FinalPages2.HoursReference.GetOfficeHoursRequestBody Body;
        
        public GetOfficeHoursRequest() {
        }
        
        public GetOfficeHoursRequest(FinalPages2.HoursReference.GetOfficeHoursRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetOfficeHoursRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string profName;
        
        public GetOfficeHoursRequestBody() {
        }
        
        public GetOfficeHoursRequestBody(string profName) {
            this.profName = profName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetOfficeHoursResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetOfficeHoursResponse", Namespace="http://tempuri.org/", Order=0)]
        public FinalPages2.HoursReference.GetOfficeHoursResponseBody Body;
        
        public GetOfficeHoursResponse() {
        }
        
        public GetOfficeHoursResponse(FinalPages2.HoursReference.GetOfficeHoursResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetOfficeHoursResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetOfficeHoursResult;
        
        public GetOfficeHoursResponseBody() {
        }
        
        public GetOfficeHoursResponseBody(string GetOfficeHoursResult) {
            this.GetOfficeHoursResult = GetOfficeHoursResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OfficeHoursServiceSoapChannel : FinalPages2.HoursReference.OfficeHoursServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OfficeHoursServiceSoapClient : System.ServiceModel.ClientBase<FinalPages2.HoursReference.OfficeHoursServiceSoap>, FinalPages2.HoursReference.OfficeHoursServiceSoap {
        
        public OfficeHoursServiceSoapClient() {
        }
        
        public OfficeHoursServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OfficeHoursServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OfficeHoursServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OfficeHoursServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FinalPages2.HoursReference.AddOfficeHoursResponse FinalPages2.HoursReference.OfficeHoursServiceSoap.AddOfficeHours(FinalPages2.HoursReference.AddOfficeHoursRequest request) {
            return base.Channel.AddOfficeHours(request);
        }
        
        public string AddOfficeHours(string profName, string profTime, string profLocation, string taName, string taTime, string taLocation) {
            FinalPages2.HoursReference.AddOfficeHoursRequest inValue = new FinalPages2.HoursReference.AddOfficeHoursRequest();
            inValue.Body = new FinalPages2.HoursReference.AddOfficeHoursRequestBody();
            inValue.Body.profName = profName;
            inValue.Body.profTime = profTime;
            inValue.Body.profLocation = profLocation;
            inValue.Body.taName = taName;
            inValue.Body.taTime = taTime;
            inValue.Body.taLocation = taLocation;
            FinalPages2.HoursReference.AddOfficeHoursResponse retVal = ((FinalPages2.HoursReference.OfficeHoursServiceSoap)(this)).AddOfficeHours(inValue);
            return retVal.Body.AddOfficeHoursResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FinalPages2.HoursReference.AddOfficeHoursResponse> FinalPages2.HoursReference.OfficeHoursServiceSoap.AddOfficeHoursAsync(FinalPages2.HoursReference.AddOfficeHoursRequest request) {
            return base.Channel.AddOfficeHoursAsync(request);
        }
        
        public System.Threading.Tasks.Task<FinalPages2.HoursReference.AddOfficeHoursResponse> AddOfficeHoursAsync(string profName, string profTime, string profLocation, string taName, string taTime, string taLocation) {
            FinalPages2.HoursReference.AddOfficeHoursRequest inValue = new FinalPages2.HoursReference.AddOfficeHoursRequest();
            inValue.Body = new FinalPages2.HoursReference.AddOfficeHoursRequestBody();
            inValue.Body.profName = profName;
            inValue.Body.profTime = profTime;
            inValue.Body.profLocation = profLocation;
            inValue.Body.taName = taName;
            inValue.Body.taTime = taTime;
            inValue.Body.taLocation = taLocation;
            return ((FinalPages2.HoursReference.OfficeHoursServiceSoap)(this)).AddOfficeHoursAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FinalPages2.HoursReference.GetOfficeHoursResponse FinalPages2.HoursReference.OfficeHoursServiceSoap.GetOfficeHours(FinalPages2.HoursReference.GetOfficeHoursRequest request) {
            return base.Channel.GetOfficeHours(request);
        }
        
        public string GetOfficeHours(string profName) {
            FinalPages2.HoursReference.GetOfficeHoursRequest inValue = new FinalPages2.HoursReference.GetOfficeHoursRequest();
            inValue.Body = new FinalPages2.HoursReference.GetOfficeHoursRequestBody();
            inValue.Body.profName = profName;
            FinalPages2.HoursReference.GetOfficeHoursResponse retVal = ((FinalPages2.HoursReference.OfficeHoursServiceSoap)(this)).GetOfficeHours(inValue);
            return retVal.Body.GetOfficeHoursResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FinalPages2.HoursReference.GetOfficeHoursResponse> FinalPages2.HoursReference.OfficeHoursServiceSoap.GetOfficeHoursAsync(FinalPages2.HoursReference.GetOfficeHoursRequest request) {
            return base.Channel.GetOfficeHoursAsync(request);
        }
        
        public System.Threading.Tasks.Task<FinalPages2.HoursReference.GetOfficeHoursResponse> GetOfficeHoursAsync(string profName) {
            FinalPages2.HoursReference.GetOfficeHoursRequest inValue = new FinalPages2.HoursReference.GetOfficeHoursRequest();
            inValue.Body = new FinalPages2.HoursReference.GetOfficeHoursRequestBody();
            inValue.Body.profName = profName;
            return ((FinalPages2.HoursReference.OfficeHoursServiceSoap)(this)).GetOfficeHoursAsync(inValue);
        }
    }
}
