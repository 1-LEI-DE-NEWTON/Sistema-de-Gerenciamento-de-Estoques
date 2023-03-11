using System;
using System.Collections.Generic;
using System.Windows;
using GerenciadorDeEstoque;
using MySql.Data.MySqlClient;

namespace Sistema_de_Gerenciamento_de_Estoques.Infra.DAO
{
    public class ProdutoDAO
    {
        private static readonly string connectionString = "server=localhost;database=gerenciadorDeEstoque;uid=root;";

        public static List<Produto> ListarProdutos()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar produtos: " + ex.Message);
                return null;
            }
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

        public static void EditarProduto(Produto produto)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("UPDATE produtos SET nome = @nome, quantidade = @quantidade, preco = @preco WHERE id = @id", connection);
                    command.Parameters.AddWithValue("@id", produto.Id);
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                    command.Parameters.AddWithValue("@preco", produto.Preco);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Produto editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar produto: " + ex.Message);
            }
        }

        public static Produto BuscarProduto(Produto produto)
        {
            try
            {
                //Pesquisa um produto no banco de dados, com mesmo nome,quantidade e preço
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM produtos WHERE nome = @nome AND quantidade = @quantidade AND preco = @preco", connection);
                    command.Parameters.AddWithValue("@nome", produto.Nome);
                    command.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                    command.Parameters.AddWithValue("@preco", produto.Preco);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produto.Id = reader.GetInt32("id");
                            produto.Nome = reader.GetString("nome");
                            produto.Quantidade = reader.GetInt32("quantidade");
                            produto.Preco = reader.GetDecimal("preco");
                        }
                    }

                    return produto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar produto: " + ex.Message);
                return null;
            }
        }

        public static void RemoverProduto(Produto produto)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("DELETE FROM produtos WHERE id = @id", connection);
                    command.Parameters.AddWithValue("@id", produto.Id);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Produto removido com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover produto: " + ex.Message);
            }
        }        
    }
}
