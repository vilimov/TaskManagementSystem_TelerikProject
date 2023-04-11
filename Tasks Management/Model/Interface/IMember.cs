using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface IMember
    {
        public string Name { get; }
        public ITask Task { get; }
        public IList<string> ActivityHistory { get; }
    }
}
