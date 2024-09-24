using System.Data;

namespace TDL.Repositories
{
    public abstract class DatabaseAssistant
    {
        #region Methods

        public abstract void CreateConnection(string pConnectionString);

        public abstract object ExecuteScalar(string pQuery);

        public abstract DataTable ExcuteQuery(string pQuery);

        public abstract object ExcuteQuery(string pQuery, out DataTable pDataTable);

        public abstract bool Update(object pDataAdapter, DataRow pDataRow);

        public abstract bool Update(object pDataAdapter, DataRow[] pDataRows);

        public abstract bool Update(object pDataAdapter, DataTable pDataTable);

        public abstract bool TestConnection();

        #endregion


    }
}
