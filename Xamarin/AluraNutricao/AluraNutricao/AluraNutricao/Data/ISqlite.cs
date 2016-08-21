using SQLite.Net;

namespace AluraNutricao.Data
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
