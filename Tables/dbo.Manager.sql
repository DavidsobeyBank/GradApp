CREATE TABLE [dbo].[Manager]
(
[ManagerID] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Surname] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AreaID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Manager] ADD CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED  ([ManagerID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Manager] ADD CONSTRAINT [FK_AreaID] FOREIGN KEY ([AreaID]) REFERENCES [dbo].[Area] ([AreaID])
GO
