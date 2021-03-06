USE [UmojaSchool]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Voucher](
	[VOUCHER_ID] [bigint] IDENTITY(100,1) NOT NULL,
	[User_ID] [bigint] NOT NULL,
	[Voucher_Type] [varchar](50) NULL,
	[Voucher_Date] [datetime] NULL,
	[Rec_Paid_ID] [bigint] NOT NULL,
	[CashBank_ID] [bigint] NOT NULL,
	[ReceiptChqNo] [varchar](150) NULL,
	[ChequeDate] [datetime] NULL,
	[PayAmount] [float] NULL,
	[RecAmount] [float] NULL,
	[Narration] [varchar](max) NULL,
	[BankReconciliation] [varchar](1) NULL,
	[Approval] [varchar](1) NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[VOUCHER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTrail]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserTrail](
	[Audit_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[User_ID] [bigint] NOT NULL,
	[Date] [datetime] NULL,
	[Action] [varchar](250) NULL,
	[Timex] [varchar](250) NULL,
	[Log_ID] [bigint] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](50) NULL,
	[password] [varchar](max) NULL,
	[full_name] [varchar](150) NULL,
	[contact_no] [varchar](150) NULL,
	[e_mail] [varchar](150) NULL,
	[status] [varchar](1) NULL,
	[UserPicture] [image] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLog]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLog](
	[Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[User_ID] [bigint] NOT NULL,
	[Log_In] [varchar](50) NULL,
	[Log_Out] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Subject](
	[SUBJECT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SubjectCode] [varchar](150) NULL,
	[SubjectName] [varchar](150) NULL,
	[CLASS_ID] [bigint] NOT NULL,
	[BATCH_ID] [bigint] NOT NULL,
	[SCHOOL_ID] [bigint] NOT NULL,
	[Sub_Order] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SUBJECT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentResult]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentResult](
	[RESULT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[STUDENT_ID] [bigint] NOT NULL,
	[SCHOOL_ID] [bigint] NOT NULL,
	[BATCH_ID] [bigint] NOT NULL,
	[CLASS_ID] [bigint] NOT NULL,
	[EXAM_ID] [bigint] NOT NULL,
	[SUBJECT_ID] [bigint] NOT NULL,
	[TheoryMarks] [float] NULL,
	[PracticalMarks] [float] NULL,
	[TotalMarks] [float] NULL,
	[Credit] [float] NULL,
	[Grade] [varchar](50) NULL,
	[GradePoint] [float] NULL,
	[ResultStatus] [varchar](50) NULL,
	[EntryDateTime] [datetime] NULL,
	[User_ID] [bigint] NOT NULL,
	[MaxTheoryMarks] [float] NULL,
	[MaxPracticalMarks] [float] NULL,
	[MaxTotalMarks] [float] NULL,
 CONSTRAINT [PK_StudentResult] PRIMARY KEY CLUSTERED 
(
	[RESULT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentParentDetails]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentParentDetails](
	[STUDENT_ID] [bigint] NULL,
	[FathersName] [varchar](150) NULL,
	[FathersOccupation] [varchar](150) NULL,
	[FathersMonthlyIncome] [varchar](150) NULL,
	[MothersName] [varchar](150) NULL,
	[MothersOccupation] [varchar](150) NULL,
	[MothersMonthlyIncome] [varchar](150) NULL,
	[ContactNo] [varchar](150) NULL,
	[Address] [varchar](max) NULL,
	[Email] [varchar](150) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentLedger]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentLedger](
	[STU_LED_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[STUDENT_ID] [bigint] NOT NULL,
	[FEES_ID] [bigint] NOT NULL,
	[EntryDate] [datetime] NULL,
	[EntryTime] [varchar](50) NULL,
	[User_ID] [bigint] NOT NULL,
	[Debit] [float] NULL,
	[Credit] [float] NULL,
	[Narration] [varchar](max) NULL,
	[Month] [varchar](50) NULL,
	[PayMode] [varchar](50) NULL,
 CONSTRAINT [PK_StudentLedger] PRIMARY KEY CLUSTERED 
(
	[STU_LED_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentLastAttended]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentLastAttended](
	[AUTO_ID_LST_ACA] [bigint] IDENTITY(1,1) NOT NULL,
	[STUDENT_ID] [bigint] NOT NULL,
	[SchoolName] [varchar](250) NULL,
	[ClassName] [varchar](150) NULL,
	[PassYear] [varchar](50) NULL,
	[Result] [varchar](150) NULL,
	[Board] [varchar](250) NULL,
 CONSTRAINT [PK_StudentLastAttended] PRIMARY KEY CLUSTERED 
(
	[AUTO_ID_LST_ACA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentInformation]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentInformation](
	[STUDENT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AdmissionNo] [varchar](250) NULL,
	[AdmisionDate] [datetime] NULL,
	[SCHOOL_ID] [bigint] NOT NULL,
	[CLASS_ID] [bigint] NOT NULL,
	[BATCH_ID] [bigint] NOT NULL,
	[StudentName] [varchar](250) NOT NULL,
	[Gender] [varchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[PresentAddress] [varchar](max) NULL,
	[PermanentAddress] [varchar](max) NULL,
	[Nationality] [varchar](100) NULL,
	[ContactNO] [varchar](150) NULL,
	[Email] [varchar](100) NULL,
	[Religion] [varchar](50) NULL,
	[BloodGroup] [varchar](50) NULL,
	[Height] [float] NULL,
	[Weight] [float] NULL,
	[SpecialNote] [varchar](max) NULL,
	[ReferenceName] [varchar](150) NULL,
	[ReferenceContactNo] [varchar](150) NULL,
	[Status] [varchar](2) NOT NULL,
	[StudentPicture] [image] NULL,
 CONSTRAINT [PK_StudentInformation] PRIMARY KEY CLUSTERED 
(
	[STUDENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentHostelFacilities]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentHostelFacilities](
	[AUTO_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[STUDENT_ID] [bigint] NOT NULL,
	[BED_ID] [bigint] NOT NULL,
	[BookDate] [datetime] NULL,
	[Active] [varchar](1) NULL,
 CONSTRAINT [PK_StudentHostelFacilities] PRIMARY KEY CLUSTERED 
(
	[AUTO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentEndorsement]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentEndorsement](
	[AUTO_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[STUDENT_ID] [bigint] NOT NULL,
	[ENDORSEMENT_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_StudentEndorsement] PRIMARY KEY CLUSTERED 
(
	[AUTO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SMS_Recipt]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMS_Recipt](
	[RECIPT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Mobile_No] [varchar](150) NULL,
	[Status] [nvarchar](max) NULL,
	[Trash] [varchar](1) NULL,
 CONSTRAINT [PK_SMS_Recipt] PRIMARY KEY CLUSTERED 
(
	[RECIPT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SMS_Parameter]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMS_Parameter](
	[PARAM_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[URL_Parameter] [nvarchar](max) NULL,
 CONSTRAINT [PK_SMS_Parameter] PRIMARY KEY CLUSTERED 
(
	[PARAM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SMS]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMS](
	[SMS_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SMS_BODY] [nvarchar](max) NULL,
 CONSTRAINT [PK_SMS] PRIMARY KEY CLUSTERED 
(
	[SMS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolInformation]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SchoolInformation](
	[SCHOOL_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[School_Name] [varchar](250) NULL,
	[Address] [varchar](250) NULL,
	[Contact_No] [varchar](250) NULL,
	[FAX] [varchar](250) NULL,
	[Email] [varchar](250) NULL,
	[Web] [varchar](250) NULL,
	[SCH_LOGO] [image] NULL,
 CONSTRAINT [PK_SchoolInformation] PRIMARY KEY CLUSTERED 
(
	[SCHOOL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SchoolFees]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SchoolFees](
	[FEES_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Fee_Type] [varchar](150) NULL,
	[SCHOOL_ID] [bigint] NOT NULL,
	[CLASS_ID] [bigint] NOT NULL,
	[Month] [varchar](50) NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_SchoolFees] PRIMARY KEY CLUSTERED 
(
	[FEES_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SchoolBus]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SchoolBus](
	[BUS_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Bus_no] [varchar](150) NULL,
	[Driver_Name] [varchar](150) NULL,
	[Driver_Contact] [varchar](150) NULL,
	[Supervisor] [varchar](150) NULL,
	[SupervisorContact] [varchar](150) NULL,
 CONSTRAINT [PK_SchoolBus] PRIMARY KEY CLUSTERED 
(
	[BUS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[ROOM_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[HOSTEL_ID] [bigint] NOT NULL,
	[RoomName] [varchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[ROOM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Promotion](
	[PROMO_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FORM_SCHOOL_ID] [bigint] NOT NULL,
	[FROM_CLASS_ID] [bigint] NOT NULL,
	[FROM_BATCH_ID] [bigint] NOT NULL,
	[TO_SCHOOL_ID] [bigint] NOT NULL,
	[TO_CLASS_ID] [bigint] NOT NULL,
	[TO_BATCH_ID] [bigint] NOT NULL,
	[STUDENT_ID] [bigint] NOT NULL,
	[User_ID] [bigint] NOT NULL,
	[Year] [int] NULL,
	[Activity] [varchar](50) NULL,
 CONSTRAINT [PK_Promotion] PRIMARY KEY CLUSTERED 
(
	[PROMO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[permission]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permission](
	[User_ID] [bigint] NOT NULL,
	[AccessKey] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nationality]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nationality](
	[NATION_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nationality] [varchar](150) NULL,
 CONSTRAINT [PK_Nationality] PRIMARY KEY CLUSTERED 
(
	[NATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdentityCard]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityCard](
	[IDN] [bigint] IDENTITY(1,1) NOT NULL,
	[SCHOOL_ID] [bigint] NOT NULL,
	[CLASS_ID] [bigint] NOT NULL,
	[BATCH_ID] [bigint] NOT NULL,
	[STUDENT_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_IdentityCard] PRIMARY KEY CLUSTERED 
(
	[IDN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HostelInfo]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HostelInfo](
	[HOSTEL_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[HostelName] [varchar](200) NULL,
	[Address] [varchar](250) NULL,
	[SuperName] [varchar](150) NULL,
	[PhoneNo] [varchar](150) NULL,
 CONSTRAINT [PK_HostelInfo] PRIMARY KEY CLUSTERED 
(
	[HOSTEL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HostelFee]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HostelFee](
	[HOS_FEE_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[HosFeeName] [varchar](150) NULL,
	[CLASS_ID] [bigint] NOT NULL,
	[HOSTEL_ID] [bigint] NOT NULL,
	[SCHOOL_ID] [bigint] NOT NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_HostelFee] PRIMARY KEY CLUSTERED 
(
	[HOS_FEE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Holiday]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Holiday](
	[HOLIDAY_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](150) NULL,
	[HolidayDate] [datetime] NULL,
 CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED 
(
	[HOLIDAY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GradingLevel]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GradingLevel](
	[GRADE_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Grade] [varchar](150) NULL,
	[MarkFrom] [float] NULL,
	[MarkTo] [float] NULL,
	[GPA] [varchar](50) NULL,
	[Status] [varchar](150) NULL,
 CONSTRAINT [PK_GradingLevel] PRIMARY KEY CLUSTERED 
(
	[GRADE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Examination]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Examination](
	[EXAM_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ExaminationName] [varchar](50) NULL,
	[HeldDate] [datetime] NULL,
	[ResultPublishDate] [datetime] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[SuperName] [varchar](200) NULL,
	[Status] [varchar](5) NULL,
 CONSTRAINT [PK_Examination] PRIMARY KEY CLUSTERED 
(
	[EXAM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Endorsement]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Endorsement](
	[ENDORSEMENT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Endorsement] [varchar](150) NULL,
 CONSTRAINT [PK_Endorsement] PRIMARY KEY CLUSTERED 
(
	[ENDORSEMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeLedger]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeLedger](
	[EMP_LED_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[User_ID] [bigint] NOT NULL,
	[EntryDate] [datetime] NULL,
	[Month] [varchar](50) NULL,
	[PostingType] [varchar](50) NULL,
	[Debit] [float] NULL,
	[Credit] [float] NULL,
	[Narration] [varchar](max) NULL,
 CONSTRAINT [PK_EmployeeLedger] PRIMARY KEY CLUSTERED 
(
	[EMP_LED_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [bigint] IDENTITY(1,1) NOT NULL,
	[AC_ID] [bigint] NOT NULL,
	[EmployeeName] [varchar](250) NULL,
	[FathersName] [varchar](250) NULL,
	[MothersName] [varchar](250) NULL,
	[Gender] [varchar](150) NULL,
	[BloodGroup] [varchar](150) NULL,
	[DateOfBirth] [datetime] NULL,
	[Religion] [varchar](150) NULL,
	[Nationality] [varchar](150) NULL,
	[Address] [varchar](max) NULL,
	[ContactNo] [varchar](150) NULL,
	[Email] [varchar](150) NULL,
	[JoiningDate] [datetime] NULL,
	[Status] [varchar](1) NULL,
	[SCHOOL_ID] [bigint] NOT NULL,
	[DEPARTMENT_ID] [bigint] NOT NULL,
	[DESIGNATION_ID] [bigint] NOT NULL,
	[EmployeePicture] [image] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[eMailSetting]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eMailSetting](
	[MAIL_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[eMail] [varchar](150) NULL,
	[smtp_client] [varchar](150) NULL,
	[user_name] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[port] [varchar](50) NULL,
 CONSTRAINT [PK_eMailSetting] PRIMARY KEY CLUSTERED 
(
	[MAIL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[eMailRecipt]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eMailRecipt](
	[RECIPT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](150) NULL,
	[Status] [varchar](50) NULL,
	[Trash] [varchar](1) NULL,
 CONSTRAINT [PK_eMailRecipt] PRIMARY KEY CLUSTERED 
(
	[RECIPT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[DESIGNATION_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Designation_Name] [varchar](150) NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[DESIGNATION_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DEPARTMENT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Department_Name] [varchar](150) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DEPARTMENT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyAttendanceEmployee]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyAttendanceEmployee](
	[EMP_ATTN_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[EntryDate] [datetime] NULL,
	[EntryTime] [varchar](50) NULL,
	[User_ID] [bigint] NOT NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_DailyAttendanceEmployee] PRIMARY KEY CLUSTERED 
(
	[EMP_ATTN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyAttendance]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyAttendance](
	[ATTN_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SCHOOL_ID] [bigint] NOT NULL,
	[BATCH_ID] [bigint] NOT NULL,
	[CLASS_ID] [bigint] NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[SUBJECT_ID] [bigint] NOT NULL,
	[EntryDate] [datetime] NULL,
	[EntryTime] [varchar](50) NULL,
	[STUDENT_ID] [bigint] NOT NULL,
	[User_ID] [bigint] NOT NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_DailyAttendance] PRIMARY KEY CLUSTERED 
(
	[ATTN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassType]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassType](
	[CLASS_TYPE_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Class_Type] [varchar](50) NULL,
 CONSTRAINT [PK_ClassType] PRIMARY KEY CLUSTERED 
(
	[CLASS_TYPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassName]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassName](
	[CLASS_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CLASS_TYPE_ID] [bigint] NOT NULL,
	[Class_name] [varchar](50) NULL,
 CONSTRAINT [PK_ClassName] PRIMARY KEY CLUSTERED 
(
	[CLASS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChartOfAccount]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChartOfAccount](
	[AC_LEDGER_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AC_ID] [bigint] NOT NULL,
	[LedgerName] [varchar](250) NULL,
	[LedgerDate] [datetime] NULL,
	[OpeningBalance] [float] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_ChartOfAccount] PRIMARY KEY CLUSTERED 
(
	[AC_LEDGER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookSupplier]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookSupplier](
	[BOOK_SUPP_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Supplier_Name] [varchar](150) NULL,
	[Address] [varchar](150) NULL,
	[Contact_No] [varchar](150) NULL,
	[FAX] [varchar](150) NULL,
	[Email] [varchar](150) NULL,
 CONSTRAINT [PK_BookSupplier] PRIMARY KEY CLUSTERED 
(
	[BOOK_SUPP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookReturn]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookReturn](
	[BK_RTN_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BK_ISSU_ID] [bigint] NOT NULL,
	[ReturnDate] [datetime] NULL,
 CONSTRAINT [PK_BookReturn] PRIMARY KEY CLUSTERED 
(
	[BK_RTN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookIssue]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookIssue](
	[BK_ISSU_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BOOK_ID] [bigint] NOT NULL,
	[IssuDate] [datetime] NULL,
	[ExpectedRtnDate] [datetime] NULL,
	[Remarks] [varchar](max) NULL,
	[STUDENT_ID] [bigint] NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[Status] [varchar](50) NULL,
	[Qty] [int] NULL,
	[User_ID] [bigint] NULL,
 CONSTRAINT [PK_BookIssue] PRIMARY KEY CLUSTERED 
(
	[BK_ISSU_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookInfo]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookInfo](
	[BOOK_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](max) NULL,
	[BOOK_SUPP_ID] [bigint] NOT NULL,
	[EntryDate] [datetime] NULL,
	[Author] [varchar](max) NULL,
	[BOOK_CLASSF_ID] [bigint] NOT NULL,
	[BOOK_CAT_ID] [bigint] NOT NULL,
	[ISBN] [varchar](150) NULL,
	[Barcode] [varchar](150) NULL,
	[Edition] [varchar](150) NULL,
	[Volume] [varchar](150) NULL,
	[Publisher] [varchar](250) NULL,
	[PubYear] [int] NULL,
	[NoOfPages] [varchar](150) NULL,
	[BookLocation] [varchar](150) NULL,
	[CoverType] [varchar](150) NULL,
	[Price] [float] NULL,
	[QtyAvailable] [float] NULL,
	[CoverPhoto] [image] NULL,
 CONSTRAINT [PK_BookInfo] PRIMARY KEY CLUSTERED 
(
	[BOOK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookClassification]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookClassification](
	[BOOK_CLASSF_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Book_Classf_Type] [varchar](150) NULL,
 CONSTRAINT [PK_BookClassification] PRIMARY KEY CLUSTERED 
(
	[BOOK_CLASSF_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookCategory](
	[BOOK_CAT_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Category_Name] [varchar](150) NULL,
 CONSTRAINT [PK_BookCategory] PRIMARY KEY CLUSTERED 
(
	[BOOK_CAT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BedPlan]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BedPlan](
	[BED_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[HOSTEL_ID] [bigint] NOT NULL,
	[ROOM_ID] [bigint] NOT NULL,
	[SeatName] [varchar](150) NULL,
	[Booked] [varchar](1) NULL,
	[STUDENT_ID] [bigint] NULL,
 CONSTRAINT [PK_BedPlan] PRIMARY KEY CLUSTERED 
(
	[BED_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Batch]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Batch](
	[BATCH_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BatchName] [varchar](150) NULL,
 CONSTRAINT [PK_Batch] PRIMARY KEY CLUSTERED 
(
	[BATCH_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Barcode]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barcode](
	[auto_id] [bigint] IDENTITY(1,1) NOT NULL,
	[BARCODE_1] [nvarchar](250) NULL,
	[BOOK_NAME_1] [nvarchar](250) NULL,
	[BARCODE_2] [nvarchar](250) NULL,
	[BOOK_NAME_2] [nvarchar](250) NULL,
 CONSTRAINT [PK_Barcode] PRIMARY KEY CLUSTERED 
(
	[auto_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 04/15/2017 22:25:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[AC_ID] [bigint] NOT NULL,
	[AC_Name] [varchar](250) NULL,
	[Ac_Group] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
