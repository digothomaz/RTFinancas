using System;
using System.Data;
using System.Linq;

namespace RThomaz.Data.Business
{
    public class LancamentoReceitaBusiness
    {
        public LancamentoReceita GetById(int id)
        {
            LancamentoReceita entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Lancamento.OfType<LancamentoReceita>()
                    .Where(c => c.LancamentoId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public LancamentoReceita Save(LancamentoReceita entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.LancamentoId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.Lancamento.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<Lancamento>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }
    }
}
