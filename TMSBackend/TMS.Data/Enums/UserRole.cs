using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Enums
{
    public enum UserRole
    {
        ProductionOperator,   // Operator responsible for registering production entries
        QualitySupervisor,    // Supervisor with full control over production records
        BusinessUnitLeader    // Leader with read-only access to reports
    }
}
