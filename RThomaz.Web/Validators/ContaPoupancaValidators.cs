using FluentValidation;
using RThomaz.Data;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class ContaPoupancaDetailModelValidator : ContaDetailModelValidatorBase<ContaPoupancaDetailModel, ContaPoupanca>
    {
        public static string AgenciaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaPoupancaResource.AgenciaTitle);
            }
        }

        public static string NumeroContaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaPoupancaResource.NumeroContaTitle);
            }
        }

        public ContaPoupancaDetailModelValidator()
            : base()
        {
            //Banco
            this.RuleFor(item => item.SelectedBancoId).Must((model, value) =>
            {
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, ContaPoupancaResource.BancoTitle);

            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Agencia).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, ContaPoupancaResource.AgenciaTitle));

            this.RuleFor(item => item.Entity.NumeroConta).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, ContaPoupancaResource.NumeroContaTitle));

            //String Length Validations

            this.RuleFor(item => item.Entity.Agencia).Length(1, 10).When(x => !string.IsNullOrEmpty(x.Entity.Agencia)).WithLocalizedMessage(() => AgenciaLengthMessage);

            this.RuleFor(item => item.Entity.NumeroConta).Length(1, 20).When(x => !string.IsNullOrEmpty(x.Entity.NumeroConta)).WithLocalizedMessage(() => NumeroContaLengthMessage);
        }
    }
}