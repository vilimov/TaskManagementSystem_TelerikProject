using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface ITeam
    {
        public string Name { get;}
        public Member Member { get;}
        public Board Board { get;}

    }
}
