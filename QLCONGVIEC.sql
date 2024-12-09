CREATE DATABASE QLCONGVIEC;
GO
USE QLCONGVIEC;
GO

-- 1 Bảng DM_ManHinh
CREATE TABLE DM_ManHinh (
    MaManHinh NVARCHAR(50) PRIMARY KEY,
    TenManHinh NVARCHAR(255) NOT NULL
);

-- 2 Bảng QL_NhomNguoiDung
CREATE TABLE QL_NhomNguoiDung (
    MaNhom NVARCHAR(50) PRIMARY KEY,
    TenNhom NVARCHAR(255) NOT NULL,
    GhiChu NVARCHAR(255) NULL
);

-- 3 Bảng QL_NguoiDung
CREATE TABLE QL_NguoiDung (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(255) NOT NULL,
    HoatDong BIT NULL
);

-- 4 Bảng QL_NguoiDungNhomNguoiDung
CREATE TABLE QL_NguoiDungNhomNguoiDung (
    TenDangNhap NVARCHAR(50) NOT NULL,
    MaNhomNguoiDung NVARCHAR(50) NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    PRIMARY KEY (TenDangNhap, MaNhomNguoiDung),
    FOREIGN KEY (TenDangNhap) REFERENCES QL_NguoiDung(TenDangNhap),
    FOREIGN KEY (MaNhomNguoiDung) REFERENCES QL_NhomNguoiDung(MaNhom)
);

-- 5 Bảng QL_PhanQuyen
CREATE TABLE QL_PhanQuyen (
    MaNhomNguoiDung NVARCHAR(50) NOT NULL,
    MaManHinh NVARCHAR(50) NOT NULL,
    CoQuyen BIT NOT NULL,
    PRIMARY KEY (MaNhomNguoiDung, MaManHinh),
    FOREIGN KEY (MaNhomNguoiDung) REFERENCES QL_NhomNguoiDung(MaNhom),
    FOREIGN KEY (MaManHinh) REFERENCES DM_ManHinh(MaManHinh)
);

-- 6. Bảng Thông Tin Cá Nhân Tài Khoản
CREATE TABLE QL_ThongTinCaNhan (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    SoDienThoai NVARCHAR(15) NULL,
    DiaChi NVARCHAR(255) NULL,
    NgaySinh DATE NULL,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN ('Nam', 'Nữ', 'Khác')),
    FOREIGN KEY (TenDangNhap) REFERENCES QL_NguoiDung(TenDangNhap)
);
GO




-- 7. Bảng Công Việc
CREATE TABLE CongViec (
    MaCongViec INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL,
    TieuDe NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(MAX),
    NgayHetHan DATETIME,
    HoanThanh BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (TenDangNhap) REFERENCES QL_NguoiDung(TenDangNhap)
);

-- 8. Bảng Danh Mục
CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    FOREIGN KEY (TenDangNhap) REFERENCES QL_NguoiDung(TenDangNhap)
);

-- 9. Bảng Công Việc - Danh Mục
CREATE TABLE CongViecDanhMuc (
    MaCongViec INT,
    MaDanhMuc INT,
    PRIMARY KEY (MaCongViec, MaDanhMuc),
    FOREIGN KEY (MaCongViec) REFERENCES CongViec(MaCongViec),
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc)
);

-- 10. Bảng Nhắc Nhở
CREATE TABLE NhacNho (
    MaNhacNho INT IDENTITY(1,1) PRIMARY KEY,
    MaCongViec INT NOT NULL,
    NgayNhacNho DATETIME NOT NULL,
    FOREIGN KEY (MaCongViec) REFERENCES CongViec(MaCongViec)
);

-- 11. Bảng Lịch Sử Công Việc
CREATE TABLE LichSuCongViec (
    MaLichSu INT IDENTITY(1,1) PRIMARY KEY,
    MaCongViec INT NOT NULL,
    NgayThayDoi DATETIME NOT NULL,
    TrangThaiCu BIT,
    TrangThaiMoi BIT,
    FOREIGN KEY (MaCongViec) REFERENCES CongViec(MaCongViec)
);



INSERT [QL_NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'AD', N'ADMIN', NULL)
INSERT [QL_NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'BH', N'BH', NULL)
INSERT [QL_NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'KH', N'KHO', NULL)
INSERT [QL_NhomNguoiDung] ([MaNhom], [TenNhom], [GhiChu]) VALUES (N'US', N'USER', NULL)

INSERT [DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF001', N'NGUOI DUNG')
INSERT [DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF002', N'NHOM NGUOIDUNG')
INSERT [DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF003', N'MAN HINH CN')
INSERT [DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF004', N'THEM NGUOI DUNG VAO NHOM')
INSERT [DM_ManHinh] ([MaManHinh], [TenManHinh]) VALUES (N'SF005', N'PHAN QUYEN')

INSERT [QL_NguoiDung] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'admin', N'123456', 1)
INSERT [QL_NguoiDung] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'Hang', N'123456', 1)
INSERT [QL_NguoiDung] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'KH', N'123456', NULL)
INSERT [QL_NguoiDung] ([TenDangNhap], [MatKhau], [HoatDong]) VALUES (N'User', N'123456', 1)

INSERT [QL_NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhomNguoiDung], [GhiChu]) VALUES (N'admin', N'AD', NULL)
INSERT [QL_NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhomNguoiDung], [GhiChu]) VALUES (N'hang', N'BH', NULL)
INSERT [QL_NguoiDungNhomNguoiDung] ([TenDangNhap], [MaNhomNguoiDung], [GhiChu]) VALUES (N'user', N'US', NULL)

INSERT [QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'AD', N'SF001', 0)
INSERT [QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'AD', N'SF002', 1)
INSERT [QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'AD', N'SF003', 1)
INSERT [QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'AD', N'SF004', 1)
INSERT [QL_PhanQuyen] ([MaNhomNguoiDung], [MaManHinh], [CoQuyen]) VALUES (N'AD', N'SF005', 1)



-- 6. Chèn dữ liệu vào Bảng Công Việc
INSERT INTO CongViec (TenDangNhap, TieuDe, MoTa, NgayHetHan, HoanThanh)
VALUES
    (N'admin', N'Công việc 1', N'Mô tả công việc 1', '2024-11-30', 0),
    (N'Hang', N'Công việc 2', N'Mô tả công việc 2', '2024-12-15', 1),
    (N'User', N'Công việc 3', N'Mô tả công việc 3', '2024-11-20', 0);

-- 7. Chèn dữ liệu vào Bảng Danh Mục
INSERT INTO DanhMuc (TenDangNhap, TenDanhMuc)
VALUES
    (N'admin', N'Danh mục 1'),
    (N'Hang', N'Danh mục 2'),
    (N'User', N'Danh mục 3');

-- 8. Chèn dữ liệu vào Bảng Công Việc - Danh Mục
INSERT INTO CongViecDanhMuc (MaCongViec, MaDanhMuc)
VALUES
    (1, 1),
    (2, 2),
    (3, 3);

-- 9. Chèn dữ liệu vào Bảng Nhắc Nhở
INSERT INTO NhacNho (MaCongViec, NgayNhacNho)
VALUES
    (1, '2024-11-25'),
    (2, '2024-12-10'),
    (3, '2024-11-18');

-- 10. Chèn dữ liệu vào Bảng Lịch Sử Công Việc
INSERT INTO LichSuCongViec (MaCongViec, NgayThayDoi, TrangThaiCu, TrangThaiMoi)
VALUES
    (1, '2024-11-20', 0, 1),
    (2, '2024-12-01', 1, 0),
    (3, '2024-11-15', 0, 1);
