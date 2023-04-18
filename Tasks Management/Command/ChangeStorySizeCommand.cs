﻿using Team.Core.Contracts;
using Team.Model;
using Team.Model.Interface;

namespace Team.Command
{
    public class ChangeStorySizeCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeStorySizeCommand(List<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);
            ParseIntParameter(CommandParameters[0], "ID");

            // Parameters:
            // [0] - ID
            // [1] - New Size
            IStory obj = (Story)Repository.Tasks.FirstOrDefault(s => s.Id == int.Parse(CommandParameters[0]));
            var currentSize = obj.Size;
            var newSize = CommandParameters[1];
            Core.Repository.ChangeEnumValue(obj, "Size", newSize);
            string message = $"Story size changed from {currentSize} to {newSize}";
            return message;
        }
    }
}