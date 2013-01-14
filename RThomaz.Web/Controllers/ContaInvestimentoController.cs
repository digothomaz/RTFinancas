using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class ContaInvestimentoController : ContaControllerDetailBase<ContaInvestimento, ContaInvestimentoDetailModel, ContaInvestimentoDetailModelValidator>
    {
        #region Detail

        protected override ContaInvestimento GetEntityById(int id)
        {
            var business = new ContaInvestimentoBusiness();
            return business.GetById(id);
        }

        protected override void Save(ContaInvestimentoDetailModel model)
        {
            base.Save(model);

            var business = new ContaInvestimentoBusiness();

            if (model.Entity.ContaId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.ContaId);

                //Comuns
                returnObj.Nome = model.Entity.Nome;
                returnObj.SaldoAberturaData = model.Entity.SaldoAberturaData;
                returnObj.SaldoAberturaValor = model.Entity.SaldoAberturaValor;
                returnObj.Ativo = model.Entity.Ativo;
                returnObj.GrupoContaId = model.Entity.GrupoContaId;

                //Adicionais

                //Salvar
                business.Save(returnObj);
            }
        }

        #endregion
    }
}
