﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFDBClient.ServiceAuthNS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceAuthNS.IAuth")]
    public interface IAuth {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuth/Autorize", ReplyAction="http://tempuri.org/IAuth/AutorizeResponse")]
        string Autorize(string user, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuth/Autorize", ReplyAction="http://tempuri.org/IAuth/AutorizeResponse")]
        System.Threading.Tasks.Task<string> AutorizeAsync(string user, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuth/UserInfo", ReplyAction="http://tempuri.org/IAuth/UserInfoResponse")]
        string UserInfo(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuth/UserInfo", ReplyAction="http://tempuri.org/IAuth/UserInfoResponse")]
        System.Threading.Tasks.Task<string> UserInfoAsync(string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthChannel : WCFDBClient.ServiceAuthNS.IAuth, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthClient : System.ServiceModel.ClientBase<WCFDBClient.ServiceAuthNS.IAuth>, WCFDBClient.ServiceAuthNS.IAuth {
        
        public AuthClient() {
        }
        
        public AuthClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Autorize(string user, string pass) {
            return base.Channel.Autorize(user, pass);
        }
        
        public System.Threading.Tasks.Task<string> AutorizeAsync(string user, string pass) {
            return base.Channel.AutorizeAsync(user, pass);
        }
        
        public string UserInfo(string token) {
            return base.Channel.UserInfo(token);
        }
        
        public System.Threading.Tasks.Task<string> UserInfoAsync(string token) {
            return base.Channel.UserInfoAsync(token);
        }
    }
}