using FluentValidation;
using RThomaz.Data.Business;
using RThomaz.Web.Content.Resources;
using RThomaz.Web.Models;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Validators
{
    public class TipoHomePageDetailModelValidator : AbstractValidator<TipoHomePageDetailModel>
    {
        public static string NomeLengthMessage
        {
            get
            {
                return ValidationMessagesResource.StringLength.Replace("{PropertyName}", TipoHomePageResource.NomeTitle);
            }
        }

        public TipoHomePageDetailModelValidator()
        {
            //NotEmpty Validations

            this.RuleFor(item => item.Entity.Nome).NotEmpty().WithMessage(string.Format(ValidationMessagesResource.NotEmpty, TipoHomePageResource.NomeTitle));

            //String Length Validations
            this.RuleFor(item => item.Entity.Nome).Length(1, 50).When(x => !string.IsNullOrEmpty(x.Entity.Nome)).WithLocalizedMessage(() => NomeLengthMessage);

            //Custom Validators

            //Nome Existente
            this.RuleFor(x => x.Entity.Nome).Must((model, value) =>
            {
                var business = new TipoHomePageBusiness();

                if (model.Entity.TipoHomePageId > 0)
                {
                    var originalEntity = business.GetById(model.Entity.TipoHomePageId);
                    if (originalEntity.Nome.Equals(value)) return true;
                }

                return !business.ExistByNome(value, model.SelectedTipoPessoaId);
            }
            ).WithMessage(string.Format(ValidationMessagesResource.RegistroExistente, TipoHomePageResource.ControllerTitle, TipoHomePageResource.NomeTitle));

            this.RuleFor(item => item.SelectedTipoPessoaId).Must((model, value) =>
            {
                if (model.Entity.TipoHomePageId > 0) return true;
                if (value.Equals(0)) return false;
                return true;
            }
            ).WithMessage(ValidationMessagesResource.SelectedRequired, TipoHomePageResource.TipoPessoaTitle);
        }
    }
}