﻿using Colegio.Entities;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Colegio.Web.Console.WS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceAlumno" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceAlumno
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AlumnoInfo Create(AlumnoInfo alumno);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        AlumnoInfo Update(AlumnoInfo alumno);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/get/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AlumnoInfo Get(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/list", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<AlumnoInfo> GetList();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Delete(string id);
    }
}