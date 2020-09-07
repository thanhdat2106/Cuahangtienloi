CREATE DATABASE QL_CUAHANGTIENLOI;
USE QL_CUAHANGTIENLOI;

CREATE TABLE TAIKHOAN
(
	MATK INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENTK NCHAR(30) NOT NULL,
	MATKHAU NCHAR(30) NOT NULL
);
CREATE TABLE CHUCVU
(
	MACV INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENCV NVARCHAR(50)
);
CREATE TABLE NHANVIEN
(
	MANV INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENNV NVARCHAR(50),
	GIOITINH NVARCHAR(3),
	NGAYSINH DATE,
	DIACHI NVARCHAR(MAX),
	MACV INT NOT NULL,
	ANH NVARCHAR(MAX),
	SDT NCHAR(11),
	CMND NCHAR(9),

	CONSTRAINT FK_NHANVIEN_CHUCVU FOREIGN KEY (MACV) REFERENCES CHUCVU(MACV),
	MATK INT NOT NULL,
	CONSTRAINT FK_NHANVIEN_TAIKHOAN FOREIGN KEY (MATK) REFERENCES TAIKHOAN(MATK)
);
CREATE TABLE NHACUNGCAP
(
	MANCC INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENNCC NVARCHAR(MAX),
	DIACHI NVARCHAR(MAX),
	SDT NCHAR(20),
);
CREATE TABLE CHUNGLOAI
(
	MACL INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENCL NVARCHAR(MAX)
);
CREATE TABLE LOAISP 
(
	MALSP INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TENLSP NVARCHAR(MAX),
	MACL INT,
	MANCC INT NOT NULL,
	DONGIA FLOAT,
	CONSTRAINT FK_LSP_NHACUNGCAP FOREIGN KEY (MANCC) REFERENCES NHACUNGCAP(MANCC),
	CONSTRAINT FK_LSP_CL FOREIGN KEY (MACL) REFERENCES CHUNGLOAI(MACL),
);
CREATE TABLE SANPHAM
(
	MASP INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MALSP INT NOT NULL,
	NGAYSX DATE NOT NULL,
	CONSTRAINT FK_SANPHAM_LOAISP FOREIGN KEY (MALSP) REFERENCES LOAISP(MALSP),
	HANSUDUNG DATE, 
	SOLUONGTON INT

);
CREATE TABLE HOADON
(
	MAHD INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	NGAYLAP DATE,
	MANV INT NOT NULL,
	CONSTRAINT FK_HOADON_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
	TONGTIEN FLOAT
);
CREATE TABLE CT_HOADON
(
	MAHD INT NOT NULL,
	MASP INT NOT NULL,
	CONSTRAINT PK_CTHD PRIMARY KEY (MAHD,MASP),
	SOLUONGSP INT,
	CONSTRAINT FK_CTHD_HOADON FOREIGN KEY (MAHD) REFERENCES HOADON(MAHD),
	CONSTRAINT FK_CTHD_SANPHAM FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP),
	THANHTIEN FLOAT 
);
CREATE TABLE NHAPHANG
(
	MANH INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MANV INT NOT NULL,
	NGAYNHAP DATE,
	CONSTRAINT FK_NHAPHANG_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV),
	TONGTIEN FLOAT
);
CREATE TABLE CT_NHAPHANG
(
	MANH INT NOT NULL,
	MASP INT NOT NULL,
	CONSTRAINT PK_CTNH PRIMARY KEY (MANH,MASP),
	SOLUONG INT,
	CONSTRAINT FK_CTNH_NHAPHANG FOREIGN KEY (MANH) REFERENCES NHAPHANG(MANH),
	CONSTRAINT FK_CTNH_SANPHAM FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP),
	GIANHAP FLOAT,
	THANHTIEN FLOAT,
);
CREATE TABLE KHUYENMAI
(
	MAKM INT IDENTITY(1,1) NOT NULL,
	MASP INT NOT NULL,
	NGAYBATDAU DATE,
	NGAYKETTHUC DATE,
	KHUYENMAI FLOAT,
	CONSTRAINT PK_KM PRIMARY KEY (MAKM,MASP),
	CONSTRAINT FK_KHUYENMAI_SANPHAM FOREIGN KEY (MASP) REFERENCES SANPHAM(MASP)

);

