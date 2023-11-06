using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Commands.Response
{
    public class CreateCostumerResponse
    {
        
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime Date { get; set; }
        
    }
}