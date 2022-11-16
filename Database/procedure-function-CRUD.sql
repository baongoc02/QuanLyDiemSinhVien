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
-- Xóa dữ liệu ở bảng Khoa
CREATE PROCEDURE Proc_DeleteKhoa(
    @maKhoa NVARCHAR(32) 
)
AS
  DELETE FROM Khoa
  WHERE
      [MaKhoa] = @maKhoa
-- Xóa dữ liệu ở bảng MonHoc
CREATE PROCEDURE Proc_DeleteMonHoc(
    @maMonHoc NVARCHAR(32) 
)
AS
  DELETE FROM MonHoc
  WHERE
      [MaMonHoc] = @maMonHoc
-- Xóa dữ liệu ở bảng SinhVien
CREATE PROCEDURE Proc_DeleteSinhVien(
    @maSinhVien NVARCHAR(32) 
)
AS
  DELETE FROM SinhVien
  WHERE
      [MaSinhVien] = @maSinhVien
-- Xóa dữ liệu ở bảng GiangVien
CREATE PROCEDURE Proc_DeleteGiangVien(
    @maGiangVien NVARCHAR(32) 
)
AS
  DELETE FROM GiangVien
  WHERE
      [MaGiangVien] = @maGiangVien
-- Xóa dữ liệu ở bảng Lop
CREATE PROCEDURE Proc_DeleteLop(
    @maLop NVARCHAR(32) 
)
AS
  DELETE FROM Lop
  WHERE
      [MaLop] = @maLop
-- Xóa dữ liệu ở bảng HocKy
CREATE PROCEDURE Proc_DeleteHocKy(
    @maHocKy NVARCHAR(32) 
)
AS
  DELETE FROM HocKy
  WHERE
      [MaHocKy] = @maHocKy
-- Xóa dữ liệu ở bảng NamHoc 
CREATE PROCEDURE Proc_DeleteNamHoc(
    @maNamHoc NVARCHAR(32) 
)
AS
  DELETE FROM NamHoc
  WHERE
      [MaNamHoc] = @maNamHoc
-- Xóa dữ liệu ở bảng KetQuaHocTap
CREATE PROCEDURE Proc_DeleteKetQuaHocTap(
    @maSinhVien NVARCHAR(32) ,
    @maLop NVARCHAR(32) 
)
AS
  DELETE FROM KetQuaHocTap
  WHERE
      [MaSinhVien] = @maSinhVien AND
      [MaLop] = @maLop 
GO
-- Xem dữ liệu sử dụng View, Function, Procedure
-- Bảng Khoa
CREATE VIEW View_ListAllKhoa
AS
  SELECT
      [Khoa].MaKhoa as 'KhoaMaKhoa',
      [Khoa].TenKhoa as 'KhoaTenKhoa',
      [Khoa].HeDaoTao as 'KhoaHeDaoTao',
      [Khoa].NgayThanhLap as 'KhoaNgayThanhLap'
  FROM Khoa
-- Bảng MonHoc
CREATE VIEW View_ListAllMonHoc
AS
  SELECT
      [MonHoc].MaMonHoc as 'MonHocMaMonHoc',
      [MonHoc].TenMonHoc as 'MonHocTenMonHoc',
      [MonHoc].MoTa as 'MonHocMoTa',
      [MonHoc].STC as 'MonHocSTC',
      [MonHoc].LoaiHocPhan as 'MonHocLoaiHocPhan',
      [MonHoc].MaKhoa as 'MonHocMaKhoa',
      [Khoa].TenKhoa as 'KhoaTenKhoa',
      [Khoa].HeDaoTao as 'KhoaHeDaoTao',
      [Khoa].NgayThanhLap as 'KhoaNgayThanhLap'
  FROM MonHoc
    INNER JOIN Khoa ON MonHoc.MaKhoa = Khoa.MaKhoa
GO
-- Bảng SinhVien
CREATE VIEW View_ListAllSinhVien
AS
  SELECT
      [SinhVien].MaSinhVien as 'SinhVienMaSinhVien',
      [SinhVien].HoTen as 'SinhVienHoTen',
      [SinhVien].NgaySinh as 'SinhVienNgaySinh',
      [SinhVien].GioiTinh as 'SinhVienGioiTinh',
      [SinhVien].CMND as 'SinhVienCMND',
      [SinhVien].SDT as 'SinhVienSDT',
      [SinhVien].QueQuan as 'SinhVienQueQuan',
      [SinhVien].MaKhoa as 'SinhVienMaKhoa',
      [Khoa].TenKhoa as 'KhoaTenKhoa',
      [Khoa].HeDaoTao as 'KhoaHeDaoTao',
      [Khoa].NgayThanhLap as 'KhoaNgayThanhLap'
  FROM SinhVien
    INNER JOIN Khoa ON SinhVien.MaKhoa = Khoa.MaKhoa
