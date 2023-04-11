using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Enum;
using Team.Model.Interface;

namespace Team.Model
{
    public class Feedback : Task, IFeedback
    {
        public Feedback(int id, string title, string description, FeedbackStatus statusType) : base(id, title, description)
        {
            StatusType = statusType;
        }

        public FeedbackStatus StatusType { get; }
    }
}
