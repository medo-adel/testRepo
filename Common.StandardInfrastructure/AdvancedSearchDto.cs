﻿using System;
using System.Collections.Generic;

namespace Common.StandardInfrastructure
{
    public class AdvancedSearchDto
    {
        public IEnumerable<Guid?> GenderId { get; set; }
        public IEnumerable<Guid?> AdminstrationId { get; set; }
        public IEnumerable<Guid?> LocationId { get; set; }
        public IEnumerable<Guid?> JobId { get; set; }
        public IEnumerable<Guid?> TeamId { get; set; }
        public IEnumerable<Guid?> OverTimeOrderId { get; set; }
        public List<Guid?> EmployeesResultIds { get; set; }
        public List<Guid?> EmployeesIdsByTeamId { get; set; }
        public string TypeProcess { get; set; }
        public bool? IsSuperAdmin { get; set; } = false;
        public Guid? EmployeeId { get; set; }
        public bool ForEmployeeDuties { get; set; }
        public bool? ForMyInquiry { get; set; } = true;
        public List<Guid?> EmployeeIds { get; set; }

    }

    public class EmployeeDutyAdvancedSearchDto : AdvancedSearchDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? FixedDutyId { get; set; }
    }
}
