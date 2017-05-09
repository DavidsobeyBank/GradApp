CREATE TABLE [dbo].[Project]
(
[ProjectID] [int] NOT NULL IDENTITY(1, 1),
[ProjectName] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AreaID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project] ADD CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED  ([ProjectID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project] ADD CONSTRAINT [FK_ProJAreaID] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Area] ([AreaID])
GO
