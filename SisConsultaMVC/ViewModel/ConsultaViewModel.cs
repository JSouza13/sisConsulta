using SisConsultaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisConsultaMVC.ViewModel
{
    public class ConsultaViewModel
    {
        public string Chave { get; set; }
        public List<Consulta> Itens { get; set; }
        public string Especialidade { get; set; }

        public ConsultaViewModel()
        {
            
            Itens = new List<Consulta>();
            
        }
    }
}
