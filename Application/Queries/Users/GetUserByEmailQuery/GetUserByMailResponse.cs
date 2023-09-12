using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetUserByEmailQuery
{
    public sealed record GetUserByMailResponse(string name, string email)
    {
    }
}
