create database QL_NhaSach

use QL_NhaSach


-- Kim Giàu
-- 1. Tạo bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV CHAR(5),
    TenNV NVARCHAR(50),
	ChucVu NVARCHAR(30),
    DiaChi NVARCHAR(100),
    SDT NVARCHAR(10),
	NgaySinh DATE,
	CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV)
)

-- 2. Tạo bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH CHAR(5),
    TenKH NVARCHAR(50),
    DiaChi NVARCHAR(100),
    SDT NVARCHAR(10),
    Email VARCHAR(50),
	CONSTRAINT PK_KhachHang PRIMARY KEY (MaKH)
)

-- 3. Tạo bảng Nhà Cung Cấp
CREATE TABLE NCC (
    MaNCC CHAR(5),
    TenNCC NVARCHAR(100),
	SDT VARCHAR(10),
	Email VARCHAR(50),
	DiaChi NVARCHAR(100),
	CONSTRAINT PK_NCC PRIMARY KEY (MaNCC)
)

-- 4. Tạo bảng Loại Sản Phẩm
CREATE TABLE LoaiSP (
    MaLoai char(5),
    TenLoai NVARCHAR(100),
	CONSTRAINT PK_LoaiSP PRIMARY KEY (MaLoai)
)

-- 5. Tạo bảng Sản Phẩm
CREATE TABLE SanPham (
    MaSP CHAR(5),
    MaNCC CHAR(5),
    MaLoai CHAR(5),
    GiaBan DECIMAL(10,2),
    TenSP NVARCHAR(200),
	CONSTRAINT PK_SanPham PRIMARY KEY (MaSP)
)

-- 6. Tạo bảng Kho
CREATE TABLE Kho (
	MaSP CHAR(5),
	SLKho INT,
	CONSTRAINT PK_Kho PRIMARY KEY (MaSP)
)

-- 7. Tạo bảng Phiếu Nhập
CREATE TABLE PhieuNhap (
	MaPhieuNhap CHAR(5),
	MaNV CHAR(5),
	MaNCC CHAR(5),
	TongTien DECIMAL(10, 2),
	NgayLap DATE,
	CONSTRAINT PK_PhieuNhap PRIMARY KEY (MaPhieuNhap)
)

-- 8. Tạo bảng Chi Tiết Phiếu Nhập
CREATE TABLE CTPN (
	MaPhieuNhap CHAR(5),
	MaSP CHAR(5),
	SoLuong INT,
	DonGia DECIMAL(10, 2),
	CONSTRAINT PK_CTPN PRIMARY KEY (MaPhieuNhap, MaSP)
)

-- 9. Tạo bảng Phiếu Xuất
CREATE TABLE PhieuXuat (
	MaPhieuXuat CHAR(5),
	MaNV CHAR(5),
	MaKH CHAR(5),
	TongTien DECIMAL(20, 2),
	NgayLap DATE,
	CONSTRAINT PK_PhieuXuat PRIMARY KEY (MaPhieuXuat)
)


-- 10. Tạo bảng Chi Tiết Phiếu Xuất
CREATE TABLE CTPX (
	MaPhieuXuat CHAR(5),
	MaSP CHAR(5),
	SoLuong INT,
	DonGia DECIMAL(10, 2),
	CONSTRAINT PK_CTPX PRIMARY KEY (MaPhieuXuat, MaSP)
)

-- 11. Tạo bảng Đơn Hàng
CREATE TABLE DonHang (
    MaDH CHAR(5),
	MaNV CHAR(5),
    MaKH CHAR(5),
    NgayDat DATE,
    TongTien DECIMAL(10,2),
	CONSTRAINT PK_DonHang PRIMARY KEY (MaDH)
)

-- 12. Tạo bảng Chi Tiết Đơn Hàng
CREATE TABLE ChiTietDH (
	MaDH CHAR(5),
    MaSP CHAR(5),
    SoLuong INT,
    GiaBan DECIMAL(10,2),
	CONSTRAINT PK_ChiTietDH PRIMARY KEY (MaDH, MaSP)
)

-- Ràng buộc
alter table NhanVien
add constraint CK_NhanVien_NgaySinh check ((year(getdate()) - year(NgaySinh)) >= 18),
constraint CK_NhanVien_SDT check (SDT LIKE '[0-9]%' AND LEN(SDT) = 10),
constraint UNI_NhanVien_SDT unique (SDT)

alter table KhachHang  -- Vinh
add constraint CK_KhachHang_SDT check (SDT LIKE '[0-9]%' AND LEN(SDT) = 10),
constraint UNI_KhachHang_SDT unique (SDT),
constraint UNI_KhachHang_Email unique (Email),
constraint CK_KhachHang_Email check(Email LIKE '%_@__%.com')

alter table SanPham
add constraint FK_SanPham_NCC foreign key (MaNCC) references NCC(MaNCC),
constraint FK_SanPham_LoaiSP foreign key (MaLoai) references LoaiSP(MaLoai),
constraint CK_SanPham_GiaBan check (GiaBan > 0)

alter table NCC
add constraint CK_NCC_SDT check (SDT LIKE '[0-9]%' AND LEN(SDT) = 10),
constraint UNI_NCC_SDT unique (SDT),
constraint UNI_NCC_Email unique (Email),
constraint CK_NCC_Email check(Email LIKE '%_@__%.com')

alter table Kho
add constraint FK_Kho_SanPham foreign key (MaSP) references SanPham(MaSP),
constraint CK_Kho_SoLuong check (SLKho >= 0)

