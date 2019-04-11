using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisConsultaMVC.Models
{
    public class Paciente
    {
        public int PacienteID { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")] // Campo obrigatório.
        [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ser entre  {2} e {1}")]
        [Display(Name = "Paciente")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")] // Campo obrigatório.
        [StringLength(14, MinimumLength = 11, ErrorMessage = "{0} tamanho deve ser entre  {2} (sem pontuação) e {1} (com pontuação)")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Telefone")]
        public string NumTelefone { get; set; }

        [EmailAddress(ErrorMessage = "Insira um e-mail valido")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public ICollection<Consulta> Consultas { get; set; }



    }
}
