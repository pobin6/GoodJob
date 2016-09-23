using System.Data.SQLite;
namespace OperteSql
{
    class OperteSql
    {
        public void Insert()
        {
            SQLiteConnection conn = null;
            string dbPath = "/sql/testData.sql";
            conn = new SQLiteConnection(dbPath);
            conn.Open();
        }
    }
}