alter table PhieuNhap
add constraint FK_PhieuNhap_NhanVien foreign key (MaNV) references NhanVien(MaNV),
constraint FK_PhieuNhap_NCC foreign key (MaNCC) references NCC(MaNCC),
constraint CK_PhieuNhap_TongTien check (TongTien > 0),
constraint DF_PhieuNhap_NgayLap default getdate() for NgayLap

alter table CTPN
add constraint FK_CTPN_PhieuNhap foreign key (MaPhieuNhap) references PhieuNhap(MaPhieuNhap),
constraint FK_CTPN_SanPham foreign key (MaSP) references SanPham(MaSP),
constraint CK_CTPN_SoLuong check (SoLuong > 0),
constraint CK_CTPN_DonGia check (DonGia > 0)

alter table PhieuXuat
add constraint FK_PhieuXuat_NhanVien foreign key (MaNV) references NhanVien(MaNV),
constraint FK_PhieuXuat_KhachHang foreign key (MaKH) references KhachHang(MaKH),
constraint CK_PhieuXuat_TongTien check (TongTien > 0),
constraint DF_PhieuXuat_NgayLap default getdate() for NgayLap

alter table CTPX
add constraint FK_CTPX_PhieuXuat foreign key (MaPhieuXuat) references PhieuXuat(MaPhieuXuat),
constraint FK_CTPX_SanPham foreign key (MaSP) references SanPham(MaSP),
constraint CK_CTPX_SoLuong check (SoLuong > 0),
constraint CK_CTPX_DonGia check (DonGia > 0)

alter table DonHang
add constraint FK_DonHang_KhachHang foreign key (MaKH) references KhachHang(MaKH),
constraint FK_DonHang_NhanVien foreign key (MaNV) references NhanVien(MaNV),
constraint CK_DonHang_TongTien check (TongTien > 0),
constraint DF_DonHang_NgayDat default getdate() for NgayDat

alter table ChiTietDH
add constraint FK_ChiTietDH_DonHang foreign key (MaDH) references DonHang(MaDH),
constraint FK_ChiTietDH_SanPham foreign key (MaSP) references SanPham(MaSP),
constraint CK_ChiTietDH_SoLuong check (SoLuong > 0),
constraint CK_ChiTietDH_GiaBan check (GiaBan > 0)

set dateformat DMY

insert into KhachHang --Vinh 
values
	('KH001', N'Nguyễn Thị Thắm', N'466 Đường Nguyễn Văn Thụ, Phường 3, Quận 8, Thành phố Hồ Chí Minh', N'0356123569', 'thamnguyen@gmail.com'),
	('KH002', N'Nguyễn Thị Hồng', N'456 Đường Nguyễn Văn Linh, Phường 2, Quận 7, Thành phố Hồ Chí Minh', N'0356123789', 'hongnguyen@gmail.com'),
	('KH003', N'Trần Văn Hải', N'789 Đường Lê Lợi, Phường 3, Quận Bình Thạnh, Thành phố Hồ Chí Minh', N'0909876543', 'haivt@gmail.com'),
	('KH004', N'Phạm Thị Lan', N'101 Đường Nguyễn Trãi, Phường Tân Bình, Quận Tân Phú, Thành phố Hồ Chí Minh', N'0987658321', 'lanpham@gmail.com'),
	('KH005', N'Bùi Minh Tuấn', N'222 Đường 3/2, Phường 5, Quận 10, Thành phố Hồ Chí Minh', N'0398795432', 'tuanbui@gmail.com'),
	('KH007', N'Võ Văn Hoàng', N'444 Đường Hòa Hảo, Phường 6, Quận 11, Thành phố Hồ Chí Minh', N'0321654987', 'hoangvo@gmail.com'),
	('KH008', N'Nguyễn Minh Đức', N'555 Đường Bạch Đằng, Phường 7, Quận 1, Thành phố Hồ Chí Minh', N'0912342678', 'ducnguyen@gmail.com'),
	('KH009', N'Thái Thị Thủy', N'666 Đường Nguyễn Thị Minh Khai, Phường 8, Quận Tân Bình, Thành phố Hồ Chí Minh', N'0378965412', 'thuythai@gmail.com'),
	('KH010', N'Đinh Văn Đạt', N'777 Đường Lý Thường Kiệt, Phường 9, Quận 4, Thành phố Hồ Chí Minh', N'0945632178', 'datdinh@gmail.com'),
	('KH011', N'Phan Thị Nga', N'888 Đường Cộng Hòa, Phường 10, Quận Tân Phú, Thành phố Hồ Chí Minh', N'0654391890', 'ngaphan@gmail.com'),
	('KH012', N'Huỳnh Văn Hòa', N'999 Đường Trần Phú, Phường 11, Quận 12, Thành phố Hồ Chí Minh', N'0321098765', 'hoahuynh@gmail.com'),
	('KH013', N'Lý Thị Ngọc Anh', N'1212 Đường Nguyễn Văn Cừ, Phường 12, Quận Gò Vấp, Thành phố Hồ Chí Minh', N'0765432109', 'anhly@gmail.com'),
	('KH014', N'Nguyễn Văn Quân', N'1313 Đường Phạm Văn Hai, Phường 1, Quận Tân Bình, Thành phố Hồ Chí Minh', N'0987654321', 'quannguyen@gmail.com'),
	('KH015', N'Trần Thị Thảo', N'1414 Đường Lê Duẩn, Phường 2, Quận 3, Thành phố Hồ Chí Minh', N'0321654937', 'thaotran@gmail.com'),
	('KH016', N'Vương Văn Dũng', N'1515 Đường Nguyễn Hữu Cảnh, Phường 3, Quận Bình Thạnh, Thành phố Hồ Chí Minh', N'0912345678', 'dungvuong@gmail.com'),
	('KH017', N'Lê Thị Kim Anh', N'1616 Đường Huỳnh Tấn Phát, Phường 4, Quận 7, Thành phố Hồ Chí Minh', N'0378962412', 'anhle@gmail.com'),
	('KH018', N'Phạm Văn Hoàng', N'1717 Đường Nguyễn Thái Bình, Phường 5, Quận 1, Thành phố Hồ Chí Minh', N'0945032178', 'hoangpham@gmail.com'),
	('KH019', N'Đỗ Thị Thu Hằng', N'1818 Đường Lý Tự Trọng, Phường 6, Quận 10, Thành phố Hồ Chí Minh', N'0654321890', 'hangdo@gmail.com'),
	('KH020', N'Võ Minh Tuấn', N'1919 Đường Cách Mạng Tháng 8, Phường 11, Quận 5, Thành phố Hồ Chí Minh', N'0369852147', 'tuantv@gmail.com'),
    ('KH021', N'Lê Thành Nam', N'123 Đường Trần Hưng Đạo, Phường 1, Quận 5, Thành phố Hồ Chí Minh', N'0324687451', 'thanhnam@gmail.com'),
    ('KH022', N'Trần Văn Khang', N'456 Đường Lê Lợi, Phường 2, Quận 1, Thành phố Hồ Chí Minh', N'0689712465', 'vankhang@gmail.com'),
    ('KH023', N'Nguyễn Thanh Phong', N'789 Đường Nguyễn Trãi, Phường 3, Quận 3, Thành phố Hồ Chí Minh', N'0359765423', 'phong@gmail.com'),
    ('KH024', N'Lê Ánh Hồng', N'321 Đường Bà Triệu, Phường 4, Quận 4, Thành phố Hồ Chí Minh', N'0689742163', 'anhhong@gmail.com'),
    ('KH025', N'Vũ Huyền Vi', N'654 Đường Hùng Vương, Phường 5, Quận 6, Thành phố Hồ Chí Minh', N'0476872153', 'huyenvi@gmail.com'),
	('KH026', N'Nguyễn Văn Ánh', N'123 Đường Lê Lợi, Phường 1, Quận 1, Thành phố Hồ Chí Minh', N'0123456789', 'nguyenvana@gmail.com'),
    ('KH027', N'Trần Thị Lan', N'456 Đường Nguyễn Trãi, Phường 2, Quận 2, Thành phố Hồ Chí Minh', N'0987654325', 'tranlan@gmail.com');

