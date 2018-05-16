using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface.Generic
{
    public interface InterfaceGeneric<T> where T : class
    {
        void Add(T Entitie);

        void Update(T Entitie);

        void Delete(int Id);

        List<T> List();

        T GetForId(int id);
    }
}
