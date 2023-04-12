﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model;
using Team.Model.Enum;
using Team.Model.Interface;

namespace Team.Core.Contracts
{
    public interface IRepository
    {
        IList<ITeam> Teams { get; }
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }
        IList<ITask> Tasks { get; }
        //TODO IRepository - Make the create methods
        public IBoard CreateBoard(string name, ITask task);
        public IMember CreateMember(string name, ITask task);
        public ITeam CreateTeam(string name, Member member, Board board);
        public IBug CreateBug(int id, string title, string description, PriorityType priority, SeverityType severity, string assignee,string listOfSteps);
        public IStory CreateStory(int id, string title, string description, PriorityType priority, SizeType size, StoryStatusType status, string assignee);
        public IFeedback CreateFeedback(int id, string title, string description, FeedbackStatus statusType);
    }
}
