CREATE TABLE [dbo].[Graduate]
(
[GraduateID] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Surname] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Email] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PreferredRole] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Degree] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[GraduateYear] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Graduate] ADD CONSTRAINT [PK_Graduate] PRIMARY KEY CLUSTERED  ([GraduateID]) ON [PRIMARY]
GO
