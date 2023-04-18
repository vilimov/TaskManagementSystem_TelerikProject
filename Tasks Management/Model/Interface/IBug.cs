using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Enum;

namespace Team.Model.Interface
{
    public interface IBug : ITask
    {
        public PriorityType Priority { get; }
        public SeverityType Severity { get; }
        public StatusType Status { get; }
        public string Assignee { get; }
        public void ChangePriority(PriorityType newPriority);
        public void ChangeSeverity(SeverityType newSeverity);
        public void ChangeStatus(StatusType newStatus);

    }
}
