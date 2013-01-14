using System.Web.Mvc;
using RThomaz.Data.Business;
using RThomaz.Data.Common;
using RThomaz.Data.Enums;
using RThomaz.Web.Common;
using RThomaz.Web.Models;

namespace RThomaz.Web.Controllers
{
    public class LancamentoController : Controller
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();

            //ListOfTipoLancamento

            byte? tipoLancamentoId = null;
            if (!string.IsNullOrEmpty(Request["tipoLancamentoId"])) tipoLancamentoId = byte.Parse(Request["tipoLancamentoId"]);

            var listOfTipoLancamento = EnumHelper.GetDictionaryFromEnum<TipoLancamento, byte>();                 

            //Entity

            var business = new LancamentoBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize, tipoLancamentoId);

            var model = new LancamentoIndexModel(pagedList, listOfTipoLancamento);
            model.SelectedTipoLancamentoId = tipoLancamentoId;
            
            return View(model);
        }

        #endregion
    }
}
