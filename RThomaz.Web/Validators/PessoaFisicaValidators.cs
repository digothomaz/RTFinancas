using System;
using System.Globalization;
using FluentValidation;
using RThomaz.Data;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class PessoaFisicaDetailModelValidator : PessoaDetailModelValidatorBase<PessoaFisicaDetailModel, PessoaFisica>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", PessoaFisicaResource.NomeTitle);
            }
        }

        public static string RGLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", PessoaFisicaResource.RGTitle);
            }
        }

        public static string CPFLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", PessoaFisicaResource.CPFTitle);
            }
        }

        public PessoaFisicaDetailModelValidator()
            : base()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, PessoaFisicaResource.NomeTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 200).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);
            this.RuleFor(item => item.Entity.RG).Length(1, 9).When(x => !string.IsNullOrEmpty(x.Entity.RG)).WithLocalizedMessage(() => RGLengthMessage);
            this.RuleFor(item => item.Entity.CPF).Length(1, 12).When(x => !string.IsNullOrEmpty(x.Entity.CPF)).WithLocalizedMessage(() => CPFLengthMessage);

            //DataNascimento
            this.RuleFor(item => item.Entity.DataNascimento)
                .Must((model, value) =>
                {
                    if (value == null) return true;

                    return value >= DateTime.Parse("01/01/1753", new CultureInfo("pt-BR"));
                })
                .WithMessage(string.Format(ValidationMessagesResource.DateTimeMinValue, PessoaFisicaResource.DataNascimentoTitle));


            //Custom Validators

            ////Nome Existente
            //this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            //{
            //    var business = new PaisBusiness();

            //    if (model.Entity.PaisId > 0)
            //    {
            //        var originalEntity = business.GetById(model.Entity.PaisId);
            //        if (originalEntity.Nome.Equals(value)) return true;
            //    }

            //    return !business.ExistByNome(value);
            //}
            //).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, PaisResource.ControllerTitle, PaisResource.NomeTitle));
        }
    }
}