using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Common;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public class UsuarioController : ControllerDetailBase<Usuario, long, UsuarioDetailModel, UsuarioDetailModelValidator>
    {
        #region Index

        [CustomAuthorize]
        public ActionResult Index()
        {
            var pageNumber = IndexControllerHelper.GetPageNumber();
            var pageSize = IndexControllerHelper.GetPageSize();            

            //Entity

            var business = new UsuarioBusiness();
            var pagedList = business.GetPaged(pageNumber, pageSize);

            var model = new UsuarioIndexModel(pagedList);

            return View(model);
        }

        #endregion

        #region Detail
       
        protected override Usuario GetEntityById(long id)
        {
            var business = new UsuarioBusiness();
            return business.GetById(id);
        }

        protected override void InitializeListsOfDetailModel(UsuarioDetailModel model)
        {
           
        }

        protected override void Save(UsuarioDetailModel model)
        {
            //Salvando Usuario

            var business = new UsuarioBusiness();

            if (model.Entity.UsuarioId == 0)
            {
                business.Save(model.Entity);
            }
            else
            {
                var returnObj = business.GetById(model.Entity.UsuarioId);

                returnObj.Nome = model.Entity.Nome;
                returnObj.Email = model.Entity.Email;
                returnObj.Senha = model.Entity.Senha;
                returnObj.Ativo = model.Entity.Ativo;

                business.Save(returnObj);
            }
        }       

        #endregion

    }
}