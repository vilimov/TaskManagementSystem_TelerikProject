﻿using System.Text;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;

namespace Team.Command
{
    public class ShowBoardsActivityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowBoardsActivityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}; \nPlease enter correct Board name");
            }
            // Parameters:
            //  [0] - Name of the Board
            string name = this.CommandParameters[0];
            if (!Repository.Boards.Any(b => b.Name == name))
            {
                throw new InvalidUserInputException($"Board with name {name} does not exist!");
            }
            return ListAllActivities(name);
        }
        
        private string ListAllActivities(string name)
        {
            var board = Repository.Boards.Where(b => b.Name == name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Board {board} has the following activities:");
            //ToDo Not implemented well - Milko
            foreach (var activity in board)
            {
                sb.AppendLine(activity.Name);
            }
            sb.Append("---------------");
            return sb.ToString();
        }
    }
}
