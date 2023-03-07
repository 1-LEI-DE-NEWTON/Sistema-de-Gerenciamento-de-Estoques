using GerenciadorDeEstoque;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace GerenciadorDeEstoques
{
    /// <summary>
    /// Lógica interna para AdicionarProdutos.xaml
    /// </summary>
    public partial class AdicionarProdutos : Window
    {
        private Models models;
        private Produto produto;

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public AdicionarProdutos()
        {
            InitializeComponent();
            models = new Models();
        }

        private void AdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            //Adiciona o produto na lista de produtos
            var produto = new Produto(txtNome.Text, int.Parse(txtQuantidade.Text), (decimal)double.Parse(txtPreco.Text));
            models.AdicionarProduto(produto);
            DialogResult = true;
            //MessageBox.Show("Produto adicionado com sucesso!");
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
