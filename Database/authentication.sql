-- Tạo Giảng Viên + Phân quyền

CREATE PROCEDURE Proc_CreateTeacherWithRole(
    @maGiangVien NVARCHAR(32),
    @hoTen NVARCHAR(MAX),
    @ngaySinh DATETIME2,
    @gioiTinh NVARCHAR(3),
    @cMND NVARCHAR(20),
    @sDT NVARCHAR(20),
    @queQuan NVARCHAR(MAX),
    @hocHam NVARCHAR(128),
    @hocVi NVARCHAR(128),
    @maKhoa NVARCHAR(32),
	@matKhau VARCHAR(100)
)
AS
	-- check data
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
  
	-- tao user trong sql server
	BEGIN TRY
		EXEC CreateLoginAndUser @maGiangVien, @matKhau;
	END TRY
	BEGIN CATCH
		DECLARE @errorMessage1 NVARCHAR(MAX) = (
			SELECT ERROR_MESSAGE() as ErrorMessage
		)
		RAISERROR(@errorMessage1, 16, 1)
		RETURN
	END CATCH;

	-- grant quyen vao database
	BEGIN TRY
		EXEC GrantUserToQuanLyDiem @maGiangVien;
	END TRY
	BEGIN CATCH
		DECLARE @errorMessage2 NVARCHAR(MAX) = (
			SELECT ERROR_MESSAGE() as ErrorMessage
		)
		RAISERROR(@errorMessage2, 16, 1)
		RETURN
	END CATCH;
  
  -- them vao bang
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