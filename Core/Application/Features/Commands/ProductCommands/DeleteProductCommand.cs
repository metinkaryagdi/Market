using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands
{
    public class DeleteProductCommand : IRequest
    {
        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }

    }
}
