
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GerenciadorDeEstoque
{
    public partial class ListarProdutos : Page
    {
        public ListarProdutos()
        {
            InitializeComponent();
            List<Produto> produtos = new List<Produto>();
        }
    }
}