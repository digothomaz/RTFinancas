using FluentValidation;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class PaisDetailModelValidator : AbstractValidator<PaisDetailModel>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", PaisResource.NomeTitle);
            }
        }

        public PaisDetailModelValidator()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, PaisResource.NomeTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);

            //Custom Validators

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            {
                var business = new PaisBusiness();

                if (model.Entity.PaisId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.PaisId);
                    if (originalEntity.Nome.Equals(value)) return true;
                }
                
                return !business.ExistByNome(value);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, PaisResource.ControllerTitle, PaisResource.NomeTitle));
        }
    }
}