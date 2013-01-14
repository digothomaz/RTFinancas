using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class ContaCartaoCreditoController : ContaControllerDetailBase<ContaCartaoCredito, ContaCartaoCreditoDetailModel, ContaCartaoCreditoDetailModelValidator>
    {
        #region Detail

        protected override ContaCartaoCredito GetEntityById(int id)
        {
            var business = new ContaCartaoCreditoBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(ContaCartaoCreditoDetailModel model)
        {
            base.InitializeListsOfDetailModel(model);

            var bancoBusiness = new BancoBusiness();
            var bancos = bancoBusiness.GetAll();

            model.Bancos.AddRange(bancos);
        }

        protected override void Save(ContaCartaoCreditoDetailModel model)
        {
            base.Save(model);

            model.Entity.BancoId = model.SelectedBancoId;

            var business = new ContaCartaoCreditoBusiness();

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
                returnObj.NumeroCartao = model.Entity.NumeroCartao;
                returnObj.BancoId = model.Entity.BancoId;
                returnObj.Agencia = model.Entity.Agencia;
                returnObj.NumeroConta = model.Entity.NumeroConta;
                returnObj.LimiteCredito = model.Entity.LimiteCredito;
                returnObj.DiaFechamento = model.Entity.DiaFechamento;
                returnObj.DiaVencimento = model.Entity.DiaVencimento;

                //Salvar
                business.Save(returnObj);
            }
        }

        #endregion
    }
}
