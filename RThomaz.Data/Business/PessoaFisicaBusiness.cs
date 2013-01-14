using System;
using System.Data;
using System.Linq;

namespace RThomaz.Data.Business
{
    public class PessoaFisicaBusiness
    {
        public PessoaFisica GetById(int id)
        {
            PessoaFisica entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Pessoa.OfType<PessoaFisica>()
                    .Where(c => c.PessoaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public PessoaFisica Save(PessoaFisica entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.PessoaId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.Pessoa.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<Pessoa>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }
    }
}
