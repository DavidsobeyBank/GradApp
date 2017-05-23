CREATE TABLE [dbo].[Project]
(
[ProjectID] [int] NOT NULL IDENTITY(1, 1),
[ProjectName] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[AreaID] [int] NOT NULL,
[ManagerID] [int] NOT NULL,
[Brief] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Skills] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[StartDate] [datetime] NOT NULL,
[EndDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project] ADD CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED  ([ProjectID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AreaID] ON [dbo].[Project] ([AreaID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ManagerID] ON [dbo].[Project] ([ManagerID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project] ADD CONSTRAINT [FK_ProJAreaID] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Area] ([AreaID])
GO
ALTER TABLE [dbo].[Project] ADD CONSTRAINT [FK_Project_Manager] FOREIGN KEY ([ManagerID]) REFERENCES [dbo].[Manager] ([ManagerID])
GO
