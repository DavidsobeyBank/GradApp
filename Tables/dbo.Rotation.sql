CREATE TABLE [dbo].[Rotation]
(
[RotationID] [int] NOT NULL IDENTITY(1, 1),
[GraduateID] [int] NOT NULL,
[ProjectID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Rotation] ADD CONSTRAINT [PK_Rotation] PRIMARY KEY CLUSTERED  ([RotationID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_GraduateID] ON [dbo].[Rotation] ([GraduateID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProjectID] ON [dbo].[Rotation] ([ProjectID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Rotation] ADD CONSTRAINT [FK_Rotation_Graduate] FOREIGN KEY ([GraduateID]) REFERENCES [dbo].[Graduate] ([GraduateID])
GO
ALTER TABLE [dbo].[Rotation] ADD CONSTRAINT [FK_Rotation_Project] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ProjectID])
GO
