using App.Models.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models.CommonModels
{
    public class CredentialsBindingModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public SignUpTypeEnum SignUpType { get; set; }
    }

    public class CredentialsBindingValidator : AbstractValidator<CredentialsBindingModel>
    {
        public CredentialsBindingValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().When(x => x.SignUpType == SignUpTypeEnum.App);
            RuleFor(x => x.Password).NotEmpty().When(x => x.SignUpType == SignUpTypeEnum.App);
            RuleFor(x => x.SignUpType).NotNull().NotEmpty();
        }
    }
}
