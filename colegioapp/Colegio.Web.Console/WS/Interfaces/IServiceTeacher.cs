using Colegio.Entities;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Colegio.Web.Console.WS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceTeacher" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceTeacher
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        TeacherInfo Create(TeacherInfo teacher);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        TeacherInfo Update(TeacherInfo teacher);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/get/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        TeacherInfo Get(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/list", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<TeacherInfo> GetList();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Delete(string id);
    }
}