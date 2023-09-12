using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users.GetUserByEmailQuery
{
    public class GetUserByMailQueryValidator : AbstractValidator<GetUserByMailRequest>
    {
        public GetUserByMailQueryValidator() 
        {
            RuleFor(x => x.email).NotEmpty();
        }
    }
}
