using System;
using System.Data;
using System.Linq;

namespace RThomaz.Data.Business
{
    public class ContaInvestimentoBusiness
    {
        public ContaInvestimento GetById(int id)
        {
            ContaInvestimento entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Conta.OfType<ContaInvestimento>()
                    .Include("GrupoConta")
                    .Where(c => c.ContaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public ContaInvestimento Save(ContaInvestimento entity)
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
