using Colegio.Data.Access;
using Colegio.Entities;
using Colegio.Interfaces;
using System;
using System.Collections.Generic;

namespace Colegio.Business
{
    internal class Teacher : ITeacher
    {
        public TeacherDao _dao;

        public TeacherDao Dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = new TeacherDao();
                }
                return _dao;
            }
        }

        public Teacher()
        {
        }

        public TeacherInfo Create(TeacherInfo data)
        {
            TeacherInfo teacher = null;
            try
            {
                teacher = Dao.Create(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teacher;
        }

        public TeacherInfo Update(TeacherInfo data)
        {
            TeacherInfo teacher = null;
            try
            {
                teacher = Dao.Update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teacher;
        }

        public TeacherInfo Get(int id)
        {
            TeacherInfo teacher = null;
            try
            {
                teacher = Dao.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teacher;
        }

        public List<TeacherInfo> GetList()
        {
            List<TeacherInfo> teacher = null;
            try
            {
                teacher = Dao.GetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teacher;
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