using ApexaTechAssess.Api.Features.AdvisorFeatures.Commands;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using FluentValidation;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.Validations
{
    /// <summary>
    /// this class is used to validate the UpdateAdvisorCommand for the input fields.
    /// </summary>
    public class UpdateAdvisorCommandValidator : AbstractValidator<UpdateAdvisorCommand>
    {
        /// <summary>
        /// this constructor is used to validate the input fields for update advisor command.
        /// </summary>
        public UpdateAdvisorCommandValidator()
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
