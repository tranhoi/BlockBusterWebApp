USE [master]
GO
/****** Object:  Database [dbBBuster]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[admin]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[category]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[celeb_job]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[celebrity]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[chapter]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[color]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[country]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[favorite]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[film]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[film_category]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[film_celebrity]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[film_country]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[form]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[job]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[position]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[review]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[role]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[trailer]    Script Date: 7/4/2020 11:07:27 AM ******/
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
/****** Object:  Table [dbo].[userr]    Script Date: 7/4/2020 11:07:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userr](
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
SET IDENTITY_INSERT [dbo].[admin] ON 

INSERT [dbo].[admin] ([id], [name], [username], [password], [position_id]) VALUES (5, N'Pa', N'adminn', N'111111', 1)
INSERT [dbo].[admin] ([id], [name], [username], [password], [position_id]) VALUES (6, N'Theo', N'manager', N'222222', 2)
SET IDENTITY_INSERT [dbo].[admin] OFF
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (24, N'Action', 1)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (25, N'Romantic', 2)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (26, N'Fantasy', 3)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (27, N'Horror', 4)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (28, N'Comedy', 1)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (29, N'Mystery', 2)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (30, N'Costume', 3)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (31, N'Documentary', 4)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (32, N'Drama', 1)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (33, N'Cartoon', 2)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (34, N'Family', 3)
INSERT [dbo].[category] ([id], [name], [color_id]) VALUES (35, N'Adventure', 4)
SET IDENTITY_INSERT [dbo].[category] OFF
SET IDENTITY_INSERT [dbo].[celeb_job] ON 

INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (1, 1, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (2, 2, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (3, 3, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (4, 4, 1)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (5, 4, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (6, 5, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (7, 6, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (8, 7, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (9, 8, 1)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (10, 9, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (11, 10, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (12, 11, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (13, 12, 1)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (14, 13, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (15, 14, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (16, 15, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (17, 16, 1)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (18, 17, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (19, 18, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (20, 19, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (21, 19, 1)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (22, 15, 1)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (23, 20, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (24, 21, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (27, 23, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (28, 24, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (29, 24, 1)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (30, 25, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (31, 26, 2)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (32, 26, 1)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (33, 1, 4)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (34, 2, 4)
INSERT [dbo].[celeb_job] ([id], [celeb_id], [job_id]) VALUES (35, 4, 3)
SET IDENTITY_INSERT [dbo].[celeb_job] OFF
SET IDENTITY_INSERT [dbo].[celebrity] ON 

INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (1, N'Joaquin Phoenix                                   ', N'Phoenix was born as Joaquin Rafael Bottom in Rio Piedras, Puerto Rico, parents from the continental United States. He is the third of five children, including River (1970–1993), Rain (born 1972), Liberty (born 1976) and Summer (born 1978), all of whom are artists. He also had a half-sister, Jodean (born 1964), who was his father''s stepdaughter with his first wife. [3]

Phoenix''s father, John Lee Bottom, originally from Fontana, California, was a lapsed Catholic, [4] with English, German and French ancestors. [5] [6] Phoenix''s mother, Arlyn (née Dunetz), was born in the Bronx, New York, to Jewish parents whose family immigrated from Russia and Hungary. [4] Arlyn left her family in 1968 and moved to California, after which she met Phoenix''s father while hitchhiking. They married in 1969, then joined a religious group, Children of God, and began traveling abroad in South America. [5] His parents later awakened and left the group and returned to the United States in 1978. They changed their name to Phoenix, after the mythical Phoenix bird rising from its ashes, symbolizing a new beginning. 7] Around this time, Joaquin began to call herself "Leaf" with the desire to have a name related to nature as her siblings, inspired by outdoor leaf raking with her father. yourself. "Leaf" became the name he used as a child actor, until he was 15, when he changed his name to Joaquin again. [8] He first used this name in the movie "To Die For".                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             ', N'Joaquin_Phoenix.jpg ', CAST(N'1974-10-28' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (2, N'Robert Mario De Niro, Jr.                         ', N'Robert Mario De Niro, Jr. born on 17 August 1943 in New York City to an artist family, his father was Robert De Niro, Sr., an artist and sculptor, and his mother, Virginia Admiral, was an artist [1] ]. Grandparents of Robert De Niro, Sr. are the original Italian migrants in Ferrazzano, Campobasso province in Molise Central Italy [2]. De Niro''s parents met at a drawing school of Hans Hofmann in Provincetown, Massachusetts, when they were divorced when Robert was two.

De Niro grew up in Little Italy (Little Italy) of Manhattan. He was enrolled by his mother at the High School of Music and Art in New York but dropped out when he was 13 to join street gangs in Little Italy. De Niro then returned to the art path when he enrolled in the Stella Adler theater school as well as the Actor''s Studio artist association led by Lee Strasberg. At the age of 16, he had his first role in the play The Bear by Anton Chekhov.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ', N'Robert_De_Niro.jpg  ', CAST(N'1943-08-17' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (3, N'Zazie Beetz                                       ', N'Zazie Olivia Beetz (born 1991 in Berlin, Germany) is a German-American actress. She stars in the FX comedy-drama series Atlanta (2016–present), for which she received a nomination for the Primetime Emmy Award for Outstanding Supporting Actress in a Comedy Series.[3][4] She also appeared in the Netflix anthology series Easy (2016–19).[5]

In film, Beetz has appeared in the disaster film Geostorm (2017), and has played the Marvel Comics character Domino in the superhero film Deadpool 2 (2018) and Arthur Fleck/Joker''s neighbor in the psychological thriller Joker (2019).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ', N'Zazie_Beetz.jpg     ', CAST(N'1991-01-01' AS Date), 2)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (4, N'Todd Phillips                                     ', N'Phillips was born in Brooklyn, New York City, to a family of Jewish background.[3][4] He was raised in Huntington, New York, on Long Island.[1] He attended New York University Film School, but dropped out[5] because he could not afford to complete his first film and pay tuition simultaneously.[6] Around that time, he worked at Kim''s Video and Music.[5]

Phillips appeared as one of the drivers in the first season of the HBO hidden camera docu-series Taxicab Confessions.[7] In a New York Times profile, Phillips said he had gotten in trouble for shoplifting as a young man.[1]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   ', N'Todd_Phillips.jpg   ', CAST(N'1970-12-20' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (5, N'Scarlett Johansson                                ', N'Scarlett Ingrid Johansson was born in the New York City borough of Manhattan,[1][2] on November 22, 1984.[3] Her father, Karsten Olaf Johansson, is an architect originally from Copenhagen, Denmark, and her paternal grandfather, Ejner Johansson, was an art historian, screenwriter and film director, whose father was Swedish.[4][5] Scarlett''s mother, Melanie Sloan, a New Yorker, has worked as a producer. She comes from an Ashkenazi Jewish family from Poland and Russia, originally surnamed Schlamberg,[5] and Scarlett has described herself as Jewish.[6][7][8] She has an older sister, Vanessa, also an actress; an older brother, Adrian; and a twin brother, Hunter.[9] Johansson also has an older half-brother, Christian, from her father''s first marriage. She holds both American and Danish citizenship.[10][11]

Johansson attended PS 41, an elementary school in Greenwich Village, Manhattan.[12] Her parents divorced when she was 13.[13][14] Johansson was particularly close to her maternal grandmother, Dorothy Sloan, a bookkeeper and schoolteacher; they often spent time together and Johansson considered Sloan her best friend.[15] Interested in a career in the spotlight from an early age, she often put on song-and-dance routines for her family. She was particularly fond of musical theater and jazz hands.[16][17] She took lessons in tap dance, and states that her parents were supportive of her career choice. She describes her childhood as very ordinary.[18]

As a child, Johansson practiced acting by staring in the mirror until she made herself cry, wanting to be Judy Garland in Meet Me in St. Louis.[19] At age seven, she was devastated when a talent agent signed one of her brothers instead of her, but she later decided to become an actress anyway. She enrolled at the Lee Strasberg Theatre Institute, and began auditioning for commercials, but soon lost interest: "I didn''t want to promote Wonder Bread."[19] She shifted her focus to film and theater,[20] making her first stage ap                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ', N'S_Johansson.jpg', CAST(N'1984-11-22' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (6, N'Chris Evans                                       ', N'Evans was born on June 13, 1981,[4] in Boston, Massachusetts,[5] and grew up in the nearby town of Sudbury.[6] His mother, Lisa (née Capuano), is an artistic director at the Concord Youth Theater,[7][8] and his father, G. Robert Evans III, is a dentist.[9] His mother is of half Italian and half Irish descent, while his father is of half British and half German ancestry.[10][11][12] His parents divorced in 1999.[13] Evans has three siblings: an older sister, Carly, a younger brother, Scott, and a younger sister, Shanna.[9] Carly is a high school drama and English teacher at Lincoln-Sudbury Regional High School, while Scott is an actor.[14][15] He and his siblings were raised Catholic.[11][12] Their uncle, Mike Capuano, represented Massachusetts''s 8th congressional district.[10] He also has three younger half-siblings from his father''s second marriage.[16]

Evans graduated from Lincoln-Sudbury Regional High School.[6] He later moved to New York City and took classes at the Lee Strasberg Theatre and Film Institute.[17]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ', N'Chris_Evans.jpg     ', CAST(N'1981-06-13' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (7, N'Robert Downey Jr.                                 ', N'Downey was born in Manhattan, New York City, the younger of two children. His father, Robert Downey Sr., is an actor and filmmaker, while his mother, Elsie Ann (née Ford), was an actress who appeared in Downey Sr.''s films.[8] Downey''s father is of half Lithuanian Jewish, one-quarter Hungarian Jewish, and one-quarter Irish descent,[9][10][11][12] while Downey''s mother had Scottish, German, and Swiss ancestry.[13][14][15] Robert''s original family name was Elias which was changed by his father to enlist in the Army.[16] Downey and his older sister Allyson grew up in Greenwich Village.[17]

As a child, Downey was "surrounded by drugs." His father, a drug addict, allowed Downey to use marijuana at age six, an incident which his father later said he regretted.[17] Downey later stated that drug use became an emotional bond between him and his father: "When my dad and I would do drugs together, it was like him trying to express his love for me in the only way he knew how." Eventually, Downey began spending every night abusing alcohol and "making a thousand phone calls in pursuit of drugs."[18][19]

During his childhood, Downey had minor roles in his father''s films. He made his acting debut at the age of five, playing a sick puppy in the absurdist comedy Pound (1970), and then at seven appeared in the surrealist Western Greaser''s Palace (1972).[14] At the age of 10, he was living in England and studied classical ballet as part of a larger curriculum.[20][21] He attended the Stagedoor Manor Performing Arts Training Center in upstate New York as a teenager. When his parents divorced in 1978, Downey moved to California with his father, but in 1982, he dropped out of Santa Monica High School, and moved back to New York to pursue an acting career full-time.[22]

Downey and Kiefer Sutherland, who shared the screen in the 1988 drama 1969, were roommates for three years when he first moved to Hollywood to pursue his career in acting.[23]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                ', N'Robert_Downey.jpg   ', CAST(N'1965-04-04' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (8, N'Anthony russo                                     ', N'Anthony Russo (born February 3, 1970)[1][2] and Joseph Russo (born July 18, 1971)[2][3] were born and raised in Cleveland, Ohio, the sons of Patricia (née Gallupoli) and attorney and former judge Basil Russo. Their parents were both of Italian descent.[4] Their paternal and maternal families immigrated from Sicily and Abruzzo, respectively, fleeing poverty and settling in Ohio to work its steel mills.[5] They attended Benedictine High School.[6] Joe graduated from the University of Iowa and majored in English and writing, while Anthony graduated from the University of Pennsylvania and majored in business before switching to English.[7][8][9]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ', N'Anthony_russo.jpg   ', CAST(N'1970-02-03' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (9, N'Choi Woo-shik', N'Choi was born in Seoul, South Korea, the youngest of two sons. He immigrated to Canada with his family when he was in grade five, living in British Columbia, where he spent the next ten years of his life.[2] He attended high school at Pinetree Secondary School in Coquitlam.[3] His English name is Edward and he goes by the nickname Eddie.[4]

Then in 2011, while a junior at Simon Fraser University, then-21-year-old Choi returned to Korea to attend acting auditions, and subsequently made his acting debut. While in Korea, he enrolled in Chung-Ang University, where he majored in cultural studies.[3]', N'Choi_Woo-shik.jpg', CAST(N'1990-03-26' AS Date), 3)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (10, N'Park So-dam', N'When Park was in high school, she watched the musical Grease and developed an interest in acting. While in university, Park started her career by turning to independent films after being rejected in around seventeen auditions.[2][3] Known as a prolific performer in independent cinema, Park starred in the Korean Academy of Film Arts feature Ingtoogi: Battle of the Internet Trolls and the indie Steel Cold Winter, the latter of which drew notice when it premiered at the Busan International Film Festival. Park also took bit parts in mainstream titles Scarlet Innocence and The Royal Tailor.[4]

She broke into the mainstream in 2015 after making a strong impression with her performance in The Silenced, which nabbed her a win for Best Supporting Actress from the Busan Film Critics Awards.[3][5] She then featured in box office hits Veteran and The Throne, which led to her casting in the critically acclaimed mystery thriller The Priests.[6][7] Her role as an evil possessed high school student won her multiple Best New Actress nods.[8][9]

Park also extended her filmography to television. In 2016, she took the lead role in KBS2''s medical drama A Beautiful Mind[10] and tvN''s romantic comedy series Cinderella with Four Knights.[11]

In 2019, Park starred in Bong Joon-ho''s black comedy, Parasite.[12] The film received international critical acclaim and was a box office success in South Korea.[13] She gained recognition for her role as a crafty, whipsmart younger sister of the family, and became known for her "Jessica Jingle".[14]

In 2020, Park was cast in the youth drama A Record of Youth as an aspiring makeup artist.[15]', N'Park_So-dam.jpg', CAST(N'1991-09-08' AS Date), 3)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (11, N'Jung Ji-so', N'Hyun Seung-min (Korean: ???; born September 17, 1999), known professionally as Jung Ji-so (Korean: ???; sometimes romanized as Jung Ziso),[1] is a South Korean actress. Hyun made her acting debut as a child actress in the 2012 television drama May Queen.[2] She is best known internationally for her role as Park Da-hye in Parasite,[1] which won the Palme d''Or at the Cannes Film Festival and the Academy Award for Best Picture.', N'Jung_Ji-so.jpg', CAST(N'1999-09-17' AS Date), 3)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (12, N'Bong Joon-ho', N'Bong Joon-ho was born in Daegu, South Korea and is the youngest of four children.[8] His father, Bong Sang-gyun, was a first-generation graphic designer, industrial designer, and professor of art at Yeungnam University and the head of the art department at the National Film Institute; his mother, Park So-young, was a full-time housewife.[8][9] His father retired from Seoul Institute of Technology as a professor of design in 2007 and passed away in 2017. Bong''s maternal grandfather, Park Taewon, was an esteemed author during the Japanese colonial period, best known for his work A Day in the Life of Kubo the Novelist and his defection to North Korea in 1950.[8][10] His older brother, Bong Joon-soo, is an English professor at the Seoul National University; his older sister, Bong Ji-hee, teaches fashion styling at Anyang University.[9] Currently, Bong''s son, Bong Hyo-min, is also a film director.[11][12]

He wanted to be a film director ever since he was fourteen-years-old and was able to see his father always drawing when he was young. Naturally, Bong imitated his father and had the opportunity to practice comic and storyboarding since the age of five, including drawing and arranging cartoon shots. While he was in elementary school, the family relocated to Seoul, taking up residence in Jamsil-dong by the Han River.[10] In 1988, Bong enrolled in Yonsei University, majoring in sociology.[8] College campuses such as Yonsei''s were then hotbeds for the South Korean democracy movement; Bong was an active participant of student demonstrations, frequently subjected to tear gas early in his college years.[8][13] He served a two-year term in the military in accordance with South Korea''s compulsory military service before returning to college in 1992.[8] Bong later co-founded a film club named "Yellow Door" with students from neighboring universities.[8] As a member of the club, Bong made his first films, including a stop motion short titled Looking for Paradise and 16 mm film short titled Baeksaekin (White Man).[8] He graduated from Yonsei University in 1995.[8]

In the early 1990s, Bong completed a two-year program at the Korean Academy of Film Arts. While there, he made many 16 mm short films. His graduation films, Incoherence and Memories in My Frame, were invited to screen at the Hong Kong International Film Festival and Vancouver International Film Festival. Bong also collaborated on several works with his classmates, which included working as cinematographer on the highly acclaimed short 2001 Imagine (1994), directed by his friend Jang Joon-hwan. Aside from cinematography, Bong was also a lighting technician on two shorts—The Love of a Grape Seed and Sounds From Heaven and Earth—in 1994.[1] Eventually, he suffered severe hardships for more than ten years while working on film production. In his early stages as a film director, Bong received a meager salary of 1900 dollars per year (US$3800 = 4,500,000 won per two year). It was hard for him to make a living and he barely made enough to buy rice, so he had to borrow rice from his university''s alumni.', N'Bong_Joon-ho.jpg', CAST(N'1969-09-14' AS Date), 3)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (13, N'Tom Hanks', N'Thomas Jeffrey Hanks[8] was born in Concord, California, on July 9, 1956,[9][10] to hospital worker Janet Marylyn (née Frager, 1932–2016)[11] and itinerant cook Amos Mefford Hanks (1924–1992).[10][12][13] His mother was of Portuguese descent (her family''s surname was originally "Fraga"),[14] while his father had English ancestry.[15] His parents divorced in 1960. Their three oldest children, Sandra (later Sandra Hanks Benoiton, a writer),[16] Larry (an entomology professor at the University of Illinois at Urbana–Champaign),[17] and Tom, went with their father, while the youngest, Jim (who also became an actor and filmmaker), remained with their mother in Red Bluff, California.[18] In his childhood, Hanks'' family moved often; by the age of 10, he had lived in 10 different houses.[19]

While Hanks'' family religious history was Catholic and Mormon, he has characterized his teenage self as being a "Bible-toting evangelical" for several years.[20] In school, he was unpopular with students and teachers alike, later telling Rolling Stone magazine, "I was a geek, a spaz. I was horribly, painfully, terribly shy. At the same time, I was the guy who''d yell out funny captions during filmstrips. But I didn''t get into trouble. I was always a real good kid and pretty responsible."[21] In 1965, his father married Frances Wong, a San Francisco native of Chinese descent. Frances had three children, two of whom lived with Hanks during his high school years. Hanks acted in school plays, including South Pacific, while attending Skyline High School in Oakland, California.[22]

Hanks studied theater at Chabot College in Hayward, California,[23] and transferred to California State University, Sacramento after two years.[24][25] During a 2001 interview with sportscaster Bob Costas, Hanks was asked whether he would rather have an Oscar or a Heisman Trophy. He replied he would rather win a Heisman by playing halfback for the California Golden Bears.[26] He told New York magazine in 1986, "Acting classes looked like the best place for a guy who liked to make a lot of noise and be rather flamboyant. I spent a lot of time going to plays. I wouldn''t take dates with me. I''d just drive to a theater, buy myself a ticket, sit in the seat and read the program, and then get into the play completely. I spent a lot of time like that, seeing Brecht, Tennessee Williams, Ibsen, and all that."[27]

During his years studying theater, Hanks met Vincent Dowling, head of the Great Lakes Theater Festival in Cleveland, Ohio.[12] At Dowling''s suggestion, Hanks became an intern at the festival. His internship stretched into a three-year experience that covered most aspects of theater production, including lighting, set design, and stage management, prompting Hanks to drop out of college. During the same time, Hanks won the Cleveland Critics Circle Award for Best Actor for his 1978 performance as Proteus in Shakespeare''s The Two Gentlemen of Verona, one of the few times he played a villain.[28] In 2010, Time magazine named Hanks one of the "Top 10 College Dropouts."[29]', N'Tom_Hanks.jpg', CAST(N'1956-09-07' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (14, N'Tim Allen', N'Allen was born in Denver, Colorado, to Martha Katherine (née Fox), a community-service worker, and Gerald M. Dick, a real estate agent.[2][3] He is the third oldest of six children. Allen has two older brothers as well as two younger brothers and a younger sister. His father died in a car accident in November 1964, colliding with a drunk driver when Allen was 11.[2][4] Two years later, his mother married her high school sweetheart, a business executive,[3] and moved with her six children to Birmingham, Michigan, to be with her new husband and his three children.[5]

Allen attended Seaholm High School in Birmingham, where he was in theater and music classes (resulting in his love of classical piano). He then attended Central Michigan University before transferring to Western Michigan University in 1974.[6] At Western Michigan, Allen worked at the student radio station WIDR and received a Bachelor of Science degree in communications specializing in radio and television production in 1976 with a split minor in philosophy and design.[5] In 1998, Western Michigan awarded Allen an honorary fine arts degree and the Distinguished Alumni Award.[6]', N'Tim_Allen.jpg', CAST(N'1953-06-13' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (15, N'Annie Potts', N'Potts was born in Nashville, Tennessee,[2] as the third lady of Powell Grisette Potts (1919-2006) and Dorothy Harris (née Billingslea) Potts (1925-2010). Her older sisters are Mary Eleanor (Potts) Hovious and Elizabeth Grissette ("Dollie") Potts. They grew up in Franklin, Kentucky, where she graduated from Franklin-Simpson High School in 1970.

She received a bachelor in fine arts degree (in theater arts) from Stephens College in Columbia, Missouri. At the age of 21, Potts and her first husband, Steven Hartley, were in a car accident that left several bones below her waist broken,[3] including compound fractures to both legs, and the loss of the heel of her right foot; Hartley lost his left leg.[4][5]', N'Annie_Potts.jpg', CAST(N'1952-10-28' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (16, N'Josh Cooley', N'Cooley was recruited by Joe Ranft at the Pixar Animation Studios, where he started his career as an intern,[2][3] mostly working as a storyboard artist on films including The Incredibles in 2004, Cars in 2006, Ratatouille in 2007, Up in 2009, and Cars 2 in 2011.[4] In 2009, Cooley wrote and directed a short film George & A.J. for Pixar and Walt Disney Pictures.[4]

In 2015, Cooley worked as a screenwriter and storyboard supervisor on the film Inside Out, the film was released on June 19, 2015 by the Walt Disney Studios Motion Pictures. The film and its screenplay ended up receiving critical acclaim. Cooley ended up receiving an Academy Awards nomination for Best Original Screenplay for his work on the film, alongside screenwriters Pete Docter (also the film''s director), Meg LeFauve, and Ronnie Del Carmen (the co-director on the film).[5] The same year, he wrote and directed another short film titled Riley''s First Date?, which released along with the Inside Out''s Blu-ray.[6][5] Following the success of Inside Out in 2015, Cooley was tapped by then Chief Creative Officer of Pixar John Lasseter and screenwriter Andrew Stanton to co-direct Toy Story 4. Lasseter ended up setting aside his directorial duties in 2017, making Cooley the sole director. Toy Story 4 was Cooley''s sole directorial debut. Upon its release, the film received instant critical acclaim, and Cooley took home his very first Academy Award from the film in the category of Best Animated Film. Cooley is also a part of the Senior Creative Team at Pixar and his contributed his talents to films such as Onward and the upcoming Soul.[7] Cooley is set to direct an animated Transformers film at Paramount Pictures.[8] The film, which will be "separate and apart from" the Michael Bay-directed franchise and the stand-alone Bumblebee, will focus on Optimus Prime and Megatron''s relationship.[8]', N'Josh_Cooley.jpg', CAST(N'1980-05-23' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (17, N'Keanu Reeves', N'Keanu Charles Reeves was born in Beirut on September 2, 1964, as the son of Patricia (née Taylor), a costume designer and performer, and Samuel Nowlin Reeves Jr. His mother is English, originating from Essex.[5] Reeves Jr. is from Hawaii, and is of Chinese, English, Irish, Native Hawaiian, and Portuguese descent.[6][7][8][9][10] Reeves Jr. earned a GED while serving time in prison for selling heroin at Hilo International Airport.[11] His mother was working in Beirut when she met Reeves Jr.[12] He abandoned his wife and family when Reeves was 3 years old. Reeves last met his father on the island of Kauai when he was 13.[13][14]

After his parents divorced in 1966, his mother moved the family to Sydney,[15] and then to New York City, where she married Paul Aaron, a Broadway and Hollywood director, in 1970.[16] The couple moved to Toronto, Ontario, and divorced in 1971. When Reeves was 9, he participated in a theatre production of Damn Yankees.[17] At 15, he worked as a production assistant on Aaron''s films.[18] Reeves'' mother then married Robert Miller, a rock music promoter, in 1976; the couple divorced in 1980. She subsequently married her fourth husband, a hairdresser named Jack Bond, which lasted until 1994. Reeves and his sisters grew up primarily in the Yorkville neighborhood of Toronto, with grandparents and nannies caring for them.[19][20] Because of his grandmother''s descent, he grew up around Chinese art, furniture, and cuisine.[21] Reeves watched British comedy shows such as The Two Ronnies, and his mother imparted English manners that he has maintained into adulthood.[22]

Describing himself as a "private kid",[23] Reeves attended four different high schools, including the Etobicoke School of the Arts, from which he was expelled. Reeves stated he was expelled because he was "just a little too rambunctious and shot [his] mouth off once too often... [he] was not generally the most well-oiled machine in the school".[24] At De La Salle College, he was a successful ice hockey goalkeeper. Reeves had aspirations to become a professional ice hockey player for the Canadian Olympic team, but decided to become an actor when he was 15.[25] After leaving the college, he attended Avondale Secondary Alternative School, which allowed him to obtain an education while working as an actor. He dropped out of high school when he was 17.[26] He obtained a green card through his American stepfather and moved to Los Angeles three years later.[18] Reeves holds Canadian citizenship by naturalization.[4]', N'Keanu_Reeves.jpg', CAST(N'1964-09-02' AS Date), 4)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (18, N'Lance Reddick', N'Reddick was born in Baltimore, Maryland, the son of Dorothy Gee and Solomon Reddick.[1][2] He attended Friends School of Baltimore. As a teenager, he studied music at the Peabody Preparatory Institute and a summer program teaching music theory and composition at the Walden School.[3] After attending the Eastman School of Music at the University of Rochester, he moved to Boston, Massachusetts in the 1980s and enrolled in the Yale School of Drama in 1991.[4]', N'Lance_Reddick.jpg', CAST(N'1962-12-31' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (19, N'Chad Stahelski', N'Stahelski was a friend of Brandon Lee at Inosanto Academy. Lee died from a gunshot wound on March 31, 1993, after an accidental shooting on the set of The Crow. After Lee''s death, with only eight days left before wrap, his fiancée, Eliza Hutton, and his mother supported director Alex Proyas'' decision to complete the film. Only a few scenes requiring Lee remained unfinished, so the story was rewritten, and Stahelski and another stunt double, Jeff Cadiente, served as Lee''s double with special effects used to give them Lee''s face.

In 1997, Stahelski co-founded action design company 87Eleven with David Leitch.[1]

He worked as a stunt double for his future John Wick star Keanu Reeves in The Matrix franchise, and later served as a stunt co-ordinator for the films.[2] In 2009, Stahelski was second-unit director and stunt co-ordinator on Ninja Assassin along with David Leitch.

In 2014, Stahelski co-directed the action thriller film John Wick along with Leitch, based on the screenplay by Derek Kolstad. The film starred Keanu Reeves and Michael Nyqvist, and was released on October 24, 2014 by Summit Entertainment, grossing over $88 million.[3][4]

Stahelski acted as sole director for the film''s 2017 sequel, John Wick: Chapter 2,[5] and again for the third film, John Wick: Chapter 3 – Parabellum (2019).[6]

In 2019, Stahelski was the second unit director for the reshoots of Birds of Prey.[7]', N'Chad_Stahelski.jpg', CAST(N'1968-09-20' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (20, N'Leonardo DiCaprio', N'Leonardo Wilhelm DiCaprio was born on November 11, 1974 in Los Angeles, California,[1] the only child of Irmelin (née Indenbirken), a legal secretary, and George DiCaprio, an underground comix writer, publisher, and distributor of comic books.[2] DiCaprio''s father is of Italian and German descent, and the actor is conversant in Italian.[3][4] DiCaprio''s maternal grandfather, Wilhelm Indenbirken, was German,[5] and his maternal grandmother, Helene Indenbirken, was a Russian-born German citizen.[6][7] In an interview in Russia, DiCaprio referred to himself as "half-Russian" and said that two of his late grandparents were Russian.[6] DiCaprio''s parents met while attending college and moved to Los Angeles after graduating.[8]

A portrait of Leonardo da Vinci
DiCaprio was named after Italian polymath Leonardo da Vinci.[9]
DiCaprio was named Leonardo because his pregnant mother was looking at a Leonardo da Vinci painting in the Uffizi museum in Florence, Italy, when he first kicked.[9] His parents separated when he was a year old; they initially agreed to live next door to each other so as not to deprive DiCaprio of his father''s presence in his life.[10][11] However, DiCaprio and his mother later moved around to multiple Los Angeles neighborhoods, such as Echo Park and Los Feliz, while the latter worked several jobs.[8] He attended Seeds Elementary School and later went to John Marshall High School a few blocks away after attending the Los Angeles Center for Enriched Studies for four years.[12] DiCaprio has said he hated public school, and often asked his mother to take him to auditions instead to improve their financial situation.[13] He dropped out of high school following his third year, eventually earning his general equivalency diploma (GED).[14]', N'L_DiCaprio.jpg', CAST(N'1974-11-11' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (21, N'Brad Pitt', N'Pitt was born in Shawnee, Oklahoma, to William Alvin Pitt, the proprietor of a trucking company, and Jane Etta (née Hillhouse), a school counselor.[1][2] The family soon moved to Springfield, Missouri, where he lived together with his younger siblings, Douglas Mitchell (born 1966) and Julie Neal (born 1969).[3] Born into a conservative Christian household,[4][5] he was raised as Southern Baptist and later "oscillate[d] between agnosticism and atheism."[6] He later came back around to just belief in that "we''re all connected".[7] Pitt has described Springfield as "Mark Twain country, Jesse James country," having grown up with "a lot of hills, a lot of lakes."[8]

Pitt attended Kickapoo High School, where he was a member of the golf, swimming and tennis teams.[9] He participated in the school''s Key and Forensics clubs, in school debates, and in musicals.[10] Following his graduation from high school, Pitt enrolled in the University of Missouri in 1982, majoring in journalism with a focus on advertising.[11] As graduation approached, Pitt did not feel ready to settle down. He loved films—"a portal into different worlds for me"—and, since films were not made in Missouri, he decided to go to where they were made.[12][13] Two weeks short of completing the coursework for a degree, Pitt left the university and moved to Los Angeles, where he took acting lessons and worked odd jobs.[12] He has named his early acting heroes as Gary Oldman, Sean Penn and Mickey Rourke.[14]', N'Brad_Pitt.jpg', CAST(N'1963-12-18' AS Date), 1)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (23, N'Jay Baruchel', N'Baruchel was born in Ottawa, Ontario,[1][3] the son of Robyne (née Ropell), a freelance writer, and Serge Baruchel, an antiques dealer.[4][5] He grew up in the Notre-Dame-de-Grâce neighbourhood of Montreal, Quebec[6] and has a younger sister.[7] His paternal grandfather was a Sephardic Jew, while his three other grandparents were from a Christian background (of French, Irish, and German descent)', N'Jay_Baruchel.jpg', CAST(N'1982-04-09' AS Date), 5)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (24, N'Dean DeBlois', N'DeBlois was born in Brockville, Ontario, and raised in Aylmer, Quebec, Canada.[2] As a boy he was interested in comic books, which he later said influenced his drawing ability, imagination and storytelling. Growing up poor, he would visit a nearby a smoke shop on weekends, where the proprietor let him read comics for free. Memorizing them, he went home and drew.[3]', N'Dean_DeBlois.jpg', CAST(N'1970-06-07' AS Date), 5)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (25, N'Slavko Sobin', N'At 18 he moved to Los Angeles to study acting at the American Academy of Dramatic Arts'', where he graduated in 2007. Upon his return to Croatia, he moved to Zagreb and works as a freelance artist in several theaters: Merlin Theatre, Open University of Velika Gorica, DK Dubrava. In 2009 his first return to Split with the play ''Here he writes about the title of the drama Anti'' in him, but now the theater GKM, and ''Fisherman fights'' in the National Theatre in Split.[1][2][3][4] In 2015, he played a Meereenese fighter in the Game of Thrones episode "Sons of the Harpy."', N'Slavko_Sobin.jpg', CAST(N'1984-11-13' AS Date), 6)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (26, N'Adam Ferency', N'Adam Ferency (born 5 October 1951) is a Polish actor. He has appeared in more than 70 films and television shows since 1976. He starred in the 1990 film Burial of a Potato, which was screened in the Un Certain Regard section at the 1991 Cannes Film Festival.[1]', N'Adam_Ferency.jpg', CAST(N'1951-10-05' AS Date), 7)
INSERT [dbo].[celebrity] ([id], [name], [description], [avatar], [birthday], [country_id]) VALUES (28, N'Win Walker', N'My idol', N'101981290.jpg', CAST(N'1998-06-24' AS Date), 4)
SET IDENTITY_INSERT [dbo].[celebrity] OFF
SET IDENTITY_INSERT [dbo].[color] ON 

INSERT [dbo].[color] ([id], [color_name]) VALUES (1, N'blue')
INSERT [dbo].[color] ([id], [color_name]) VALUES (2, N'green')
INSERT [dbo].[color] ([id], [color_name]) VALUES (3, N'orange')
INSERT [dbo].[color] ([id], [color_name]) VALUES (4, N'yell')
SET IDENTITY_INSERT [dbo].[color] OFF
SET IDENTITY_INSERT [dbo].[country] ON 

INSERT [dbo].[country] ([id], [name]) VALUES (1, N'America')
INSERT [dbo].[country] ([id], [name]) VALUES (2, N'Germany')
INSERT [dbo].[country] ([id], [name]) VALUES (3, N'Korea')
INSERT [dbo].[country] ([id], [name]) VALUES (4, N'Lebanon')
INSERT [dbo].[country] ([id], [name]) VALUES (5, N'Canada')
INSERT [dbo].[country] ([id], [name]) VALUES (6, N'Croatia')
INSERT [dbo].[country] ([id], [name]) VALUES (7, N'Poland')
INSERT [dbo].[country] ([id], [name]) VALUES (8, N'England')
INSERT [dbo].[country] ([id], [name]) VALUES (9, N'China')
INSERT [dbo].[country] ([id], [name]) VALUES (10, N'Japan')
INSERT [dbo].[country] ([id], [name]) VALUES (11, N'France')
SET IDENTITY_INSERT [dbo].[country] OFF
SET IDENTITY_INSERT [dbo].[favorite] ON 

INSERT [dbo].[favorite] ([id], [user_id], [film_id], [created]) VALUES (32, 2, 12, CAST(N'2020-06-22 21:30:33.993' AS DateTime))
INSERT [dbo].[favorite] ([id], [user_id], [film_id], [created]) VALUES (35, 31, 8, CAST(N'2020-06-24 20:11:29.407' AS DateTime))
INSERT [dbo].[favorite] ([id], [user_id], [film_id], [created]) VALUES (36, 31, 14, CAST(N'2020-06-24 20:13:15.070' AS DateTime))
SET IDENTITY_INSERT [dbo].[favorite] OFF
SET IDENTITY_INSERT [dbo].[film] ON 

INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (1, N'Joker (2019)', CAST(N'2019-10-01' AS Date), N'joker.jpg', 13, N'JOKER has long been a legendary superhero of world cinema. But have you ever wondered where the Joker came from and what made the Joker a crime symbol of Gotham City? JOKER will be a unique view of the notorious villain of the DC Universe - an original story imbued, but clearly separated from familiar legends surrounding this iconic character.', CAST(N'2020-04-04 00:00:00.000' AS DateTime), 1, 5)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (2, N'Endgame (2019)', CAST(N'2019-04-24' AS Date), N'Endgame.jpg', 4, N'Avengers 4: Endgame (Avengers 4: Endgame) released in April 2019 will thoroughly solve the problems that have been outlined in the previous 22 movies of the Marvel Cinematic Universe (MCU). Two months later, Spider-Man 2 is a completely new start for the MCU.

After Thanos caused half of the universe to dissolve and make the Avengers a failure, surviving superheroes must participate in the final battle in Avengers: Endgame.', CAST(N'2020-04-04 00:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (3, N'Parasite (2019)', CAST(N'2019-05-30' AS Date), N'Parasite.jpg', 970, N'"Parasites" is a film directed by Bong Joon-ho directed around a poor family. The family lived in a shabby apartment in the basement of a rental housing area, electricity was cut, and struggled to eat every meal. Until one day, the eldest son was introduced as an English tutor to the daughter of a wealthy family. Overwhelmed by the property of the homeowner, he planned to bring his whole family into the rich but trustworthy house of this person, starting a "parasitic" life.', CAST(N'2020-04-04 00:00:00.000' AS DateTime), 1, 4)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (4, N'Toy Story (2019)', CAST(N'2019-06-20' AS Date), N'Toystory.jpg', 1, N'Exciting return of familiar toys like Woody, Buzz Lightyear, Jessie ... and two new characters will appear in Toy Story4: Ducky and Bunny!', CAST(N'2020-04-04 00:00:00.000' AS DateTime), 1, 4)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (5, N'John Wick 3 (2019)', CAST(N'2019-05-15' AS Date), N'John_Wick_3.jpg', 2, N'After becoming the "big prize" of the global assassin, super assassin John Wick must accompany the pet dog to flee. At $ 14 million, John Wick has become a lucrative target for any human head hunter.', CAST(N'2020-04-04 00:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (6, N'O. J. T. Hollywood', CAST(N'2019-07-24' AS Date), N'Hollywood.jpg', 3, N'Once upon a time in ... Hollywood was set in Los Angeles in 1969 with two main characters, Rick Dalton - former star of a Western TV series - and his long-time stuntman Cliff Booth. When new things come and replace the outdated guys like Rick and Cliff, they are forced to fight to survive and rebuild their careers. In the end, both had to rely on her beautiful neighbor, female actress Sharon Tate.', CAST(N'2020-04-04 00:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (7, N'H. T. Y. Dragon 3', CAST(N'2019-01-03' AS Date), N'Dragon_3.jpg', 1, N'After Hiccup created a peaceful world for dragons, Tooth Saw discovered a mysterious new friend. Hiccup has now become the leader of the whole village, carrying the burden of keeping everyone safe. Therefore, he cannot be forever swept away by endless adventures with Tooth Sún. And when danger strikes the village, both Hiccup and Rang have stood up, bravely defending their species.', CAST(N'2020-04-05 00:00:00.000' AS DateTime), 1, 0)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (8, N'Cold War (2018)', CAST(N'2018-06-08' AS Date), N'Cold_War.jpg', 50, N'This Polish-French-English co-production is directed by Polish-based Polish director Pawel Pawlikowski hoping to win the Golden Palm 2018. Cold War tells a love story in Europe in the 1950s between the two. different relatives. It is also Pawlikowski''s latest film after the Ida film won the Best Foreign Film Bafta Award in 2015.

The movie Cold War takes place in Poland after World War II, telling the love story of Zula (Joanna Kulig) - a young singer from the government choir - and Wiktor (Tomasz Kot) - a music director. Things got complicated when they had a tour in East Berlin (East Germany) and had the opportunity to defect.', CAST(N'2020-05-05 00:00:00.000' AS DateTime), 1, 4)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (9, N'Supergirl (Season 5)', CAST(N'2019-10-07' AS Date), N'Supergirl.jpg', 1, N'Supergirl part 5 continues to talk about 24-year-old girl Kara Zor - El, cousin of Superman. She escaped from Krypton after the explosion and stayed on earth as an ordinary girl named Kara Devengers. But then at age 24, Kara decided to use her supernatural abilities to become a superhero.', CAST(N'2020-04-04 00:00:00.000' AS DateTime), 2, 0)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (10, N'Outlander (Season 5)', CAST(N'2020-01-01' AS Date), N'Outlander.jpg', 2, N'When his friends and family gathered at the Fraser Ridge to attend a wedding, Governor Tryon forced Jamie to hunt down Murtagh and Brianna overheard ominous news.', CAST(N'2020-04-04 00:00:00.000' AS DateTime), 2, 0)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (12, N'Prodigal. Son (Season 1)', CAST(N'2019-03-03' AS Date), N'Prodigal_Son.jpg', 42, N'Malcom Bright is the son of a notorious psychic murderer in the United States, also one of New York''s best crime psychologists. With the intelligence and help of a criminal father, Malcom helps New York police solve bloody murder cases.', CAST(N'2020-05-05 00:00:00.000' AS DateTime), 2, 0)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (13, N'Killing Eve (Season 3)', CAST(N'2018-05-05' AS Date), N'Killing_Eve.jpg', 7, N'The series continues with the final episode of part two, agent MI6, Eve is shot down by Villanelle.', CAST(N'2020-05-05 00:00:00.000' AS DateTime), 2, 5)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (14, N'The Blacklist (Season 7)', CAST(N'2019-06-06' AS Date), N'The_Blacklist.jpg', 7, N'Former government agent Raymond "Red" Reddington (played by James Spader) was the FBI''s top wanted target in the decade suddenly coming to the FBI to voluntarily surrender, offering support to arrest the terrorist who thought died long ago - Ranko Zamani, with the condition of only talking to Elizabeth "Liz" Keen - a new FBI file. It started from there ...', CAST(N'2020-05-05 00:00:00.000' AS DateTime), 2, 4)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (15, N'City of Angels (Season 1)', CAST(N'2020-01-01' AS Date), N'CoAngels.jpg', 23, N'The series is set in the city of Los Angeles in 1938, after a bewildering murder of people, detective Tiago Vega gets caught up in a story that reflects its history. From the city''s glorious high-rise buildings and the deep traditions of Mexican Americans to the risky espionage acts of the Third Reich and the rise of the wave of missions.', CAST(N'2020-05-05 00:00:00.000' AS DateTime), 2, 5)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (16, N'Penny Dreadful (Season 1)', CAST(N'2014-09-09' AS Date), N'P_Dreadful.jpg', 23, N'The film will bring television viewers back to the Victorian city of London. At this time, characters only exist in literary novels such as Dorian Gray, Dr. Frankenstein and his monster, characters in the novel Dracula ... all exist alongside humans and are hiding in in the darkest street corners of London. The film brings together stars from different places, such as Josh Hartnett from the US, Eva Green from France, singer and actor Billie Piper and "former" spy 007 Timothy Dalton from the land of fog. The Penny Dreadful horror television series was penned by John Logan, the writer of the hugely successful Hugo and Skyfall.', CAST(N'2020-05-05 00:00:00.000' AS DateTime), 2, 0)
INSERT [dbo].[film] ([id], [name], [release], [image_link], [view_count], [description], [created], [form_id], [rate]) VALUES (25, N'The Mermaid (2016)', CAST(N'2016-02-08' AS Date), N'TheMermaid.jpg', 707, N'CHINESE FISH of Chau Tinh Tri is set in modern times. The film revolves around the love story between the San San mermaid and the successful young businessman Luu Hien. The film is not only humorous, it also has many human values about love, life and environmental protection.', CAST(N'2020-06-09 21:59:23.383' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[film] OFF
SET IDENTITY_INSERT [dbo].[film_category] ON 

INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (41, 1, 25)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (45, 1, 24)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (55, 2, 26)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (56, 2, 35)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (57, 3, 33)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (58, 3, 34)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (59, 4, 27)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (60, 4, 29)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (61, 5, 24)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (62, 5, 30)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (63, 6, 29)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (64, 6, 33)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (65, 7, 28)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (66, 7, 29)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (67, 8, 25)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (69, 8, 35)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (70, 9, 31)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (71, 9, 34)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (72, 10, 29)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (73, 10, 30)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (77, 13, 30)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (78, 13, 31)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (79, 14, 34)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (80, 14, 35)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (81, 15, 31)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (82, 15, 33)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (83, 16, 26)
INSERT [dbo].[film_category] ([id], [film_id], [category_id]) VALUES (84, 16, 27)
SET IDENTITY_INSERT [dbo].[film_category] OFF
SET IDENTITY_INSERT [dbo].[film_celebrity] ON 

INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (1, 1, 1, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (3, 1, 3, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (5, 2, 5, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (6, 2, 6, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (7, 2, 7, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (9, 3, 9, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (10, 3, 10, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (11, 3, 11, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (13, 4, 13, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (14, 4, 14, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (15, 4, 15, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (17, 5, 17, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (18, 5, 18, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (19, 5, 19, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (20, 6, 20, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (21, 6, 21, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (23, 7, 23, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (24, 7, 24, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (25, 8, 25, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (26, 8, 26, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (27, 9, 26, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (28, 9, 25, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (29, 10, 24, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (30, 10, 23, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (37, 13, 15, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (38, 13, 14, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (39, 13, 13, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (40, 14, 11, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (41, 14, 10, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (42, 14, 9, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (43, 15, 7, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (44, 15, 6, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (45, 15, 5, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (46, 16, 3, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (48, 16, 1, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (49, 1, 4, 3)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (50, 2, 8, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (51, 3, 12, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (52, 4, 15, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (53, 4, 16, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (54, 5, 19, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (56, 7, 24, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (57, 8, 26, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (58, 9, 26, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (59, 10, 24, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (62, 13, 16, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (63, 15, 12, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (64, 15, 8, 1)
INSERT [dbo].[film_celebrity] ([id], [film_id], [celeb_id], [role_id]) VALUES (65, 1, 4, 2)
SET IDENTITY_INSERT [dbo].[film_celebrity] OFF
SET IDENTITY_INSERT [dbo].[film_country] ON 

INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (1, 1, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (2, 1, 5)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (3, 2, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (4, 3, 3)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (5, 4, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (6, 5, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (7, 6, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (8, 6, 8)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (9, 6, 9)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (10, 7, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (11, 7, 2)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (12, 8, 7)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (13, 8, 8)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (14, 8, 11)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (15, 9, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (16, 10, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (19, 13, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (20, 14, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (21, 15, 1)
INSERT [dbo].[film_country] ([id], [film_id], [country_id]) VALUES (22, 16, 1)
SET IDENTITY_INSERT [dbo].[film_country] OFF
SET IDENTITY_INSERT [dbo].[form] ON 

INSERT [dbo].[form] ([id], [name]) VALUES (1, N'Movie     ')
INSERT [dbo].[form] ([id], [name]) VALUES (2, N'Drama     ')
SET IDENTITY_INSERT [dbo].[form] OFF
SET IDENTITY_INSERT [dbo].[job] ON 

INSERT [dbo].[job] ([id], [name]) VALUES (1, N'Director')
INSERT [dbo].[job] ([id], [name]) VALUES (2, N'Cast')
INSERT [dbo].[job] ([id], [name]) VALUES (3, N'Writer')
INSERT [dbo].[job] ([id], [name]) VALUES (4, N'Model')
SET IDENTITY_INSERT [dbo].[job] OFF
SET IDENTITY_INSERT [dbo].[position] ON 

INSERT [dbo].[position] ([id], [name]) VALUES (1, N'Admin')
INSERT [dbo].[position] ([id], [name]) VALUES (2, N'Hr Manager')
INSERT [dbo].[position] ([id], [name]) VALUES (3, N'Viewer')
SET IDENTITY_INSERT [dbo].[position] OFF
SET IDENTITY_INSERT [dbo].[review] ON 

INSERT [dbo].[review] ([id], [point], [title], [comment], [film_id], [user_id], [created]) VALUES (10, 4, N'Bean', N'ad', 4, 2, CAST(N'2020-06-06 09:00:24.443' AS DateTime))
INSERT [dbo].[review] ([id], [point], [title], [comment], [film_id], [user_id], [created]) VALUES (14, 4, N'nice movie for the lazy day', N'Avengers Age of Ultron is an excellent sequel and a worthy MCU title! There are a lot of good and one thing that feels off in my opinion.  THE GOOD:  First off the action in this movie is amazing, to buildings crumbling, to evil blue eyed robots tearing stuff up, this movie has the action perfectly handled. And with that action comes visuals. The visuals are really good, even though you can see clearly where they are through the movie, but that doesn''t detract from the experience. While all the CGI glory is taking place, there are lovable characters that are in the mix. First off the original characters, Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye, are just as brilliant as they are always. And Joss Whedon fixed my main problem in the first Avengers by putting in more Hawkeye and him more fleshed out. Then there is the new Avengers, Quicksilver, Scarletwich, and Vision, they are pretty cool in my opinion. Vision in particular is pretty amazing in all his scenes.  THE BAD:  The beginning of ', 8, 31, CAST(N'2020-06-24 20:07:41.377' AS DateTime))
INSERT [dbo].[review] ([id], [point], [title], [comment], [film_id], [user_id], [created]) VALUES (15, 4, N'Just about as good as the first one!', N'nice', 14, 31, CAST(N'2020-06-24 20:13:09.217' AS DateTime))
INSERT [dbo].[review] ([id], [point], [title], [comment], [film_id], [user_id], [created]) VALUES (16, 5, N'nice movie for the lazy day', N'Avengers Age of Ultron is an excellent sequel and a worthy MCU title! There are a lot of good and one thing that feels off in my opinion.  THE GOOD:  First off the action in this movie is amazing, to buildings crumbling, to evil blue eyed robots tearing stuff up, this movie has the action perfectly handled. And with that action comes visuals. The visuals are really good, even though you can see clearly where they are through the movie, but that doesn''t detract from the experience. While all the CGI glory is taking place, there are lovable characters that are in the mix. First off the original characters, Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye, are just as brilliant as they are always. And Joss Whedon fixed my main problem in the first Avengers by putting in more Hawkeye and him more fleshed out. Then there is the new Avengers, Quicksilver, Scarletwich, and Vision, they are pretty cool in my opinion. Vision in particular is pretty amazing in all his scenes.  THE BAD:  The beginning of ', 13, 2, CAST(N'2020-07-03 16:24:58.870' AS DateTime))
INSERT [dbo].[review] ([id], [point], [title], [comment], [film_id], [user_id], [created]) VALUES (17, 5, N'nice movie for the lazy day', N'Avengers Age of Ultron is an excellent sequel and a worthy MCU title! There are a lot of good and one thing that feels off in my opinion.  THE GOOD:  First off the action in this movie is amazing, to buildings crumbling, to evil blue eyed robots tearing stuff up, this movie has the action perfectly handled. And with that action comes visuals. The visuals are really good, even though you can see clearly where they are through the movie, but that doesn''t detract from the experience. While all the CGI glory is taking place, there are lovable characters that are in the mix. First off the original characters, Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye, are just as brilliant as they are always. And Joss Whedon fixed my main problem in the first Avengers by putting in more Hawkeye and him more fleshed out. Then there is the new Avengers, Quicksilver, Scarletwich, and Vision, they are pretty cool in my opinion. Vision in particular is pretty amazing in all his scenes.  THE BAD:  The beginning of ', 13, 2, CAST(N'2020-07-03 16:25:34.437' AS DateTime))
INSERT [dbo].[review] ([id], [point], [title], [comment], [film_id], [user_id], [created]) VALUES (18, 5, N'nice movie for the lazy day', N'Avengers Age of Ultron is an excellent sequel and a worthy MCU title! There are a lot of good and one thing that feels off in my opinion.  THE GOOD:  First off the action in this movie is amazing, to buildings crumbling, to evil blue eyed robots tearing stuff up, this movie has the action perfectly handled. And with that action comes visuals. The visuals are really good, even though you can see clearly where they are through the movie, but that doesn''t detract from the experience. While all the CGI glory is taking place, there are lovable characters that are in the mix. First off the original characters, Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye, are just as brilliant as they are always. And Joss Whedon fixed my main problem in the first Avengers by putting in more Hawkeye and him more fleshed out. Then there is the new Avengers, Quicksilver, Scarletwich, and Vision, they are pretty cool in my opinion. Vision in particular is pretty amazing in all his scenes.  THE BAD:  The beginning of ', 13, 2, CAST(N'2020-07-03 16:26:15.203' AS DateTime))
INSERT [dbo].[review] ([id], [point], [title], [comment], [film_id], [user_id], [created]) VALUES (19, 5, N'nice movie for the lazy day', N'Avengers Age of Ultron is an excellent sequel and a worthy MCU title! There are a lot of good and one thing that feels off in my opinion.  THE GOOD:  First off the action in this movie is amazing, to buildings crumbling, to evil blue eyed robots tearing stuff up, this movie has the action perfectly handled. And with that action comes visuals. The visuals are really good, even though you can see clearly where they are through the movie, but that doesn''t detract from the experience. While all the CGI glory is taking place, there are lovable characters that are in the mix. First off the original characters, Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye, are just as brilliant as they are always. And Joss Whedon fixed my main problem in the first Avengers by putting in more Hawkeye and him more fleshed out. Then there is the new Avengers, Quicksilver, Scarletwich, and Vision, they are pretty cool in my opinion. Vision in particular is pretty amazing in all his scenes.  THE BAD:  The beginning of ', 13, 2, CAST(N'2020-07-03 16:27:55.850' AS DateTime))
INSERT [dbo].[review] ([id], [point], [title], [comment], [film_id], [user_id], [created]) VALUES (20, 5, N'Just about as good as the first one!', N'Avengers Age of Ultron is an excellent sequel and a worthy MCU title! There are a lot of good and one thing that feels off in my opinion.  THE GOOD:  First off the action in this movie is amazing, to buildings crumbling, to evil blue eyed robots tearing stuff up, this movie has the action perfectly handled. And with that action comes visuals. The visuals are really good, even though you can see clearly where they are through the movie, but that doesn''t detract from the experience. While all the CGI glory is taking place, there are lovable characters that are in the mix. First off the original characters, Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye, are just as brilliant as they are always. And Joss Whedon fixed my main problem in the first Avengers by putting in more Hawkeye and him more fleshed out. Then there is the new Avengers, Quicksilver, Scarletwich, and Vision, they are pretty cool in my opinion. Vision in particular is pretty amazing in all his scenes.  THE BAD:  The beginning of ', 15, 2, CAST(N'2020-07-03 16:29:24.153' AS DateTime))
SET IDENTITY_INSERT [dbo].[review] OFF
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([id], [name], [display]) VALUES (1, N'Director', 1)
INSERT [dbo].[role] ([id], [name], [display]) VALUES (2, N'Writer', 1)
INSERT [dbo].[role] ([id], [name], [display]) VALUES (3, N'Cast', 1)
SET IDENTITY_INSERT [dbo].[role] OFF
SET IDENTITY_INSERT [dbo].[trailer] ON 

INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (1, N'JOKER - Final Trailer - Now Playing In Theaters', N'zAGVQLHvwOY', N'joker.jpg', 1)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (3, N'Parasite - Official Trailer (2019) Bong Joon Ho Film', N'5xH0HfJHsaY', N'parasite.jpg', 1)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (6, N'JOKER - Final Trailer - Now Playing In Theaters', N'zAGVQLHvwOY', N'joker.jpg', 2)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (7, N'Marvel Studios'' Avengers: Endgame - Official Trailer', N'TcMBFSGVi1c', N'endgame.jpg', 3)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (8, N'Parasite - Official Trailer (2019) Bong Joon Ho Film', N'5xH0HfJHsaY', N'parasite.jpg', 4)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (9, N'Toy Story 4 - Trailer (2019) Disney Movie Trailer HD', N'wmiIUN-7qhE', N'toystory.jpg', 5)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (10, N'John Wick: Chapter 3 - Parabellum (2019) New Trailer', N'pU8-7BX9uxs', N'johnwick.jpg', 6)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (11, N'JOKER - Final Trailer - Now Playing In Theaters', N'zAGVQLHvwOY', N'joker.jpg', 7)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (12, N'Marvel Studios'' Avengers: Endgame - Official Trailer', N'TcMBFSGVi1c', N'endgame.jpg', 8)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (13, N'Parasite - Official Trailer (2019) Bong Joon Ho Film', N'5xH0HfJHsaY', N'parasite.jpg', 9)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (14, N'Toy Story 4 - Trailer (2019) Disney Movie Trailer HD', N'wmiIUN-7qhE', N'toystory.jpg', 10)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (16, N'JOKER - Final Trailer - Now Playing In Theaters', N'zAGVQLHvwOY', N'joker.jpg', 13)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (17, N'Marvel Studios'' Avengers: Endgame - Official Trailer', N'TcMBFSGVi1c', N'endgame.jpg', 14)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (18, N'Parasite - Official Trailer (2019) Bong Joon Ho Film', N'5xH0HfJHsaY', N'parasite.jpg', 15)
INSERT [dbo].[trailer] ([id], [name], [source], [image_link], [film_id]) VALUES (19, N'Toy Story 4 - Trailer (2019) Disney Movie Trailer HD', N'wmiIUN-7qhE', N'toystory.jpg', 16)
SET IDENTITY_INSERT [dbo].[trailer] OFF
SET IDENTITY_INSERT [dbo].[userr] ON 

INSERT [dbo].[userr] ([id], [email], [password], [first_name], [last_name], [created]) VALUES (2, N'ChiHao98@gmail.com', N'Efgh@765483', N'hao', N'phan', CAST(N'2020-06-06 00:00:00.000' AS DateTime))
INSERT [dbo].[userr] ([id], [email], [password], [first_name], [last_name], [created]) VALUES (31, N'jonhtheo@hotmail.com', N'JonhTheo@12345', N'Jonh', N'Theo', CAST(N'2020-06-24 20:05:51.947' AS DateTime))
INSERT [dbo].[userr] ([id], [email], [password], [first_name], [last_name], [created]) VALUES (32, N'Tranhoi.8198@gmail.com', N'AZRel@abas', N'tran', N'hoi', NULL)
SET IDENTITY_INSERT [dbo].[userr] OFF
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
REFERENCES [dbo].[userr] ([id])
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
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_dbRate_tbFilm] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_dbRate_tbFilm]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_review_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[userr] ([id])
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
