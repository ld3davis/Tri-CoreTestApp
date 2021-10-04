using System;
using System.Collections.Generic;
using Web.BLL.Models;

namespace Web.BLL.Interface
{
    public interface IEmployeeService
    {
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(Guid employeeId);
        Employee Get(Guid employeeId);
        IEnumerable<Employee> GetAll();
    }
}
