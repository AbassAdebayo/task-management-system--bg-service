using Application.Abstractions.Messaging;
using Domain.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetUserByEmailQuery
{
    public sealed record GetUserByMailRequest(string email) : IQuery<GetUserByMailResponse>
    {
    }
}
