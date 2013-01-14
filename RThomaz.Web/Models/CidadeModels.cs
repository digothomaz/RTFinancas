using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class CidadeIndexModel: IndexModelBase<Cidade>
    {
        private readonly IList<Pais> _paises;
        private readonly IList<Estado> _estados;

        public CidadeIndexModel(PagedList<Cidade> pagedList, IList<Pais> paises, IList<Estado> estados)
            : base(CidadeResource.PageIndexTitle, "Cidade", pagedList)
        {
            _paises = paises;
            _estados = estados;
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

        public IList<Estado> Estados
        {
            get
            {
                return _estados;
            }
        }

        public int? SelectedEstadoId
        {
            get;
            set;
        }
    }

    public class CidadeDetailModel : DetailModelBase<Cidade>
    {
        private readonly List<Pais> _paises;
        private readonly List<Estado> _estados;

        public CidadeDetailModel()
            : base(CidadeResource.PageDetailTitle, "Cidade")
        {
            _paises = new List<Pais>();
            _estados = new List<Estado>();   
        }

        public CidadeDetailModel(Cidade entity)
            : base(CidadeResource.PageDetailTitle, "Cidade", entity)
        {
            _paises = new List<Pais>();
            _estados = new List<Estado>();

            SelectedPaisId = entity.Estado.PaisId;            
            SelectedEstadoId = entity.EstadoId;
        }

        public List<Pais> Paises
        {
            get
            {
                return _paises;
            }
        }

        public List<Estado> Estados
        {
            get
            {
                return _estados;
            }
        }

        public int SelectedPaisId
        {
            get;
            set;
        }

        public int SelectedEstadoId
        {
            get;
            set;
        }
    }
}