using Business.DTOs.Requests.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CreateTypeValidator:AbstractValidator<CreateTypeRequest>
    {
        public CreateTypeValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Name).MinimumLength(2);
        }
    }

    public class UpdateTypeValidator : AbstractValidator<UpdateTypeRequest>
    {
        public UpdateTypeValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Name).MinimumLength(2);
        }
    }
}
