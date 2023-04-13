using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Interface;

namespace Team.Model
{
    public class Comment : IComment
    {
        private const int CommentMinLength = 4;
        private const int CommentMaxLength = 200;
        private const string InvalidCommentError = "Invalid comment text length";
        private const string CommentSeparator = "**********";
        public Comment(string comment, IMember author)
        {
            Validator.ValidateIntRange(comment.Length, CommentMinLength, CommentMaxLength, InvalidCommentError);

            CommentText = comment;
            Author = author;
        }
        public IMember Author { get; }

        public string CommentText { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(CommentSeparator);
            sb.AppendLine($"Author: {Author}");
            sb.AppendLine($"{CommentText}");
            sb.Append(CommentSeparator);

            return sb.ToString();
        }
    }
}
