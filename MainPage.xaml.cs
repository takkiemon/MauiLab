using Intents;
using System.Collections.ObjectModel;

namespace MauiLab
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<String> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();
            InitItems();

            FolderList.SelectionBackground = Brush.Transparent;
            //FolderList.ItemTemplate = new DocumentItemTemplateSelector();
            FolderList.ExpanderTemplate = App.Current.Resources["DocumentExpanderTemplate"] as DataTemplate;
            Color kleurtje = Color.FromArgb("");
            //FolderList.ItemTapped += FolderListOnItemTapped;
            //FolderList.NodeExpanded += OnNodeExpanded;
        }

        public ObservableCollection<String> CreateItemListMain(char[] characters = null, string[] strings = null)
        {
            var items = new ObservableCollection<String>();
            items.Add(
            return items;
        }

        public ObservableCollection<String> CreateItemListFromCharacters(char[] characters, int amountOfEntries = 3)
        {
            var items = new ObservableCollection<String>();
            for (int i = 0; i < amountOfEntries; 
            return items;
        }

        public void InitItems()
        {
            Items = new ObservableCollection<String>();
            Items.Add("asdf");
        }
    }
}
