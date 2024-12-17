using Syncfusion.Maui.ListView;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WindowsSfListViewEventBug;

public partial class MainPage : ContentPage
{
    int count = 0;
    int longPressCount = 0;
    public ObservableCollection<Item> ItemList = new();
    public ObservableCollection<Item> Items
    {
        get { return ItemList; }
        set { ItemList = value; }
    }

    public MainPage()
    {
        InitializeComponent();
        ListViewElement.ItemLongPress += OnItemLongPress;
        Items.Add(new Item { ItemText = "Hello" });
        Items.Add(new Item { ItemText = "Check" });
        Items.Add(new Item { ItemText = "Test" });
        Items.Add(new Item { ItemText = "One Two Three" });
        Items.Add(new Item { ItemText = "Message" });
        Items.Add(new Item { ItemText = "ASDF" });
    }

    private void OnItemLongPress(object? sender, ItemLongPressEventArgs e)
    {
        longPressCount++;
        CounterBtn.Text = $"Longpressed {longPressCount} time(s)";
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

public class Item
{
    public string ItemText { get; set; }
}