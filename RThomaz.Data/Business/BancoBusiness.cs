using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class BancoBusiness
    {
        public IList<Banco> GetAll()
        {
            IList<Banco> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.Banco
                  .OrderBy(c => c.Nome)
                  .ToList();
            }

            return result;
        }

        public PagedList<Banco> GetPaged(int pageNumber, int pageSize)
        {
            PagedList<Banco> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.Banco
                  .OrderBy(c => c.Nome);

                pagedList = new PagedList<Banco>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public Banco GetById(int id)
        {
            Banco entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Banco
                    .Where(c => c.BancoId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public Banco Save(Banco entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.BancoId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.Banco.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<Banco>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }

        public bool ExistByNome(string nome)
        {
            Banco entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Banco
                  .Where(c => c.Nome.Equals(nome)).FirstOrDefault();
            }
            return entity == null ? false : true;
        }

        public bool ExistByNumero(string numero)
        {
            Banco entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Banco
                  .Where(c => c.Numero.Equals(numero)).FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
