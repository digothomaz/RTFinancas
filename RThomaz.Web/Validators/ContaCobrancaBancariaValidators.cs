using FluentValidation;
using RThomaz.Data;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class ContaCobrancaBancariaDetailModelValidator : ContaDetailModelValidatorBase<ContaCobrancaBancariaDetailModel, ContaCobrancaBancaria>
    {
        public static string AgenciaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaCobrancaBancariaResource.AgenciaTitle);
            }
        }

        public static string NumeroContaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaCobrancaBancariaResource.NumeroContaTitle);
            }
        }

        public ContaCobrancaBancariaDetailModelValidator()
            : base()
        {
            //Banco
            this.RuleFor(item => item.SelectedBancoId).Must((model, value) =>
            {
                if (!value.HasValue) return true;

                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, ContaCorrenteResource.BancoTitle);

            //String Length Validations

            this.RuleFor(item => item.Entity.Agencia).Length(1, 10).When(x => !string.IsNullOrEmpty(x.Entity.Agencia)).WithLocalizedMessage(() => AgenciaLengthMessage);

            this.RuleFor(item => item.Entity.NumeroConta).Length(1, 10).When(x => !string.IsNullOrEmpty(x.Entity.NumeroConta)).WithLocalizedMessage(() => NumeroContaLengthMessage);
        }
    }
}