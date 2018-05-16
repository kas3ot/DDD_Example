using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Generic
{
    public interface IApplicationGeneric<T> where T : class
    {
        T Add(T Entitie);

        void Update(T Entitie);

        void Delete(int Id);

        List<T> List();

        T GetForId(int id);
    }
}
