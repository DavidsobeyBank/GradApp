CREATE TABLE [dbo].[Goal]
(
[GoalID] [int] NOT NULL IDENTITY(1, 1),
[GoalName] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[AreaID] [int] NULL,
[GradProjID] [int] NULL,
[GoalComment] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GoalFeedback] [varchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Goal] ADD CONSTRAINT [PK_Goal] PRIMARY KEY CLUSTERED  ([GoalID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Goal] ADD CONSTRAINT [FK_Goal_GradProjID] FOREIGN KEY ([GradProjID]) REFERENCES [dbo].[Rotation] ([RotationID])
GO
