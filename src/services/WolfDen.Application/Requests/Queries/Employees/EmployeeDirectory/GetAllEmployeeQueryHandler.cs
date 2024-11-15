﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfDen.Application.DTOs;
using WolfDen.Application.Requests.Queries.Employee.GetEmployeeHierarchy;
using WolfDen.Domain.Entity;
using WolfDen.Infrastructure.Data;

namespace WolfDen.Application.Requests.Queries.Employees.EmployeeDirectory
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeDirectoryDTO>>
    {
        private readonly WolfDenContext _context;

        public GetAllEmployeeQueryHandler(WolfDenContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeDirectoryDTO>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var baseQuery = _context.Employees
               .Include(e => e.Designation)
               .Include(e => e.Department)
               .AsQueryable();



            if(request.DepartmentID.HasValue)
            {
                baseQuery=baseQuery.Where(e=>e.DepartmentId==request.DepartmentID);
            }


            if (!string.IsNullOrWhiteSpace(request.EmployeeName))
            {
                baseQuery = baseQuery.Where(e =>
                    (e.FirstName + " " + e.LastName).Contains(request.EmployeeName));
            }
            var employees = await baseQuery
               .Select(e => new EmployeeDirectoryDTO
               {
                   EmployeeCode = e.EmployeeCode,
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   Email = e.Email,
                   PhoneNumber = e.PhoneNumber,
                   DateofBirth = e.DateofBirth,
                   JoiningDate = e.JoiningDate,
                   Gender = e.Gender,
                   DesignationId = e.DesignationId,
                   Designation = e.Designation != null ? e.Designation : null,
                   DepartmentId = e.DepartmentId,
                   DepartmentName = e.Department != null ? e.Department.Name : null,
                   ManagerId = e.ManagerId,
                   ManagerName = e.Manager != null ? e.Manager.FirstName + " " + e.Manager.LastName : null,
                   IsActive = e.IsActive
               })
               .ToListAsync(cancellationToken);

            return employees;
        }
    }
}
