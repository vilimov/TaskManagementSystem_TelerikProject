using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Model;
using Team.Model.Enum;
using Team.Model.Interface;

namespace Team.Core
{
    public class Repository : IRepository
    {
        private readonly IList<ITeam> teams = new List<ITeam>();
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<IBoard> boards = new List<IBoard>();
        private readonly IList<ITask> tasks = new List<ITask>();

        //TODO - Example of ID tracker
        /*var nextId = vehicles.Count;
        var bus = new Bus(++nextId, passengerCapacity, pricePerKilometer, hasFreeTv);
        this.vehicles.Add(bus);
        return bus;*/
        public IList<ITeam> Teams => throw new NotImplementedException();

        public IList<IMember> Members => throw new NotImplementedException();

        public IList<IBoard> Boards => throw new NotImplementedException();

        public IList<ITask> Tasks => throw new NotImplementedException();

        public IBoard CreateBoard(string name, ITask task)
        {
            throw new NotImplementedException();
        }

        public IBug CreateBug(int id, string title, string description, PriorityType priority, SeverityType severity, string assignee, string listOfSteps)
        {
            throw new NotImplementedException();
        }

        public IFeedback CreateFeedback(int id, string title, string description, FeedbackStatus statusType)
        {
            throw new NotImplementedException();
        }

        public IMember CreateMember(string name, ITask task)
        {
            throw new NotImplementedException();
        }

        public IStory CreateStory(int id, string title, string description, PriorityType priority, SizeType size, StoryStatusType status, string assignee)
        {
            throw new NotImplementedException();
        }

        public ITeam CreateTeam(string name, Member member, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
