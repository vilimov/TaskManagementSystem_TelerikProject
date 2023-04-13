using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Exeption;
using Team.Model.Enum;
using Team.Model.Interface;

namespace Team.Model
{
    public class Bug : Task, IBug
    {
        private PriorityType priority;
        private SeverityType severity;
        private StatusType status;
        private string assignee;

        public Bug( int id, 
                    string title,  
                    string description, 
                    PriorityType priority, 
                    SeverityType severity, 
                    string assignee,
                    string listOfSteps) 
            : base(id, title, description)
        {
            Status = StatusType.Active;
        }
        public PriorityType Priority 
        {
            get
            {
                return priority;
            }
            private set 
            {
                priority = value;
            }
        }
        public SeverityType Severity
        {
            get
            {
                return severity;
            }
            private set
            {
                severity = value;
            }
        }
        public StatusType Status
        {
            get
            {
                return status;
            }
            private set
            {
                status = value;
            }
        }
        public string Assignee 
        {
            get
            {
                return assignee;
            } 
            private set
            {
                assignee = value;
            }
        }

    }
}
