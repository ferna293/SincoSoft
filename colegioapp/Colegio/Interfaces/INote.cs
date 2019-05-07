using Colegio.Entities;
using System.Collections.Generic;

namespace Colegio.Interfaces
{
    public interface INote
    {
        NoteInfo Create(NoteInfo data);

        NoteInfo Update(NoteInfo data);

        NoteInfo Get(int id);

        List<NoteInfo> GetList();

        void Delete(int id);

        List<NoteInfo> GetByAlumno(int alumnId, int termId);
    }
}