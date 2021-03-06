﻿using BlazorSPA1.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSPA1.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<bool> CreateEmployee(Employee employee);
        Task<bool> EditEmployee(string id, Employee employee);
        Task<Employee> SingleEmployee(string id);
        Task<bool> DeleteEmployee(string id);
    }
}
