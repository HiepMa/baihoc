using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ItemController (TodoContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Item>> Get()
        {
            return _context.Items.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromForm] Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            var file = item.File;
            if(file != null)
            {
                string path = _hostingEnvironment.WebRootPath + "\\Data\\";
                string newFileName = item.ItemId + "_" + file.FileName;
                using (var stream = new FileStream(path + newFileName, FileMode.Create)) {
                    file.CopyTo(stream);
                    item.File = null;
                    item.Image = newFileName;
                    _context.Entry(item).Property(x => x.Image).IsModified = true;
                    _context.SaveChanges();
                }
            }
            return Ok(item);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromForm]Item item)
        {
            var im = _context.Items.Find(id);
            if(im == null)
            {
                return NotFound();
            }

            im.name = item.name;
            im.Descript = item.Descript;
            im.Price = item.Price;

            _context.Items.Update(im);
            _context.SaveChanges();

            var file = item.File;
            if (file != null)
            {
                string path = _hostingEnvironment.WebRootPath + "\\Data\\";
                //delete file
                string oldFile = im.Image;
                FileInfo old = new FileInfo(path + oldFile);
                if (old.Exists) old.Delete();
                string newFileName = im.ItemId + "_" + file.FileName;
                using (var stream = new FileStream(path+ newFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    im.File = null;
                    im.Image = newFileName;
                    _context.Entry(im).Property(x => x.Image).IsModified = true;
                    _context.SaveChanges();
                }
            }
            
            return Ok(im);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
