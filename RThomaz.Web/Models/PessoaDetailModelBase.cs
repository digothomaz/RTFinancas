using RThomaz.Data;
using RThomaz.Web.Common;

namespace RThomaz.Web.Models
{
    public abstract class PessoaDetailModelBase<TPessoa> : DetailModelBase<TPessoa>
        where TPessoa : Pessoa
    {
        public PessoaDetailModelBase(string title, string controllerName)
            : base(title, controllerName, "../Pessoa/Index/")
        {

        }

        public PessoaDetailModelBase(string title, string controllerName, TPessoa entity)
            : base(title, controllerName, entity, "../Pessoa/Index/")
        {

        }
    }
}