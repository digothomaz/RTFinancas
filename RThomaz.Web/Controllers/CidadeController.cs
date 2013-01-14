using System.Collections.Generic;
using System.Web.Mvc;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Common;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class CidadeController : ControllerDetailBase<Cidade, int, CidadeDetailModel, CidadeDetailModelValidator>
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

            //Estados

            int? estadoId = null;
            var estados = new List<Estado>();

            if (paisId.HasValue)
            {
                if (!string.IsNullOrEmpty(Request["estadoId"])) estadoId = int.Parse(Request["estadoId"]);

                var estadoBusiness = new EstadoBusiness();
                estados.AddRange(estadoBusiness.GetByPaisId(paisId.Value));
            }

            //Entity

            var business = new CidadeBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize, paisId, estadoId);

            var model = new CidadeIndexModel(pagedList, paises, estados);
            model.SelectedPaisId = paisId;
            model.SelectedEstadoId = estadoId;

            return View(model);
        }

        #endregion

        #region Detail        

        protected override Cidade GetEntityById(int id)
        {
            var business = new CidadeBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(CidadeDetailModel model)
        {
            //Paises

            var paisBusiness = new PaisBusiness();
            var paises = paisBusiness.GetAll();

            model.Paises.AddRange(paises);

            //Estados

            if (model.SelectedPaisId > 0)
            {
                var estadoBusiness = new EstadoBusiness();
                var estados = estadoBusiness.GetByPaisId(model.SelectedPaisId);

                model.Estados.AddRange(estados);
            }
        }

        protected override void Save(CidadeDetailModel model)
        {
            model.Entity.EstadoId = model.SelectedEstadoId;

            var business = new CidadeBusiness();

            if (model.Entity.CidadeId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.CidadeId);

                returnObj.Nome = model.Entity.Nome;

                business.Save(returnObj);
            }
        }

        #endregion
    }
}