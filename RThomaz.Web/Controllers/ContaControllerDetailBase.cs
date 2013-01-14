using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public abstract class ContaControllerDetailBase<TEntity, TDetailModel, TDetailModelValidator>
        : ControllerDetailBase<TEntity, int, TDetailModel, TDetailModelValidator>
        where TEntity : Conta
        where TDetailModel : ContaDetailModelBase<TEntity>
        where TDetailModelValidator : ContaDetailModelValidatorBase<TDetailModel, TEntity>
    {
        protected override void InitializeListsOfDetailModel(TDetailModel model)
        {
            var grupoContaBusiness = new GrupoContaBusiness();
            var listOfGrupoConta = grupoContaBusiness.GetByTipoConta(model.Entity.TipoContaId);

            model.ListOfGrupoConta.AddRange(listOfGrupoConta);
        }

        protected override void Save(TDetailModel model)
        {
            model.Entity.GrupoContaId = model.SelectedGrupoContaId;
        }
    }
}