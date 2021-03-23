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
    public class DishController : ApiController
    {
        

        private ILuncherAppContext db = new LuncherDBModell();

        public DishController()
        {

        }
        public DishController(ILuncherAppContext context)
        {
            db = context;
        }

        // GET: api/Dish
        public IQueryable<Dishes> GetDishes()
        {
            return db.Dishes;
        }

        // GET: api/Dish/5
        [ResponseType(typeof(Dishes))]
        public IHttpActionResult GetDishes(int id)
        {
            Dishes dishes = db.Dishes.Find(id);
            if (dishes == null)
            {
                return NotFound();
            }

            return Ok(dishes);
        }
        #region TBASprint3
        //// PUT: api/Dish/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDishes(int id, Dishes dishes)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != dishes.Id)
        //    {
        //        return BadRequest();
        //    }

        //    //db.Entry(dishes).State = EntityState.Modified;
        //    db.MarkAsModified(dishes);
        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DishesExists(id))
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

        //// POST: api/Dish
        //[ResponseType(typeof(Dishes))]
        //public IHttpActionResult PostDishes(Dishes dishes)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Dishes.Add(dishes);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = dishes.Id }, dishes);
        //}

        //// DELETE: api/Dish/5
        //[ResponseType(typeof(Dishes))]
        //public IHttpActionResult DeleteDishes(int id)
        //{
        //    Dishes dishes = db.Dishes.Find(id);
        //    if (dishes == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Dishes.Remove(dishes);
        //    db.SaveChanges();

        //    return Ok(dishes);
        //}
        
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool DishesExists(int id)
        //{
        //    return db.Dishes.Count(e => e.Id == id) > 0;
        //}
        #endregion

    }
}