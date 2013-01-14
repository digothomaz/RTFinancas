using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class PessoaJuridicaController : PessoaControllerDetailBase<PessoaJuridica, PessoaJuridicaDetailModel, PessoaJuridicaDetailModelValidator>
    {
        #region Detail          

        protected override PessoaJuridica GetEntityById(int id)
        {
            var business = new PessoaJuridicaBusiness();
            return business.GetById(id);            
        }        

        protected override void Save(PessoaJuridicaDetailModel model)
        {
            base.Save(model);

            var business = new PessoaJuridicaBusiness();

            if (model.Entity.PessoaId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.PessoaId);

                //Comuns                

                //Adicionais

                returnObj.NomeFantasia = model.Entity.NomeFantasia;
                returnObj.RazaoSocial = model.Entity.RazaoSocial;
                returnObj.CNPJ = model.Entity.CNPJ;
                returnObj.InscricaoEstadual = model.Entity.InscricaoEstadual;

                //Salvar
                business.Save(returnObj);
            }
        }

        #endregion
    }
}
