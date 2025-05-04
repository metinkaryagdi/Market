using Application.Features.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.UserQueries
{
    public class GetUserQuery : IRequest<List<GetUserQueryResult>>
    {
        // Add any necessary properties for the query here  
    }
}
