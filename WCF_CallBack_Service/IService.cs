using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace WCF_CallBack_Service
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void GetData(string userName, string password);

        [OperationContract(IsOneWay = true)]
        void GetStoreProcedureData();
    }
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendResult(Department[] arrDept);

        [OperationContract(IsOneWay = true)]
        void SendStoreProcedureResult(string resultinfo);
    }

    [DataContract]
    public class Department
    {
        public int DeptNo { get; set; }
        [DataMember]
        public string DeptName { get; set; }
        [DataMember]
        public int Capacity { get; set; }
    }

}
