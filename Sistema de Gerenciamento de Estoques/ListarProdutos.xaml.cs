using GerenciadorDeEstoque.Filtros;
using Sistema_de_Gerenciamento_de_Estoques;
using Sistema_de_Gerenciamento_de_Estoques.Infra.DAO;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GerenciadorDeEstoque
{
    public partial class ListarProdutos : Window
    {
        public ObservableCollection<Produto> Produtos { get; set; }
        public ListarProdutos()
        {
            InitializeComponent();
            PreencherListView();
        }

        public ListarProdutos(Produto produto)
        {
            InitializeComponent();            
            Produtos = new ObservableCollection<Produto>(ProdutoDAO.ListarProdutosComFiltro(
                            new FiltroPorNome(produto.Nome)));
            lvwProdutos.ItemsSource = Produtos;
        }

        private void PreencherListView()
        {
            Produtos = new ObservableCollection<Produto>(ProdutoDAO.ListarProdutos());
            lvwProdutos.ItemsSource = Produtos;
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            if (lvwProdutos.SelectedItem != null)
            {
                var produtoSelecionado = (Produto)lvwProdutos.SelectedItem;
                var janela = new EditorProdutos(produtoSelecionado);
                janela.ShowDialog();
                PreencherListView();
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar!");
            }
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            if (lvwProdutos.SelectedItem != null)
            {
                var produtoSelecionado = (Produto)lvwProdutos.SelectedItem;
                produtoSelecionado = ProdutoDAO.BuscarProduto(produtoSelecionado);

                MessageBoxResult resultado = MessageBox.Show("Deseja excluir o produto " + produtoSelecionado.Nome
                    + "?", "Excluir Produto", MessageBoxButton.YesNo);

                if (resultado == MessageBoxResult.Yes)
                {
                    ProdutoDAO.RemoverProduto(produtoSelecionado);
                    PreencherListView();
                }
                else
                {
                    MessageBox.Show("Operação cancelada!", "Excluir Produto");
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para remover!");
            }
        }
        private void Filtrar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbxFiltroEscolhido = (ComboBoxItem)cbxFiltro.SelectedItem;
            string filtroEscolhido = cbxFiltroEscolhido.Content.ToString();

            switch (filtroEscolhido)
            {
                case "Nome":
                    txtFiltro.Visibility = Visibility.Visible;
                    txtMinimo.Visibility = Visibility.Collapsed;
                    txtMaximo.Visibility = Visibility.Collapsed;                    

                    break;
                case "Preço":
                    txtFiltro.Visibility = Visibility.Collapsed;
                    txtMinimo.Visibility = Visibility.Visible;
                    txtMaximo.Visibility = Visibility.Visible;
                    txtMinimo.Tag = "Preço Mínimo";
                    txtMaximo.Tag = "Preço Máximo";
                    break;
                case "Quantidade":
                    txtFiltro.Visibility = Visibility.Collapsed;
                    txtMinimo.Visibility = Visibility.Visible;
                    txtMaximo.Visibility = Visibility.Visible;
                    txtMinimo.Tag = "Quantidade Mínima";
                    txtMaximo.Tag = "Quantidade Máxima";
                    break;
            }            
            
            if (txtFiltro.Text != "" || txtMaximo.Text != "" || txtMinimo.Text != "")
            {                      
                switch (filtroEscolhido)
                {
                    case "Preço":
                        if (decimal.TryParse(txtMinimo.Text, out decimal precoMinimo) &&
                            decimal.TryParse(txtMaximo.Text, out decimal precoMax))
                        {
                            Produtos = new ObservableCollection<Produto>(ProdutoDAO.ListarProdutosComFiltro(
                                new FiltroPreco(precoMinimo, precoMax)));
                            lvwProdutos.ItemsSource = Produtos;
                        }
                        else
                        {
                            MessageBox.Show("Digite um valor válido!", "Filtro por Preço",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }                       
                        break;
                        
                    case "Quantidade":
                        if (int.TryParse(txtMinimo.Text, out int qntMinima) &&
                            (int.TryParse(txtMaximo.Text, out int qntMax)))
                        {
                            Produtos = new ObservableCollection<Produto>(ProdutoDAO.ListarProdutosComFiltro(
                                new FiltroPreco(qntMinima, qntMax)));
                            lvwProdutos.ItemsSource = Produtos;
                        }
                        else
                        {
                            MessageBox.Show("Digite um valor válido!", "Filtro por Quantidade", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case "Nome":
                        txtFiltro.Visibility = Visibility.Visible;
                        Produtos = new ObservableCollection<Produto>(ProdutoDAO.ListarProdutosComFiltro(
                            new FiltroPorNome(txtFiltro.Text)));
                        lvwProdutos.ItemsSource = Produtos;
                        break;
                }
            }
            else
            {
                lvwProdutos.ItemsSource = Produtos;
            }
        }
    }
}