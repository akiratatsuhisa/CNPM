using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class DataProvider
    {
        private static DataProvider _instance;
        public static DataProvider Instance => _instance = _instance ?? new DataProvider();

        public SalesManagementEntities DataContext;

        public DataProvider()
        {
            DataContext = new SalesManagementEntities();
        }
    }

    public class SalesManagementEntities
    {
    }
}
