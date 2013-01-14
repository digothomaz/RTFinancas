using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class PessoaFisicaController : PessoaControllerDetailBase<PessoaFisica, PessoaFisicaDetailModel, PessoaFisicaDetailModelValidator>
    {
        #region Detail          

        protected override PessoaFisica GetEntityById(int id)
        {
            var business = new PessoaFisicaBusiness();
            return business.GetById(id);            
        }        

        protected override void Save(PessoaFisicaDetailModel model)
        {
            base.Save(model);

            var business = new PessoaFisicaBusiness();

            if (model.Entity.PessoaId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.PessoaId);

                //Comuns                

                //Adicionais

                returnObj.Nome = model.Entity.Nome;
                returnObj.RG = model.Entity.RG;
                returnObj.CPF = model.Entity.CPF;
                returnObj.DataNascimento = model.Entity.DataNascimento;
                returnObj.Sexo = model.Entity.Sexo;

                //Salvar
                business.Save(returnObj);
            }
        }

        #endregion
    }
}
