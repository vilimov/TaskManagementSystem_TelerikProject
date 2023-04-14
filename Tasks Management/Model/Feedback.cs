using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        private FeedbackStatus statusType;
        public Feedback(int id, string title, string description,int rating) : base(id, title, description)
        {
            Validator.ValidateIntRange(rating, ratingMinValue, ratingMaxValue, string.Format(ratingErrorMsg, ratingMinValue, ratingMaxValue));
            StatusType = FeedbackStatus.New;
            Rating = rating;
        }
        public int Rating { get; set; }
        public FeedbackStatus StatusType 
        {
            get
            {
                return statusType;
            }
            set
            {
                AddHistory($"Status changed from {this.statusType} to {value}");
                this.statusType = value;
            }
        }
        public void AddComment(string commentText, IMember author)
        {
            Comments.Add(new Comment(commentText, author));
            AddHistory($"{author.Name} added a comment: {commentText}");
        }
    }
}
