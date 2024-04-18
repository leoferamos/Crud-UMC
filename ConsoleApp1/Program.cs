using System;

namespace ConsoleCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Secretaria alunoManager = new Secretaria();
            Biblioteca livroManager = new Biblioteca();

            while (true)
            {
                Console.WriteLine("\n\n╔════════════════ MENU DE OPÇÕES ════════════════╗    ");
                Console.WriteLine("║ 1- Alunos                                      ║    ");
                Console.WriteLine("║                                                ║     ");
                Console.WriteLine("║ 2- Livros                                      ║    ");
                Console.WriteLine("║                                                ║     ");
                Console.WriteLine("║ 0- Sair                                        ║    ");
                Console.WriteLine("╚════════════════════════════════════════════════╝    ");
                Console.Write("Selecione uma opção: ");


                if (!int.TryParse(Console.ReadLine(), out int opcaoPrincipal))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (opcaoPrincipal)
                {
                    case 1:
                        MenuAlunos(alunoManager);
                        break;
                    case 2:
                        MenuLivros(livroManager);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                
            }
        }

        static void MenuAlunos(Secretaria alunoManager)
        {
            while (true)
            {
                
                Console.WriteLine("\n\n╔════════════════ MENU DE OPÇÕES ════════════════╗    ");
                Console.WriteLine("║ 1- Cadastrar Aluno                             ║    ");
                Console.WriteLine("║                                                ║     ");
                Console.WriteLine("║ 2- Buscar Aluno                                ║    ");
                Console.WriteLine("║                                                ║     ");
                Console.WriteLine("║ 3- Atualizar Cadastro do Aluno                 ║    ");
                Console.WriteLine("║                                                ║    ");
                Console.WriteLine("║ 4- Remover Aluno                               ║    ");
                Console.WriteLine("║                                                ║    ");
                Console.WriteLine("║ 5- Listar Alunos                               ║    ");
                Console.WriteLine("║                                                ║    ");
                Console.WriteLine("║ 0- Voltar                                      ║    ");
                Console.WriteLine("╚════════════════════════════════════════════════╝    ");
                Console.WriteLine(" ");
                Console.Write("Digite uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out int opcaoAluno))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (opcaoAluno)
                {
                    case 1:
                        AdicionarAluno(alunoManager);
                        break;
                    case 2:
                        BuscarAluno(alunoManager);
                        break;
                    case 3:
                        AtualizarAluno(alunoManager);
                        break;
                    case 4:
                        RemoverAluno(alunoManager);
                        break;
                    case 5:
                        ListarAlunos(alunoManager);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MenuLivros(Biblioteca livroManager)
        {
            while (true)
            {
                Console.WriteLine("\n\n╔════════════════ MENU DE OPÇÕES ════════════════╗    ");
                Console.WriteLine("║ 1- Adicionar Livro                             ║    ");
                Console.WriteLine("║                                                ║     ");
                Console.WriteLine("║ 2- Buscar Livro                                ║    ");
                Console.WriteLine("║                                                ║     ");
                Console.WriteLine("║ 3- Atualizar Livro                             ║    ");
                Console.WriteLine("║                                                ║    ");
                Console.WriteLine("║ 4- Remover Livro                               ║    ");
                Console.WriteLine("║                                                ║    ");
                Console.WriteLine("║ 5- Listar Livros                               ║    ");
                Console.WriteLine("║                                                ║    ");
                Console.WriteLine("║ 0- Voltar                                      ║    ");
                Console.WriteLine("╚════════════════════════════════════════════════╝    ");
                Console.WriteLine(" ");
                Console.Write("Digite uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out int opcaoLivro))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (opcaoLivro)
                {
                    case 1:
                        AdicionarLivro(livroManager);
                        break;
                    case 2:
                        BuscarLivro(livroManager);
                        break;
                    case 3:
                        AtualizarLivro(livroManager);
                        break;
                    case 4:
                        RemoverLivro(livroManager);
                        break;
                    case 5:
                        ListarLivros(livroManager);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        // Métodos para operações com alunos
        static void AdicionarAluno(Secretaria alunoManager)
        {
            Console.WriteLine("Informe o nome do aluno:");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe o RGM do aluno:");
            int rgm = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a data de nascimento do aluno (formato: yyyy-MM-dd):");
            DateTime dataNascimento = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Informe o curso do aluno:");
            string curso = Console.ReadLine();

            Console.WriteLine("O aluno é bolsista? (true/false):");
            bool bolsista = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Informe o RG do aluno:");
            string rg = Console.ReadLine();

            Console.WriteLine("Informe o gênero do aluno:");
            string genero = Console.ReadLine();

            Aluno aluno = new Aluno
            {
                Nome = nome,
                RGM = rgm,
                DataNascimento = dataNascimento,
                Curso = curso,
                Bolsista = bolsista,
                RG = rg,
                Genero = genero
            };

            alunoManager.AdicionarAluno(aluno);
        }

        static void BuscarAluno(Secretaria alunoManager)
        {
            Console.WriteLine("Informe o RGM do aluno que deseja buscar:");
            int rgm = Convert.ToInt32(Console.ReadLine());

            Aluno aluno = alunoManager.BuscarAluno(rgm);
            if (aluno != null)
            {
                Console.WriteLine($"Nome: {aluno.Nome}");
                Console.WriteLine($"RGM: {aluno.RGM}");
                Console.WriteLine($"Data de Nascimento: {aluno.DataNascimento.ToShortDateString()}");
                Console.WriteLine($"Curso: {aluno.Curso}");
                Console.WriteLine($"Bolsista: {aluno.Bolsista}");
                Console.WriteLine($"RG: {aluno.RG}");
                Console.WriteLine($"Gênero: {aluno.Genero}");
            }
        }

        static void AtualizarAluno(Secretaria alunoManager)
        {
            Console.WriteLine("Informe o RGM do aluno que deseja atualizar:");
            int rgm = Convert.ToInt32(Console.ReadLine());

            Aluno alunoExistente = alunoManager.BuscarAluno(rgm);
            if (alunoExistente != null)
            {
                Console.WriteLine("Informe o novo nome do aluno:");
                string nome = Console.ReadLine();

                Console.WriteLine("Informe a nova data de nascimento do aluno (formato: yyyy-MM-dd):");
                DateTime dataNascimento = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Informe o novo curso do aluno:");
                string curso = Console.ReadLine();

                Console.WriteLine("O aluno é bolsista? (true/false):");
                bool bolsista = Convert.ToBoolean(Console.ReadLine());

                Console.WriteLine("Informe o novo RG do aluno:");
                string rg = Console.ReadLine();

                Console.WriteLine("Informe o novo gênero do aluno:");
                string genero = Console.ReadLine();

                Aluno novoAluno = new Aluno
                {
                    Nome = nome,
                    RGM = rgm,
                    DataNascimento = dataNascimento,
                    Curso = curso,
                    Bolsista = bolsista,
                    RG = rg,
                    Genero = genero
                };

                alunoManager.AtualizarAluno(rgm, novoAluno);
            }
        }

        static void RemoverAluno(Secretaria alunoManager)
        {
            Console.WriteLine("Informe o RGM do aluno que deseja remover:");
            int rgm = Convert.ToInt32(Console.ReadLine());

            alunoManager.RemoverAluno(rgm);
        }

        static void ListarAlunos(Secretaria alunoManager)
        {
            alunoManager.ListarAlunos();
        }

        // Métodos para operações com livros
        static void AdicionarLivro(Biblioteca livroManager)
        {
            Console.WriteLine("Informe o ISBN do livro:");
            string isbn = Console.ReadLine();

            Console.WriteLine("Informe o título do livro:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Informe o autor do livro:");
            string autor = Console.ReadLine();

            Console.WriteLine("Informe o ano do livro:");
            int ano = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o gênero do livro:");
            string genero = Console.ReadLine();

            Console.WriteLine("Informe a edição do livro:");
            int edicao = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a quantidade do livro:");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Livro livro = new Livro
            {
                ISBN = isbn,
                Titulo = titulo,
                Autor = autor,
                Ano = ano,
                Genero = genero,
                Edicao = edicao,
                Quantidade = quantidade
            };

            livroManager.AdicionarLivro(livro);
        }

        static void BuscarLivro(Biblioteca livroManager)
        {
            Console.WriteLine("Informe o ISBN do livro que deseja buscar:");
            string isbn = Console.ReadLine();

            Livro livro = livroManager.BuscarLivro(isbn);
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Ano: {livro.Ano}");
                Console.WriteLine($"Gênero: {livro.Genero}");
                Console.WriteLine($"Edição: {livro.Edicao}");
                Console.WriteLine($"Quantidade: {livro.Quantidade}");
            }
        }

        static void AtualizarLivro(Biblioteca livroManager)
        {
            Console.WriteLine("Informe o ISBN do livro que deseja atualizar:");
            string isbn = Console.ReadLine();

            Livro livroExistente = livroManager.BuscarLivro(isbn);
            if (livroExistente != null)
            {
                Console.WriteLine("Informe o novo título do livro:");
                string titulo = Console.ReadLine();

                Console.WriteLine("Informe o novo autor do livro:");
                string autor = Console.ReadLine();

                Console.WriteLine("Informe o novo ano do livro:");
                int ano = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe o novo gênero do livro:");
                string genero = Console.ReadLine();

                Console.WriteLine("Informe a nova edição do livro:");
                int edicao = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe a nova quantidade do livro:");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                Livro novoLivro = new Livro
                {
                    Titulo = titulo,
                    Autor = autor,
                    Ano = ano,
                    Genero = genero,
                    Edicao = edicao,
                    Quantidade = quantidade
                };

                livroManager.AtualizarLivro(isbn, novoLivro);
            }
        }

        static void RemoverLivro(Biblioteca livroManager)
        {
            Console.WriteLine("Informe o ISBN do livro que deseja remover:");
            string isbn = Console.ReadLine();

            livroManager.RemoverLivro(isbn);
        }

        static void ListarLivros(Biblioteca livroManager)
        {
            livroManager.ListarLivros();
        }
    }
}