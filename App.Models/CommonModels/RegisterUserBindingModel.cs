using App.Models.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.CommonModels
{
    public class RegisterUserBindingModel
    {
        public string Id { get; set; }
       
        public string NormalizedUserName { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Alias { get; set; }
        public string DateOfBrith { get; set; }

        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public SignUpTypeEnum SignUpType { get; set; }
    }
    public class RegisterUserValidator : AbstractValidator<RegisterUserBindingModel>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.UserName).NotNull();
        }
    }
}
