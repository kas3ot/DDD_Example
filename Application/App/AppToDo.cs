using Application.Interface;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App
{
    public class AppToDo : IAppToDo
    {

        InterfaceToDo _InterfaceToDo;

        public AppToDo(InterfaceToDo InterfaceToDo)
        {
            _InterfaceToDo = InterfaceToDo;
        }


        public ToDo Add(ToDo Entitie)
        {
            _InterfaceToDo.Add(Entitie);
            return Entitie;
        }

        public void Delete(int Id)
        {
            _InterfaceToDo.Delete(Id);
        }

        public ToDo GetForId(int id)
        {
            return _InterfaceToDo.GetForId(id);
        }

        public List<ToDo> List()
        {
            return _InterfaceToDo.List();
        }

        public void Update(ToDo Entitie)
        {
            _InterfaceToDo.Update(Entitie);
        }
    }
}
