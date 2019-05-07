using Colegio.Data.Context;
using Colegio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Data.Access
{
    internal class AlumnoDao
    {
        public AlumnoInfo Create(AlumnoInfo alumno)
        {
            AlumnoInfo alumnoInfo = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    alumnoInfo = context.Alumnos.Add(alumno);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumnoInfo;
        }

        public AlumnoInfo Update(AlumnoInfo alumno)
        {
            AlumnoInfo alumnoOld = new AlumnoInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    alumnoOld = context.Alumnos.Where(x => x.Id == alumno.Id).FirstOrDefault();

                    if (alumnoOld != null)
                    {
                        context.Entry(alumnoOld).CurrentValues.SetValues(alumno);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumno;
        }

        public AlumnoInfo Get(int id)
        {
            AlumnoInfo alumno = new AlumnoInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    alumno = context.Alumnos.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumno;
        }

        public List<AlumnoInfo> GetList()
        {
            List<AlumnoInfo> alumnoList = null;

            try
            {
                using (DBContext context = new DBContext())
                {
                    alumnoList = context.Alumnos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return alumnoList;
        }

        public void Delete(int id)
        {
            AlumnoInfo alumno = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    alumno = context.Alumnos.Where(x => x.Id == id).FirstOrDefault();
                    context.Alumnos.Remove(alumno);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}