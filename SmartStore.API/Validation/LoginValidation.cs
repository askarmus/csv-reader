using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartStore.Model;

namespace SmartStore.API.Validation
{
    public class LoginValidation : AbstractValidator<LoginRequestModel> 
    {
        public LoginValidation()
        {
            RuleFor(m => m.Username).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
        }
    }
}
