using GerenciadorDeEstoque;
using Sistema_de_Gerenciamento_de_Estoques.Infra.DAO;
using System.Windows;

namespace Sistema_de_Gerenciamento_de_Estoques
{
    /// <summary>
    /// Lógica interna para EditorProdutos.xaml
    /// </summary>
    public partial class EditorProdutos : Window
    {
        private Produto produtoSelecionado;
        public EditorProdutos(Produto produtoSelecionado)
        {            
            InitializeComponent();
            this.produtoSelecionado = produtoSelecionado;
            txtNome.Tag = produtoSelecionado.Nome;
            txtQuantidade.Tag = produtoSelecionado.Quantidade.ToString();
            txtPreco.Tag = produtoSelecionado.Preco.ToString();
        }        

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            produtoSelecionado = ProdutoDAO.BuscarProduto(produtoSelecionado);
            
            produtoSelecionado.Nome = txtNome.Text;
            produtoSelecionado.Quantidade = int.Parse(txtQuantidade.Text);
            produtoSelecionado.Preco = (decimal)double.Parse(txtPreco.Text);
            //Salva as alterações no banco de dados
            ProdutoDAO.EditarProduto(produtoSelecionado);
            //Fecha a janela
            DialogResult = true;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