DROP TABLE CT_HOADON;
DROP TABLE HOADON;
DROP TABLE CT_NHAPHANG;
DROP TABLE NHAPHANG;
DROP TABLE SANPHAM;
DROP TABLE LOAISP;
DROP TABLE CHUNGLOAI;
DROP TABLE NHACUNGCAP;
DROP TABLE NHANVIEN;
DROP TABLE TAIKHOAN;
DROP TABLE CHUCVU;
DROP TABLE KHUYENMAI;
GO
insert into TAIKHOAN values('thanhdat123','123'),
							('thanhcanh','123'),
							('tueman','123'),
							('truonggiang','123'),
							('huyhuy','123'),
							('nhannhan','123')
--GO
insert INTO CHUCVU values(N'Quản lý'),(N'Nhân viên quầy'),(N'Nhân viên kho'),(N'Nhân viên thu ngân')
--GO
set dateformat dmy;
INSERT INTO NHANVIEN VALUES (N'Nguyễn Thành Đạt',N'Nam','21/6/1999',N'Bình Định','1',N'D:\CNPM_PIC\NVNam.PNG','01239558432','321123999','1'),
							(N'Trần Thanh Cảnh',N'Nữ','6/4/1999',N'Bình Thuận','2',N'D:\CNPM_PIC\NVNu.PNG','01239556753','321123345','2'),
							(N'Phạm Nguyễn Tuệ Mẫn',N'Nữ','31/12/1999',N'Bến Tre','4',N'D:\CNPM_PIC\NVNu.PNG','01239556202','321123311','3'),
							(N'Nguyễn Trường Giang',N'Nam','18/3/1999',N'Đăk Nông','3',N'D:\CNPM_PIC\NVNam.PNG','01239567811','321123445','4'),
							(N'Phạm Quang Huy',N'Nam','4/7/1999',N'Vũng Tàu','3',N'D:\CNPM_PIC\NVNam.PNG','01239468923','321165191','5'),
							(N'Hoàng Thái Thanh Nhàn',N'Nữ','21/9/1999',N'TP.HCM','4',N'D:\CNPM_PIC\NVNu.PNG','01239556234','321123991','6')

