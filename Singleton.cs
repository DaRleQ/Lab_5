using System;
using System.Collections.Generic;

public class CacheManager
{
    private static CacheManager _instance;
    private static readonly object _lock = new object();
    private Dictionary<string, string> _cache = new Dictionary<string, string>();

    private CacheManager() { }

    public static CacheManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new CacheManager();
                return _instance;
            }
        }
    }

    public void AddToCache(string key, string value)
    {
        _cache[key] = value;
        Console.WriteLine($"[Cache] Дані збережено: {key} = {value}");
    }

    public string GetFromCache(string key)
    {
        return _cache.ContainsKey(key) ? _cache[key] : "Дані не знайдено";
    }
}