using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface ICommentable
    {
        IList<IComment> History { get; }

        void AddComment(IComment history);

        void RemoveComment(IComment history);
    }
}
