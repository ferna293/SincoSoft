using Colegio.Data.Access;
using Colegio.Entities;
using Colegio.Interfaces;
using System;
using System.Collections.Generic;

namespace Colegio.Business
{
    internal class Term : ITerm
    {
        public TermDao _dao;

        public TermDao Dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new TermDao();
                }
                return _dao;
            }
        }

        public Term()
        {
        }

        public TermInfo Create(TermInfo data)
        {
            TermInfo term = null;
            try
            {
                term = Dao.Create(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return term;
        }

        public TermInfo Update(TermInfo data)
        {
            TermInfo term = null;
            try
            {
                term = Dao.Update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return term;
        }

        public TermInfo Get(int id)
        {
            TermInfo term = null;
            try
            {
                term = Dao.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return term;
        }

        public List<TermInfo> GetList()
        {
            List<TermInfo> term = null;
            try
            {
                term = Dao.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return term;
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
    }
}