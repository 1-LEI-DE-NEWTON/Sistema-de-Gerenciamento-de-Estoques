using GerenciadorDeEstoques;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace GerenciadorDeEstoque
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        private List<Produto> _produtos;
        public List<Produto> Produtos
        {
            get { return _produtos; }
            set
            {
                _produtos = value;
                OnPropertyChanged(nameof(Produtos));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Produtos = new List<Produto>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            var adicionarProdutos = new AdicionarProdutos();
            adicionarProdutos.ShowDialog();
            //MessageBox.Show("Produto adicionado com sucesso!");
        }

        private void AtualizarProdutos(object sender, RoutedEventArgs e)
        {
            Produtos = Produtos.ToList(); // atualiza o DataGrid
        }

        /*
        private void RemoverProduto(object sender, RoutedEventArgs e)
        {
            var produto = (Produto)dgProdutos.SelectedItem;
            Produtos.Remove(produto);
            Produtos = Produtos.ToList(); // atualiza o DataGrid
        }
        */

        /*
        private void ListarProdutos(object sender, RoutedEventArgs e)
        {
            var listarProdutosWindow = new ListarProdutosWindow(Produtos);
            listarProdutosWindow.ShowDialog();
        }
        */
    }
}