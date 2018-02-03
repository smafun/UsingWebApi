using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UsingWebApi.Data;
using UsingWebApi.Models;

namespace UsingWebApi.Controllers
{
    public class OrdersController : Controller
    {
        public async Task<IActionResult> Index(String searchString)
        {
            List<Order> OrderInfo = new List<Order>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(ConstantsUrl.REST_SERVICE_URL);
                client.DefaultRequestHeaders.Clear();
                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string path = "order";
                if(! String.IsNullOrEmpty(searchString))
                {
                    
                }
                try
                {
                    // Sending request to find web api REST service resource GetAll using HttpClient
                    HttpResponseMessage Res = await client.GetAsync(path);
                    // Checking response is successful or not which is sent using HttpClient
                    if(Res.IsSuccessStatusCode)
                    {
                        // Storing the response details received from web api
                        var EmResponse = Res.Content.ReadAsStringAsync().Result;

                        // Deserializing the response received from web api and storing into the order list
                        OrderInfo = JsonConvert.DeserializeObject<List<Order>>(EmResponse);
                    }
                }catch
                {
                    ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                    return RedirectToAction(nameof(Index));
                }
                return View(OrderInfo);
            }
            
        }
        /*  // GET: Orders/Details/5
            public async Task<IActionResult> Details(long? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var order = await _context.Orders
                    .SingleOrDefaultAsync(m => m.id == id);
                if (order == null)
                {
                    return NotFound();
                }

                return View(order);
            }

            // GET: Orders/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Orders/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("id")] Order order)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(order);
            }

            // GET: Orders/Edit/5
            public async Task<IActionResult> Edit(long? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var order = await _context.Orders.SingleOrDefaultAsync(m => m.id == id);
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }

            // POST: Orders/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(long id, [Bind("id")] Order order)
            {
                if (id != order.id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(order);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!OrderExists(order.id))
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
                return View(order);
            }

            // GET: Orders/Delete/5
            public async Task<IActionResult> Delete(long? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var order = await _context.Orders
                    .SingleOrDefaultAsync(m => m.id == id);
                if (order == null)
                {
                    return NotFound();
                }

                return View(order);
            }

            // POST: Orders/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(long id)
            {
                var order = await _context.Orders.SingleOrDefaultAsync(m => m.id == id);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool OrderExists(long id)
            {
                return _context.Orders.Any(e => e.id == id);
            }*/
    }
}
