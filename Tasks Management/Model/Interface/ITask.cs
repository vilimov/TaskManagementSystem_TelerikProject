using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface ITask : ICommentable
    {
        public string Title { get; }
        public string Description { get; }
        IMember Assignee { get; set; }
        public int Id { get; }
        IList<IComment> Comments { get; }
        IList<string> History { get; }
    }
}
