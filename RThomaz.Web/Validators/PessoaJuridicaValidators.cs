using FluentValidation;
using RThomaz.Data;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class PessoaJuridicaDetailModelValidator : PessoaDetailModelValidatorBase<PessoaJuridicaDetailModel, PessoaJuridica>
    {
        public static string NomeFantasiaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", PessoaJuridicaResource.NomeFantasiaTitle);
            }
        }

        public static string RazaoSocialLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", PessoaJuridicaResource.RazaoSocialTitle);
            }
        }        

        public static string CNPJLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", PessoaJuridicaResource.CNPJTitle);
            }
        }

        public static string InscricaoEstadualLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", PessoaJuridicaResource.InscricaoEstadualTitle);
            }
        }

        public PessoaJuridicaDetailModelValidator()
            : base()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.NomeFantasia).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, PessoaJuridicaResource.NomeFantasiaTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.NomeFantasia).Length(1, 200).When(x => !string.IsNullOrEmpty(x.Entity.NomeFantasia)).WithLocalizedMessage(() => NomeFantasiaLengthMessage);
            this.RuleFor(item => item.Entity.RazaoSocial).Length(1, 200).When(x => !string.IsNullOrEmpty(x.Entity.RazaoSocial)).WithLocalizedMessage(() => RazaoSocialLengthMessage);
            this.RuleFor(item => item.Entity.CNPJ).Length(1, 18).When(x => !string.IsNullOrEmpty(x.Entity.CNPJ)).WithLocalizedMessage(() => CNPJLengthMessage);
            this.RuleFor(item => item.Entity.InscricaoEstadual).Length(1, 20).When(x => !string.IsNullOrEmpty(x.Entity.InscricaoEstadual)).WithLocalizedMessage(() => InscricaoEstadualLengthMessage);
        }
    }
}