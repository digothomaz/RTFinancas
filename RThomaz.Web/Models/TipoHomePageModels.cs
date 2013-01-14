using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class TipoHomePageIndexModel : IndexModelBase<TipoHomePage>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public TipoHomePageIndexModel(PagedList<TipoHomePage> pagedList, IDictionary<byte, string> listOfTipoPessoa)
            : base(TipoHomePageResource.PageIndexTitle, "TipoHomePage", pagedList)
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

    public class TipoHomePageDetailModel : DetailModelBase<TipoHomePage>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public TipoHomePageDetailModel()
            : base(TipoHomePageResource.PageDetailTitle, "TipoHomePage")
        {
            _listOfTipoPessoa = new Dictionary<byte, string>();
        }

        public TipoHomePageDetailModel(TipoHomePage entity)
            : base(TipoHomePageResource.PageDetailTitle, "TipoHomePage", entity)
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