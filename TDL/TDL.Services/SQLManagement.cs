using System.Data.SqlTypes;
using TDL.Repositories;

namespace TDL.Service
{
    public class SQLManagement
    {

        public SQLManagement() { }

        // 1 = Chuỗi cấu hình không tồn tại
        // 2 = Chuỗi cấu hình không phù hợp
        // 0 =  Chuỗi cấu hình hợp lệ

        public int Check_Config(string pcnn, SQLClass sqldt)
        {
            if (string.IsNullOrWhiteSpace(pcnn)) { return 1; }

            sqldt.CreateConnection(pcnn);   // Tạo kết nối
            bool isConnected = sqldt.TestConnection();  // Kiểm tra kết nối

            if (!isConnected) { return 2; }

            return 0;
        }

    }
}
