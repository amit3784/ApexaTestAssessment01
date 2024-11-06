using ApexaTechAssess.Api.Features.AdvisorFeatures.Commands;
using FluentValidation;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Validations
{
    public class CreateAdvisorCommandValidator : AbstractValidator<CreateAdvisorCommand>
    {
        public CreateAdvisorCommandValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name can not be empty!");
            RuleFor(x => x.FullName).MaximumLength(255).WithMessage("Full name should be less than 255 characters length!");
            RuleFor(adv => adv.SIN).Length(9).WithMessage("SIN Number should be 9 digit number!!");
            RuleFor(adv => adv.SIN).Must(CommonValidations.isValidSIN).WithMessage("SIN Number should be valid one!");
            RuleFor(adv => adv.PhoneNumber).Length(10).WithMessage("Phone number should be 10 digit number!!");
            RuleFor(adv => adv.PhoneNumber).Must(CommonValidations.isValidPhone).WithMessage("Phone Number should be valid one!");
        }
       
    }
}
