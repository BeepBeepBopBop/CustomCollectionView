using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CustomCollectionView
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ItemViewModel> items = new ObservableCollection<ItemViewModel>();

        [ObservableProperty]
        ItemViewModel? selectedItem;

        [RelayCommand]
        public void AddNewItem()
        {
            Items.Add(new ItemViewModel($"Item {Items.Count + 1}"));
        }
    }
}
