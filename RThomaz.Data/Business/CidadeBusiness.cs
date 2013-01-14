using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class CidadeBusiness
    {
        public PagedList<Cidade> GetPaged(int pageNumber, int pageSize, int? paisId, int? estadoId)
        {
            PagedList<Cidade> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.Cidade
                    .Include("Estado.Pais")
                    .Where(x => paisId == null || x.Estado.PaisId.Equals(paisId.Value))
                    .Where(x => estadoId == null || x.EstadoId.Equals(estadoId.Value))
                    .OrderBy(c => c.Nome);

                pagedList = new PagedList<Cidade>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public Cidade GetById(int id)
        {
            Cidade entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Cidade
                    .Include("Estado.Pais")
                    .Where(c => c.CidadeId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public Cidade Save(Cidade entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.CidadeId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.Cidade.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<Cidade>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(int estadoId, string nome)
        {
            Cidade entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Cidade
                    .Where(c => c.EstadoId.Equals(estadoId))
                    .Where(c => c.Nome.Equals(nome)).FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
