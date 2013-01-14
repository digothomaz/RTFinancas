using System;
using System.ComponentModel;

namespace RThomaz.Data.Enums
{
    public enum TipoLancamento : byte
    {
        [Description("Receita")]
        Receita = 1,

        [Description("Despesa")]
        Despesa = 2,
    }
}
