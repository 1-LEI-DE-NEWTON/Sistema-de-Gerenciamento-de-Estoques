using Sistema_de_Gerenciamento_de_Estoques;
using Sistema_de_Gerenciamento_de_Estoques.Infra.DAO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                    MessageBox.Show("Operação cancelada!");
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para remover!");
            }
        }       
    }
}