using FluentValidation;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class CidadeDetailModelValidator : AbstractValidator<CidadeDetailModel>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", CidadeResource.NomeTitle);
            }
        }

        public CidadeDetailModelValidator()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, CidadeResource.NomeTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);

            //Custom Validators

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            {
                var business = new CidadeBusiness();

                if (model.Entity.CidadeId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.CidadeId);
                    if (originalEntity.Nome.Equals(value)) return true;
                }
                
                return !business.ExistByNome(model.SelectedEstadoId, value);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, CidadeResource.ControllerTitle, CidadeResource.NomeTitle));

            this.RuleFor(item => item.SelectedEstadoId).Must((model, value) =>
            {
                if (model.Entity.CidadeId > 0) return true;
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, CidadeResource.EstadoTitle);
        }
    }
}