using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using DDD_Eample.Models;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace DDD_Eample.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IAppProduto _IAppProduto;

        public ProdutoController(IAppProduto IAppProduto)
        {
            _IAppProduto = IAppProduto;
        }

        // GET api/Produto
        [HttpGet]
        public IActionResult Get()
        {
            var Lista = _IAppProduto.List();
            var Retorno = new List<ProdutoModel>();
            foreach (var item in Lista)
            {
                Retorno.Add(new Models.ProdutoModel { Id = item.Id, NomeProduto = item.NomeProduto });
            }
            return Json(Retorno);
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _IAppProduto.GetForId(id);
            return Json(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ProdutoModel value)
        {
            var Product = _IAppProduto.Add(new Produto { NomeProduto = value.NomeProduto });
            if(Product == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = Product.Id }, Product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Produto value)
        {
            var prod = _IAppProduto.GetForId(id);
            prod.NomeProduto = value.NomeProduto;
            _IAppProduto.Update(prod);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IAppProduto.Delete(id);
            return Ok();
        }
    }
}
