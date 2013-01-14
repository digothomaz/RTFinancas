using System;
using System.Data;
using System.Linq;

namespace RThomaz.Data.Business
{
    public class PessoaJuridicaBusiness
    {
        public PessoaJuridica GetById(int id)
        {
            PessoaJuridica entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Pessoa.OfType<PessoaJuridica>()
                    .Where(c => c.PessoaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public PessoaJuridica Save(PessoaJuridica entity)
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
