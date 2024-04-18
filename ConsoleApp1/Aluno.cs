using System;

namespace ConsoleCRUD
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int RGM { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Curso { get; set; }
        public bool Bolsista { get; set; }
        public string RG { get; set; }
        public string Genero { get; set; }
    }
}
