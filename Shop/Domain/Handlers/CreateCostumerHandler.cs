using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Commands.Request;
using Shop.Domain.Commands.Response;

namespace Shop.Domain.Handlers
{
    public class CreateCostumerHandler : IRequestHandler<CreateCostumerRequest, CreateCostumerResponse>
    {
        public async Task<CreateCostumerResponse> Handle(CreateCostumerRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateCostumerResponse
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Date = DateTime.Now
            };

            return await Task.FromResult(result);
        }
    }
}