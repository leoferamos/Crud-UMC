using System;
using MySql.Data.MySqlClient;

namespace ConsoleCRUD
{
    public static class ConexaoBanco
    {
        private static readonly object bloqueio = new object();
        private static MySqlConnection instancia;
        private static string connectionString = "server=sql.freedb.tech;user=freedb_cruduser;password=E!9kD6h2W!4QY@9;database=freedb_testedb";

        // Método estático para obter a instância única da classe
        public static MySqlConnection ObterInstancia()
        {
            // Verifica se a instância ainda não foi criada
            if (instancia == null)
            {
                // Usando um bloqueio para garantir que a criação da instância seja thread-safe
                lock (bloqueio)
                {
                    // Verifica novamente dentro do bloqueio se a instância ainda é nula
                    if (instancia == null)
                    {
                        instancia = new MySqlConnection(connectionString);
                    }
                }
            }
            return instancia;
        }

        // Método para abrir a conexão
        public static MySqlConnection AbrirConexao()
        {
            try
            {
                MySqlConnection conexao = ObterInstancia();
                conexao.Open();
                return conexao;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
                return null;
            }
        }

        // Método para fechar a conexão
        public static void FecharConexao()
        {
            if (instancia != null && instancia.State == System.Data.ConnectionState.Open)
            {
                instancia.Close();
            }
        }
    }
}
