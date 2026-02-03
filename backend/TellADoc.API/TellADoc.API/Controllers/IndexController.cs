using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TellADoc.API.Context;
using TellADoc.API.Models;

namespace TellADoc.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        readonly string[] Users = new string[] { "Admin", "User", "Viewer" };

        public IndexController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IndexController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Route("/")]
        [Route("document")]
        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var documents = await _context.Document.ToListAsync();
            return Ok(documents);
        }

        [Route("document/upload")]
        [HttpPost]
        public async Task<IActionResult> UploadDocument([FromBody] Document document)
        {
            bool isDeleted = false;
            DateTime createdAt = DateTime.UtcNow;
            DateTime updatedAt = DateTime.UtcNow;

            document.IsDeleted = isDeleted;
            document.CreatedAt = createdAt;
            document.UpdatedAt = updatedAt;

            _context.Document.Add(document);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //// GET: IndexController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: IndexController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: IndexController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: IndexController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: IndexController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [Route("documents/{id}")]
        [HttpPatch]
        public async Task<IActionResult> DeleteDocument(int id, string user)
        {
            var doc = await _context.Document.FindAsync(id);

            if(user == "Admin" || user == "User")
            {
                if (doc != null)
                {
                    doc.IsDeleted = true;
                    doc.DeletedAt = DateTime.UtcNow;
                }
                else
                {
                    return NotFound("Document is not found");
                }

                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

        //// POST: IndexController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