insert into NHACUNGCAP values (N'Công ty CP Hàng Tiêu Dùng Masan',N'Tầng 12, tòa nhà MPlaza Saigon Số 39 Lê Duẩn, Phường Bến Nghé, Quận 1, Tp. Hồ Chí Minh','(84.28) 62 555 660'),
							  (N'Công ty TNHH Dầu thực vật Cái Lân',N'Khu Công nghiệp Cái Lân, Thành phố Hạ Long, Tỉnh Quảng Ninh, Việt Nam',' (84 33) 3846 993'),
							  (N'Công ty Cổ phần Acecook Việt Nam',N'Lô II-3, Đường số 11, KCN Tân Bình, Phường Tây Thạnh, Quận Tân Phú, Tp. Hồ Chí Minh.','(028) 3815 0969'),
							  (N'Công Ty CP Kỹ Nghệ Thực Phẩm Việt Nam (VIFON)',N'913 Trường Chinh, phường Tây Thạnh, quận Tân Phú, TPHCM','028.3815.3933'),
						      (N'Công Ty Cổ phần Việt Nam Kỹ Nghệ Súc Sản (Vissan)',N'420 Nơ Trang Long, P. 13, Quận Bình Thạnh, TP.HCM','(84 28) 3553 3999'),
						      (N'Công ty cổ phần thực phẩm Á Châu',N'Số 9/2, đường ĐT 743, khu phố 1B, phường An Phú,thị xã Thuận An, tỉnh Bình Dương','(028) 4450 0588'),
							  (N' Công ty CP Thực phẩm Dinh dưỡng Nutifood',N'281-283 Hoàng Diệu, Phường 6, Quận 4, TP. Hồ Chí Minh','(84-8) 38 267 999'),
							  (N'Công Ty Cổ Phần Thực Phẩm Đông Lạnh Kido',N'Lô A2 -7, Đường số N4, KCN Tây Bắc Củ Chi, Ấp Cây Sộp, Xã Tân An Hội, Huyện Củ Chi','(84) 3827 0468'),
						      (N'Công ty TNHH Nước giải khát SUNTORY PEPSICO Việt Nam',N'Tầng 5, Khách sạn Sheraton, 88 Đồng Khởi, Quận 1, TP. HCM','08 3821 9437'),
						      (N'Công ty cổ phần Bia - Rượu - Nước giải khát Hà Nội',N'183 Hoàng Hoa Thám, Ba Đình, Hà Nội','0243 845 843'),
							  (N'Công ty TNHH Lavie',N'Quốc lộ 1A, phường Khánh Hậu, thành phố Tân An, Long An','072 3511801'),
							  (N'Công ty TNHH Red Bull',N'Xa lộ Hà Nội, phường Bình Thắng, Dĩ An, Bình Dương','0274 3749 164'),
						      (N'Công ty bánh kẹo Á Châu',N'1175A, đường 3/2, phường 6, quận 11, Tp. HCM','(028) 37520857'),
						      (N'Công ty bánh kẹo Oishi Việt Nam',N'khu cn Vietnam Singapore, Số 14 Đường Số 5 VSIP, Dĩ An, Bình dương, Bình Dươngkhu cn Vietnam Singapore, Số 14 Đường Số 5 VSIP, Dĩ An, Bình dương, Bình Dương','842743743118'),
							  (N'Công ty Cổ Phần Sữa Việt Nam',N'Số 10, Đường Tân Trào, phường Tân Phú, quận 7, Tp. HCM','(028) 54 155 555')
insert into CHUNGLOAI values(N'Hàng tổng hợp'), (N'Hóa mỹ phẩm'),(N'Thực phẩm khô'),(N'Snack'),(N'Kem'),(N'Sữa&Sản phẩm từ Sữa'),(N'Nước giải khát lạnh'),(N'Bánh kẹo'),(N'Bia&Rượu'),(N'Kem')
insert into LOAISP values  (N'Bia Tiger','9','10',18000), 
						   (N'Bia Hà Nội Habeco','9','10',14000),
						   (N'Bia Larue','9','10',14000),
						   (N'Bia Heineken','9','10',18000),
						   (N'Nước giải khát ít calo Pepsi Light không đường','7','9',10000),
						   (N'Nước giải khát có gas hương chanh 7 Up','7','9',10000),
						   (N'Nước giải khát có gas Pepsi','7','9',10000),
						   (N'Nước giải khát có gas Sting','7','9',10000),
					       (N'Nước giải khát Coca Cola','7','9',10000),
						   (N'Nước khoáng thiên nhiên Lavie','7','11',10000),
						   (N'Nước giải khát ít calo Pepsi Light không đường','7','9',10000),
						   (N'Sữa tươi tiệt trùng tách béo Vinamilk không đường','6','15',10000), 
 					       (N'Sữa tươi tiệt trùng tách béo Vinamilk có đường','6','15',10000),					
						   (N'Mỳ tôm chua cay Hảo Hảo','3','3',3000),						   
						   (N'Mỳ Hảo 100','3','3',3000),
						   (N'Mỳ Số Đỏ','3','3',3000),
						   (N'Mỳ Lẩu Thái','3','3',6000),
						   (N'Mỳ Hoành Thánh','3','3',12000),
				           (N'Mỳ ly Modern','3','3',15000),
					       (N'Mỳ ly Enjoy ','3','3',18000),
						   (N'Phở Đệ Nhất','3','3',18000),
						   (N'Phở trộn Đệ Nhất','3','3',18000),
						   (N'Hủ tiếu Nhịp Sống','3','3',15000),
						   (N'Snack Tôm Cay','4','14',6000),
						   (N'Snack Tôm Cay Đặc biệt','4','14',6000),
						   (N'Snack Tôm Cay Vị Muối Ớt Xanh','4','14',6000),
						   (N'Snack Bí Đỏ','4','14',6000),
						   (N'Snack Hành','4','14',6000),
						   (N'Snack Tomati','4','14',6000),
						   (N'Snack Rau Cải','4','14',6000),
						   (N'Snack Bắp','4','14',6000),
						   (N'Snack Phomai miếng','4','14',6000),
						   (N'Snack Tom Toms','4','14',6000),
						   (N'Snack Inka','4','14',6000),
						   (N'Snack lula','4','14',6000),
						   (N'Snack 4x','4','14',6000),
						   (N'Kẹo Thập Cẩm','8','14',17000),
						   (N'Kẹo vị ổi','8','14',18000),
						   (N'Kẹo vị me','8','14',15000),
						   (N'Kẹo vị soda chanh đá','8','14',16000),
						   (N'Kẹo vị Bạc hà','8','14',16000),
						   (N'Dầu ăn','1','2',28000),
						   (N'Tương ớt','1','1',14000),
						   (N'Nước mắm','1','1',25000),
						   (N'Cháo thịt gà Vifon','3','4',4000),
						   (N'Sữa pha sẵn GrowPLUS+ Diamond ','6','7',12000)
