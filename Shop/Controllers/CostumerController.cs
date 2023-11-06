using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Commands.Request;
using Shop.Domain.Commands.Response;

namespace Shop.Controllers
{
    [ApiController]
    [Route("v1/costumer")]
    public class CostumerController : ControllerBase
    {
        
     [HttpPost]
     [Route("")]
     public Task<CreateCostumerResponse> Create(
        [FromServices]IMediator mediator,
        [FromBody]CreateCostumerRequest comand
     ){

        return mediator.Send(comand);

     }

    }
}