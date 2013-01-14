using FluentValidation;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class BancoDetailModelValidator : AbstractValidator<BancoDetailModel>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", BancoResource.NomeTitle);
            }
        }

        public static string NumeroLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", BancoResource.NumeroTitle);
            }
        }

        public BancoDetailModelValidator()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, BancoResource.NomeTitle));

            this.RuleFor(item => item.Entity.Numero).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, BancoResource.NumeroTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);

            this.RuleFor(item => item.Entity.Numero).Length(1, 10).When(x => !string.IsNullOrEmpty(x.Entity.Numero)).WithLocalizedMessage(() => NumeroLengthMessage);

            //Custom Validators

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            {
                var business = new BancoBusiness();

                if (model.Entity.BancoId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.BancoId);
                    if (originalEntity.Nome.Equals(value)) return true;
                }
                
                return !business.ExistByNome(value);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, BancoResource.ControllerTitle, BancoResource.NomeTitle));

            //Numero Existente
            this.RuleFor(x => x.Entity.Numero).Must((model, value) =>
            {
                var business = new BancoBusiness();

                if (model.Entity.BancoId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.BancoId);
                    if (originalEntity.Numero.Equals(value)) return true;
                }

                return !business.ExistByNumero(value);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, BancoResource.ControllerTitle, BancoResource.NumeroTitle));
        }
    }
}