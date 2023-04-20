using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Enum;

namespace Team.Tests.Helpers
{
    public static class TaskData
    {
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
}
