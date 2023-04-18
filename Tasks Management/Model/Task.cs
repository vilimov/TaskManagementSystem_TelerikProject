using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Interface;

namespace Team.Model
{
    public abstract class Task : ITask
    {
        private const int TitleMinLenght = 10;
        private const int TitleMaxLenght = 50;
        private const string TitleLenghtErrorMsg = "Title must be between 10 and 50 symbols.";
        private const int DescriptionMinLenght = 10;
        private const int DescriptionMaxLenght = 500;
        private const string DescriptionLenghtErrorMsg = "Description must be between 10 and 500 symbols.";

        private readonly IList<string> history = new List<string>();
        private readonly IList<IComment> comments = new List<IComment>();

        public Task(int id, string title, string description) 
        {
            Validator.ValidateIntRange(title.Length, TitleMinLenght, TitleMaxLenght, TitleLenghtErrorMsg);
            Validator.ValidateIntRange(description.Length, DescriptionMinLenght, DescriptionMaxLenght, DescriptionLenghtErrorMsg);
            Id = id;
            Title = title;
            Description = description;
            AddHistory($"{this.GetType().Name} with name {title} and ID {id} was created!");
        }
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        
        public IList<IComment> Comments
        {
            get
            {
                return new List<IComment>(comments);
            }
        }

        public IList<string> History
        {
            get
            {
                return new List<string>(history);
            }
        }

        public void AddComment(IComment comment)
        {
            comments.Add(comment);
            AddHistory($"New Comment Added by {comment.Author}");
        }

        public void RemoveComment(IComment comment)
        {
            comments.Remove(comment);
        }

        public void AddHistory(string historyText)
        {
            history.Add(historyText);
        }
    }
}
