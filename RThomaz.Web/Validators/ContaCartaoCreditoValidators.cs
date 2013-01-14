using System;
using System.Globalization;
using FluentValidation;
using RThomaz.Data;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class ContaCartaoCreditoDetailModelValidator : ContaDetailModelValidatorBase<ContaCartaoCreditoDetailModel, ContaCartaoCredito>
    {
        public static string NumeroCartaoLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaCartaoCreditoResource.NumeroCartaoTitle);
            }
        }

        public static string AgenciaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaCartaoCreditoResource.AgenciaTitle);
            }
        }

        public static string NumeroContaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaCartaoCreditoResource.NumeroContaTitle);
            }
        }

        public ContaCartaoCreditoDetailModelValidator()
            : base()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.NumeroCartao).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, ContaCartaoCreditoResource.NumeroCartaoTitle));

            //Banco
            this.RuleFor(item => item.SelectedBancoId).Must((model, value) =>
            {
                if (!value.HasValue) return true;

                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, ContaCartaoCreditoResource.BancoTitle);

            //String Length Validations

            this.RuleFor(item => item.Entity.NumeroCartao).Length(1, 20).When(x => !string.IsNullOrEmpty(x.Entity.NumeroCartao)).WithLocalizedMessage(() => NumeroCartaoLengthMessage);

            this.RuleFor(item => item.Entity.Agencia).Length(1, 10).When(x => !string.IsNullOrEmpty(x.Entity.Agencia)).WithLocalizedMessage(() => AgenciaLengthMessage);

            this.RuleFor(item => item.Entity.NumeroConta).Length(1, 10).When(x => !string.IsNullOrEmpty(x.Entity.NumeroConta)).WithLocalizedMessage(() => NumeroContaLengthMessage);

            //Dias

            this.RuleFor(item => item.Entity.DiaFechamento)
                .Must((model, value) =>
                {
                    return value > 0 && value <= 31;
                })
                .WithMessage(string.Format(ValidationMessagesResource.RangeNumeric, ContaCartaoCreditoResource.DiaFechamentoTitle, 1, 31));

            this.RuleFor(item => item.Entity.DiaVencimento)
                .Must((model, value) =>
                {
                    return value > 0 && value <= 31;
                })
                .WithMessage(string.Format(ValidationMessagesResource.RangeNumeric, ContaCartaoCreditoResource.DiaVencimentoTitle, 1, 31));
        }
    }
}