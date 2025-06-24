using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;

namespace MenuTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            var popup = new TestMenu();
            //this.ShowPopup(popup);

            var result = await this.ShowPopupAsync<string>(popup, new PopupOptions
            {
                Shape = null,
                Shadow = null,
                PageOverlayColor = Colors.Transparent,
            });

            if (result.Result is string stringResult)
            {
                    switch (stringResult)
                    {
                        case "scanqrcode":
                            //ScanQRCode();
                            break;

                        case "printlabels":
                            //PrintLabels();
                            break;

                        case "additem":
                            //AddItem();
                            break;

                        case "setsale":
                            //SetGroupSales();
                            break;

                    }
            }
        }
    }
}
