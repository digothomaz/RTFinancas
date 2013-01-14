using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class ContaCartaoCreditoDetailModel : ContaDetailModelBase<ContaCartaoCredito>
    {
        private readonly List<Banco> _bancos;

        public ContaCartaoCreditoDetailModel()
            : base(ContaCartaoCreditoResource.PageDetailTitle, "ContaCartaoCredito")
        {
            Entity.TipoContaId = (byte)TipoConta.CartaoCredito;
            Entity.DiaVencimento = 1;
            Entity.DiaFechamento = 1;

            _bancos = new List<Banco>();
        }

        public ContaCartaoCreditoDetailModel(ContaCartaoCredito entity)
            : base(ContaCartaoCreditoResource.PageDetailTitle, "ContaCartaoCredito", entity)
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

        public int? SelectedBancoId
        {
            get;
            set;
        }
    }
}