set dateformat dmy;
insert into SANPHAM values (1,'28/12/2019','28/12/2020',54), 
						   (2,'1/3/2020','1/3/2021',56),
						   (3,'21/12/2019','21/12/2020',15),
						   (4,'2/2/2020','2/2/2021',22),
						   (5,'8/1/2020','8/1/2021',78),
						   (6,'5/12/2019','5/12/2020',12),
						   (7,'28/12/2019','28/12/2020',77),
						   (8,'28/12/2019','28/12/2020',10),
					       (9,'2/2/2020','2/2/2021',0),
						   (10,'8/2/2020','8/2/2021',8),
						   (5,'30/5/2020','30/5/2021',12),
						   (6,'23/6/2020','23/6/2021',34),
						   (7,'2/1/2020','2/1/2021',17),
						   (8,'1/7/2020','1/7/2021',9),
						   (9,'21/4/2020','21/4/2021',44),
						   (10,'1/6/2020','1/6/2022',48),
						   (11,'12/4/2020','12/4/2022',67), 
 					       (12,'11/3/2020','11/3/2022',23),
						   (11,'19/5/2020','19/5/2022',88),
						   (12,'30/6/2020','30/6/2022',12),
						   (13,'28/5/2020','28/5/2022',12),
						   (13,'30/5/2020','30/10/2020',67),
						   (13,'20/4/2020','20/9/2020',3),
						   (14,'25/4/2020','25/9/2020',5),
						   (14,'25/5/2020','25/9/2020',14),
						   (15,'27/2/2020','27/7/2020',33),
						   (16,'21/4/2020','21/9/2020',12),
						   (17,'28/3/2020','28/8/2020',66),
				           (18,'29/6/2020','29/11/2020',4),
				           (19,'28/5/2020','28/10/2020',78),
					       (19,'2/6/2020','2/11/2020',34),
					       (20,'21/6/2020','21/11/2020',43),
						   (21,'2/6/2020','2/11/2020',12),
						   (22,'12/6/2020','12/11/2020',11),
						   (23,'19/5/2020','19/10/2020',1),
						   (24,'3/5/2020','3/10/2020',3),
						   (25,'1/6/2020','1/6/2021',4),
						   (26,'22/4/2020','22/4/2021',6),
						   (27,'2/6/2020','2/6/2021',9),
						   (28,'11/5/2020','11/5/2021',1),
						   (29,'11/5/2020','11/5/2021',66),
						   (30,'12/6/2020','12/6/2021',8),
						   (31,'13/4/2020','13/9/2020',11),
						   (32,'1/6/2020','1/6/2021',45),
						   (33,'11/5/2020','11/10/2020',99),
						   (34,'19/5/2020','19/10/2020',1),
						   (35,'15/7/2020','15/7/2021',6),
						   (36,'1/11/2019','1/11/2020',8),
						   (37,'13/4/2020','13/4/2021',9),
						   (38,'13/4/2020','13/4/2021',10),
						   (39,'13/4/2020','13/4/2021',45),
						   (40,'11/5/2020','11/5/2021',65),
						   (41,'3/1/2020','11/5/2021',12),
						   (42,'25/2/2020','11/5/2021',45),
						   (43,'13/4/2020','11/5/2021',13),
						   (44,'13/4/2020','11/5/2021',55),
						   (45,'11/5/2020','11/5/2021',1),
						   (46,'13/4/2020','11/5/2021',1)

