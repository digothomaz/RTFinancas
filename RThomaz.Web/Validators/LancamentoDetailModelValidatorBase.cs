using System;
using System.Globalization;
using FluentValidation;
using RThomaz.Data;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public abstract class LancamentoDetailModelValidatorBase<TLancamentoDetailModel, TLancamento> : AbstractValidator<TLancamentoDetailModel>
        where TLancamentoDetailModel : LancamentoDetailModelBase<TLancamento>
        where TLancamento : Lancamento
    {
        public static string NumeroLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", LancamentoResource.NumeroTitle);
            }
        }        

        public LancamentoDetailModelValidatorBase()
        {
            //String Length Validations
            this.RuleFor(item => item.Entity.Numero).Length(1, 20).When(x => !string.IsNullOrEmpty(x.Entity.Numero)).WithLocalizedMessage(() => NumeroLengthMessage);

            //DataLancamento
            this.RuleFor(item => item.Entity.DataLancamento)
                .GreaterThanOrEqualTo(DateTime.Parse("01/01/1753", new CultureInfo("pt-BR")))
                .WithMessage(string.Format(ValidationMessagesResource.DateTimeMinValue, LancamentoResource.DataLancamentoTitle));

            //Conta Lançamento Receita Requirido
            this.RuleFor(item => item.SelectedContaId).Must((model, value) =>
            {
                if (model.Entity is LancamentoDespesa) return true;
                if (model.Entity.LancamentoId > 0) return true;
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, LancamentoReceitaResource.ContaTitle);

            //Conta Lançamento Despesa Requirido
            this.RuleFor(item => item.SelectedContaId).Must((model, value) =>
            {
                if (model.Entity is LancamentoReceita) return true;
                if (model.Entity.LancamentoId > 0) return true;
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, LancamentoDespesaResource.ContaTitle);
        }
    }
}