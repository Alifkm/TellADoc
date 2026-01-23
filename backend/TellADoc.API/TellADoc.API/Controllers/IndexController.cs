using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TellADoc.API.Context;
using TellADoc.API.Models;

namespace TellADoc.API.Controllers
{
    public class IndexController : Controller
    {
        public readonly ApplicationDbContext _context;

        public IndexController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IndexController
        public ActionResult Index()
        {
            return View();
        }

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

        // GET: IndexController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
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