select * from KhachHang

INSERT INTO NCC (MaNCC, TenNCC, SDT, Email, DiaChi) --Thịnh
VALUES
    ('NCC01', N'CÔNG TY TNHH MTV AN LỘC VIỆT', '0899189499', 'vppanlocviet@gmail.com', N'30 Kha Vạn Cân,Hiệp Bình Chánh,Thủ Đức,TPHCM'),
    ('NCC02', N'CÔNG TY CỔ PHẦN TẬP ĐOÀN THIÊN LONG', '0961531616', 'info@thienlonggroup.com', N'Số 10 Đường Mai Chí Thọ,Phường Thủ Thiêm,Thủ Đức,TPHCM'),
    ('NCC03', N'Văn phòng phẩm Hoàng Hà', '0919542541', 'vpphoangha48@gmail.com', N'247/13 Độc Lập,Phường Tân Quý,Quận Tân Phú,TPHCM');

INSERT INTO NhanVien (MaNV, TenNV, ChucVu, DiaChi, SDT, NgaySinh) --Thịnh
VALUES
    ('QL001', N'Nguyễn Hữu Thông', N'Quản lý', N'123 Đường ABC, Quận 1, TP.HCM', '0123456789', '2003-01-15'),
    ('NB001', N'Phạm Thị Thu Phương', N'Nhân viên bán hàng', N'456 Đường XYZ, Quận 2, TP.HCM', '0987654321', '2003-03-22'),
    ('NK001', N'Nguyễn Hoài Nam', N'Nhân viên kho', N'789 Đường KLM, Quận 3, TP.HCM', '0369852147', '2003-07-10'),
    ('NB002', N'Mai Thế Vinh', N'Nhân viên bán hàng', N'101 Đường LMN, Quận 4, TP.HCM', '0932154768', '2003-09-18'),
    ('NB003', N'Võ Thị Kim Giàu', N'Nhân viên bán hàng', N'222 Đường XYZ, Quận 5, TP.HCM', '0765432109', '2003-12-05'),
    ('NK002', N'Nguyễn Hồ Phúc Thịnh', N'Nhân viên kho', N'316/14 Tây Thạnh, Quận Tân Phú, TP.HCM', '0764047814', '2003-04-23');

insert into LoaiSP --Vinh 
values 
	('L001', N'Sách'),
	('L002', N'Văn phòng phẩm'),
	('L003', N'Dụng cụ học tập');

select * from LoaiSP

