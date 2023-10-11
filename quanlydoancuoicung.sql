use quanlydoancuoicung

CREATE TABLE san_pham (
  MaSanPham VARCHAR(25) PRIMARY KEY,
  TenSanPham NVARCHAR(255),
  LoaiSanPham NVARCHAR(255),
  MoTa NVARCHAR(255),
  Gia FLOAT,
  SoLuongTon INT,
  Anh image ,	
);

SELECT *from san_pham
INSERT INTO san_pham (MaSanPham, TenSanPham, LoaiSanPham, MoTa, Gia, SoLuongTon, Anh) VALUES
('SP001', N'Áo thun trắng', N'Áo', N'Áo thun cổ tròn', 10.99, 50, NULL),
('SP002', N'Áo khoác đen', N'Áo khoác', N'Áo khoác dày', 49.99, 20, NULL),
('SP003', N'Quần jean nam', N'Quần', N'Quần jean đen', 29.99, 30, NULL),
('SP004', N'Giày thể thao', N'Giày', N'Giày thể thao nam', 59.99, 40, NULL),
('SP005', N'Túi xách nữ', N'Túi xách', N'Túi xách da nữ', 39.99, 10, NULL),
('SP006', N'Áo khoác nữ', N'Áo khoác', N'Áo khoác dạ nữ', 69.99, 15, NULL);

CREATE TABLE khach_hang (
  MaKhachHang VARCHAR(25) PRIMARY KEY,
  TenKhachHang NVARCHAR(255),
  Email VARCHAR(255),
  SoDienThoai VARCHAR(20),
  DiaChi NVARCHAR(255)
)
-- Insert dữ liệu vào bảng khach_hang
INSERT INTO khach_hang (MaKhachHang, TenKhachHang, Email, SoDienThoai, DiaChi) VALUES
('KH001', N'Trần Thanh Hải', 'hai@gmail.com', '0987654321', N'An Giang'),
('KH002', N'Trần Thanh Nhi', 'nhi@gmail.com', '0123456789', N'Hồ Chí Minh'),
('KH003', N'Trần Thanh Huy', 'huy@gmail.com', '0912345678', N'Đà Nẵng');

CREATE TABLE don_hang (
  MaDonHang VARCHAR(25) PRIMARY KEY,
  MaKhachHang VARCHAR (25),
  MaSanPham VARCHAR(25),
  MaThanhToan VARCHAR(25),
  NgayDat DATE,
  TrangThai NVARCHAR(50),
  SoLuong INT,
  TongTien FLOAT,
)
ALTER TABLE don_hang ADD MaVanChuyen varchar(25);

-- Insert dữ liệu vào bảng don_hang
INSERT INTO don_hang (MaDonHang, MaKhachHang, MaSanPham, MaThanhToan, NgayDat, TrangThai, SoLuong, TongTien) VALUES
('DH001', 'KH001', 'SP001', 'TT001', '2023-04-23', N'Đã giao hàng', 2, 21.98),
('DH002', 'KH002', 'SP002', 'TT002', '2023-04-22', N'Đang xử lý', 1, 49.99),
('DH003', 'KH003', 'SP003', 'TT002', '2023-04-22', N'Chưa thanh toán', 3, 89.97);

ALTER TABLE don_hang ADD CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES khach_hang(MaKhachHang);
ALTER TABLE don_hang ADD CONSTRAINT FK_DonHang_san_pham FOREIGN KEY (MaSanPham) REFERENCES san_pham(MaSanPham);
ALTER TABLE don_hang ADD CONSTRAINT FK_DonHang_thanh_toan FOREIGN KEY (MaThanhToan) REFERENCES thanh_toan(MaThanhToan);
ALTER TABLE don_hang ADD CONSTRAINT FK_DonHang_VanChuyen FOREIGN KEY (MaVanChuyen) REFERENCES van_chuyen(MaVanChuyen);
CREATE TABLE thanh_toan (
  MaThanhToan VARCHAR(25) PRIMARY KEY,
  NgayThanhToan DATE,
  TrangThai NVARCHAR(50),
)
-- Insert dữ liệu vào bảng thanh_toan
INSERT INTO thanh_toan (MaThanhToan, NgayThanhToan, TrangThai) VALUES
('TT001', '2023-04-23', N'Đã thanh toán'),
('TT002', '2023-04-22', N'Chưa thanh toán');


CREATE TABLE van_chuyen (
  MaVanChuyen VARCHAR(25) PRIMARY KEY,
  DiaChiVanChuyen NVARCHAR(255),
  PhiVanChuyen FLOAT,
)
ALTER TABLE van_chuyen ADD NgayVanChuyen DATE;
-- Insert dữ liệu vào bảng van_chuyen

INSERT INTO van_chuyen (MaVanChuyen, DiaChiVanChuyen, PhiVanChuyen, NgayVanChuyen) VALUES 
('VC001', N'Hà Nội', 10.99, '2023-05-15'),
('VC002', N'Hồ Chí Minh', 9.99, '2023-05-10' ),
('VC003', N'Đà Nẵng', 8.99, '2023-05-13');

