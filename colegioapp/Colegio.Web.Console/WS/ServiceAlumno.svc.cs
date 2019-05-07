using Colegio.Business;
using Colegio.Entities;
using Colegio.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace Colegio.Web.Console.WS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceAlumno" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceAlumno.svc o ServiceAlumno.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceAlumno : RestConfiguration, IServiceAlumno
    {
        private Factory facade;

        public Factory Facade
        {
            get
            {
                if (facade == null)
                {
                    facade = new Factory();
                }
                return facade;
            }
        }

        public AlumnoInfo Create(AlumnoInfo alumno)
        {
            AlumnoInfo data = null;
            try
            {
                data = Facade.Alumno.Create(alumno);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
            return data;
        }

        public void Delete(string id)
        {
            try
            {
                var number = Convert.ToInt32(id);
                Facade.Alumno.Delete(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public void DoWork()
        {
        }

        public AlumnoInfo Get(string id)
        {
            AlumnoInfo alumno = null;
            try
            {
                var number = Convert.ToInt32(id);
                alumno = Facade.Alumno.Get(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
            return alumno;
        }

        public List<AlumnoInfo> GetList()
        {
            List<AlumnoInfo> alumnoList = null;

            try
            {
                alumnoList = Facade.Alumno.GetList();
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return alumnoList;
        }

        public AlumnoInfo Update(AlumnoInfo alumno)
        {
            AlumnoInfo data = null;

            try
            {
                data = Facade.Alumno.Update(alumno);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return data;
        }
    }
}