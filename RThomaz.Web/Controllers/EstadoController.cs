using System.Web.Mvc;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Common;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class EstadoController : ControllerDetailBase<Estado, int, EstadoDetailModel, EstadoDetailModelValidator>
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();

            //Paises

            int? paisId = null;
            if (!string.IsNullOrEmpty(Request["paisId"])) paisId = int.Parse(Request["paisId"]);

            var paisBusiness = new PaisBusiness();
            var paises = paisBusiness.GetAll();

            //Entity

            var business = new EstadoBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize, paisId);

            var model = new EstadoIndexModel(pagedList, paises);
            model.SelectedPaisId = paisId;

            return View(model);
        }

        #endregion

        #region Detail
        
        protected override Estado GetEntityById(int id)
        {
            var business = new EstadoBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(EstadoDetailModel model)
        {
            var paisBusiness = new PaisBusiness();
            var paises = paisBusiness.GetAll();

            model.Paises.AddRange(paises);
        }

        protected override void Save(EstadoDetailModel model)
        {
            var business = new EstadoBusiness();

            if (model.Entity.EstadoId == 0)
            {
                model.Entity.PaisId = model.SelectedPaisId;
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.EstadoId);

                returnObj.Nome = model.Entity.Nome;
                returnObj.UF = model.Entity.UF;

                business.Save(returnObj);
            }
        }

        #endregion
    }
}
