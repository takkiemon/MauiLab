namespace MauiLab
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            //TargetBadge.HeightRequest = 100;
            //TargetBadge.WidthRequest = 100;
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //TargetBadge.HeightRequest = 100;
            //TargetBadge.WidthRequest = 100;
            count++;

            TargetBadge.Rotation += 15;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
