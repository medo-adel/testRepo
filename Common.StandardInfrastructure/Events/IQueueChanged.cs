using System;
using System.Collections.Generic;

namespace Common.StandardInfrastructure.Events
{
    public interface IQueueChanged
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        List<Guid?> EmployeeId { get; set; }
        Guid? OrganizationId { get; set; }
        Guid? DutyTypeId { get; set; }
        Guid? DutyId { get; set; }
    }
}
