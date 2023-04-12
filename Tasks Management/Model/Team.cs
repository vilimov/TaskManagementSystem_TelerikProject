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
        public Team(string name, Member member, Board board)
        {
            Validator.ValidateIntRange(name.Length, minLength, maxLength, string.Format(errorMsg, minLength, maxLength));
        }

        public string Name { get; }

        public Member Member { get; }

        public Board Board { get; }
    }
}
