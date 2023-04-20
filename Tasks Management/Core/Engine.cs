using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Command.Contracts;
using Team.Core.Contracts;
using Team.Exeption;

namespace Team.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string EmptyCommandError = "Command cannot be empty.";
        private string ReportSeparator = new string('*', 20);

        //From Agency Workshop
        private readonly ICommandFactory commandFactory;
        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    string inputLine = Console.ReadLine().Trim();

                    if (inputLine == string.Empty)
                    {
                        Console.WriteLine(EmptyCommandError);
                        continue;
                    }

                    if (inputLine.ToLower() == TerminationCommand)
                    {
                        break;
                    }

                    ICommand command = commandFactory.Create(inputLine);
                    string result = command.Execute();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(result.Trim());
                    Console.ResetColor();
                    Console.WriteLine(ReportSeparator);
                }
                catch (InvalidUserInputException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    Console.WriteLine(ReportSeparator);
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(ex);
                    }
                    Console.WriteLine(ReportSeparator);
                }
            }
        }
    }
}
