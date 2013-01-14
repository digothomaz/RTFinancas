using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class LancamentoDespesaDetailModel : LancamentoDetailModelBase<LancamentoDespesa>
    {
        public LancamentoDespesaDetailModel()
            :base(LancamentoDespesaResource.PageDetailTitle, "LancamentoDespesa")
        {
            Entity.TipoLancamentoId = (byte)TipoLancamento.Despesa;
            
        }

        public LancamentoDespesaDetailModel(LancamentoDespesa entity)
            : base(LancamentoDespesaResource.PageDetailTitle, "LancamentoDespesa", entity)
        {
            
        }      
    }
}