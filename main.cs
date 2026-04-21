using System;
using System.Runtime.Remoting.Messaging;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Тест Singleton
        Console.WriteLine("--- Тест Singleton (Cache) ---");
        CacheManager cache = CacheManager.Instance;
        cache.AddToCache("User_1", "Олексій");
        Console.WriteLine("Отримано з кешу: " + cache.GetFromCache("User_1"));

        // Тест Adapter
        Console.WriteLine("\n--- Тест Adapter (Databases) ---");
        IDatabase db = new MySQLAdapter();
        db.Connect("MainStore");

        IDatabase db2 = new PostgreSQL();
        db2.Connect("AnalyticsDB");

        // Тест Observer
        Console.WriteLine("\n--- Тест Observer (Blog) ---");
        Blog techBlog = new Blog();
        techBlog.Subscribe(new Reader("Іван"));
        techBlog.Subscribe(new Reader("Марія"));
        techBlog.PublishArticle("Топ 10 патернів у C#");

        Console.ReadKey();
    }
}