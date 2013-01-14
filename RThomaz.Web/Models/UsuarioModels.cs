using System.Collections.Generic;
using System.Linq;
using RThomaz.Data;
using RThomaz.Data.Common;
using RThomaz.Web.Common;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class UsuarioIndexModel : IndexModelBase<Usuario>
    {
        public UsuarioIndexModel(PagedList<Usuario> pagedList)
            : base(UsuarioResource.PageIndexTitle, "Usuario", pagedList)
        {

        }
    }

    public class UsuarioDetailModel : DetailModelBase<Usuario>
    {
       
        public UsuarioDetailModel()
            : base(UsuarioResource.PageDetailTitle, "Usuario")
        {
            Entity.Ativo = true;
        }

        public UsuarioDetailModel(Usuario entity)
            : base(UsuarioResource.PageDetailTitle, "Usuario", entity)
        {
            ConfirmacaoSenha = entity.Senha;
        }

        public string ConfirmacaoSenha
        {
            get;
            set;
        }
    }
}