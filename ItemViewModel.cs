using CommunityToolkit.Mvvm.ComponentModel;

namespace CustomCollectionView
{
    public partial class ItemViewModel : ObservableObject
    {
        [ObservableProperty]
        string? title;

        public ItemViewModel(string title)
        {
            Title = title;
        }
    }
}
