using Colegio.Data.Access;
using Colegio.Entities;
using Colegio.Interfaces;
using System;
using System.Collections.Generic;

namespace Colegio.Business
{
    internal class Matter : IMatter
    {
        public MatterDao _dao;

        public MatterDao Dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new MatterDao();
                }
                return _dao;
            }
        }

        public Matter()
        {
        }

        public MatterInfo Create(MatterInfo data)
        {
            MatterInfo matter = null;
            try
            {
                matter = Dao.Create(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return matter;
        }

        public MatterInfo Update(MatterInfo data)
        {
            MatterInfo matter = null;
            try
            {
                matter = Dao.Update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return matter;
        }

        public MatterInfo Get(int id)
        {
            MatterInfo matter = null;
            try
            {
                matter = Dao.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return matter;
        }

        public List<MatterInfo> GetList()
        {
            List<MatterInfo> matter = null;
            try
            {
                matter = Dao.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return matter;
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