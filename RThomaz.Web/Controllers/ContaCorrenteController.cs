using System.Linq;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class ContaCorrenteController : ContaControllerDetailBase<ContaCorrente, ContaCorrenteDetailModel, ContaCorrenteDetailModelValidator>
    {
        #region Detail

        protected override ContaCorrente GetEntityById(int id)
        {
            var business = new ContaCorrenteBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(ContaCorrenteDetailModel model)
        {
            base.InitializeListsOfDetailModel(model);

            var bancoBusiness = new BancoBusiness();
            var bancos = bancoBusiness.GetAll();

            model.Bancos.AddRange(bancos);
        }

        protected override void Save(ContaCorrenteDetailModel model)
        {
            base.Save(model);

            model.Entity.BancoId = model.SelectedBancoId;

            var business = new ContaCorrenteBusiness();

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
                returnObj.BancoId = model.Entity.BancoId;
                returnObj.Agencia = model.Entity.Agencia;
                returnObj.NumeroConta = model.Entity.NumeroConta;
                returnObj.LimiteCredito = model.Entity.LimiteCredito;
                returnObj.LimiteVencimento = model.Entity.LimiteVencimento;

                //Salvar
                business.Save(returnObj);
            }
        }

        #endregion
    }
}
