using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class EstadoBusiness
    {
        public IList<Estado> GetByPaisId(int paisId)
        {
            IList<Estado> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.Estado
                    .Where(x => x.PaisId.Equals(paisId))
                    .OrderBy(c => c.Nome)
                    .ToList();
            }

            return result;
        }

        public PagedList<Estado> GetPaged(int pageNumber, int pageSize, int? paisId)
        {
            PagedList<Estado> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.Estado
                    .Include("Pais")
                    .Where(x => paisId == null || x.PaisId.Equals(paisId.Value))
                    .OrderBy(c => c.Nome);

                pagedList = new PagedList<Estado>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public Estado GetById(int id)
        {
            Estado entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Estado
                    .Include("Pais")
                    .Where(c => c.EstadoId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public Estado Save(Estado entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.EstadoId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.Estado.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<Estado>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(int paisId, string nome)
        {
            Estado entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Estado
                    .Where(c => c.PaisId.Equals(paisId))
                    .Where(c => c.Nome.Equals(nome)).FirstOrDefault();
            }
            return entity == null ? false : true;
        }

        public bool ExistByUF(int paisId, string uf)
        {
            Estado entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Estado
                    .Where(c => c.PaisId.Equals(paisId))
                    .Where(c => c.UF.Equals(uf)).FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
