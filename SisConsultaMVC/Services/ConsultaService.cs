using SisConsultaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SisConsultaMVC.Data;

namespace SisConsultaMVC.Services
{
    public class ConsultaService
    {
        private readonly SisConsultaContext _context;

        public ConsultaService(SisConsultaContext context)
        {
            _context = context;
        }

        public async Task<List<Consulta>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Consultas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DataConsulta >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataConsulta <= maxDate.Value);
            }
            return await result

                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .OrderByDescending(x => x.DataConsulta)
                .ToListAsync();
        }       
    }
}

