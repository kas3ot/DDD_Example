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
    public class ToDoController : Controller
    {
        private readonly IAppToDo _IAppToDo;

        public ToDoController(IAppToDo IAppToDo)
        {
            _IAppToDo = IAppToDo;
        }

        // GET api/Produto
        [HttpGet]
        public IActionResult Get()
        {
            var Lista = _IAppToDo.List();
            var Retorno = new List<ToDoModel>();
            foreach (var item in Lista)
            {
                Retorno.Add(new Models.ToDoModel { Id = item.Id, Title = item.Title, Message = item.Message, Datetime = item.Datetime });
            }
            return Json(Retorno);
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _IAppToDo.GetForId(id);
            return Json(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ToDoModel value)
        {
            var ToDo = _IAppToDo.Add(new ToDo { Title = value.Title, Message = value.Message, Datetime = DateTime.Now });
            if(ToDo == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = ToDo.Id }, ToDo);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ToDo value)
        {
            var prod = _IAppToDo.GetForId(id);
            prod.Title = value.Title;
            prod.Message = value.Message;            
            _IAppToDo.Update(prod);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _IAppToDo.Delete(id);
            return Ok();
        }
    }
}
