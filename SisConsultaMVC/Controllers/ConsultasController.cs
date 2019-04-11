using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisConsultaMVC.Data;
using SisConsultaMVC.Models;
using SisConsultaMVC.Validation;

namespace SisConsultaMVC.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly SisConsultaContext _context;
        private readonly ConsultaValidation _validation;



        public ConsultasController(SisConsultaContext context, ConsultaValidation validation)
        {
            _context = context;
            _validation = validation;
        }



        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var sisConsultaContext = _context.Consultas.Include(c => c.Medico).Include(c => c.Paciente);
            return View(await sisConsultaContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.ConsultaID == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["MedicoID"] = new SelectList(_context.Medicos, "MedicoID", "Nome");
            ViewData["PacienteID"] = new SelectList(_context.Pacientes, "PacienteID", "NomePaciente");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsultaID,MedicoID,PacienteID,DataConsulta")] Consulta consulta) 
        {
            if (ModelState.IsValid)
            {
                if (_validation.ValidarConsultaMedico(consulta.MedicoID, consulta.DataConsulta)){

                    ModelState.AddModelError("ProcessSubmitUpload", "Já existe consulta agendada para este médico");
                    ViewData["MedicoID"] = new SelectList(_context.Medicos, "MedicoID", "Nome");
                    ViewData["PacienteID"] = new SelectList(_context.Pacientes, "PacienteID", "NomePaciente");
                    return View();
                    //throw new Exception("Já consulta agendada para este médico");
                }
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoID"] = new SelectList(_context.Medicos, "MedicoID", "MedicoID", consulta.MedicoID);
            ViewData["PacienteID"] = new SelectList(_context.Pacientes, "PacienteID", "PacienteID", consulta.PacienteID);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["MedicoID"] = new SelectList(_context.Medicos, "MedicoID", "Nome", consulta.MedicoID);
            ViewData["PacienteID"] = new SelectList(_context.Pacientes, "PacienteID", "NomePaciente", consulta.PacienteID);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsultaID,MedicoID,PacienteID,DataConsulta")] Consulta consulta)
        {
            if (id != consulta.ConsultaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.ConsultaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicoID"] = new SelectList(_context.Medicos, "MedicoID", "Nome", consulta.MedicoID);
            ViewData["PacienteID"] = new SelectList(_context.Pacientes, "PacienteID", "NomePaciente", consulta.PacienteID);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.ConsultaID == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.ConsultaID == id);
        }
    }
}
