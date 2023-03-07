using System.Linq;

namespace GerenciadorDeEstoque.Filtros;
public class FiltroPreco : FiltroBase<Produto>
{
    public decimal PrecoMinimo { get; set; }
    public decimal PrecoMaximo { get; set; }

    public override IQueryable<Produto> Aplicar(IQueryable<Produto> produtos)
    {
        return produtos.Where(p => p.Preco >= PrecoMinimo && p.Preco <= PrecoMaximo);
    }
}
