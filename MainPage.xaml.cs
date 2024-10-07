namespace CustomCollectionView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var mainViewModel = new MainViewModel();

            for (int i =0; i < 10; i++)
            {
                mainViewModel.AddNewItem();
            }
            
            mainViewModel.SelectedItem = mainViewModel.Items.First();

            BindingContext = mainViewModel;
        }
    }
}
