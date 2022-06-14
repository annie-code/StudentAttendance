using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendance.Data;
using StudentAttendance.Models;

namespace StudentAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceModelsController : ControllerBase
    {
        private readonly StudentAttendanceContext _context;

        public StudentAttendanceModelsController(StudentAttendanceContext context)
        {
            _context = context;
        }

        // GET: api/StudentAttendanceModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAttendanceModel>>> GetStudentAttendanceModel()
        {
            return await _context.StudentAttendanceModel.ToListAsync();
        }

        // GET: api/StudentAttendanceModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAttendanceModel>> GetStudentAttendanceModel(int id)
        {
            var studentAttendanceModel = await _context.StudentAttendanceModel.FindAsync(id);

            if (studentAttendanceModel == null)
            {
                return NotFound();
            }

            return studentAttendanceModel;
        }

        // PUT: api/StudentAttendanceModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAttendanceModel(int id, StudentAttendanceModel studentAttendanceModel)
        {
            if (id != studentAttendanceModel.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentAttendanceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAttendanceModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentAttendanceModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentAttendanceModel>> PostStudentAttendanceModel(StudentAttendanceModel studentAttendanceModel)
        {
            _context.StudentAttendanceModel.Add(studentAttendanceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentAttendanceModel", new { id = studentAttendanceModel.StudentId }, studentAttendanceModel);
        }

        // DELETE: api/StudentAttendanceModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAttendanceModel(int id)
        {
            var studentAttendanceModel = await _context.StudentAttendanceModel.FindAsync(id);
            if (studentAttendanceModel == null)
            {
                return NotFound();
            }

            _context.StudentAttendanceModel.Remove(studentAttendanceModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentAttendanceModelExists(int id)
        {
            return _context.StudentAttendanceModel.Any(e => e.StudentId == id);
        }
    }
}
