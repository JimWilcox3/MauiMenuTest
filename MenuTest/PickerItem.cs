using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MenuTest
{
    public class PickerItem : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public override bool Equals(object? obj)
        {
            if (obj is not PickerItem other) return false;
            return Equals(Value, other.Value);
        }

        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        private object? _Value;
        public object? Value
        {
            get => _Value;
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    OnPropertyChanged();
                }
            }
        }

        private string? _Display;
        public string? Display
        {
            get => _Display;
            set
            {
                if (_Display != value)
                {
                    _Display = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
