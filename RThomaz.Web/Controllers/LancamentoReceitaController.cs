using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class LancamentoReceitaController : LancamentoControllerDetailBase<LancamentoReceita, LancamentoReceitaDetailModel, LancamentoReceitaDetailModelValidator>
    {
        #region Detail          

        protected override LancamentoReceita GetEntityById(int id)
        {
            var business = new LancamentoReceitaBusiness();
            return business.GetById(id);            
        }        

        protected override void Save(LancamentoReceitaDetailModel model)
        {
            base.Save(model);

            var business = new LancamentoReceitaBusiness();

            if (model.Entity.LancamentoId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.LancamentoId);

                //Comuns                

                //Adicionais                

                //Salvar
                business.Save(returnObj);
            }
        }

        #endregion
    }
}
