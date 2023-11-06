using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Commands.Response;

namespace Shop.Domain.Commands.Request
{
    public class CreateCostumerRequest : IRequest<CreateCostumerResponse>
    {
        public String Name { get; set; }
        public String Email { get; set; }
    }
}