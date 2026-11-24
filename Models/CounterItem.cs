using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Counter.Models;

public class CounterItem : INotifyPropertyChanged
{
    private string _name = string.Empty;
    private int _value;

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name
    {
        get => _name;
        set { if (_name != value) { _name = value; OnPropertyChanged(); } }
    }

    public int Value
    {
        get => _value;
        set { if (_value != value) { _value = value; OnPropertyChanged(); } }
    }

    public void Increment() => Value++;
    public void Decrement() => Value--;

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
