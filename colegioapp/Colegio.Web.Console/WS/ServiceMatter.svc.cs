using Colegio.Business;
using Colegio.Entities;
using Colegio.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace Colegio.Web.Console.WS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceMatter" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceMatter.svc o ServiceMatter.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceMatter : RestConfiguration, IServiceMatter
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

        public MatterInfo Create(MatterInfo matter)
        {
            MatterInfo data = null;
            try
            {
                data = Facade.Matter.Create(matter);
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
                Facade.Matter.Delete(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public void DoWork()
        {
        }

        public MatterInfo Get(string id)
        {
            MatterInfo matter = null;
            try
            {
                var number = Convert.ToInt32(id);
                matter = Facade.Matter.Get(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
            return matter;
        }

        public List<MatterInfo> GetList()
        {
            List<MatterInfo> matterList = null;

            try
            {
                matterList = Facade.Matter.GetList();
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return matterList;
        }

        public MatterInfo Update(MatterInfo matter)
        {
            MatterInfo data = null;

            try
            {
                data = Facade.Matter.Update(matter);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return data;
        }
    }
}