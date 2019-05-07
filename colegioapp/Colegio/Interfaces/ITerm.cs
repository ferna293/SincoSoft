using Colegio.Entities;
using System.Collections.Generic;

namespace Colegio.Interfaces
{
    public interface ITerm
    {
        TermInfo Create(TermInfo data);

        TermInfo Update(TermInfo data);

        TermInfo Get(int id);

        List<TermInfo> GetList();

        void Delete(int id);
    }
}