using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using FrontEnd.Login.Servicios;

namespace FrontEnd.Login.Controllers
{
    public class GroupInvitationsController : Controller
    {

        GroupsServices servicios = new GroupsServices();

        // GET: GroupInvitations
        public async Task<IActionResult> Index()
        {
            List<Models.GroupInvitations> aux = new List<Models.GroupInvitations>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/GroupInvitations");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.GroupInvitations>>(auxres);
                }
            }
            return View(aux);
        }

        // GET: GroupInvitations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInvitations = GetById(id);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            return View(groupInvitations);
        }

        // GET: GroupInvitations/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(servicios.GetAll(), "GroupId", "GroupName");
            return View();
        }

        // POST: GroupInvitations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupInvitationId,FromUserId,GroupId,ToUserId,SentDate,Accepted")] Models.GroupInvitations groupInvitations)
        {
            if (ModelState.IsValid)
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(groupInvitations);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/GroupInvitations", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            ViewData["GroupId"] = new SelectList(servicios.GetAll(), "GroupId", "GroupName", groupInvitations.GroupId);
            return View(groupInvitations);
        }

        // GET: GroupInvitations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInvitations = GetById(id);
            if (groupInvitations == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(servicios.GetAll(), "GroupId", "GroupName", groupInvitations.GroupId);
            return View(groupInvitations);
        }

        // POST: GroupInvitations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupInvitationId,FromUserId,GroupId,ToUserId,SentDate,Accepted")] Models.GroupInvitations groupInvitations)
        {
            if (id != groupInvitations.GroupInvitationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var cl = new HttpClient())
                    {
                        cl.BaseAddress = new Uri(Program.baseurl);
                        var content = JsonConvert.SerializeObject(groupInvitations);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var postTask = cl.PutAsync("api/GroupInvitations/" + id, byteContent).Result;

                        if (postTask.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                catch (Exception)
                {
                    var aux2 = GetById(id);
                    if (aux2 == null)
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
            ViewData["GroupId"] = new SelectList(servicios.GetAll(), "GroupId", "GroupName", groupInvitations.GroupId);
            return View(groupInvitations);
        }

        // GET: GroupInvitations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInvitations = GetById(id);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            return View(groupInvitations);
        }

        // POST: GroupInvitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupInvitations = GetById(id);
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.DeleteAsync("api/GroupInvitations/" + id);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public Models.GroupInvitations GetById(int? id)
        {
            Models.GroupInvitations aux = new Models.GroupInvitations();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/GroupInvitations/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.GroupInvitations>(auxres);
                }
            }
            return aux;
        }

        public List<Models.GroupInvitations> GetAll()
        {
            List<Models.GroupInvitations> aux = new List<Models.GroupInvitations>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/GroupInvitations").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.GroupInvitations>>(auxres);
                }
            }
            return aux;
        }

        public async Task<List<Models.GroupInvitations>> GetAllAsync()
        {
            List<Models.GroupInvitations> aux = new List<Models.GroupInvitations>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/GroupInvitations");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.GroupInvitations>>(auxres);
                }
            }
            return aux;
        }
    }
}
