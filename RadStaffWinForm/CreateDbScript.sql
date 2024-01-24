USE [master]
GO
/****** Object:  Database [RadfordsEvaluationProject]    Script Date: 24/01/2024 3:23:27 pm ******/
CREATE DATABASE [RadfordsEvaluationProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RadfordsEvaluationProject', FILENAME = N'C:\SQL2022Data\RadfordsEvaluationProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RadfordsEvaluationProject_log', FILENAME = N'C:\SQL2022Data\RadfordsEvaluationProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [RadfordsEvaluationProject] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RadfordsEvaluationProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RadfordsEvaluationProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET RECOVERY FULL 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET  MULTI_USER 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RadfordsEvaluationProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RadfordsEvaluationProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RadfordsEvaluationProject', N'ON'
GO
ALTER DATABASE [RadfordsEvaluationProject] SET QUERY_STORE = ON
GO
ALTER DATABASE [RadfordsEvaluationProject] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RadfordsEvaluationProject]
GO
/****** Object:  Table [dbo].[StaffMember]    Script Date: 24/01/2024 3:23:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffMember](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[StaffTitle] [varchar](5) NOT NULL,
	[StaffFirstName] [varchar](50) NOT NULL,
	[StaffLastName] [varchar](50) NOT NULL,
	[StaffMiddleInitial] [varchar](3) NOT NULL,
	[StaffHomePhone] [varchar](25) NULL,
	[StaffCellPhone] [varchar](25) NOT NULL,
	[StaffOfficeExtension] [varchar](5) NOT NULL,
	[StaffIRDNumber] [varchar](9) NOT NULL,
	[StaffStatusID] [int] NOT NULL,
	[StaffTypeID] [int] NOT NULL,
	[StaffManagerID] [int] NULL,
 CONSTRAINT [PK_StaffMember] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffStatus]    Script Date: 24/01/2024 3:23:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffStatus](
	[StaffStatusID] [int] IDENTITY(1,1) NOT NULL,
	[StaffStatusDescription] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StaffStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffType]    Script Date: 24/01/2024 3:23:27 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffType](
	[StaffTypeID] [int] IDENTITY(1,1) NOT NULL,
	[StaffTypeDescription] [varchar](10) NOT NULL,
 CONSTRAINT [PK_StaffType] PRIMARY KEY CLUSTERED 
(
	[StaffTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StaffMember]  WITH CHECK ADD  CONSTRAINT [FK_StaffMember_StaffManager] FOREIGN KEY([StaffManagerID])
REFERENCES [dbo].[StaffMember] ([StaffID])
GO
ALTER TABLE [dbo].[StaffMember] CHECK CONSTRAINT [FK_StaffMember_StaffManager]
GO
ALTER TABLE [dbo].[StaffMember]  WITH CHECK ADD  CONSTRAINT [FK_StaffMember_StaffStatus] FOREIGN KEY([StaffStatusID])
REFERENCES [dbo].[StaffStatus] ([StaffStatusID])
GO
ALTER TABLE [dbo].[StaffMember] CHECK CONSTRAINT [FK_StaffMember_StaffStatus]
GO
ALTER TABLE [dbo].[StaffMember]  WITH CHECK ADD  CONSTRAINT [FK_StaffMember_StaffType] FOREIGN KEY([StaffTypeID])
REFERENCES [dbo].[StaffType] ([StaffTypeID])
GO
ALTER TABLE [dbo].[StaffMember] CHECK CONSTRAINT [FK_StaffMember_StaffType]
GO
USE [master]
GO
ALTER DATABASE [RadfordsEvaluationProject] SET  READ_WRITE 
GO
