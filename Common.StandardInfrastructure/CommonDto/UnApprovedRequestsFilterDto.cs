using System;
using System.Collections.Generic;
using System.Text;

namespace Common.StandardInfrastructure.CommonDto
{
   public class UnApprovedRequestsFilterDto
    {

        public SearchValues searchValues { get; set; }

    }

    public class SearchValues
    {
        public Guid? WorkflowTemplateId { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? StatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
