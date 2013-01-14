using FluentValidation;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class UsuarioDetailModelValidator : AbstractValidator<UsuarioDetailModel>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", UsuarioResource.NomeTitle);
            }
        }

        public static string EmailLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", UsuarioResource.EmailTitle);
            }
        }

        public static string SenhaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", UsuarioResource.SenhaTitle);
            }
        }

        public static string ConfirmacaoSenhaLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", UsuarioResource.ConfirmacaoSenhaTitle);
            }
        }

        public UsuarioDetailModelValidator()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, UsuarioResource.NomeTitle));
            this.RuleFor(item => item.Entity.Email).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, UsuarioResource.EmailTitle));
            this.RuleFor(item => item.Entity.Senha).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, UsuarioResource.SenhaTitle));
            this.RuleFor(item => item.ConfirmacaoSenha).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, UsuarioResource.ConfirmacaoSenhaTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);
            this.RuleFor(item => item.Entity.Email).Length(1, 500).When(x => !string.IsNullOrEmpty(x.Entity.Email)).WithLocalizedMessage(() => EmailLengthMessage);
            this.RuleFor(item => item.Entity.Senha).Length(5, 50).When(x => !string.IsNullOrEmpty(x.Entity.Senha)).WithLocalizedMessage(() => SenhaLengthMessage);
            this.RuleFor(item => item.ConfirmacaoSenha).Length(5, 50).When(x => !string.IsNullOrEmpty(x.ConfirmacaoSenha)).WithLocalizedMessage(() => ConfirmacaoSenhaLengthMessage);
                                   
            //Custom Validations

            this.RuleFor(item => item.Entity.Email).EmailAddress().WithMessage(ValidationMessagesResource.EmailAddress);
            this.RuleFor(item => item.Entity.Senha).Equal(item => item.ConfirmacaoSenha).When(x => !string.IsNullOrEmpty(x.Entity.Senha) && !string.IsNullOrEmpty(x.ConfirmacaoSenha)).WithMessage(ValidationMessagesResource.ConfrmacaoSenhaNotEqual);

            ////Multi Selected Funcoes
            //this.RuleFor(item => item.MultiSelectedFuncaoId).Must((model, value) =>
            //    {
            //        if (value == null || value.Count == 0)
            //            return false;
            //        else
            //            return true;
            //    }
            //).WithMessage(string.Format(ValidationMessagesResource.MultiSelectedRequired, UsuarioResource.FuncoesTitle));

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
                {
                    if (model.Entity.UsuarioId > 0) return true;

                    var business = new UsuarioBusiness();
                    return !business.ExistByNome(value);
                }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, UsuarioResource.ControllerTitle, UsuarioResource.NomeTitle));

            //Email Existente
            this.RuleFor(x => x.Entity.Email).Must((model, value) =>
            {
                if (model.Entity.UsuarioId > 0) return true;

                var business = new UsuarioBusiness();
                return !business.ExistByEmail(value);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, UsuarioResource.ControllerTitle, UsuarioResource.EmailTitle));
        }
    }
}