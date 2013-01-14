using FluentValidation;
using RThomaz.Data;
using RThomaz.Web.Models;

namespace RThomaz.Web.Validators
{
    public abstract class PessoaDetailModelValidatorBase<TPessoaDetailModel, TPessoa> : AbstractValidator<TPessoaDetailModel>
        where TPessoaDetailModel : PessoaDetailModelBase<TPessoa>
        where TPessoa : Pessoa
    {
        public PessoaDetailModelValidatorBase()
        {
            ////Tipo Pessoa
            //this.RuleFor(item => item.).Must((model, value) =>
            //{
            //    if (model.Entity.PessoaId > 0) return true;
            //    if (value.Equals(0)) return false;
            //    return true;
            //}
            //).WithMessage(ValidationMessagesResource.SelectedRequired, PessoaResource.TipoPessoaTitle);
        }
    }
}