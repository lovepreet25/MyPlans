using FluentValidation;
using MyPlansLibrary.Models;

namespace MyPlansLibrary.Validator
{
    public class PlanDetailsValidator : AbstractValidator<PlanDetails>
    {
    public PlanDetailsValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(100)
                .WithMessage("Title should be less than 100 Characters");
            RuleFor(p => p.Description)
                .MaximumLength(1000)
                .WithMessage("maximum length for the description is 1000 characters");


        
        
        
        
        
        
        }
    
    
    
    }
}
