using System.Data.SqlClient;

namespace DatabaseBackupAndRestore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.;Initial Catalog=MyDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Database database = new Database(connection);
            BackupManager manager = new BackupManager();

            // Выполняем запрос
            database.ExecuteQuery("INSERT INTO Users (Name) VALUES ('John')");

            // Делаем бэкап
            manager.BackupDatabase(database);

            // Выполняем другой запрос
            database.ExecuteQuery("DELETE FROM Users WHERE Name = 'John'");

            // Восстанавливаем базу данных
            manager.RestoreDatabase(database);

            // Проверка, что данные восстановлены
            Console.WriteLine("Database restored.");
        }
    }

    // Класс Memento
    class DatabaseMemento
    {
        public readonly string ConnectionString;

        public DatabaseMemento(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }

    // Класс Originator
    class Database
    {
        private SqlConnection connection;

        public Database(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void ExecuteQuery(string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Метод для создания хранителя (memento)
        public DatabaseMemento CreateMemento()
        {
            return new DatabaseMemento(connection.ConnectionString);
        }

        // Метод для восстановления состояния из хранителя
        public void RestoreFromMemento(DatabaseMemento memento)
        {
            connection = new SqlConnection(memento.ConnectionString);
            connection.Open();
        }
    }

    // Класс Caretaker
    class BackupManager
    {
        private DatabaseMemento backup;

        public void BackupDatabase(Database database)
        {
            backup = database.CreateMemento();
        }

        public void RestoreDatabase(Database database)
        {
            if (backup != null)
            {
                database.RestoreFromMemento(backup);
            }
        }
    }
}
