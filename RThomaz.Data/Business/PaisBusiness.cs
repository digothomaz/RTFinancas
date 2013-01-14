using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class PaisBusiness
    {
        public IList<Pais> GetAll()
        {
            IList<Pais> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.Pais
                  .OrderBy(c => c.Nome)
                  .ToList();
            }

            return result;
        }

        public PagedList<Pais> GetPaged(int pageNumber, int pageSize)
        {
            PagedList<Pais> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.Pais
                  .OrderBy(c => c.Nome);

                pagedList = new PagedList<Pais>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public Pais GetById(int id)
        {
            Pais entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Pais
                    .Where(c => c.PaisId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public Pais Save(Pais entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.PaisId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.Pais.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<Pais>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(string nome)
        {
            Pais entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Pais
                  .Where(c => c.Nome.Equals(nome)).FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
