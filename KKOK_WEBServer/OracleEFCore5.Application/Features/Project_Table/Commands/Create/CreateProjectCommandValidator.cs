using FluentValidation;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Create;
using OracleEFCore5.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Project_Table.Commands.Create
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        private readonly IProjectRepositoryAsync projectRepository;

        public CreateProjectCommandValidator(IProjectRepositoryAsync projectRepository)
        {
            this.projectRepository = projectRepository;

            RuleFor(p => p.pjt_code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniquecode).WithMessage("{PropertyName} already exists.");
            RuleFor(p => p.pjt_name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniquecode).WithMessage("{PropertyName} already exists.");
        }

        private async Task<bool> IsUniquecode(string code, CancellationToken cancellationToken)
        {
            return await projectRepository.IsUniqueProjectCodeAsync(code);
        }
    }
}
