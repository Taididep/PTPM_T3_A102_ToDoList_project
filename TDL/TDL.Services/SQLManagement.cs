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

        public int Check_Config(string pcnn)
        {
            if (string.IsNullOrWhiteSpace(pcnn)) { return 1; }

            SQLClass sqldt = new SQLClass();
            sqldt.CreateConnection(pcnn);
            bool isConnected = sqldt.TestConnection();

            if (!isConnected) { return 2; }

            return 0;
        }


    }
}
