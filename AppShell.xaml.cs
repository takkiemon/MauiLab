using MauiLab.Views;
using System.Diagnostics;

namespace MauiLab
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            CustomInitializer();
        }

        private void OnLabellyClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("labelly is clicked, yo!");
        }

        public void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(Pokemon), typeof(Pokemon));
            Routing.RegisterRoute(nameof(SuperMario), typeof(SuperMario));
            //Routing.RegisterRoute(Routes.Pokemon, new AppRouteFactory<Pokemon>());
        }

        private Tab CreateTab()
        {
            Tab tab = new Tab()
            {
                Title = "tabTitle",
                Route = "pokemon"//,
                //Icon = FontAwesomeIcon.FAClockAlt
            };
            Shell.SetBackgroundColor(tab, Colors.DarkSlateBlue);

            return tab;
        }

        public void CustomInitializer()
        {
            TabBar.Items.Add(CreateTab());
        }
    }

    public static class Routes
    {
        public const string Pokemon = "pokemon";
        public const string MainPage = "mainpage";
        public const string SuperMario = "supermario";
    }

    public class AppRouteFactory<T> : RouteFactory where T : Page, new()
    {
        public override Microsoft.Maui.Controls.Element GetOrCreate()
        {
            return new T();
        }

        public override Microsoft.Maui.Controls.Element GetOrCreate(IServiceProvider servises)
        {
            return GetOrCreate();
        }
    }
}
