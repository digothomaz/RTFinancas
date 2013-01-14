using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class LancamentoReceitaDetailModel : LancamentoDetailModelBase<LancamentoReceita>
    {
        public LancamentoReceitaDetailModel()
            :base(LancamentoReceitaResource.PageDetailTitle, "LancamentoReceita")
        {
            Entity.TipoLancamentoId = (byte)TipoLancamento.Receita;
        }

        public LancamentoReceitaDetailModel(LancamentoReceita entity)
            : base(LancamentoReceitaResource.PageDetailTitle, "LancamentoReceita", entity)
        {
            
        }
    }
}