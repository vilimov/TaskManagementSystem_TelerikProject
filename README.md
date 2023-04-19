# ![Team 14 Logo](https://gitlab.com/team-147643914/task-managment-system_oop-teamwork/-/raw/main/OtherFiles/T14Logo.png "Team 14")
###### This project is developed by Team 14
######   **Alpha C-Sharp 47** 
- [ ] _Tsvetomila Tsenkova_ 	
- [ ] _Milko Tomov_ 	
- [ ] _Kostadin Palchev_
	
================================================

# Task Management System

## Project Description
##### Design and implement a Tasks Management console application that will help a small team of developers to organize and manage their work tasks.
<hr>

## Functional Requirements
##### The application _must_ support multiple **teams, boards, members, tasks**

<details>
<summary>Click here for full requirements of teams, boards and members</summary>
<hr>

Each **team** `must` have a name, members, and boards.<br>
• The name must be unique in the application.<br>
• The name is a string between 5 and 15 symbols.


Each **member** `must` have a name, list of tasks and activity history.<br>
• The name must be unique in the application.<br>
• The name is a string between 5 and 15 symbols.

Each **board** `must` have a name, list of tasks and activity history.<br>
• Name must be unique in the team.<br>
• Name is a string between 5 and 10 symbols.
<hr>

</details> 

##### There are 3 types of tasks: bug, story, and feedback
<details>
<summary>Click here for full requirements of bug, story, and feedback</summary>
<hr>

**Bugs** `must` have an ID, a title, a description, a list of steps to reproduce it, a priority, a
severity, a status, an assignee, a list of comments and a list of changes history.<br>
• Title is a string between 10 and 50 symbols.<br>
• Description is a string between 10 and 500 symbols.<br>
• Steps to reproduce is a list of strings.<br>
• Priority is one of the following: High, Medium, or Low.<br>
• Severity is one of the following: Critical, Major, or Minor.<br>
• Status is one of the following: Active or Fixed.<br>
• Assignee is a member from the team.<br>
• Comments is a list of comments (string messages with an author).<br>
• History is a list of all changes (string messages) that were done to the bug.


**Stories** `must` have an ID, a title, a description, a priority, a size, a status, an assignee, a 
list of comments and a list of changes history.
<br>
• Title is a string between 10 and 50 symbols.<br>
• Description is a string between 10 and 500 symbols.<br>
• Priority is one of the following: High, Medium, or Low.<br>
• Size is one of the following: Large, Medium, or Small.<br>
• Status is one of the following: Not Done, InProgress, or Done.<br>
• Assignee is a member from the team.<br>
• Comments is a list of comments (string messages with author).<br>
• History is a list of all changes (string messages) that were done to the story.


**Feedbacks** `must` have an ID, a title, a description, a rating, a status, a list of 
comments and a list of changes history.<br>
• Title is a string between 10 and 50 symbols.<br>
• Description is a string between 10 and 500 symbols.<br>
• Rating is an integer.<br>
• Status is one of the following: New, Unscheduled, Scheduled, or Done.<br>
• Comments is a list of comments (string messages with author).<br>
• History is a list of all changes (string messages) that were done to the 
feedback.
<hr>
<b>Important</b><br>
<b>Each task must have a unique ID</b>.<br>
    - For example, if there is a bug with ID = 1 then a story or feedback with ID = 1 cannot exist

</details> 

##### Operations
The application `must` support the following operations:
<details><summary>Click here for full list of operations</summary>
<hr>
• Create a new person.<br>
• Show all people.<br>
• Show person's activity.<br>
• Create a new team.<br>
• Show all teams.<br>
• Show team's activity.<br>
• Add person to team.<br>
• Show all team members.<br>
• Create a new board in a team.<br>
• Show all team boards.<br>
• Show board's activity.<br>
• Create a new Bug/Story/Feedback in a board.<br>
• Change the Priority/Severity/Status of a bug.<br>
• Change the Priority/Size/Status of a story.<br>
• Change the Rating/Status of a feedback.<br>
• Assign/Unassign a task to a person.<br>
• Add comment to a task.<br>
• Listing:<br>
o List all tasks (display the most important info).<br>
• Filter by title<br>
• Sort by title<br>
o List bugs/stories/feedback only.<br>
• Filter by status and/or assignee<br>
• Sort by title/priority/severity/size/rating (depending on the task type)<br>
o List tasks with assignee.<br>
• Filter by status and/or assignee<br>
• Sort by Title
<hr>
</details>

<hr>

### Use cases<br>

