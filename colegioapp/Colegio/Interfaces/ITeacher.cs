using Colegio.Entities;
using System.Collections.Generic;

namespace Colegio.Interfaces
{
    public interface ITeacher
    {
        TeacherInfo Create(TeacherInfo data);

        TeacherInfo Update(TeacherInfo data);

        TeacherInfo Get(int id);

        List<TeacherInfo> GetList();

        void Delete(int id);
    }
}