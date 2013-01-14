using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class ContaCobrancaBancariaDetailModel : ContaDetailModelBase<ContaCobrancaBancaria>
    {
        private readonly List<Banco> _bancos;

        public ContaCobrancaBancariaDetailModel()
            : base(ContaCobrancaBancariaResource.PageDetailTitle, "ContaCobrancaBancaria")
        {
            Entity.TipoContaId = (byte)TipoConta.CobrancaBancaria;
            _bancos = new List<Banco>();
        }

        public ContaCobrancaBancariaDetailModel(ContaCobrancaBancaria entity)
            : base(ContaCobrancaBancariaResource.PageDetailTitle, "ContaCobrancaBancaria", entity)
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