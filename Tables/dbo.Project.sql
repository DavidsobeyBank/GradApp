CREATE TABLE [dbo].[Project]
(
[ProjectID] [int] NOT NULL IDENTITY(1, 1),
[ProjectName] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AreaID] [int] NULL,
[ManagerID] [int] NULL,
[Brief] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Skills] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[StartDate] [datetime] NULL,
[EndDate] [datetime] NULL
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
