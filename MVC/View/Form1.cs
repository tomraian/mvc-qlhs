using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC
{
    public partial class Form1 : Form
    {
        hs_ctrl ctrl = new hs_ctrl();
        hs_info info = new hs_info();
        
       // string mahs,tenhs, ngaysinh, diachi,dtb,malop;
        DataProvider data = new DataProvider();
        public Form1()
        {
            InitializeComponent();
        }
        public void loadlop()
        {
            cboLop.DisplayMember = "tenlop";
            cboLop.ValueMember = "malop";
            cboLop.DataSource = ctrl.GetDatatable("lop");
        }
        public void loadDanhSach()
        {
            string malop;
            malop = cboLop.SelectedValue.ToString();
            dtgHocSinh.DataSource = ctrl.GetDatatable("hocsinh where malop ='" + malop + "'");
        }
        public void connect()
        {
            if (!ctrl.Connect())
            {
                MessageBox.Show("Không thể kết nối đến với csdl");
                this.Close();
            }
            ctrl.Connect();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataProvider.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\winform\MVC\MVC\app_data\qlhs.mdf;Integrated Security=True";
            connect();
            loadlop();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LayDuLieu();
            ctrl.InsertHS(info.MaHS, info.TenHS, info.NgaySinh, info.DiaChi, info.MaLop, info.dtb);
            loadDanhSach();
        }
        public void LayDuLieu()
        {
            info.MaLop = cboLop.SelectedValue.ToString();
            info.MaHS = txtMa.Text;
            info.TenHS = txtTen.Text;
            info.NgaySinh = dtNgaySinh.Text;
            info.DiaChi = txtDiaChi.Text;
            info.dtb = float.Parse(txtDiemTB.Text);
        }
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDanhSach();

        }
    }
}
