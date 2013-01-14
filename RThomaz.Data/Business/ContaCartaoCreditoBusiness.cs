using System;
using System.Data;
using System.Linq;

namespace RThomaz.Data.Business
{
    public class ContaCartaoCreditoBusiness
    {
        public ContaCartaoCredito GetById(int id)
        {
            ContaCartaoCredito entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Conta.OfType<ContaCartaoCredito>()
                    .Include("GrupoConta")
                    .Where(c => c.ContaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public ContaCartaoCredito Save(ContaCartaoCredito entity)
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
