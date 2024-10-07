namespace CustomCollectionView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var mainViewModel = new MainViewModel();
            mainViewModel.Conversations.Add(new ConversationViewModel("Barambibol"));
            mainViewModel.Conversations.Add(new ConversationViewModel("Wakatepe"));
            mainViewModel.Conversations.Add(new ConversationViewModel("Baboune"));

            mainViewModel.SelectedConversation = mainViewModel.Conversations.First();

            BindingContext = mainViewModel;
        }
    }
}