GO
-- Bảng GiangVien
CREATE VIEW View_ListAllGiangVien
AS
  SELECT
      [GiangVien].MaGiangVien as 'GiangVienMaGiangVien',
      [GiangVien].HoTen as 'GiangVienHoTen',
      [GiangVien].NgaySinh as 'GiangVienNgaySinh',
      [GiangVien].GioiTinh as 'GiangVienGioiTinh',
      [GiangVien].CMND as 'GiangVienCMND',
      [GiangVien].SDT as 'GiangVienSDT',
      [GiangVien].QueQuan as 'GiangVienQueQuan',
      [GiangVien].HocHam as 'GiangVienHocHam',
      [GiangVien].HocVi as 'GiangVienHocVi',
      [GiangVien].MaKhoa as 'GiangVienMaKhoa',
      [Khoa].TenKhoa as 'KhoaTenKhoa',
      [Khoa].HeDaoTao as 'KhoaHeDaoTao',
      [Khoa].NgayThanhLap as 'KhoaNgayThanhLap'
  FROM GiangVien
    INNER JOIN Khoa ON GiangVien.MaKhoa = Khoa.MaKhoa
GO
-- Bảng LopHoc
CREATE VIEW View_ListAllLop
AS
  SELECT
      [Lop].MaLop as 'LopMaLop',
      [Lop].MaHocKy as 'LopMaHocKy',
      [Lop].MaMonHoc as 'LopMaMonHoc',
      [Lop].MaGiangVien as 'LopMaGiangVien',
      [Lop].LichHoc as 'LopLichHoc',
      [Lop].NgayBatDau as 'LopNgayBatDau',
      [Lop].NgayKetThuc as 'LopNgayKetThuc',
      [Lop].GioiHan as 'LopGioiHan',
      [GiangVien].HoTen as 'GiangVienHoTen',
      [GiangVien].NgaySinh as 'GiangVienNgaySinh',
      [GiangVien].GioiTinh as 'GiangVienGioiTinh',
      [GiangVien].CMND as 'GiangVienCMND',
      [GiangVien].SDT as 'GiangVienSDT',
      [GiangVien].QueQuan as 'GiangVienQueQuan',
      [GiangVien].HocHam as 'GiangVienHocHam',
      [GiangVien].HocVi as 'GiangVienHocVi',
      [GiangVien].MaKhoa as 'GiangVienMaKhoa',
      [HocKy].TenHocKy as 'HocKyTenHocKy',
      [HocKy].NgayBatDau as 'HocKyNgayBatDau',
      [HocKy].NgayKetThuc as 'HocKyNgayKetThuc',
      [HocKy].MaNamHoc as 'HocKyMaNamHoc',
      [MonHoc].TenMonHoc as 'MonHocTenMonHoc',
      [MonHoc].MoTa as 'MonHocMoTa',
      [MonHoc].STC as 'MonHocSTC',
      [MonHoc].LoaiHocPhan as 'MonHocLoaiHocPhan',
      [MonHoc].MaKhoa as 'MonHocMaKhoa'
  FROM Lop
    INNER JOIN GiangVien ON Lop.MaGiangVien = GiangVien.MaGiangVien
    INNER JOIN HocKy ON Lop.MaHocKy = HocKy.MaHocKy
    INNER JOIN MonHoc ON Lop.MaMonHoc = MonHoc.MaMonHoc
GO
-- Bảng HocKy
CREATE VIEW View_ListAllHocKy
AS
  SELECT
      [HocKy].MaHocKy as 'HocKyMaHocKy',
      [HocKy].TenHocKy as 'HocKyTenHocKy',
      [HocKy].NgayBatDau as 'HocKyNgayBatDau',
      [HocKy].NgayKetThuc as 'HocKyNgayKetThuc',
      [HocKy].MaNamHoc as 'HocKyMaNamHoc',
      [NamHoc].TenNamHoc as 'NamHocTenNamHoc'
  FROM HocKy
    INNER JOIN NamHoc ON HocKy.MaNamHoc = NamHoc.MaNamHoc
GO
-- Bảng NamHoc
CREATE VIEW View_ListAllNamHoc
AS
  SELECT
      [NamHoc].MaNamHoc as 'NamHocMaNamHoc',
      [NamHoc].TenNamHoc as 'NamHocTenNamHoc'
  FROM NamHoc
GO
-- Bảng KetQuaHocTap
CREATE VIEW View_ListAllKetQuaHocTap
AS
  SELECT
      [KetQuaHocTap].MaSinhVien as 'KetQuaHocTapMaSinhVien',
      [KetQuaHocTap].MaLop as 'KetQuaHocTapMaLop',
      [KetQuaHocTap].DiemGiuaKy as 'KetQuaHocTapDiemGiuaKy',
      [KetQuaHocTap].DiemCuoiKy as 'KetQuaHocTapDiemCuoiKy',
      [Lop].MaHocKy as 'LopMaHocKy',
      [Lop].MaMonHoc as 'LopMaMonHoc',
      [Lop].MaGiangVien as 'LopMaGiangVien',
      [Lop].LichHoc as 'LopLichHoc',
      [Lop].NgayBatDau as 'LopNgayBatDau',
      [Lop].NgayKetThuc as 'LopNgayKetThuc',
      [Lop].GioiHan as 'LopGioiHan',
      [SinhVien].HoTen as 'SinhVienHoTen',
      [SinhVien].NgaySinh as 'SinhVienNgaySinh',
      [SinhVien].GioiTinh as 'SinhVienGioiTinh',
      [SinhVien].CMND as 'SinhVienCMND',
      [SinhVien].SDT as 'SinhVienSDT',
      [SinhVien].QueQuan as 'SinhVienQueQuan',
      [SinhVien].MaKhoa as 'SinhVienMaKhoa'
  FROM KetQuaHocTap
    INNER JOIN Lop ON KetQuaHocTap.MaLop = Lop.MaLop
    INNER JOIN SinhVien ON KetQuaHocTap.MaSinhVien = SinhVien.MaSinhVien
