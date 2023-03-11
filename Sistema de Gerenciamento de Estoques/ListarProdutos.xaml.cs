using GerenciadorDeEstoque.Filtros;
using Sistema_de_Gerenciamento_de_Estoques;
using Sistema_de_Gerenciamento_de_Estoques.Infra.DAO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
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

        private void PreencherListView()
        {
            //Preenche o ListView com os produtos que estão no banco de dados
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
                    break;
                case "Preço":
                    txtMinimo.Visibility = Visibility.Visible;
                    txtMaximo.Visibility = Visibility.Visible;
                    txtMinimo.Tag = "Preço Mínimo";
                    txtMaximo.Tag = "Preço Máximo";
                    break;
                case "Quantidade":
                    txtMinimo.Visibility = Visibility.Visible;
                    txtMaximo.Visibility = Visibility.Visible;
                    txtMinimo.Tag = "Quantidade Mínima";
                    txtMaximo.Tag = "Quantidade Máxima";
                    break;
            }

            if (txtFiltro.Text != "")
            {                      
                switch (filtroEscolhido)
                {
                    case "Preço":
                        Produtos = new ObservableCollection<Produto>(ProdutoDAO.ListarProdutosComFiltro(
                            new FiltroPorPreco(decimal.Parse(txtFiltro.Text))));
                        lvwProdutos.ItemsSource = Produtos;
                        break;
                    //Filtro por quantidade
                    case "Quantidade":
                        Produtos = new ObservableCollection<Produto>(ProdutoDAO.ListarProdutosComFiltro(
                            new FiltroPorQuantidade(int.Parse(txtFiltro.Text))));
                        lvwProdutos.ItemsSource = Produtos;
                        break;
                    //Filtro por nome
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