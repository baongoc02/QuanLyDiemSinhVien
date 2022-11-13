-- Tạo Học kỳ
DROP PROCEDURE Proc_CreateHocKy
GO

CREATE PROCEDURE Proc_CreateHocKy(
    @maHocKy NVARCHAR(32),
    @tenHocKy NVARCHAR(128),
    @ngayBatDau DATETIME2,
    @ngayKetThuc DATETIME2,
    @maNamHoc NVARCHAR(32)
)
AS
  IF (@maHocKy IS NULL OR LEN(@maHocKy) = 0)
    BEGIN
      RAISERROR(N'Mã học kỳ không được trống', 16, 1);
      RETURN;
    END

  IF (@tenHocKy IS NULL OR LEN(@tenHocKy) = 0)
    BEGIN
      RAISERROR(N'Tên học kỳ không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayBatDau IS NULL OR LEN(@ngayBatDau) = 0)
    BEGIN
      RAISERROR(N'Ngày bắt đầu không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayKetThuc IS NULL OR LEN(@ngayKetThuc) = 0)
    BEGIN
      RAISERROR(N'Ngày kết thúc không được trống', 16, 1);
      RETURN;
    END

  IF (@maNamHoc IS NULL OR LEN(@maNamHoc) = 0)
    BEGIN
      RAISERROR(N'Mã năm học không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@ngayBatDau < @ngayKetThuc)
    BEGIN
      RAISERROR(N'Ngày bắt đầu phải nhỏ hơn ngày kết thúc', 16, 1);
      RETURN;
    END

  INSERT INTO [HocKy]
  VALUES (
    @maHocKy,
    @tenHocKy,
    @ngayBatDau,
    @ngayKetThuc,
    @maNamHoc
  )
GO

-- Tạo Năm học
DROP PROCEDURE Proc_CreateNamHoc
GO

CREATE PROCEDURE Proc_CreateNamHoc(
    @maNamHoc NVARCHAR(32),
    @tenNamHoc NVARCHAR(128)
)
AS
  IF (@maNamHoc IS NULL OR LEN(@maNamHoc) = 0)
    BEGIN
      RAISERROR(N'Mã năm học không được trống', 16, 1);
      RETURN;
    END

  IF (@tenNamHoc IS NULL OR LEN(@tenNamHoc) = 0)
    BEGIN
      RAISERROR(N'Tên năm học không được trống', 16, 1);
      RETURN;
    END

  INSERT INTO [NamHoc]
  VALUES (
    @maNamHoc,
    @tenNamHoc
  )
GO

-- Tạo Giảng viên
DROP PROCEDURE Proc_CreateGiangVien
GO

CREATE PROCEDURE Proc_CreateGiangVien(
    @maGiangVien NVARCHAR(32),
    @hoTen NVARCHAR(MAX),
    @ngaySinh DATETIME2,
    @gioiTinh NVARCHAR(3),
    @cMND NVARCHAR(20),
    @sDT NVARCHAR(20),
    @queQuan NVARCHAR(MAX),
    @hocHam NVARCHAR(128),
    @hocVi NVARCHAR(128),
    @maKhoa NVARCHAR(32)
)
AS
  IF (@maGiangVien IS NULL OR LEN(@maGiangVien) = 0)
    BEGIN
      RAISERROR(N'Mã giảng viên không được trống', 16, 1);
      RETURN;
    END

  IF (@hoTen IS NULL OR LEN(@hoTen) = 0)
    BEGIN
      RAISERROR(N'Họ và tên không được trống', 16, 1);
      RETURN;
    END

  IF (@ngaySinh IS NULL OR LEN(@ngaySinh) = 0)
    BEGIN
      RAISERROR(N'Ngày sinh không được trống', 16, 1);
      RETURN;
    END

  IF (@gioiTinh IS NULL OR LEN(@gioiTinh) = 0)
    BEGIN
      RAISERROR(N'Giới tính không được trống', 16, 1);
      RETURN;
    END

  IF (@cMND IS NULL OR LEN(@cMND) = 0)
    BEGIN
      RAISERROR(N'CMND không được trống', 16, 1);
      RETURN;
    END

  IF (@sDT IS NULL OR LEN(@sDT) = 0)
    BEGIN
      RAISERROR(N'Số điện thoại không được trống', 16, 1);
      RETURN;
    END

  IF (@queQuan IS NULL OR LEN(@queQuan) = 0)
    BEGIN
      RAISERROR(N'Quê quán không được trống', 16, 1);
      RETURN;
    END

  IF (@hocHam IS NULL OR LEN(@hocHam) = 0)
    BEGIN
      RAISERROR(N'Học hàm không được trống', 16, 1);
      RETURN;
    END

  IF (@hocVi IS NULL OR LEN(@hocVi) = 0)
    BEGIN
      RAISERROR(N'Học vị không được trống', 16, 1);
      RETURN;
    END

  IF (@maKhoa IS NULL OR LEN(@maKhoa) = 0)
    BEGIN
      RAISERROR(N'Mã khoa không được trống', 16, 1);
      RETURN;
    END

  IF NOT (LEN(@cMND) BETWEEN 9 AND 12)
    BEGIN
      RAISERROR(N'Độ dài CMND phải từ 9 đến 12 ký tự', 16, 1);
      RETURN;
    END

  IF NOT (@gioiTinh IN (N'Nam', N'Nữ'))
    BEGIN
      RAISERROR(N'Giới tính phải là nam hoặc nữ', 16, 1);
      RETURN;
    END

  IF NOT (@hocHam IN (N'GS', N'PGS'))
    BEGIN
      RAISERROR(N'Học hàm phải là GS hoặc PGS', 16, 1);
      RETURN;
    END

  IF NOT (@hocVi IN (N'TS', N'ThS'))
    BEGIN
      RAISERROR(N'Học vị phải là TS hoặc ThS', 16, 1);
      RETURN;
    END

  INSERT INTO [GiangVien]
  VALUES (
    @maGiangVien,
    @hoTen,
    @ngaySinh,
    @gioiTinh,
    @cMND,
    @sDT,
    @queQuan,
    @hocHam,
    @hocVi,
    @maKhoa
  )
GO

-- Tạo kết quả học tập
DROP PROCEDURE Proc_CreateKetQuaHocTap
GO

CREATE PROCEDURE Proc_CreateKetQuaHocTap(
    @maSinhVien NVARCHAR(32),
    @maLop NVARCHAR(32),
    @diemGiuaKy FLOAT,
    @diemCuoiKy FLOAT
)
AS
  IF (@maSinhVien IS NULL OR LEN(@maSinhVien) = 0)
    BEGIN
      RAISERROR(N'Mã sinh viên không được trống', 16, 1);
      RETURN;
    END

  IF (@maLop IS NULL OR LEN(@maLop) = 0)
    BEGIN
      RAISERROR(N'Mã lớp không được trống', 16, 1);
      RETURN;
    END

  IF (@diemGiuaKy IS NULL OR LEN(@diemGiuaKy) = 0)
    BEGIN
      RAISERROR(N'Điểm giữa kì không được trống', 16, 1);
      RETURN;
    END

  IF (@diemCuoiKy IS NULL OR LEN(@diemCuoiKy) = 0)
    BEGIN
      RAISERROR(N'Điểm cuối kì không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@diemGiuaKy IS NULL OR @diemGiuaKy BETWEEN 0 AND 10)
    BEGIN
      RAISERROR(N'Điểm giữa kì phải nằm giữa 0 và 10 điểm', 16, 1);
      RETURN;
    END

  IF NOT (@diemCuoiKy IS NULL OR @diemCuoiKy BETWEEN 0 AND 10)
    BEGIN
      RAISERROR(N'Điểm cuối kì phải nằm giữa 0 và 10 điểm', 16, 1);
      RETURN;
    END

  INSERT INTO [KetQuaHocTap]
  VALUES (
    @maSinhVien,
    @maLop,
    @diemGiuaKy,
    @diemCuoiKy
  )
GO

-- Tạo khoa
DROP PROCEDURE Proc_CreateKhoa
GO

CREATE PROCEDURE Proc_CreateKhoa(
    @maKhoa NVARCHAR(32),
    @tenKhoa NVARCHAR(MAX),
    @heDaoTao NVARCHAR(MAX),
    @ngayThanhLap DATETIME2
)
AS
  IF (@maKhoa IS NULL OR LEN(@maKhoa) = 0)
    BEGIN
      RAISERROR(N'Mã khoa không được trống', 16, 1);
      RETURN;
    END

  IF (@tenKhoa IS NULL OR LEN(@tenKhoa) = 0)
    BEGIN
      RAISERROR(N'Tên khoa không được trống', 16, 1);
      RETURN;
    END

  IF (@heDaoTao IS NULL OR LEN(@heDaoTao) = 0)
    BEGIN
      RAISERROR(N'Hệ đào tạo không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayThanhLap IS NULL OR LEN(@ngayThanhLap) = 0)
    BEGIN
      RAISERROR(N'Ngày thành lập không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@heDaoTao IN (N'Chất lượng cao', N'Đại trà'))
    BEGIN
      RAISERROR(N'Hệ đào tạo phải là Chất lượng cao hoặc đại trà', 16, 1);
      RETURN;
    END

  INSERT INTO [Khoa]
  VALUES (
    @maKhoa,
    @tenKhoa,
    @heDaoTao,
    @ngayThanhLap
  )
GO

-- Tạo lớp
DROP PROCEDURE Proc_CreateLop
GO

CREATE PROCEDURE Proc_CreateLop(
    @maLop NVARCHAR(32),
    @maHocKy NVARCHAR(32),
    @maMonHoc NVARCHAR(32),
    @maGiangVien NVARCHAR(32),
    @lichHoc NVARCHAR(MAX),
    @ngayBatDau DATETIME2,
    @ngayKetThuc DATETIME2,
    @gioiHan INT
)
AS
  IF (@maLop IS NULL OR LEN(@maLop) = 0)
    BEGIN
      RAISERROR(N'Mã lớp không được trống', 16, 1);
      RETURN;
    END

  IF (@maHocKy IS NULL OR LEN(@maHocKy) = 0)
    BEGIN
      RAISERROR(N'Mã học kỳ không được trống', 16, 1);
      RETURN;
    END

  IF (@maMonHoc IS NULL OR LEN(@maMonHoc) = 0)
    BEGIN
      RAISERROR(N'Mã môn học không được trống', 16, 1);
      RETURN;
    END

  IF (@maGiangVien IS NULL OR LEN(@maGiangVien) = 0)
    BEGIN
      RAISERROR(N'Mã giảng viên không được trống', 16, 1);
      RETURN;
    END

  IF (@lichHoc IS NULL OR LEN(@lichHoc) = 0)
    BEGIN
      RAISERROR(N'Lịch học không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayBatDau IS NULL OR LEN(@ngayBatDau) = 0)
    BEGIN
      RAISERROR(N'Ngày bắt đầu không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayKetThuc IS NULL OR LEN(@ngayKetThuc) = 0)
    BEGIN
      RAISERROR(N'Ngày kết thúc không được trống', 16, 1);
      RETURN;
    END

  IF (@gioiHan IS NULL OR LEN(@gioiHan) = 0)
    BEGIN
      RAISERROR(N'Giới hạn không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@gioiHan BETWEEN 1 AND 200)
    BEGIN
      RAISERROR(N'Giới hạn sinh viên trong lớp phải từ 1 đến 200', 16, 1);
      RETURN;
    END

  IF NOT (@ngayBatDau < @ngayKetThuc)
    BEGIN
      RAISERROR(N'Ngày bắt đầu phải bé hơn ngày kết thúc', 16, 1);
      RETURN;
    END

  INSERT INTO [Lop]
  VALUES (
    @maLop,
    @maHocKy,
    @maMonHoc,
    @maGiangVien,
    @lichHoc,
    @ngayBatDau,
    @ngayKetThuc,
    @gioiHan
  )
GO

-- Tạo môn học
DROP PROCEDURE Proc_CreateMonHoc
GO

CREATE PROCEDURE Proc_CreateMonHoc(
    @maMonHoc NVARCHAR(32),
    @tenMonHoc NVARCHAR(MAX),
    @moTa NVARCHAR(MAX),
    @sTC INT,
    @loaiHocPhan NVARCHAR(128),
    @maKhoa NVARCHAR(32)
)
AS
  IF (@maMonHoc IS NULL OR LEN(@maMonHoc) = 0)
    BEGIN
      RAISERROR(N'Mã môn học không được trống', 16, 1);
      RETURN;
    END

  IF (@tenMonHoc IS NULL OR LEN(@tenMonHoc) = 0)
    BEGIN
      RAISERROR(N'Tên môn học không được trống', 16, 1);
      RETURN;
    END

  IF (@moTa IS NULL OR LEN(@moTa) = 0)
    BEGIN
      RAISERROR(N'Mô tả không được trống', 16, 1);
      RETURN;
    END

  IF (@sTC IS NULL OR LEN(@sTC) = 0)
    BEGIN
      RAISERROR(N'Số tín chỉ (STC) không được trống', 16, 1);
      RETURN;
    END

  IF (@loaiHocPhan IS NULL OR LEN(@loaiHocPhan) = 0)
    BEGIN
      RAISERROR(N'Loại học phần không được trống', 16, 1);
      RETURN;
    END

  IF (@maKhoa IS NULL OR LEN(@maKhoa) = 0)
    BEGIN
      RAISERROR(N'Mã khoa không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@loaiHocPhan IN (N'Thực hành', N'Lý thuyết'))
    BEGIN
      RAISERROR(N'Loại học phần phải là thực hàn hoặc lý thuyết', 16, 1);
      RETURN;
    END

  IF NOT (@sTC > 0)
    BEGIN
      RAISERROR(N'Số tín chỉ phải lớn hơn 0', 16, 1);
      RETURN;
    END

  INSERT INTO [MonHoc]
  VALUES (
    @maMonHoc,
    @tenMonHoc,
    @moTa,
    @sTC,
    @loaiHocPhan,
    @maKhoa
  )
GO

-- Tạo sinh viên
DROP PROCEDURE Proc_CreateSinhVien
GO

CREATE PROCEDURE Proc_CreateSinhVien(
    @maSinhVien NVARCHAR(32),
    @hoTen NVARCHAR(MAX),
    @ngaySinh DATETIME2,
    @gioiTinh NVARCHAR(3),
    @cMND NVARCHAR(20),
    @sDT NVARCHAR(20),
    @queQuan NVARCHAR(MAX),
    @maKhoa NVARCHAR(32)
)
AS
  IF (@maSinhVien IS NULL OR LEN(@maSinhVien) = 0)
    BEGIN
      RAISERROR(N'Mã sinh viên không được trống', 16, 1);
      RETURN;
    END

  IF (@hoTen IS NULL OR LEN(@hoTen) = 0)
    BEGIN
      RAISERROR(N'Họ và tên không được trống', 16, 1);
      RETURN;
    END

  IF (@ngaySinh IS NULL OR LEN(@ngaySinh) = 0)
    BEGIN
      RAISERROR(N'Ngày sinh không được trống', 16, 1);
      RETURN;
    END

  IF (@gioiTinh IS NULL OR LEN(@gioiTinh) = 0)
    BEGIN
      RAISERROR(N'Giới tính không được trống', 16, 1);
      RETURN;
    END

  IF (@cMND IS NULL OR LEN(@cMND) = 0)
    BEGIN
      RAISERROR(N'CMND không được trống', 16, 1);
      RETURN;
    END

  IF (@sDT IS NULL OR LEN(@sDT) = 0)
    BEGIN
      RAISERROR(N'Số điện thoại không được trống', 16, 1);
      RETURN;
    END

  IF (@queQuan IS NULL OR LEN(@queQuan) = 0)
    BEGIN
      RAISERROR(N'Quê quán không được trống', 16, 1);
      RETURN;
    END

  IF (@maKhoa IS NULL OR LEN(@maKhoa) = 0)
    BEGIN
      RAISERROR(N'Mã khoa không được trống', 16, 1);
      RETURN;
    END

  IF NOT (LEN(@cMND) BETWEEN 9 AND 12)
    BEGIN
      RAISERROR(N'Độ dài CMND phải từ 9 đến 12 ký tự', 16, 1);
      RETURN;
    END

  IF NOT (@gioiTinh IN (N'Nam', N'Nữ'))
    BEGIN
      RAISERROR(N'Giới tính phải là nam hoặc nữ', 16, 1);
      RETURN;
    END

  IF NOT (LEN(@maSinhVien) = 8)
    BEGIN
      RAISERROR(N'Mã sinh viên phải có 8 ký tự', 16, 1);
      RETURN;
    END

  INSERT INTO [SinhVien]
  VALUES (
    @maSinhVien,
    @hoTen,
    @ngaySinh,
    @gioiTinh,
    @cMND,
    @sDT,
    @queQuan,
    @maKhoa
  )
GO

-- Cập nhật Học kỳ
DROP PROCEDURE Proc_UpdateHocKy
GO

CREATE PROCEDURE Proc_UpdateHocKy(
    @maHocKy NVARCHAR(32),
    @tenHocKy NVARCHAR(128),
    @ngayBatDau DATETIME2,
    @ngayKetThuc DATETIME2,
    @maNamHoc NVARCHAR(32)
)
AS
  IF (@maHocKy IS NULL OR LEN(@maHocKy) = 0)
    BEGIN
      RAISERROR(N'Mã học kỳ không được trống', 16, 1);
      RETURN;
    END

  IF (@tenHocKy IS NULL OR LEN(@tenHocKy) = 0)
    BEGIN
      RAISERROR(N'Tên học kỳ không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayBatDau IS NULL OR LEN(@ngayBatDau) = 0)
    BEGIN
      RAISERROR(N'Ngày bắt đầu không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayKetThuc IS NULL OR LEN(@ngayKetThuc) = 0)
    BEGIN
      RAISERROR(N'Ngày kết thúc không được trống', 16, 1);
      RETURN;
    END

  IF (@maNamHoc IS NULL OR LEN(@maNamHoc) = 0)
    BEGIN
      RAISERROR(N'Mã năm học không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@ngayBatDau < @ngayKetThuc)
    BEGIN
      RAISERROR(N'Ngày bắt đầu phải nhỏ hơn ngày kết thúc', 16, 1);
      RETURN;
    END

  UPDATE [HocKy]
  SET
    [TenHocKy] = @tenHocKy,
    [NgayBatDau] = @ngayBatDau,
    [NgayKetThuc] = @ngayKetThuc,
    [MaNamHoc] = @maNamHoc
  WHERE
      [MaHocKy] = @maHocKy 

GO

-- Cập nhật Năm học
DROP PROCEDURE Proc_UpdateNamHoc
GO

CREATE PROCEDURE Proc_UpdateNamHoc(
    @maNamHoc NVARCHAR(32),
    @tenNamHoc NVARCHAR(128)
)
AS
  IF (@maNamHoc IS NULL OR LEN(@maNamHoc) = 0)
    BEGIN
      RAISERROR(N'Mã năm học không được trống', 16, 1);
      RETURN;
    END

  IF (@tenNamHoc IS NULL OR LEN(@tenNamHoc) = 0)
    BEGIN
      RAISERROR(N'Tên năm học không được trống', 16, 1);
      RETURN;
    END

  UPDATE [NamHoc]
  SET
    [TenNamHoc] = @tenNamHoc
  WHERE
      [MaNamHoc] = @maNamHoc 

GO

-- Cập nhật Giảng viên
DROP PROCEDURE Proc_UpdateGiangVien
GO

CREATE PROCEDURE Proc_UpdateGiangVien(
    @maGiangVien NVARCHAR(32),
    @hoTen NVARCHAR(MAX),
    @ngaySinh DATETIME2,
    @gioiTinh NVARCHAR(3),
    @cMND NVARCHAR(20),
    @sDT NVARCHAR(20),
    @queQuan NVARCHAR(MAX),
    @hocHam NVARCHAR(128),
    @hocVi NVARCHAR(128),
    @maKhoa NVARCHAR(32)
)
AS
  IF (@maGiangVien IS NULL OR LEN(@maGiangVien) = 0)
    BEGIN
      RAISERROR(N'Mã giảng viên không được trống', 16, 1);
      RETURN;
    END

  IF (@hoTen IS NULL OR LEN(@hoTen) = 0)
    BEGIN
      RAISERROR(N'Họ và tên không được trống', 16, 1);
      RETURN;
    END

  IF (@ngaySinh IS NULL OR LEN(@ngaySinh) = 0)
    BEGIN
      RAISERROR(N'Ngày sinh không được trống', 16, 1);
      RETURN;
    END

  IF (@gioiTinh IS NULL OR LEN(@gioiTinh) = 0)
    BEGIN
      RAISERROR(N'Giới tính không được trống', 16, 1);
      RETURN;
    END

  IF (@cMND IS NULL OR LEN(@cMND) = 0)
    BEGIN
      RAISERROR(N'CMND không được trống', 16, 1);
      RETURN;
    END

  IF (@sDT IS NULL OR LEN(@sDT) = 0)
    BEGIN
      RAISERROR(N'Số điện thoại không được trống', 16, 1);
      RETURN;
    END

  IF (@queQuan IS NULL OR LEN(@queQuan) = 0)
    BEGIN
      RAISERROR(N'Quê quán không được trống', 16, 1);
      RETURN;
    END

  IF (@hocHam IS NULL OR LEN(@hocHam) = 0)
    BEGIN
      RAISERROR(N'Học hàm không được trống', 16, 1);
      RETURN;
    END

  IF (@hocVi IS NULL OR LEN(@hocVi) = 0)
    BEGIN
      RAISERROR(N'Học vị không được trống', 16, 1);
      RETURN;
    END

  IF (@maKhoa IS NULL OR LEN(@maKhoa) = 0)
    BEGIN
      RAISERROR(N'Mã khoa không được trống', 16, 1);
      RETURN;
    END

  IF NOT (LEN(@cMND) BETWEEN 9 AND 12)
    BEGIN
      RAISERROR(N'Độ dài CMND phải từ 9 đến 12 ký tự', 16, 1);
      RETURN;
    END

  IF NOT (@gioiTinh IN (N'Nam', N'Nữ'))
    BEGIN
      RAISERROR(N'Giới tính phải là nam hoặc nữ', 16, 1);
      RETURN;
    END

  IF NOT (@hocHam IN (N'GS', N'PGS'))
    BEGIN
      RAISERROR(N'Học hàm phải là GS hoặc PGS', 16, 1);
      RETURN;
    END

  IF NOT (@hocVi IN (N'TS', N'ThS'))
    BEGIN
      RAISERROR(N'Học vị phải là TS hoặc ThS', 16, 1);
      RETURN;
    END

  UPDATE [GiangVien]
  SET
    [HoTen] = @hoTen,
    [NgaySinh] = @ngaySinh,
    [GioiTinh] = @gioiTinh,
    [CMND] = @cMND,
    [SDT] = @sDT,
    [QueQuan] = @queQuan,
    [HocHam] = @hocHam,
    [HocVi] = @hocVi,
    [MaKhoa] = @maKhoa
  WHERE
      [MaGiangVien] = @maGiangVien 

GO

-- Cập nhật kết quả học tập
DROP PROCEDURE Proc_UpdateKetQuaHocTap
GO

CREATE PROCEDURE Proc_UpdateKetQuaHocTap(
    @maSinhVien NVARCHAR(32),
    @maLop NVARCHAR(32),
    @diemGiuaKy FLOAT,
    @diemCuoiKy FLOAT
)
AS
  IF (@maSinhVien IS NULL OR LEN(@maSinhVien) = 0)
    BEGIN
      RAISERROR(N'Mã sinh viên không được trống', 16, 1);
      RETURN;
    END

  IF (@maLop IS NULL OR LEN(@maLop) = 0)
    BEGIN
      RAISERROR(N'Mã lớp không được trống', 16, 1);
      RETURN;
    END

  IF (@diemGiuaKy IS NULL OR LEN(@diemGiuaKy) = 0)
    BEGIN
      RAISERROR(N'Điểm giữa kì không được trống', 16, 1);
      RETURN;
    END

  IF (@diemCuoiKy IS NULL OR LEN(@diemCuoiKy) = 0)
    BEGIN
      RAISERROR(N'Điểm cuối kì không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@diemGiuaKy IS NULL OR @diemGiuaKy BETWEEN 0 AND 10)
    BEGIN
      RAISERROR(N'Điểm giữa kì phải nằm giữa 0 và 10 điểm', 16, 1);
      RETURN;
    END

  IF NOT (@diemCuoiKy IS NULL OR @diemCuoiKy BETWEEN 0 AND 10)
    BEGIN
      RAISERROR(N'Điểm cuối kì phải nằm giữa 0 và 10 điểm', 16, 1);
      RETURN;
    END

  UPDATE [KetQuaHocTap]
  SET
    [DiemGiuaKy] = @diemGiuaKy,
    [DiemCuoiKy] = @diemCuoiKy
  WHERE
      [MaSinhVien] = @maSinhVien AND
      [MaLop] = @maLop 

GO

-- Cập nhật khoa
DROP PROCEDURE Proc_UpdateKhoa
GO

CREATE PROCEDURE Proc_UpdateKhoa(
    @maKhoa NVARCHAR(32),
    @tenKhoa NVARCHAR(MAX),
    @heDaoTao NVARCHAR(MAX),
    @ngayThanhLap DATETIME2
)
AS
  IF (@maKhoa IS NULL OR LEN(@maKhoa) = 0)
    BEGIN
      RAISERROR(N'Mã khoa không được trống', 16, 1);
      RETURN;
    END

  IF (@tenKhoa IS NULL OR LEN(@tenKhoa) = 0)
    BEGIN
      RAISERROR(N'Tên khoa không được trống', 16, 1);
      RETURN;
    END

  IF (@heDaoTao IS NULL OR LEN(@heDaoTao) = 0)
    BEGIN
      RAISERROR(N'Hệ đào tạo không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayThanhLap IS NULL OR LEN(@ngayThanhLap) = 0)
    BEGIN
      RAISERROR(N'Ngày thành lập không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@heDaoTao IN (N'Chất lượng cao', N'Đại trà'))
    BEGIN
      RAISERROR(N'Hệ đào tạo phải là Chất lượng cao hoặc đại trà', 16, 1);
      RETURN;
    END

  UPDATE [Khoa]
  SET
    [TenKhoa] = @tenKhoa,
    [HeDaoTao] = @heDaoTao,
    [NgayThanhLap] = @ngayThanhLap
  WHERE
      [MaKhoa] = @maKhoa 

GO

-- Cập nhật lớp
DROP PROCEDURE Proc_UpdateLop
GO

CREATE PROCEDURE Proc_UpdateLop(
    @maLop NVARCHAR(32),
    @maHocKy NVARCHAR(32),
    @maMonHoc NVARCHAR(32),
    @maGiangVien NVARCHAR(32),
    @lichHoc NVARCHAR(MAX),
    @ngayBatDau DATETIME2,
    @ngayKetThuc DATETIME2,
    @gioiHan INT
)
AS
  IF (@maLop IS NULL OR LEN(@maLop) = 0)
    BEGIN
      RAISERROR(N'Mã lớp không được trống', 16, 1);
      RETURN;
    END

  IF (@maHocKy IS NULL OR LEN(@maHocKy) = 0)
    BEGIN
      RAISERROR(N'Mã học kỳ không được trống', 16, 1);
      RETURN;
    END

  IF (@maMonHoc IS NULL OR LEN(@maMonHoc) = 0)
    BEGIN
      RAISERROR(N'Mã môn học không được trống', 16, 1);
      RETURN;
    END

  IF (@maGiangVien IS NULL OR LEN(@maGiangVien) = 0)
    BEGIN
      RAISERROR(N'Mã giảng viên không được trống', 16, 1);
      RETURN;
    END

  IF (@lichHoc IS NULL OR LEN(@lichHoc) = 0)
    BEGIN
      RAISERROR(N'Lịch học không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayBatDau IS NULL OR LEN(@ngayBatDau) = 0)
    BEGIN
      RAISERROR(N'Ngày bắt đầu không được trống', 16, 1);
      RETURN;
    END

  IF (@ngayKetThuc IS NULL OR LEN(@ngayKetThuc) = 0)
    BEGIN
      RAISERROR(N'Ngày kết thúc không được trống', 16, 1);
      RETURN;
    END

  IF (@gioiHan IS NULL OR LEN(@gioiHan) = 0)
    BEGIN
      RAISERROR(N'Giới hạn không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@gioiHan BETWEEN 1 AND 200)
    BEGIN
      RAISERROR(N'Giới hạn sinh viên trong lớp phải từ 1 đến 200', 16, 1);
      RETURN;
    END

  IF NOT (@ngayBatDau < @ngayKetThuc)
    BEGIN
      RAISERROR(N'Ngày bắt đầu phải bé hơn ngày kết thúc', 16, 1);
      RETURN;
    END

  UPDATE [Lop]
  SET
    [MaHocKy] = @maHocKy,
    [MaMonHoc] = @maMonHoc,
    [MaGiangVien] = @maGiangVien,
    [LichHoc] = @lichHoc,
    [NgayBatDau] = @ngayBatDau,
    [NgayKetThuc] = @ngayKetThuc,
    [GioiHan] = @gioiHan
  WHERE
      [MaLop] = @maLop 

GO

-- Cập nhật môn học
DROP PROCEDURE Proc_UpdateMonHoc
GO

CREATE PROCEDURE Proc_UpdateMonHoc(
    @maMonHoc NVARCHAR(32),
    @tenMonHoc NVARCHAR(MAX),
    @moTa NVARCHAR(MAX),
    @sTC INT,
    @loaiHocPhan NVARCHAR(128),
    @maKhoa NVARCHAR(32)
)
AS
  IF (@maMonHoc IS NULL OR LEN(@maMonHoc) = 0)
    BEGIN
      RAISERROR(N'Mã môn học không được trống', 16, 1);
      RETURN;
    END

  IF (@tenMonHoc IS NULL OR LEN(@tenMonHoc) = 0)
    BEGIN
      RAISERROR(N'Tên môn học không được trống', 16, 1);
      RETURN;
    END

  IF (@moTa IS NULL OR LEN(@moTa) = 0)
    BEGIN
      RAISERROR(N'Mô tả không được trống', 16, 1);
      RETURN;
    END

  IF (@sTC IS NULL OR LEN(@sTC) = 0)
    BEGIN
      RAISERROR(N'Số tín chỉ (STC) không được trống', 16, 1);
      RETURN;
    END

  IF (@loaiHocPhan IS NULL OR LEN(@loaiHocPhan) = 0)
    BEGIN
      RAISERROR(N'Loại học phần không được trống', 16, 1);
      RETURN;
    END

  IF (@maKhoa IS NULL OR LEN(@maKhoa) = 0)
    BEGIN
      RAISERROR(N'Mã khoa không được trống', 16, 1);
      RETURN;
    END

  IF NOT (@loaiHocPhan IN (N'Thực hành', N'Lý thuyết'))
    BEGIN
      RAISERROR(N'Loại học phần phải là thực hàn hoặc lý thuyết', 16, 1);
      RETURN;
    END

  IF NOT (@sTC > 0)
    BEGIN
      RAISERROR(N'Số tín chỉ phải lớn hơn 0', 16, 1);
      RETURN;
    END

  UPDATE [MonHoc]
  SET
    [TenMonHoc] = @tenMonHoc,
    [MoTa] = @moTa,
    [STC] = @sTC,
    [LoaiHocPhan] = @loaiHocPhan,
    [MaKhoa] = @maKhoa
  WHERE
      [MaMonHoc] = @maMonHoc 

GO

-- Cập nhật sinh viên
DROP PROCEDURE Proc_UpdateSinhVien
GO

CREATE PROCEDURE Proc_UpdateSinhVien(
    @maSinhVien NVARCHAR(32),
    @hoTen NVARCHAR(MAX),
    @ngaySinh DATETIME2,
    @gioiTinh NVARCHAR(3),
    @cMND NVARCHAR(20),
    @sDT NVARCHAR(20),
    @queQuan NVARCHAR(MAX),
    @maKhoa NVARCHAR(32)
)
AS
  IF (@maSinhVien IS NULL OR LEN(@maSinhVien) = 0)
    BEGIN
      RAISERROR(N'Mã sinh viên không được trống', 16, 1);
      RETURN;
    END

  IF (@hoTen IS NULL OR LEN(@hoTen) = 0)
    BEGIN
      RAISERROR(N'Họ và tên không được trống', 16, 1);
      RETURN;
    END

  IF (@ngaySinh IS NULL OR LEN(@ngaySinh) = 0)
    BEGIN
      RAISERROR(N'Ngày sinh không được trống', 16, 1);
      RETURN;
    END

  IF (@gioiTinh IS NULL OR LEN(@gioiTinh) = 0)
    BEGIN
      RAISERROR(N'Giới tính không được trống', 16, 1);
      RETURN;
    END

  IF (@cMND IS NULL OR LEN(@cMND) = 0)
    BEGIN
      RAISERROR(N'CMND không được trống', 16, 1);
      RETURN;
    END

  IF (@sDT IS NULL OR LEN(@sDT) = 0)
    BEGIN
      RAISERROR(N'Số điện thoại không được trống', 16, 1);
      RETURN;
    END

  IF (@queQuan IS NULL OR LEN(@queQuan) = 0)
    BEGIN
      RAISERROR(N'Quê quán không được trống', 16, 1);
      RETURN;
    END

  IF (@maKhoa IS NULL OR LEN(@maKhoa) = 0)
    BEGIN
      RAISERROR(N'Mã khoa không được trống', 16, 1);
      RETURN;
    END

  IF NOT (LEN(@cMND) BETWEEN 9 AND 12)
    BEGIN
      RAISERROR(N'Độ dài CMND phải từ 9 đến 12 ký tự', 16, 1);
      RETURN;
    END

  IF NOT (@gioiTinh IN (N'Nam', N'Nữ'))
    BEGIN
      RAISERROR(N'Giới tính phải là nam hoặc nữ', 16, 1);
      RETURN;
    END

  IF NOT (LEN(@maSinhVien) = 8)
    BEGIN
      RAISERROR(N'Mã sinh viên phải có 8 ký tự', 16, 1);
      RETURN;
    END

  UPDATE [SinhVien]
  SET
    [HoTen] = @hoTen,
    [NgaySinh] = @ngaySinh,
    [GioiTinh] = @gioiTinh,
    [CMND] = @cMND,
    [SDT] = @sDT,
    [QueQuan] = @queQuan,
    [MaKhoa] = @maKhoa
  WHERE
      [MaSinhVien] = @maSinhVien 

GO

