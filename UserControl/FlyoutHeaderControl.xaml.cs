namespace TimeZoneApp.UserControl;

public partial class FlyoutHeaderControl : ContentView
{
    public FlyoutHeaderControl()
    {
        InitializeComponent();

        if (App.UserInfo == null) return;
        LabelUserName.Text = $"Welcome, {App.UserInfo.UserName}!";
    }
}