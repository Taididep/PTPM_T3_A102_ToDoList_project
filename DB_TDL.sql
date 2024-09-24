CREATE DATABASE DB_TDL
GO

USE DB_TDL
GO


-- Tạo bảng Users
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL
);



CREATE TABLE Tasks (
    TaskId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    DueDate DATETIME,
    IsCompleted BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);


CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    CategoryName NVARCHAR(100) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);


CREATE TABLE TaskCategories (
    TaskId INT,
    CategoryId INT,
    PRIMARY KEY (TaskId, CategoryId),
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);



CREATE TABLE Reminders (
    ReminderId INT IDENTITY(1,1) PRIMARY KEY,
    TaskId INT NOT NULL,
    ReminderDate DATETIME NOT NULL,
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId)
);



CREATE TABLE TaskHistory (
    HistoryId INT IDENTITY(1,1) PRIMARY KEY,
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
