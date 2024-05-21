using MauiLab.ViewModel;

namespace MauiLab
{
    public partial class App : Application
    {
        public App(BottomTabbarViewModel viewModel)
        {
            InitializeComponent();

            Current!.UserAppTheme = AppTheme.Dark;

            MainPage = new MainPage(viewModel);
        }
    }
}
