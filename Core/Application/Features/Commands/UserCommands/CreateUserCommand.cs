using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands
{
    public class CreateUserCommand : IRequest
    {
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Role Role { get; set; } // e.g., Admin, User, etc.
    public DateTime CreatedAt { get; set; }
    }
}

