using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class TipoEnderecoBusiness
    {
        public IList<TipoEndereco> GetAll()
        {
            IList<TipoEndereco> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.TipoEndereco
                  .OrderBy(c => c.Nome)
                  .ToList();
            }

            return result;
        }

        public PagedList<TipoEndereco> GetPaged(int pageNumber, int pageSize, byte? tipoPessoaId)
        {
            PagedList<TipoEndereco> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.TipoEndereco
                    .Where(x => tipoPessoaId == null || x.TipoPessoaId.Equals(tipoPessoaId.Value))
                    .OrderBy(c => c.Nome);

                pagedList = new PagedList<TipoEndereco>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public TipoEndereco GetById(int id)
        {
            TipoEndereco entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.TipoEndereco
                    .Where(c => c.TipoEnderecoId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public TipoEndereco Save(TipoEndereco entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.TipoEnderecoId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.TipoEndereco.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<TipoEndereco>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(string nome, byte tipoPessoaId)
        {
            TipoEndereco entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.TipoEndereco
                    .Where(c => c.Nome.Equals(nome))
                    .Where(c => c.TipoPessoaId.Equals(tipoPessoaId))
                    .FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
