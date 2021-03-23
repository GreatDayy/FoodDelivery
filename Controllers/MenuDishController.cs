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
    public class MenuDishController : ApiController
    {
        #region TBAsprint3
        //private LuncherDBModell db = new LuncherDBModell();

        //// GET: api/MenuDish
        //public IQueryable<MenuDishes> GetMenuDishes()
        //{
        //    return db.MenuDishes;
        //}

        //// GET: api/MenuDish/5
        //[ResponseType(typeof(MenuDishes))]
        //public IHttpActionResult GetMenuDishes(int id)
        //{
        //    MenuDishes menuDishes = db.MenuDishes.Find(id);
        //    if (menuDishes == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(menuDishes);
        //}

        //// PUT: api/MenuDish/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMenuDishes(int id, MenuDishes menuDishes)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != menuDishes.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(menuDishes).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MenuDishesExists(id))
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

        //// POST: api/MenuDish
        //[ResponseType(typeof(MenuDishes))]
        //public IHttpActionResult PostMenuDishes(MenuDishes menuDishes)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.MenuDishes.Add(menuDishes);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MenuDishesExists(menuDishes.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = menuDishes.Id }, menuDishes);
        //}

        //// DELETE: api/MenuDish/5
        //[ResponseType(typeof(MenuDishes))]
        //public IHttpActionResult DeleteMenuDishes(int id)
        //{
        //    MenuDishes menuDishes = db.MenuDishes.Find(id);
        //    if (menuDishes == null)
        //    {
        //        return NotFound();
        //    }

        //    db.MenuDishes.Remove(menuDishes);
        //    db.SaveChanges();

        //    return Ok(menuDishes);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool MenuDishesExists(int id)
        //{
        //    return db.MenuDishes.Count(e => e.Id == id) > 0;
        //}
        #endregion
    }
}