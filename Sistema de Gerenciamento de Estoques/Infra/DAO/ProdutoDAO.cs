using System;
using System.Collections.Generic;
using System.Windows;
using GerenciadorDeEstoque;
using MySql.Data.MySqlClient;

namespace Sistema_de_Gerenciamento_de_Estoques.Infra.DAO
{
    public static class ProdutoDAO
    {
        private static readonly string connectionString = "server=localhost;database=gerenciadorDeEstoque;uid=root;";

        public static List<Produto> ListarProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM produtos", connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var produto = new Produto(
                            reader.GetString("nome"),
                            reader.GetInt32("quantidade"),
                            reader.GetDecimal("preco"));

                        produtos.Add(produto);
                    }
                }
            }

            return produtos;
        }

        public static void AdicionarProduto(Produto produto)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO produtos (nome, quantidade, preco) VALUES (@nome, @quantidade, @preco)", connection);
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                    command.Parameters.AddWithValue("@preco", produto.Preco);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Produto adicionado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar produto: " + ex.Message);
            }
        }
    }
}
