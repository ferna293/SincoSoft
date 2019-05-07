using Colegio.Data.Access;
using Colegio.Entities;
using Colegio.Interfaces;
using System;
using System.Collections.Generic;

namespace Colegio.Business
{
    internal class Note : INote
    {
        public NoteDao _dao;

        public NoteDao Dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new NoteDao();
                }
                return _dao;
            }
        }

        public Note()
        {
        }

        public NoteInfo Create(NoteInfo data)
        {
            NoteInfo note = null;
            try
            {
                note = Dao.Create(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return note;
        }

        public NoteInfo Update(NoteInfo data)
        {
            NoteInfo note = null;
            try
            {
                note = Dao.Update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return note;
        }

        public NoteInfo Get(int id)
        {
            NoteInfo note = null;
            try
            {
                note = Dao.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return note;
        }

        public List<NoteInfo> GetList()
        {
            List<NoteInfo> note = null;
            try
            {
                note = Dao.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return note;
        }

        public void Delete(int id)
        {
            try
            {
                Dao.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NoteInfo> GetByAlumno(int alumnId, int termId)
        {
            List<NoteInfo> note = null;
            try
            {
                note = Dao.GetByAlumno(alumnId, termId);
            }
            catch (Exception)
            {
                throw;
            }
            return note;
        }
    }
}