using FluentValidation;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class GrupoContaDetailModelValidator : AbstractValidator<GrupoContaDetailModel>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", GrupoContaResource.NomeTitle);
            }
        }

        public GrupoContaDetailModelValidator()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, GrupoContaResource.NomeTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);

            //Custom Validators

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            {
                var business = new GrupoContaBusiness();

                if (model.Entity.GrupoContaId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.GrupoContaId);
                    if (originalEntity.Nome.Equals(value)) return true;
                }
                
                return !business.ExistByNome(value);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, GrupoContaResource.ControllerTitle, GrupoContaResource.NomeTitle));

            this.RuleFor(item => item.SelectedTipoContaId).Must((model, value) =>
            {
                if (model.Entity.GrupoContaId > 0) return true;
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, GrupoContaResource.TipoContaTitle);
        }
    }
}