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
    public class OrderController : ApiController
    {
        private ILuncherAppContext db = new LuncherDBModell();
        private OrderValidation orderValidation = new OrderValidation();

        public OrderController()
        {

        }

        public OrderController(ILuncherAppContext context)
        {
            db = context;
        }

        #region TBASprint3
        // GET: api/Order
        //public IQueryable<Orders> GetOrders()
        //{
        //    return db.Orders;
        //}

        //// GET: api/Order/5
        //[ResponseType(typeof(Orders))]
        //public IHttpActionResult GetOrders(int id)
        //{
        //    Orders orders = db.Orders.Find(id);
        //    if (orders == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(orders);
        //}
        
        //// PUT: api/Order/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutOrders(int id, Orders orders)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != orders.Id)
        //    {
        //        return BadRequest();
        //    }

        //    //db.Entry(orders).State = EntityState.Modified;
        //    db.MarkAsModified(orders);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrdersExists(id))
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

        //// POST: api/Order
        //[ResponseType(typeof(Orders))]
        //public IHttpActionResult PostOrders(Orders orders)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        #endregion

        // POST: api/Order
        [ResponseType(typeof(Orders))]
        public IHttpActionResult PostOrders(Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }          
            
            var errorList = orderValidation.ValidateOrder(orders);
            if (errorList.ContainsKey(100))
            {
                return BadRequest(orderValidation.ErrorListToString());
            }
            db.Orders.Add(orders);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrdersExists(orders.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orders.Id }, orders);
        }

        #region TBAsprint3
        //// DELETE: api/Order/5
        //[ResponseType(typeof(Orders))]
        //public IHttpActionResult DeleteOrders(int id)
        //{
        //    Orders orders = db.Orders.Find(id);
        //    if (orders == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Orders.Remove(orders);
        //    db.SaveChanges();

        //    return Ok(orders);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool OrdersExists(int id)
        {
            return db.Orders.Count(e => e.Id == id) > 0;
        }
        #endregion
    }
}