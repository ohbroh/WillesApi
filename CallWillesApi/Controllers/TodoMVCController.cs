using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CallWillesApi.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoApi.Models;

namespace CallWillesApi.Controllers
{
    public class TodoMVCController : Controller
    {
        ArtistApi _api = new ArtistApi();
        public async Task<IActionResult> Index()
        {
            List<TodoItem> toDO = new List<TodoItem>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("/api/TodoItems");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                toDO = JsonConvert.DeserializeObject<List<TodoItem>>(result);
            }
            return View(toDO);
        }
        public async Task<IActionResult> DeleteArtist(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync("/api/TodoItems/" + id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PutArtist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PutArtist(TodoItem Titem)
        {
            TodoItem T1 = new TodoItem();
            HttpClient client = _api.Initial();
            var putTask = client.PutAsJsonAsync<TodoItem>("/api/TodoItems/" + Titem.Artist_ID, Titem);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(Titem);
        }
        [HttpGet]
        public ActionResult PostArtist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostArtist(TodoItem Titem)
        {
            TodoItem T1 = new TodoItem();
            HttpClient client = _api.Initial();
            var putTask = client.PostAsJsonAsync<TodoItem>("/api/TodoItems", Titem);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(Titem);
        }
        public async Task<IActionResult> IndexLot()
        {
            List<TodoItemLot> toDO = new List<TodoItemLot>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("/api/TodoItemLots");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                toDO = JsonConvert.DeserializeObject<List<TodoItemLot>>(result);
            }
            return View(toDO);
        }
        public async Task<IActionResult> DeleteLot(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync("/api/TodoItemLots/" + id);
            return RedirectToAction("IndexLot");
        }

        [HttpGet]
        public ActionResult PutLot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PutLot(TodoItemLot Titem)
        {
            TodoItemLot T1 = new TodoItemLot();
            HttpClient client = _api.Initial();
            var putTask = client.PutAsJsonAsync<TodoItemLot>("/api/TodoItemLots/" + Titem.Lot_ID, Titem);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("IndexLot");
            }
            return View(Titem);
        }
        public ActionResult PostLot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostLot(TodoItemLot Titem)
        {
            TodoItemLot T1 = new TodoItemLot();
            HttpClient client = _api.Initial();
            var putTask = client.PostAsJsonAsync<TodoItemLot>("/api/TodoItemLots", Titem);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("IndexLot");
            }
            return View(Titem);
        }

        public async Task<IActionResult> IndexSkivbolag()
        {
            List<TodoItemSkivbolag> toDO = new List<TodoItemSkivbolag>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("/api/TodoItemSkivbolags");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                toDO = JsonConvert.DeserializeObject<List<TodoItemSkivbolag>>(result);
            }
            return View(toDO);
        }
        public async Task<IActionResult> DeleteSkivbolag(int id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync("/api/TodoItemSkivbolags/" + id);
            return RedirectToAction("IndexSkivbolag");
        }
        [HttpGet]
        public ActionResult PutSkivbolag()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PutSkivbolag(TodoItemSkivbolag Titem)
        {
            TodoItemSkivbolag T1 = new TodoItemSkivbolag();
            HttpClient client = _api.Initial();
            var putTask = client.PutAsJsonAsync<TodoItemSkivbolag>("/api/TodoItemSkivbolags/" + Titem.Skivbolag_ID, Titem);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("IndexSkivbolag");
            }
            return View(Titem);
        }
        public ActionResult PostSkivbolag(TodoItemSkivbolag Titem)
        {
            TodoItemSkivbolag T1 = new TodoItemSkivbolag();
            HttpClient client = _api.Initial();
            var putTask = client.PostAsJsonAsync<TodoItemSkivbolag>("/api/TodoItemSkivbolags", Titem);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("IndexSkivbolag");
            }
            return View(Titem);
        }

    }
}
