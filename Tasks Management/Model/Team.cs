using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Interface;

namespace Team.Model
{
    public class Team : ITeam
    {
        private const int minLength = 5;
        private const int maxLength = 15;
        private const string errorMsg = "Team's name must be between {0} and {1} symbols";
        private readonly IList<IMember> members;
        private readonly IList<IBoard> boards;
        private readonly IList<string> activityHistory;
        public Team(string name)
        {
            Validator.ValidateIntRange(name.Length, minLength, maxLength, string.Format(errorMsg, minLength, maxLength));
            Name = name;
            members = new List<IMember>();
            boards = new List<IBoard>(); 
            activityHistory = new List<string>();
            AddActivity($"Team with name '{Name}' was created on {DateTime.Now}");
        }

        public string Name { get; }

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

        public IList<string> ActivityHistory
        {
            get 
            {
                return new List<string>(activityHistory);
            }
        }
        public void AddActivity(string activity)
        {
            activityHistory.Add(activity);
        }

        public void AddBoard(IBoard board)
        {
            if (boards.Any(b => b.Name == board.Name))
            {
                string errorMsg = "Board name must be unique within the team.";
                throw new ArgumentException(errorMsg);
            }
            boards.Add(board);
            AddActivity($"Added Board with board name: '{board.Name}'.");
        }

        public void AddMember(IMember member)
        {
            if(members.Any(m => m.Name == member.Name)) 
            {
                string errorMsg = "Member name must be unique";
                throw new ArgumentException(errorMsg);
            }
            members.Add(member);
            AddActivity($"Added member with name: '{member.Name}'.");
        }

        public void RemoveBoard(IBoard board)
        {
            boards.Remove(board);
            AddActivity($"Removed Board with board name: '{board.Name}'.");
        }

        public void RemoveMember(IMember member)
        {
            members.Remove(member);
            AddActivity($"Removed member with name: '{member.Name}'.");
        }
    }
}
