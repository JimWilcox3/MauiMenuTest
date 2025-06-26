using CommunityToolkit.Maui.Views;

namespace MenuTest;

public partial class MessagePopup : Popup
{
    public string Message { get; set; }

    public Command OKCommand { get; private set; }

    public MessagePopup(string message)
    {
        InitializeComponent();

        Message = message;

        OKCommand = new Command(async () =>
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await CloseAsync(cts.Token);
        });

        BindingContext = this; // ? BindingContext AFTER commands are ready
    }

}