GO
-- 5. Xem danh sách sinh viên theo khoa
CREATE VIEW view_xemDanhSachToanBoMonHoc
AS
    SELECT MaLop, TenHocKy, TenNamHoc, HoTen, TenMonHoc, LichHoc
    FROM Lop
        INNER JOIN HocKy
            ON Lop.MaHocKy = HocKy.MaHocKy
        INNER JOIN NamHoc
            ON HocKy.MaNamHoc = NamHoc.MaNamHoc
        INNER JOIN GiangVien
            ON Lop.MaGiangVien = GiangVien.MaGiangVien
        INNER JOIN MonHoc
            ON Lop.MaMonHoc = MonHoc.MaMonHoc
GO
-- 6. Xem điểm theo mã số sinh viên của một học kỳ
	CREATE PROCEDURE prc_XemDiemTheoMSSV_TrenHocKy(@maSV NVARCHAR(32), @maHocKy NVARCHAR(32))
AS
    SELECT SinhVien.MaSinhVien, HoTen, DiemGiuaKy, DiemCuoiKy, (DiemGiuaKy + DiemCuoiKy) / 2 as DTB, Lop.MaHocKy
    FROM SinhVien
        INNER JOIN KetQuaHocTap
            ON KetQuaHocTap.MaSinhVien = SinhVien.MaSinhVien
        INNER JOIN Lop
            ON Lop.MaLop = KetQuaHocTap.MaLop
    WHERE SinhVien.MaSinhVien = @maSV AND Lop.MaHocKy = @maHocKy
GO
-- 7. Xem điểm theo mã lớp
	CREATE PROCEDURE prc_XemDiemTheoLop(@maLop NVARCHAR(32))
AS
    SELECT Lop.MaLop, SinhVien.MaSinhVien, DiemGiuaKy, DiemCuoiKy, (DiemGiuaKy + DiemCuoiKy) / 2 as DTB
    FROM Lop
        INNER JOIN KetQuaHocTap
            ON KetQuaHocTap.MaLop = Lop.MaLop
        INNER JOIN SinhVien
            ON SinhVien.MaSinhVien = KetQuaHocTap.MaSinhVien
    WHERE Lop.MaLop = @maLop
GO
-- 8. Thống kê điểm theo lớp
	CREATE PROCEDURE fn_ThongKeDiemTheoLop(@maLop NVARCHAR(32))
AS
BEGIN
    SELECT KetQua, count(*) AS SoLuong
    FROM
    (
        SELECT (
            CASE
                WHEN DTB < 3.0 THEN 'Yeu'
                WHEN 3.0 <= DTB AND DTB < 5.0 THEN 'Trung Binh'
                WHEN 5.0 <= DTB AND DTB < 8.0 THEN 'Kha'
                ELSE 'Gioi'
            END
        ) AS KetQua FROM (
            SELECT (DiemGiuaKy + DiemCuoiKy) / 2 AS DTB
            FROM KetQuaHocTap
            WHERE MaLop = @maLop
        ) AS A
    ) AS B
    GROUP BY KetQua
END
GO
-- 9. Thống kê điểm theo môn trên từng học kỳ
	CREATE PROCEDURE fn_ThongKeDiemTheoMon_TrenHocKy(@maMon NVARCHAR(32), @maHocKy NVARCHAR(32))
AS
BEGIN
    SELECT KetQua, count(*) AS SoLuong
    FROM
    (
        SELECT (
            CASE
                WHEN DTB < 3.0 THEN 'Yeu'
                WHEN 3.0 <= DTB AND DTB < 5.0 THEN 'Trung Binh'
                WHEN 5.0 <= DTB AND DTB < 8.0 THEN 'Kha'
                ELSE 'Gioi'
            END
        ) AS KetQua FROM 
        (
            SELECT (DiemGiuaKy + DiemCuoiKy) / 2 AS DTB
            FROM MonHoc
                INNER JOIN Lop
                    ON Lop.MaMonHoc = MonHoc.MaMonHoc
                INNER JOIN HocKy
                    ON HocKy.MaHocKy = Lop.MaHocKy
                INNER JOIN KetQuaHocTap
                    ON KetQuaHocTap.MaLop = Lop.MaLop
        ) AS A
    ) AS B
    GROUP BY KetQua
END
GO
-- 10. Danh sách giảng viên theo khoa (xem thông tin một giảng viên)
	CREATE FUNCTION F_GV_Khoa(@MaKhoa NVARCHAR(32))
RETURNS TABLE
AS 
RETURN(
    SELECT MaGiangVien, HoTen, NgaySinh, GioiTinh, CMND, 
        SDT, QueQUan, HocHam, HocVi, Khoa.TenKhoa
    FROM GiangVien AS GV 
        INNER JOIN Khoa 
        ON GV.MaKhoa=Khoa.MaKhoa
    WHERE Khoa.MaKhoa=@MaKhoa
)
GO
-- 11. Danh sách sinh viên theo khoa (xem thông tin một sinh viên)
	CREATE FUNCTION F_SV_Khoa(@MaKhoa NVARCHAR(32))
