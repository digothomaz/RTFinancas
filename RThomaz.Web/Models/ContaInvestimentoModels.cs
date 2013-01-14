using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class ContaInvestimentoDetailModel : ContaDetailModelBase<ContaInvestimento>
    {
        public ContaInvestimentoDetailModel()
            : base(ContaInvestimentoResource.PageDetailTitle, "ContaInvestimento")
        {
            Entity.TipoContaId = (byte)TipoConta.Investimento;
        }

        public ContaInvestimentoDetailModel(ContaInvestimento entity)
            : base(ContaInvestimentoResource.PageDetailTitle, "ContaInvestimento", entity)
        {

        }
    }
}