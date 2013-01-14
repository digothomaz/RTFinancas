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
    public class TipoEnderecoController : ControllerDetailBase<TipoEndereco, int, TipoEnderecoDetailModel, TipoEnderecoDetailModelValidator>
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

            var business = new TipoEnderecoBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize, tipoPessoaId);

            var model = new TipoEnderecoIndexModel(pagedList, listOfTipoPessoa);
            model.SelectedTipoPessoaId = tipoPessoaId;

            return View(model);
        }

        #endregion

        #region Detail

        protected override TipoEndereco GetEntityById(int id)
        {
            var business = new TipoEnderecoBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(TipoEnderecoDetailModel model)
        {
            if (model.Entity.TipoEnderecoId.Equals(0))
            {
                var listOfTipoPessoa = EnumHelper.GetDictionaryFromEnum<TipoPessoa, byte>();
                foreach (var tipoPessoa in listOfTipoPessoa) model.ListOfTipoPessoa.Add(tipoPessoa);
            }
        }

        protected override void Save(TipoEnderecoDetailModel model)
        {
            var business = new TipoEnderecoBusiness();

            if (model.Entity.TipoEnderecoId == 0)
            {
                model.Entity.TipoPessoaId = model.SelectedTipoPessoaId;
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.TipoEnderecoId);

                returnObj.Nome = model.Entity.Nome;

                business.Save(returnObj);
            }
        }

        #endregion
    }
}