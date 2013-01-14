using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class TipoHomePageBusiness
    {
        public IList<TipoHomePage> GetAll()
        {
            IList<TipoHomePage> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.TipoHomePage
                  .OrderBy(c => c.Nome)
                  .ToList();
            }

            return result;
        }

        public PagedList<TipoHomePage> GetPaged(int pageNumber, int pageSize, byte? tipoPessoaId)
        {
            PagedList<TipoHomePage> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.TipoHomePage
                    .Where(x => tipoPessoaId == null || x.TipoPessoaId.Equals(tipoPessoaId.Value))
                    .OrderBy(c => c.Nome);

                pagedList = new PagedList<TipoHomePage>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public TipoHomePage GetById(int id)
        {
            TipoHomePage entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.TipoHomePage
                    .Where(c => c.TipoHomePageId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public TipoHomePage Save(TipoHomePage entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.TipoHomePageId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.TipoHomePage.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<TipoHomePage>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(string nome, byte tipoPessoaId)
        {
            TipoHomePage entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.TipoHomePage
                    .Where(c => c.Nome.Equals(nome))
                    .Where(c => c.TipoPessoaId.Equals(tipoPessoaId))
                    .FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