insert into SanPham(MaSP, MaNCC, MaLoai, GiaBan, TenSP) --Vinh 
values
	('SP001', 'NCC01', 'L001', 179000, N'Không Gia Đình'),
    ('SP002', 'NCC01', 'L001', 40000, N'Ông già và biển cả'),
    ('SP003', 'NCC01', 'L001', 129000, N'Âm Thanh Và Cuồng Nộ'),
    ('SP004', 'NCC01', 'L001', 150000, N'Mắt Biếc'),
    ('SP005', 'NCC01', 'L001', 98000, N'Dế Mèn Phiêu Lưu Ký'),
    ('SP006', 'NCC01', 'L001', 210000, N'Chạy Án'),
    ('SP007', 'NCC01', 'L001', 135000, N'Tiếng Gọi Của Hoang Dã'),
    ('SP008', 'NCC01', 'L001', 62000, N'Người Đua Của Bóng Đêm'),
    ('SP009', 'NCC01', 'L001', 175000, N'Một Nửa Yêu Thương'),
    ('SP010', 'NCC01', 'L001', 89000, N'Cô Gái Đến Từ Hôm Qua'),
    ('SP011', 'NCC01', 'L001', 125000, N'Bắt Trẻ Đồng Xanh'),
    ('SP012', 'NCC01', 'L001', 280000, N'Điệu Nhảy Cuộc Đời'),
    ('SP013', 'NCC01', 'L001', 118000, N'Kỳ Nghỉ'),
    ('SP014', 'NCC01', 'L001', 34000, N'Vợ Chồng A Phủ'),
    ('SP015', 'NCC01', 'L001', 196000, N'Giai Điệu Tình Yêu'),
    ('SP016', 'NCC01', 'L001', 165000, N'Bảy Nụ Hôn Đầu'),
    ('SP017', 'NCC01', 'L001', 75000, N'Nàng Tiên Cá'),
    ('SP018', 'NCC01', 'L001', 112000, N'Nhà Giả Kim'),
    ('SP019', 'NCC01', 'L001', 225000, N'Đồi Gió Hú'),
    ('SP020', 'NCC01', 'L001', 48000, N'Dấu Chân Trên Cát'),
	('SP021', 'NCC01', 'L001', 70000, N'Hoàng Tử Bé'),
	('SP022', 'NCC01', 'L001', 60000, N'Alice ở xứ sở diệu kỳ'),
	('SP023', 'NCC01', 'L001', 50000, N' Charlie và nhà máy Sô-cô-la '),
	('SP024', 'NCC01', 'L001', 143000, N'Việt Nam phong tục'),
	('SP025', 'NCC01', 'L001', 126000, N'Bản sắc văn hóa vùng ở Việt Nam'),
	('SP026', 'NCC01', 'L001', 143000, N'Việt Nam phong tục'),
	('SP027', 'NCC01', 'L001', 345000, N'1000 phát minh vĩ đại'),
	('SP028', 'NCC01', 'L001', 279000, N'Tôn giáo thế giới'),
	('SP029', 'NCC01', 'L001', 262000, N'Vòng đời'),
	('SP030', 'NCC01', 'L001', 107000, N'13 nguyên tắc nghĩ giàu làm giàu'),
	('SP031', 'NCC01', 'L001', 86000, N'Bí mật tư duy triệu phú'),
	('SP032', 'NCC01', 'L001', 157000, N'Quốc gia khởi nghiệp'),

	('SP033', 'NCC02', 'L002', 3500, N'Bút Mực Xanh'),
    ('SP034', 'NCC02', 'L002', 4000, N'Bút Bi Đen'),
    ('SP035', 'NCC02', 'L002', 40000, N'Tẩy Keo'),
    ('SP036', 'NCC02', 'L002', 15000, N'Bìa Đựng Giấy'),
    ('SP037', 'NCC02', 'L002', 25000, N'Dây Đeo Thẻ'),
    ('SP038', 'NCC02', 'L002', 22000, N'Kéo Cắt Giấy'),
    ('SP039', 'NCC02', 'L002', 19000, N'Bút Dạ Quang'),
    ('SP040', 'NCC02', 'L002', 17000, N'Thước Dẻo'),
    ('SP041', 'NCC02', 'L002', 29000, N'Bút Màu'),
    ('SP042', 'NCC02', 'L002', 18000, N'Keo Dán'),
    ('SP043', 'NCC02', 'L002', 21000, N'Bút Lông'),
    ('SP044', 'NCC02', 'L002', 29000, N'Bút Dạ'),
    ('SP045', 'NCC02', 'L002', 23000, N'Bút Sáp Màu'),
	('SP046', 'NCC02', 'L002', 145000, N'Khắc dấu tên'),
	('SP047', 'NCC02', 'L002', 5000, N'Kẹp bướm'),
	('SP048', 'NCC02', 'L002', 25000, N'Kim bấm'),

	('SP049', 'NCC03', 'L003', 7900, N'Gôm Tẩy Bút Chì'),
    ('SP050', 'NCC03', 'L003', 17900, N'Bảng Trắng'),
    ('SP051', 'NCC03', 'L003', 13000, N'Bút Chì Đen'),
	('SP052', 'NCC03', 'L003', 500000, N'Máy Tính Bỏ Túi'),
    ('SP053', 'NCC03', 'L003', 10000, N'Bút Chì HB'),
    ('SP054', 'NCC03', 'L003', 19000, N'Gạt Bút Chì'),
    ('SP066', 'NCC03', 'L003', 15000, N'Thước Kẻ'),
    ('SP056', 'NCC03', 'L003', 15000, N'Thước Kẻ'),
	('SP057', 'NCC03', 'L003', 29900, N'Dụng Cụ Vẽ'),
	('SP058', 'NCC03', 'L003', 200000, N'Balo');

