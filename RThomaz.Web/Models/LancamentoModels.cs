using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    #region Index

    public class LancamentoIndexModel : IndexModelBase<Lancamento>
    {
        private readonly IDictionary<byte, string> _listOfTipoLancamento;

        public LancamentoIndexModel(PagedList<Lancamento> pagedList, IDictionary<byte, string> listOfTipoLancamento)
            : base(LancamentoResource.PageIndexTitle, "Lancamento", pagedList)
        {
            _listOfTipoLancamento = listOfTipoLancamento;
        }

        public IDictionary<byte, string> ListOfTipoLancamento
        {
            get
            {
                return _listOfTipoLancamento;
            }
        }

        public short? SelectedTipoLancamentoId
        {
            get;
            set;
        }
    }

    #endregion
}