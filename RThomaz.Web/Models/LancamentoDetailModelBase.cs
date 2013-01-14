using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Web.Common;

namespace RThomaz.Web.Models
{
    public abstract class LancamentoDetailModelBase<TLancamento> : DetailModelBase<TLancamento>
        where TLancamento : Lancamento
    {
        private readonly List<Conta> _contas;
        private readonly List<Pessoa> _pessoas;

        public LancamentoDetailModelBase(string title, string controllerName)
            : base(title, controllerName, "../Lancamento/Index/")
        {
            _contas = new List<Conta>();
            _pessoas = new List<Pessoa>();
        }

        public LancamentoDetailModelBase(string title, string controllerName, TLancamento entity)
            : base(title, controllerName, entity, "../Lancamento/Index/")
        {
            _contas = new List<Conta>();
            _pessoas = new List<Pessoa>();

            SelectedContaId = entity.ContaId;
            SelectedPessoaId = entity.PessoaId;
        }

        public List<Conta> Contas
        {
            get
            {
                return _contas;
            }
        }

        public List<Pessoa> Pessoas
        {
            get
            {
                return _pessoas;
            }
        }

        public int SelectedContaId
        {
            get;
            set;
        }

        public int? SelectedPessoaId
        {
            get;
            set;
        }
    }
}