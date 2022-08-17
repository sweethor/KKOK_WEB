using FluentValidation;
using OracleEFCore5.Application.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public class CreateMemberNoticeCommandValidator : AbstractValidator<CreateMemberNoticeCommand>
    {
        private readonly IMemberNoticeRepositoryAsync membernoticeRepository;

        public CreateMemberNoticeCommandValidator(IMemberNoticeRepositoryAsync membernoticeRepository)
        {
            this.membernoticeRepository = membernoticeRepository;

            /*RuleFor(p => p.Member_Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniquecode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Member_ID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Member_PWD)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Member_Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Member_Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Member_Phone)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Member_Permission)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");*/

        }

        private async Task<bool> IsUniquecode(string code, CancellationToken cancellationToken)
        {
            return await membernoticeRepository.IsUniqueMemberNoticeCodeAsync(code);
        }
    }
}