RETURNS TABLE
AS
RETURN(
    SELECT MaSinhVien, HoTen, NgaySinh,
        GioiTinh, CMND, SDT, QueQuan, Khoa.TenKhoa
    FROM SinhVien AS SV 
        INNER JOIN Khoa 
        ON SV.MaKhoa=Khoa.MaKhoa
    WHERE Khoa.MaKhoa=@MaKhoa
)
GO
-- 12. Danh sách môn theo khoa (xem thông tin một môn)
	CREATE FUNCTION F_Mon_Khoa(@MaKhoa NVARCHAR(32))
RETURNS TABLE
AS 
RETURN(
    SELECT MaMonHoc, TenMonHoc, MoTa, STC, Khoa.TenKhoa
    FROM MonHoc
        INNER JOIN Khoa 
        ON MonHoc.MaKhoa=Khoa.MaKhoa
    WHERE MonHoc.MaKhoa=@MaKhoa
)
GO
-- 13. Danh sách lớp theo giảng viên trên từng học kỳ (xem thông tin một lớp)
	CREATE FUNCTION F_Lop_GV_HocKy(@MaGV NVARCHAR(32), @MaHocKy NVARCHAR(32))
RETURNS TABLE
AS 
RETURN(
    SELECT Lop.MaLop, HocKy.TenHocKy, MonHoc.TenMonHoc, 
        GiangVien.HoTen, Lop.LichHoc, Lop.NgayBatDau, Lop.NgayKetThuc, Lop.Gioihan
    FROM Lop
        INNER JOIN HocKy ON Lop.MaHocKy=HocKy.MaHocKy
        INNER JOIN MonHoc ON Lop.MaMonhoc=MonHoc.MaMonHoc
        INNER JOIN GiangVien ON Lop.MaGiangVien=GiangVien.MaGiangVien
    WHERE Lop.MaGiangVien=@MaGV AND Lop.MaHocKy=@MaHocKy
)
GO
-- 14. Xem kết quả học tập theo từng sinh viên
	-- ds kết quả học tập của sinh viên theo mã sinh viên
CREATE PROCEDURE Proc_KetQuaHocTapTheoSinhVien (
	@maSinhVien NVARCHAR(32)
)
AS
	SELECT
		[SinhVien].HoTen as TenSinhVien,
		[Lop].MaLop as MaLop,
		[MonHoc].TenMonHoc as TenMonHoc,
		[KetQuaHocTap].DiemGiuaKy as DiemGiuaKy,
		[KetQuaHocTap].DiemCuoiKy as DiemCuoiKy,
		(DiemCuoiKy + DiemGiuaKy) / 2 as DiemTrungBinh,
		(
			CASE
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 9 AND 10) THEN N'Xuất sắc'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 8 AND 9) THEN N'Giỏi'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 6.5 AND 8) THEN N'Khá'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 5 AND 6.5) THEN N'Trung bình'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 3 AND 5) THEN N'Yếu'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 1 AND 3) THEN N'Kém'
				ELSE '<Unknown>'
			END
		) as Loai
	FROM [KetQuaHocTap]
		INNER JOIN [SinhVien] ON [SinhVien].MaSinhVien = [KetQuaHocTap].MaSinhVien
		INNER JOIN [Lop] ON [Lop].MaLop = [KetQuaHocTap].MaLop
		INNER JOIN [MonHoc] ON [Lop].MaMonHoc = [MonHoc].MaMonHoc
	WHERE [DiemCuoiKy] IS NOT NULL AND [DiemGiuaKy] IS NOT NULL AND [SinhVien].MaSinhVien = @maSinhVien
GO

-- tính tổng số tín chỉ và điểm trung bình tích lũy + xếp loại theo mssv
-- ds kết quả học tập của sinh viên theo mã sinh viên
DROP PROCEDURE Proc_KetQuaHocTapTheoSinhVien
GO

CREATE PROCEDURE Proc_KetQuaHocTapTheoSinhVien (
	@maSinhVien NVARCHAR(32)
)
AS
	SELECT
		[SinhVien].MaSinhVien as MaSinhVien,
		[SinhVien].HoTen as TenSinhVien,
		[Lop].MaLop as MaLop,
		[MonHoc].TenMonHoc as TenMonHoc,
		(DiemCuoiKy + DiemGiuaKy) / 2 as DiemTrungBinh,
		(
			CASE
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 9 AND 10) THEN N'Xuất sắc'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 8 AND 9) THEN N'Giỏi'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 6.5 AND 8) THEN N'Khá'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 5 AND 6.5) THEN N'Trung bình'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 3 AND 5) THEN N'Yếu'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 1 AND 3) THEN N'Kém'
				ELSE '<Unknown>'
			END
		) as Loai
	FROM [KetQuaHocTap]
		INNER JOIN [SinhVien] ON [SinhVien].MaSinhVien = [KetQuaHocTap].MaSinhVien
		INNER JOIN [Lop] ON [Lop].MaLop = [KetQuaHocTap].MaLop
		INNER JOIN [MonHoc] ON [Lop].MaMonHoc = [MonHoc].MaMonHoc
	WHERE [DiemCuoiKy] IS NOT NULL AND [DiemGiuaKy] IS NOT NULL AND [SinhVien].MaSinhVien LIKE CONCAT('%', @maSinhVien, '%')
