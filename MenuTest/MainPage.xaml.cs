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

        private async void OnPopupClicked(object sender, EventArgs e)
        {
            var CurrDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            CurrDate = CurrDate.AddDays(-1);

            var dates = new List<DateTime?>();

            for (int i = 0; i < 10; i++)
            {
                dates.Add(CurrDate);

                CurrDate = new DateTime(CurrDate.Year, CurrDate.Month, 1);
                CurrDate = CurrDate.AddDays(-1);
            }

            dates = dates.OrderByDescending(x => x).ToList();

            var list = new List<PickerItem>();

            foreach (var item in dates)
            {
                list.Add(new PickerItem
                {
                    Value = item,
                    Display = item?.ToString("MMMM yyyy") ?? "No Date"
                });
            }

            var popup = new PickerPopup("Select Statement Date", list);
            var result = await this.ShowPopupAsync<object?>(popup, new PopupOptions
            {
                Shape = null, // Use default shape
            });

            if (result?.Result is DateTime statementDate)
            {
                var msg = new MessagePopup($"You selected: {statementDate.ToString("MMMM yyyy")}");
                await this.ShowPopupAsync(msg, new PopupOptions
                {
                    Shape = null, // Use default shape
                });
            }
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
