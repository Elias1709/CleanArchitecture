using FluentValidation;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetPagedUsers
{
    public class GetPagedUsersValidator : AbstractValidator<GetPagedUsersQuery>
    {
        public GetPagedUsersValidator()
        {
            RuleFor(x => x.PageNumber)
                          .GreaterThan(0);

            RuleFor(x => x.PageSize)
                          .GreaterThan(0)
                          .LessThanOrEqualTo(100);
        }
    }
}
