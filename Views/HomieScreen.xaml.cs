using System.Diagnostics;

namespace MauiLab.Views;

public partial class HomieScreen : ContentView
{
    int count = 0;

    public HomieScreen()
    {
        Debug.WriteLine("checkis eyo waddup");
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}