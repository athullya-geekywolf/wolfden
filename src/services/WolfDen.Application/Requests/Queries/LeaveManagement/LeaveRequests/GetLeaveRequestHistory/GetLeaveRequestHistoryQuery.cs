﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfDen.Application.DTOs.LeaveManagement;
using WolfDen.Domain.Entity;

namespace WolfDen.Application.Requests.Queries.LeaveManagement.LeaveRequests.GetLeaveRequestHistory
{
    public class GetLeaveRequestHistoryQuery : IRequest<List<LeaveRequestDto>>
    {
        public int RequestId { get; set; }
        public int TypeId { get; set; }
     
    }
}
