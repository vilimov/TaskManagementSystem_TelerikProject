using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Enum;
using Team.Model.Interface;
using Team.Model;

namespace Team.Model
{
    public class Story : Task, IStory
    {
        private PriorityType priority;
        private SizeType size;
        private StoryStatusType status;
        private string assignee;

        public Story(int id, 
                    string title, 
                    string description, 
                    PriorityType priority, 
                    SizeType size, 
                    string assignee)
                    : base(id, title, description)
        {
            Priority = priority;
            Size = size;
            Status = StoryStatusType.NotDone;
            Assignee = assignee;
        }

        public PriorityType Priority
        {
            get
            {
                return priority;
            }
            private set
            {
                //AddHistory($"Priority changed from {this.priority} to {value}");
                priority = value;
            }
        }      

        public SizeType Size
        {
            get
            {
                return size;
            }
            private set
            {
                //AddHistory($"Size changed from {this.size} to {value}");
                size = value;
            }
        }            

        public StoryStatusType Status
        {
            get
            {
                return status;
            }
            private set
            {
                //AddHistory($"Status changed from {this.status} to {value}");
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
                //AddHistory($"Assignee changed from {this.assignee} to {value}");
                assignee = value;
            }
        }
        //ToDo Dali ne e po-dobre da e w Task?
        public void AddComment(string commentText, IMember author)
        {
            Comments.Add(new Comment(commentText, author));
            AddHistory($"{author.Name} added a comment: {commentText}");
        }
    }
}
