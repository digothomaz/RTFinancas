using System.Linq;
using RThomaz.Data;
using RThomaz.Data.Business;
using RThomaz.Web.Models;
using RThomaz.Web.Validators;

namespace RThomaz.Web.Controllers
{
    public abstract class LancamentoControllerDetailBase<TEntity, TDetailModel, TDetailModelValidator>
        : ControllerDetailBase<TEntity, int, TDetailModel, TDetailModelValidator>
        where TEntity : Lancamento
        where TDetailModel : LancamentoDetailModelBase<TEntity>
        where TDetailModelValidator : LancamentoDetailModelValidatorBase<TDetailModel, TEntity>
    {
        protected override void InitializeListsOfDetailModel(TDetailModel model)
        {
            var contaBusiness = new ContaBusiness();
            var contas = contaBusiness.GetAll();
            model.Contas.AddRange(contas);

            var pessoaBusiness = new PessoaBusiness();
            var pessoas = pessoaBusiness.GetAll();
            model.Pessoas.AddRange(pessoas);
        }

        protected override void Save(TDetailModel model)
        {
            var pessoa = model.Pessoas.First(x => x.PessoaId.Equals(model.SelectedPessoaId));
            var conta = model.Contas.First(x => x.ContaId.Equals(model.SelectedContaId));

            model.Entity.ContaId = conta.ContaId;
            model.Entity.TipoContaId = conta.TipoContaId;
            model.Entity.PessoaId = pessoa.PessoaId;
            model.Entity.TipoPessoaId = pessoa.TipoPessoaId;
        }
    }
}