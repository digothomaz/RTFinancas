using System.Linq;
using RThomaz.Data.Common;
using RThomaz.Data.Enums;

namespace RThomaz.Data.Business
{
    public class LancamentoBusiness
    {
        public PagedList<Lancamento> GetPaged(int pageNumber, int pageSize, byte? tipoLancamentoId)
        {
            PagedList<Lancamento> pagedList;

            using (var context = new RThomazDbEntities())
            {                
                var query = context.Lancamento
                    .Where(x => tipoLancamentoId == null || x.TipoLancamentoId.Equals(tipoLancamentoId.Value))
                    .OrderBy(x => x.TipoLancamentoId);

                pagedList = new PagedList<Lancamento>(query, pageNumber, pageSize);
            }

            return pagedList;
        }        

        public Lancamento GetById(int id)
        {
            Lancamento entity;
            using (var context = new RThomazDbEntities())
            {
                entity = context.Lancamento
                    .Where(c => c.LancamentoId.Equals(id))
                    .FirstOrDefault();
            }
            return entity;
        }
    }
}
