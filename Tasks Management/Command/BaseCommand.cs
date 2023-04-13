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
    }
}
