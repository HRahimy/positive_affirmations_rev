using FluentValidation;

namespace WebStack.Application.Affirmations.Commands.CreateAffirmation
{
    public class CreateAffirmationCommandValidator : AbstractValidator<CreateAffirmationCommand>
    {
        public CreateAffirmationCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
