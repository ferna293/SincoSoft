using Colegio.Data.Access;
using Colegio.Entities;
using Colegio.Interfaces;
using System;
using System.Collections.Generic;

namespace Colegio.Business
{
    internal class Alumno : IAlumno
    {
        public AlumnoDao _dao;

        public AlumnoDao Dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new AlumnoDao();
                }
                return _dao;
            }
        }

        public Alumno()
        {
        }

        public AlumnoInfo Create(AlumnoInfo data)
        {
            AlumnoInfo alumno = null;
            try
            {
                alumno = Dao.Create(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumno;
        }

        public AlumnoInfo Update(AlumnoInfo data)
        {
            AlumnoInfo alumno = null;
            try
            {
                alumno = Dao.Update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumno;
        }

        public AlumnoInfo Get(int id)
        {
            AlumnoInfo alumno = null;
            try
            {
                alumno = Dao.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumno;
        }

        public List<AlumnoInfo> GetList()
        {
            List<AlumnoInfo> alumno = null;
            try
            {
                alumno = Dao.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumno;
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