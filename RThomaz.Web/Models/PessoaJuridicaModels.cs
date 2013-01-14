using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class PessoaJuridicaDetailModel : PessoaDetailModelBase<PessoaJuridica>
    {
        public PessoaJuridicaDetailModel()
            :base(PessoaJuridicaResource.PageDetailTitle, "PessoaJuridica")
        {
            Entity.TipoPessoaId = (byte)TipoPessoa.Juridica;
        }

        public PessoaJuridicaDetailModel(PessoaJuridica entity)
            : base(PessoaJuridicaResource.PageDetailTitle, "PessoaJuridica", entity)
        {
            
        }
    }
}