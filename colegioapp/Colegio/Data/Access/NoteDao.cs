using Colegio.Data.Context;
using Colegio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Data.Access
{
    internal class NoteDao
    {
        public NoteInfo Create(NoteInfo note)
        {
            NoteInfo noteInfo = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    noteInfo = context.Notes.Add(note);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return noteInfo;
        }

        public NoteInfo Update(NoteInfo note)
        {
            NoteInfo noteOld = new NoteInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    noteOld = context.Notes.Where(x => x.Id == note.Id).FirstOrDefault();

                    if (noteOld != null)
                    {
                        context.Entry(noteOld).CurrentValues.SetValues(note);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return note;
        }

        public NoteInfo Get(int id)
        {
            NoteInfo note = new NoteInfo();
            try
            {
                using (DBContext context = new DBContext())
                {
                    note = context.Notes.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return note;
        }

        public List<NoteInfo> GetList()
        {
            List<NoteInfo> noteList = null;

            try
            {
                using (DBContext context = new DBContext())
                {
                    noteList = context.Notes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return noteList;
        }

        public void Delete(int id)
        {
            NoteInfo note = null;
            try
            {
                using (DBContext context = new DBContext())
                {
                    note = context.Notes.Where(x => x.Id == id).FirstOrDefault();
                    context.Notes.Remove(note);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NoteInfo> GetByAlumno(int alumnId, int termId)
        {
            List<NoteInfo> note = new List<NoteInfo>();
            try
            {
                using (DBContext context = new DBContext())
                {
                    var noteData = (from n in context.Notes
                                    join a in context.Alumnos on n.IdAlumno equals a.Id
                                    join m in context.Matters on n.IdMatter equals m.Id
                                    join p in context.Terms on n.IdTerm equals p.Id
                                    where n.IdAlumno == alumnId && n.IdTerm == termId
                                    select new
                                    {
                                        Id = n.Id,
                                        IdAlumno = a.Id,
                                        IdMatter = m.Id,
                                        IdTerm = p.Id,
                                        NameMatter = m.Name,
                                        Notes = n.Notes,
                                        NameTerm = p.Name,
                                    }
                                    ).ToList();

                    foreach (var item in noteData)
                    {
                        NoteInfo noteList = new NoteInfo();

                        noteList.Id = item.Id;
                        noteList.IdAlumno = item.IdAlumno;
                        noteList.IdMatter = item.IdMatter;
                        noteList.IdTerm = item.IdTerm;
                        noteList.NameMatter = item.NameMatter;
                        noteList.NameTerm = item.NameTerm;
                        noteList.Notes = item.Notes;

                        note.Add(noteList);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return note;
        }
    }
}