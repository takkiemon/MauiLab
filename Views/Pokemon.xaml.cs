using System.Diagnostics;

namespace MauiLab.Views;

public partial class Pokemon : ContentPage
{
	public Pokemon()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Debug.WriteLine("POKEMON!");
    }
}