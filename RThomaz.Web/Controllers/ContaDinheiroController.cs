using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class ContaDinheiroController : ContaControllerDetailBase<ContaDinheiro, ContaDinheiroDetailModel, ContaDinheiroDetailModelValidator>
    {
        #region Detail

        protected override ContaDinheiro GetEntityById(int id)
        {
            var business = new ContaDinheiroBusiness();
            return business.GetById(id);
        }

        protected override void Save(ContaDinheiroDetailModel model)
        {
            base.Save(model);

            var business = new ContaDinheiroBusiness();

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
