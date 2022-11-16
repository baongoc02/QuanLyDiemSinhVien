-- Bảng Khoa
USE QuanLyDiemSinhVien;
GO
CREATE TABLE Khoa
(
	MaKhoa nvarchar(32) PRIMARY KEY,
	TenKhoa nvarchar(max),
	HeDaoTao nvarchar(max),
	NgayThanhLap DATETIME2
)
GO
-- Bảng SinhVien
CREATE TABLE SinhVien
(
	MaSinhVien nvarchar(32) PRIMARY KEY,
	HoTen nvarchar(max),
	NgaySinh DATETIME2,
	GioiTinh nvarchar(3),
	CMND nvarchar(20),
	SDT nvarchar(20),
	QueQuan nvarchar(max),
	MaKhoa nvarchar(32)
)
GO
-- Bảng MonHoc
CREATE TABLE MonHoc
(
	MaMonHoc nvarchar(32) PRIMARY KEY,
	TenMonHoc nvarchar(max),
	MoTa nvarchar(max),
	STC int,
	LoaiHocPhan nvarchar(128),
	MaKhoa nvarchar(32)
)
GO
-- Bảng GiangVien
CREATE TABLE GiangVien
(
	MaGiangVien nvarchar(32) PRIMARY KEY,
	HoTen nvarchar(max),
	NgaySinh DATETIME2,
	GioiTinh nvarchar(3),
	CMND nvarchar(20),
	SDT nvarchar(20),
	QueQuan nvarchar(max),
	HocHam nvarchar(128),
	HocVi nvarchar(128),
	MaKhoa nvarchar(32)
)
GO
-- Bảng Lop
CREATE TABLE Lop
(
	MaLop nvarchar(32) PRIMARY KEY,
	MaHocKy nvarchar(32),
	MaMonHoc nvarchar(32),
	MaGiangVien nvarchar(32),
	LichHoc nvarchar(max),
	NgayBatDau DATETIME2,
	NgayKetThuc DATETIME2,
	GioiHan int
)
GO
-- Bảng HocKy
CREATE TABLE HocKy
(
	MaHocKy nvarchar(32) PRIMARY KEY,
	TenHocKy nvarchar(128),
	NgayBatDau DATETIME2,
	NgayKetThuc DATETIME2,
	MaNamHoc nvarchar(32)
)
GO
-- Bảng NamHoc
CREATE TABLE NamHoc
(
	MaNamHoc nvarchar(32) PRIMARY KEY,
	TenNamhoc nvarchar(128)
)
GO
-- Bảng KetQuaHocTap
CREATE TABLE KetQuaHocTap
(
	MaSinhVien nvarchar(32),
	MaLop nvarchar(32),
	DiemGiuaKy float,
	DiemCuoiKy float,
	PRIMARY KEY(MaSinhVien, MaLop)
)
GO
--	Ràng buộc khóa ngoại giữa các quan hệ
ALTER TABLE SinhVien
    ADD CONSTRAINT FK_SinhVien_Khoa_MaKhoa
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
    ON UPDATE NO ACTION
    ON DELETE SET NULL
GO

ALTER TABLE MonHoc
    ADD CONSTRAINT FK_Mon_Khoa_MaKhoa
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
GO

ALTER TABLE GiangVien
    ADD CONSTRAINT FK_GiangVien_Khoa_MaKhoa
    FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
GO

ALTER TABLE Lop
    ADD CONSTRAINT FK_Lop_Mon_MaMonHoc
    FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc)
    ON UPDATE CASCADE
    ON DELETE NO ACTION
GO

ALTER TABLE KetQuaHocTap
    ADD CONSTRAINT FK_KetQuaHocTap_SinhVien_MaSinhVien
    FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien)
    ON UPDATE CASCADE
    ON DELETE CASCADE
GO

ALTER TABLE KetQuaHocTap
    ADD CONSTRAINT FK_KetQuaHocTap_Lop_MaLop
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
    ON UPDATE CASCADE
    ON DELETE CASCADE
GO

ALTER TABLE Lop
    ADD CONSTRAINT FK_Lop_HocKy
    FOREIGN KEY (MaHocKy) REFERENCES HocKy(MaHocKy)
    ON UPDATE CASCADE
    ON DELETE NO ACTION
GO

ALTER TABLE HocKy
    ADD CONSTRAINT FK_HocKy_NamHoc_MaNamHoc
    FOREIGN KEY (MaNamHoc) REFERENCES NamHoc(MaNamHoc)
    ON UPDATE CASCADE
    ON DELETE NO ACTION
