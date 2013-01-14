using System;
using System.Globalization;
using FluentValidation;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public abstract class ContaDetailModelValidatorBase<TContaDetailModel, TConta> : AbstractValidator<TContaDetailModel>
        where TContaDetailModel : ContaDetailModelBase<TConta>
        where TConta : Conta
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", ContaResource.NomeTitle);
            }
        }

        public ContaDetailModelValidatorBase()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, ContaResource.NomeTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);

            //Custom Validators

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            {
                var business = new ContaBusiness();

                if (model.Entity.ContaId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.ContaId);
                    if (originalEntity.Nome.Equals(value)) return true;
                }

                return !business.ExistByNome(value, model.Entity.TipoContaId);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, ContaResource.ControllerTitle, ContaResource.NomeTitle));

            //Grupo Conta
            this.RuleFor(item => item.SelectedGrupoContaId).Must((model, value) =>
            {
                if (model.Entity.ContaId > 0) return true;
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, ContaResource.GrupoContaTitle);

            //SaldoAberturaData
            this.RuleFor(item => item.Entity.SaldoAberturaData)
                .GreaterThanOrEqualTo(DateTime.Parse("01/01/1753", new CultureInfo("pt-BR")))
                .WithMessage(string.Format(ValidationMessagesResource.DateTimeMinValue, ContaResource.SaldoAberturaDataTitle));

        }
    }
}