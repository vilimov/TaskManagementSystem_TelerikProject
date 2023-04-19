using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model;
using Team.Model.Interface;

namespace Team.Command.Enum
{
    public enum CommandType
    {
        //Add person to team.
        AddMemberToTeam,
        //Create a new board in a team.
        CreateBoard,
        //Create a new Bug in a board.
        CreateBug,
        //Create a new Feedback in a board.
        CreateFeedback,
        //Create a new person.
        CreateMember,
        //Create a new Story in a board.
        CreateStory,
        //Create a new team.
        CreateTeam,
        //Show board's activity.
        ShowBoardsActivity,
        //Show person's activity.
        ShowMembersActivity,
        //Show all people.
        ShowMembers,
        //Show all team boards.
        ShowTeamBoards,
        //Show all team members.
        ShowTeamMembers,
        //Show team's activity.
        ShowTeamsActivity,
        //Show all teams.
        ShowTeams,
        // Change Bug Priority
        ChangeBugPriority,
        // Change Bug Severity
        ChangeBugSeverity,
        // Change Bug Status
        ChangeBugStatus,
        // Change Story Priority
        ChangeStoryPriority,
        // Change Story Size
        ChangeStorySize,
        // Change Story Status
        ChangeStoryStatus,
        // Change Feedback Rating
        ChangeFeedbackRating,
        // Change Feedback Status
        ChangeFeedbackStatus,
        //Add Comment to Task
        AddCommentToTask,
        //Change Assignee with new one
        ChangeAssignee,
        //List Tasks
        ListTasks,
        //List Bugs
        ListBugs,
        //List Stories
        ListStories,
        //List Feedback
        ListFeedback,
        //List Tasks with Assignee
        ListTasksWithAssignee
        

        //DOEN - Change the Priority/Severity/Status of a bug.
        //DONE Change the Priority/Size/Status of a story.
        //DONE Change the Rating/Status of a feedback
        //Assign/Unassign a task to a person. - ChangeAssignee
        //DONE - Add comment to a task
    }
}
