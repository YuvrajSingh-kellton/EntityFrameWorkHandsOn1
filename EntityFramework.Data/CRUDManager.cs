using EntityFramework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class CRUDManager
    {
        private DemoDbContext demoDbContext;
        public CRUDManager()
        {
            demoDbContext = new DemoDbContext();
        }

        public Employee GetEmplpoyeeById(int employeeId)
        {
            // Tracking not required
            var employee = demoDbContext.Employees.Where(x => x.ID == employeeId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            var employee = demoDbContext.Employees.ToList();
            return employee;
        }

        public void Insert(Employee employee)
        {
            demoDbContext.Employees.Add(employee);
            demoDbContext.SaveChanges();
        }

        public void Update(int employeeId, Employee modifiedEmployee)
        {
            var employee = demoDbContext.Employees.Where(x => x.ID == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            employee.Name = modifiedEmployee.Name;
            employee.Address = modifiedEmployee.Address;

            // Entity state : Modified
            demoDbContext.Employees.Update(employee);

            // This issues insert statement
            demoDbContext.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var employee = demoDbContext.Employees.Where(x => x.ID == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            // Entity state : Deleted
            demoDbContext.Employees.Remove(employee);

            // This issues insert statement
            demoDbContext.SaveChanges();
        }
    }
}
