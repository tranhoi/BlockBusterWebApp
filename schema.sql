USE [master]
GO
/****** Object:  Database [dbBBuster]    Script Date: 6/9/2020 10:07:38 PM ******/
CREATE DATABASE [dbBBuster]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbBlockBuster', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLPATHEO\MSSQL\DATA\dbBlockBuster.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbBlockBuster_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLPATHEO\MSSQL\DATA\dbBlockBuster_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbBBuster] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbBBuster].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbBBuster] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbBBuster] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbBBuster] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbBBuster] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbBBuster] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbBBuster] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbBBuster] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbBBuster] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbBBuster] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbBBuster] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbBBuster] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbBBuster] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbBBuster] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbBBuster] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbBBuster] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbBBuster] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbBBuster] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbBBuster] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbBBuster] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbBBuster] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbBBuster] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbBBuster] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbBBuster] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbBBuster] SET  MULTI_USER 
GO
ALTER DATABASE [dbBBuster] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbBBuster] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbBBuster] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbBBuster] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [dbBBuster] SET DELAYED_DURABILITY = DISABLED 
GO
USE [dbBBuster]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 6/9/2020 10:07:38 PM ******/
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
/****** Object:  Table [dbo].[category]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[color_id] [int] NULL,
 CONSTRAINT [PK_dbCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[celeb_job]    Script Date: 6/9/2020 10:07:38 PM ******/
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
/****** Object:  Table [dbo].[celebrity]    Script Date: 6/9/2020 10:07:38 PM ******/
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
	[avatar] [varchar](200) NULL,
	[birthday] [date] NULL,
	[country_id] [int] NULL,
 CONSTRAINT [PK_dbCelebrity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[chapter]    Script Date: 6/9/2020 10:07:38 PM ******/
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
/****** Object:  Table [dbo].[color]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[color](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[color_name] [varchar](8) NULL,
 CONSTRAINT [PK_color] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[country]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
 CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[favorite]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favorite](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[film_id] [int] NULL,
	[created] [datetime] NULL,
 CONSTRAINT [PK_favorite] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[film]    Script Date: 6/9/2020 10:07:38 PM ******/
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
	[image_link] [varchar](200) NULL,
	[view_count] [int] NULL CONSTRAINT [DF_tbFilm_view_count]  DEFAULT ((0)),
	[description] [varchar](5000) NULL,
	[created] [datetime] NULL,
	[form_id] [int] NULL,
	[rate] [int] NULL CONSTRAINT [DF_film_rate]  DEFAULT ((5)),
 CONSTRAINT [PK_tbFilm] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[film_category]    Script Date: 6/9/2020 10:07:38 PM ******/
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
/****** Object:  Table [dbo].[film_celebrity]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[film_celebrity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NULL,
	[celeb_id] [int] NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_dbFilm_Cast] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[film_country]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[film_country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NULL,
	[country_id] [int] NULL,
 CONSTRAINT [PK_film_country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[film_trailer]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[film_trailer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NULL,
	[trailer_id] [int] NULL,
 CONSTRAINT [PK_film_trailer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[form]    Script Date: 6/9/2020 10:07:38 PM ******/
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
/****** Object:  Table [dbo].[job]    Script Date: 6/9/2020 10:07:38 PM ******/
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
/****** Object:  Table [dbo].[position]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
 CONSTRAINT [PK_position] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[review]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[review](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[point] [int] NULL CONSTRAINT [DF_review_point]  DEFAULT ((3)),
	[title] [varchar](100) NULL,
	[comment] [varchar](2000) NULL,
	[film_id] [int] NULL,
	[user_id] [int] NULL,
	[created] [datetime] NULL,
 CONSTRAINT [PK_dbRate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[role]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[display] [bit] NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[trailer]    Script Date: 6/9/2020 10:07:38 PM ******/
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
	[image_link] [varchar](200) NULL,
	[film_id] [int] NULL,
 CONSTRAINT [PK_dbTrailer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user]    Script Date: 6/9/2020 10:07:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NULL,
	[password] [varchar](16) NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[created] [datetime] NULL,
 CONSTRAINT [PK_dbUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_admin_position] FOREIGN KEY([position_id])
REFERENCES [dbo].[position] ([id])
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [FK_admin_position]
GO
ALTER TABLE [dbo].[category]  WITH CHECK ADD  CONSTRAINT [FK_category_color] FOREIGN KEY([color_id])
REFERENCES [dbo].[color] ([id])
GO
ALTER TABLE [dbo].[category] CHECK CONSTRAINT [FK_category_color]
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
ALTER TABLE [dbo].[celebrity]  WITH CHECK ADD  CONSTRAINT [FK_celebrity_country] FOREIGN KEY([country_id])
REFERENCES [dbo].[country] ([id])
GO
ALTER TABLE [dbo].[celebrity] CHECK CONSTRAINT [FK_celebrity_country]
GO
ALTER TABLE [dbo].[chapter]  WITH CHECK ADD  CONSTRAINT [FK_dbChapter_tbFilm] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[chapter] CHECK CONSTRAINT [FK_dbChapter_tbFilm]
GO
ALTER TABLE [dbo].[favorite]  WITH CHECK ADD  CONSTRAINT [FK_favorite_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[favorite] CHECK CONSTRAINT [FK_favorite_film]
GO
ALTER TABLE [dbo].[favorite]  WITH CHECK ADD  CONSTRAINT [FK_favorite_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[favorite] CHECK CONSTRAINT [FK_favorite_user]
GO
ALTER TABLE [dbo].[film]  WITH CHECK ADD  CONSTRAINT [FK_film_form] FOREIGN KEY([form_id])
REFERENCES [dbo].[form] ([id])
GO
ALTER TABLE [dbo].[film] CHECK CONSTRAINT [FK_film_form]
GO
ALTER TABLE [dbo].[film_category]  WITH CHECK ADD  CONSTRAINT [FK_film_category_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[film_category] CHECK CONSTRAINT [FK_film_category_category]
GO
ALTER TABLE [dbo].[film_category]  WITH CHECK ADD  CONSTRAINT [FK_film_category_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[film_category] CHECK CONSTRAINT [FK_film_category_film]
GO
ALTER TABLE [dbo].[film_celebrity]  WITH CHECK ADD  CONSTRAINT [FK_film_celebrity_celebrity1] FOREIGN KEY([celeb_id])
REFERENCES [dbo].[celebrity] ([id])
GO
ALTER TABLE [dbo].[film_celebrity] CHECK CONSTRAINT [FK_film_celebrity_celebrity1]
GO
ALTER TABLE [dbo].[film_celebrity]  WITH CHECK ADD  CONSTRAINT [FK_film_celebrity_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[film_celebrity] CHECK CONSTRAINT [FK_film_celebrity_film]
GO
ALTER TABLE [dbo].[film_celebrity]  WITH CHECK ADD  CONSTRAINT [FK_film_celebrity_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[film_celebrity] CHECK CONSTRAINT [FK_film_celebrity_role]
GO
ALTER TABLE [dbo].[film_country]  WITH CHECK ADD  CONSTRAINT [FK_film_country_country] FOREIGN KEY([country_id])
REFERENCES [dbo].[country] ([id])
GO
ALTER TABLE [dbo].[film_country] CHECK CONSTRAINT [FK_film_country_country]
GO
ALTER TABLE [dbo].[film_country]  WITH CHECK ADD  CONSTRAINT [FK_film_country_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[film_country] CHECK CONSTRAINT [FK_film_country_film]
GO
ALTER TABLE [dbo].[film_trailer]  WITH CHECK ADD  CONSTRAINT [FK_film_trailer_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[film_trailer] CHECK CONSTRAINT [FK_film_trailer_film]
GO
ALTER TABLE [dbo].[film_trailer]  WITH CHECK ADD  CONSTRAINT [FK_film_trailer_trailer] FOREIGN KEY([trailer_id])
REFERENCES [dbo].[trailer] ([id])
GO
ALTER TABLE [dbo].[film_trailer] CHECK CONSTRAINT [FK_film_trailer_trailer]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_dbRate_tbFilm] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_dbRate_tbFilm]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_review_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_review_user]
GO
ALTER TABLE [dbo].[trailer]  WITH CHECK ADD  CONSTRAINT [FK_trailer_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[trailer] CHECK CONSTRAINT [FK_trailer_film]
GO
USE [master]
GO
ALTER DATABASE [dbBBuster] SET  READ_WRITE 
GO
