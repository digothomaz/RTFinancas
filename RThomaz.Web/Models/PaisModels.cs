using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class PaisIndexModel: IndexModelBase<Pais>
    {
        public PaisIndexModel(PagedList<Pais> pagedList)
            : base(PaisResource.PageIndexTitle, "Pais", pagedList)
        {

        }
    }

    public class PaisDetailModel : DetailModelBase<Pais>
    {
        public PaisDetailModel()
            : base(PaisResource.PageDetailTitle, "Pais")
        {
            
        }

        public PaisDetailModel(Pais entity)
            : base(PaisResource.PageDetailTitle, "Pais", entity)
        {
            
        }
    }
}