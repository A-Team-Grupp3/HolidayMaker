USE [master]
GO
/****** Object:  Database [HolidayMakerGrupp2]    Script Date: 2021-05-10 13:46:16 ******/
CREATE DATABASE [HolidayMakerGrupp2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HolidayMakerGrupp2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HolidayMakerGrupp2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HolidayMakerGrupp2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HolidayMakerGrupp2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HolidayMakerGrupp2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HolidayMakerGrupp2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HolidayMakerGrupp2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET ARITHABORT OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET  MULTI_USER 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HolidayMakerGrupp2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HolidayMakerGrupp2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HolidayMakerGrupp2] SET QUERY_STORE = OFF
GO
USE [HolidayMakerGrupp2]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accomodation]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accomodation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
	[NrOfRooms] [int] NOT NULL,
	[Pool] [bit] NOT NULL,
	[NightEntertainment] [bit] NOT NULL,
	[KidsClub] [bit] NOT NULL,
	[Restaurants] [bit] NOT NULL,
	[DistanceBeach] [float] NOT NULL,
	[DistanceDowntown] [float] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Accomodations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[BookingDate] [datetime] NOT NULL,
	[ArrivalDate] [datetime] NOT NULL,
	[DepartureDate] [datetime] NOT NULL,
	[AccomodationsId] [int] NOT NULL,
	[TransportationId] [int] NOT NULL,
	[NrOfGuests] [int] NOT NULL,
	[NrOfKids] [int] NOT NULL,
	[ExtraBed] [bit] NOT NULL,
	[ComfortId] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comfort]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comfort](
	[Name] [varchar](max) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Comfort] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](max) NOT NULL,
	[Lastname] [varchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[PhoneNr] [varchar](max) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[City] [varchar](max) NOT NULL,
	[Zipcode] [int] NOT NULL,
	[GuID] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[Id] [int] NOT NULL,
	[BookingId] [int] NOT NULL,
	[TransportationId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AccomodationsId] [int] NOT NULL,
	[Review] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [float] NOT NULL,
	[NrOfBeds] [int] NOT NULL,
	[AccomodationsId] [int] NOT NULL,
	[RoomType] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomInBooking]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomInBooking](
	[BookingId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
 CONSTRAINT [PK_RoomInBooking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC,
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transportation]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Departure] [varchar](max) NOT NULL,
	[Destination] [varchar](max) NOT NULL,
	[Price] [varchar](max) NOT NULL,
	[TransportType] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Transportation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlist]    Script Date: 2021-05-10 13:46:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlist](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AccomodationsId] [int] NOT NULL,
 CONSTRAINT [PK_Wishlist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accomodation] ON 

INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (1, 1, 5, 0, 1, 0, 1, 1.2, 0.5, N'Blablabla')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (2, 1, 10, 1, 1, 0, 1, 1.5, 0.5, N'Malmö Stadshotell')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (3, 1, 10, 0, 0, 0, 1, 0.5, 2, N'Malmö LIve')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (4, 2, 10, 1, 1, 1, 1, 7, 1, N'Kalmar Slott')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (5, 2, 10, 0, 1, 0, 1, 8, 2, N'Kalmar Fängelse')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (6, 3, 10, 0, 0, 0, 1, 1, 0.5, N'Hotell Knaust')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (7, 4, 10, 1, 0, 0, 1, 1, 2, N'Igloo Housing')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (8, 4, 10, 1, 1, 0, 1, 2, 0.5, N'Björneborg Stadshotell')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (9, 4, 10, 0, 1, 0, 1, 0.5, 1, N'Björneborg Strandhotell')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (10, 5, 10, 0, 1, 0, 1, 0.5, 1, N'FinlandAirBnB')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (11, 5, 10, 1, 1, 1, 1, 2, 0.5, N'Tammerfors Motel')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (12, 6, 10, 1, 0, 0, 0, 5, 2, N'Kantlax Hostel')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (13, 6, 10, 0, 0, 1, 1, 1.5, 1, N'Kantlax Beach Hotell')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (14, 2, 5, 1, 0, 1, 0, 2.1, 1.3, N'Blabla')
INSERT [dbo].[Accomodation] ([Id], [CityId], [NrOfRooms], [Pool], [NightEntertainment], [KidsClub], [Restaurants], [DistanceBeach], [DistanceDowntown], [Name]) VALUES (15, 3, 5, 1, 1, 1, 1, 0.3, 0.9, N'Bla')
SET IDENTITY_INSERT [dbo].[Accomodation] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Id], [CustomerId], [BookingDate], [ArrivalDate], [DepartureDate], [AccomodationsId], [TransportationId], [NrOfGuests], [NrOfKids], [ExtraBed], [ComfortId], [TotalPrice]) VALUES (4, 2, CAST(N'2021-05-07T15:00:20.817' AS DateTime), CAST(N'2021-06-11T11:23:02.000' AS DateTime), CAST(N'2021-06-21T12:00:00.000' AS DateTime), 3, 1, 0, 0, 0, 4, 7500)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [Name]) VALUES (1, N'Malmö')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (2, N'Sundsvall')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (3, N'Kalmar')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (4, N'Björneborg')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (5, N'Tammerfors')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (6, N'Kantlax')
INSERT [dbo].[Cities] ([Id], [Name]) VALUES (7, N'Halmstad')
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET IDENTITY_INSERT [dbo].[Comfort] ON 

