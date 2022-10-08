﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebBanVaLi_TTK.Models
{
    [MetadataTypeAttribute(typeof(tDanhMucSPMetadata))]
    public partial class tDanhMucSP
    {
        internal sealed class tDanhMucSPMetadata
        {
            [DisplayName("Mã sản phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string MaSP { get; set; }
            [DisplayName("Tên sản phẩm")]
            public string TenSP { get; set; }
            [DisplayName("Mã chất liệu")]
            public string MaChatLieu { get; set; }
            [DisplayName("Ngăn Laptop")]
            public string NganLapTop { get; set; }
            public string Model { get; set; }
            [DisplayName("Màu sắc")]
            public string MauSac { get; set; }
            [DisplayName("Mã kích thước")]
            public string MaKichThuoc { get; set; }
            [DisplayName("Cân nặng")]
            public Nullable<double> CanNang { get; set; }
            [DisplayName("Độ nới")]
            public Nullable<double> DoNoi { get; set; }
            [DisplayName("Mã hãng sản xuất")]
            public string MaHangSX { get; set; }
            [DisplayName("Mã nước sản xuất")]
            public string MaNuocSX { get; set; }
            [DisplayName("Mã đặc tính")]
            public string MaDacTinh { get; set; }
            public string Website { get; set; }
            [DisplayName("Thời gian bảo hành")]
            public Nullable<double> ThoiGianBaoHanh { get; set; }
            [DisplayName("Giới thiệu sản phẩm")]
            public string GioiThieuSP { get; set; }
            [DisplayName("Giá sản phẩm")]
            public Nullable<double> Gia { get; set; }
            [DisplayName("Chiết khấu")]
            public Nullable<double> ChietKhau { get; set; }
            [DisplayName("Mã loại")]
            public string MaLoai { get; set; }
            [DisplayName("Mã đối tượng")]
            public string MaDT { get; set; }
            [DisplayName("Ảnh")]
            public string Anh { get; set; }
        }
    }
}
