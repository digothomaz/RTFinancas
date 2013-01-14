using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RThomaz.Data.Enums
{
    public enum Sexo : byte
    {
        [Description("Masculino")]
        Masculino = 1,

        [Description("Feminino")]
        Feminino = 2,
    }
}