INSERT [dbo].[Comfort] ([Name], [Id]) VALUES (N'Självhushåll', 1)
INSERT [dbo].[Comfort] ([Name], [Id]) VALUES (N'Halvpension', 2)
INSERT [dbo].[Comfort] ([Name], [Id]) VALUES (N'Helpension', 3)
INSERT [dbo].[Comfort] ([Name], [Id]) VALUES (N'All inclusive', 4)
SET IDENTITY_INSERT [dbo].[Comfort] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Firstname], [Lastname], [Email], [PhoneNr], [Address], [City], [Zipcode], [GuID]) VALUES (2, N'Anton', N'Bajs', N'anton.carl@bajs.com', N'123456789', N'Bajsvägen 2', N'Malmö', 12345, N'9855cf67-a15a-42ff-9b21-31bacfa2f92b')
INSERT [dbo].[Customer] ([Id], [Firstname], [Lastname], [Email], [PhoneNr], [Address], [City], [Zipcode], [GuID]) VALUES (3, N'Elin', N'Elin', N'elin.elin@bajs.com', N'123456789', N'Bajsvägen 2', N'Malmö', 12355, N'bad55201-b03f-4725-993d-8c640e7001e8')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES (1, 500, 1, 1, N'Garderob')
INSERT [dbo].[Room] ([Id], [Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES (2, 1000, 1, 2, N'Enkelrum')
INSERT [dbo].[Room] ([Id], [Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES (3, 1250, 2, 3, N'Dubbelrum')
INSERT [dbo].[Room] ([Id], [Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES (4, 3000, 3, 1, N'Familjerum')
INSERT [dbo].[Room] ([Id], [Price], [NrOfBeds], [AccomodationsId], [RoomType]) VALUES (5, 5000, 4, 2, N'Löfvensuite')
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Transportation] ON 

INSERT [dbo].[Transportation] ([Id], [Departure], [Destination], [Price], [TransportType]) VALUES (1, N'Juni 11', N'Någonstans', N'500', N'Katapullt')
SET IDENTITY_INSERT [dbo].[Transportation] OFF
GO
ALTER TABLE [dbo].[Accomodation]  WITH CHECK ADD  CONSTRAINT [FK_Accomodations_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Accomodation] CHECK CONSTRAINT [FK_Accomodations_Cities]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Accomodations] FOREIGN KEY([AccomodationsId])
REFERENCES [dbo].[Accomodation] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Accomodations]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Comfort] FOREIGN KEY([ComfortId])
REFERENCES [dbo].[Comfort] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Comfort]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Transportation] FOREIGN KEY([TransportationId])
REFERENCES [dbo].[Transportation] ([Id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Transportation]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Booking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Booking] ([Id])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipts_Booking]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipts_Customer]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Transportation] FOREIGN KEY([TransportationId])
REFERENCES [dbo].[Transportation] ([Id])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipts_Transportation]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Accomodations] FOREIGN KEY([AccomodationsId])
REFERENCES [dbo].[Accomodation] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Accomodations]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Customer]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Accomodations] FOREIGN KEY([AccomodationsId])
REFERENCES [dbo].[Accomodation] ([Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Accomodations]
GO
ALTER TABLE [dbo].[RoomInBooking]  WITH CHECK ADD  CONSTRAINT [FK_RoomInBooking_Booking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Booking] ([Id])
GO
ALTER TABLE [dbo].[RoomInBooking] CHECK CONSTRAINT [FK_RoomInBooking_Booking]
GO
ALTER TABLE [dbo].[RoomInBooking]  WITH CHECK ADD  CONSTRAINT [FK_RoomInBooking_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[RoomInBooking] CHECK CONSTRAINT [FK_RoomInBooking_Room]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Accomodations] FOREIGN KEY([AccomodationsId])
REFERENCES [dbo].[Accomodation] ([Id])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Accomodations]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Customer]
GO
USE [master]
GO
ALTER DATABASE [HolidayMakerGrupp2] SET  READ_WRITE 
GO
