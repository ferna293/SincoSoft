using Colegio.Business;
using Colegio.Entities;
using Colegio.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace Colegio.Web.Console.WS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceNote" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceNote.svc o ServiceNote.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceNote : RestConfiguration, IServiceNote
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

        public NoteInfo Create(NoteInfo note)
        {
            NoteInfo data = null;
            try
            {
                data = Facade.Note.Create(note);
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
                Facade.Note.Delete(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        public void DoWork()
        {
        }

        public NoteInfo Get(string id)
        {
            NoteInfo note = null;
            try
            {
                var number = Convert.ToInt32(id);
                note = Facade.Note.Get(number);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }
            return note;
        }

        public List<NoteInfo> GetList()
        {
            List<NoteInfo> noteList = null;

            try
            {
                noteList = Facade.Note.GetList();
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return noteList;
        }

        public NoteInfo Update(NoteInfo note)
        {
            NoteInfo data = null;

            try
            {
                data = Facade.Note.Update(note);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.BadRequest);
            }

            return data;
        }

        public List<NoteInfo> GetByAlumno(string alumnId, string termId)
        {
            List<NoteInfo> note = null;

            try
            {
                var numberAlumno = Convert.ToInt32(alumnId);
                var numberTerm = Convert.ToInt32(termId);
                note = Facade.Note.GetByAlumno(numberAlumno, numberTerm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return note;
        }
    }
}