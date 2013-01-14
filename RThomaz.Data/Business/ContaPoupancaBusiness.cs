using System;
using System.Data;
using System.Linq;

namespace RThomaz.Data.Business
{
    public class ContaPoupancaBusiness
    {
        public ContaPoupanca GetById(int id)
        {
            ContaPoupanca entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Conta.OfType<ContaPoupanca>()
                    .Include("GrupoConta")
                    .Where(c => c.ContaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public ContaPoupanca Save(ContaPoupanca entity)
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
