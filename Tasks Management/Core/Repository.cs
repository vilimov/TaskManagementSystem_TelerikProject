using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public IList<ITeam> Teams
        {
            get
            {
                return new List<ITeam>(teams);
            }
        }

        public IList<IMember> Members
        {
            get
            {
                return new List<IMember>(members);
            }
        }

        public IList<IBoard> Boards
        {
            get
            {
                return new List<IBoard>(boards);
            }
        }

        public IList<ITask> Tasks
        {
            get
            {
                return new List<ITask>(tasks);
            }
        }

        public IBoard CreateBoard(string name, ITask task)
        {
            throw new NotImplementedException();
        }

        public IBug CreateBug(string title, string description, string bordName, PriorityType priority, 
                              SeverityType severity, string assignee, string listOfSteps)
        {
            doesTaskTitleExists(title);
            var myBoard = BoardNameExists(bordName);
            var myTeam = CheckTeamHasBoard(myBoard);
            CheckMemberInTeam(myTeam, assignee);
            var taskID = tasks.Count;
            var bug = new Bug(++taskID, title, description, priority, severity, assignee, listOfSteps);
            myBoard.AssignTask(bug);
            this.tasks.Add(bug);
            return bug;
        }

        public IFeedback CreateFeedback(string title, string description, int rating, string bordName, FeedbackStatus statusType)
        {
            doesTaskTitleExists(title);
            var myBoard = BoardNameExists(bordName);
            var taskID = tasks.Count;
            var feedback = new Feedback(++taskID, title, description, rating, statusType);
            myBoard.AssignTask(feedback);
            this.tasks.Add(feedback);
            return feedback;
        }

        public IMember CreateMember(string name, ITask task)
        {
            throw new NotImplementedException();
        }

        public IStory CreateStory(string title, string description, string bordName, PriorityType priority, SizeType size, StoryStatusType status, string assignee)
        {
            throw new NotImplementedException();
        }

        public ITeam CreateTeam(string name, Member member, Board board)
        {
            throw new NotImplementedException();
        }

        //Check for unique Task Title
        public bool doesTaskTitleExists(string title)
        {
            foreach (var task in tasks)
            {
                if (task.Title == title)
                {
                    string errorMsg = $"Task with title {title} already exists.";
                    throw new ArgumentException(errorMsg);
                }
            }
            return true;
        }

        //Check if Board Name exists and return the Board with this name
        public IBoard BoardNameExists(string name)
        {
            foreach (var board in boards)
            {
                if (board.Name == name)
                {
                    return board;
                }
            }
            string errorMsg = $"Board with name {name} doesn't exist.";
            throw new ArgumentException(errorMsg);
        }

        //Check if the board is added to a team
        public ITeam CheckTeamHasBoard(IBoard checkBoard)
        {
            foreach (var team in teams)
            {
                if (team.Boards.Contains(checkBoard))
                {
                    return team;
                }
            }
            throw new ArgumentException("This board is not part of any team");
        }

        //Check if member is part of a team
        public bool CheckMemberInTeam(ITeam myTeamm, string memberName)
        {
            foreach (var teamMember in myTeamm.Members)
            {
                if (teamMember.Name == memberName)
                { 
                    return true;
                }
            }
            throw new ArgumentException($"Person with name {memberName} is not in the {myTeamm.Name} team");
        }
    }
}
