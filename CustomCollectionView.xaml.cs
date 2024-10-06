using System.Collections;

namespace CustomCollectionView;

public partial class CustomCollectionView : ContentView
{
    public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CustomCollectionView));
    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        private set => SetValue(ItemTemplateProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(CustomCollectionView));
    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        private set => SetValue(ItemsSourceProperty, value);
    }

    public CustomCollectionView()
    {
        InitializeComponent();
    }
}