USE [BallroomDance]
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [Name]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [IdUserRole], [Login], [Email], [Password], [Created], [Updated]) VALUES (1, 1, NULL, N'Kira', N'Kira@email.com', N'8On8WBVO4/96H1HaMsc2hw7eYlGRLnz2WrqEnuL12R7TCwHLTC2WUXyxf4W9h+8gZY/w0b7hs7Z8NEYL/UnO7g==', CAST(N'2024-03-15T01:52:03.9154364' AS DateTime2), NULL)
INSERT [dbo].[Users] ([Id], [IdUserRole], , [Login], [Email], [Password], [Created], [Updated]) VALUES (7, 1, NULL, N'lololo', N'tuturu@mail.com', N'SCVrePTPJpUQK926yVE57Bm95TLApqYJTvTb0gE1sUmsFV62y1FST18LvsTASRwBEJXTVyiZxBAHGsnJsfOcmg==', CAST(N'2024-03-28T23:11:07.3574760' AS DateTime2), CAST(N'2024-03-28T23:11:07.3574760' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
