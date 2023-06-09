DROP DATABASE [ProjectManagement]
CREATE DATABASE [ProjectManagement]
CONTAINMENT = NONE
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProjectManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProjectManagement]
GO
/****** Object:  Table [dbo].[Audit]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audit](
	[audit_id] [int] IDENTITY(1,1) NOT NULL,
	[timestamp] [datetime] NULL CONSTRAINT [DF_Audit_timestamp]  DEFAULT (getdate()),
	[change_type] [nvarchar](50) NULL,
	[table_name] [nvarchar](50) NULL,
	[record_id] [int] NULL,
	[old_value] [nvarchar](max) NULL,
	[current_value] [nvarchar](max) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED 
(
	[audit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[comment_timestamp] [datetime] NULL CONSTRAINT [DF_Comment_comment_timestamp]  DEFAULT (getdate()),
	[comment_text] [nvarchar](1000) NULL,
	[user_id] [int] NULL,
	[task_id] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Document]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[document_id] [int] IDENTITY(1,1) NOT NULL,
	[document_name] [nvarchar](100) NULL,
	[upload_time] [datetime] NULL CONSTRAINT [DF_Document_upload_time]  DEFAULT (getdate()),
	[path] [nvarchar](max) NULL,
	[type_id] [int] NULL,
	[user_id] [int] NULL,
	[task_id] [int] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[document_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentType](
	[documentType_id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[documentType_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[log_id] [int] IDENTITY(1,1) NOT NULL,
	[source] [nvarchar](50) NULL,
	[exception] [nvarchar](max) NULL,
	[timestamp] [datetime] NULL CONSTRAINT [DF_Log_timestamp]  DEFAULT (getdate()),
	[user_id] [int] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notification]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[notification_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[message] [nvarchar](500) NULL,
	[status] [nvarchar](50) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[notification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[project_id] [int] IDENTITY(1,1) NOT NULL,
	[project_name] [nvarchar](100) NULL,
	[description] [nvarchar](1000) NULL,
	[project_manager_id] [int] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[project_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProjectMember]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectMember](
	[project_member_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[project_id] [int] NULL,
 CONSTRAINT [PK_ProjectMember] PRIMARY KEY CLUSTERED 
(
	[project_member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Task]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[task_id] [int] IDENTITY(1,1) NOT NULL,
	[task_name] [nvarchar](100) NULL,
	[description] [nvarchar](1000) NULL,
	[assign_date] [datetime] NULL CONSTRAINT [DF_Task_assign_date]  DEFAULT (getdate()),
	[deadline] [datetime] NULL,
	[status_id] [int] NULL,
	[project_id] [int] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[task_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[taskStatus_id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](50) NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_TaskStatus] PRIMARY KEY CLUSTERED 
(
	[taskStatus_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 6/3/2023 11:56:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](150) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Audit] ON 

INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (1, CAST(N'2023-06-03 18:21:35.673' AS DateTime), N'Create', N'Project', 1, NULL, N'{"ProjectId":1,"ProjectName":"Computer Programming 2 Final Project","Description":"Creating an interactive GUI application with JAVA elements integrated. ","ProjectManagerId":14,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (2, CAST(N'2023-06-03 18:21:52.523' AS DateTime), N'Create', N'ProjectMember', 2, NULL, N'{"ProjectMemberId":2,"UserId":16,"ProjectId":1,"Project":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (3, CAST(N'2023-06-03 18:22:25.040' AS DateTime), N'Create', N'ProjectMember', 3, NULL, N'{"ProjectMemberId":3,"UserId":17,"ProjectId":1,"Project":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (4, CAST(N'2023-06-03 18:25:10.107' AS DateTime), N'Create', N'Task', 1, NULL, N'{"TaskId":1,"TaskName":"Creating the buttons","Description":"Integrating the buttons into the application","AssignDate":"2023-06-03T18:25:10.093","Deadline":"2023-06-04T23:59:00","StatusId":2,"ProjectId":1,"UserId":14,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (5, CAST(N'2023-06-03 18:27:18.070' AS DateTime), N'Create', N'Task', 2, NULL, N'{"TaskId":2,"TaskName":"Making the buttons functional","Description":"Writing code under the buttons to add functionality to them","AssignDate":"2023-06-03T18:27:18.067","Deadline":"2023-03-06T23:59:00","StatusId":1,"ProjectId":1,"UserId":16,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (6, CAST(N'2023-06-03 18:29:03.477' AS DateTime), N'Create', N'Task', 3, NULL, N'{"TaskId":3,"TaskName":"Implementing the form","Description":"Adding the form to the application and filling it with data","AssignDate":"2023-06-03T18:29:03.473","Deadline":"2023-06-04T23:55:00","StatusId":3,"ProjectId":1,"UserId":17,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (7, CAST(N'2023-06-03 18:29:51.750' AS DateTime), N'Create', N'Comments', 1, NULL, N'{"CommentId":1,"CommentTimestamp":"2023-06-03T18:29:51.747","CommentText":"Trying to decide which style buttons would suit our application","UserId":14,"TaskId":1,"Task":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (8, CAST(N'2023-06-03 18:30:57.123' AS DateTime), N'Create', N'Comments', 2, NULL, N'{"CommentId":2,"CommentTimestamp":"2023-06-03T18:30:57.12","CommentText":"Currently deciding an appropriate place to keep these buttons on the application","UserId":14,"TaskId":1,"Task":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (9, CAST(N'2023-06-03 18:32:34.500' AS DateTime), N'Create', N'Comments', 3, NULL, N'{"CommentId":3,"CommentTimestamp":"2023-06-03T18:32:34.5","CommentText":"Filling the form with data was easy! It was done in less than 10 minutes.","UserId":17,"TaskId":3,"Task":null,"User":null}', 17)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (10, CAST(N'2023-06-03 18:34:45.530' AS DateTime), N'Create', N'Comments', 4, NULL, N'{"CommentId":4,"CommentTimestamp":"2023-06-03T18:34:45.527","CommentText":"Trying to come up with efficient code to add some functionality to these buttons. ","UserId":16,"TaskId":2,"Task":null,"User":null}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (11, CAST(N'2023-06-03 18:35:08.477' AS DateTime), N'Create', N'Comments', 5, NULL, N'{"CommentId":5,"CommentTimestamp":"2023-06-03T18:35:08.477","CommentText":"Need to remember to add comments after I am done. ","UserId":16,"TaskId":2,"Task":null,"User":null}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (12, CAST(N'2023-06-03 18:37:33.297' AS DateTime), N'Create', N'Project', 2, NULL, N'{"ProjectId":2,"ProjectName":"Project CloudSwirl","Description":"CloudSwirl is a cloud-based platform that provides a centralized hub for managing multi-cloud environments. With CloudSwirl, users can easily deploy, manage, and monitor resources across multiple cloud providers, such as Amazon Web Services, Google Cloud Platform, and Microsoft Azure.","ProjectManagerId":14,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (13, CAST(N'2023-06-03 18:38:01.747' AS DateTime), N'Edit', N'Project', 1, NULL, N'{"ProjectId":1,"ProjectName":"Computer Programming 2 Final Project","Description":"Creating an interactive GUI application with JAVA elements integrated. ","ProjectManagerId":14,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (14, CAST(N'2023-06-03 18:38:16.620' AS DateTime), N'Create', N'ProjectMember', 5, NULL, N'{"ProjectMemberId":5,"UserId":18,"ProjectId":2,"Project":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (15, CAST(N'2023-06-03 18:40:32.220' AS DateTime), N'Create', N'Task', 4, NULL, N'{"TaskId":4,"TaskName":"Market Research","Description":"Conduct market research to identify potential customers and their needs for managing multi-cloud environments.","AssignDate":"2023-06-03T18:40:32.217","Deadline":"2023-10-06T23:59:00","StatusId":3,"ProjectId":2,"UserId":14,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (16, CAST(N'2023-06-03 18:42:03.050' AS DateTime), N'Create', N'Task', 5, NULL, N'{"TaskId":5,"TaskName":"Interface Development","Description":"Develop a user-friendly interface and intuitive dashboards for CloudSwirl.","AssignDate":"2023-06-03T18:42:03.047","Deadline":"2023-06-12T23:59:00","StatusId":2,"ProjectId":2,"UserId":18,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (17, CAST(N'2023-06-03 18:42:20.040' AS DateTime), N'Edit', N'Tasks', 5, NULL, N'{"TaskId":5,"TaskName":"Interface Development","Description":"Develop a user-friendly interface and intuitive dashboards for CloudSwirl.","AssignDate":"2023-06-03T18:42:03.047","Deadline":"2023-06-12T23:59:00","StatusId":2,"ProjectId":2,"UserId":18,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (18, CAST(N'2023-06-03 18:42:31.530' AS DateTime), N'Edit', N'Tasks', 4, NULL, N'{"TaskId":4,"TaskName":"Market Research","Description":"Conduct market research to identify potential customers and their needs for managing multi-cloud environments.","AssignDate":"2023-06-03T18:40:32.217","Deadline":"2023-06-10T23:59:00","StatusId":3,"ProjectId":2,"UserId":14,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (19, CAST(N'2023-06-03 18:43:53.400' AS DateTime), N'Create', N'Task', 6, NULL, N'{"TaskId":6,"TaskName":"Automation","Description":"Build automation capabilities for deploying and managing resources across multiple cloud providers.","AssignDate":"2023-06-03T18:43:53.397","Deadline":"2023-06-15T23:59:00","StatusId":1,"ProjectId":2,"UserId":18,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (20, CAST(N'2023-06-03 18:45:11.020' AS DateTime), N'Create', N'Comments', 6, NULL, N'{"CommentId":6,"CommentTimestamp":"2023-06-03T18:45:11.017","CommentText":"It was loads of fun conducting the market research! Can''t wait to do more in the future","UserId":14,"TaskId":4,"Task":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (21, CAST(N'2023-06-03 18:46:53.770' AS DateTime), N'Create', N'Comments', 7, NULL, N'{"CommentId":7,"CommentTimestamp":"2023-06-03T18:46:53.767","CommentText":"I am eager to see the final product!!","UserId":14,"TaskId":5,"Task":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (22, CAST(N'2023-06-03 18:46:59.707' AS DateTime), N'Edit', N'Comments', 7, NULL, N'{"CommentId":7,"CommentTimestamp":"2023-06-03T18:46:53.767","CommentText":"I am eager to see the final product!","UserId":14,"TaskId":5,"Task":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (23, CAST(N'2023-06-03 18:48:50.483' AS DateTime), N'Create', N'Comments', 8, NULL, N'{"CommentId":8,"CommentTimestamp":"2023-06-03T18:48:50.48","CommentText":"Coming up with ways to fully automate the process isn''t particularly easy. ","UserId":18,"TaskId":6,"Task":null,"User":null}', 18)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (24, CAST(N'2023-06-03 18:50:55.540' AS DateTime), N'Edit', N'Project', 2, NULL, N'{"ProjectId":2,"ProjectName":"CloudSwirl","Description":"CloudSwirl is a cloud-based platform that provides a centralized hub for managing multi-cloud environments. With CloudSwirl, users can easily deploy, manage, and monitor resources across multiple cloud providers, such as Amazon Web Services, Google Cloud Platform, and Microsoft Azure.","ProjectManagerId":14,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (25, CAST(N'2023-06-03 18:51:34.253' AS DateTime), N'Edit', N'Project', 1, NULL, N'{"ProjectId":1,"ProjectName":"EcoMinds","Description":"EcoMinds is a mobile app that helps individuals and organizations reduce their carbon footprint and contribute to a sustainable future. The app offers a range of features, including a carbon calculator that helps users understand their personal carbon footprint, tips and suggestions for reducing carbon emissions, and a social platform where users can connect with others and share their sustainability efforts","ProjectManagerId":14,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (26, CAST(N'2023-06-03 18:54:30.223' AS DateTime), N'Edit', N'Tasks', 1, NULL, N'{"TaskId":1,"TaskName":"Carbon calculator feature","Description":"Build a carbon calculator feature that accurately calculates a user''s carbon footprint based on their activities and lifestyle.","AssignDate":"2023-06-03T18:25:10.093","Deadline":"2023-06-04T23:59:00","StatusId":2,"ProjectId":1,"UserId":14,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (27, CAST(N'2023-06-03 18:54:53.633' AS DateTime), N'Edit', N'Tasks', 3, NULL, N'{"TaskId":3,"TaskName":"Database Creation","Description":"Create a database of sustainability tips and suggestions, and integrate them into the app in a way that is easy for users to access and implement.","AssignDate":"2023-06-03T18:29:03.473","Deadline":"2023-06-04T23:55:00","StatusId":3,"ProjectId":1,"UserId":17,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (28, CAST(N'2023-06-03 18:55:26.200' AS DateTime), N'Edit', N'Tasks', 2, NULL, N'{"TaskId":2,"TaskName":"Social platform feature","Description":"Develop a social platform feature that allows users to connect with others and share their sustainability efforts, as well as a system for incentivizing users to engage with the platform and contribute to the community.","AssignDate":"2023-06-03T18:27:18.067","Deadline":"2023-03-06T23:59:00","StatusId":1,"ProjectId":1,"UserId":16,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (29, CAST(N'2023-06-03 18:58:48.283' AS DateTime), N'Delete', N'Comments', 2, N'{"CommentId":2,"CommentTimestamp":"2023-06-03T18:30:57.12","CommentText":"Currently deciding an appropriate place to keep these buttons on the application","UserId":14,"TaskId":1,"Task":null,"User":null}', NULL, 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (30, CAST(N'2023-06-03 18:58:50.700' AS DateTime), N'Delete', N'Comments', 1, N'{"CommentId":1,"CommentTimestamp":"2023-06-03T18:29:51.747","CommentText":"Trying to decide which style buttons would suit our application","UserId":14,"TaskId":1,"Task":null,"User":null}', NULL, 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (32, CAST(N'2023-06-03 19:03:10.847' AS DateTime), N'Create', N'Comments', 9, NULL, N'{"CommentId":9,"CommentTimestamp":"2023-06-03T19:03:10.843","CommentText":"I believe this feature would really be beneficial to our project","UserId":14,"TaskId":1,"Task":null,"User":null}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (33, CAST(N'2023-06-03 19:05:37.090' AS DateTime), N'Delete', N'Comments', 5, N'{"CommentId":5,"CommentTimestamp":"2023-06-03T18:35:08.477","CommentText":"Need to remember to add comments after I am done. ","UserId":16,"TaskId":2,"Task":null,"User":null}', NULL, 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (34, CAST(N'2023-06-03 19:05:38.510' AS DateTime), N'Delete', N'Comments', 4, N'{"CommentId":4,"CommentTimestamp":"2023-06-03T18:34:45.527","CommentText":"Trying to come up with efficient code to add some functionality to these buttons. ","UserId":16,"TaskId":2,"Task":null,"User":null}', NULL, 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (35, CAST(N'2023-06-03 19:06:42.880' AS DateTime), N'Create', N'Comments', 10, NULL, N'{"CommentId":10,"CommentTimestamp":"2023-06-03T19:06:42.88","CommentText":"I believe users communicating with each other within the app would be essential for the success of our project!","UserId":16,"TaskId":2,"Task":null,"User":null}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (36, CAST(N'2023-06-03 19:08:47.810' AS DateTime), N'Create', N'Project', 3, NULL, N'{"ProjectId":3,"ProjectName":"FitBuddy","Description":"FitBuddy is a wearable device and accompanying mobile app that helps individuals achieve their fitness goals by tracking their physical activity, monitoring their health metrics, and providing personalized coaching and motivation. The device can be worn on the wrist or attached to clothing, and uses sensors to track steps, distance, calories burned, and other metrics. The app provides real-time feedback on activity levels, as well as insights into sleep quality, heart rate, and other health metrics. ","ProjectManagerId":16,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (37, CAST(N'2023-06-03 19:09:32.080' AS DateTime), N'Create', N'ProjectMember', 7, NULL, N'{"ProjectMemberId":7,"UserId":18,"ProjectId":3,"Project":null,"User":null}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (38, CAST(N'2023-06-03 19:09:38.507' AS DateTime), N'Create', N'ProjectMember', 8, NULL, N'{"ProjectMemberId":8,"UserId":17,"ProjectId":3,"Project":null,"User":null}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (39, CAST(N'2023-06-03 19:14:50.430' AS DateTime), N'Create', N'Task', 7, NULL, N'{"TaskId":7,"TaskName":"Develop Partnerships","Description":" Develop partnerships with fitness studios, gyms, and other health and wellness organizations to promote the FitBuddy device and app as a tool for achieving fitness goals and improving overall health.","AssignDate":"2023-06-03T19:14:50.427","Deadline":"2023-06-20T23:59:00","StatusId":2,"ProjectId":3,"UserId":16,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (40, CAST(N'2023-06-03 19:16:47.880' AS DateTime), N'Create', N'Task', 8, NULL, N'{"TaskId":8,"TaskName":"User Data Collection","Description":"Collect and analyze user data to continuously improve the device and app, as well as to develop new products and services that meet the evolving needs of the fitness and health tracking market.","AssignDate":"2023-06-03T19:16:47.877","Deadline":"2023-06-21T23:59:00","StatusId":1,"ProjectId":3,"UserId":17,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (41, CAST(N'2023-06-03 19:18:38.640' AS DateTime), N'Create', N'Task', 9, NULL, N'{"TaskId":9,"TaskName":"Marketing and Sales Strategy","Description":"Develop a marketing and sales strategy for promoting the device and app to potential customers, including social media advertising, influencer marketing, and other channels.","AssignDate":"2023-06-03T19:18:38.637","Deadline":"2023-06-25T23:59:00","StatusId":2,"ProjectId":3,"UserId":18,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (42, CAST(N'2023-06-03 19:20:02.523' AS DateTime), N'Create', N'Comments', 11, NULL, N'{"CommentId":11,"CommentTimestamp":"2023-06-03T19:20:02.523","CommentText":"Communicating with these sponsors was super fun! ","UserId":16,"TaskId":7,"Task":null,"User":null}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (43, CAST(N'2023-06-03 19:22:45.960' AS DateTime), N'Create', N'Comments', 12, NULL, N'{"CommentId":12,"CommentTimestamp":"2023-06-03T19:22:45.957","CommentText":"Need to start on this soon!","UserId":17,"TaskId":8,"Task":null,"User":null}', 17)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (44, CAST(N'2023-06-03 19:37:26.063' AS DateTime), N'Delete', N'Comments', 6, N'{"CommentId":6,"CommentTimestamp":"2023-06-03T18:45:11.017","CommentText":"It was loads of fun conducting the market research! Can''t wait to do more in the future","UserId":14,"TaskId":4,"Task":null,"User":null}', NULL, 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (46, CAST(N'2023-06-03 19:41:50.303' AS DateTime), N'Delete', N'ProjectMember', 7, N'{"ProjectMemberId":7,"UserId":18,"ProjectId":3,"Project":null,"User":null}', NULL, 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (47, CAST(N'2023-06-03 19:41:53.850' AS DateTime), N'Create', N'ProjectMember', 9, NULL, N'{"ProjectMemberId":9,"UserId":14,"ProjectId":3,"Project":null,"User":null}', 16)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (48, CAST(N'2023-06-03 19:45:30.330' AS DateTime), N'Create', N'Project', 4, NULL, N'{"ProjectId":4,"ProjectName":"Web Design","Description":"A university project to design a new website for the course IT8140","ProjectManagerId":17,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 17)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (49, CAST(N'2023-06-03 19:48:38.157' AS DateTime), N'Create', N'Project', 5, NULL, N'{"ProjectId":5,"ProjectName":"SmartGrid","Description":"SmartGrid is an innovative engineering project aimed at developing a smart energy grid system. The project involves designing and implementing a network of intelligent devices and sensors that can monitor power usage, identify inefficiencies, and optimize energy distribution. SmartGrid leverages advanced technologies such as machine learning, artificial intelligence, and data analytics to provide real-time insights into energy consumption patterns and enable more efficient and sustainable power management. The system is designed to be scalable and adaptable, allowing it to be deployed in a variety of settings, from small residential communities to large industrial complexes. SmartGrid has the potential to revolutionize the way we generate, distribute, and consume energy, and contribute to a more sustainable future.","ProjectManagerId":18,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 18)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (50, CAST(N'2023-06-03 23:52:53.370' AS DateTime), N'Edit', N'Project', 2, N'{"ProjectId":2,"ProjectName":"CloudSwirl","Description":"CloudSwirl is a cloud-based platform that provides a centralized hub for managing multi-cloud environments. With CloudSwirl, users can easily deploy, manage, and monitor resources across multiple cloud providers, such as Amazon Web Services, Google Cloud Platform, and Microsoft Azure.","ProjectManagerId":14,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', N'{"ProjectId":2,"ProjectName":"CloudSwirls","Description":"CloudSwirl is a cloud-based platform that provides a centralized hub for managing multi-cloud environments. With CloudSwirl, users can easily deploy, manage, and monitor resources across multiple cloud providers, such as Amazon Web Services, Google Cloud Platform, and Microsoft Azure.","ProjectManagerId":14,"ProjectManager":null,"ProjectMembers":[],"Tasks":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (51, CAST(N'2023-06-03 23:53:07.980' AS DateTime), N'Edit', N'Tasks', 4, N'{"TaskId":4,"TaskName":"Market Research","Description":"Conduct market research to identify potential customers and their needs for managing multi-cloud environments.","AssignDate":"2023-06-03T18:40:32.217","Deadline":"2023-06-10T23:59:00","StatusId":3,"ProjectId":2,"UserId":14,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', N'{"TaskId":4,"TaskName":"Market Research","Description":"Conduct market research to identify potential customers and their needs for managing multi-cloud environments.","AssignDate":"2023-06-03T18:40:32.217","Deadline":"2023-06-22T23:59:00","StatusId":3,"ProjectId":2,"UserId":14,"Project":null,"Status":null,"User":null,"Comments":[],"Documents":[]}', 14)
INSERT [dbo].[Audit] ([audit_id], [timestamp], [change_type], [table_name], [record_id], [old_value], [current_value], [user_id]) VALUES (52, CAST(N'2023-06-03 23:53:29.833' AS DateTime), N'Status Update', N'Tasks', 6, N'1', N'2', 14)
SET IDENTITY_INSERT [dbo].[Audit] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([comment_id], [comment_timestamp], [comment_text], [user_id], [task_id]) VALUES (3, CAST(N'2023-06-03 18:32:34.500' AS DateTime), N'Finished a crucial task for our precious project!', 17, 3)
INSERT [dbo].[Comment] ([comment_id], [comment_timestamp], [comment_text], [user_id], [task_id]) VALUES (7, CAST(N'2023-06-03 18:46:53.767' AS DateTime), N'I am eager to see the final product!', 14, 5)
INSERT [dbo].[Comment] ([comment_id], [comment_timestamp], [comment_text], [user_id], [task_id]) VALUES (8, CAST(N'2023-06-03 18:48:50.480' AS DateTime), N'Coming up with ways to fully automate the process isn''t particularly easy. ', 18, 6)
INSERT [dbo].[Comment] ([comment_id], [comment_timestamp], [comment_text], [user_id], [task_id]) VALUES (9, CAST(N'2023-06-03 19:03:10.843' AS DateTime), N'I believe this feature would really be beneficial to our project', 14, 1)
INSERT [dbo].[Comment] ([comment_id], [comment_timestamp], [comment_text], [user_id], [task_id]) VALUES (10, CAST(N'2023-06-03 19:06:42.880' AS DateTime), N'I believe users communicating with each other within the app would be essential for the success of our project!', 16, 2)
INSERT [dbo].[Comment] ([comment_id], [comment_timestamp], [comment_text], [user_id], [task_id]) VALUES (11, CAST(N'2023-06-03 19:20:02.523' AS DateTime), N'Communicating with these sponsors was super fun! ', 16, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_timestamp], [comment_text], [user_id], [task_id]) VALUES (12, CAST(N'2023-06-03 19:22:45.957' AS DateTime), N'Need to start on this soon!', 17, 8)
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Document] ON 

INSERT [dbo].[Document] ([document_id], [document_name], [upload_time], [path], [type_id], [user_id], [task_id]) VALUES (1, N'ERD', CAST(N'2023-06-03 23:47:09.680' AS DateTime), N'UploadedFiles\AP_ERD.png', 4, 14, 6)
INSERT [dbo].[Document] ([document_id], [document_name], [upload_time], [path], [type_id], [user_id], [task_id]) VALUES (3, N'DB Script', CAST(N'2023-06-03 23:49:05.247' AS DateTime), N'UploadedFiles\ProjectManagement - With sample data.sql', 3, 16, 9)
INSERT [dbo].[Document] ([document_id], [document_name], [upload_time], [path], [type_id], [user_id], [task_id]) VALUES (4, N'Identity script', CAST(N'2023-06-03 23:50:15.383' AS DateTime), N'UploadedFiles\PMIdentity - With sample user.sql', 3, 14, 2)
SET IDENTITY_INSERT [dbo].[Document] OFF
SET IDENTITY_INSERT [dbo].[DocumentType] ON 

INSERT [dbo].[DocumentType] ([documentType_id], [type], [description]) VALUES (1, N'PDF', NULL)
INSERT [dbo].[DocumentType] ([documentType_id], [type], [description]) VALUES (2, N'Word', NULL)
INSERT [dbo].[DocumentType] ([documentType_id], [type], [description]) VALUES (3, N'Text', NULL)
INSERT [dbo].[DocumentType] ([documentType_id], [type], [description]) VALUES (4, N'Image', NULL)
INSERT [dbo].[DocumentType] ([documentType_id], [type], [description]) VALUES (5, N'Video', NULL)
INSERT [dbo].[DocumentType] ([documentType_id], [type], [description]) VALUES (6, N'Audio', NULL)
INSERT [dbo].[DocumentType] ([documentType_id], [type], [description]) VALUES (7, N'Compressed', NULL)
INSERT [dbo].[DocumentType] ([documentType_id], [type], [description]) VALUES (8, N'Other', NULL)
SET IDENTITY_INSERT [dbo].[DocumentType] OFF
SET IDENTITY_INSERT [dbo].[Log] ON 

INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (1, N'Windows Forms', N'System.InvalidOperationException: An exception was thrown while attempting to evaluate a LINQ query parameter expression. See the inner exception for more information. To show additional information call ''DbContextOptionsBuilder.EnableSensitiveDataLogging''.
 ---> System.NullReferenceException: Object reference not set to an instance of an object.
   at lambda_method247(Closure )
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.GetValue(Expression expression, String& parameterName)
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.GetValue(Expression expression, String& parameterName)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.Evaluate(Expression expression, Boolean generateParameter)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.Visit(Expression expression)
   at System.Linq.Expressions.ExpressionVisitor.VisitBinary(BinaryExpression node)
   at System.Linq.Expressions.BinaryExpression.Accept(ExpressionVisitor visitor)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.Visit(Expression expression)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.VisitBinary(BinaryExpression binaryExpression)
   at System.Linq.Expressions.BinaryExpression.Accept(ExpressionVisitor visitor)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.Visit(Expression expression)
   at System.Linq.Expressions.ExpressionVisitor.VisitLambda[T](Expression`1 node)
   at System.Linq.Expressions.Expression`1.Accept(ExpressionVisitor visitor)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.Visit(Expression expression)
   at System.Linq.Expressions.ExpressionVisitor.VisitUnary(UnaryExpression node)
   at System.Linq.Expressions.UnaryExpression.Accept(ExpressionVisitor visitor)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.Visit(Expression expression)
   at System.Dynamic.Utils.ExpressionVisitorUtils.VisitArguments(ExpressionVisitor visitor, IArgumentProvider nodes)
   at System.Linq.Expressions.ExpressionVisitor.VisitMethodCall(MethodCallExpression node)
   at System.Linq.Expressions.MethodCallExpression.Accept(ExpressionVisitor visitor)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.Visit(Expression expression)
   at Microsoft.EntityFrameworkCore.Query.Internal.ParameterExtractingExpressionVisitor.ExtractParameters(Expression expression, Boolean clearEvaluatedValues)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.Execute[TResult](Expression query)
   at System.Linq.Queryable.Any[TSource](IQueryable`1 source, Expression`1 predicate)
   at ProjectForms.AddMembersForm.btnSave_Click(Object sender, EventArgs e) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectForms\AddMembersForm.cs:line 81', CAST(N'2023-06-01 21:08:21.110' AS DateTime), 18)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (2, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:05:43.400' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (3, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:06:40.573' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (4, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:09:18.503' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (5, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:10:10.740' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (6, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:11:15.140' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (7, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:13:05.753' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (8, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:17:09.220' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (9, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:17:46.230' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (10, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:20:29.537' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (11, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:24:02.997' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (12, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:25:29.260' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (13, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 196', CAST(N'2023-06-03 02:29:23.307' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (14, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.Task''. Path ''Project.Tasks''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.Task.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\Task.cs:line 55
   at ProjectManagement.Controllers.TasksController.Edit(Nullable`1 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 168', CAST(N'2023-06-03 02:36:42.183' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (15, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.Task''. Path ''Project.Tasks''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.Task.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\Task.cs:line 55
   at ProjectManagement.Controllers.TasksController.Edit(Nullable`1 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 168', CAST(N'2023-06-03 02:37:39.440' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (16, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:45:16.007' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (17, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:45:21.677' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (18, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:45:24.787' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (19, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:45:34.090' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (20, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:45:37.813' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (21, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:47:50.400' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (22, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:47:52.477' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (23, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:47:53.090' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (24, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:47:53.300' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (25, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:47:53.467' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (26, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:47:53.653' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (27, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:47:53.847' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (28, N'Microsoft.Data.SqlClient', N'System.InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.ValidateConnectionForExecute(SqlCommand command)
   at Microsoft.Data.SqlClient.SqlCommand.ValidateCommand(Boolean isAsync, String method)
   at Microsoft.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry, String method)
   at Microsoft.Data.SqlClient.SqlCommand.ExecuteReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.RemoveRange(IEnumerable`1 entities)
   at ProjectManagement.Controllers.ProjectsController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 228', CAST(N'2023-06-03 04:47:56.210' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (29, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 204', CAST(N'2023-06-03 05:00:53.080' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (30, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 204', CAST(N'2023-06-03 05:03:31.037' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (31, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 204', CAST(N'2023-06-03 05:07:10.883' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (32, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 204', CAST(N'2023-06-03 05:08:11.707' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (33, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 204', CAST(N'2023-06-03 05:08:47.510' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (34, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.Task''. Path ''Project.Tasks''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.Task.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\Task.cs:line 55
   at ProjectManagement.Controllers.TasksController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 384', CAST(N'2023-06-03 05:18:07.467' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (35, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.Task''. Path ''Project.Tasks''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.Task.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\Task.cs:line 55
   at ProjectManagement.Controllers.TasksController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 384', CAST(N'2023-06-03 05:18:10.647' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (36, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.Task''. Path ''Project.Tasks''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.Task.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\Task.cs:line 55
   at ProjectManagement.Controllers.TasksController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 384', CAST(N'2023-06-03 05:18:46.990' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (37, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.Task''. Path ''Project.Tasks''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.Task.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\Task.cs:line 55
   at ProjectManagement.Controllers.TasksController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 383', CAST(N'2023-06-03 05:20:38.607' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (38, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.Task''. Path ''Project.Tasks''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.Task.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\Task.cs:line 55
   at ProjectManagement.Controllers.TasksController.DeleteConfirmed(Int32 id) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 383', CAST(N'2023-06-03 05:20:49.230' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (39, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 177', CAST(N'2023-06-03 05:32:59.030' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (40, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 177', CAST(N'2023-06-03 05:33:09.173' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (41, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 177', CAST(N'2023-06-03 05:33:45.160' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (42, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 177', CAST(N'2023-06-03 05:34:22.617' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (43, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 177', CAST(N'2023-06-03 05:34:29.847' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (44, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 179', CAST(N'2023-06-03 05:35:35.277' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (45, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 179', CAST(N'2023-06-03 05:35:53.593' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (46, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 179', CAST(N'2023-06-03 05:36:44.027' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (47, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 179', CAST(N'2023-06-03 05:37:53.190' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (48, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 179', CAST(N'2023-06-03 05:38:51.560' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (49, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Project'' cannot be tracked because another instance with the same key value for {''ProjectId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.ProjectsController.Edit(Int32 id, Project project) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectsController.cs:line 179', CAST(N'2023-06-03 05:40:04.740' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (50, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.ProjectMember''. Path ''Project.ProjectMembers''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.ProjectMember.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\ProjectMember.cs:line 29
   at ProjectManagement.Controllers.ProjectMembersController.Create(ProjectMember projectMember) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectMembersController.cs:line 81', CAST(N'2023-06-03 05:44:19.550' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (51, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.ProjectMember''. Path ''Project.ProjectMembers''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.ProjectMember.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\ProjectMember.cs:line 29
   at ProjectManagement.Controllers.ProjectMembersController.Create(ProjectMember projectMember) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectMembersController.cs:line 81', CAST(N'2023-06-03 05:44:54.373' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (52, N'Newtonsoft.Json', N'Newtonsoft.Json.JsonSerializationException: Self referencing loop detected with type ''ProjectManagementBusinessObjects.ProjectMember''. Path ''Project.ProjectMembers''.
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.CheckForCircularReference(JsonWriter writer, Object value, JsonProperty property, JsonContract contract, JsonContainerContract containerContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeList(JsonWriter writer, IEnumerable values, JsonArrayContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.SerializeObject(JsonWriter writer, Object value, JsonObjectContract contract, JsonProperty member, JsonContainerContract collectionContract, JsonProperty containerProperty)
   at Newtonsoft.Json.Serialization.JsonSerializerInternalWriter.Serialize(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonSerializer.SerializeInternal(JsonWriter jsonWriter, Object value, Type objectType)
   at Newtonsoft.Json.JsonConvert.SerializeObjectInternal(Object value, Type type, JsonSerializer jsonSerializer)
   at ProjectManagementBusinessObjects.ProjectMember.ToString() in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagementBusinessObjects\ProjectMember.cs:line 29
   at ProjectManagement.Controllers.ProjectMembersController.Create(ProjectMember projectMember) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\ProjectMembersController.cs:line 81', CAST(N'2023-06-03 05:46:29.107' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (53, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Comment'' cannot be tracked because another instance with the same key value for {''CommentId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.CommentsController.Edit(Int32 id, Comment comment) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\CommentsController.cs:line 160', CAST(N'2023-06-03 05:54:12.587' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (54, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Comment'' cannot be tracked because another instance with the same key value for {''CommentId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.CommentsController.Edit(Int32 id, Comment comment) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\CommentsController.cs:line 160', CAST(N'2023-06-03 05:54:47.310' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (55, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Task'' cannot be tracked because another instance with the same key value for {''TaskId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.Update(TEntity entity)
   at ProjectManagement.Controllers.TasksController.Edit(Int32 id, Task task) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\TasksController.cs:line 211', CAST(N'2023-06-03 05:57:44.093' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (56, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Comment'' cannot be tracked because another instance with the same key value for {''CommentId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.CommentsController.Edit(Int32 id, Comment comment) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\CommentsController.cs:line 163', CAST(N'2023-06-03 15:06:13.723' AS DateTime), 18)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (57, N'Microsoft.EntityFrameworkCore', N'System.InvalidOperationException: The instance of entity type ''Comment'' cannot be tracked because another instance with the same key value for {''CommentId''} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using ''DbContextOptionsBuilder.EnableSensitiveDataLogging'' to see the conflicting key values.
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.ThrowIdentityConflict(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.IdentityMap`1.Add(TKey key, InternalEntityEntry entry, Boolean updateDuplicate)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.StartTracking(InternalEntityEntry entry)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.InternalEntityEntry.SetEntityState(EntityState oldState, EntityState newState, Boolean acceptChanges, Boolean modifyProperties)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.PaintAction(EntityEntryGraphNode`1 node)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityEntryGraphIterator.TraverseGraph[TState](EntityEntryGraphNode`1 node, Func`2 handleNode)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.EntityGraphAttacher.AttachGraph(InternalEntityEntry rootEntry, EntityState targetState, EntityState storeGeneratedWithKeySetTargetState, Boolean forceStateWhenUnknownKey)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState(InternalEntityEntry entry, EntityState entityState)
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState)
   at ProjectManagement.Controllers.CommentsController.Edit(Int32 id, Comment comment) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\CommentsController.cs:line 163', CAST(N'2023-06-03 15:12:32.883' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (58, N'System.Private.CoreLib', N'System.IO.DirectoryNotFoundException: Could not find a part of the path ''H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\wwwroot\UploadedFiles\AP_ERD.png''.
   at Microsoft.Win32.SafeHandles.SafeFileHandle.CreateFile(String fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options)
   at Microsoft.Win32.SafeHandles.SafeFileHandle.Open(String fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)
   at System.IO.Strategies.OSFileStreamStrategy..ctor(String path, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)
   at System.IO.Strategies.FileStreamHelpers.ChooseStrategyCore(String path, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)
   at System.IO.Strategies.FileStreamHelpers.ChooseStrategy(FileStream fileStream, String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options, Int64 preallocationSize)
   at System.IO.FileStream..ctor(String path, FileMode mode)
   at ProjectManagement.Controllers.DocumentsController.Create(Document document, IFormFile file) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\DocumentsController.cs:line 79', CAST(N'2023-06-03 16:14:30.317' AS DateTime), 14)
INSERT [dbo].[Log] ([log_id], [source], [exception], [timestamp], [user_id]) VALUES (59, N'System.Private.CoreLib', N'System.IO.DirectoryNotFoundException: Could not find a part of the path ''H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\wwwroot\UploadedFiles\AP_ERD.png''.
   at Microsoft.Win32.SafeHandles.SafeFileHandle.CreateFile(String fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options)
   at Microsoft.Win32.SafeHandles.SafeFileHandle.Open(String fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)
   at System.IO.Strategies.OSFileStreamStrategy..ctor(String path, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)
   at System.IO.Strategies.FileStreamHelpers.ChooseStrategyCore(String path, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)
   at System.IO.Strategies.FileStreamHelpers.ChooseStrategy(FileStream fileStream, String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options, Int64 preallocationSize)
   at System.IO.FileStream..ctor(String path, FileMode mode)
   at ProjectManagement.Controllers.DocumentsController.Create(Document document, IFormFile file) in H:\Folders\Courses\Year 3 - Semester 2\Advanced Prog\Project\ProjectManagement\ProjectManagement\Controllers\DocumentsController.cs:line 77', CAST(N'2023-06-03 16:17:11.373' AS DateTime), 14)
SET IDENTITY_INSERT [dbo].[Log] OFF
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (1, N'We have got a leader!', N'You have successfully created a new project with the name:Computer Programming 2 Final Project. You may add members and create new tasks by going to the projects tab.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (2, N'Welcome to the team!', N'You have been added to the project: Computer Programming 2 Final Project. Check it out by navigating to your projects.', N'Unread', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (3, N'Welcome to the team!', N'You have been added to the project: Computer Programming 2 Final Project. Check it out by navigating to your projects.', N'Unread', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (4, N'A new task awaits', N'You have been assigned a new task for the project: Computer Programming 2 Final Project. Check it out by navigating to the tasks section in your project.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (5, N'A new task awaits', N'You have been assigned a new task for the project: Computer Programming 2 Final Project. Check it out by navigating to the tasks section in your project.', N'Unread', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (6, N'A new task awaits', N'You have been assigned a new task for the project: Computer Programming 2 Final Project. Check it out by navigating to the tasks section in your project.', N'Read', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (7, N'You have a new comment', N'Someone has added a new comment to your task: Creating the buttons. Check it out by navigating to the task''s comment section.', N'Read', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (8, N'You have a new comment', N'Someone has added a new comment to your task: Creating the buttons. Check it out by navigating to the task''s comment section.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (9, N'You have a new comment', N'Someone has added a new comment to your task: Implementing the form. Check it out by navigating to the task''s comment section.', N'Unread', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (10, N'You have a new comment', N'Someone has added a new comment to your task: Making the buttons functional. Check it out by navigating to the task''s comment section.', N'Unread', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (11, N'You have a new comment', N'Someone has added a new comment to your task: Making the buttons functional. Check it out by navigating to the task''s comment section.', N'Read', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (12, N'We have got a leader!', N'You have successfully created a new project with the name:Project CloudSwirl. You may add members and create new tasks by going to the projects tab.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (13, N'Welcome to the team!', N'You have been added to the project: Project CloudSwirl. Check it out by navigating to your projects.', N'Read', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (14, N'A new task awaits', N'You have been assigned a new task for the project: Project CloudSwirl. Check it out by navigating to the tasks section in your project.', N'Read', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (15, N'A new task awaits', N'You have been assigned a new task for the project: Project CloudSwirl. Check it out by navigating to the tasks section in your project.', N'Unread', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (16, N'Your task has some updates', N'Your task for the project: Project CloudSwirl has been updated by the project manager. Check it out by navigating to the tasks section in your project.', N'Unread', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (17, N'Your task has some updates', N'Your task for the project: Project CloudSwirl has been updated by the project manager. Check it out by navigating to the tasks section in your project.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (18, N'A new task awaits', N'You have been assigned a new task for the project: Project CloudSwirl. Check it out by navigating to the tasks section in your project.', N'Read', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (19, N'You have a new comment', N'Someone has added a new comment to your task: Market Research. Check it out by navigating to the task''s comment section.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (20, N'You have a new comment', N'Someone has added a new comment to your task: Interface Development. Check it out by navigating to the task''s comment section.', N'Unread', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (21, N'You have a new comment', N'Someone has added a new comment to your task: Automation. Check it out by navigating to the task''s comment section.', N'Unread', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (22, N'Your task has some updates', N'Your task for the project: EcoMinds has been updated by the project manager. Check it out by navigating to the tasks section in your project.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (23, N'Your task has some updates', N'Your task for the project: EcoMinds has been updated by the project manager. Check it out by navigating to the tasks section in your project.', N'Unread', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (24, N'Your task has some updates', N'Your task for the project: EcoMinds has been updated by the project manager. Check it out by navigating to the tasks section in your project.', N'Read', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (25, N'You have a new comment', N'Someone has added a new comment to your task: Carbon calculator feature. Check it out by navigating to the task''s comment section.', N'Read', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (26, N'You have a new comment', N'Someone has added a new comment to your task: Social platform feature. Check it out by navigating to the task''s comment section.', N'Read', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (27, N'We have got a leader!', N'You have successfully created a new project with the name:FitBuddy. You may add members and create new tasks by going to the projects tab.', N'Unread', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (28, N'Welcome to the team!', N'You have been added to the project: FitBuddy. Check it out by navigating to your projects.', N'Read', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (29, N'Welcome to the team!', N'You have been added to the project: FitBuddy. Check it out by navigating to your projects.', N'Unread', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (30, N'A new task awaits', N'You have been assigned a new task for the project: FitBuddy. Check it out by navigating to the tasks section in your project.', N'Read', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (31, N'A new task awaits', N'You have been assigned a new task for the project: FitBuddy. Check it out by navigating to the tasks section in your project.', N'Unread', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (32, N'A new task awaits', N'You have been assigned a new task for the project: FitBuddy. Check it out by navigating to the tasks section in your project.', N'Read', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (33, N'You have a new comment', N'Someone has added a new comment to your task: Develop Partnerships. Check it out by navigating to the task''s comment section.', N'Unread', 16)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (34, N'You have a new comment', N'Someone has added a new comment to your task: User Data Collection. Check it out by navigating to the task''s comment section.', N'Read', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (35, N'Your task has some updates', N'Your task for the project: FitBuddy has been updated by the project manager. Check it out by navigating to the tasks section in your project.', N'Unread', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (36, N'Welcome to the team!', N'You have been added to the project: FitBuddy. Check it out by navigating to your projects.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (37, N'We have got a leader!', N'You have successfully created a new project with the name:Web Design. You may add members and create new tasks by going to the projects tab.', N'Read', 17)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (38, N'We have got a leader!', N'You have successfully created a new project with the name:SmartGrid. You may add members and create new tasks by going to the projects tab.', N'Unread', 18)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (39, N'Your task has some updates', N'Your task for the project: CloudSwirls has been updated by the project manager. Check it out by navigating to the tasks section in your project.', N'Unread', 14)
INSERT [dbo].[Notification] ([notification_id], [title], [message], [status], [user_id]) VALUES (40, N'Task status update', N'The task: Automation in the project: CloudSwirls has a status update. Check it out by navigating to the tasks section in your project.', N'Unread', 14)
SET IDENTITY_INSERT [dbo].[Notification] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([project_id], [project_name], [description], [project_manager_id]) VALUES (1, N'EcoMinds', N'EcoMinds is a mobile app that helps individuals and organizations reduce their carbon footprint and contribute to a sustainable future. The app offers a range of features, including a carbon calculator that helps users understand their personal carbon footprint, tips and suggestions for reducing carbon emissions, and a social platform where users can connect with others and share their sustainability efforts', 14)
INSERT [dbo].[Project] ([project_id], [project_name], [description], [project_manager_id]) VALUES (2, N'CloudSwirls', N'CloudSwirl is a cloud-based platform that provides a centralized hub for managing multi-cloud environments. With CloudSwirl, users can easily deploy, manage, and monitor resources across multiple cloud providers, such as Amazon Web Services, Google Cloud Platform, and Microsoft Azure.', 14)
INSERT [dbo].[Project] ([project_id], [project_name], [description], [project_manager_id]) VALUES (3, N'FitBuddy', N'FitBuddy is a wearable device and accompanying mobile app that helps individuals achieve their fitness goals by tracking their physical activity, monitoring their health metrics, and providing personalized coaching and motivation. The device can be worn on the wrist or attached to clothing, and uses sensors to track steps, distance, calories burned, and other metrics. The app provides real-time feedback on activity levels, as well as insights into sleep quality, heart rate, and other health metrics. ', 16)
INSERT [dbo].[Project] ([project_id], [project_name], [description], [project_manager_id]) VALUES (4, N'Web Design', N'A university project to design a new website for the course IT8140', 17)
INSERT [dbo].[Project] ([project_id], [project_name], [description], [project_manager_id]) VALUES (5, N'SmartGrid', N'SmartGrid is an innovative engineering project aimed at developing a smart energy grid system. The project involves designing and implementing a network of intelligent devices and sensors that can monitor power usage, identify inefficiencies, and optimize energy distribution. SmartGrid leverages advanced technologies such as machine learning, artificial intelligence, and data analytics to provide real-time insights into energy consumption patterns and enable more efficient and sustainable power management. The system is designed to be scalable and adaptable, allowing it to be deployed in a variety of settings, from small residential communities to large industrial complexes. SmartGrid has the potential to revolutionize the way we generate, distribute, and consume energy, and contribute to a more sustainable future.', 18)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[ProjectMember] ON 

INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (1, 14, 1)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (2, 16, 1)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (3, 17, 1)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (4, 14, 2)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (5, 18, 2)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (6, 16, 3)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (8, 17, 3)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (9, 14, 3)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (10, 17, 4)
INSERT [dbo].[ProjectMember] ([project_member_id], [user_id], [project_id]) VALUES (11, 18, 5)
SET IDENTITY_INSERT [dbo].[ProjectMember] OFF
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (1, N'Carbon calculator feature', N'Build a carbon calculator feature that accurately calculates a user''s carbon footprint based on their activities and lifestyle.', CAST(N'2023-06-03 18:25:10.093' AS DateTime), CAST(N'2023-06-04 23:59:00.000' AS DateTime), 2, 1, 14)
INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (2, N'Social platform feature', N'Develop a social platform feature that allows users to connect with others and share their sustainability efforts, as well as a system for incentivizing users to engage with the platform and contribute to the community.', CAST(N'2023-06-03 18:27:18.067' AS DateTime), CAST(N'2023-03-06 23:59:00.000' AS DateTime), 1, 1, 16)
INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (3, N'Database Creation', N'Create a database of sustainability tips and suggestions, and integrate them into the app in a way that is easy for users to access and implement.', CAST(N'2023-06-03 18:29:03.473' AS DateTime), CAST(N'2023-06-04 23:55:00.000' AS DateTime), 3, 1, 17)
INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (4, N'Market Research', N'Conduct market research to identify potential customers and their needs for managing multi-cloud environments.', CAST(N'2023-06-03 18:40:32.217' AS DateTime), CAST(N'2023-06-22 23:59:00.000' AS DateTime), 3, 2, 14)
INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (5, N'Interface Development', N'Develop a user-friendly interface and intuitive dashboards for CloudSwirl.', CAST(N'2023-06-03 18:42:03.047' AS DateTime), CAST(N'2023-06-12 23:59:00.000' AS DateTime), 2, 2, 18)
INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (6, N'Automation', N'Build automation capabilities for deploying and managing resources across multiple cloud providers.', NULL, CAST(N'2023-06-15 23:59:00.000' AS DateTime), 2, 2, 18)
INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (7, N'Develop Partnerships', N' Develop partnerships with fitness studios, gyms, and other health and wellness organizations to promote the FitBuddy device and app as a tool for achieving fitness goals and improving overall health.', CAST(N'2023-06-03 19:14:50.427' AS DateTime), CAST(N'2023-06-20 23:59:00.000' AS DateTime), 2, 3, 16)
INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (8, N'User Data Collection', N'Collect and analyze user data to continuously improve the device and app, as well as to develop new products and services that meet the evolving needs of the fitness and health tracking market.', CAST(N'2023-06-03 19:16:47.877' AS DateTime), CAST(N'2023-06-21 23:59:00.000' AS DateTime), 1, 3, 17)
INSERT [dbo].[Task] ([task_id], [task_name], [description], [assign_date], [deadline], [status_id], [project_id], [user_id]) VALUES (9, N'Marketing and Sales Strategy', N'Develop a marketing and sales strategy for promoting the device and app to potential customers, including social media advertising, influencer marketing, and other channels.', CAST(N'2023-06-03 19:18:38.637' AS DateTime), CAST(N'2023-06-25 23:59:00.000' AS DateTime), 2, 3, 17)
SET IDENTITY_INSERT [dbo].[Task] OFF
SET IDENTITY_INSERT [dbo].[TaskStatus] ON 

INSERT [dbo].[TaskStatus] ([taskStatus_id], [status], [description]) VALUES (1, N'Not started', N'The task has not been started with yet')
INSERT [dbo].[TaskStatus] ([taskStatus_id], [status], [description]) VALUES (2, N'Ongoing', N'The task is in progress but has not been completed')
INSERT [dbo].[TaskStatus] ([taskStatus_id], [status], [description]) VALUES (3, N'Completed', N'The task has been finished successfully')
SET IDENTITY_INSERT [dbo].[TaskStatus] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [email]) VALUES (14, N'test_admin@gmail.com')
INSERT [dbo].[User] ([user_id], [email]) VALUES (16, N'user1@gmail.com')
INSERT [dbo].[User] ([user_id], [email]) VALUES (17, N'user2@gmail.com')
INSERT [dbo].[User] ([user_id], [email]) VALUES (18, N'user3@gmail.com')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Audit]  WITH CHECK ADD  CONSTRAINT [FK_Audit_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Audit] CHECK CONSTRAINT [FK_Audit_User]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Task] FOREIGN KEY([task_id])
REFERENCES [dbo].[Task] ([task_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Task]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Task1] FOREIGN KEY([task_id])
REFERENCES [dbo].[Task] ([task_id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Task1]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Type] FOREIGN KEY([type_id])
REFERENCES [dbo].[DocumentType] ([documentType_id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Type]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_User]
GO
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_User1] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_User1]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_User1] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_User1]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_User] FOREIGN KEY([project_manager_id])
REFERENCES [dbo].[User] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_User]
GO
ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD  CONSTRAINT [FK_ProjectMember_Project1] FOREIGN KEY([project_id])
REFERENCES [dbo].[Project] ([project_id])
GO
ALTER TABLE [dbo].[ProjectMember] CHECK CONSTRAINT [FK_ProjectMember_Project1]
GO
ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD  CONSTRAINT [FK_ProjectMember_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[ProjectMember] CHECK CONSTRAINT [FK_ProjectMember_User]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([project_id])
REFERENCES [dbo].[Project] ([project_id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Status] FOREIGN KEY([status_id])
REFERENCES [dbo].[TaskStatus] ([taskStatus_id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Status]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User]
GO
USE [master]
GO
ALTER DATABASE [ProjectManagement] SET  READ_WRITE 
GO
