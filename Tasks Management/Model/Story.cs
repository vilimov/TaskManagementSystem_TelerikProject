﻿using System;
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
        private int counter = 0;
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
            counter++;
        }

        public PriorityType Priority
        {
            get
            {
                return priority;
            }
            private set
            {
                if (counter!=0)
                {
                    AddHistory($"Story priority changed from {priority} to {value}");
                }
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
                if (counter != 0)
                {
                    AddHistory($"Story size changed from {size} to {value}");
                }
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
                if (counter != 0)
                {
                    AddHistory($"Story status changed from {status} to {value}");
                }
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
       /* public void AddComment(string commentText, IMember author)
        {
            string oldName = Assignee;
            //Assignee = newAssignee;
            AddHistory($"Assignee changed from {oldName} to {Assignee}");
        }*/
        public void ChangeAssignee(string newAssignee)
        {
            string oldName = Assignee;
            Assignee = newAssignee;
            AddHistory($"Assignee changed from {oldName} to {Assignee}");
        }
    }
}
