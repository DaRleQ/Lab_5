using System;

public interface IDatabase
{
    void Connect(string dbName);
}

// Сторонній клас для MySQL
public class MySQLServer
{
    public void OpenMySQLConnection(string connectionString)
    {
        Console.WriteLine($"MySQL: Підключено до {connectionString}");
    }
}

// Адаптер для MySQL
public class MySQLAdapter : IDatabase
{
    private MySQLServer _mySQLServer = new MySQLServer();

    public void Connect(string dbName)
    {
        _mySQLServer.OpenMySQLConnection($"jdbc:mysql://localhost/{dbName}");
    }
}

// Клас для PostgreSQL
public class PostgreSQL : IDatabase
{
    public void Connect(string dbName)
    {
        Console.WriteLine($"PostgreSQL: Підключено до бази {dbName}");
    }
}