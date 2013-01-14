using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class ContaDinheiroDetailModel : ContaDetailModelBase<ContaDinheiro>
    {
        public ContaDinheiroDetailModel()
            : base(ContaDinheiroResource.PageDetailTitle, "ContaDinheiro")
        {
            Entity.TipoContaId = (byte)TipoConta.Dinheiro;
        }

        public ContaDinheiroDetailModel(ContaDinheiro entity)
            : base(ContaDinheiroResource.PageDetailTitle, "ContaDinheiro", entity)
        {

        }
    }
}