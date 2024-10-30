namespace MauiLab
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            FolderList.SelectionBackground = Brush.Transparent;
            //FolderList.ItemTemplate = new DocumentItemTemplateSelector();
            FolderList.ExpanderTemplate = App.Current.Resources["DocumentExpanderTemplate"] as DataTemplate;
            Color kleurtje = Color.FromArgb("");
            //FolderList.ItemTapped += FolderListOnItemTapped;
            //FolderList.NodeExpanded += OnNodeExpanded;
        }
    }
}
