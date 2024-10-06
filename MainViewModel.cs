using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionView
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ConversationViewModel> conversations = new ObservableCollection<ConversationViewModel>();
    }

    public partial class ConversationViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        public ConversationViewModel(string title)
        {
            Title = title;
        }
    }
}
