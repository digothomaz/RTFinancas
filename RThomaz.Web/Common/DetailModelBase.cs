using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using FluentValidation.Results;

namespace RThomaz.Web.Common
{
    public abstract class DetailModelBase<TEntity> : ModelBase
        where TEntity : EntityObject
    {
        private readonly TEntity _entity;
        private readonly IList<ValidationFailure> _errors;
        private readonly string _indexActionName;

        public DetailModelBase(string title, string controllerName, string indexActionName = "/")
            : base(title, controllerName)
        {
            _entity = Activator.CreateInstance<TEntity>();
            _errors = new List<ValidationFailure>();
            _indexActionName = indexActionName;
        }

        public DetailModelBase(string title, string controllerName, TEntity entity, string indexActionName = "/")
            : base(title, controllerName)
        {
            _entity = entity;
            _errors = new List<ValidationFailure>();
            _indexActionName = indexActionName;
        }

        public string IndexActionName
        {
            get
            {
                return _indexActionName;
            }
        }

        public TEntity Entity
        {
            get
            {
                return _entity;
            }
        }

        public IList<ValidationFailure> Errors
        {
            get
            {
                return _errors;
            }
        }
    }
}