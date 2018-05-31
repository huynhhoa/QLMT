using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLMT.Models
{
    public class May
    {
        //anh xa toan bo database
        [Display(Name = "Mã máy:")]
        public int MaTS { set; get; }
        //trả về lỗi nếu không nhập số serial máy
        [Required(ErrorMessage ="Mời nhập số Serial máy")]
        [Display(Name ="Số Serial:")]
        public string IdMay { set; get; }
        [Required(ErrorMessage ="Mời nhập tên máy")]
        [Display(Name = "Tên máy:")]
        public string TenMay { set; get; }
        [Display(Name = "Giá trị:")]
        public string GiaTri { set; get; }
        [Display(Name = "Loại:")]
        public string Loai { set; get; }
        [Display(Name = "Màu sắc:")]
        public string MauSac { set; get; }
        [Display(Name = "Kích thước:")]
        public string KichThuoc { set; get; }
        [Display(Name = "CPU:")]
        public string CPU { set; get; }
        [Display(Name = "RAM:")]
        public string RAM { set; get; }
        [Display(Name = "Ổ cứng:")]
        public string Ocung { set; get; }
        [Display(Name = "Hệ điều hành:")]
        public string HeDieuHanh { set; get; }
        [Display(Name = "Đồ họa:")]
        public string DoHoa { set; get; }
        [Required(ErrorMessage = "Mời nhập ngày nhập máy")]
        [Display(Name = "Ngày nhập máy:")]
        public DateTime NgayNhapMay { set; get; }
        [Display(Name = "Tình trạng máy:")]
        public string TinhTrangMay { set; get; }
        [Display(Name = "Trạng thái:")]
        public bool TrangThai { set; get; }
    }
    class MayList 
    {
        //tao doi tuong cua lop
        DBConnection db;
        public MayList()
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
        public List<May> getTrangThai(int TrangThai)
        {
            string sql = "Select * from May where TrangThai= " + TrangThai;
            List<May> mayList = new List<May>();
            dt = new DataTable();
            ketnoi(sql);
            May may;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                may = new May();
                may.MaTS = Convert.ToInt32(dt.Rows[i]["MaTS"].ToString());
                may.IdMay = dt.Rows[i]["IdMay"].ToString();
                may.TenMay = dt.Rows[i]["TenMay"].ToString();
                may.GiaTri = dt.Rows[i]["GiaTri"].ToString();
                may.Loai = dt.Rows[i]["Loai"].ToString();
                may.MauSac = dt.Rows[i]["MauSac"].ToString();
                may.KichThuoc = dt.Rows[i]["KichThuoc"].ToString();
                may.CPU = dt.Rows[i]["CPU"].ToString();
                may.RAM = dt.Rows[i]["RAM"].ToString();
                may.Ocung = dt.Rows[i]["Ocung"].ToString();
                may.HeDieuHanh = dt.Rows[i]["HeDieuHanh"].ToString();
                may.DoHoa = dt.Rows[i]["DoHoa"].ToString();
                may.NgayNhapMay = DateTime.Parse(dt.Rows[i]["NgayNhapMay"].ToString());
                may.TinhTrangMay = dt.Rows[i]["TinhTrangMay"].ToString();
                may.TrangThai = Convert.ToBoolean(dt.Rows[i]["TrangThai"].ToString());

                //add doi tuong vao list
                mayList.Add(may);
            }
            return mayList;
        
    }
    //hien thi danh sach may tinh
        public List<May> getMay (string IdMay)
        {
            string sql;
            if (string.IsNullOrEmpty(IdMay))
                sql = "Select * from May";
            else
                sql = "Select * from May where IdMay= " + IdMay;
            List<May> mayList = new List<May>();
             dt = new DataTable();
            ketnoi(sql);
            May may;
            for(int i =0;i<dt.Rows.Count;i++)
            {
                may = new May();
                may.MaTS = Convert.ToInt32(dt.Rows[i]["MaTS"].ToString());
                may.IdMay = dt.Rows[i]["IdMay"].ToString();
                may.TenMay = dt.Rows[i]["TenMay"].ToString();
                may.GiaTri = dt.Rows[i]["GiaTri"].ToString();
                may.Loai = dt.Rows[i]["Loai"].ToString();
                may.MauSac = dt.Rows[i]["MauSac"].ToString();
                may.KichThuoc = dt.Rows[i]["KichThuoc"].ToString();
                may.CPU = dt.Rows[i]["CPU"].ToString();
                may.RAM = dt.Rows[i]["RAM"].ToString();
                may.Ocung = dt.Rows[i]["Ocung"].ToString();
                may.HeDieuHanh = dt.Rows[i]["HeDieuHanh"].ToString();
                may.DoHoa = dt.Rows[i]["DoHoa"].ToString();
                may.NgayNhapMay = DateTime.Parse(dt.Rows[i]["NgayNhapMay"].ToString());
                may.TinhTrangMay = dt.Rows[i]["TinhTrangMay"].ToString();
                may.TrangThai = Convert.ToBoolean(dt.Rows[i]["TrangThai"].ToString());
                    
                //add doi tuong vao list
                mayList.Add(may);
            }
            return mayList;
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
        // Add máy tính 
        public void AddMay(May addmay)
        {
            string sql = "Insert into May(MaTS,IdMay,TenMay,GiaTri,Loai,MauSac,KichThuoc,CPU,RAM,Ocung,HeDieuHanh,DoHoa,NgayNhapMay,TinhTrangMay,TrangThai) values(N'" 
                +  addmay.MaTS +"',N'" +addmay.IdMay +"',N'" +addmay.TenMay +"',N'" +addmay.GiaTri +"',N'" + addmay.Loai+"',N'" + addmay.MauSac+"',N'" + addmay.KichThuoc
                +"',N'" + addmay.CPU+"',N'" + addmay.RAM  +"',N'" + addmay.Ocung+"',N'" + addmay.HeDieuHanh+"',N'" + addmay.DoHoa+"',N'"
                +addmay.NgayNhapMay +"',N'" +addmay.TinhTrangMay +"',N'" +  0 + "')";
            RunSQL(sql);
        }
        //Sửa máy
        public void UpdateMay(May upmay)
        {
            string sql = "UPDATE May Set TenMay=N'" + upmay.TenMay + "',N'" + upmay.GiaTri + "',N'" + upmay.Loai + "',N'" + upmay.MauSac + "',N'" + upmay.KichThuoc
                + "',N'" + upmay.CPU + "',N'" + upmay.RAM + "',N'" + upmay.Ocung + "',N'" + upmay.HeDieuHanh + "',N'" + upmay.DoHoa + "',N'"
                + upmay.NgayNhapMay + "',N'" + upmay.TinhTrangMay +
            "'WHERE IdMay=N'" + upmay.IdMay + "'";
            RunSQL(sql);
        }
        //Xóa máy
        public void DeleteMay(May delemay)
        {
            if (delemay.TrangThai is false)
            {
                string sql = "DELETE May WHERE IdMay=N'" + delemay.IdMay + "'";
                RunSQL(sql);
            }
        }
        
    }
}