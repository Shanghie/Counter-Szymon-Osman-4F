using Counter.ViewModels;

namespace Counter.Views;

using Microsoft.Maui.Controls;
public partial class NewCounterPage : ContentPage
{
    private readonly CountersViewModel _vm;

    public NewCounterPage(CountersViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        nameEntry.Text = string.Empty;
    }

    private async void Save_Clicked(object? sender, EventArgs e)
    {
        var name = nameEntry.Text?.Trim();
        if (string.IsNullOrEmpty(name))
        {
            await DisplayAlert("Błąd", "Podaj nazwę licznika.", "OK");
            return;
        }
        _vm.Add(name);
        await Shell.Current.GoToAsync("..");
    }

    private async void Cancel_Clicked(object? sender, EventArgs e)
        => await Shell.Current.GoToAsync("..");
}