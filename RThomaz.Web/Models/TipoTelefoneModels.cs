using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class TipoTelefoneIndexModel: IndexModelBase<TipoTelefone>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public TipoTelefoneIndexModel(PagedList<TipoTelefone> pagedList, IDictionary<byte, string> listOfTipoPessoa)
            : base(TipoTelefoneResource.PageIndexTitle, "TipoTelefone", pagedList)
        {
            _listOfTipoPessoa = listOfTipoPessoa;
        }

        public IDictionary<byte, string> ListOfTipoPessoa
        {
            get
            {
                return _listOfTipoPessoa;
            }
        }

        public byte? SelectedTipoPessoaId
        {
            get;
            set;
        }
    }

    public class TipoTelefoneDetailModel : DetailModelBase<TipoTelefone>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public TipoTelefoneDetailModel()
            : base(TipoTelefoneResource.PageDetailTitle, "TipoTelefone")
        {
            _listOfTipoPessoa = new Dictionary<byte, string>();
        }

        public TipoTelefoneDetailModel(TipoTelefone entity)
            : base(TipoTelefoneResource.PageDetailTitle, "TipoTelefone", entity)
        {
            _listOfTipoPessoa = new Dictionary<byte, string>();
            SelectedTipoPessoaId = entity.TipoPessoaId;
        }

        public IDictionary<byte, string> ListOfTipoPessoa
        {
            get
            {
                return _listOfTipoPessoa;
            }
        }

        public byte SelectedTipoPessoaId
        {
            get;
            set;
        }
    }
}