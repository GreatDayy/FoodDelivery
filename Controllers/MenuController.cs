using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BackEndLuncher;

namespace BackEndLuncher.Controllers
{
    public class MenuController : ApiController
    {
        private ILuncherAppContext db = new LuncherDBModell(); // Detta är context

        public MenuController()
        {

        }

        public MenuController(ILuncherAppContext context)
        {
            db = context;
        }




        // GET: api/Menu
        public IQueryable<Menu> GetMenu()
        {
            return db.Menu;
        }

        // GET: api/Menu/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult GetMenu(int id)
        {
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }
        #region TBASprint3
        //// PUT: api/Menu/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMenu(int id, Menu menu)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != menu.Id)
        //    {
        //        return BadRequest();
        //    }

        //    //db.Entry(menu).State = EntityState.Modified;
        //    db.MarkAsModified(menu);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MenuExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Menu
        //[ResponseType(typeof(Menu))]
        //public IHttpActionResult PostMenu(Menu menu)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Menu.Add(menu);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = menu.Id }, menu);
        //}

        //// DELETE: api/Menu/5
        //[ResponseType(typeof(Menu))]
        //public IHttpActionResult DeleteMenu(int id)
        //{
        //    Menu menu = db.Menu.Find(id);
        //    if (menu == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Menu.Remove(menu);
        //    db.SaveChanges();

        //    return Ok(menu);
        //}


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool MenuExists(int id)
        //{
        //    return db.Menu.Count(e => e.Id == id) > 0;
        //}
        #endregion
    }
}