GO
-- Lấy điểm trung bình tích lũy, tổng số tín chỉ tích lũy, xếp loại của sinh viên theo mã số sinh viên
drop procedure proc_TinhSTCAndDiemTrungBinh
go
create procedure proc_TinhSTCAndDiemTrungBinh(
	@maSinhVien nvarchar(32)
)
	as
	select 
		avg((DiemCuoiKy + DiemGiuaKy)/2) as DiemTrungBinh,
		(
			CASE
				WHEN (avg((DiemCuoiKy + DiemGiuaKy)/2) BETWEEN 9 AND 10) THEN N'Xuất sắc'
				WHEN (avg((DiemCuoiKy + DiemGiuaKy)/2) BETWEEN 8 AND 9) THEN N'Giỏi'
				WHEN (avg((DiemCuoiKy + DiemGiuaKy)/2) BETWEEN 6.5 AND 8) THEN N'Khá'
				WHEN (avg((DiemCuoiKy + DiemGiuaKy)/2) BETWEEN 5 AND 6.5) THEN N'Trung bình'
				WHEN (avg((DiemCuoiKy + DiemGiuaKy)/2) BETWEEN 3 AND 5) THEN N'Yếu'
				WHEN (avg((DiemCuoiKy + DiemGiuaKy)/2) BETWEEN 0 AND 3) THEN N'Kém'
				ELSE '<Unknown>'
			END
		) as Loai,
		(
			sum([MonHoc].STC)
		)as TongSTC
	from [KetQuaHocTap]
		INNER JOIN [SinhVien] ON [SinhVien].MaSinhVien = [KetQuaHocTap].MaSinhVien
		INNER JOIN [Lop] ON [Lop].MaLop = [KetQuaHocTap].MaLop
		INNER JOIN [MonHoc] ON [Lop].MaMonHoc = [MonHoc].MaMonHoc
	where [DiemCuoiKy] IS NOT NULL AND [DiemGiuaKy] IS NOT NULL AND [SinhVien].MaSinhVien LIKE CONCAT('%', @maSinhVien, '%') and ((DiemGiuaKy+DIemCuoiKy)/2 >=5)
	group by [KetQuaHocTap].MaSinhVien
GO
-- xem dssv trong 1 môn hoặc một lớp theo xếp loại (giỏi khá trung bình yếu..)(kết quả học tập thêm 1 cái là tìm dssv theo cột điểm trung bình)
drop procedure Proc_KetQuaHocTapTheoMaLopVaXepLoai
go
CREATE PROCEDURE Proc_KetQuaHocTapTheoMaLopVaXepLoai (
	@maLop NVARCHAR(32),
	@mucDiemTren float,
	@mucDiemDuoi float
)
AS
	SELECT
		[SinhVien].HoTen as TenSinhVien,
		[Lop].MaLop as MaLop,
		[MonHoc].TenMonHoc as TenMonHoc,
		(DiemCuoiKy + DiemGiuaKy) / 2 as DiemTrungBinh,
		(
			CASE
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 9 AND 10) THEN N'Xuất sắc'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 8 AND 9) THEN N'Giỏi'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 6.5 AND 8) THEN N'Khá'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 5 AND 6.5) THEN N'Trung bình'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 3 AND 5) THEN N'Yếu'
				WHEN ((DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN 1 AND 3) THEN N'Kém'
				ELSE '<Unknown>'
			END
		) as Loai
	FROM [KetQuaHocTap]
		INNER JOIN [SinhVien] ON [SinhVien].MaSinhVien = [KetQuaHocTap].MaSinhVien
		INNER JOIN [Lop] ON [Lop].MaLop = [KetQuaHocTap].MaLop
		INNER JOIN [MonHoc] ON [Lop].MaMonHoc = [MonHoc].MaMonHoc
	WHERE [DiemCuoiKy] IS NOT NULL AND [DiemGiuaKy] IS NOT NULL AND [Lop].MaLop LIKE CONCAT('%', @maLop, '%') and (DiemCuoiKy + DiemGiuaKy) / 2 BETWEEN @mucDiemDuoi AND @mucDiemTren
GO
-- xem dssv ko đạt 1 môn học trong một học kỳ cụ thể
drop procedure Proc_DSSVKhongDatMonHoc

go
create procedure Proc_DSSVKhongDatMonHoc
(
	@maMonHoc nvarchar(32),
	@maHocKy nvarchar(32)
)
as 
	select 
		[SinhVien].MaSinhVien as MaSinhVien,
		[SinhVien].HoTen as HoTen,
		((DiemGiuaKy+DIemCuoiKy)/2) as DiemTrungBinh,
		[Khoa].TenKhoa as Khoa
	from [MonHoc]
		INNER JOIN [Lop] ON [Lop].MaMonHoc = MonHoc.MaMonHoc
		INNER JOIN [KetQuaHocTap] ON [Lop].MaLop = [KetQuaHocTap].MaLop
		INNER JOIN [SinhVien] ON [KetQuaHocTap].MaSinhVien = [SinhVien].MaSinhVien
		INNER JOIN HocKy ON [Lop].MaHocKy = HocKy.MaHocKy
		INNER JOIN Khoa ON [Khoa].MaKhoa = SinhVien.MaKhoa
	where [MonHoc].MaMonHoc LIKE CONCAT('%', @maMonHoc, '%') and [HocKy].MaHocKy LIKE CONCAT('%', @maHocKy, '%') and ((DiemGiuaKy+DIemCuoiKy)/2 <5)
