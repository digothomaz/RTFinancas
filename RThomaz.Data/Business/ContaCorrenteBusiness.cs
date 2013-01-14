using System;
using System.Data;
using System.Linq;

namespace RThomaz.Data.Business
{
    public class ContaCorrenteBusiness
    {
        public ContaCorrente GetById(int id)
        {
            ContaCorrente entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Conta.OfType<ContaCorrente>()
                    .Include("GrupoConta")
                    .Where(c => c.ContaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public ContaCorrente Save(ContaCorrente entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.ContaId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.Conta.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<Conta>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }
    }
}