insert into HOADON(NGAYLAP, MANV) values('12/7/2020',3),
										('12/7/2020',3),
										('12/7/2020',3),
										('12/7/2020',3),
										('13/7/2020',3),
										('13/7/2020',3),
										('16/7/2020',3),
										('15/7/2020',3),
										('17/7/2020',6),
										('17/7/2020',6),
										('11/7/2020',6),
										('11/7/2020',6),
										('11/7/2020',6),
										('12/7/2020',6),
										('3/7/2020',3)
										

insert into CT_HOADON(MAHD,MASP,SOLUONGSP)values (1,12,1),
																(1,6,1),
																(2,10,3),
																(3,22,2),
																(4,27,1),
																(4,30,2),
																(4,33,2),
																(5,43,1),
																(6,45,1),
																(6,28,1),
																(7,6,1),
																(7,7,1),
																(7,8,1),
																(7,19,1),
																(8,1,1),
																(9,33,1),
																(9,41,2),
																(9,11,1),
																(10,11,1),
																(10,38,1),
																(10,2,2),
																(11,38,1),
																(11,14,1),
																(12,16,1),
																(13,20,1),
																(13,12,1),
																(14,19,2),
																(15,26,1)
																

insert into NHAPHANG(MANV,NGAYNHAP) values (4,'29/4/2020'),
											   (4,'10/5/2020'),
											   (4,'25/5/2020'),
											   (5,'5/6/2020')

insert into CT_NHAPHANG(MANH,MASP,SOLUONG,GIANHAP) values		  (1,1,500,13000),
																  (1,3,500,10000),
																  (1,4,500,13500),
																  (1,7,600,6300),
																  (1,8,700,6200),
																  (1,12,300,6000),
																  (1,17,400,5000),
																  (1,18,400,5000),
																  (1,43,100,4000),
																  (1,31,200,12000),
																  (1,39,300,4000),
																  (1,23,200,1900),
																  (2,2,500,9000),
																  (2,15,500,6300),
																  (2,36,200,4000),
																  (2,27,50,3000),
																  (2,11,50,7000),
																  (2,18,200,6000),
																  (2,19,400,5000),
																  (2,20,400,5000),
																  (3,19,250,5000),
																  (3,20,250,5000),
																  (3,16,500,3000),
																  (3,21,250,1900),
																  (3,29,250,9000),
																  (3,37,300,4000),
																  (4,13,100,6000),
																  (4,12,100,6000),
																  (4,14,300,6000),
																  (4,6,50,6000)

insert into KHUYENMAI values(6,'15/7/2020','16/7/2020',0.3),
							(8,'15/7/2020','16/7/2020',0.3),
							(7,'15/7/2020','16/7/2020',0.3),
							(1,'17/7/2020','19/7/2020',0.4)
							
							
																  
											


