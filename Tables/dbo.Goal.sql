CREATE TABLE [dbo].[Goal]
(
[GoalID] [int] NOT NULL IDENTITY(1, 1),
[GoalName] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AreaID] [int] NULL,
[GradProjID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Goal] ADD CONSTRAINT [PK_Goal] PRIMARY KEY CLUSTERED  ([GoalID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Goal] ADD CONSTRAINT [FK_Goal_GradProjID] FOREIGN KEY ([GradProjID]) REFERENCES [dbo].[GradProj] ([GradProjID])
GO
