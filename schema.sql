USE [dbBBuster]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[position_id] [int] NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[category]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[color] [varchar](50) NULL,
 CONSTRAINT [PK_dbCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[celeb_job]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[celeb_job](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[celeb_id] [int] NULL,
	[job_id] [int] NULL,
 CONSTRAINT [PK_celeb_job] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[celebrity]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[celebrity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[description] [varchar](5000) NULL,
	[avatar] [varchar](20) NULL,
 CONSTRAINT [PK_dbCelebrity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[chapter]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chapter](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [int] NULL,
	[film_id] [int] NULL,
	[source] [varchar](100) NULL,
 CONSTRAINT [PK_dbChapter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[favorite_film]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favorite_film](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[film_id] [int] NULL,
 CONSTRAINT [PK_dbFavorite_film] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[film]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[film](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[release] [date] NULL,
	[image_link] [varchar](100) NULL,
	[source] [varchar](200) NULL,
	[view_count] [int] NULL CONSTRAINT [DF_tbFilm_view_count]  DEFAULT ((0)),
	[description] [varchar](5000) NULL,
	[created] [date] NULL,
	[form_id] [int] NULL,
	[rate] [float] NULL CONSTRAINT [DF_film_rate]  DEFAULT ((5)),
 CONSTRAINT [PK_tbFilm] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[film_cast]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[film_cast](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NULL,
	[celeb_id] [int] NULL,
	[characters] [varchar](20) NULL,
 CONSTRAINT [PK_dbFilm_Cast] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[film_category]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[film_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NULL,
	[category_id] [int] NULL,
 CONSTRAINT [PK_dbFilm_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[film_director]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[film_director](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NULL,
	[celeb_id] [int] NULL,
 CONSTRAINT [PK_film_director] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[form]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[form](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [char](10) NULL,
 CONSTRAINT [PK_form] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[job]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[job](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](10) NULL,
 CONSTRAINT [PK_job] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[review]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[review](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[point] [int] NULL,
	[comment] [varchar](1000) NULL,
	[film_id] [int] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_dbRate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[trailer]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trailer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[source] [varchar](50) NULL,
	[image_link] [varchar](50) NULL,
 CONSTRAINT [PK_dbTrailer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 5/18/2020 9:21:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](16) NULL,
	[password] [varchar](16) NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[created] [date] NULL,
	[activate] [bit] NULL CONSTRAINT [DF_dbUsers_activate]  DEFAULT ((0)),
 CONSTRAINT [PK_dbUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[celeb_job]  WITH CHECK ADD  CONSTRAINT [FK_celeb_job_celebrity] FOREIGN KEY([celeb_id])
REFERENCES [dbo].[celebrity] ([id])
GO
ALTER TABLE [dbo].[celeb_job] CHECK CONSTRAINT [FK_celeb_job_celebrity]
GO
ALTER TABLE [dbo].[celeb_job]  WITH CHECK ADD  CONSTRAINT [FK_celeb_job_job1] FOREIGN KEY([job_id])
REFERENCES [dbo].[job] ([id])
GO
ALTER TABLE [dbo].[celeb_job] CHECK CONSTRAINT [FK_celeb_job_job1]
GO
ALTER TABLE [dbo].[chapter]  WITH CHECK ADD  CONSTRAINT [FK_dbChapter_tbFilm] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[chapter] CHECK CONSTRAINT [FK_dbChapter_tbFilm]
GO
ALTER TABLE [dbo].[favorite_film]  WITH CHECK ADD  CONSTRAINT [FK_dbFavorite_film_dbUsers] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[favorite_film] CHECK CONSTRAINT [FK_dbFavorite_film_dbUsers]
GO
ALTER TABLE [dbo].[favorite_film]  WITH CHECK ADD  CONSTRAINT [FK_dbFavorite_film_tbFilm] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[favorite_film] CHECK CONSTRAINT [FK_dbFavorite_film_tbFilm]
GO
ALTER TABLE [dbo].[film]  WITH CHECK ADD  CONSTRAINT [FK_film_form] FOREIGN KEY([form_id])
REFERENCES [dbo].[form] ([id])
GO
ALTER TABLE [dbo].[film] CHECK CONSTRAINT [FK_film_form]
GO
ALTER TABLE [dbo].[film_cast]  WITH CHECK ADD  CONSTRAINT [FK_dbFilm_Cast_dbCelebrity] FOREIGN KEY([celeb_id])
REFERENCES [dbo].[celebrity] ([id])
GO
ALTER TABLE [dbo].[film_cast] CHECK CONSTRAINT [FK_dbFilm_Cast_dbCelebrity]
GO
ALTER TABLE [dbo].[film_cast]  WITH CHECK ADD  CONSTRAINT [FK_dbFilm_Cast_tbFilm] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[film_cast] CHECK CONSTRAINT [FK_dbFilm_Cast_tbFilm]
GO
ALTER TABLE [dbo].[film_category]  WITH CHECK ADD  CONSTRAINT [FK_dbFilm_Category_dbCategory] FOREIGN KEY([category_id])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[film_category] CHECK CONSTRAINT [FK_dbFilm_Category_dbCategory]
GO
ALTER TABLE [dbo].[film_category]  WITH CHECK ADD  CONSTRAINT [FK_dbFilm_Category_tbFilm] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[film_category] CHECK CONSTRAINT [FK_dbFilm_Category_tbFilm]
GO
ALTER TABLE [dbo].[film_director]  WITH CHECK ADD  CONSTRAINT [FK_film_director_celebrity] FOREIGN KEY([celeb_id])
REFERENCES [dbo].[celebrity] ([id])
GO
ALTER TABLE [dbo].[film_director] CHECK CONSTRAINT [FK_film_director_celebrity]
GO
ALTER TABLE [dbo].[film_director]  WITH CHECK ADD  CONSTRAINT [FK_film_director_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[film_director] CHECK CONSTRAINT [FK_film_director_film]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_dbRate_dbUsers] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_dbRate_dbUsers]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_dbRate_tbFilm] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_dbRate_tbFilm]
GO
