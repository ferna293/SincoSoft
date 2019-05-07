using Colegio.Entities;
using System.Collections.Generic;

namespace Colegio.Interfaces
{
    public interface IAlumno
    {
        AlumnoInfo Create(AlumnoInfo data);

        AlumnoInfo Update(AlumnoInfo data);

        AlumnoInfo Get(int id);

        List<AlumnoInfo> GetList();

        void Delete(int id);
    }
}