GO
-- Tìm
-- Lấy danh sách toàn bộ Học kỳ
DROP PROCEDURE Proc_ListAllHocKy;
GO

CREATE PROCEDURE Proc_ListAllHocKy (
  @maHocKy NVARCHAR(32),
  @tenHocKy NVARCHAR(128),
  @maNamHoc NVARCHAR(32))
AS
  SELECT
      [HocKy].MaHocKy as 'HocKyMaHocKy',
      [HocKy].TenHocKy as 'HocKyTenHocKy',
      [HocKy].NgayBatDau as 'HocKyNgayBatDau',
      [HocKy].NgayKetThuc as 'HocKyNgayKetThuc',
      [HocKy].MaNamHoc as 'HocKyMaNamHoc',
      [NamHoc].TenNamHoc as 'NamHocTenNamHoc'
  FROM HocKy
    INNER JOIN NamHoc ON HocKy.MaNamHoc = NamHoc.MaNamHoc
  WHERE
    [HocKy].[MaHocKy] LIKE CONCAT('%', @maHocKy, '%') AND
    [HocKy].[TenHocKy] LIKE CONCAT('%', @tenHocKy, '%') AND
    [HocKy].[MaNamHoc] LIKE CONCAT('%', @maNamHoc, '%')

GO

-- Lấy danh sách toàn bộ Năm học
DROP PROCEDURE Proc_ListAllNamHoc;
GO

CREATE PROCEDURE Proc_ListAllNamHoc (
  @maNamHoc NVARCHAR(32),
  @tenNamHoc NVARCHAR(128))
AS
  SELECT
      [NamHoc].MaNamHoc as 'NamHocMaNamHoc',
      [NamHoc].TenNamHoc as 'NamHocTenNamHoc'
  FROM NamHoc
  WHERE
    [NamHoc].[MaNamHoc] LIKE CONCAT('%', @maNamHoc, '%') AND
    [NamHoc].[TenNamHoc] LIKE CONCAT('%', @tenNamHoc, '%')

GO

-- Lấy danh sách toàn bộ Giảng viên
DROP PROCEDURE Proc_ListAllGiangVien;
GO

CREATE PROCEDURE Proc_ListAllGiangVien (
  @maGiangVien NVARCHAR(32),
  @hoTen NVARCHAR(MAX),
  @gioiTinh NVARCHAR(3),
  @cMND NVARCHAR(20),
  @sDT NVARCHAR(20),
  @queQuan NVARCHAR(MAX),
  @hocHam NVARCHAR(128),
  @hocVi NVARCHAR(128),
  @maKhoa NVARCHAR(32))
AS
  SELECT
      [GiangVien].MaGiangVien as 'GiangVienMaGiangVien',
      [GiangVien].HoTen as 'GiangVienHoTen',
      [GiangVien].NgaySinh as 'GiangVienNgaySinh',
      [GiangVien].GioiTinh as 'GiangVienGioiTinh',
      [GiangVien].CMND as 'GiangVienCMND',
      [GiangVien].SDT as 'GiangVienSDT',
      [GiangVien].QueQuan as 'GiangVienQueQuan',
      [GiangVien].HocHam as 'GiangVienHocHam',
      [GiangVien].HocVi as 'GiangVienHocVi',
      [GiangVien].MaKhoa as 'GiangVienMaKhoa',
      [Khoa].TenKhoa as 'KhoaTenKhoa',
      [Khoa].HeDaoTao as 'KhoaHeDaoTao',
      [Khoa].NgayThanhLap as 'KhoaNgayThanhLap'
  FROM GiangVien
    INNER JOIN Khoa ON GiangVien.MaKhoa = Khoa.MaKhoa
  WHERE
    [GiangVien].[MaGiangVien] LIKE CONCAT('%', @maGiangVien, '%') AND
    [GiangVien].[HoTen] LIKE CONCAT('%', @hoTen, '%') AND
    [GiangVien].[GioiTinh] LIKE CONCAT('%', @gioiTinh, '%') AND
    [GiangVien].[CMND] LIKE CONCAT('%', @cMND, '%') AND
    [GiangVien].[SDT] LIKE CONCAT('%', @sDT, '%') AND
    [GiangVien].[QueQuan] LIKE CONCAT('%', @queQuan, '%') AND
    [GiangVien].[HocHam] LIKE CONCAT('%', @hocHam, '%') AND
    [GiangVien].[HocVi] LIKE CONCAT('%', @hocVi, '%') AND
    [GiangVien].[MaKhoa] LIKE CONCAT('%', @maKhoa, '%')

GO

-- Lấy danh sách toàn bộ kết quả học tập
DROP PROCEDURE Proc_ListAllKetQuaHocTap;
GO

CREATE PROCEDURE Proc_ListAllKetQuaHocTap (
  @maSinhVien NVARCHAR(32),
  @maLop NVARCHAR(32))
