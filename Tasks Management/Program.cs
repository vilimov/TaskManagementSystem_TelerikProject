﻿using Team.Model.Interface;
using Team.Model;
using Team.Core.Contracts;
using Team.Core;

namespace Team
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Core.Engine(commandFactory);
            engine.Start();

            /*
            Console.WriteLine("Hello, World!");

            ITask story = new Story(1, "Title_title", "Description", Model.Enum.PriorityType.Low, Model.Enum.SizeType.Small, Model.Enum.StoryStatusType.NotDone, "Assignee");

            IStory story1 = new Story(1, "Title_title1", "Description1", Model.Enum.PriorityType.Low, Model.Enum.SizeType.Small, Model.Enum.StoryStatusType.NotDone, "Assignee1");

            IMember member = new Member("Gosho", story);

            Console.WriteLine(new string('#', 20));*/
        }
    }
}