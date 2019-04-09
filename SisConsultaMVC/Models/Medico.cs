using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SisConsultaMVC.Models
{
    public class Medico
    {
        public int MedicoID { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")] // Campo obrigatório.
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ser entre  {2} e {1}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")] // Campo obrigatório.
        [EmailAddress(ErrorMessage = "Insira um e-mail valido")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")] // Campo obrigatório.
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho deve ser entre  {2} e {1}")]
        public string Especialidade { get; set; }

        public ICollection<Consulta> Consultas { get; set; }
    }
}

