using System.Collections.ObjectModel;
using System.Text.Json;
using Counter.Models;
using Microsoft.Maui.Storage;

namespace Counter.ViewModels;

public class CountersViewModel
{
    private readonly string _path = Path.Combine(FileSystem.AppDataDirectory, "counters.json");

    public ObservableCollection<CounterItem> Counters { get; } = new();

    public CountersViewModel() => Load();

    public void Add(string name)
    {
        var item = new CounterItem { Name = name };
        item.PropertyChanged += (_, _) => Save();
        Counters.Add(item);
        Save();
    }

    public void Remove(CounterItem item)
    {
        Counters.Remove(item);
        Save();
    }

    private void Load()
    {
        try
        {
            if (!File.Exists(_path)) return;
            var items = JsonSerializer.Deserialize<List<CounterItem>>(File.ReadAllText(_path));
            if (items == null) return;
            foreach (var item in items)
            {
                item.PropertyChanged += (_, _) => Save();
                Counters.Add(item);
            }
        }
        catch { /* uszkodzony plik - zaczynamy od pustej listy */ }
    }

    private void Save()
    {
        try { File.WriteAllText(_path, JsonSerializer.Serialize(Counters.ToList())); }
        catch { }
    }
}
