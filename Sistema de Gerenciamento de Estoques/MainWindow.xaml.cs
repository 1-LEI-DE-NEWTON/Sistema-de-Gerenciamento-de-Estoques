using System.Windows;
using Sistema_de_Gerenciamento_de_Estoques;


namespace GerenciadorDeEstoque
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models models;

        public MainWindow()
        {
            InitializeComponent();
            models = new Models();
        }

        private void AdicionarProduto(object sender, RoutedEventArgs e)
        {
            var produto = new Produto(txtNome.Text, int.Parse(txtQuantidade.Text), double.Parse(txtPreco.Text));
            models.AdicionarProduto(produto);
            MessageBox.Show("Produto adicionado com sucesso!");
        }

        private void ListarProdutos(object sender, RoutedEventArgs e)
        {
            var produtos = models.ListarProdutos();
            foreach (var produto in produtos)
            {
                MessageBox.Show($"Nome: {produto.Nome} - Quantidade: {produto.Quantidade} - Preço: {produto.Preco}");
            }
        }

        private void RemoverProduto(object sender, RoutedEventArgs e)
        {
            var produto = new Produto(txtNome.Text, int.Parse(txtQuantidade.Text), double.Parse(txtPreco.Text));
            models.RemoverProduto(produto);
            MessageBox.Show("Produto removido com sucesso!");
        }

        /*
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var produto = new Produto(txtNome.Text, int.Parse(txtQuantidade.Text), double.Parse(txtPreco.Text));
            models.RemoverProduto(int.Parse(txtIndex.Text));
            MessageBox.Show("Produto removido com sucesso!");
        }
        */

        private void RemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            // Obter o índice do produto selecionado na lista
            int index = lstProdutos.SelectedIndex;

            // Verificar se um produto foi selecionado
            if (index != -1)
            {
                // Remover o produto da lista
                produtos.RemoveAt(index);

                // Atualizar a exibição da lista na interface do usuário
                lstProdutos.ItemsSource = produtos;
            }
        }
    }
}
