
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
            var produto = ProdutoDAO.BuscarProdutoPorNome(txtNome.Text);
            
            if (produto != null)
            {
                MessageBoxResult resultado = MessageBox.Show("Produto encontrado! Clique em Sim para editar ou Nao para visualizar " +
                    "Todos os produtos com esse nome", "Produto encontrado", MessageBoxButton.YesNoCancel);
                
                if (resultado == MessageBoxResult.Yes)
                {
                    var janela = new EditorProdutos(produto);
                    janela.ShowDialog();
                }
                else if (resultado == MessageBoxResult.No)
                {
                    var janela = new ListarProdutos(produto);
                    janela.ShowDialog();
                }                
                Close();
            }
            else
            {
                MessageBox.Show("Produto não encontrado!");
                Close();
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }       
}
