using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface ITask
    {
        public string Title { get; }
        public string Description { get; }
        public int Id { get; }
        IMember Assignee { get; }
        IList<IComment> Comments { get; }
        IList<string> History { get; }
        void AddComment(IComment comment);
        void RemoveComment(IComment comment);
    }
}
