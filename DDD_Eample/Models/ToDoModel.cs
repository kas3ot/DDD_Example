using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD_Eample.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Message { get; set; }

        public DateTime Datetime { get; set; }
    }
}
