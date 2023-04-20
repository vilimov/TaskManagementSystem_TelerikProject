using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Team.Core.Contracts;
using Team.Exeption;
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

        private int lastTaskId = 1;
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
            /*if (boards.Any(b => b.Name == name))
            {
                throw new ArgumentException($"Board with name '{name}' already exists.");
            }*/
            var newBoard = new Board(name);
            teams.FirstOrDefault(t => t.Name == team.Name).AddBoard(newBoard);
            boards.Add(newBoard);
            return newBoard;

        }

        public IBug CreateBug(string title, string description, string boardName, PriorityType priority, 
                              SeverityType severity, string assignee, string listOfSteps, string teamName)
        {
            var team = CheckIfTeamExists(teamName);     //Check if Team Exists, return Iteam
            var myBoard = CheckTeamHasBoard(boardName, team);           //Check if Bord is in Team and return Board
            CheckMemberInTeam(team, assignee);          //Check if Member is in Team
            DoesTaskTitleExistsInBoard(title, myBoard);
            var member = ReturnTheMember(assignee);
            var taskID = lastTaskId;
            var bug = new Bug(taskID, title, description, priority, severity, assignee, listOfSteps);
            myBoard.AddTask(bug);
            this.tasks.Add(bug);
            member.AssignTask(bug);
            GenerateUniqueTaskId();
            return bug;
        }

        private ITeam CheckIfTeamExists(string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new InvalidUserInputException($"Team with name {teamName} doesn't exist");
            }
            var team = teams.FirstOrDefault(t => t.Name == teamName);
            return team;
        }

        public IFeedback CreateFeedback(string title, string description, int rating, string boardName, string teamName)
        {
            var team = CheckIfTeamExists(teamName);     //Check if Team Exists, return Iteam
            var myBoard = CheckTeamHasBoard(boardName, team);           //Check if Bord is in Team and return Board
            DoesTaskTitleExistsInBoard(title, myBoard);
            var taskID = lastTaskId;
            var feedback = new Feedback(taskID, title, description, rating);
            myBoard.AddTask(feedback);
            this.tasks.Add(feedback);
            GenerateUniqueTaskId();
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

        public IStory CreateStory(string title, string description, string boardName, PriorityType priority, SizeType size, string assignee, string teamName)
        {
            var team = CheckIfTeamExists(teamName);     //Check if Team Exists, return Iteam
            var myBoard = CheckTeamHasBoard(boardName, team);           //Check if Bord is in Team and return Board
            CheckMemberInTeam(team, assignee);          //Check if Member is in Team
            DoesTaskTitleExistsInBoard(title, myBoard);
            var member = ReturnTheMember(assignee);
            var taskID = lastTaskId;
            var story = new Story(taskID, title, description, priority, size, assignee);
            myBoard.AddTask(story);
            this.tasks.Add(story);
            member.AssignTask(story);
            GenerateUniqueTaskId();
            return story;
        }

        private IMember ReturnTheMember(string assignee)
        {
            foreach (var member in members)
            {
                if (member.Name == assignee)
                {
                    return member;
                }
            }
            string errorMsg = $"Assignee with name '{assignee}' doesn't exist.";
            throw new ArgumentException(errorMsg);
        }

        public ITeam CreateTeam(string name)
        {
            var newTeam = new Model.Team(name);
            teams.Add(newTeam);
            return newTeam;
            
        }
        // New Find task. Used for Changing Enums (Priority/Severity/Status)
        public ITask FindTask(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);

            if (task == null)
            {
                throw new ArgumentException($"Task with ID {taskId} not found.");
            }

            return task;
        }
        public IEnumerable<ITask> GetAllTasks()
        {
            return tasks;
        }
        //ID ++
        private int GenerateUniqueTaskId()
        {
            lastTaskId++;
            return lastTaskId;
        }

        //Check for unique Task Title
        public bool DoesTaskTitleExistsInBoard(string title, IBoard board)
        {
            foreach (var task in board.Tasks)
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
        public IBoard CheckTeamHasBoard(string boardName, ITeam teamName)
        {
            foreach (var board in teamName.Boards)
            {
                if (board.Name == boardName)
                {
                    return board;
                }
            }
            throw new ArgumentException($"This board is not part of team {teamName.Name}");
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

        // Change Enum Value
        public static void ChangeEnumValue<T>(T obj, string propertyName, string enumValueName) where T : class
        {
            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(propertyName);
            Type propType = prop.PropertyType;
            
            if (propType.IsEnum)
            {
                if (Enum.TryParse(propType, enumValueName, out var enumValue))
                {
                    prop.SetValue(obj, enumValue);
                }
                else
                {
                    throw new InvalidUserInputException($"{type.Name} '{propertyName}' does not contain value '{enumValueName}'");
                }
                    
                
            }
        }            
    }
}