select * from KhachHang
select * from LoaiSP	   
select * from SanPham

INSERT INTO KHO (MaSP, SLKho) --Thịnh
VALUES
    ('SP001', 100),
    ('SP002', 50),
    ('SP003', 80),
    ('SP004', 120),
    ('SP005', 90),
    ('SP006', 60),
    ('SP007', 75),
    ('SP008', 110),
    ('SP009', 85),
    ('SP010', 70),
    ('SP011', 95),
    ('SP012', 40),
    ('SP013', 65),
    ('SP014', 30),
    ('SP015', 50),
    ('SP016', 75),
    ('SP017', 40),
    ('SP018', 60),
    ('SP019', 25),
    ('SP020', 55),
    ('SP021', 80),
    ('SP022', 70),
    ('SP023', 60),
    ('SP024', 45),
    ('SP025', 55),
    ('SP026', 90),
    ('SP027', 35),
    ('SP028', 50),
    ('SP029', 40),
    ('SP030', 85),
    ('SP031', 60),
    ('SP032', 45),
    ('SP033', 120),
    ('SP034', 100),
    ('SP035', 60),
    ('SP036', 80),
    ('SP037', 70),
    ('SP038', 55),
    ('SP039', 65),
    ('SP040', 45),
    ('SP041', 70),
    ('SP042', 60),
    ('SP043', 55),
    ('SP044', 75),
    ('SP045', 65),
    ('SP046', 30),
    ('SP047', 40),
    ('SP048', 50),
    ('SP049', 90),
    ('SP050', 60),
    ('SP051', 75),
    ('SP052', 25),
    ('SP053', 80),
    ('SP054', 70),
    ('SP066', 60),
    ('SP056', 50),
    ('SP057', 45),
    ('SP058', 30);


-- Nhập liệu bảng Phiếu Nhập
-- SET DATEFORMAT YMD;
INSERT INTO PhieuNhap (MaPhieuNhap, MaNV, MaNCC, TongTien, NgayLap) --Phương
VALUES ('PN001', 'NK001', 'NCC01', 718000, NULL),
       ('PN002', 'NK002', 'NCC02', 823000, NULL),
       ('PN003', 'NK001', 'NCC03', 562000, NULL),
	   ('PN004', 'NK002', 'NCC01', 629000, NULL),
       ('PN005', 'NK002', 'NCC02', 482000, NULL),
       ('PN006', 'NK002', 'NCC03', 321000, NULL),
	   ('PN007', 'NK001', 'NCC01', 612000, NULL);

select * from PhieuNhap

--Nhập liệu bảng CTPN
INSERT INTO CTPN (MaPhieuNhap, MaSP, SoLuong, DonGia) --Phương
VALUES ('PN001', 'SP001', 100, 169000),
       ('PN001', 'SP002', 65, 39000),
       ('PN001', 'SP003', 65, 119000),
       ('PN001', 'SP004', 65, 140000),
       ('PN001', 'SP005', 65, 88000),
       ('PN001', 'SP006', 65, 200000),
       ('PN001', 'SP007', 65, 125000),
       ('PN001', 'SP008', 65, 52000),
       ('PN001', 'SP009', 65, 165000),
       ('PN001', 'SP010', 65, 165000),
       ('PN001', 'SP011', 65, 115000),
       ('PN001', 'SP012', 65, 270000),
       ('PN001', 'SP013', 65, 108000),


       ('PN002', 'SP008', 108, 52000),
       ('PN002', 'SP009', 108, 165000),
       ('PN002', 'SP010', 108, 165000),
       ('PN002', 'SP011', 108, 115000),
       ('PN002', 'SP012', 108, 270000),
       ('PN002', 'SP013', 108, 108000),
       ('PN002', 'SP014', 108, 24000),
       ('PN002', 'SP015', 108, 186000),


       ('PN003', 'SP001', 12, 169000),
       ('PN003', 'SP002', 12, 39000),
       ('PN003', 'SP003', 12, 119000),
       ('PN003', 'SP004', 12, 140000),
       ('PN003', 'SP005', 12, 88000),
       ('PN003', 'SP006', 12, 200000),

		
	   ('PN004', 'SP010', 28, 165000),
	   ('PN004', 'SP011', 28, 165000),
	   ('PN004', 'SP012', 28, 270000),
	   ('PN004', 'SP013', 28, 108000),
	   ('PN004', 'SP001', 28, 169000),
	   ('PN004', 'SP002', 28, 39000),
	   ('PN004', 'SP003', 28, 119000),
	   ('PN004', 'SP004', 28, 140000),
	   ('PN004', 'SP005', 28, 88000),
	   ('PN004', 'SP006', 28, 200000),
	   ('PN004', 'SP007', 28, 125000),
	   ('PN004', 'SP008', 28, 52000),
	   ('PN004', 'SP014', 28, 24000),
	   ('PN004', 'SP015', 28, 186000),
	   ('PN004', 'SP016', 28, 155000),


       ('PN005', 'SP001', 13, 169000),
       ('PN005', 'SP002', 13, 39000),
       ('PN005', 'SP009', 13, 165000),
       ('PN005', 'SP010', 13, 165000),
       ('PN005', 'SP011', 13, 115000),
       ('PN005', 'SP012', 13, 270000),
       ('PN005', 'SP013', 13, 108000),
       ('PN005', 'SP014', 13, 24000),
       ('PN005', 'SP015', 13, 186000),

	   ('PN005', 'SP033', 13, 2500),
       ('PN005', 'SP034', 13, 2000),
       ('PN005', 'SP035', 13, 30000),
       ('PN005', 'SP036', 13, 11000),
       ('PN005', 'SP037', 13, 15000),
       ('PN005', 'SP038', 13, 20000),
       ('PN005', 'SP039', 13, 15000),
       ('PN005', 'SP040', 13, 13000),
       ('PN005', 'SP041', 13, 21000),
	   ('PN005', 'SP042', 13, 11000),
       ('PN005', 'SP043', 13, 11000),
       ('PN005', 'SP044', 13, 20000),
       ('PN005', 'SP045', 13, 17000),
       ('PN005', 'SP046', 13, 135000),
       ('PN005', 'SP047', 13, 3000),
       ('PN005', 'SP048', 13, 15000),
       ('PN005', 'SP049', 13, 6900),
       ('PN005', 'SP050', 13, 12900),
	   ('PN005', 'SP051', 13, 11000),
       ('PN005', 'SP052', 13, 300000),
       ('PN005', 'SP053', 13, 90000),
       ('PN005', 'SP054', 13, 16000),
       ('PN005', 'SP057', 13, 26900),
       ('PN005', 'SP058', 13, 110000),


       ('PN006', 'SP002', 50, 39000),
       ('PN006', 'SP004', 50, 140000),
       ('PN006', 'SP006', 50, 200000),
       ('PN006', 'SP008', 50, 52000),
       ('PN006', 'SP010', 50, 165000),
       ('PN006', 'SP012', 50, 270000),
       ('PN006', 'SP014', 50, 24000),
       ('PN006', 'SP016', 50, 155000),
       ('PN006', 'SP018', 50, 102000),
       ('PN006', 'SP020', 50, 38000),
       ('PN006', 'SP022', 50, 50000),

	   ('PN007', 'SP023', 8, 40000),
	   ('PN007', 'SP024', 8, 133000),
	   ('PN007', 'SP025', 8, 116000),
	   ('PN007', 'SP026', 8, 133000),
	   ('PN007', 'SP027', 8, 335000),
	   ('PN007', 'SP028', 8, 269000),
	   ('PN007', 'SP029', 8, 252000),
	   ('PN007', 'SP030', 8, 97000),
	   ('PN007', 'SP031', 8, 76000),
	   ('PN007', 'SP032', 8, 147000),
	   ('PN007', 'SP021', 8, 60000),
	   ('PN007', 'SP022', 8, 50000),
	   ('PN007', 'SP001', 8, 169000),
	   ('PN007', 'SP002', 8, 39000),
	   ('PN007', 'SP003', 8, 119000),
	   ('PN007', 'SP004', 8, 140000);

