using Colegio.Entities;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Colegio.Web.Console.WS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceNote" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceNote
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NoteInfo Create(NoteInfo note);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        NoteInfo Update(NoteInfo note);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/get/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NoteInfo Get(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/list", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<NoteInfo> GetList();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Delete(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/getAlumno/{alumnId}/{termId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<NoteInfo> GetByAlumno(string alumnId, string termid);
    }
}