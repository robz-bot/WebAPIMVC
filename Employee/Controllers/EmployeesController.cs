using Employee.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

//https://localhost:44357/  mvc
//https://localhost:44386/  api
namespace Employee.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult Index()
        {
            List<Models.Employee> employee = new List<Models.Employee>();
            try
            {
                HttpResponseMessage responseMessage = GlobalVariables.httpClient.GetAsync("api/Employees").Result;
                responseMessage.EnsureSuccessStatusCode();
                employee = responseMessage.Content.ReadAsAsync<List<Models.Employee>>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(employee);
        }

        public ActionResult AddOrEdit(int id=0)
        {
            if(id==0)
            {
                return View(new Models.Employee());
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalVariables.httpClient.GetAsync("api/Employees/"+id.ToString()).Result;
                return View(responseMessage.Content.ReadAsAsync<Models.Employee>().Result);
            }
            
        }

        [HttpPost]
        public ActionResult AddOrEdit(Models.Employee employee)
        {
            if(employee.Id==0)
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage responseMessage = GlobalVariables.httpClient.PostAsJsonAsync("api/Employees", employee).Result;
                    TempData["Message"] = "Saved Succesfully";
                }
                else
                {
                    TempData["Invalid_Data"] = "Please provide the required fields";
                    return View();
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage responseMessage = GlobalVariables.httpClient.PutAsJsonAsync("api/Employees/"+employee.Id, employee).Result;
                    TempData["Message"] = "Updated Succesfully";
                }
                else
                {
                    TempData["Invalid_Data"] = "Please provide the required fields";
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if(id>0)
            {
                HttpResponseMessage responseMessage = GlobalVariables.httpClient.DeleteAsync("api/Employees/" + id.ToString()).Result;
                TempData["deleteMessage"] = "Deleted Succesfully";
            }
            return RedirectToAction("Index");
        }


    }
}
