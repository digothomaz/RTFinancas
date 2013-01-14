using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class GrupoContaIndexModel: IndexModelBase<GrupoConta>
    {
        private readonly IDictionary<byte, string> _listOfTipoConta;

        public GrupoContaIndexModel(PagedList<GrupoConta> pagedList, IDictionary<byte, string> listOfTipoConta)
            : base(GrupoContaResource.PageIndexTitle, "GrupoConta", pagedList)
        {
            _listOfTipoConta = listOfTipoConta;
        }

        public IDictionary<byte, string> ListOfTipoConta
        {
            get
            {
                return _listOfTipoConta;
            }
        }

        public byte? SelectedTipoContaId
        {
            get;
            set;
        }
    }

    public class GrupoContaDetailModel : DetailModelBase<GrupoConta>
    {
        private readonly IDictionary<byte, string> _listOfTipoConta;

        public GrupoContaDetailModel()
            : base(GrupoContaResource.PageDetailTitle, "GrupoConta")
        {
            _listOfTipoConta = new Dictionary<byte, string>();
        }

        public GrupoContaDetailModel(GrupoConta entity)
            : base(GrupoContaResource.PageDetailTitle, "GrupoConta", entity)
        {
            _listOfTipoConta = new Dictionary<byte, string>();
            SelectedTipoContaId = entity.TipoContaId;
        }

        public IDictionary<byte, string> ListOfTipoConta
        {
            get
            {
                return _listOfTipoConta;
            }
        }

        public byte SelectedTipoContaId
        {
            get;
            set;
        }
    }
}