using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace MVC
{
    class hs_ctrl
    {
        DataProvider _provider;
        public hs_ctrl()
        {
            _provider = new DataProvider();
        }
        public bool Connect()
        {
            return _provider.Connect();
        }
        public void Disconnect()
        {
            _provider.Disconnect();
        }
        public DataTable GetDatatable(string table)
        {
            return _provider.loadTable("sp_Select",table);
        }
        public void InsertHS(string mahs, string tenhs, string ngaysinh, string diachi, string malop, float dtb)
        {
            _provider.InsertHS("sp_InsertHS",  mahs,  tenhs,  ngaysinh,  diachi,  malop,  dtb);
        }
    }
}
