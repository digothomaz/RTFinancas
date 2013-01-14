using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class EstadoIndexModel: IndexModelBase<Estado>
    {
        private readonly IList<Pais> _paises;

        public EstadoIndexModel(PagedList<Estado> pagedList, IList<Pais> paises)
            : base(EstadoResource.PageIndexTitle, "Estado", pagedList)
        {
            _paises = paises;
        }

        public IList<Pais> Paises
        {
            get
            {
                return _paises;
            }
        }

        public int? SelectedPaisId
        {
            get;
            set;
        }
    }

    public class EstadoDetailModel : DetailModelBase<Estado>
    {
        private readonly List<Pais> _paises;

        public EstadoDetailModel()
            : base(EstadoResource.PageDetailTitle, "Estado")
        {
            _paises = new List<Pais>();
        }

        public EstadoDetailModel(Estado entity)
            : base(EstadoResource.PageDetailTitle, "Estado", entity)
        {
            _paises = new List<Pais>();
            SelectedPaisId = entity.PaisId;
        }

        public List<Pais> Paises
        {
            get
            {
                return _paises;
            }
        }

        public int SelectedPaisId
        {
            get;
            set;
        }
    }
}