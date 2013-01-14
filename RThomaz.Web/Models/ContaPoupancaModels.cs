using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class ContaPoupancaDetailModel : ContaDetailModelBase<ContaPoupanca>
    {
        private readonly List<Banco> _bancos;

        public ContaPoupancaDetailModel()
            : base(ContaPoupancaResource.PageDetailTitle, "ContaPoupanca")
        {
            Entity.TipoContaId = (byte)TipoConta.Poupanca;
            _bancos = new List<Banco>();
        }

        public ContaPoupancaDetailModel(ContaPoupanca entity)
            : base(ContaPoupancaResource.PageDetailTitle, "ContaPoupanca", entity)
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