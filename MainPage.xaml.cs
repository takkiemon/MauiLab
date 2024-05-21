using MauiLab.ViewModel;

namespace MauiLab
{
    public partial class MainPage : ContentPage
    {
        public MainPage(BottomTabbarViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        private BottomTabbarViewModel ViewModel => (BottomTabbarViewModel)BindingContext;
    }

}
