using Counter.Models;
using Counter.ViewModels;
using Microsoft.Maui.Controls;

namespace Counter.Views;

public partial class AllCountersPage : ContentPage
{
    private readonly CountersViewModel _vm;

    public AllCountersPage(CountersViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = vm;
    }

    private async void Add_Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(NewCounterPage));

    private void Plus_Clicked(object? sender, EventArgs e)
    {
        if ((sender as Button)?.BindingContext is CounterItem c) c.Increment();
    }

    private void Minus_Clicked(object? sender, EventArgs e)
    {
        if ((sender as Button)?.BindingContext is CounterItem c) c.Decrement();
    }

    private void Delete_Clicked(object? sender, EventArgs e)
    {
        if ((sender as Button)?.BindingContext is CounterItem c) _vm.Remove(c);
    }
}