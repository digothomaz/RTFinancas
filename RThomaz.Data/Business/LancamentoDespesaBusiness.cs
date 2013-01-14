using System;
using System.Data;
using System.Linq;

namespace RThomaz.Data.Business
{
    public class LancamentoDespesaBusiness
    {
        public LancamentoDespesa GetById(int id)
        {
            LancamentoDespesa entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Lancamento.OfType<LancamentoDespesa>()
                    .Where(c => c.LancamentoId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public LancamentoDespesa Save(LancamentoDespesa entity)
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
