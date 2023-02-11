using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC
{
    class hs_info
    {
        private string _maHS;
        private string _tenHS;
        private float _dtb;
        private string _ngaysinh;
        private string _diachi;
        private string _maLop;
        public string MaHS
        {
            get
            {
                return _maHS;
            }
            set
            {
                if (value == null)
                    throw new Exception("Ma HS khong duoc rong");
                _maHS = value;
            }
        }
        public string TenHS
        {
            get
            {
                return _tenHS;
            }
            set
            {
                if (value == null)
                    throw new Exception("Ten HS khong duoc rong");
                _tenHS = value;
            }
        }
        public float dtb
        {
            get
            {
                return _dtb;
            }
            set
            {
                _dtb = value;
            }
        }
        public string NgaySinh
        {
            get
            {
                return _ngaysinh;
            }
            set
            {
                _ngaysinh = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return _diachi;
            }
            set
            {
                if (value == null)
                    throw new Exception("Dia chi HS khong duoc rong");
                _diachi = value;
            }
        }
        public string MaLop
        {
            get
            {
                return _maLop;
            }
            set
            {
                _maLop = value;
            }
        }
    }
}
