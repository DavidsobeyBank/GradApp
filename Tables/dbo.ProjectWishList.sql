CREATE TABLE [dbo].[ProjectWishList]
(
[WishListID] [int] NOT NULL IDENTITY(1, 1),
[ProjectID] [int] NULL,
[GraduateID] [int] NULL,
[Moivation] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProjectWishList] ADD CONSTRAINT [PK_ProjectWishList] PRIMARY KEY CLUSTERED  ([WishListID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_GraduateID] ON [dbo].[ProjectWishList] ([GraduateID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ProjectID] ON [dbo].[ProjectWishList] ([ProjectID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProjectWishList] ADD CONSTRAINT [FK_ProjectWishList_Graduate] FOREIGN KEY ([GraduateID]) REFERENCES [dbo].[Graduate] ([GraduateID])
GO
ALTER TABLE [dbo].[ProjectWishList] ADD CONSTRAINT [FK_ProjectWishList_Project] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ProjectID])
GO
