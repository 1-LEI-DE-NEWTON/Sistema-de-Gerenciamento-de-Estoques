
using GerenciadorDeEstoque;
using GerenciadorDeEstoque.Filtros;
using Sistema_de_Gerenciamento_de_Estoques.Infra.DAO;
using System.Windows;


namespace Sistema_de_Gerenciamento_de_Estoques
{
    /// <summary>
    /// Interação lógica para BuscarProdutos.xam
    /// </summary>
    public partial class BuscarProdutos : Window
    {
        public BuscarProdutos()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            //Busca o produto por nome
            
            var produto = ProdutoDAO.BuscarProdutoPorNome(txtNome.Text);
            
            if (produto != null)
            {
                MessageBox.Show("Produto encontrado: " + produto.Nome, "Buscar Produto");
                //Exibe o produto encontrado na pagina de Listar Produtos
                var janela = new ListarProdutos(produto);
                janela.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Produto não encontrado!");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }       
}