##### Use case 1<br>
> One of the developers has noticed a bug in the company’s product. He starts the 
application and goes on to create a new Task for it. He creates a new Bug and gives 
it the title "The program freezes when the Log In button is clicked." For the 
description he adds "This needs to be fixed quickly!", he marks the Bug as High 
priority and gives it Critical severity. Since it is a new bug, it gets the Active status. 
The developer also assigns it to the senior developer in the team. To be able to fix the 
bug, the senior developer needs to know how to reproduce it, so the developer who 
logged the bug adds a list of steps to reproduce: "1. Open the application; 2. Click 
"Log In"; 3. The application freezes!" The bug is saved to the application and is ready 
to be fixed.


##### Use case 2<br>
> A new developer has joined the team. One of the other developers starts the 
application and creates a new team member. After that, he adds the new team 
member to one of the existing teams and assigns all Critical bugs to him.
##### Use case 3<br>
> One of the developers has fixed a bug that was assigned to him. He adds a comment 
to that bug, saying "This one took me a while, but it is fixed now!", and then changes 
the status of the bug to Done. Just to be sure, he checks the changes history list of 
the bug and sees that the last entry in the list says, "The status of item with ID 42
switched from Active to Done."

<hr>

## Technical Requirements
<details><summary>Click here for full Technical Requirements </summary>
• Follow the OOP best practices: <br>
o Use data encapsulation.<br>
o Use inheritance and polymorphism properly.<br>
o Use interfaces and abstract classes properly.<br>
o Use static members properly.<br>
o Use enumerations properly.<br>
o Aim for strong cohesion and loose coupling.<br>
• Follow guidelines for writing clean code:<br>
o Proper naming of classes, methods, and fields.<br>
o Small classes and methods.<br>
o Well formatted and consistent code.<br>
o No duplicate code.<br>
• Implement user input validations and display meaningful messages.<br>
• Implement proper exception handling.<br>
• Prefer using LINQ when working with collections.<br>
• Cover the core functionality with unit tests (at least 80% code coverage of the models and commands).<br>
o There is no need to test the printing commands.<br>
• Use Git to keep your source code and for team collaboration.<br>
</details>
<hr>


##### With all that in mind we have created a working console application, following the rules, principles and requirements listed above. 

###### Unit test provide ...% of coverage over the project, but we also provide list of commands that would help better user experience.

test cases:

```cs
CreateTeam Team1
CreateTeam Team2
CreateMember Member1
CreateMember Member2
CreateMember Member3
CreateMember Member4
AddMemberToTeam Member1 Team1
AddMemberToTeam Member2 Team1
AddMemberToTeam Member3 Team1
AddMemberToTeam Member4 Team1
AddMemberToTeam Member1 Team2
AddMemberToTeam Member2 Team2
CreateBoard Board1 Team1
CreateBoard Board2 Team2
CreateBoard Board2 Team1
CreateBug  Bug_Name_1 Bug_Description_1 Board1 High Critical Member1 <<StepsToReproduce>>
CreateBug <<The prg freezes when the Log In button is clicked.>> <<This needs to be fixed quickly!>> Board1 High Critical Member1 <<1. Open the application; 2.Click "Log In"; 3. The application freezes!>>
CreateFeedback FeedbackTitle FeedbackDescription 1 Board1
CreateStory newStory_1 Description1 Board1 Low Small Done Member1
CreateStory newStory_2 Description2 Board2 Medium Medium Done Member2
CreateStory newStory_1 Description1 Board1 Low Small Member1
ShowBoardsActivity Board1
ShowMembersActivity Member1
ShowMembers
ShowTeamBoards Team1
ShowTeamMembers Team1
ShowTeamsActivity Team1
ShowTeams
```


reult cases:

```cs
CreateTeam Team1
...
CreateTeam Team2
...
CreateMember Member1
CreateMember Member2
CreateMember Member3
CreateMember Member4
AddMemberToTeam Member1 Team1
AddMemberToTeam Member2 Team1
AddMemberToTeam Member3 Team1
AddMemberToTeam Member4 Team1
AddMemberToTeam Member1 Team2
AddMemberToTeam Member2 Team2
CreateBoard Board1 Team1
CreateBoard Board2 Team2
CreateBoard Board2 Team1
CreateBug  Bug_Name_1 Bug_Description_1 Board1 High Critical Member1 <<StepsToReproduce>>
CreateBug <<The prg freezes when the Log In button is clicked.>> <<This needs to be fixed quickly!>> Board1 High Critical Member1 <<1. Open the application; 2.Click "Log In"; 3. The application freezes!>>
CreateFeedback FeedbackTitle FeedbackDescription 1 Board1
CreateStory newStory_1 Description1 Board1 Low Small Done Member1
CreateStory newStory_2 Description2 Board2 Medium Medium Done Member2
CreateStory newStory_1 Description1 Board1 Low Small Member1
ShowBoardsActivity Board1
ShowMembersActivity Member1
ShowMembers
ShowTeamBoards Team1
ShowTeamMembers Team1
ShowTeamsActivity Team1
ShowTeams
```
