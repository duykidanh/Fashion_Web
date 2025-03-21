﻿// <auto-generated />
using System;
using Fashion_Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTL_LTWeb.Migrations
{
    [DbContext(typeof(QLBanDoThoiTrangContext))]
    partial class QLBanDoThoiTrangContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fashion_Web.Models.TAnhChiTietSp", b =>
                {
                    b.Property<int>("MaChiTietSp")
                        .HasColumnType("int")
                        .HasColumnName("MaChiTietSP");

                    b.Property<string>("TenFileAnh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ViTri")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaChiTietSp", "TenFileAnh")
                        .HasName("PK__tAnhChiT__6DFA63355C4D9532");

                    b.ToTable("tAnhChiTietSP", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TAnhSp", b =>
                {
                    b.Property<int>("MaSp")
                        .HasColumnType("int")
                        .HasColumnName("MaSP");

                    b.Property<string>("TenFileAnh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ViTri")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MaSp", "TenFileAnh")
                        .HasName("PK__tAnhSP__2FC2FB7E27DAAE4B");

                    b.ToTable("tAnhSP", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TChiTietHoaDonBan", b =>
                {
                    b.Property<int>("MaHoaDonBan")
                        .HasColumnType("int")
                        .HasColumnName("MaHoaDonBan");

                    b.Property<int>("MaChiTietSP")
                        .HasColumnType("int")
                        .HasColumnName("MaChiTietSP");

                    b.Property<decimal?>("DonGiaBan")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("DonGiaBan");

                    b.Property<int?>("SoLuongBan")
                        .HasColumnType("int")
                        .HasColumnName("SoLuongBan");

                    b.HasKey("MaHoaDonBan", "MaChiTietSP")
                        .HasName("PK__tChiTiet__6A50CA8AF98C3478");

                    b.HasIndex("MaChiTietSP");

                    b.ToTable("tChiTietHoaDonBan", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TChiTietSanPham", b =>
                {
                    b.Property<int>("MaChiTietSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaChiTietSP");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietSp"));

                    b.Property<string>("AnhDaiDien")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("KichThuoc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaSp")
                        .HasColumnType("int")
                        .HasColumnName("MaSP");

                    b.Property<string>("MauSac")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Slton")
                        .HasColumnType("int")
                        .HasColumnName("SLTon");

                    b.HasKey("MaChiTietSp")
                        .HasName("PK__tChiTiet__651D9057021AE26D");

                    b.HasIndex("MaSp");

                    b.ToTable("tChiTietSanPham", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TDanhGia", b =>
                {
                    b.Property<int>("MaDanhGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDanhGia"));

                    b.Property<string>("BinhLuan")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Diem")
                        .HasColumnType("int");

                    b.Property<string>("LichSu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TraLoi")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("MaDanhGia");

                    b.ToTable("tDanhGia", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TDanhMucSp", b =>
                {
                    b.Property<int>("MaSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaSP");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSp"));

                    b.Property<string>("AnhDaiDien")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ChatLieu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Gia")
                        .IsRequired()
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("GioiThieuSp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GioiThieuSP");

                    b.Property<string>("HangSx")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("HangSX");

                    b.Property<string>("LoaiDt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LoaiDT");

                    b.Property<string>("TenSp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TenSP");

                    b.Property<int?>("ThoiGianBaoHanh")
                        .HasColumnType("int");

                    b.HasKey("MaSp")
                        .HasName("PK__tDanhMuc__2725081C34ED1B0E");

                    b.ToTable("tDanhMucSP", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TGiaoHang", b =>
                {
                    b.Property<int>("MaGiaoHang")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("MaGiaoHang");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGiaoHang"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("DiaChi");

                    b.Property<string>("HoTenNguoiNhan")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("HoTenNguoiNhan");

                    b.Property<int>("MaHoaDonBan")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("MaHoaDonBan");

                    b.Property<string>("QuanHuyen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("QuanHuyen");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("SoDienThoai");

                    b.Property<string>("ThanhPho")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ThanhPho");

                    b.HasKey("MaGiaoHang")
                        .HasName("PK_TGiaoHang");

                    b.HasIndex("MaHoaDonBan")
                        .IsUnique();

                    b.ToTable("tGiaoHang", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TGioHang", b =>
                {
                    b.Property<int>("MaGioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGioHang"));

                    b.Property<int>("MaChiTietSP")
                        .HasColumnType("int")
                        .HasColumnName("MaChiTietSP");

                    b.Property<int>("MaKhachHang")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("MaKhachHang");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int")
                        .HasColumnName("SoLuong");

                    b.HasKey("MaGioHang")
                        .HasName("PK__tGioHang__F5001DA30BA24EA8");

                    b.HasIndex("MaChiTietSP");

                    b.HasIndex("MaKhachHang");

                    b.ToTable("tGioHang", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.THoaDonBan", b =>
                {
                    b.Property<int>("MaHoaDonBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MaHoaDonBan");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHoaDonBan"));

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaGiamGia")
                        .HasColumnType("int")
                        .HasColumnName("MaGiamGia");

                    b.Property<int?>("MaKhachHang")
                        .HasColumnType("int")
                        .HasColumnName("MaKhachHang");

                    b.Property<DateTime?>("NgayHoaDon")
                        .HasColumnType("datetime");

                    b.Property<string>("PhuongThucThanhToan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("TongTienHd")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("TongTienHD");

                    b.HasKey("MaHoaDonBan")
                        .HasName("PK__tHoaDonBan");

                    b.HasIndex("MaGiamGia");

                    b.HasIndex("MaKhachHang");

                    b.ToTable("tHoaDonBan", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TKhachHang", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhachHang"));

                    b.Property<string>("DiaChi")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("NgaySinh")
                        .HasColumnType("date");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhachHang")
                        .HasName("PK__tKhachHa__88D2F0E5693BB92D");

                    b.HasIndex("Email");

                    b.ToTable("tKhachHang", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TMaGiamGia", b =>
                {
                    b.Property<int>("MaGiamGia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGiamGia"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("Code");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Mota");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2")
                        .HasColumnName("NgayBatDau");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2")
                        .HasColumnName("NgayKetThuc");

                    b.Property<decimal>("TiLeGiam")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TiLeGiam");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int")
                        .HasColumnName("TrangThai");

                    b.HasKey("MaGiamGia")
                        .HasName("PK_tMaGiamGia");

                    b.ToTable("tMaGiamGia", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TNhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNhanVien"));

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("TenNhanVien")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaNhanVien")
                        .HasName("PK__tNhanVie__77B2CA474377FBA4");

                    b.HasIndex("Email");

                    b.ToTable("tNhanVien", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TPhanHoi", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int>("MaDanhGia")
                        .HasColumnType("int");

                    b.Property<int>("HuuIch")
                        .HasColumnType("int");

                    b.Property<int>("Thich")
                        .HasColumnType("int");

                    b.HasKey("MaKhachHang", "MaDanhGia");

                    b.ToTable("tPhanHoi", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TUser", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("LoaiUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Email")
                        .HasName("PK__tUser__F3DBC5736648EC50");

                    b.ToTable("tUser", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TempUserOtp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OtpCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("OtpExpiration")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK__TempUser__3214EC0793EDB907");

                    b.ToTable("TempUserOtp", (string)null);
                });

            modelBuilder.Entity("Fashion_Web.Models.TAnhChiTietSp", b =>
                {
                    b.HasOne("Fashion_Web.Models.TChiTietSanPham", "ChiTietSanPham")
                        .WithMany("TAnhChiTietSps")
                        .HasForeignKey("MaChiTietSp")
                        .IsRequired()
                        .HasConstraintName("FK_AnhChiTietSP_ChiTietSP");

                    b.Navigation("ChiTietSanPham");
                });

            modelBuilder.Entity("Fashion_Web.Models.TAnhSp", b =>
                {
                    b.HasOne("Fashion_Web.Models.TDanhMucSp", "DangMucSp")
                        .WithMany("TAnhSps")
                        .HasForeignKey("MaSp")
                        .IsRequired()
                        .HasConstraintName("FK_AnhSP_ChiTietSanPham");

                    b.Navigation("DangMucSp");
                });

            modelBuilder.Entity("Fashion_Web.Models.TChiTietHoaDonBan", b =>
                {
                    b.HasOne("Fashion_Web.Models.TDanhMucSp", "DanhMucSP")
                        .WithMany()
                        .HasForeignKey("MaChiTietSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tChiTietHoaDonBan_tDanhMucSP");

                    b.HasOne("Fashion_Web.Models.THoaDonBan", "HoaDonBan")
                        .WithMany("TChiTietHoaDonBans")
                        .HasForeignKey("MaHoaDonBan")
                        .IsRequired()
                        .HasConstraintName("FK_HoaDonBan_ChiTietHoaDonBan");

                    b.Navigation("DanhMucSP");

                    b.Navigation("HoaDonBan");
                });

            modelBuilder.Entity("Fashion_Web.Models.TChiTietSanPham", b =>
                {
                    b.HasOne("Fashion_Web.Models.TDanhMucSp", "DanhMucSp")
                        .WithMany("TChiTietSanPhams")
                        .HasForeignKey("MaSp")
                        .IsRequired()
                        .HasConstraintName("FK_ChiTietSP_DanhMucSP");

                    b.Navigation("DanhMucSp");
                });

            modelBuilder.Entity("Fashion_Web.Models.TGiaoHang", b =>
                {
                    b.HasOne("Fashion_Web.Models.THoaDonBan", "HoaDonBan")
                        .WithOne("GiaoHang")
                        .HasForeignKey("Fashion_Web.Models.TGiaoHang", "MaHoaDonBan")
                        .IsRequired();

                    b.Navigation("HoaDonBan");
                });

            modelBuilder.Entity("Fashion_Web.Models.TGioHang", b =>
                {
                    b.HasOne("Fashion_Web.Models.TChiTietSanPham", "ChiTietSanPham")
                        .WithMany()
                        .HasForeignKey("MaChiTietSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fashion_Web.Models.TKhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChiTietSanPham");

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("Fashion_Web.Models.THoaDonBan", b =>
                {
                    b.HasOne("Fashion_Web.Models.TMaGiamGia", "GiamGia")
                        .WithMany()
                        .HasForeignKey("MaGiamGia")
                        .HasConstraintName("FK_HoaDonBan_MaGiamGia");

                    b.HasOne("Fashion_Web.Models.TKhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKhachHang")
                        .HasConstraintName("FK_HoaDonBan_KhachHang");

                    b.Navigation("GiamGia");

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("Fashion_Web.Models.TKhachHang", b =>
                {
                    b.HasOne("Fashion_Web.Models.TUser", "User")
                        .WithMany("TKhachHangs")
                        .HasForeignKey("Email")
                        .IsRequired()
                        .HasConstraintName("FK_KhachHang_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fashion_Web.Models.TNhanVien", b =>
                {
                    b.HasOne("Fashion_Web.Models.TUser", "UsernameNavigation")
                        .WithMany("TNhanViens")
                        .HasForeignKey("Email")
                        .IsRequired()
                        .HasConstraintName("FK_tNhanVien_tUser");

                    b.Navigation("UsernameNavigation");
                });

            modelBuilder.Entity("Fashion_Web.Models.TChiTietSanPham", b =>
                {
                    b.Navigation("TAnhChiTietSps");
                });

            modelBuilder.Entity("Fashion_Web.Models.TDanhMucSp", b =>
                {
                    b.Navigation("TAnhSps");

                    b.Navigation("TChiTietSanPhams");
                });

            modelBuilder.Entity("Fashion_Web.Models.THoaDonBan", b =>
                {
                    b.Navigation("GiaoHang")
                        .IsRequired();

                    b.Navigation("TChiTietHoaDonBans");
                });

            modelBuilder.Entity("Fashion_Web.Models.TUser", b =>
                {
                    b.Navigation("TKhachHangs");

                    b.Navigation("TNhanViens");
                });
#pragma warning restore 612, 618
        }
    }
}
