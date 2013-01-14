using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class GrupoContaBusiness
    {
        public IList<GrupoConta> GetByTipoConta(byte tipoContaId)
        {
            IList<GrupoConta> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.GrupoConta
                    .Where(x => x.TipoContaId.Equals(tipoContaId))
                    .OrderBy(c => c.Nome)
                    .ToList();
            }

            return result;
        }

        public PagedList<GrupoConta> GetPaged(int pageNumber, int pageSize, byte? tipoContaId)
        {
            PagedList<GrupoConta> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.GrupoConta
                    .Where(x => tipoContaId == null || x.TipoContaId.Equals(tipoContaId.Value))
                    .OrderBy(c => c.Nome);

                pagedList = new PagedList<GrupoConta>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public GrupoConta GetById(int id)
        {
            GrupoConta entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.GrupoConta
                    .Where(c => c.GrupoContaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public GrupoConta Save(GrupoConta entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.GrupoContaId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.GrupoConta.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<GrupoConta>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(string nome)
        {
            GrupoConta entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.GrupoConta
                  .Where(c => c.Nome.Equals(nome)).FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