select * from CTPN

INSERT INTO PhieuXuat(MaPhieuXuat, MaNV, MaKH, NgayLap, TongTien) -- Nam
VALUES ('PX001', 'NK001', 'KH007', '16/12/2023', 543000),
       ('PX002', 'NK001', 'KH004', '16/12/2023', 723000),
       ('PX003', 'NK002', 'KH009', '17/12/2023', 832000),
	   ('PX004', 'NK001', 'KH013', '17/12/2023', 871000),
       ('PX005', 'NK002', 'KH019', '17/12/2023', 120000),
       ('PX006', 'NK002', 'KH005', '18/12/2023', 472000),
	   ('PX007', 'NK002', 'KH021', '18/12/2023', 239000);

select * from PhieuXuat

--Nhập liệu cho bảng Chi Tiết Phiếu Xuất
INSERT INTO CTPX (MaPhieuXuat, MaSP, SoLuong, DonGia) -- Nam
VALUES ('PX001', 'SP054', 20, 19000),
       ('PX001', 'SP050', 30, 17900),
	   ('PX001', 'SP007', 10, 135000),

       ('PX002', 'SP010', 10, 89000),
       ('PX002', 'SP058', 40, 15000),
	   ('PX002', 'SP045', 30, 23000),
       ('PX002', 'SP049', 80, 7900),

       ('PX003', 'SP022', 30, 60000),
       ('PX003', 'SP026', 10, 143000),
	   ('PX003', 'SP021', 20, 70000),
       ('PX003', 'SP014', 50, 34000),
		
	   ('PX004', 'SP027', 5, 345000),
	   ('PX004', 'SP040', 40, 17000),
	   ('PX004', 'SP016', 15, 165000),
	   ('PX004', 'SP057', 15, 165000),
	   ('PX004', 'SP035', 10, 200000),

       ('PX005', 'SP056', 70, 15000),
       ('PX005', 'SP009', 12, 175000),

       ('PX006', 'SP041', 40, 29000),
       ('PX006', 'SP008', 20, 62000),
	   ('PX006', 'SP039', 50, 19000),
       ('PX006', 'SP056', 10, 299000),
	   ('PX006', 'SP023', 30, 50000),

	   ('PX007', 'SP027', 10, 345000),
	   ('PX007', 'SP053', 30, 10000),
	   ('PX007', 'SP042', 20, 18000);

select * from CTPX

INSERT INTO DonHang VALUES -- Thông
	('DH001', 'NB001', 'KH001', NULL, NULL),
	('DH002', 'NB002', 'KH002', NULL, NULL),
	('DH003', 'NB003', 'KH003', NULL, NULL),
	('DH004', 'NB002', 'KH004', NULL, NULL),
	('DH005', 'NB001', 'KH005', NULL, NULL)

