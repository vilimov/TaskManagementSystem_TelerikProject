using System;
using System.Collections.Generic;
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
        //UNDONE - Probably we need IList<IMemebers> and IList<IBoards> and not in the constructor, but in addBoard and addMemeber methods
        public Team(string name)
        {
            Validator.ValidateIntRange(name.Length, minLength, maxLength, string.Format(errorMsg, minLength, maxLength));
            Name = name;
            Members = new List<IMember>();
            Boards = new List<IBoard>();
        }

        public string Name { get; }

        public IList<IMember> Members { get; }

        public IList<IBoard> Boards { get; }

        public void AddBoard(IBoard board)
        {
            if (Boards.Any(b => b.Name == board.Name))
            {
                string errorMsg = "Board name must be unique within the team.";
                throw new ArgumentException(errorMsg);
            }
            Boards.Add(board);
        }

        public void AddMember(IMember member)
        {
            if(Members.Any(m => m.Name == member.Name)) 
            {
                string errorMsg = "Member name must be unique";
                throw new ArgumentException(errorMsg);
            }
            Members.Add(member);
        }

        public void RemoveBoard(IBoard board)
        {
            Boards.Remove(board);
        }

        public void RemoveMember(IMember member)
        {
            Members.Remove(member);
        }
    }
}
