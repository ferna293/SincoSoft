using Colegio.Business;
using Colegio.Entities;
using Colegio.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace Colegio.Web.Console.WS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceTeacher" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceTeacher.svc o ServiceTeacher.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceTeacher : RestConfiguration, IServiceTeacher
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

        public TeacherInfo Create(TeacherInfo teacher)
        {
            TeacherInfo data = null;
            try
            {
                data = Facade.Teacher.Create(teacher);
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
                Facade.Teacher.Delete(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public void DoWork()
        {
        }

        public TeacherInfo Get(string id)
        {
            TeacherInfo teacher = null;
            try
            {
                var number = Convert.ToInt32(id);
                teacher = Facade.Teacher.Get(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
            return teacher;
        }

        public List<TeacherInfo> GetList()
        {
            List<TeacherInfo> teacherList = null;

            try
            {
                teacherList = Facade.Teacher.GetList();
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return teacherList;
        }

        public TeacherInfo Update(TeacherInfo teacher)
        {
            TeacherInfo data = null;

            try
            {
                data = Facade.Teacher.Update(teacher);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return data;
        }
    }
}