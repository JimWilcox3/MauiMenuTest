using CommunityToolkit.Maui.Views;

namespace MenuTest;

public partial class TestMenu : Popup<string>
{
    public Command ScanQRCodeCommand { get; private set; }
    public Command PrintLabelsCommand { get; private set; }
    public Command AddItemCommand { get; private set; }
    public Command AddSaleCommand { get; private set; }

    public TestMenu()
    {
        InitializeComponent();

        ScanQRCodeCommand = new Command(() => CloseWithResult("scanqrcode"));
        PrintLabelsCommand = new Command(() => CloseWithResult("printlabels"));
        AddItemCommand = new Command(() => CloseWithResult("additem"));
        AddSaleCommand = new Command(() => CloseWithResult("setsale"));

        BindingContext = this; // ? BindingContext AFTER commands are ready
    }

    private async void CloseWithResult(string result)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        await CloseAsync(result, cts.Token);
    }
}