INSERT INTO ChiTietDH VALUES -- Thông
	('DH001', 'SP001', 5, NULL),
	('DH001', 'SP002', 3, NULL),
	('DH002', 'SP003', 2, NULL),
	('DH003', 'SP004', 4, NULL),
	('DH003', 'SP002', 4, NULL),
	('DH004', 'SP015', 1, NULL),
	('DH005', 'SP030', 2, NULL)
	
SELECT * from DonHang
SELECT * from ChiTietDH

-- Phân quyền ( Kim Giàu)

-- Tạo các nhóm quyền
use QL_NhaSach
exec sp_addrole 'NVBanHang'
exec sp_addrole 'NVKho'
exec sp_addrole 'QuanLy'

-- Cấp quyền cho mỗi nhóm
-- Cấp quyền cho quản lý: toàn quyền trên database QL_NhaSach
use QL_NhaSach
grant control
to QuanLy

-- Cấp quyền cho nhóm nhân viên bán hàng
grant select, update, delete 
on SanPham
to NVBanHang

grant select, update, delete 
on DonHang
to NVBanHang

grant select, update, delete 
on ChiTietDH
to NVBanHang

grant select
on Kho
to NVBanHang

-- Cấo quyền cho nhóm nhân viên kho
grant select, update, delete 
on Kho
to NVKho

grant select, update, delete 
on PhieuNhap
to NVKho

grant select, update, delete 
on CTPN
to NVKho

grant select, update, delete 
on PhieuXuat
to NVKho

grant select, update, delete 
on CTPX
to NVKho

grant select
on SanPham
to NVKho

-- Tạo tài khoản login
use QL_NhaSach
exec sp_addlogin 'NB001', 'bh012'
exec sp_addlogin 'NB002', 'bh034'
exec sp_addlogin 'NB003', 'bh056'
exec sp_addlogin 'NK001', 'kho123'
exec sp_addlogin 'NK002', 'kho456'
exec sp_addlogin 'QL001', 'manager@'

-- Tạo tài khoản user
use QL_NhaSach
exec sp_adduser 'NB001', 'NB001'
exec sp_adduser 'NB002', 'NB002'
exec sp_adduser 'NB003', 'NB003'
exec sp_adduser 'NK001', 'NK001'
exec sp_adduser 'NK002', 'NK002'
exec sp_adduser 'QL001', 'QL001'

-- Thêm user vào nhóm quyền
use QL_NhaSach
exec sp_addrolemember 'QuanLy', 'QL001'
exec sp_addrolemember 'NVBanHang', 'NB001'
exec sp_addrolemember 'NVBanHang', 'NB002'
exec sp_addrolemember 'NVBanHang', 'NB003'
exec sp_addrolemember 'NVKho', 'NK001'
exec sp_addrolemember 'NVKho', 'NK002'

create table PQ
(
	MaNV char(5),
	UserName char(5),
	Pass varchar(20),
	constraint PK_PQ primary key (MaNV),
	constraint FK_PQ_NhanVien foreign key (MaNV) references NhanVien(MaNV)
)

insert into PQ values
('QL001', 'QL001', 'manager@'),
('NB001', 'NB001', 'bh012'),
('NB002', 'NB002', 'bh034'),
('NB003', 'NB003', 'bh056'),
('NK001', 'NK001', 'kho123'),
('NK002', 'NK002', 'kho456')


GO
CREATE TRIGGER CapNhatDonHang -- Thông
ON ChiTietDH
AFTER INSERT, UPDATE
AS
BEGIN
	declare TinhTongTien cursor for
	select MaDH,TongTien
	from DonHang

	open TinhTongTien

	declare @ma char(5),@tong DECIMAL(10,2)
	fetch next from TinhTongTien into @ma, @tong

	while @@FETCH_STATUS = 0
	begin
		update DonHang
		set TongTien = (SELECT SUM(GiaBan * SoLuong)
        FROM ChiTietDH
        WHERE MaDH = @ma)
		where MaDH = @ma
	  fetch next from TinhTongTien into @ma, @tong
	end

	close TinhTongTien
	deallocate TinhTongTien
END;
GO

GO
CREATE TRIGGER LayGiaBan -- Thông
ON ChiTietDH
AFTER INSERT, UPDATE
AS
BEGIN

	declare TinhGiaBan cursor for
	select MaDH,MaSP,GiaBan
	from ChiTietDH

	open TinhGiaBan

	declare @madh char(5),@masp char(5), @gia DECIMAL(10,2)
	fetch next from TinhGiaBan into @madh,@masp,@gia

	while @@FETCH_STATUS = 0
	begin
		update ChiTietDH
		set GiaBan = (select GiaBan	
					from SanPham
					where MaSP = @masp)
		where MaDH = @madh and MaSP = @masp
		fetch next from TinhGiaBan into @madh,@masp,@gia
	end

close TinhGiaBan
deallocate TinhGiaBan
END;
GO
---------------
--Khách Hàng---
---------------
--Trigger để tự động tạo mã khách hàng khi chèn dữ liệu mới:


--Trigger để kiểm tra và tự động cập nhật thông tin khách hàng khi có thay đổi:
CREATE TRIGGER TR_KhachHang_Update -- Vinh 
ON KhachHang
INSTEAD OF UPDATE
AS
BEGIN
    UPDATE k
    SET
        k.TenKH = i.TenKH,
        k.DiaChi = i.DiaChi,
        k.SDT = i.SDT,
        k.Email = i.Email
    FROM KhachHang k
    INNER JOIN inserted i ON k.MaKH = i.MaKH;
