using Colegio.Business;
using Colegio.Entities;
using Colegio.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace Colegio.Web.Console.WS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceTerm" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceTerm.svc o ServiceTerm.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceTerm : RestConfiguration, IServiceTerm
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

        public TermInfo Create(TermInfo term)
        {
            TermInfo data = null;
            try
            {
                data = Facade.Term.Create(term);
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
                Facade.Term.Delete(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public void DoWork()
        {
        }

        public TermInfo Get(string id)
        {
            TermInfo term = null;
            try
            {
                var number = Convert.ToInt32(id);
                term = Facade.Term.Get(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
            return term;
        }

        public List<TermInfo> GetList()
        {
            List<TermInfo> termList = null;

            try
            {
                termList = Facade.Term.GetList();
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return termList;
        }

        public TermInfo Update(TermInfo term)
        {
            TermInfo data = null;

            try
            {
                data = Facade.Term.Update(term);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return data;
        }
    }
}