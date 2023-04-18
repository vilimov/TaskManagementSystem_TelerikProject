using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Command.Contracts;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Enum;

namespace Team.Command
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(IRepository repository)
            : this(new List<string>(), repository)
        {
            this.Repository = repository;
        }
        protected BaseCommand(IList<string> commandParameters, IRepository repository)
        {
            this.CommandParameters = commandParameters;
            this.Repository = repository;
        }
        public abstract string Execute();
        protected IRepository Repository { get; }

        protected IList<string> CommandParameters { get; }

        //Validators
        protected int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be an integer number.");
        }
        protected PriorityType ParsePriorityTypeParameter(string value, string parameterName)
        {
            if (System.Enum.TryParse(value, true, out PriorityType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Please select Low, Medium or High");
        }
        protected SeverityType ParseSeverityTypeParameter(string value, string parameterName)
        {
            if (System.Enum.TryParse(value, true, out SeverityType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Please select Minor, Major or Critical");
        }
        protected FeedbackStatus ParseFeedbackStatusParameter(string value, string parameterName)
        {
            if (System.Enum.TryParse(value, true, out FeedbackStatus result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Please select Done, Scheduled, Unscheduled or New");
        }
        protected void ValidateInputParametersCount(IList<string> commandParameters, int expectedNumberOfArguments)
        {
            if (commandParameters.Count != expectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {expectedNumberOfArguments}, Received: {commandParameters.Count}");
            }
        }
        protected SizeType ParseSizeTypeParameter(string value, string parameterName)
        {
            if (System.Enum.TryParse(value, true, out SizeType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Please select Small, Medium or Large");
        }
        protected StoryStatusType ParseStoryStatusTypeParameter(string value, string parameterName)
        {
            if (System.Enum.TryParse(value, true, out StoryStatusType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Please select NotDone, InProgress or Done");
        }
        protected StatusType ParseStatusTypeParameter(string value, string parameterName)
        {
            if (System.Enum.TryParse(value, true, out StatusType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Please select Active and Fixed");
        }
    }
}
