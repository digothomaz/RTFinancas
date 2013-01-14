using RThomaz.Data;
using RThomaz.Data.Enums;
using RThomaz.Web.Resources;

namespace RThomaz.Web.Models
{
    public class PessoaFisicaDetailModel : PessoaDetailModelBase<PessoaFisica>
    {
        public PessoaFisicaDetailModel()
            :base(PessoaFisicaResource.PageDetailTitle, "PessoaFisica")
        {
            Entity.TipoPessoaId = (byte)TipoPessoa.Fisica;
            Entity.Sexo = (byte)Sexo.Masculino;
        }

        public PessoaFisicaDetailModel(PessoaFisica entity)
            : base(PessoaFisicaResource.PageDetailTitle, "PessoaFisica", entity)
        {
            
        }
    }
}