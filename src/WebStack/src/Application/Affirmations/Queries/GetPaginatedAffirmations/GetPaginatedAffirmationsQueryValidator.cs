using FluentValidation;

namespace WebStack.Application.Affirmations.Queries.GetPaginatedAffirmations;
public class GetPaginatedAffirmationsQueryValidator : AbstractValidator<GetPaginatedAffirmationsQuery>
{
    public GetPaginatedAffirmationsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber must be greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(5).WithMessage("PageSize must be greater than or equal to 5.");
    }
}
