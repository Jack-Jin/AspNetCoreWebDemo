using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebDemo_MVC.Models;
using AspNetCoreWebDemo_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWebDemo_MVC.Controllers
{
    /* Demo #1 ***************************************************************
     * 
     * services.AddMvcCore();
     * 
     *************************************************************************/
    //public class HomeController
    //{
    //    public string Index()
    //    {
    //        return "Hello from MVC";
    //    }
    //}

    /* Demo #2 ***************************************************************
     * 
     * services.AddMvc();
     * 
     *************************************************************************/
    //public class HomeController : Controller
    //{
    //    // GET: /<controller>/
    //    public JsonResult Index()
    //    {
    //        return Json(new { id = 1, name = "Jack" });
    //    }
    //}

    /* Demo #3 ***************************************************************
     * 
     * services.AddMvc().AddXmlDataContractSerializerFormatters();
     * 
     *************************************************************************/
    //public class HomeController : Controller
    //{
    //    public ObjectResult Index()
    //    {
    //        return new ObjectResult(new { id = 1, name = "Jack" });
    //    }
    //}

    /* Demo #4 ***************************************************************
     * Dependency Injection
     * 
     * services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
     * 
     *************************************************************************/
    //public class HomeController : Controller
    //{
    //    private IEmployeeRepository _EmployeeRepository;

    //    public HomeController(IEmployeeRepository employeeRepository)
    //    {
    //        _EmployeeRepository = employeeRepository;
    //    }

    //    public ObjectResult Index()
    //    {
    //        Employee emp = _EmployeeRepository.GetEmployee(2);

    //        return new ObjectResult(emp);
    //    }
    //}

    /* Demo #5 ***************************************************************
     * ViewData
     * ViewBag
     * Strongly Type
     * 
     *************************************************************************/
    //public class HomeController : Controller
    //{
    //    private IEmployeeRepository _EmployeeRepository;

    //    public HomeController(IEmployeeRepository employeeRepository)
    //    {
    //        _EmployeeRepository = employeeRepository;
    //    }

    //    public ViewResult Details()
    //    {
    //        Employee emp = _EmployeeRepository.GetEmployee(2);

    //        ViewData["Employee"] = emp;

    //        ViewBag.PageTitle = "Employee Details";
    //        ViewBag.Employee = emp;

    //        return View(emp);
    //    }
    //}

    /* Demo #5 ***************************************************************
     * ViewModel
     *************************************************************************/
    //public class HomeController : Controller
    //{
    //    private IEmployeeRepository _EmployeeRepository;

    //    public HomeController(IEmployeeRepository employeeRepository)
    //    {
    //        _EmployeeRepository = employeeRepository;
    //    }

    //    public ViewResult Index()
    //    {
    //        List<Employee> list = _EmployeeRepository.GetEmployeeList();

    //        return View(list);
    //    }

    //    public ViewResult Details1(int id)
    //    {
    //        HomeDetails1ViewModel homeDetails1ViewModel = new HomeDetails1ViewModel()
    //        {
    //            PageTitle = "Employee Details",
    //            Employee = _EmployeeRepository.GetEmployee(id)
    //        };

    //        return View(homeDetails1ViewModel);
    //    }
    //}

    /* Demo #7 ***************************************************************
     * Attribute routes
     *************************************************************************/
    //[Route("[controller]/[action]")]
    ////[Route("[controller]")]
    ////[Route("Home")]
    //public class HomeController : Controller
    //{
    //    private IEmployeeRepository _EmployeeRepository;

    //    public HomeController(IEmployeeRepository employeeRepository)
    //    {
    //        _EmployeeRepository = employeeRepository;
    //    }

    //    [Route("~/Home")]
    //    //[Route("")]
    //    //[Route("[action]")]
    //    //[Route("Index")]
    //    [Route("~/")]
    //    //[Route("~/")]
    //    //[Route("Home")]
    //    //[Route("Home/Index")]
    //    public ViewResult Index()
    //    {
    //        List<Employee> list = _EmployeeRepository.GetEmployeeList();

    //        return View(list);
    //    }

    //    [Route("{id?}")]
    //    //[Route("[action]/{id?}")]
    //    //[Route("Details/{id?}")]
    //    //[Route("Home/Details/{id?}")]
    //    public ViewResult Details1(int? id)
    //    {
    //        HomeDetails1ViewModel homeDetails1ViewModel = new HomeDetails1ViewModel()
    //        {
    //            PageTitle = "Employee Details",
    //            Employee = _EmployeeRepository.GetEmployee(id ?? 1)
    //        };

    //        return View(homeDetails1ViewModel);
    //    }
    //}

    /* Demo #8 ***************************************************************
     * Attribute routes
     *************************************************************************/
    public class HomeController : Controller
    {
        private IEmployeeRepository _EmployeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            List<Employee> list = _EmployeeRepository.GetEmployeeList();

            return View(list);
        }

        public ViewResult Details1(int? id)
        {
            HomeDetails1ViewModel homeDetails1ViewModel = new HomeDetails1ViewModel()
            {
                PageTitle = "Employee Details",
                Employee = _EmployeeRepository.GetEmployee(id ?? 1)
            };

            return View(homeDetails1ViewModel);
        }
    }



}
