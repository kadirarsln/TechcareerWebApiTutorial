using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechcareerWebApiTutorial.Models.ORM;

namespace TechcareerWebApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly TechCareerDbContext _context;

        public EmployeeController()
        {
            _context = new TechCareerDbContext();
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {

            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetByEmployeeId(int id)
        {

            //firstordefault metodu icerisine yazdığımız sorguya göre arama yapar
            var employee = _context.Employees.FirstOrDefault(e=> e.Id == id);

            //blog yoksa 404 döndür
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return StatusCode(201, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updatedEmployee)
        {
            // Veritabanında id'ye sahip bir Employee var mı kontrol et
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            // Employee bulunamadıysa 404 Not Found döndür
            if (employee == null)
            {
                return NotFound();
            }

            // Var olan Employee'in özelliklerini güncelle
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Adress = updatedEmployee.Adress;
            employee.BirthDate = updatedEmployee.BirthDate;
            employee.City = updatedEmployee.City;
            employee.AddDate = updatedEmployee.AddDate;

            _context.SaveChanges();

            // Başarılı bir şekilde güncellendiğine dair 200 OK döndür
            return Ok(employee);
        }


        //delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e=> e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Ok(employee);
        }
    }
}
