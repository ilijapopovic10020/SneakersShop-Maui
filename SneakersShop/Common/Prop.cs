using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Common
{
    public class Prop<T> : INotifyPropertyChanged
    {
        private T? value;
        private string? error;
        private Action? onValueChange;

        public Action OnValueChange
        {
            set
            {
                onValueChange = value;
            }
        }

        public T? Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged();
                onValueChange?.Invoke();
            }
        }

        public bool HasError => !string.IsNullOrEmpty(error);

        public string? Error
        {
            get => error;
            set
            {
                error = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasError));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
