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
        public EditorProdutos(Produto produtoSelecionado)
        {            
            InitializeComponent();
            txtNome.Tag = produtoSelecionado.Nome;
            txtQuantidade.Tag = produtoSelecionado.Quantidade.ToString();
            txtPreco.Tag = produtoSelecionado.Preco.ToString();
        }        

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            var produto = new Produto(txtNome.Text, int.Parse(txtQuantidade.Text), (decimal)double.Parse(txtPreco.Text));
            //Salva as alterações no banco de dados
            ProdutoDAO.EditarProduto(produto);
            //Fecha a janela
            DialogResult = true;
        }
    }
}
