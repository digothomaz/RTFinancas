using System.Collections.Generic;
using System.Web.Mvc;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Data.Common;
using RThomaz.Data.Enums;
using RThomaz.Web.Common;
using RThomaz.Web.Models;

namespace RThomaz.Web.Controllers
{
    public class ContaController : Controller
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();

            //TiposConta

            byte? tipoContaId = null;
            if (!string.IsNullOrEmpty(Request["tipoContaId"])) tipoContaId = byte.Parse(Request["tipoContaId"]);

            var listOfTipoConta = EnumHelper.GetDictionaryFromEnum<TipoConta, byte>();

            //GrupoConta

            int? grupoContaId = null;
            var listOfGrupoConta = new List<GrupoConta>();

            if (tipoContaId.HasValue)
            {
                var grupoContaBusiness = new GrupoContaBusiness();
                listOfGrupoConta.AddRange(grupoContaBusiness.GetByTipoConta(tipoContaId.Value));

                if (!string.IsNullOrEmpty(Request["grupoContaId"])) grupoContaId = int.Parse(Request["grupoContaId"]);
            }

            //Entity

            var business = new ContaBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize, tipoContaId, grupoContaId);

            var model = new ContaIndexModel(pagedList, listOfTipoConta, listOfGrupoConta);
            model.SelectedTipoContaId = tipoContaId;
            model.SelectedGrupoContaId = grupoContaId;

            return View(model);
        }

        #endregion
    }
}
