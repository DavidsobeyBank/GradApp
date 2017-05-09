CREATE TABLE [dbo].[Area]
(
[AreaID] [int] NOT NULL IDENTITY(1, 1),
[AreaName] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AreaBuilding] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ManagerID] [int] NULL,
[AreaFloor] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Comment] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Area] ADD CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED  ([AreaID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Area] ADD CONSTRAINT [FK_ManagerID] FOREIGN KEY ([ManagerID]) REFERENCES [dbo].[Manager] ([ManagerID])
GO
