CREATE TABLE [dbo].[GradProj]
(
[GradProjID] [int] NOT NULL,
[GraduateID] [int] NULL,
[ProjectID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GradProj] ADD CONSTRAINT [PK_GradProj] PRIMARY KEY CLUSTERED  ([GradProjID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GradProj] ADD CONSTRAINT [FK_GradProj_Project] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[GradProj] ADD CONSTRAINT [FK_GraduateID] FOREIGN KEY ([GraduateID]) REFERENCES [dbo].[Graduate] ([GraduateID])
GO
