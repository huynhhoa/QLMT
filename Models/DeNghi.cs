using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLMT.Models
{
    public class DeNghi
    {
        //anh xa toan bo database
        [Display(Name = "Mã ĐN:")]
        public int MaDN { set; get; }
        [Display(Name = "Ngày ĐN:")]
        public DateTime NgayDN { set; get; }
        [Display(Name = "Tên NV ĐN:")]
        public string TenNguoiDN { set; get; }
        [Required(ErrorMessage = "Nhập số CMND")]
        [Display(Name = "CMND:")]
        public int CMND { set; get; }
        [Required(ErrorMessage = "Nhập tên trường bộ phận")]
        [Display(Name = "Trưởng BP:")]
        public string TruongBP { set; get; }
        [Required(ErrorMessage = "Nhập số mô tả")]
        [Display(Name = "Mô tả")]
        public string MoTa { set; get; }
        [Display(Name = "Ghi chú:")]
        public string LyDo { set; get; }
        public string GhiChu { set; get; }
        [Display(Name = "Số lượng:")]
        public int SoLuong{ set; get; }
        [Display(Name = "Ngày duyệt")]
        public DateTime NgayDuyetDN { set; get; }
        [Display(Name = "Tình trạng")]
        public bool TinhTrangDN { set; get; }
    }
    class DeNghiList
    {
        //tao doi tuong cua lop
        DBConnection db;
        public DeNghiList()
        {
            db = new DBConnection();
        }
        DataTable dt;
        public void ketnoi(string sql)
        {
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
        }
        //Hien thi danh sach de nghi trong tinh trang dang cho "Tinhtrangdn =0"
        public List<DeNghi> getDN (int TinhTrang)
        {
            string sql = "Select * from DeNghi where TinhTrangDN= " + TinhTrang ;
            List<DeNghi> dnList = new List<DeNghi>();
            dt= new DataTable();
            ketnoi(sql);
            DeNghi denghi;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                denghi = new DeNghi();
                denghi.MaDN = int.Parse(dt.Rows[i]["MaDN"].ToString());
                denghi.NgayDN = DateTime.Parse(dt.Rows[i]["NgayDN"].ToString());
                denghi.TenNguoiDN = dt.Rows[i]["TenNguoiDN"].ToString();
                denghi.CMND = int.Parse(dt.Rows[i]["CMND"].ToString());
                denghi.TruongBP = dt.Rows[i]["TruongBP"].ToString();
                denghi.MoTa = dt.Rows[i]["MoTa"].ToString();
                denghi.LyDo = dt.Rows[i]["LyDo"].ToString();
                denghi.GhiChu = dt.Rows[i]["GhiChu"].ToString();
                denghi.SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                denghi.NgayDuyetDN = DateTime.Parse(dt.Rows[i]["NgayDuyetDN"].ToString());
                denghi.TinhTrangDN = bool.Parse(dt.Rows[i]["TinhTrangDN"].ToString());
                dnList.Add(denghi);
            }
            return dnList;

        }
        public List<DeNghi> getDNMa(int MaDN)
        {
            string sql;
            if(MaDN ==null)
                sql = "Select * from DeNghi";
            else
                sql = "Select * from DeNghi where MaDN= " + MaDN;
            List<DeNghi> dnList = new List<DeNghi>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            DeNghi denghi;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                denghi = new DeNghi();
                denghi.MaDN = int.Parse(dt.Rows[i]["MaDN"].ToString());
                denghi.NgayDN = DateTime.Parse(dt.Rows[i]["NgayDN"].ToString());
                denghi.TenNguoiDN = dt.Rows[i]["TenNguoiDN"].ToString();
                denghi.CMND = int.Parse(dt.Rows[i]["CMND"].ToString());
                denghi.TruongBP = dt.Rows[i]["TruongBP"].ToString();
                denghi.MoTa = dt.Rows[i]["MoTa"].ToString();
                denghi.LyDo = dt.Rows[i]["LyDo"].ToString();
                denghi.GhiChu = dt.Rows[i]["GhiChu"].ToString();
                denghi.SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                denghi.NgayDuyetDN = DateTime.Parse(dt.Rows[i]["NgayDuyetDN"].ToString());
                denghi.TinhTrangDN = bool.Parse(dt.Rows[i]["TinhTrang"].ToString());
                dnList.Add(denghi);
            }
            return dnList;
        }
        public void RunSQL(string sql)
        {
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        //Them de nghi
        public void AddDeNghi(DeNghi adddeNghi)
        {
            string sql = "Insert into DeNghi(NgayDN,TenNguoiDN,CMND,TruongBP,MoTa,LyDo,GhiChu,SoLuong,NgayDuyetDN,TinhTrangDN)  values(N'"
                + adddeNghi.NgayDN +"',N'"+adddeNghi.TenNguoiDN+"',N'"+adddeNghi.CMND+"',N'"+adddeNghi.TruongBP+"',N'"+adddeNghi.MoTa
                +"',N'"+ adddeNghi.LyDo+"',N'"+adddeNghi.GhiChu+"',N'"+adddeNghi.SoLuong+"',N'"+adddeNghi.NgayDuyetDN+"',N'"+ 0 + "')";
            RunSQL(sql);
        }
        //sua de nghi
        public void EditDN(DeNghi editDN)
        {
            string sql= "Update DeNghi Set NgayDN= N'" + editDN.NgayDN + "',N'" + editDN.TenNguoiDN+"',N'" + editDN.CMND+"',N'" + editDN.TruongBP+"',N'" +
                editDN.MoTa+"',N'" + editDN.LyDo+"',N'" +editDN.LyDo
                 +"',N'" + editDN.GhiChu+"',N'" + editDN.SoLuong+"',N'" +editDN.NgayDuyetDN + "',N'" + editDN.TinhTrangDN +
                  "'WHERE MaDN=N'" + editDN.MaDN + "'";
            RunSQL(sql);
        }

        //xoa de nghi vs tinh trang chua duyet
        public void DeleteDN(DeNghi deleDN)
        {
            if (deleDN.TinhTrangDN is false)
            {
                string sql = "DELETE DeNghi WHERE MaDN=N'" + deleDN.MaDN + "'";
                RunSQL(sql);
            }
            else
            {
               
            }
        }
    }
}