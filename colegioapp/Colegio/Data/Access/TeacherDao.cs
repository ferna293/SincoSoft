using Colegio.Data.Context;
using Colegio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Data.Access
{
    internal class TeacherDao
    {
        public TeacherInfo Create(TeacherInfo teacher)
        {
            TeacherInfo teacherInfo = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    teacherInfo = context.Teachers.Add(teacher);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teacherInfo;
        }

        public TeacherInfo Update(TeacherInfo teacher)
        {
            TeacherInfo teacherOld = new TeacherInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    teacherOld = context.Teachers.Where(x => x.Id == teacher.Id).FirstOrDefault();

                    if (teacherOld != null)
                    {
                        context.Entry(teacherOld).CurrentValues.SetValues(teacher);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teacher;
        }

        public TeacherInfo Get(int id)
        {
            TeacherInfo teacher = new TeacherInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    var teacherData = (from t in context.Teachers
                                       join m in context.Matters on t.IdMatter equals m.Id
                                       select new
                                       {
                                           Id = t.Id,
                                           IdMatter = t.IdMatter,
                                           Name = t.Name,
                                           LastName = t.LastName,
                                           TypeDocument = t.TypeDocument,
                                           NumberDocument = t.NumberDocument,
                                           Email = t.Email,
                                           Telephone = t.Telephone,
                                           MatterName = m.Name,
                                       }).ToList();

                    foreach (var item in teacherData)
                    {
                        teacher.Id = item.Id;
                        teacher.IdMatter = item.IdMatter;
                        teacher.Name = item.Name;
                        teacher.LastName = item.LastName;
                        teacher.TypeDocument = item.TypeDocument;
                        teacher.NumberDocument = item.NumberDocument;
                        teacher.Email = item.Email;
                        teacher.Telephone = item.Telephone;
                        teacher.MatterName = item.MatterName;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teacher;
        }

        public List<TeacherInfo> GetList()
        {
            List<TeacherInfo> teacherList = new List<TeacherInfo>();

            try
            {
                using (DBContext context = new DBContext())
                {
                    var teacher = (from t in context.Teachers
                                   join m in context.Matters on t.IdMatter equals m.Id
                                   select new
                                   {
                                       Id = t.Id,
                                       IdMatter = t.IdMatter,
                                       Name = t.Name,
                                       LastName = t.LastName,
                                       TypeDocument = t.TypeDocument,
                                       NumberDocument = t.NumberDocument,
                                       Email = t.Email,
                                       Telephone = t.Telephone,
                                       MatterName = m.Name,
                                   }).ToList();

                    foreach (var item in teacher)
                    {
                        TeacherInfo teacherInfo = new TeacherInfo();

                        teacherInfo.Id = item.Id;
                        teacherInfo.IdMatter = item.IdMatter;
                        teacherInfo.Name = item.Name;
                        teacherInfo.LastName = item.LastName;
                        teacherInfo.TypeDocument = item.TypeDocument;
                        teacherInfo.NumberDocument = item.NumberDocument;
                        teacherInfo.Email = item.Email;
                        teacherInfo.Telephone = item.Telephone;
                        teacherInfo.MatterName = item.MatterName;

                        teacherList.Add(teacherInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return teacherList;
        }

        public void Delete(int id)
        {
            TeacherInfo teacher = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    teacher = context.Teachers.Where(x => x.Id == id).FirstOrDefault();
                    context.Teachers.Remove(teacher);
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