using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface ITeam
    {
        public string Name { get; }
        IList <IMember> Members { get; }
        IList<IBoard> Boards { get; }
        void AddMember(IMember member);
        void RemoveMember(IMember member);

        void AddBoard(IBoard board);
        void RemoveBoard(IBoard board);

    }
}
