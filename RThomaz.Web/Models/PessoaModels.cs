using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    #region Index

    public class PessoaIndexModel: IndexModelBase<Pessoa>
    {
        private readonly IDictionary<byte, string> _listOfTipoPessoa;

        public PessoaIndexModel(PagedList<Pessoa> pagedList, IDictionary<byte, string> listOfTipoPessoa)
            : base(PessoaResource.PageIndexTitle, "Pessoa", pagedList)
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

        public short? SelectedTipoPessoaId
        {
            get;
            set;
        }
    }

    #endregion
}