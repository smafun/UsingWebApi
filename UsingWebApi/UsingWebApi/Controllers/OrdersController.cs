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
                    //
                    path = path + "/Search/" + searchString;
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

                //Order test = OrderInfo.Find(x => x.GetId() == "xy");
                return View(OrderInfo);
            }
            
        }

        // GET: Orders/Create
        public IActionResult Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Start test
           
            // End test

            var OrderInfo = new Order();
            OrderInfo.CustomerId = (long)id;

            return View(OrderInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (order.Id > 0)
            {
                order.Id = 0;
            }
            using (var client = new HttpClient())
            {
                // Passing service base url
                client.BaseAddress = new Uri(ConstantsUrl.REST_SERVICE_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.PostAsJsonAsync("order", order);
                    // Checking the response
                    if (!Res.IsSuccessStatusCode)
                    {
                        ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                    }
                }
                catch
                {
                    ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                }
                // rerturn the customer list to view
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(String id)
        {
            var tmpOrder = new Order();
            String tmp = ConstantsUrl.ORDER + "/" + id;
            using (var client = new HttpClient())
            {
                // Passing service base url
                client.BaseAddress = new Uri(ConstantsUrl.REST_SERVICE_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.GetAsync(tmp);
                    // Checking the response
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        tmpOrder = JsonConvert.DeserializeObject<Order>(EmpResponse);
                    }
                }
                catch
                {
                    ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                    return RedirectToAction(nameof(Index));
                }
                // rerturn the order list to view
                return View(tmpOrder);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                // Passing service base url
                client.BaseAddress = new Uri(ConstantsUrl.REST_SERVICE_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.PutAsJsonAsync("order/" + id, order);
                    // Checking the response
                    if (!Res.IsSuccessStatusCode)
                    {
                        ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                        return View(order);
                    }
                }
                catch
                {
                    ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                    return View(order);
                }
                // rerturn the order list to view
                return RedirectToAction(nameof(Index));
            }
        }

        //Get: OrdersController/DEelte
        public async Task<IActionResult> Delete(int? id)
        {
            var tmpOrder = new Order();
            String tmp = ConstantsUrl.ORDER + "/" + id;
            using (var client = new HttpClient())
            {
                // Passing service base url
                client.BaseAddress = new Uri(ConstantsUrl.REST_SERVICE_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.GetAsync(tmp);
                    // Checking the response
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        tmpOrder = JsonConvert.DeserializeObject<Order>(EmpResponse);
                    }
                }
                catch
                {
                    ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                    return RedirectToAction(nameof(Index));
                }
                // rerturn the order list to view
                return View(tmpOrder);
            }
        }

        //Post: Order/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConstantsUrl.REST_SERVICE_URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // Sending request to find web api REST service resource using HttpClient
                    HttpResponseMessage Res = await client.DeleteAsync("order/" + id);
                    // Checking the response
                    if (!Res.IsSuccessStatusCode)
                    {
                        ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                    }
                }
                catch
                {
                    ViewData["Error"] = ConstantsUrl.ERROR_MESSAGE;
                }
                // rerturn the order list to view
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
