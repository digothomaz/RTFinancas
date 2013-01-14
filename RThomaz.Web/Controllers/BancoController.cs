using System.Web.Mvc;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Common;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class BancoController : ControllerDetailBase<Banco, int, BancoDetailModel, BancoDetailModelValidator>
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();

            var business = new BancoBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize);
            var model = new BancoIndexModel(pagedList);

            return View(model);
        }

        #endregion

        #region Detail

        protected override Banco GetEntityById(int id)
        {
            var business = new BancoBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(BancoDetailModel model)
        {
            
        }

        protected override void Save(BancoDetailModel model)
        {
            var business = new BancoBusiness();

            if (model.Entity.BancoId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.BancoId);

                returnObj.Nome = model.Entity.Nome;
                returnObj.Numero = model.Entity.Numero;
                returnObj.Site = model.Entity.Site;

                business.Save(returnObj);
            }
        }

        #endregion
    }
}