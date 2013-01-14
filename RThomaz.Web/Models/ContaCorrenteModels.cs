using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class ContaCorrenteDetailModel : ContaDetailModelBase<ContaCorrente>
    {
        private readonly List<Banco> _bancos;

        public ContaCorrenteDetailModel()
            : base(ContaCorrenteResource.PageDetailTitle, "ContaCorrente")
        {
            Entity.TipoContaId = (byte)TipoConta.ContaCorrente;
            _bancos = new List<Banco>();
        }

        public ContaCorrenteDetailModel(ContaCorrente entity)
            : base(ContaCorrenteResource.PageDetailTitle, "ContaCorrente", entity)
        {
            _bancos = new List<Banco>();
            SelectedBancoId = entity.BancoId;
        }

        public List<Banco> Bancos
        {
            get
            {
                return _bancos;
            }
        }

        public int SelectedBancoId
        {
            get;
            set;
        }
    }
}