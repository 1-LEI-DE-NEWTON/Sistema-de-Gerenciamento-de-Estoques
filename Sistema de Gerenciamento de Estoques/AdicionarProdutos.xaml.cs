using GerenciadorDeEstoque;
using System.Windows;


namespace GerenciadorDeEstoques
{
    /// <summary>
    /// Lógica interna para AdicionarProdutos.xaml
    /// </summary>
    public partial class AdicionarProdutos : Window
    {
        private Models models;

        public AdicionarProdutos()
        {
            InitializeComponent();
            models = new Models();
        }

        private void AdicionarProduto_Click(object sender, RoutedEventArgs e)
        {            
            var produto = new Produto(txtNome.Text, int.Parse(txtQuantidade.Text), double.Parse(txtPreco.Text));
            models.AdicionarProduto(produto);
            DialogResult = true;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
