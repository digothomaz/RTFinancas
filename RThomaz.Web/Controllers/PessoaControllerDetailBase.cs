using RThomaz.Data;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public abstract class PessoaControllerDetailBase<TEntity, TDetailModel, TDetailModelValidator>
        : ControllerDetailBase<TEntity, int, TDetailModel, TDetailModelValidator>
        where TEntity : Pessoa
        where TDetailModel : PessoaDetailModelBase<TEntity>
        where TDetailModelValidator : PessoaDetailModelValidatorBase<TDetailModel, TEntity>
    {
        protected override void InitializeListsOfDetailModel(TDetailModel model)
        {            

        }

        protected override void Save(TDetailModel model)
        {
            
        }
    }
}