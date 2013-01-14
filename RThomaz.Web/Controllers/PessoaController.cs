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
    public class PessoaController : Controller
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();

            //ListOfTipoPessoa

            byte? tipoPessoaId = null;
            if (!string.IsNullOrEmpty(Request["tipoPessoaId"])) tipoPessoaId = byte.Parse(Request["tipoPessoaId"]);

            var listOfTipoPessoa = EnumHelper.GetDictionaryFromEnum<TipoPessoa, byte>();                 

            //Entity

            var business = new PessoaBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize, tipoPessoaId);

            var model = new PessoaIndexModel(pagedList, listOfTipoPessoa);
            model.SelectedTipoPessoaId = tipoPessoaId;
            
            return View(model);
        }

        #endregion
    }
}
