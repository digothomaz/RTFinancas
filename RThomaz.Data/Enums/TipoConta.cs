using System;
using System.ComponentModel;

namespace RThomaz.Data.Enums
{
    public enum TipoConta : byte
    {
        [Description("Dinheiro")]
        Dinheiro = 1,

        [Description("Conta Corrente")]
        ContaCorrente = 2,

        [Description("Poupança")]
        Poupanca = 3,

        [Description("Investimento")]
        Investimento = 4,

        [Description("Cartão de Crédito")]
        CartaoCredito = 5,

        [Description("Cobrança Bancária")]
        CobrancaBancaria = 6,
    }
}
