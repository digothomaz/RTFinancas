using System.Linq;
using RThomaz.Data.Common;
using System.Collections.Generic;

namespace RThomaz.Data.Business
{
    public class ContaBusiness
    {
        public IList<Conta> GetAll()
        {
            IList<Conta> result;

            using (var context = new RThomazDbEntities())
            {
                result = context.Conta
                    .Include("GrupoConta")
                  .OrderBy(c => c.Nome)
                  .ToList();
            }

            return result;
        }

        public PagedList<Conta> GetPaged(int pageNumber, int pageSize, byte? tipoContaId, int? grupoContaId)
        {
            PagedList<Conta> pagedList;

            using (var context = new RThomazDbEntities())
            {                
                var query = context.Conta
                    .Include("GrupoConta")
                    .Where(x => tipoContaId == null || x.TipoContaId.Equals(tipoContaId.Value))
                    .Where(x => grupoContaId == null || x.GrupoContaId.Equals(grupoContaId.Value))
                    .OrderBy(x => x.TipoContaId)
                    .ThenBy(x => x.GrupoConta.Nome)
                    .ThenBy(x => x.Nome);

                pagedList = new PagedList<Conta>(query, pageNumber, pageSize);
            }

            return pagedList;
        }        

        public Conta GetById(int id)
        {
            Conta entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Conta
                    .Include("GrupoConta")
                    .Where(c => c.ContaId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }

        public bool ExistByNome(string nome, byte tipoContaId)
        {
            Conta entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Conta
                    .Where(c => c.TipoContaId.Equals(tipoContaId))
                    .Where(c => c.Nome.Equals(nome))
                    .FirstOrDefault();
            }
            return entity == null ? false : true;
        }
    }
}
