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

        private void StatefulContentView_Tapped(object sender, EventArgs e)
        {
            Microsoft.Maui.Controls.VisualStateManager.GoToState((VisualElement)sender, "Selected");
        }

        private void StatefulContentView_Hovered(object sender, EventArgs e)
        {
            Microsoft.Maui.Controls.VisualStateManager.GoToState((VisualElement)sender, "Hovered");
        }

        private void StatefulContentView_HoverExited(object sender, EventArgs e)
        {
            Microsoft.Maui.Controls.VisualStateManager.GoToState((VisualElement)sender, "Normal");
        }
    }
}
