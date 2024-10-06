namespace CustomCollectionView;

public partial class CustomCollectionView : ContentView
{
    public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CustomCollectionView));
    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        private set => SetValue(ItemTemplateProperty, value);
    }


    public CustomCollectionView()
    {
        InitializeComponent();
    }
}