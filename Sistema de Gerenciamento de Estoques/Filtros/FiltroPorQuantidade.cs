using GerenciadorDeEstoque.Filtros;
using GerenciadorDeEstoque;
using System.Linq;

namespace Sistema_de_Gerenciamento_de_Estoques.Filtros
{
    public class FiltroPorQuantidade : FiltroBase<Produto>
    {
        private readonly decimal _QntMinima;
        private readonly decimal _QntMaxima;
        public FiltroPorQuantidade(decimal QntMinima, decimal QntMaxima)
        {
            _QntMinima = QntMinima;
            _QntMaxima = QntMaxima;
        }

        public override IQueryable<Produto> Aplicar(IQueryable<Produto> produtos)
        {
            return produtos.Where(p => p.Quantidade >= _QntMinima && p.Quantidade <= _QntMaxima);
        }

    }
}
