
//simple api without logging
using ConsumingMainWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

namespace ConsumingMainWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly string url = "http://localhost:5028/api/StudentAPI/";
        private readonly HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(std);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["insert_message"] = "Student Added.";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Log the response or show an error message
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(std);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student std)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(std);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url + std.id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["update_message"] = "Student Updated.";
                    return RedirectToAction("Index");
                }
                else
                {
                    // Log the response or show an error message
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(std);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["delete_message"] = "Student Deleted.";
                return RedirectToAction("Index");
            }
            else
            {
                // Log the response or show an error message
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View();
        }
    }
}


// api with logging
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using ConsumingMainWebAPI.Models;

//namespace ConsumingMainWebAPI.Controllers
//{
//    public class StudentController : Controller
//    {
//        private readonly string url = "http://localhost:5028/api/StudentAPI/";
//        private readonly HttpClient client = new HttpClient();

//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            List<Student> students = new List<Student>();
//            HttpResponseMessage response = await client.GetAsync(url);
//            if (response.IsSuccessStatusCode)
//            {
//                string result = await response.Content.ReadAsStringAsync();
//                students = JsonConvert.DeserializeObject<List<Student>>(result);
//            }
//            return View(students);
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Student std)
//        {
//            if (ModelState.IsValid)
//            {
//                string data = JsonConvert.SerializeObject(std);
//                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
//                HttpResponseMessage response = await client.PostAsync(url, content);
//                if (response.IsSuccessStatusCode)
//                {
//                    TempData["insert_message"] = "Student Added.";
//                    await LogOperationAsync("CreateStudent", std.id);
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
//                }
//            }
//            return View(std);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Edit(int id)
//        {
//            HttpResponseMessage response = await client.GetAsync(url + id);
//            if (response.IsSuccessStatusCode)
//            {
//                string result = await response.Content.ReadAsStringAsync();
//                var std = JsonConvert.DeserializeObject<Student>(result);
//                return View(std);
//            }
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(Student std)
//        {
//            if (ModelState.IsValid)
//            {
//                string data = JsonConvert.SerializeObject(std);
//                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
//                HttpResponseMessage response = await client.PutAsync(url + std.id, content);
//                if (response.IsSuccessStatusCode)
//                {
//                    TempData["update_message"] = "Student Updated.";
//                    await LogOperationAsync("UpdateStudent", std.id);
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
//                }
//            }
//            return View(std);
//        }

//        [HttpGet]
//        public async Task<IActionResult> Details(int id)
//        {
//            HttpResponseMessage response = await client.GetAsync(url + id);
//            if (response.IsSuccessStatusCode)
//            {
//                string result = await response.Content.ReadAsStringAsync();
//                var std = JsonConvert.DeserializeObject<Student>(result);
//                return View(std);
//            }
//            return View();
//        }

//        [HttpGet]
//        public async Task<IActionResult> Delete(int id)
//        {
//            HttpResponseMessage response = await client.GetAsync(url + id);
//            if (response.IsSuccessStatusCode)
//            {
//                string result = await response.Content.ReadAsStringAsync();
//                var std = JsonConvert.DeserializeObject<Student>(result);
//                return View(std);
//            }
//            return View();
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            HttpResponseMessage response = await client.DeleteAsync(url + id);
//            if (response.IsSuccessStatusCode)
//            {
//                TempData["delete_message"] = "Student Deleted.";
//                await LogOperationAsync("DeleteStudent", id);
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
//            }
//            return View();
//        }

//        private async Task LogOperationAsync(string operation, int recordId)
//        {
//            Assuming your API exposes a LogOperation endpoint for logging

//           string logUrl = "http://localhost:5028/api/LogOperation/";
//           var logData = new { Operation = operation, RecordId = recordId };
//            string data = JsonConvert.SerializeObject(logData);
//            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
//            await client.PostAsync(logUrl, content);
//        }
//    }
//}








