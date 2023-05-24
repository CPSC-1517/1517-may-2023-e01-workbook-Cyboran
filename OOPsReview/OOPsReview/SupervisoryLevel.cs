using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public enum SupervisoryLevel
    {
        // summary
        // enum names are strings representing an integer value
        // by default the integer values start at 0 and increment by 1
        // one could assign their own values to each of the enum names
        Entry,
        TeamMember,
        TeamLeader,
        Supervisor,
        DepartmentHead,
        Owner
    }
}
