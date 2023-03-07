using System;
using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace GerenciadorDeEstoque.DAO
{
    public static class ProdutoDAO
    {
        private static readonly string connectionString = "server=localhost;database=nome_do_banco;uid=nome_de_usuario;pwd=senha;";

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar produto: " + ex.Message);

            }

        }
    }
}
