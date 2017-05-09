CREATE TABLE [dbo].[Rotation]
(
[RotationID] [int] NOT NULL IDENTITY(1, 1),
[GraduateID] [int] NULL,
[ProjectID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Rotation] ADD CONSTRAINT [PK_GradProj] PRIMARY KEY CLUSTERED  ([RotationID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Rotation] ADD CONSTRAINT [FK_GradProj_Project] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[Rotation] ADD CONSTRAINT [FK_GraduateID] FOREIGN KEY ([GraduateID]) REFERENCES [dbo].[Graduate] ([GraduateID])
GO
