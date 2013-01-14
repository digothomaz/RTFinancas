using FluentValidation;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class TipoEmailDetailModelValidator : AbstractValidator<TipoEmailDetailModel>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", TipoEmailResource.NomeTitle);
            }
        }

        public TipoEmailDetailModelValidator()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, TipoEmailResource.NomeTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);

            //Custom Validators

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            {
                var business = new TipoEmailBusiness();

                if (model.Entity.TipoEmailId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.TipoEmailId);
                    if (originalEntity.Nome.Equals(value)) return true;
                }

                return !business.ExistByNome(value, model.SelectedTipoPessoaId);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, TipoEmailResource.ControllerTitle, TipoEmailResource.NomeTitle));

            this.RuleFor(item => item.SelectedTipoPessoaId).Must((model, value) =>
            {
                if (model.Entity.TipoEmailId > 0) return true;
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, TipoEmailResource.TipoPessoaTitle);
        }
    }
}