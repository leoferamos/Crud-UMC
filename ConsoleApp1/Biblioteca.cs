using System;
using MySql.Data.MySqlClient;

namespace ConsoleCRUD
{
    public class Biblioteca
    {
        // Método para adicionar um livro
        public void AdicionarLivro(Livro livro)
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return;
                }

                string query = "INSERT INTO livros (isbn, titulo, autor, ano, genero, edicao, quantidade) VALUES (@ISBN, @Titulo, @Autor, @Ano, @Genero, @Edicao, @Quantidade)";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@ISBN", livro.ISBN);
                cmd.Parameters.AddWithValue("@Titulo", livro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", livro.Autor);
                cmd.Parameters.AddWithValue("@Ano", livro.Ano);
                cmd.Parameters.AddWithValue("@Genero", livro.Genero);
                cmd.Parameters.AddWithValue("@Edicao", livro.Edicao);
                cmd.Parameters.AddWithValue("@Quantidade", livro.Quantidade);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Livro cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao cadastrar livro: {ex.Message}");
                }
            }
        }

        // Método para buscar um livro pelo ISBN
        public Livro BuscarLivro(string isbn)
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return null;
                }

                string query = "SELECT * FROM livros WHERE ISBN = @ISBN";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Livro
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ISBN = reader["ISBN"].ToString(),
                                Titulo = reader["Titulo"].ToString(),
                                Autor = reader["Autor"].ToString(),
                                Ano = Convert.ToInt32(reader["Ano"]),
                                Genero = reader["Genero"].ToString(),
                                Edicao = Convert.ToInt32(reader["Edicao"]),
                                Quantidade = Convert.ToInt32(reader["Quantidade"])
                            };
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao buscar livro: {ex.Message}");
                    return null;
                }
            }
        }

        // Método para atualizar os dados de um livro
        public void AtualizarLivro(string isbn, Livro novoLivro)
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return;
                }

                string query = "UPDATE livros SET titulo = @Titulo, autor = @Autor, ano = @Ano, genero = @Genero, edicao = @Edicao, quantidade = @Quantidade WHERE ISBN = @ISBN";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@Titulo", novoLivro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", novoLivro.Autor);
                cmd.Parameters.AddWithValue("@Ano", novoLivro.Ano);
                cmd.Parameters.AddWithValue("@Genero", novoLivro.Genero);
                cmd.Parameters.AddWithValue("@Edicao", novoLivro.Edicao);
                cmd.Parameters.AddWithValue("@Quantidade", novoLivro.Quantidade);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Dados do livro atualizados com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Livro não encontrado!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao atualizar livro: {ex.Message}");
                }
            }
        }

        // Método para remover um livro pelo ISBN
        public void RemoverLivro(string isbn)
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return;
                }

                string query = "DELETE FROM livros WHERE ISBN = @ISBN";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@ISBN", isbn);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Livro removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Livro não encontrado!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao remover livro: {ex.Message}");
                }
            }
        }
        public void ListarLivros()
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return;
                }

                string query = "SELECT * FROM livros";
                MySqlCommand cmd = new MySqlCommand(query, conexao);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]}");
                            Console.WriteLine($"ISBN: {reader["ISBN"]}");
                            Console.WriteLine($"Título: {reader["Titulo"]}");
                            Console.WriteLine($"Autor: {reader["Autor"]}");
                            Console.WriteLine($"Ano: {reader["Ano"]}");
                            Console.WriteLine($"Gênero: {reader["Genero"]}");
                            Console.WriteLine($"Edição: {reader["Edicao"]}");
                            Console.WriteLine($"Quantidade: {reader["Quantidade"]}");
                            Console.WriteLine("-------------------------------------");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao listar livros: {ex.Message}");
                }
            }
        }
    }
}
