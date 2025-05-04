﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

    }
}
