namespace CustomCollectionView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
