using Colegio.Data.Context;
using Colegio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Data.Access
{
    internal class TermDao
    {
        public TermInfo Create(TermInfo term)
        {
            TermInfo termInfo = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    termInfo = context.Terms.Add(term);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return termInfo;
        }

        public TermInfo Update(TermInfo term)
        {
            TermInfo termOld = new TermInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    termOld = context.Terms.Where(x => x.Id == term.Id).FirstOrDefault();

                    if (termOld != null)
                    {
                        context.Entry(termOld).CurrentValues.SetValues(term);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return term;
        }

        public TermInfo Get(int id)
        {
            TermInfo term = new TermInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    term = context.Terms.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return term;
        }

        public List<TermInfo> GetList()
        {
            List<TermInfo> termList = null;

            try
            {
                using (DBContext context = new DBContext())
                {
                    termList = context.Terms.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return termList;
        }

        public void Delete(int id)
        {
            TermInfo term = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    term = context.Terms.Where(x => x.Id == id).FirstOrDefault();
                    context.Terms.Remove(term);
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