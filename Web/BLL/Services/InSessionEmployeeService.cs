using System;
using System.Collections.Generic;
using System.Linq;
using Web.BLL.Interface;
using Web.BLL.Models;

namespace Web.BLL.Services
{
    public class InSessionEmployeeService : IEmployeeService
    {
        //simple in session implementation with few checks
        public InSessionEmployeeService()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (System.Web.HttpContext.Current.Session["Employees"] == null)
            {
                CreateDefaultList();
            }
        }

        private void CreateDefaultList()
        {
            System.Web.HttpContext.Current.Session["Employees"] = new List<Employee>
            {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Leo",
                    DateOfHire = new DateTime(2020, 1, 15),
                    Position = "Developer"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    DateOfHire = new DateTime(2015, 12, 1),
                    Position = "Analyst"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Sarah",
                    DateOfHire = new DateTime(2017, 4, 8),
                    Position = "Writer"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Harold",
                    DateOfHire = new DateTime(2018, 3, 19),
                    Position = "Leader"
                }
            };
        }

        public void Create(Employee employee)
        {
            ((List<Employee>)System.Web.HttpContext.Current.Session["Employees"]).Add(employee);
        }

        public void Delete(Guid employeeId)
        {
            System.Web.HttpContext.Current.Session["Employees"] =
            ((List<Employee>)System.Web.HttpContext.Current.Session["Employees"]).Where(x => x.Id != employeeId).ToList();
        }

        public Employee Get(Guid employeeId)
        {
            return ((List<Employee>)System.Web.HttpContext.Current.Session["Employees"]).FirstOrDefault(x => x.Id == employeeId);
        }

        public IEnumerable<Employee> GetAll()
        {
            return (List<Employee>)System.Web.HttpContext.Current.Session["Employees"];
        }

        public void Update(Employee employee)
        {
            var entity = ((List<Employee>)System.Web.HttpContext.Current.Session["Employees"]).FirstOrDefault(x => x.Id == employee.Id);
            if(entity != null)
            {
                entity.Name = employee.Name;
                entity.Position = employee.Position;
                entity.DateOfHire = employee.DateOfHire;
            }
        }
    }
}