using System.Web.Mvc;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Data.Common;
using RThomaz.Data.Enums;
using RThomaz.Web.Common;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class GrupoContaController : ControllerDetailBase<GrupoConta, int, GrupoContaDetailModel, GrupoContaDetailModelValidator>
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();

            //TipoConta

            byte? tipoContaId = null;
            if (!string.IsNullOrEmpty(Request["tipoContaId"])) tipoContaId = byte.Parse(Request["tipoContaId"]);

            var listOfTipoConta = EnumHelper.GetDictionaryFromEnum<TipoConta, byte>();            

            var business = new GrupoContaBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize, tipoContaId);

            var model = new GrupoContaIndexModel(pagedList, listOfTipoConta);
            model.SelectedTipoContaId = tipoContaId;

            return View(model);
        }

        #endregion

        #region Detail          

        protected override GrupoConta GetEntityById(int id)
        {
            var business = new GrupoContaBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(GrupoContaDetailModel model)
        {
            if (model.Entity.GrupoContaId.Equals(0))
            {
                var listOfTipoConta = EnumHelper.GetDictionaryFromEnum<TipoConta, byte>();
                foreach (var tipoConta in listOfTipoConta) model.ListOfTipoConta.Add(tipoConta);
            }
        }

        protected override void Save(GrupoContaDetailModel model)
        {
            var business = new GrupoContaBusiness();

            if (model.Entity.GrupoContaId == 0)
            {
                model.Entity.TipoContaId = model.SelectedTipoContaId;
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.GrupoContaId);

                returnObj.Nome = model.Entity.Nome;
                
                business.Save(returnObj);
            }
        }

        #endregion
    }
}