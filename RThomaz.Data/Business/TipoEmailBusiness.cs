using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class TipoEmailBusiness
    {
        public IList<TipoEmail> GetAll()
        {
            IList<TipoEmail> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.TipoEmail
                  .OrderBy(c => c.Nome)
                  .ToList();
            }

            return result;
        }

        public PagedList<TipoEmail> GetPaged(int pageNumber, int pageSize, byte? tipoPessoaId)
        {
            PagedList<TipoEmail> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.TipoEmail
                    .Where(x => tipoPessoaId == null || x.TipoPessoaId.Equals(tipoPessoaId.Value))
                    .OrderBy(c => c.Nome);

                pagedList = new PagedList<TipoEmail>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public TipoEmail GetById(int id)
        {
            TipoEmail entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.TipoEmail
                    .Where(c => c.TipoEmailId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public TipoEmail Save(TipoEmail entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.TipoEmailId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.TipoEmail.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<TipoEmail>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(string nome, byte tipoPessoaId)
        {
            TipoEmail entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.TipoEmail
                    .Where(c => c.Nome.Equals(nome))
                    .Where(c => c.TipoPessoaId.Equals(tipoPessoaId))
                    .FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
