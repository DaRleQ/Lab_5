using System;
using System.Collections.Generic;

public interface IBlogSubscriber
{
    void Update(string articleTitle);
}

public class Reader : IBlogSubscriber
{
    private string _name;
    public Reader(string name) { _name = name; }

    public void Update(string articleTitle)
    {
        Console.WriteLine($"Користувач {_name} отримав сповіщення: Нова стаття '{articleTitle}'!");
    }
}

public class Blog
{
    private List<IBlogSubscriber> _subscribers = new List<IBlogSubscriber>();

    public void Subscribe(IBlogSubscriber subscriber) => _subscribers.Add(subscriber);

    public void PublishArticle(string title)
    {
        Console.WriteLine($"\n[Блог] Публікація нової статті: {title}");
        foreach (var sub in _subscribers)
            sub.Update(title);
    }
}