AS
  SELECT
      [KetQuaHocTap].MaSinhVien as 'KetQuaHocTapMaSinhVien',
      [KetQuaHocTap].MaLop as 'KetQuaHocTapMaLop',
      [KetQuaHocTap].DiemGiuaKy as 'KetQuaHocTapDiemGiuaKy',
      [KetQuaHocTap].DiemCuoiKy as 'KetQuaHocTapDiemCuoiKy',
      [Lop].MaHocKy as 'LopMaHocKy',
      [Lop].MaMonHoc as 'LopMaMonHoc',
      [Lop].MaGiangVien as 'LopMaGiangVien',
      [Lop].LichHoc as 'LopLichHoc',
      [Lop].NgayBatDau as 'LopNgayBatDau',
      [Lop].NgayKetThuc as 'LopNgayKetThuc',
      [Lop].GioiHan as 'LopGioiHan',
      [SinhVien].HoTen as 'SinhVienHoTen',
      [SinhVien].NgaySinh as 'SinhVienNgaySinh',
      [SinhVien].GioiTinh as 'SinhVienGioiTinh',
      [SinhVien].CMND as 'SinhVienCMND',
      [SinhVien].SDT as 'SinhVienSDT',
      [SinhVien].QueQuan as 'SinhVienQueQuan',
      [SinhVien].MaKhoa as 'SinhVienMaKhoa'
  FROM KetQuaHocTap
    INNER JOIN Lop ON KetQuaHocTap.MaLop = Lop.MaLop
    INNER JOIN SinhVien ON KetQuaHocTap.MaSinhVien = SinhVien.MaSinhVien
  WHERE
    [KetQuaHocTap].[MaSinhVien] LIKE CONCAT('%', @maSinhVien, '%') AND
    [KetQuaHocTap].[MaLop] LIKE CONCAT('%', @maLop, '%')

GO

-- Lấy danh sách toàn bộ khoa
DROP PROCEDURE Proc_ListAllKhoa;
GO

CREATE PROCEDURE Proc_ListAllKhoa (
  @maKhoa NVARCHAR(32),
  @tenKhoa NVARCHAR(MAX),
  @heDaoTao NVARCHAR(MAX))
AS
  SELECT
      [Khoa].MaKhoa as 'KhoaMaKhoa',
      [Khoa].TenKhoa as 'KhoaTenKhoa',
      [Khoa].HeDaoTao as 'KhoaHeDaoTao',
      [Khoa].NgayThanhLap as 'KhoaNgayThanhLap'
  FROM Khoa
  WHERE
    [Khoa].[MaKhoa] LIKE CONCAT('%', @maKhoa, '%') AND
    [Khoa].[TenKhoa] LIKE CONCAT('%', @tenKhoa, '%') AND
    [Khoa].[HeDaoTao] LIKE CONCAT('%', @heDaoTao, '%')

GO

-- Lấy danh sách toàn bộ lớp
DROP PROCEDURE Proc_ListAllLop;
GO

CREATE PROCEDURE Proc_ListAllLop (
  @maLop NVARCHAR(32),
  @maHocKy NVARCHAR(32),
  @maMonHoc NVARCHAR(32),
  @maGiangVien NVARCHAR(32),
  @lichHoc NVARCHAR(MAX))
AS
  SELECT
      [Lop].MaLop as 'LopMaLop',
      [Lop].MaHocKy as 'LopMaHocKy',
      [Lop].MaMonHoc as 'LopMaMonHoc',
      [Lop].MaGiangVien as 'LopMaGiangVien',
      [Lop].LichHoc as 'LopLichHoc',
      [Lop].NgayBatDau as 'LopNgayBatDau',
      [Lop].NgayKetThuc as 'LopNgayKetThuc',
      [Lop].GioiHan as 'LopGioiHan',
      [GiangVien].HoTen as 'GiangVienHoTen',
      [GiangVien].NgaySinh as 'GiangVienNgaySinh',
      [GiangVien].GioiTinh as 'GiangVienGioiTinh',
      [GiangVien].CMND as 'GiangVienCMND',
      [GiangVien].SDT as 'GiangVienSDT',
      [GiangVien].QueQuan as 'GiangVienQueQuan',
      [GiangVien].HocHam as 'GiangVienHocHam',
      [GiangVien].HocVi as 'GiangVienHocVi',
      [GiangVien].MaKhoa as 'GiangVienMaKhoa',
      [HocKy].TenHocKy as 'HocKyTenHocKy',
      [HocKy].NgayBatDau as 'HocKyNgayBatDau',
      [HocKy].NgayKetThuc as 'HocKyNgayKetThuc',
      [HocKy].MaNamHoc as 'HocKyMaNamHoc',
      [MonHoc].TenMonHoc as 'MonHocTenMonHoc',
      [MonHoc].MoTa as 'MonHocMoTa',
      [MonHoc].STC as 'MonHocSTC',
      [MonHoc].LoaiHocPhan as 'MonHocLoaiHocPhan',
      [MonHoc].MaKhoa as 'MonHocMaKhoa'
  FROM Lop
    INNER JOIN GiangVien ON Lop.MaGiangVien = GiangVien.MaGiangVien
    INNER JOIN HocKy ON Lop.MaHocKy = HocKy.MaHocKy
    INNER JOIN MonHoc ON Lop.MaMonHoc = MonHoc.MaMonHoc
  WHERE
    [Lop].[MaLop] LIKE CONCAT('%', @maLop, '%') AND
    [Lop].[MaHocKy] LIKE CONCAT('%', @maHocKy, '%') AND
    [Lop].[MaMonHoc] LIKE CONCAT('%', @maMonHoc, '%') AND
    [Lop].[MaGiangVien] LIKE CONCAT('%', @maGiangVien, '%') AND
    [Lop].[LichHoc] LIKE CONCAT('%', @lichHoc, '%')

GO

-- Lấy danh sách toàn bộ môn học
DROP PROCEDURE Proc_ListAllMonHoc;
GO

