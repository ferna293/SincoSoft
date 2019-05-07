using Colegio.Entities;
using System.Collections.Generic;

namespace Colegio.Interfaces
{
    public interface IMatter
    {
        MatterInfo Create(MatterInfo data);

        MatterInfo Update(MatterInfo data);

        MatterInfo Get(int id);

        List<MatterInfo> GetList();

        void Delete(int id);
    }
}