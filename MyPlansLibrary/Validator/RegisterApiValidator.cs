using FluentValidation;
using MyPlansLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansLibrary.Validator
{
    public class RegisterApiValidator:AbstractValidator<RegisterAPI>
    {
        public RegisterApiValidator() 
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not a valid email Address ");

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage("First Name is Required")
                .MaximumLength(25)
                .WithMessage("First Name should not be more than 25 characters");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .WithMessage("Last Name is Required")
                .MaximumLength(25)
                .WithMessage("Last Name should not be more than 25 characters");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(5)
                .WithMessage("Password must be at least 5 character");


            RuleFor(p => p.ConfirmPassword)
               .NotEmpty()
               .Equal(p => p.Password)
               .WithMessage("Confirm Password should match the Password ");

            




        }   
    }
}
