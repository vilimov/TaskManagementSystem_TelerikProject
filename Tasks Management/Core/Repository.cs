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

        private int lastTaskId = 0;

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

        //public IBoard CreateBoard(string name, ITask task)
        public IBoard CreateBoard(string name, ITeam team)
        {
            var newBoard = new Board(name);
            teams.FirstOrDefault(t => t.Name == team.Name).AddBoard(newBoard);
            boards.Add(newBoard);
            return newBoard;

        }

        public IBug CreateBug(string title, string description, string bordName, PriorityType priority, 
                              SeverityType severity, string assignee, string listOfSteps)
        {
            doesTaskTitleExists(title);
            var myBoard = BoardNameExists(bordName);
            var myTeam = CheckTeamHasBoard(myBoard);
            CheckMemberInTeam(myTeam, assignee);
            var taskID = GenerateUniqueTaskId();
            var bug = new Bug(taskID, title, description, priority, severity, assignee, listOfSteps);
            myBoard.AddTask(bug);
            this.tasks.Add(bug);
            return bug;
        }

        public IFeedback CreateFeedback(string title, string description, int rating, string bordName)
        {
            doesTaskTitleExists(title);
            var myBoard = BoardNameExists(bordName);
            var taskID = GenerateUniqueTaskId();
            var feedback = new Feedback(taskID, title, description, rating);
            myBoard.AddTask(feedback);
            this.tasks.Add(feedback);
            return feedback;
        }

        public IMember CreateMember(string name)
        {
            if(members.Any(m => m.Name == name))
            {
                throw new ArgumentException($"Member with name '{name}' already exists.");
            }
            var newMember = new Member(name);
            members.Add(newMember);
            return newMember;
        }

        public IStory CreateStory(string title, string description, string boardName, PriorityType priority, SizeType size, StoryStatusType status, string assignee)
        {
            doesTaskTitleExists(title);
            var myBoard = BoardNameExists(boardName);
            var taskID = GenerateUniqueTaskId();
            var story = new Story(taskID, title, description, priority, size, status, assignee);
            myBoard.AddTask(story);
            this.tasks.Add(story);
            return story;
        }

        public ITeam CreateTeam(string name)
        {
            var newTeam = new Model.Team(name);
            teams.Add(newTeam);
            return newTeam;
            
        }
        //ID ++
        private int GenerateUniqueTaskId()
        {
            lastTaskId++;
            return lastTaskId;
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
