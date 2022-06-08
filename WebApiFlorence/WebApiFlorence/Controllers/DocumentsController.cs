#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFlorence;
using WebApiFlorence.Data;
using Wkhtmltopdf.NetCore;

namespace WebApiFlorence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DataContext _context;
        readonly IGeneratePdf _generatedPdf;

        public DocumentsController(DataContext context,IGeneratePdf generatePdf)
        {
            _context = context;
            _generatedPdf = generatePdf;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
            return await _context.Documents.ToListAsync();
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // PUT: api/Documents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(int id, Document document)
        {
            if (id != document.DocumentId)
            {
                return BadRequest();
            }

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        // POST: api/Documents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Document>> PostDocument()
        {
            //creare contract

            Document document=new Document();
            document.SigningDate = new DateTime(2020,2,2,12,12,12);
            document.ReservationId= 1;

            var user = new User
            {
                UserId = 40,
                FirstName = "Ramona",
                LastName = "Oana",
                Address = "Strada Principala, Numarul 348",
                County = "Ilfov",
                Town = "Copaceni",
                Phone = "0731831884",
                Email = "ramonaoana29@gmail.com"
            };

            var array=await _generatedPdf.GetByteArray("Views/Contract.cshtml", user);
            document.ContentDocument = array;


            _context.Documents.Add(document);
           
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocument", new { id = document.DocumentId }, document);
        }



        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }
    }
}
