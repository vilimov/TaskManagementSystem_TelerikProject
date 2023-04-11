using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface ICommentable
    {
        IList<IComment> Comments { get; }

        void AddComment(IComment comment);

        void RemoveComment(IComment comment);
    }
}
