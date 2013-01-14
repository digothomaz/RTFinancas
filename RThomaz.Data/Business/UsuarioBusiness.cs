using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{    
    public class UsuarioBusiness
    {
        //Remover usado na tela de funções.... depois que colocar paginação nesta tela
        public IList<Usuario> GetAll()
        {
            IList<Usuario> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.Usuario
                  .OrderBy(c => c.Nome)
                  .ToList();
            }

            return result;
        }

        public Usuario GetByNome(string nome)
        {
            Usuario entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Usuario
                    .Where(c => c.Nome.Equals(nome)).FirstOrDefault();
            }
            return entity;
        }

        public bool ValidateByNome(string nome, string senha)
        {
            var validate = false;

            using (var context = new RThomazDbEntities())
            {
                var usuario = context.Usuario
                    .Where(item => item.Nome.Equals(nome) && item.Senha.Equals(senha))
                    .FirstOrDefault();

                if (usuario != null) validate = true;
            }

            return validate;
        }

        public bool ValidateByEmail(string email, string senha)
        {
            var validate = false;

            using (var context = new RThomazDbEntities())
            {
                var usuario = context.Usuario
                    .Where(item => item.Email.Equals(email) && item.Senha.Equals(senha))
                    .FirstOrDefault();

                if (usuario != null) validate = true;
            }

            return validate;
        }

        public PagedList<Usuario> GetPaged(int pageNumber, int pageSize)
        {
            PagedList<Usuario> pagedList;

            using (var context = new RThomazDbEntities())
            {
                var query = context.Usuario
                    .OrderBy(c => c.Nome);

                pagedList = new PagedList<Usuario>(query, pageNumber, pageSize);
            }

            return pagedList;
        }

        public Usuario GetById(long id)
        {
            Usuario entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Usuario
                    .Where(c => c.UsuarioId.Equals(id)).FirstOrDefault();
            }
            return entity;
        }

        public bool ExistByNome(string nome)
        {
            Usuario entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Usuario
                  .Where(c => c.Nome.Equals(nome)).FirstOrDefault();
            }
            return entity == null ? false : true;
        }

        public bool ExistByEmail(string email)
        {
            Usuario entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Usuario
                  .Where(c => c.Email.Equals(email))
                  .FirstOrDefault();
            }
            return entity == null ? false : true;
        }

        public Usuario Save(Usuario entity)
        {
            using (var context = new RThomazDbEntities())
            {
                if (entity.UsuarioId == 0)
                {
                    entity.DataCriacao = DateTime.Now;
                    context.Usuario.AddObject(entity);
                }
                else
                {
                    context.CreateObjectSet<Usuario>().Attach(entity);
                    context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                }
                context.SaveChanges();
            }
            return entity;
        }        
    }
}
