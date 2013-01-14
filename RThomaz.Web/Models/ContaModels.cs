using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    #region Index

    public class ContaIndexModel : IndexModelBase<Conta>
    {
        private readonly IList<GrupoConta> _listOfGrupoConta;
        private readonly IDictionary<byte, string> _listOfTipoConta;

        public ContaIndexModel(PagedList<Conta> pagedList, IDictionary<byte, string> listOfTipoConta, IList<GrupoConta> listOfGrupoConta)
            : base(ContaResource.PageIndexTitle, "Conta", pagedList)
        {
            _listOfGrupoConta = listOfGrupoConta;
            _listOfTipoConta = listOfTipoConta;
        }

        public IList<GrupoConta> ListOfGrupoConta
        {
            get
            {
                return _listOfGrupoConta;
            }
        }

        public int? SelectedGrupoContaId
        {
            get;
            set;
        }

        public IDictionary<byte, string> ListOfTipoConta
        {
            get
            {
                return _listOfTipoConta;
            }
        }

        public short? SelectedTipoContaId
        {
            get;
            set;
        }
    }

    #endregion
}