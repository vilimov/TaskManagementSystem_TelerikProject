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
        private const int ratingMinValue = 1;
        private const int ratingMaxValue = 5;
        private const string ratingErrorMsg = "Rating must be a number between {0} and {1}";
        public Feedback(int id, string title, string description,int rating, FeedbackStatus statusType) : base(id, title, description)
        {
            Validator.ValidateIntRange(rating, ratingMinValue, ratingMaxValue, string.Format(ratingErrorMsg, ratingMinValue, ratingMaxValue));
            StatusType = statusType;
            Rating = rating;
        }

        public FeedbackStatus StatusType { get; }

        public int Rating { get; set; }
    }
}