GO
--	Ràng buộc check có trong đề tài
-- Kiểm tra mã số sinh viên có 8 ký tự số
ALTER TABLE SinhVien
    ADD CONSTRAINT CHK_SinhVien_MaSinhVien
    CHECK (MaSinhVien IS NOT NULL AND LEN(MaSinhVien) = 8)
GO
-- Các họ tên trong cơ sở dữ liệu không được bỏ trống
ALTER TABLE SinhVien
    ADD CONSTRAINT CHK_SinhVien_HoTen
    CHECK (HoTen IS NOT NULL AND LEN(HoTen) > 0)
GO

ALTER TABLE GiangVien
    ADD CONSTRAINT CHK_GiangVien_HoTen
    CHECK (HoTen IS NOT NULL AND LEN(HoTen) > 0)
GO
-- Giới tính chỉ gồm 2 giá trị nam và nữ
ALTER TABLE SinhVien
    ADD CONSTRAINT CHK_SinhVien_GioiTinh
    CHECK (GioiTinh IN (N'Nam', N'Nữ'))
GO

ALTER TABLE GiangVien
    ADD CONSTRAINT CHK_GiangVien_GioiTinh
    CHECK (GioiTinh IN (N'Nam', N'Nữ'))
GO

-- Kiểm tra độ dài chứng minh nhân dân từ 9 đến 12 ký tự số
ALTER TABLE SinhVien
    ADD CONSTRAINT CHK_SinhVien_CMND
    CHECK (CMND IS NOT NULL AND LEN(CMND) BETWEEN 9 AND 12)
GO

ALTER TABLE GiangVien
    ADD CONSTRAINT CHK_GiangVien_CMND
    CHECK (CMND IS NOT NULL AND LEN(CMND) BETWEEN 9 AND 12)
GO

-- Tên khoa không được bỏ trống
ALTER TABLE Khoa
    ADD CONSTRAINT CHK_Khoa_TenKhoa
    CHECK (TenKhoa IS NOT NULL AND LEN(TenKhoa) > 0)
GO

-- Hệ đào tạo chỉ bao gồm 2 giá trị ‘đại trà’ hoặc ‘chất lượng cao’
ALTER TABLE Khoa
    ADD CONSTRAINT CHK_Khoa_HeDaoTao
    CHECK (HeDaoTao IN (N'Đại trà', N'Chất lượng cao'))
GO

-- Tên môn không được bỏ trống
ALTER TABLE MonHoc
    ADD CONSTRAINT CHK_MonHoc_TenMonHoc
    CHECK (TenMonHoc IS NOT NULL AND LEN(TenMonHoc) > 0)
GO

-- Số tín chỉ nhập vào phải lớn hơn 0
ALTER TABLE MonHoc
    ADD CONSTRAINT CHK_MonHoc_STC
    CHECK (STC IS NOT NULL AND STC > 0)
GO

-- Loại học phần chỉ bao gồm 2 giá trị ‘lý thuyết’ hoặc ‘thực hành’
ALTER TABLE MonHoc
    ADD CONSTRAINT CHK_MonHoc_LoaiHocPhan
    CHECK (LoaiHocPhan IN (N'Lý thuyết', N'Thực hành'))
GO

-- Kiểm tra học hàm của giảng viên
ALTER TABLE GiangVien
    ADD CONSTRAINT CHK_GiangVien_HocHam
    CHECK (HocHam IN (N'PGS', N'GS'))
GO

-- Kiểm tra học vị của giảng viên
ALTER TABLE GiangVien
    ADD CONSTRAINT CHK_GiangVien_HocVi
    CHECK (HocVi IN (N'ThS', N'TS'))
GO

-- Ngày bắt đầu phải trước ngày kết thúc
ALTER TABLE Lop
    ADD CONSTRAINT CHK_Lop_NgayBatDau_NgayKetThuc
    CHECK (NgayBatDau IS NOT NULL AND NgayKetThuc IS NOT NULL AND NgayBatDau < NgayketThuc)
GO

ALTER TABLE HocKy
    ADD CONSTRAINT CHK_HocKy_NgayBatDau_NgayKetThuc
    CHECK (NgayBatDau IS NOT NULL AND NgayKetThuc IS NOT NULL AND NgayBatDau < NgayketThuc)
GO
-- Kiểm tra giới hạn sinh viên của lớp học
ALTER TABLE Lop
    ADD CONSTRAINT CHK_Lop_GioiHan
    CHECK (GioiHan IS NOT NULL AND GioiHan BETWEEN 1 AND 200)
GO