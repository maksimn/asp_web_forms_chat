using System;
using System.Data;
using System.ServiceModel;
using WcfChat.Contracts.Data;

namespace WcfChat.Contracts {
    [ServiceContract]
    public interface IAuthService {
        [OperationContract]
        [FaultContract(typeof(DuplicateNameException))]
        [FaultContract(typeof(Exception))]
        void RegisterUser(UserRegistrationData userData);

        [OperationContract]
        bool AuthenticateUser(string userName, string password);
    }
}
