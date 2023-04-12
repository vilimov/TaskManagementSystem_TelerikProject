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
        public Story(int id, 
                    string title, 
                    string description, 
                    string board,
                    PriorityType priority, 
                    SizeType size, 
                    StoryStatusType status, 
                    string assignee)
                    : base(id, title, description, board)
        {
            Priority = priority;
            Size = size;
            Status = status;
            Assignee = assignee;
        }

        public PriorityType Priority { get; private set; }      

        public SizeType Size { get; private set; }            

        public StoryStatusType Status { get; private set; }

        public string Assignee { get; private set; }

    }
}
