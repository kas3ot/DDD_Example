using Application.Interface;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App
{
    public class AppProduto : IAppProduto
    {

        InterfaceProduto _InterfaceProduto;

        public AppProduto(InterfaceProduto InterfaceProduto)
        {
            _InterfaceProduto = InterfaceProduto;
        }


        public Produto Add(Produto Entitie)
        {
            _InterfaceProduto.Add(Entitie);
            return Entitie;
        }

        public void Delete(int Id)
        {
            _InterfaceProduto.Delete(Id);
        }

        public Produto GetForId(int id)
        {
            return _InterfaceProduto.GetForId(id);
        }

        public List<Produto> List()
        {
            return _InterfaceProduto.List();
        }

        public void Update(Produto Entitie)
        {
            _InterfaceProduto.Update(Entitie);
        }
    }
}
