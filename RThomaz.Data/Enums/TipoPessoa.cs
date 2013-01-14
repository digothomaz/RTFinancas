using System;
using System.ComponentModel;

namespace RThomaz.Data.Enums
{
    public enum TipoPessoa : byte
    {
        [Description("Pessoa Física")]
        Fisica = 1,

        [Description("Pessoa Jurídica")]
        Juridica = 2,
    }
}
