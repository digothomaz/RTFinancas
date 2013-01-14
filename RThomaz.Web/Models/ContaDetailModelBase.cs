using System;
using System.Collections.Generic;
using RThomaz.Data;
using RThomaz.Web.Common;

namespace RThomaz.Web.Models
{
    public abstract class ContaDetailModelBase<TConta> : DetailModelBase<TConta>
        where TConta : Conta
    {
        private readonly List<GrupoConta> _listOfGrupoConta;

        public ContaDetailModelBase(string title, string controllerName)
            : base(title, controllerName, "../Conta/Index/")
        {
            _listOfGrupoConta = new List<GrupoConta>();
            Entity.Ativo = true;
            Entity.SaldoAberturaData = DateTime.Now;
        }

        public ContaDetailModelBase(string title, string controllerName, TConta entity)
            : base(title, controllerName, entity, "../Conta/Index/")
        {
            _listOfGrupoConta = new List<GrupoConta>();
            SelectedGrupoContaId = entity.GrupoContaId;
        }

        public List<GrupoConta> ListOfGrupoConta
        {
            get
            {
                return _listOfGrupoConta;
            }
        }

        public int SelectedGrupoContaId
        {
            get;
            set;
        }
    }
}