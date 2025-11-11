USE [RestaurantManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/11/2025 11:51:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[FullName] [nvarchar](1000) NOT NULL,
	[Email] [nvarchar](1000) NULL,
	[Tell] [nvarchar](200) NULL,
	[DateCreated] [smalldatetime] NULL,
 CONSTRAINT [PK_Account_1] PRIMARY KEY CLUSTERED 
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetails]    Script Date: 11/11/2025 11:51:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 11/11/2025 11:51:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[TableID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Discount] [float] NULL,
	[Tax] [float] NULL,
	[Status] [bit] NOT NULL,
	[CheckoutDate] [smalldatetime] NULL,
	[Account] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/11/2025 11:51:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_FoodCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 11/11/2025 11:51:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Unit] [nvarchar](100) NOT NULL,
	[FoodCategoryID] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Notes] [nvarchar](3000) NULL,
 CONSTRAINT [PK_FoodStuffs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/11/2025 11:51:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](1000) NOT NULL,
	[Path] [nvarchar](3000) NULL,
	[Notes] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAccount]    Script Date: 11/11/2025 11:51:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAccount](
	[RoleID] [int] NOT NULL,
	[AccountName] [nvarchar](100) NOT NULL,
	[Actived] [bit] NOT NULL,
	[Notes] [nvarchar](3000) NULL,
 CONSTRAINT [PK_RoleAccount] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 11/11/2025 11:51:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[Status] [int] NOT NULL,
	[Capacity] [int] NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'lgcong', N'legiacongz', N'Lê Gia Công', N'conglg@dlu.edu.vn', N'1', CAST(N'2025-11-03T19:23:00' AS SmallDateTime))
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'pttnga', N'phanthithanhnga', N'Phan Thị Thanh Nga', N'ngaptt@dlu.edu.vn', NULL, CAST(N'2020-06-04T00:00:00' AS SmallDateTime))
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'tdquy', N'thaiduyquy', N'Thái Duy Quý', N'quytd@dlu.edu.vn', N'', NULL)
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated]) VALUES (N'ttplinh', N'tranthiphuonglinh', N'Trần Thị Phương Linh', N'linhttp@dlu.edu.vn', N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[BillDetails] ON 

INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (19, 26, 6, 2)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (32, 34, 1, 2)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (33, 34, 2, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (34, 35, 2, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (35, 35, 5, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (36, 36, 1, 2)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (37, 36, 2, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (38, 37, 2, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (39, 37, 6, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (40, 37, 11, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (41, 38, 8, 2)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (42, 38, 5, 1)
INSERT [dbo].[BillDetails] ([ID], [InvoiceID], [FoodID], [Quantity]) VALUES (43, 38, 4, 1)
SET IDENTITY_INSERT [dbo].[BillDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 

INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (2, N'Hóa đơn thanh toán', 5, 110000, 0.01, 0, 1, CAST(N'2020-10-21T11:31:00' AS SmallDateTime), N'tdquy')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (4, N'HĐTT', 1002, 12, 0, 0, 0, CAST(N'2025-11-02T18:07:00' AS SmallDateTime), N'1')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (5, N'123', 6, 123, 0, 0, 0, CAST(N'2025-11-02T18:09:00' AS SmallDateTime), N'pa')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (6, N'123', 5, 2, 0, 123, 0, CAST(N'2025-11-02T18:12:00' AS SmallDateTime), N'pa')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (7, N'123', 5, 1, 0, 0, 0, CAST(N'2025-11-02T18:16:00' AS SmallDateTime), N'pa')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (26, N'Hóa đơn', 1004, 1, 0, 0, 1, CAST(N'2025-11-04T15:18:00' AS SmallDateTime), N'admin')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (34, N'Hóa đơn bàn 1', 4, 2, 0, 0, 1, CAST(N'2025-11-11T11:43:00' AS SmallDateTime), N'admin')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (35, N'Hóa đơn bàn 4', 5, 4, 0, 0, 0, NULL, N'admin')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (36, N'Hóa đơn bàn 3', 4, 2, 0, 0, 1, CAST(N'2025-11-11T11:44:00' AS SmallDateTime), N'admin')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (37, N'Hóa đơn bàn 1', 4, 3, 0, 0, 0, NULL, N'admin')
INSERT [dbo].[Bills] ([ID], [Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account]) VALUES (38, N'Hóa đơn bàn 5', 6, 3, 0, 0, 0, NULL, N'admin')
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (1, N'Khai vị', 1)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (2, N'Hải sản', 1)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (3, N'Gà ', 0)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (4, N'Cơm', 1)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (5, N'Thịt', 1)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (6, N'Rau', 1)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (8, N'Canh', 1)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (11, N'Nước ngọt', 0)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (12, N'Cà phê', 0)
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (27, N'Gà ', 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (1, N'Rau muống xào tỏi', N'Đĩa', 6, 20000, NULL)
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (2, N'Cơm chiên Dương châu', N'Đĩa nhỏ', 4, 35000, N'3 người ăn')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (3, N'Cơm chiên Dương châu', N'Đĩa lớn', 4, 40000, N'4 người ăn')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (4, N'Ếch thui rơm a', N'Đĩa', 2, 70000, N'')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (5, N'Sò lông nướng mỡ hành a', N'Đĩa', 2, 80000, N'')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (6, N'Càng cua hấp', N'Đĩa', 2, 100000, NULL)
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (7, N'Canh cải', N'Tô', 8, 20000, NULL)
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (8, N'Gà nướng muối ớt ', N'Con', 3, 180000, N'')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (11, N'Súp cua', N'Tô', 1, 15000, NULL)
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (12, N'Thịt kho', N'Đĩa', 5, 25000, N'Theo thời giá')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (20, N'Súp cuaca', N'Tô', 1, 100, N'')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (21, N'ád', N'ád', 1, 0, N'ád')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (22, N'20', N'Tô', 1, 100, N'')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (23, N'21', N'ád', 1, 0, N'ád')
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (25, N'Càng cua hấp bia', N'Đĩa', 2, 100000, N'')
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (1, N'Adminstrator', NULL, NULL)
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (2, N'Kế toán', NULL, NULL)
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (3, N'Nhân viên thanh toán', NULL, NULL)
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (4, N'Nhân viên phục vụ', NULL, NULL)
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (5, N'Nhân viên phục vụ a', NULL, NULL)
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (6, N'Nhân viên phục vụ a f', N'ádd', N'ádád')
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (8, N'Nhân viên thanh toán', N'', N'')
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (9, N'Nhân viên thanh toán a', N'', N'')
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (11, N'Nhân viên thanh toán', N'', N'')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (1, N'lgcong', 1, N'')
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (1, N'pttnga', 1, NULL)
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (1, N'tdquy', 1, N'')
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (1, N'ttplinh', 1, NULL)
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (2, N'lgcong', 1, N'')
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (2, N'tdquy', 1, N'')
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (3, N'tdquy', 1, N'')
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (3, N'ttplinh', 1, NULL)
INSERT [dbo].[RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES (4, N'tdquy', 1, N'')
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (4, N'03', 1, 2)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (5, N'04', 1, 6)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (6, N'05', 1, 8)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (8, N'06', 0, 8)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1002, N'07', 0, 8)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1003, N'08', 0, 12)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1004, N'09', 0, 12)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1005, N'10', 0, 15)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1006, N'VIP.1', 0, 20)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1007, N'VIP.2', 0, 20)
INSERT [dbo].[Table] ([ID], [Name], [Status], [Capacity]) VALUES (1008, N'VIP.3', 0, 10)
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
ALTER TABLE [dbo].[BillDetails] ADD  CONSTRAINT [DF_InvoiceDetails_Amount]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Food] ADD  CONSTRAINT [DF_Food_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceInfo_FoodStuffs] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[BillDetails] CHECK CONSTRAINT [FK_InvoiceInfo_FoodStuffs]
GO
ALTER TABLE [dbo].[BillDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceInfo_Invoice] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Bills] ([ID])
GO
ALTER TABLE [dbo].[BillDetails] CHECK CONSTRAINT [FK_InvoiceInfo_Invoice]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Table] FOREIGN KEY([TableID])
REFERENCES [dbo].[Table] ([ID])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Invoice_Table]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_FoodStuffs_FoodCategory] FOREIGN KEY([FoodCategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_FoodStuffs_FoodCategory]
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD  CONSTRAINT [FK_RoleAccount_Account] FOREIGN KEY([AccountName])
REFERENCES [dbo].[Account] ([AccountName])
GO
ALTER TABLE [dbo].[RoleAccount] CHECK CONSTRAINT [FK_RoleAccount_Account]
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD  CONSTRAINT [FK_RoleAccount_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleAccount] CHECK CONSTRAINT [FK_RoleAccount_Role]
GO
/****** Object:  StoredProcedure [dbo].[Account_Delete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Account_Delete]
(
 @AccountName nvarchar(100)
)
as
begin
     delete from dbo.Account where AccountName=@AccountName
end
GO
/****** Object:  StoredProcedure [dbo].[Account_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Lấy toàn bộ dữ liệu bảng Account
------------------------------------------------------
CREATE PROCEDURE [dbo].[Account_GetAll]
AS
BEGIN
    SELECT * FROM [Account];
END
GO
/****** Object:  StoredProcedure [dbo].[Account_Insert]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================Account===================================================
Create proc [dbo].[Account_Insert]
(
 @AccountName nvarchar(100),
 @Password nvarchar(200),
 @FullName nvarchar(1000),
 @Email nvarchar(1000),
 @Tell nvarchar(200),
 @DateCreated smalldatetime
)
as
begin
     if(not exists (select AccountName from dbo.Account where AccountName = @AccountName))
        insert into dbo.Account(AccountName,Password,FullName,Email,Tell,DateCreated)
        values(@AccountName,@Password,@FullName,@Email,@Tell,@DateCreated)
end
GO
/****** Object:  StoredProcedure [dbo].[Account_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_InsertUpdateDelete]
    @AccountName NVARCHAR(100),
    @Password NVARCHAR(100),
    @FullName NVARCHAR(200),
    @Email NVARCHAR(200),
    @Tell NVARCHAR(20),
    @DateCreated DATETIME,
    @Action INT
AS
BEGIN
    SET NOCOUNT OFF;

    IF (@Action = 0)
    BEGIN
        INSERT INTO Account(AccountName, Password, FullName, Email, Tell, DateCreated)
        VALUES(@AccountName, @Password, @FullName, @Email, @Tell, @DateCreated);
    END
    ELSE IF (@Action = 1)
    BEGIN
        UPDATE Account
        SET Password=@Password, FullName=@FullName, Email=@Email, Tell=@Tell
        WHERE AccountName=@AccountName;
    END
    ELSE IF (@Action = 2)
    BEGIN
        DELETE FROM Account WHERE AccountName=@AccountName;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Account_Update]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Account_Update]
(
 @AccountName nvarchar(100),
 @Password nvarchar(200),
 @FullName nvarchar(1000),
 @Email nvarchar(1000),
 @Tell nvarchar(200),
 @DateCreated smalldatetime
)
as
begin
     update dbo.Account
     set [Password]=@Password, [FullName]=@FullName, [Email]=@Email,
         [Tell]=@Tell, [DateCreated]=@DateCreated
     where AccountName=@AccountName
end
GO
/****** Object:  StoredProcedure [dbo].[Bill_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Lấy toàn bộ dữ liệu bảng Bill
------------------------------------------------------
CREATE PROCEDURE [dbo].[Bill_GetAll]
AS
BEGIN
    SELECT * FROM [Bills];
END
GO
/****** Object:  StoredProcedure [dbo].[Bill_GetByTableID]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bill_GetByTableID]
    @TableID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.Name AS BillName,          -- Tên hóa đơn (sẽ hiển thị ở txtTenHoaDon)
        b.Amount AS NumOfPeople,     -- Số người (Amount chính là số người)
        b.Discount,                  -- Giảm giá (%)
        b.Tax,                       -- Thuế (%)
        f.Name AS FoodName,          -- Tên món ăn
        bd.Quantity,                 -- Số lượng
        f.Price AS UnitPrice,        -- Đơn giá
        (bd.Quantity * f.Price) AS TotalPrice  -- Thành tiền
    FROM Bills b
    INNER JOIN BillDetails bd ON b.ID = bd.InvoiceID
    INNER JOIN Food f ON bd.FoodID = f.ID
    WHERE b.TableID = @TableID AND b.Status = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[Bill_GetCheckoutDate]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bill_GetCheckoutDate]
AS
BEGIN
    SELECT CheckoutDate FROM Bills;
END
GO
/****** Object:  StoredProcedure [dbo].[Bill_GetCheckoutDateAccount]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bill_GetCheckoutDateAccount]
    @account NVARCHAR(100)  -- hoặc kiểu dữ liệu phù hợp với cột Account trong bảng Bills
AS
BEGIN
    SELECT CheckoutDate
    FROM Bills
    WHERE Account = @account;
END
GO
/****** Object:  StoredProcedure [dbo].[Bill_GetDetailByDate]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bill_GetDetailByDate]
    @StartOfDay DATETIME,
    @EndOfDay DATETIME
AS
BEGIN
    SELECT 
        A.ID AS BillID,
        A.Name AS BillName,
        C.Name AS TableName,
        A.Discount,
        A.Tax,
        D.Name AS FoodName,
        B.Quantity
    FROM Bills A
        JOIN BillDetails B ON A.ID = B.InvoiceID
        JOIN [Table] C ON A.TableID = C.ID
        JOIN Food D ON B.FoodID = D.ID
    WHERE A.CheckoutDate >= @StartOfDay 
      AND A.CheckoutDate < @EndOfDay;
END
GO
/****** Object:  StoredProcedure [dbo].[Bill_GetDetailsByID]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bill_GetDetailsByID]
    @BillID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        f.Name AS FoodName,
        bd.Quantity
    FROM BillDetails bd
    INNER JOIN Food f ON f.ID = bd.FoodID
    WHERE bd.InvoiceID = @BillID;
END
GO
/****** Object:  StoredProcedure [dbo].[Bill_GetUnpaidBillByTableID]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bill_GetUnpaidBillByTableID]
    @TableID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 *
    FROM Bill
    WHERE TableID = @TableID
      AND Status = 0  -- 0 = chưa thanh toán
    ORDER BY ID DESC; -- Lấy hóa đơn mới nhất
END
GO
/****** Object:  StoredProcedure [dbo].[BillDetail_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Lấy toàn bộ dữ liệu bảng BillDetail
------------------------------------------------------
CREATE PROCEDURE [dbo].[BillDetail_GetAll]
AS
BEGIN
    SELECT * FROM [BillDetail];
END
GO
/****** Object:  StoredProcedure [dbo].[BillDetail_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Thêm, sửa, xóa dữ liệu bảng BillDetail
------------------------------------------------------
CREATE PROCEDURE [dbo].[BillDetail_InsertUpdateDelete]
    @ID INT OUTPUT,
    @BillID INT,
    @FoodID INT,
    @Quantity INT,
    @Price INT,
    @Action INT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Action = 0) -- Thêm
    BEGIN
        INSERT INTO [BillDetail]([BillID],[FoodID],[Quantity],[Price])
        VALUES(@BillID,@FoodID,@Quantity,@Price);
        SET @ID = SCOPE_IDENTITY();
    END
    ELSE IF (@Action = 1) -- Sửa
    BEGIN
        UPDATE [BillDetail]
        SET [BillID] = @BillID,
            [FoodID] = @FoodID,
            [Quantity] = @Quantity,
            [Price] = @Price
        WHERE [ID] = @ID;
    END
    ELSE IF (@Action = 2) -- Xóa
    BEGIN
        DELETE FROM [BillDetail] WHERE [ID] = @ID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[BillDetails_Delete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[BillDetails_Delete]
(
 @ID int
)
as
begin
     delete from dbo.BillDetails where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[BillDetails_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Lấy toàn bộ dữ liệu bảng BillDetail
------------------------------------------------------
Create PROCEDURE [dbo].[BillDetails_GetAll]
AS
BEGIN
    SELECT * FROM [BillDetails];
END
GO
/****** Object:  StoredProcedure [dbo].[BillDetails_Insert]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================BillDetails===================================================
Create proc [dbo].[BillDetails_Insert]
(
 @InvoiceID int,
 @FoodID int,
 @Quantity int
)
as
begin
     insert into dbo.BillDetails(InvoiceID,FoodID,Quantity)
     values(@InvoiceID,@FoodID,@Quantity)
end
GO
/****** Object:  StoredProcedure [dbo].[BillDetails_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Thêm, sửa, xóa dữ liệu bảng Bill
------------------------------------------------------
CREATE PROCEDURE [dbo].[BillDetails_InsertUpdateDelete]
    @ID INT OUTPUT,
    @InvoiceID INT,
    @FoodID INT,
    @Quantity INT,
    @Action INT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Action = 0)  -- Thêm
    BEGIN
        INSERT INTO [BillDetails]([InvoiceID], [FoodID], [Quantity])
        VALUES(@InvoiceID, @FoodID, @Quantity);
        SET @ID = SCOPE_IDENTITY();
    END
    ELSE IF (@Action = 1)  -- Sửa
    BEGIN
        UPDATE [BillDetails]
        SET [InvoiceID] = @InvoiceID,
            [FoodID] = @FoodID,
            [Quantity] = @Quantity
        WHERE [ID] = @ID;
    END
    ELSE IF (@Action = 2)  -- Xóa
    BEGIN
        DELETE FROM [BillDetails] WHERE [ID] = @ID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[BillDetails_Update]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[BillDetails_Update]
(
 @ID int,
 @InvoiceID int,
 @FoodID int,
 @Quantity int
)
as
begin
     update dbo.BillDetails
     set [InvoiceID]=@InvoiceID, [FoodID]=@FoodID, [Quantity]=@Quantity
     where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Bills_Delete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Bills_Delete]
(
 @ID int
)
as
begin
     delete from dbo.Bills where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Bills_GetByDateRange]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bills_GetByDateRange]
    @fromDate DATETIME,
    @toDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * 
    FROM Bills
    WHERE CheckoutDate BETWEEN @fromDate AND @toDate
    ORDER BY CheckoutDate DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[Bills_Insert]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================Bills===================================================
Create proc [dbo].[Bills_Insert]
(
 @Name nvarchar(1000),
 @TableID int,
 @Amount int,
 @Discount float,
 @Tax float,
 @Status bit,
 @CheckoutDate smalldatetime,
 @Account nvarchar(100)
)
as
begin
     insert into dbo.Bills(Name,TableID,Amount,Discount,Tax,Status,CheckoutDate,Account)
     values(@Name,@TableID,@Amount,@Discount,@Tax,@Status,@CheckoutDate,@Account)
end
GO
/****** Object:  StoredProcedure [dbo].[Bills_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--========
CREATE PROCEDURE [dbo].[Bills_InsertUpdateDelete]
    @ID INT Output,
    @Name NVARCHAR(200),
    @TableID INT,
    @Amount INT,
    @Discount FLOAT,
    @Tax FLOAT,
    @Status INT,
    @CheckoutDate DATETIME,
    @Account NVARCHAR(100),
    @Action INT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Action = 0)  -- Thêm mới
BEGIN
    INSERT INTO Bills([Name], [TableID], [Amount], [Discount], [Tax], [Status], [CheckoutDate], [Account])
    VALUES(@Name, @TableID, @Amount, @Discount, @Tax, @Status, @CheckoutDate, @Account);

    -- Gán lại ID vừa thêm để C# nhận được
    SET @ID = SCOPE_IDENTITY();
END

    ELSE IF (@Action = 1)  -- Cập nhật toàn bộ hóa đơn
    BEGIN
        UPDATE Bills
        SET [Name] = @Name,
            [TableID] = @TableID,
            [Amount] = @Amount,
            [Discount] = @Discount,
            [Tax] = @Tax,
            [Status] = @Status,
            [CheckoutDate] = @CheckoutDate,
            [Account] = @Account
        WHERE [ID] = @ID;
    END

    ELSE IF (@Action = 2)  -- Cập nhật trạng thái thanh toán
    BEGIN
        UPDATE Bills
        SET [Status] = @Status,
            [CheckoutDate] = @CheckoutDate,
            [Account] = @Account
        WHERE [ID] = @ID;
    END

    ELSE IF (@Action = 3)  -- Xóa hóa đơn
    BEGIN
        DELETE FROM Bills WHERE [ID] = @ID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Bills_Update]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Bills_Update]
(
 @ID int,
 @Name nvarchar(1000),
 @TableID int,
 @Amount int,
 @Discount float,
 @Tax float,
 @Status bit,
 @CheckoutDate smalldatetime,
 @Account nvarchar(100)
)
as
begin
     update dbo.Bills
     set [Name]=@Name, [TableID]=@TableID, [Amount]=@Amount, [Discount]=@Discount,
         [Tax]=@Tax, [Status]=@Status, [CheckoutDate]=@CheckoutDate, [Account]=@Account
     where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Category_Delete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Category_Delete]
(
@ID int
)
as
begin
     delete from dbo.Category
	 where ID= @ID
end
GO
/****** Object:  StoredProcedure [dbo].[Category_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Category_GetAll]
AS
BEGIN
    SELECT *
    FROM [Category];
END
GO
/****** Object:  StoredProcedure [dbo].[Category_Insert]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--===========================Category==========================================

Create proc [dbo].[Category_Insert]
(
@Name nvarchar(1000),
@Type INT
)
as
begin
     if(not exists (select Name from dbo.Category where Name = @Name))
	    insert into dbo. Category (Name,Type) values (@Name,@Type)
end
GO
/****** Object:  StoredProcedure [dbo].[Category_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Category_InsertUpdateDelete]
   @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
   @Name nvarchar(200),
   @Type int,
   @Action int -- Biến cho biết thêm, xóa, hay sửa
AS
-- Nếu Action = 0, thực hiện thêm dữ liệu
IF @Action = 0
BEGIN
    INSERT INTO [Category] ([Name], [Type])
    VALUES (@Name, @Type)
    SET @ID = @@IDENTITY -- Thiết lập ID tự tăng
END
-- Nếu Action = 1, thực hiện cập nhật dữ liệu
ELSE IF @Action = 1
BEGIN
    UPDATE [Category] SET [Name] = @Name, [Type] = @Type
    WHERE [ID] = @ID
END
-- Nếu Action = 2, thực hiện xóa dữ liệu
ELSE IF @Action = 2
BEGIN
    DELETE FROM [Category] WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Category_Update]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Category_Update]
(
@ID int,
@Name nvarchar(1000),
@Type int
)
as
begin
     update dbo.Category
	 set [Name]= @Name, [Type]= @Type
	 Where ID= @ID
end
GO
/****** Object:  StoredProcedure [dbo].[dbo_GetALL]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--===========================Xem Bang==========================================
CREATE PROC [dbo].[dbo_GetALL]
(
   @TableName NVARCHAR(200)
)
AS
BEGIN
      DECLARE @Sql NVARCHAR(1000)
      SET @Sql = 'Select * from '+ @TableName
      EXEC (@Sql)
END
GO
/****** Object:  StoredProcedure [dbo].[dbo_GetID]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[dbo_GetID]
(
   @TableName NVARCHAR(200),
   @ID int
)
AS
BEGIN
      DECLARE @Sql NVARCHAR(1000)
	  set @Sql= 'Select * from '+ @TableName + ' Where'+ ' ID=@ID'
	  EXEC (@Sql)
END
GO
/****** Object:  StoredProcedure [dbo].[Food_Delete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Food_Delete]
(
 @ID int
)
as
begin
     delete from dbo.Food where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Food_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Food_GetAll]
AS
    SELECT * FROM Food
GO
/****** Object:  StoredProcedure [dbo].[Food_Insert]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================Food===================================================
Create proc [dbo].[Food_Insert]
(
 @Name nvarchar(1000),
 @Unit nvarchar(100),
 @FoodCategoryID int,
 @Price int,
 @Notes nvarchar(3000)
)
as
begin
     if(not exists (select Name from dbo.Food where Name=@Name and Unit=@Unit))
        insert into dbo.Food(Name,Unit,FoodCategoryID,Price,Notes)
        values(@Name,@Unit,@FoodCategoryID,@Price,@Notes)
end
GO
/****** Object:  StoredProcedure [dbo].[Food_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Food_InsertUpdateDelete]
    @ID int output, -- Biến ID tự tăng, khi thêm xong phải lấy ra
    @Name nvarchar(1000),
    @Unit nvarchar(100),
    @FoodCategoryID int,
    @Price int,
    @Notes nvarchar(3000),
    @Action int -- Biến cho biết thêm, xóa, hay sửa
AS
IF @Action = 0 -- Nếu Action = 0, thêm dữ liệu
BEGIN
    INSERT INTO [Food] ([Name], [Unit], [FoodCategoryID], [Price], [Notes])
    VALUES (@Name, @Unit, @FoodCategoryID, @Price, @Notes)
    SET @ID = @@IDENTITY -- Thiết lập ID tự tăng
END
ELSE IF @Action = 1 -- Nếu Action = 1, cập nhật dữ liệu
BEGIN
    UPDATE [Food]
    SET [Name] = @Name,
        [Unit] = @Unit,
        [FoodCategoryID] = @FoodCategoryID,
        [Price] = @Price,
        [Notes] = @Notes
    WHERE [ID] = @ID
END
ELSE IF @Action = 2 -- Nếu Action = 2, xóa dữ liệu
BEGIN
    DELETE FROM [Food] WHERE [ID] = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Food_Update]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Food_Update]
(
 @ID int,
 @Name nvarchar(1000),
 @Unit nvarchar(100),
 @FoodCategoryID int,
 @Price int,
 @Notes nvarchar(3000)
)
as
begin
     update dbo.Food
     set [Name]=@Name, [Unit]=@Unit, [FoodCategoryID]=@FoodCategoryID,
         [Price]=@Price, [Notes]=@Notes
     where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[GetDailyRevenue]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE GetDailyRevenue
    @FromDate SMALLDATETIME,
    @ToDate SMALLDATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        SUM(bd.Quantity * f.Price) AS TotalBeforeDiscount,                          -- Tổng tiền gốc
        SUM((bd.Quantity * f.Price) * ISNULL(b.Discount, 0) / 100) AS TotalDiscount, -- Tổng tiền giảm
        SUM(
            (bd.Quantity * f.Price)
            - ((bd.Quantity * f.Price) * ISNULL(b.Discount, 0) / 100)
            + ((bd.Quantity * f.Price) * ISNULL(b.Tax, 0) / 100)
        ) AS TotalRevenue                                                           -- Thực thu sau giảm và thuế
    FROM Bills b
    JOIN BillDetails bd ON b.ID = bd.InvoiceID
    JOIN Food f ON bd.FoodID = f.ID
    WHERE b.CheckoutDate BETWEEN @FromDate AND @ToDate;
END;
go
/****** Object:  StoredProcedure [dbo].[GetRolesByAccount]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRolesByAccount]
    @AccountName NVARCHAR(100)
AS
BEGIN
    SELECT 
        R.ID AS RoleID,
        R.RoleName,
        R.Path,
        R.Notes,
        ISNULL(RA.Actived, 0) AS Actived
    FROM Role R
    LEFT JOIN RoleAccount RA 
        ON R.ID = RA.RoleID AND RA.AccountName = @AccountName
END;
GO
/****** Object:  StoredProcedure [dbo].[GetRolesOfAccount]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRolesOfAccount]
    @AccountName NVARCHAR(100)
AS
BEGIN
    SELECT 
        r.ID,
        r.RoleName,
        r.Path,
        r.Notes
    FROM Role AS r
    INNER JOIN RoleAccount AS ra 
        ON r.ID = ra.RoleID
    WHERE ra.AccountName = @AccountName 
      AND ra.Actived = 1
END
GO
/****** Object:  StoredProcedure [dbo].[InsertAccount]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertAccount]
    @AccountName NVARCHAR(100),
    @Password NVARCHAR(200),
    @FullName NVARCHAR(1000),
    @Email NVARCHAR(1000),
    @Tell NVARCHAR(200)
AS
BEGIN
    INSERT INTO Account (AccountName, [Password], FullName, Email, Tell)
    VALUES (@AccountName, @Password, @FullName, @Email, @Tell);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCategory]
    @ID int output,
    @Name nvarchar(1000),
    @Type nvarchar(100)
    
AS
INSERT INTO [Category]
    ([Name], [Type])
VALUES
    (@Name, @Type)

SELECT @ID = SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[InsertFood]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================
CREATE PROCEDURE [dbo].[InsertFood]
@ID int output,
@Name nvarchar(3000), 
@Unit nvarchar(3000), 
@FoodCategoryID int, 
@Price int,  
@Notes nvarchar(3000)
AS
	INSERT INTO Food (Name, Unit, FoodCategoryID, Price,  Notes)
	VALUES ( @Name, @Unit, @FoodCategoryID, @Price,  @Notes)

	SELECT @ID = SCOPE_IDENTITY()

GO
/****** Object:  StoredProcedure [dbo].[InsertRole]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertRole]
    @ID INT OUTPUT,
    @RoleName NVARCHAR(1000),
    @Path NVARCHAR(3000) = NULL,
    @Notes NVARCHAR(3000) = NULL
AS
BEGIN
    INSERT INTO Role (RoleName, Path, Notes)
    VALUES (@RoleName, @Path, @Notes);

    SELECT @ID = SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[LoadBillByTable]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadBillByTable]
    @TableID INT
AS
BEGIN
    SELECT 
        f.Name AS FoodName,
        f.Price AS UnitPrice,
        bd.Quantity,
        (f.Price * bd.Quantity) AS TotalPrice
    FROM Bills b
    INNER JOIN BillDetails bd ON b.ID = bd.InvoiceID
    INNER JOIN Food f ON f.ID = bd.FoodID
    WHERE b.TableID = @TableID AND b.Status = 0;  -- chỉ lấy hóa đơn chưa thanh toán
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Delete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Role_Delete]
(
 @ID int
)
as
begin
     delete from dbo.Role where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Role_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Lấy toàn bộ dữ liệu bảng Role
------------------------------------------------------
CREATE PROCEDURE [dbo].[Role_GetAll]
AS
BEGIN
    SELECT * FROM [Role];
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Insert]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================Role===================================================
Create proc [dbo].[Role_Insert]
(
 @RoleName nvarchar(1000),
 @Path nvarchar(3000),
 @Notes nvarchar(3000)
)
as
begin
     if(not exists (select RoleName from dbo.Role where RoleName=@RoleName))
        insert into dbo.Role(RoleName,Path,Notes)
        values(@RoleName,@Path,@Notes)
end
GO
/****** Object:  StoredProcedure [dbo].[Role_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Thêm, sửa, xóa dữ liệu bảng Role
------------------------------------------------------
CREATE PROCEDURE [dbo].[Role_InsertUpdateDelete]
    @ID INT OUTPUT,
    @RoleName NVARCHAR(1000),
    @Path NVARCHAR(3000),
    @Notes NVARCHAR(3000),
    @Action INT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Action = 0) -- Thêm
    BEGIN
        INSERT INTO [Role]([RoleName], [Path], [Notes])
        VALUES(@RoleName, @Path, @Notes);

        SET @ID = SCOPE_IDENTITY();
    END
    ELSE IF (@Action = 1) -- Sửa
    BEGIN
        UPDATE [Role]
        SET [RoleName] = @RoleName,
            [Path] = @Path,
            [Notes] = @Notes
        WHERE [ID] = @ID;
    END
    ELSE IF (@Action = 2) -- Xóa
    BEGIN
        DELETE FROM [Role] WHERE [ID] = @ID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Update]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Role_Update]
(
 @ID int,
 @RoleName nvarchar(1000),
 @Path nvarchar(3000),
 @Notes nvarchar(3000)
)
as
begin
     update dbo.Role
     set [RoleName]=@RoleName, [Path]=@Path, [Notes]=@Notes
     where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_Delete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[RoleAccount_Delete]
(
 @RoleID int,
 @AccountName nvarchar(100)
)
as
begin
     delete from dbo.RoleAccount where RoleID=@RoleID and AccountName=@AccountName
end
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_DeleteByAccountName]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleAccount_DeleteByAccountName]
    @AccountName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [RoleAccount]
    WHERE [AccountName] = @AccountName;
END
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Lấy toàn bộ dữ liệu bảng RoleAccount
------------------------------------------------------
CREATE PROCEDURE [dbo].[RoleAccount_GetAll]
AS
BEGIN
    SELECT * FROM [RoleAccount];
END
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_Insert]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================RoleAccount===================================================
Create proc [dbo].[RoleAccount_Insert]
(
 @RoleID int,
 @AccountName nvarchar(100),
 @Actived bit,
 @Notes nvarchar(3000)
)
as
begin
     if(not exists (select 1 from dbo.RoleAccount where RoleID=@RoleID and AccountName=@AccountName))
        insert into dbo.RoleAccount(RoleID,AccountName,Actived,Notes)
        values(@RoleID,@AccountName,@Actived,@Notes)
end
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------------------------
-- Thêm, sửa, xóa dữ liệu bảng RoleAccount
------------------------------------------------------
CREATE PROCEDURE [dbo].[RoleAccount_InsertUpdateDelete]
    @RoleID INT,
    @AccountName NVARCHAR(100),
    @Actived BIT,
    @Notes NVARCHAR(500),
    @Action INT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Action = 0) -- Thêm
    BEGIN
        INSERT INTO [RoleAccount]([RoleID],[AccountName],[Notes],[Actived])
        VALUES(@RoleID,@AccountName,@Notes,@Actived);
    END
    ELSE IF (@Action = 1) -- Sửa
    BEGIN
        UPDATE [RoleAccount]
        SET [Actived] = @Actived,
            [Notes] = @Notes
        WHERE [RoleID] = @RoleID AND [AccountName] = @AccountName;
    END
    ELSE IF (@Action = 2) -- Xóa
    BEGIN
        DELETE FROM [RoleAccount]
        WHERE [RoleID] = @RoleID AND [AccountName] = @AccountName;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_Update]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[RoleAccount_Update]
(
 @RoleID int,
 @AccountName nvarchar(100),
 @Actived bit,
 @Notes nvarchar(3000)
)
as
begin
     update dbo.RoleAccount
     set [Actived]=@Actived, [Notes]=@Notes
     where RoleID=@RoleID and AccountName=@AccountName
end
GO
/****** Object:  StoredProcedure [dbo].[Table_Delete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Table_Delete]
(
 @ID int
)
as
begin
     delete from dbo.[Table] where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Table_GetAll]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Table_GetAll]
AS
BEGIN
    SELECT * FROM [Table];
END
GO
/****** Object:  StoredProcedure [dbo].[Table_Insert]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=====================Table===================================================
Create proc [dbo].[Table_Insert]
(
 @Name nvarchar(1000),
 @Status int,
 @Capacity int
)
as
begin
     if(not exists (select Name from dbo.[Table] where Name=@Name))
        insert into dbo.[Table](Name,Status,Capacity)
        values(@Name,@Status,@Capacity)
end
GO
/****** Object:  StoredProcedure [dbo].[Table_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE or alter PROCEDURE [dbo].[Table_InsertUpdateDelete]
    @ID       INT           OUTPUT,
    @Name     NVARCHAR(1000),
    @Status   INT,
    @Capacity INT,
    @Action   INT -- 0 = Thêm, 1 = Cập nhật, 2 = Xóa
AS
BEGIN

    IF @Action = 0 -- Thêm dữ liệu
    BEGIN
        INSERT INTO [Table] ([Name], [Status], [Capacity])
        VALUES (@Name, @Status, @Capacity);

        SET @ID = @@IDENTITY;
    END
    ELSE IF @Action = 1 -- Cập nhật dữ liệu
    BEGIN
        UPDATE [Table]
           SET [Name]     = @Name,
               [Status]   = @Status,
               [Capacity] = @Capacity
        WHERE [ID] = @ID;
    END
    ELSE IF @Action = 2 -- Xóa dữ liệu
    BEGIN
        DELETE FROM [Table]
        WHERE [ID] = @ID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Table_Update]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Table_Update]
(
 @ID int,
 @Name nvarchar(1000),
 @Status int,
 @Capacity int
)
as
begin
     update dbo.[Table]
     set [Name]=@Name, [Status]=@Status, [Capacity]=@Capacity
     where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[Tables_InsertUpdateDelete]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Tables_InsertUpdateDelete]
    @ID INT OUTPUT,
    @Name NVARCHAR(1000),
    @Status INT,
    @Capacity INT,
    @Action INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Thêm
    IF (@Action = 0)
    BEGIN
        INSERT INTO [Table] ([Name], [Status], [Capacity])
        VALUES (@Name, @Status, @Capacity);
        SET @ID = SCOPE_IDENTITY();
    END

    -- Cập nhật
    ELSE IF (@Action = 1)
    BEGIN
        UPDATE [Table]
        SET [Name] = @Name,
            [Status] = @Status,
            [Capacity] = @Capacity
        WHERE [ID] = @ID;
    END

    -- Xóa
    ELSE IF (@Action = 2)
    BEGIN
        DELETE FROM [Table]
        WHERE [ID] = @ID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAccount]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAccount]
    @AccountName NVARCHAR(100),
    @Password NVARCHAR(100),
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Tell NVARCHAR(20)
AS
BEGIN
    UPDATE Account
    SET 
        [Password] = @Password,
        [FullName] = @FullName,
        [Email] = @Email,
        [Tell] = @Tell
    WHERE [AccountName] = @AccountName
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateFood]    Script Date: 11/11/2025 11:51:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateFood]
    @ID int,
    @Name nvarchar(1000),
    @Unit nvarchar(100),
    @FoodCategoryID int,
    @Price int,
    @Notes nvarchar(3000)
AS
UPDATE [Food]
SET
    [Name] = @Name,
    [Unit] = @Unit,
    [FoodCategoryID] = @FoodCategoryID,
    [Price] = @Price,
    [Notes] = @Notes
WHERE ID = @ID

IF @@ERROR <> 0
    RETURN 0
ELSE
    RETURN 1
GO