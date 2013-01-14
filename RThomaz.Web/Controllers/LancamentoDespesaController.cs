using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class LancamentoDespesaController : LancamentoControllerDetailBase<LancamentoDespesa, LancamentoDespesaDetailModel, LancamentoDespesaDetailModelValidator>
    {
        #region Detail          

        protected override LancamentoDespesa GetEntityById(int id)
        {
            var business = new LancamentoDespesaBusiness();
            return business.GetById(id);            
        }        

        protected override void Save(LancamentoDespesaDetailModel model)
        {
            base.Save(model);

            var business = new LancamentoDespesaBusiness();

            if (model.Entity.LancamentoId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.LancamentoId);

                //Comuns                
                returnObj.ContaId = model.Entity.ContaId;
                returnObj.TipoContaId = model.Entity.TipoContaId;
                returnObj.PessoaId = model.Entity.PessoaId;
                returnObj.TipoPessoaId = model.Entity.TipoPessoaId;
                returnObj.DataLancamento = model.Entity.DataLancamento;
                returnObj.ValorLancamento = model.Entity.ValorLancamento;
                returnObj.Numero = model.Entity.Numero;
                returnObj.Historico = model.Entity.Historico;

                //Adicionais                

                //Salvar
                business.Save(returnObj);
            }
        }

        #endregion
    }
}