CREATE PROCEDURE Proc_ListAllMonHoc (
  @maMonHoc NVARCHAR(32),
  @tenMonHoc NVARCHAR(MAX),
  @moTa NVARCHAR(MAX),
  @loaiHocPhan NVARCHAR(128),
  @maKhoa NVARCHAR(32))
AS
  SELECT
      [MonHoc].MaMonHoc as 'MonHocMaMonHoc',
      [MonHoc].TenMonHoc as 'MonHocTenMonHoc',
      [MonHoc].MoTa as 'MonHocMoTa',
      [MonHoc].STC as 'MonHocSTC',
      [MonHoc].LoaiHocPhan as 'MonHocLoaiHocPhan',
      [MonHoc].MaKhoa as 'MonHocMaKhoa',
      [Khoa].TenKhoa as 'KhoaTenKhoa',
      [Khoa].HeDaoTao as 'KhoaHeDaoTao',
      [Khoa].NgayThanhLap as 'KhoaNgayThanhLap'
  FROM MonHoc
    INNER JOIN Khoa ON MonHoc.MaKhoa = Khoa.MaKhoa
  WHERE
    [MonHoc].[MaMonHoc] LIKE CONCAT('%', @maMonHoc, '%') AND
    [MonHoc].[TenMonHoc] LIKE CONCAT('%', @tenMonHoc, '%') AND
    [MonHoc].[MoTa] LIKE CONCAT('%', @moTa, '%') AND
    [MonHoc].[LoaiHocPhan] LIKE CONCAT('%', @loaiHocPhan, '%') AND
    [MonHoc].[MaKhoa] LIKE CONCAT('%', @maKhoa, '%')

GO

-- Lấy danh sách toàn bộ sinh viên
DROP PROCEDURE Proc_ListAllSinhVien;
GO

CREATE PROCEDURE Proc_ListAllSinhVien (
  @maSinhVien NVARCHAR(32),
  @hoTen NVARCHAR(MAX),
  @gioiTinh NVARCHAR(3),
  @cMND NVARCHAR(20),
  @sDT NVARCHAR(20),
  @queQuan NVARCHAR(MAX),
  @maKhoa NVARCHAR(32))
AS
  SELECT
      [SinhVien].MaSinhVien as 'SinhVienMaSinhVien',
      [SinhVien].HoTen as 'SinhVienHoTen',
      [SinhVien].NgaySinh as 'SinhVienNgaySinh',
      [SinhVien].GioiTinh as 'SinhVienGioiTinh',
      [SinhVien].CMND as 'SinhVienCMND',
      [SinhVien].SDT as 'SinhVienSDT',
      [SinhVien].QueQuan as 'SinhVienQueQuan',
      [SinhVien].MaKhoa as 'SinhVienMaKhoa',
      [Khoa].TenKhoa as 'KhoaTenKhoa',
      [Khoa].HeDaoTao as 'KhoaHeDaoTao',
      [Khoa].NgayThanhLap as 'KhoaNgayThanhLap'
  FROM SinhVien
    INNER JOIN Khoa ON SinhVien.MaKhoa = Khoa.MaKhoa
  WHERE
    [SinhVien].[MaSinhVien] LIKE CONCAT('%', @maSinhVien, '%') AND
    [SinhVien].[HoTen] LIKE CONCAT('%', @hoTen, '%') AND
    [SinhVien].[GioiTinh] LIKE CONCAT('%', @gioiTinh, '%') AND
    [SinhVien].[CMND] LIKE CONCAT('%', @cMND, '%') AND
    [SinhVien].[SDT] LIKE CONCAT('%', @sDT, '%') AND
    [SinhVien].[QueQuan] LIKE CONCAT('%', @queQuan, '%') AND
    [SinhVien].[MaKhoa] LIKE CONCAT('%', @maKhoa, '%')

GO

-- Tìm thông tin trong HomepageGiangVien
	create procedure Proc_TimTrongHomePageGiangVien
	(
		@monHoc nvarchar(max),
		@maLop nvarchar(32),
		@maHocKy nvarchar(32),
		@maNamHoc nvarchar(32),
		@maGiangVien nvarchar(32)
	)
	as
		select [KetQuaHocTap].MaSinhVien, [Lop].MaLop, [MonHoc].TenMonHoc, (DiemGiuaKy + DiemCuoiKy)/2 as DiemTrungBinh, [HocKy].TenHocKy, [NamHoc].TenNamhoc
		from [KetQuaHocTap]
			INNER JOIN [Lop] ON [Lop].MaLop = [KetQuaHocTap].MaLop
			INNER JOIN [MonHoc] ON [Lop].MaMonHoc = [MonHoc].MaMonHoc
			INNER JOIN [HocKy] ON [Lop].MaHocKy = HocKy.MaHocKy
			INNER JOIN [NamHoc] ON [HocKy].MaNamHoc = [NamHoc].MaNamHoc
		where [MonHoc].TenMonHoc LIKE CONCAT('%', @monHoc, '%')
			and [Lop].MaLop LIKE CONCAT('%', @maLop, '%')
			and [HocKy].MaHocKy LIKE CONCAT('%', @maHocKy, '%')
			and [NamHoc].MaNamHoc LIKE CONCAT('%', @maNamHoc, '%')
			and [Lop].MaGiangVien = @maGiangVien
GO