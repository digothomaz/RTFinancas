using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class TipoEnderecoIndexModel : IndexModelBase<TipoEndereco>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public TipoEnderecoIndexModel(PagedList<TipoEndereco> pagedList, IDictionary<byte, string> listOfTipoPessoa)
            : base(TipoEnderecoResource.PageIndexTitle, "TipoEndereco", pagedList)
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

    public class TipoEnderecoDetailModel : DetailModelBase<TipoEndereco>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public TipoEnderecoDetailModel()
            : base(TipoEnderecoResource.PageDetailTitle, "TipoEndereco")
        {
            _listOfTipoPessoa = new Dictionary<byte, string>();
        }

        public TipoEnderecoDetailModel(TipoEndereco entity)
            : base(TipoEnderecoResource.PageDetailTitle, "TipoEndereco", entity)
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