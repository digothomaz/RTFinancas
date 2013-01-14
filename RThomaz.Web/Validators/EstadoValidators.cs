using FluentValidation;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class EstadoDetailModelValidator : AbstractValidator<EstadoDetailModel>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", EstadoResource.NomeTitle);
            }
        }

        public static string UFLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", EstadoResource.UFTitle);
            }
        }

        public EstadoDetailModelValidator()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, EstadoResource.NomeTitle));
            this.RuleFor(item => item.Entity.UF).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, EstadoResource.UFTitle));
            
            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);
            this.RuleFor(item => item.Entity.UF).Length(1, 2).When(x => !string.IsNullOrEmpty(x.Entity.UF)).WithLocalizedMessage(() => UFLengthMessage);

            //Custom Validators

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            {
                var business = new EstadoBusiness();

                if (model.Entity.EstadoId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.EstadoId);
                    if (originalEntity.Nome.Equals(value)) return true;
                }
                
                return !business.ExistByNome(model.SelectedPaisId, value);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, EstadoResource.ControllerTitle, EstadoResource.NomeTitle));

            //UF Existente
            this.RuleFor(x => x.Entity.UF).Must((model, value) =>
            {
                var business = new EstadoBusiness();

                if (model.Entity.EstadoId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.EstadoId);
                    if (originalEntity.UF.Equals(value)) return true;
                }

                return !business.ExistByUF(model.SelectedPaisId, value);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, EstadoResource.ControllerTitle, EstadoResource.UFTitle));

            this.RuleFor(item => item.SelectedPaisId).Must((model, value) =>
            {
                if (model.Entity.EstadoId > 0) return true;
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, EstadoResource.PaisTitle);
        }
    }
}