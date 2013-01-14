using System;
using System.Data.Objects.DataClasses;
using System.Web.Mvc;
using FluentValidation;
using RThomaz.Web.Common;

namespace RThomaz.Web
{   
    public abstract class ControllerDetailBase<TEntity, TId, TDetailModel, TDetailModelValidator> : Controller
        where TEntity : EntityObject
        where TId : struct
        where TDetailModel : DetailModelBase<TEntity>
        where TDetailModelValidator : AbstractValidator<TDetailModel>
    {
        [CustomAuthorize]
        public virtual ActionResult Detail(TId id)
        {
            TDetailModel model;

            if ((id is int || id is long) && Convert.ToInt32(id).Equals(0))
            {
                model = Activator.CreateInstance<TDetailModel>();
                InitializeListsOfDetailModel(model);
                return View(model);
            }

            TEntity entity = this.GetEntityById(id);

            model = (TDetailModel)Activator.CreateInstance(typeof(TDetailModel), entity);
            
            InitializeListsOfDetailModel(model);

            return View(model);
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Detail(TDetailModel model)
        {
            InitializeListsOfDetailModel(model);

            if (string.IsNullOrEmpty(Request["Salvar"])) return View(model); 

            var validation = Activator.CreateInstance<TDetailModelValidator>().Validate(model);
            
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    model.Errors.Add(error);

                return View(model);
            }

            Save(model);

            return RedirectToAction(model.IndexActionName);
        }

        protected abstract void InitializeListsOfDetailModel(TDetailModel model);
        protected abstract void Save(TDetailModel model);
        protected abstract TEntity GetEntityById(TId id);
    }
}