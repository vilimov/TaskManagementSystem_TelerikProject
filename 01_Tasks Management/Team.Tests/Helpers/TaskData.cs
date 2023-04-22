using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Team.Core.Contracts;
using Team.Core;
using Team.Model;
using Team.Model.Enum;

namespace Team.Tests.Helpers
{
    public static class TaskData
    {
        public static List<string> GetListWithSize(int size)
        {
            return new string[size].ToList();
        }

        public static IRepository GetTestRepository()
        {
            return new Repository();
        }

        public const string ValidTitle = "Valid_Title";
        public const string ValidDescription = "Valid_Description";
    }

    public static class BugData
    {
        public static PriorityType ValidPriority = PriorityType.Medium;
        public static SeverityType ValidSeverity = SeverityType.Major;
        public const string ValidAssignee = "Assignee_Name";
        public const string ValidStepsList = "step1, step2, step3";
    }
    public static class StoryData
    {
        public static PriorityType ValidPriority = PriorityType.Medium;
        public static SizeType ValidSize = SizeType.Medium;

    }
    public static class FeedbackData
    {
        public static int ValidRating = 3;
    }
    public static class MemberData
    {
        public const string ValidName = "Valid_Name";
    }
    public static class TeamData
    {
        public const string ValidName = "Valid_Name";
    }
    public static class BoardData
    {
        public const string ValidName = "Valid_Name";
    }

    public static class TaskTestInitialization
    {
        public static Model.Bug InitializeTestBug()
        {
            return new Model.Bug(
                        1,
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BugData.ValidPriority,
                        BugData.ValidSeverity,
                        BugData.ValidAssignee,
                        BugData.ValidStepsList);
        }
    }
    public static class MemberTestInitialization
    {
        public static Member InitializeTestMember()
        {
            return new Member(MemberData.ValidName);
        }
    }
    public static class BoardTestInitialization
    {
        public static Board InitializeTestBoard()
        {
            return new Board("BoardName");
        }
    }
    public static class RepossitoryTestInitialization
    {
        public static IRepository GetTestRepository()
        {
            return new Repository();
        }
    }
}
