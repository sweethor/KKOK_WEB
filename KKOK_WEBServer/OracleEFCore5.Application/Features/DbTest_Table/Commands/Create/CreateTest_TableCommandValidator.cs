using FluentValidation;
using OracleEFCore5.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public class CreateTestTableCommandValidator : AbstractValidator<CreateTestTableCommand>
    {
        private readonly ITestTableRepositoryAsync testtableRepository;

        public CreateTestTableCommandValidator(ITestTableRepositoryAsync testtableRepository)
        {
            this.testtableRepository = testtableRepository;

            RuleFor(p => p.TestName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniquetestName).WithMessage("{PropertyName} already exists.");

        }

        private async Task<bool> IsUniquetestName(string testname, CancellationToken cancellationToken)
        {
            return await testtableRepository.IsUniqueTestNameAsync(testname);
        }
    }
}
