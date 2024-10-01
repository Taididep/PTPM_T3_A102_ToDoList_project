CREATE DATABASE DB_TDL
GO

USE DB_TDL
GO


-- 1
CREATE TABLE Users (
    Username NVARCHAR(50) PRIMARY KEY NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Active BIT NOT NULL DEFAULT 1
);
-- 2
CREATE TABLE Roles (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL,
    Note NVARCHAR(255) NULL
);
-- 3
CREATE TABLE UserGroups (
    Username NVARCHAR(50) NOT NULL,
    RoleID INT NOT NULL,               
    Note NVARCHAR(255) NULL,
    PRIMARY KEY (Username, RoleID),
    FOREIGN KEY (Username) REFERENCES Users(Username),
    FOREIGN KEY (RoleID) REFERENCES Roles(ID)
);
-- 4
-- Tạo bảng UserInfo
CREATE TABLE UserInfos (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NULL,
    PhoneNumber NVARCHAR(20) NULL,
    FOREIGN KEY (Username) REFERENCES Users(Username)
);

---------------------------------------------------------------------------

INSERT INTO Users (Username, Password, Active)
VALUES ('tai', 'tai', 1),
       ('ty', 'ty', 1),
       ('tung', 'tung', 1);





	   select * from Users where Username='tai' and Password ='tai'










CREATE TABLE Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    DueDate DATETIME,
    IsCompleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);


CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    CategoryName NVARCHAR(100) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);


CREATE TABLE TaskCategories (
    Id INT,
    CategoryId INT,
    PRIMARY KEY (TaskId, CategoryId),
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);



CREATE TABLE Reminders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TaskId INT NOT NULL,
    ReminderDate DATETIME NOT NULL,
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId)
);



CREATE TABLE TaskHistory (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TaskId INT NOT NULL,
    ChangedDate DATETIME NOT NULL,
    OldStatus BIT,
    NewStatus BIT,
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId)
);



INSERT INTO Users (Username, Password)
VALUES
('taidz', 'taidz'),
('hothienty', 'hothienty'),
('hongoctung', 'hongoctung');


INSERT INTO Tasks (UserId, Title, Description, DueDate, IsCompleted)
VALUES (1, N'Hoàn thành báo cáo', N'Hoàn thành báo cáo cho dự án X', '2024-09-30', 0),
       (2, N'Đặt lịch họp', N'Đặt lịch họp với khách hàng Y', '2024-09-20', 1),
       (3, N'Chuẩn bị tài liệu', N'Chuẩn bị tài liệu cho buổi thuyết trình', '2024-09-25', 0);


INSERT INTO Categories (UserId, CategoryName)
VALUES (1, N'Công việc quan trọng'),
       (2, N'Nhắc nhở'),
       (3, N'Gặp gỡ khách hàng');


INSERT INTO TaskCategories (TaskId, CategoryId)
VALUES (1, 1),  -- Công việc quan trọng
       (2, 2),  -- Nhắc nhở
       (3, 3);  -- Gặp gỡ khách hàng


INSERT INTO Reminders (TaskId, ReminderDate)
VALUES (1, '2024-09-28 09:00:00'),
       (2, '2024-09-18 14:00:00'),
       (3, '2024-09-22 10:00:00');


INSERT INTO TaskHistory (TaskId, ChangedDate, OldStatus, NewStatus)
VALUES (1, '2024-09-15 10:00:00', 0, 1),  -- Đã hoàn thành
       (2, '2024-09-16 11:00:00', 1, 0),  -- Chưa hoàn thành
       (3, '2024-09-20 12:00:00', 0, 1);  -- Đã hoàn thành
