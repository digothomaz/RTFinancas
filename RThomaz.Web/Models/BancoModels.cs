using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class BancoIndexModel: IndexModelBase<Banco>
    {
        public BancoIndexModel(PagedList<Banco> pagedList)
            : base(BancoResource.PageIndexTitle, "Banco", pagedList)
        {

        }
    }

    public class BancoDetailModel : DetailModelBase<Banco>
    {
        public BancoDetailModel()
            : base(BancoResource.PageDetailTitle, "Banco")
        {
            
        }

        public BancoDetailModel(Banco entity)
            : base(BancoResource.PageDetailTitle, "Banco", entity)
        {
            
        }
    }
}