using System;
using System.Linq;
using MySql.Data.MySqlClient;

namespace ConsoleCRUD
{
    public class Secretaria
    {
        // Método para adicionar um aluno
        public void AdicionarAluno(Aluno aluno)
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return;
                }

                string query = "INSERT INTO alunos (Nome, RGM, data_nascimento, Curso, Bolsista, RG, Genero) VALUES (@Nome, @RGM, @DataNascimento, @Curso, @Bolsista, @RG, @Genero)";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                cmd.Parameters.AddWithValue("@RGM", aluno.RGM);
                cmd.Parameters.AddWithValue("@DataNascimento", aluno.DataNascimento);
                cmd.Parameters.AddWithValue("@Curso", aluno.Curso);
                cmd.Parameters.AddWithValue("@Bolsista", aluno.Bolsista);
                cmd.Parameters.AddWithValue("@RG", aluno.RG);
                cmd.Parameters.AddWithValue("@Genero", aluno.Genero);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Aluno cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao cadastrar aluno: {ex.Message}");
                }
            }
        }

        // Método para buscar um aluno pelo RGM
        public Aluno BuscarAluno(int rgm)
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return null;
                }

                string query = "SELECT * FROM alunos WHERE RGM = @RGM";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@RGM", rgm);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Aluno
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                RGM = Convert.ToInt32(reader["RGM"]),
                                DataNascimento = Convert.ToDateTime(reader["data_nascimento"]), // Corrigido para "data_nascimento"
                                Curso = reader["Curso"].ToString(),
                                Bolsista = Convert.ToBoolean(reader["Bolsista"]),
                                RG = reader["RG"].ToString(),
                                Genero = reader["Genero"].ToString()
                            };
                        }
                        else
                        {
                            Console.WriteLine("Aluno não encontrado.");
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao buscar aluno: {ex.Message}");
                    return null;
                }
            }
        }

        // Método para atualizar os dados de um aluno
        public void AtualizarAluno(int rgm, Aluno novoAluno)
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return;
                }

                string query = "UPDATE alunos SET Nome = @Nome, data_nascimento = @DataNascimento, Curso = @Curso, Bolsista = @Bolsista, RG = @RG, Genero = @Genero WHERE RGM = @RGM";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@Nome", novoAluno.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", novoAluno.DataNascimento);
                cmd.Parameters.AddWithValue("@Curso", novoAluno.Curso);
                cmd.Parameters.AddWithValue("@Bolsista", novoAluno.Bolsista);
                cmd.Parameters.AddWithValue("@RG", novoAluno.RG);
                cmd.Parameters.AddWithValue("@Genero", novoAluno.Genero);
                cmd.Parameters.AddWithValue("@RGM", rgm);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Dados do aluno atualizados com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Aluno não encontrado!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao atualizar aluno: {ex.Message}");
                }
            }
        }

        // Método para remover um aluno pelo RGM
        public void RemoverAluno(int rgm)
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return;
                }

                string query = "DELETE FROM alunos WHERE RGM = @RGM";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@RGM", rgm);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Aluno removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Aluno não encontrado!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao remover aluno: {ex.Message}");
                }
            }
        }

        // Método para listar todos os alunos cadastrados
        public void ListarAlunos()
        {
            using (MySqlConnection conexao = ConexaoBanco.AbrirConexao())
            {
                if (conexao == null)
                {
                    Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
                    return;
                }

                string query = "SELECT * FROM alunos";
                MySqlCommand cmd = new MySqlCommand(query, conexao);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Nenhum aluno cadastrado.");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine();
                                Console.WriteLine($"ID: {reader["Id"]}");
                                Console.WriteLine($"Nome: {reader["Nome"]}");
                                Console.WriteLine($"RGM: {reader["RGM"]}");
                                Console.WriteLine($"Data de Nascimento: {reader["data_nascimento"]}");
                                Console.WriteLine($"Curso: {reader["Curso"]}");
                                Console.WriteLine($"Bolsista: {reader["Bolsista"]}");
                                Console.WriteLine($"RG: {reader["RG"]}");
                                Console.WriteLine($"Gênero: {reader["Genero"]}");
                                Console.WriteLine("-------------------------------------");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao listar alunos: {ex.Message}");
                }
            }
        }
    }
}