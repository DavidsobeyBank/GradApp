CREATE TABLE [dbo].[Graduate]
(
[GraduateID] [int] NOT NULL IDENTITY(1, 1),
[Name] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Surname] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [nchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PrefferedRole] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Degree] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GraduateYear] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Graduate] ADD CONSTRAINT [PK_Graduate] PRIMARY KEY CLUSTERED  ([GraduateID]) ON [PRIMARY]
GO
