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
        }
        private void ListarProdutos_Click(object sender, RoutedEventArgs e)
        {
            var listarProdutos = new ListarProdutos();
            listarProdutos.ShowDialog();
        }       
    }
}