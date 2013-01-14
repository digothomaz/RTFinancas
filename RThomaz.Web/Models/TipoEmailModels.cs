using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class TipoEmailIndexModel : IndexModelBase<TipoEmail>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public TipoEmailIndexModel(PagedList<TipoEmail> pagedList, IDictionary<byte, string> listOfTipoPessoa)
            : base(TipoEmailResource.PageIndexTitle, "TipoEmail", pagedList)
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

    public class TipoEmailDetailModel : DetailModelBase<TipoEmail>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public TipoEmailDetailModel()
            : base(TipoEmailResource.PageDetailTitle, "TipoEmail")
        {
            _listOfTipoPessoa = new Dictionary<byte, string>();
        }

        public TipoEmailDetailModel(TipoEmail entity)
            : base(TipoEmailResource.PageDetailTitle, "TipoEmail", entity)
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