END;
GO
---------------
--Sản Phẩm  ---
---------------
--Trigger để kiểm tra và cảnh báo khi giá bán của sản phẩm thấp hơn giá nhập:
CREATE TRIGGER TR_SanPham_CheckGiaBan --Vinh 
ON SanPham
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.GiaBan < 0.9 * (SELECT AVG(DonGia) FROM CTPN WHERE MaSP = i.MaSP)
    )
    BEGIN
        PRINT(N'Giá bán của sản phẩm thấp hơn 90% giá nhập trung bình.');
        ROLLBACK;
    END;
END;
GO
--Trigger để kiểm tra và cập nhật tồn kho trong bảng Kho sau mỗi lần chèn hoặc cập nhật thông tin sản phẩm:
CREATE TRIGGER TR_SanPham_UpdateKho --Vinh 
ON SanPham
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE k
    SET k.SLKho = ISNULL((SELECT SUM(SLKho) FROM Kho WHERE MaSP = k.MaSP), 0)
    FROM Kho k
    INNER JOIN inserted i ON k.MaSP = i.MaSP;
END;
GO
------------------
--Loại Sản Phẩm---
------------------
CREATE TRIGGER TR_LoaiSP_AfterDelete --Vinh 
ON LoaiSP
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM SanPham WHERE MaLoai IN (SELECT MaLoai FROM deleted))
    BEGIN
        PRINT(N'Không thể xóa loại sản phẩm có sản phẩm thuộc loại này.');
        ROLLBACK;
    END
    ELSE
    BEGIN
        DELETE FROM LoaiSP WHERE MaLoai IN (SELECT MaLoai FROM deleted);
    END
END;
GO
-------------
--KHO--
-------------
-- Kiểm tra xem khi thêm hoặc sửa thì số lượng hàng trong kho không được phép âm 
GO
CREATE TRIGGER TR_Kho_CheckSLKho --Thịnh
ON Kho
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT *
        FROM inserted i
        WHERE i.SLKho <= 0
    )
    BEGIN
        PRINT(N'Số lượng hàng trong kho phải lớn hơn 0.');
        ROLLBACK;
    END;
END;

UPDATE Kho
SET SLKho = -5
WHERE MaSP = 'SP001';

-------------
----NCC------
-------------
-- Không được xóa các nhà cung cấp có các sản phẩm đang bày bán 
GO
CREATE TRIGGER TR_NCC_AfterDelete --Thịnh
ON NCC
AFTER DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM SanPham WHERE MaNCC IN (SELECT MaNCC FROM deleted))
    BEGIN
        PRINT(N'Không thể xóa nhà cung cấp có sản phẩm thuộc nhà cung cấp này.');
        ROLLBACK;
    END
END;

-- Kiểm tra số lượng xuất không được lớn hơn số lượng trong kho
GO
CREATE TRIGGER TR_DonPhieuXuat_CheckSL --Thịnh
ON CTPX
AFTER INSERT
AS
BEGIN

    IF EXISTS (
        SELECT *
        FROM inserted i
        INNER JOIN Kho k ON i.MaSP = k.MaSP
        WHERE i.SoLuong > k.SLKho
    )
    BEGIN
        PRINT(N'Số lượng xuất không được lớn hơn số lượng trong kho.');
        ROLLBACK;
    END;
END;

GO
CREATE TRIGGER Trigger_TongTien --Phương
ON CTPN
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted) 
    BEGIN
        UPDATE PN
        SET TongTien = (
            SELECT SUM(CTPN.DonGia * CTPN.SoLuong)
            FROM CTPN
            WHERE CTPN.MaPhieuNhap = PN.MaPhieuNhap
        )
        FROM PhieuNhap PN
        INNER JOIN inserted i ON PN.MaPhieuNhap = i.MaPhieuNhap
    END
END


--Cập nhật lại SLKho trong bảng KHO sau khi thêm trong CTPN hoặc PhieuNhap
GO
CREATE TRIGGER UpdateSLKho --Phương
ON CTPN
AFTER INSERT, UPDATE
AS
BEGIN
    -- Cộng dồn giá trị mới vào trường SLKho của bảng Kho
    UPDATE Kho
    SET SLKho = Kho.SLKho + (
        SELECT SUM(CTPN.SoLuong)
        FROM CTPN
        WHERE CTPN.MaSP = Kho.MaSP
    )
    FROM Kho
    INNER JOIN inserted ON Kho.MaSP = inserted.MaSP
END



GO
CREATE TRIGGER TG_CapNhapSoLuong_Kho ON CTPX -- Nam
FOR INSERT
AS
BEGIN 
	DECLARE @MAPX CHAR(5), @MASP CHAR(5), @SLX INT, @GIA DECIMAL(10, 2), @SLConLai INT
	SELECT @MAPX = MaPhieuXuat, @MASP = MASP, @SLX = SoLuong, @GIA = DonGia FROM inserted

	SET @SLConLai = (SELECT SLKho FROM Kho WHERE MaSP = @MASP) - @SLX

	IF @SLConLai >= 0
	BEGIN
		COMMIT TRAN
		UPDATE Kho
		SET SLKho = @SLConLai
		WHERE MaSP = @MASP

		UPDATE PhieuXuat
		SET TongTien = TongTien + (@SLX * @GIA)
		WHERE MaPhieuXuat = @MAPX
	END
	ELSE 
	BEGIN
		PRINT N'Số lượng xuất vượt quá số lượng kho'
		ROLLBACK TRAN
	END
END;

