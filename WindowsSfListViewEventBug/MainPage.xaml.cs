using Syncfusion.Maui.ListView;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WindowsSfListViewEventBug;

public partial class MainPage : ContentPage
{
    int longPressCount = 0;
    public ObservableCollection<string> Items { get; set; } = [];

    public MainPage()
    {
        InitializeComponent();
        for (int i = 0; i < 6; i++)
        {
            Items.Add($"Item {i}");
        }
        ListViewElement.ItemsSource = Items;
        ListViewElement.ItemLongPress += OnItemLongPress;
    }

    private void OnItemLongPress(object? sender, ItemLongPressEventArgs e)
    {
        longPressCount++;
        ResultLabel.Text = $"Longpressed {longPressCount} time(s)";
    }
}

public class Item
{
    public string ItemText { get; set; }
}