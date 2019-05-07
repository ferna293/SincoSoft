using Colegio.Data.Context;
using Colegio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Data.Access
{
    internal class MatterDao
    {
        public MatterInfo Create(MatterInfo matter)
        {
            MatterInfo matterInfo = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    matterInfo = context.Matters.Add(matter);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return matterInfo;
        }

        public MatterInfo Update(MatterInfo matter)
        {
            MatterInfo matterOld = new MatterInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    matterOld = context.Matters.Where(x => x.Id == matter.Id).FirstOrDefault();

                    if (matterOld != null)
                    {
                        context.Entry(matterOld).CurrentValues.SetValues(matter);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return matter;
        }

        public MatterInfo Get(int id)
        {
            MatterInfo matter = new MatterInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    matter = context.Matters.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return matter;
        }

        public List<MatterInfo> GetList()
        {
            List<MatterInfo> matterList = null;

            try
            {
                using (DBContext context = new DBContext())
                {
                    matterList = context.Matters.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return matterList;
        }

        public void Delete(int id)
        {
            MatterInfo matter = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    matter = context.Matters.Where(x => x.Id == id).FirstOrDefault();
                    context.Matters.Remove(matter);
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