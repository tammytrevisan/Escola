namespace Escola.Models
{
    public class turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        //public object aluno { get; set; }

        //relacionamento
        //public virtual List<aluno> Alunos { internal get; set; }
    }
}
