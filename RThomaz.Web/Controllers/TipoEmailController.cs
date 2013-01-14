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
    public class TipoEmailController : ControllerDetailBase<TipoEmail, int, TipoEmailDetailModel, TipoEmailDetailModelValidator>
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();

            //TipoPessoa

            byte? tipoPessoaId = null;
            if (!string.IsNullOrEmpty(Request["tipoPessoaId"])) tipoPessoaId = byte.Parse(Request["tipoPessoaId"]);

            var listOfTipoPessoa = EnumHelper.GetDictionaryFromEnum<TipoPessoa, byte>();

            var business = new TipoEmailBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize, tipoPessoaId);

            var model = new TipoEmailIndexModel(pagedList, listOfTipoPessoa);
            model.SelectedTipoPessoaId = tipoPessoaId;

            return View(model);
        }

        #endregion

        #region Detail

        protected override TipoEmail GetEntityById(int id)
        {
            var business = new TipoEmailBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(TipoEmailDetailModel model)
        {
            if (model.Entity.TipoEmailId.Equals(0))
            {
                var listOfTipoPessoa = EnumHelper.GetDictionaryFromEnum<TipoPessoa, byte>();
                foreach (var tipoPessoa in listOfTipoPessoa) model.ListOfTipoPessoa.Add(tipoPessoa);
            }
        }

        protected override void Save(TipoEmailDetailModel model)
        {
            var business = new TipoEmailBusiness();

            if (model.Entity.TipoEmailId == 0)
            {
                model.Entity.TipoPessoaId = model.SelectedTipoPessoaId;
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.TipoEmailId);

                returnObj.Nome = model.Entity.Nome;

                business.Save(returnObj);
            }
        }

        #endregion
    }
}