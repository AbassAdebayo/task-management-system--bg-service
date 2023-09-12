using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetAllUserQuerry
{
    public sealed record GetAllUserUserResponse(string name, string email)
    {
    }
}
