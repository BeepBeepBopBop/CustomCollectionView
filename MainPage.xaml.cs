namespace CustomCollectionView
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();

            mainViewModel.Conversations.Add(new ConversationViewModel("Barambibol"));
            mainViewModel.Conversations.Add(new ConversationViewModel("Wakatepe"));
            mainViewModel.Conversations.Add(new ConversationViewModel("Baboune"));
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
