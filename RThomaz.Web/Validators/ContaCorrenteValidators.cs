using System;
using System.Globalization;
using FluentValidation;
using RThomaz.Data;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class ContaCorrenteDetailModelValidator : ContaDetailModelValidatorBase<ContaCorrenteDetailModel, ContaCorrente>
    {
        public static string AgenciaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaCorrenteResource.AgenciaTitle);
            }
        }

        public static string NumeroContaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaCorrenteResource.NumeroContaTitle);
            }
        }

        public ContaCorrenteDetailModelValidator()
            : base()
        {
            //Banco
            this.RuleFor(item => item.SelectedBancoId).Must((model, value) =>
            {
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, ContaCorrenteResource.BancoTitle);

            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Agencia).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, ContaCorrenteResource.AgenciaTitle));

            this.RuleFor(item => item.Entity.NumeroConta).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, ContaCorrenteResource.NumeroContaTitle));

            //String Length Validations

            this.RuleFor(item => item.Entity.Agencia).Length(1, 10).When(x => !string.IsNullOrEmpty(x.Entity.Agencia)).WithLocalizedMessage(() => AgenciaLengthMessage);

            this.RuleFor(item => item.Entity.NumeroConta).Length(1, 10).When(x => !string.IsNullOrEmpty(x.Entity.NumeroConta)).WithLocalizedMessage(() => NumeroContaLengthMessage);
        }
    }
}