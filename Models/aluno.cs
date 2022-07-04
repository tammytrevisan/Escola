namespace Escola.Models
{
    public class aluno
    {

        public int Id { get; set; }
        public string nome { get; set; }  
        public DateTime dataNascimento { get; set; }
        public char sexo { get; set; }  
        public int turmaId { get; set; } 
        public int totalFaltas { get; set; }


        //relacionamento
        //public virtual turma? Turma { get; set; }
        

    }
}
