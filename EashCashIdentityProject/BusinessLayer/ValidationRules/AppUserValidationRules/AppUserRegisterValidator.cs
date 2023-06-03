using DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreler eşleşmiyor");
        }
    }
}
