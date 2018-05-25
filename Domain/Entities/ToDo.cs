using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ToDo
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Message { get; set; }

        public DateTime Datetime { get; set; }
    }
}