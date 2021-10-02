using FluentValidation;

namespace Hestia.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .WithMessage("Name can not be empty!")
                .MaximumLength(20)
                .MinimumLength(3)
                .WithMessage("Name should be betweem 3 and 20 characters!");
        }
    }
}
