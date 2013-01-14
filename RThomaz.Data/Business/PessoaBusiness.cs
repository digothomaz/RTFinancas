using System.Collections.Generic;
using System.Linq;
using RThomaz.Data.Common;

namespace RThomaz.Data.Business
{
    public class PessoaBusiness
    {
        public IList<Pessoa> GetAll()
        {
            IList<Pessoa> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.Pessoa
                  .ToList();
            }

            return result;
        }

        public PagedList<Pessoa> GetPaged(int pageNumber, int pageSize, byte? tipoPessoaId)
        {
            PagedList<Pessoa> pagedList;

            using (var context = new RThomazDbEntities())
            {                
                var query = context.Pessoa
                    .Where(x => tipoPessoaId == null || x.TipoPessoaId.Equals(tipoPessoaId.Value))
                    .OrderBy(x => x.TipoPessoaId);

                pagedList = new PagedList<Pessoa>(query, pageNumber, pageSize);
            }

            return pagedList;
        }        

        public Pessoa GetById(int id)
        {
            Pessoa entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Pessoa
                    .Where(c => c.PessoaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }
    }
}
