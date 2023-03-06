using System.Collections.Generic;
using System.Linq;


namespace Sistema_de_Gerenciamento_de_Estoques
{
    public class Models
    {
        private List<Produto> produtos;

        public Models()
        {
            produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }

        public List<Produto> ListarProdutos()
        {
            return produtos;
        }

        public void RemoverProduto(Produto produto)
        {
            produtos.Remove(produto);
        }

        public void RemoverProduto(int index)
        {
            produtos.RemoveAt(index);
        }

        public void RemoverProduto(string nome)
        {
            var produto = produtos.FirstOrDefault(p => p.Nome == nome);
            produtos.Remove(produto);
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, int quantidade, double preco)
        {
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }
    }
}