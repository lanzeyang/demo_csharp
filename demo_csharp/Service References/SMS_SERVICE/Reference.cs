﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace demo_csharp.SMS_SERVICE {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.flaginfo.com.cn", ConfigurationName="SMS_SERVICE.SmsPortType")]
    public interface SmsPortType {
        
        // CODEGEN: 参数“out”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="out")]
        demo_csharp.SMS_SERVICE.SmsResponse Sms(demo_csharp.SMS_SERVICE.SmsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.SmsResponse> SmsAsync(demo_csharp.SMS_SERVICE.SmsRequest request);
        
        // CODEGEN: 参数“out”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="out")]
        demo_csharp.SMS_SERVICE.ReportResponse Report(demo_csharp.SMS_SERVICE.ReportRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.ReportResponse> ReportAsync(demo_csharp.SMS_SERVICE.ReportRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        demo_csharp.SMS_SERVICE.ReplyResponse Reply(demo_csharp.SMS_SERVICE.ReplyRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.ReplyResponse> ReplyAsync(demo_csharp.SMS_SERVICE.ReplyRequest request);
        
        // CODEGEN: 消息 ReplyConfirmRequest 的包装名称(ReplyConfirmRequest)以后生成的消息协定与默认值(ReplyConfirm)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        demo_csharp.SMS_SERVICE.ReplyConfirmResponse ReplyConfirm(demo_csharp.SMS_SERVICE.ReplyConfirmRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.ReplyConfirmResponse> ReplyConfirmAsync(demo_csharp.SMS_SERVICE.ReplyConfirmRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        demo_csharp.SMS_SERVICE.SearchSmsNumResponse SearchSmsNum(demo_csharp.SMS_SERVICE.SearchSmsNumRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.SearchSmsNumResponse> SearchSmsNumAsync(demo_csharp.SMS_SERVICE.SearchSmsNumRequest request);
        
        // CODEGEN: 消息 AuditingRequest 的包装名称(AuditingRequest)以后生成的消息协定与默认值(Auditing)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        demo_csharp.SMS_SERVICE.AuditingResponse Auditing(demo_csharp.SMS_SERVICE.AuditingRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.AuditingResponse> AuditingAsync(demo_csharp.SMS_SERVICE.AuditingRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Sms", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class SmsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in2;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in3;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in4;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in5;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in6;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=7)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in7;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=8)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in8;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=9)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in9;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=10)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in10;
        
        public SmsRequest() {
        }
        
        public SmsRequest(string in0, string in1, string in2, string in3, string in4, string in5, string in6, string in7, string in8, string in9, string in10) {
            this.in0 = in0;
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
            this.in5 = in5;
            this.in6 = in6;
            this.in7 = in7;
            this.in8 = in8;
            this.in9 = in9;
            this.in10 = in10;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SmsResponse", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class SmsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @out;
        
        public SmsResponse() {
        }
        
        public SmsResponse(string @out) {
            this.@out = @out;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Report", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class ReportRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in2;
        
        public ReportRequest() {
        }
        
        public ReportRequest(string in0, string in1, string in2) {
            this.in0 = in0;
            this.in1 = in1;
            this.in2 = in2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReportResponse", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class ReportResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @out;
        
        public ReportResponse() {
        }
        
        public ReportResponse(string @out) {
            this.@out = @out;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.flaginfo.com.cn")]
    public partial class Reply : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string callMdnField;
        
        private string mdnField;
        
        private string contentField;
        
        private string reply_timeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string callMdn {
            get {
                return this.callMdnField;
            }
            set {
                this.callMdnField = value;
                this.RaisePropertyChanged("callMdn");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public string mdn {
            get {
                return this.mdnField;
            }
            set {
                this.mdnField = value;
                this.RaisePropertyChanged("mdn");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public string content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
                this.RaisePropertyChanged("content");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public string reply_time {
            get {
                return this.reply_timeField;
            }
            set {
                this.reply_timeField = value;
                this.RaisePropertyChanged("reply_time");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReplyRequest", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class ReplyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in2;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in3;
        
        public ReplyRequest() {
        }
        
        public ReplyRequest(string in0, string in1, string in2, string in3) {
            this.in0 = in0;
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReplyResponse", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class ReplyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string confirm_time;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string id;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute("replys", IsNullable=true)]
        public demo_csharp.SMS_SERVICE.Reply[] replys;
        
        public ReplyResponse() {
        }
        
        public ReplyResponse(string result, string confirm_time, string id, demo_csharp.SMS_SERVICE.Reply[] replys) {
            this.result = result;
            this.confirm_time = confirm_time;
            this.id = id;
            this.replys = replys;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReplyConfirmRequest", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class ReplyConfirmRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in2;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in3;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in4;
        
        public ReplyConfirmRequest() {
        }
        
        public ReplyConfirmRequest(string in0, string in1, string in2, string in3, string in4) {
            this.in0 = in0;
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
            this.in4 = in4;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ReplyConfirmResponse", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class ReplyConfirmResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string result;
        
        public ReplyConfirmResponse() {
        }
        
        public ReplyConfirmResponse(string result) {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SearchSmsNumRequest", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class SearchSmsNumRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in2;
        
        public SearchSmsNumRequest() {
        }
        
        public SearchSmsNumRequest(string in0, string in1, string in2) {
            this.in0 = in0;
            this.in1 = in1;
            this.in2 = in2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SearchSmsNumResponse", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class SearchSmsNumResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string result;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string number;
        
        public SearchSmsNumResponse() {
        }
        
        public SearchSmsNumResponse(string result, string number) {
            this.result = result;
            this.number = number;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AuditingRequest", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class AuditingRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in2;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string in3;
        
        public AuditingRequest() {
        }
        
        public AuditingRequest(string in0, string in1, string in2, string in3) {
            this.in0 = in0;
            this.in1 = in1;
            this.in2 = in2;
            this.in3 = in3;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AuditingResponse", WrapperNamespace="http://ws.flaginfo.com.cn", IsWrapped=true)]
    public partial class AuditingResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.flaginfo.com.cn", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @out;
        
        public AuditingResponse() {
        }
        
        public AuditingResponse(string @out) {
            this.@out = @out;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SmsPortTypeChannel : demo_csharp.SMS_SERVICE.SmsPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SmsPortTypeClient : System.ServiceModel.ClientBase<demo_csharp.SMS_SERVICE.SmsPortType>, demo_csharp.SMS_SERVICE.SmsPortType {
        
        public SmsPortTypeClient() {
        }
        
        public SmsPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SmsPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SmsPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SmsPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        demo_csharp.SMS_SERVICE.SmsResponse demo_csharp.SMS_SERVICE.SmsPortType.Sms(demo_csharp.SMS_SERVICE.SmsRequest request) {
            return base.Channel.Sms(request);
        }
        
        public string Sms(string in0, string in1, string in2, string in3, string in4, string in5, string in6, string in7, string in8, string in9, string in10) {
            demo_csharp.SMS_SERVICE.SmsRequest inValue = new demo_csharp.SMS_SERVICE.SmsRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            inValue.in3 = in3;
            inValue.in4 = in4;
            inValue.in5 = in5;
            inValue.in6 = in6;
            inValue.in7 = in7;
            inValue.in8 = in8;
            inValue.in9 = in9;
            inValue.in10 = in10;
            demo_csharp.SMS_SERVICE.SmsResponse retVal = ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).Sms(inValue);
            return retVal.@out;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.SmsResponse> demo_csharp.SMS_SERVICE.SmsPortType.SmsAsync(demo_csharp.SMS_SERVICE.SmsRequest request) {
            return base.Channel.SmsAsync(request);
        }
        
        public System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.SmsResponse> SmsAsync(string in0, string in1, string in2, string in3, string in4, string in5, string in6, string in7, string in8, string in9, string in10) {
            demo_csharp.SMS_SERVICE.SmsRequest inValue = new demo_csharp.SMS_SERVICE.SmsRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            inValue.in3 = in3;
            inValue.in4 = in4;
            inValue.in5 = in5;
            inValue.in6 = in6;
            inValue.in7 = in7;
            inValue.in8 = in8;
            inValue.in9 = in9;
            inValue.in10 = in10;
            return ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).SmsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        demo_csharp.SMS_SERVICE.ReportResponse demo_csharp.SMS_SERVICE.SmsPortType.Report(demo_csharp.SMS_SERVICE.ReportRequest request) {
            return base.Channel.Report(request);
        }
        
        public string Report(string in0, string in1, string in2) {
            demo_csharp.SMS_SERVICE.ReportRequest inValue = new demo_csharp.SMS_SERVICE.ReportRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            demo_csharp.SMS_SERVICE.ReportResponse retVal = ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).Report(inValue);
            return retVal.@out;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.ReportResponse> demo_csharp.SMS_SERVICE.SmsPortType.ReportAsync(demo_csharp.SMS_SERVICE.ReportRequest request) {
            return base.Channel.ReportAsync(request);
        }
        
        public System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.ReportResponse> ReportAsync(string in0, string in1, string in2) {
            demo_csharp.SMS_SERVICE.ReportRequest inValue = new demo_csharp.SMS_SERVICE.ReportRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            return ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).ReportAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        demo_csharp.SMS_SERVICE.ReplyResponse demo_csharp.SMS_SERVICE.SmsPortType.Reply(demo_csharp.SMS_SERVICE.ReplyRequest request) {
            return base.Channel.Reply(request);
        }
        
        public string Reply(string in0, string in1, string in2, string in3, out string confirm_time, out string id, out demo_csharp.SMS_SERVICE.Reply[] replys) {
            demo_csharp.SMS_SERVICE.ReplyRequest inValue = new demo_csharp.SMS_SERVICE.ReplyRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            inValue.in3 = in3;
            demo_csharp.SMS_SERVICE.ReplyResponse retVal = ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).Reply(inValue);
            confirm_time = retVal.confirm_time;
            id = retVal.id;
            replys = retVal.replys;
            return retVal.result;
        }
        
        public System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.ReplyResponse> ReplyAsync(demo_csharp.SMS_SERVICE.ReplyRequest request) {
            return base.Channel.ReplyAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        demo_csharp.SMS_SERVICE.ReplyConfirmResponse demo_csharp.SMS_SERVICE.SmsPortType.ReplyConfirm(demo_csharp.SMS_SERVICE.ReplyConfirmRequest request) {
            return base.Channel.ReplyConfirm(request);
        }
        
        public string ReplyConfirm(string in0, string in1, string in2, string in3, string in4) {
            demo_csharp.SMS_SERVICE.ReplyConfirmRequest inValue = new demo_csharp.SMS_SERVICE.ReplyConfirmRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            inValue.in3 = in3;
            inValue.in4 = in4;
            demo_csharp.SMS_SERVICE.ReplyConfirmResponse retVal = ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).ReplyConfirm(inValue);
            return retVal.result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.ReplyConfirmResponse> demo_csharp.SMS_SERVICE.SmsPortType.ReplyConfirmAsync(demo_csharp.SMS_SERVICE.ReplyConfirmRequest request) {
            return base.Channel.ReplyConfirmAsync(request);
        }
        
        public System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.ReplyConfirmResponse> ReplyConfirmAsync(string in0, string in1, string in2, string in3, string in4) {
            demo_csharp.SMS_SERVICE.ReplyConfirmRequest inValue = new demo_csharp.SMS_SERVICE.ReplyConfirmRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            inValue.in3 = in3;
            inValue.in4 = in4;
            return ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).ReplyConfirmAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        demo_csharp.SMS_SERVICE.SearchSmsNumResponse demo_csharp.SMS_SERVICE.SmsPortType.SearchSmsNum(demo_csharp.SMS_SERVICE.SearchSmsNumRequest request) {
            return base.Channel.SearchSmsNum(request);
        }
        
        public string SearchSmsNum(string in0, string in1, string in2, out string number) {
            demo_csharp.SMS_SERVICE.SearchSmsNumRequest inValue = new demo_csharp.SMS_SERVICE.SearchSmsNumRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            demo_csharp.SMS_SERVICE.SearchSmsNumResponse retVal = ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).SearchSmsNum(inValue);
            number = retVal.number;
            return retVal.result;
        }
        
        public System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.SearchSmsNumResponse> SearchSmsNumAsync(demo_csharp.SMS_SERVICE.SearchSmsNumRequest request) {
            return base.Channel.SearchSmsNumAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        demo_csharp.SMS_SERVICE.AuditingResponse demo_csharp.SMS_SERVICE.SmsPortType.Auditing(demo_csharp.SMS_SERVICE.AuditingRequest request) {
            return base.Channel.Auditing(request);
        }
        
        public string Auditing(string in0, string in1, string in2, string in3) {
            demo_csharp.SMS_SERVICE.AuditingRequest inValue = new demo_csharp.SMS_SERVICE.AuditingRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            inValue.in3 = in3;
            demo_csharp.SMS_SERVICE.AuditingResponse retVal = ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).Auditing(inValue);
            return retVal.@out;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.AuditingResponse> demo_csharp.SMS_SERVICE.SmsPortType.AuditingAsync(demo_csharp.SMS_SERVICE.AuditingRequest request) {
            return base.Channel.AuditingAsync(request);
        }
        
        public System.Threading.Tasks.Task<demo_csharp.SMS_SERVICE.AuditingResponse> AuditingAsync(string in0, string in1, string in2, string in3) {
            demo_csharp.SMS_SERVICE.AuditingRequest inValue = new demo_csharp.SMS_SERVICE.AuditingRequest();
            inValue.in0 = in0;
            inValue.in1 = in1;
            inValue.in2 = in2;
            inValue.in3 = in3;
            return ((demo_csharp.SMS_SERVICE.SmsPortType)(this)).AuditingAsync(inValue);
        }
    }
}
