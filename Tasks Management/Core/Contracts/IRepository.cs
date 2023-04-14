using System;
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
        //public IBoard CreateBoard(string name, ITask task);
        public IBoard CreateBoard(string name, ITeam team);
        public IMember CreateMember(string name);
        public ITeam CreateTeam(string name, Member member, Board board);
        public IBug CreateBug(string title, string description, string board, PriorityType priority, SeverityType severity, string assignee,string listOfSteps);
        public IStory CreateStory(string title, string description, string board, PriorityType priority, SizeType size, StoryStatusType status, string assignee);
        public IFeedback CreateFeedback(string title, string description, int rating, string board, FeedbackStatus statusType);
    }
}
