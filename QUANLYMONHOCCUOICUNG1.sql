use quanlydoancuoicung1

CREATE TABLE san_pham (
  MaSanPham VARCHAR(25) PRIMARY KEY,
  TenSanPham NVARCHAR(255),
  LoaiSanPham NVARCHAR(255),
  MoTa NVARCHAR(255),
  Gia FLOAT,
  SoLuongTon INT,
  Anh image ,	
);

CREATE TABLE khach_hang (
  MaKhachHang VARCHAR(25) PRIMARY KEY  DEFAULT 'KH001',
  TenKhachHang NVARCHAR(255),
  Email VARCHAR(255),
  SoDienThoai VARCHAR(20),
  DiaChi NVARCHAR(255)
)

CREATE TABLE don_hang (
  MaDonHang VARCHAR(25) PRIMARY KEY DEFAULT 'DH001',
  MaKhachHang VARCHAR (25) ,
  MaSanPham VARCHAR(25),
  MaVanChuyen varchar(25),
  MaThanhToan VARCHAR(25),
  NgayDat DATE,
  TrangThai NVARCHAR(50),
  SoLuong INT,
  TongTien FLOAT,
)
-- Insert d? li?u vào b?ng don_hang

ALTER TABLE don_hang ADD CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES khach_hang(MaKhachHang);
ALTER TABLE don_hang ADD CONSTRAINT FK_DonHang_san_pham FOREIGN KEY (MaSanPham) REFERENCES san_pham(MaSanPham);
ALTER TABLE don_hang ADD CONSTRAINT FK_DonHang_thanh_toan FOREIGN KEY (MaThanhToan) REFERENCES thanh_toan(MaThanhToan);
ALTER TABLE don_hang ADD CONSTRAINT FK_DonHang_VanChuyen FOREIGN KEY (MaVanChuyen) REFERENCES van_chuyen(MaVanChuyen);


CREATE TABLE thanh_toan (
  MaThanhToan VARCHAR(25) PRIMARY KEY DEFAULT 'TT001',
  NgayThanhToan DATE,
  TrangThai NVARCHAR(50)
);

CREATE TABLE van_chuyen (
  MaVanChuyen VARCHAR(25) PRIMARY KEY DEFAULT 'VC001',
  DiaChiVanChuyen NVARCHAR(255),
  PhiVanChuyen FLOAT,
  NgayVanChuyen DATE
);
