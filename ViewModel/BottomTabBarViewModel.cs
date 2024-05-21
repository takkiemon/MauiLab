using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiLab.ViewModel
{
    public class BottomTabbarViewModel : INotifyPropertyChanged
    {
        private int _selectedViewModelIndex = 0;

        public HomePageViewModel HomePageViewModel { get; }

        public BottomTabbarViewModel()
        {
            HomePageViewModel = new HomePageViewModel();
        }

        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set
            {
                _selectedViewModelIndex = value;
                RaisePropertyChanged(nameof(_selectedViewModelIndex));
            }
        }

        public bool IsTabVisible { get; set; } = true;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(
            ref T field,
            T newValue,
            [CallerMemberName] string propertyName = default
        )
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            field = newValue;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
