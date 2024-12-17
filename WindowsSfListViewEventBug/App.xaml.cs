namespace WindowsSfListViewEventBug;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzYzMDQ4OEAzMjM4MmUzMDJlMzBPUG1tVGFsbHhlVjBnS0ZSZ3lHcWFBQTdhc285aC91N3B6YXpNYmx0eCtJPQ==");
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}