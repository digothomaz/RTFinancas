using System.Web.Mvc;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Common;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class PaisController : ControllerDetailBase<Pais, int, PaisDetailModel, PaisDetailModelValidator>
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();

            var business = new PaisBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize);
            var model = new PaisIndexModel(pagedList);

            return View(model);
        }

        #endregion

        #region Detail          

        protected override Pais GetEntityById(int id)
        {
            var business = new PaisBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(PaisDetailModel model)
        {
            
        }

        protected override void Save(PaisDetailModel model)
        {
            var business = new PaisBusiness();

            if (model.Entity.PaisId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.PaisId);

                returnObj.Nome = model.Entity.Nome;

                business.Save(returnObj);
            }
        }

        #endregion
    }
}