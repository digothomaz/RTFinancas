using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class TipoTelefoneBusiness
    {
        public IList<TipoTelefone> GetAll()
        {
            IList<TipoTelefone> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.TipoTelefone
                  .OrderBy(c => c.Nome)
                  .ToList();
            }

            return result;
        }

        public PagedList<TipoTelefone> GetPaged(int pageNumber, int pageSize, byte? tipoPessoaId)
        {
            PagedList<TipoTelefone> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.TipoTelefone
                    .Where(x => tipoPessoaId == null || x.TipoPessoaId.Equals(tipoPessoaId.Value))
                    .OrderBy(c => c.Nome);

                pagedList = new PagedList<TipoTelefone>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public TipoTelefone GetById(int id)
        {
            TipoTelefone entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.TipoTelefone
                    .Where(c => c.TipoTelefoneId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public TipoTelefone Save(TipoTelefone entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.TipoTelefoneId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.TipoTelefone.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<TipoTelefone>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(string nome, byte tipoPessoaId)
        {
            TipoTelefone entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.TipoTelefone
                    .Where(c => c.Nome.Equals(nome))
                    .Where(c => c.TipoPessoaId.Equals(tipoPessoaId))
                    .FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
