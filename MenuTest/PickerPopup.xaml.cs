using CommunityToolkit.Maui.Views;
using System.Windows.Input;

namespace MenuTest;

public partial class PickerPopup : Popup<object?>
{
    public PickerPopup(string title, List<PickerItem> items)
    {
        BindingContext = this;

        Title = title;

        Items = items;

        InitializeComponent();
    }

    public string Title { get; set; }

    private List<PickerItem> _Items = new List<PickerItem>();
    public List<PickerItem> Items
    {
        get => _Items;
        set
        {
            if (_Items != value)
            {
                _Items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    public ICommand ItemTappedCommand => new Command<PickerItem>(async item =>
    {
        if (item?.Value != null)
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await CloseAsync(item.Value, cts.Token);
        }
    });

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        await CloseAsync(null, cts.Token); // Indicates cancellation
    }

}
