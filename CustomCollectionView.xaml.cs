using System.Collections;
using UraniumUI.Views;

namespace CustomCollectionView;

public partial class CustomCollectionView : ContentView
{
    public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CustomCollectionView), propertyChanged: OnItemTemplatePropertyChanged);
    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
    }

    public static readonly BindableProperty ItemTemplate2Property = BindableProperty.Create(nameof(ItemTemplate2), typeof(DataTemplate), typeof(CustomCollectionView));
    public DataTemplate ItemTemplate2
    {
        get => (DataTemplate)GetValue(ItemTemplate2Property);
        set => SetValue(ItemTemplate2Property, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(CustomCollectionView));
    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(int), typeof(CustomCollectionView));
    public int Count
    {
        get => (int)GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(CustomCollectionView), propertyChanged: OnSelectedItemPropertyChanged);

    public object? SelectedItem
    {
        get => (object?)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public CustomCollectionView()
    {
        InitializeComponent();
    }

    private static void OnSelectedItemPropertyChanged(BindableObject bindable, object? oldValue, object newValue)
    {
        var customCollectionView = (CustomCollectionView)bindable;

        if (oldValue != null && oldValue is VisualElement visualElement)
        {
            VisualStateManager.GoToState(visualElement, "_Normal");
        }

        if (newValue is VisualElement visualElement2)
        {
            VisualStateManager.GoToState(visualElement2, "_Selected");
        }
    }

    private static void OnItemTemplatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var customCollectionView = (CustomCollectionView)bindable;

        var dataTemplate = (DataTemplate)newValue;

        var wrapper = new DataTemplate(() =>
        {
            var statefulContentView = new StatefulContentView();
            statefulContentView.Tapped += StatefulContentView_Tapped;
            return statefulContentView;
        });
    }

    private static void StatefulContentView_Tapped(object? sender, EventArgs e)
    {
    }

    private void rootLayout_ChildAdded(object sender, ElementEventArgs e)
    {
        VerticalStackLayout verticalStackLayout;

        if (e.Element is View view)
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 1,
            };
            PointerGestureRecognizer pointerGestureRecognizer = new PointerGestureRecognizer()
            {
            };

            pointerGestureRecognizer.PointerEntered += PointerGestureRecognize_PointerEntered;
            pointerGestureRecognizer.PointerExited += PointerGestureRecognize_PointerExited;
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            view.GestureRecognizers.Add(tapGestureRecognizer);
            view.GestureRecognizers.Add(pointerGestureRecognizer);
        }
    }

    private void PointerGestureRecognize_PointerExited(object? sender, PointerEventArgs e)
    {
        if (sender is VisualElement visualElement)
        {
            bool isSelected = ((VisualElement)sender).BindingContext == SelectedItem;

            VisualStateManager.GoToState(visualElement, isSelected ? "_Selected" : "_Normal");
        }
    }

    private void PointerGestureRecognize_PointerEntered(object? sender, PointerEventArgs e)
    {
        bool isSelected = ((VisualElement)sender).BindingContext == SelectedItem;

        if (sender is VisualElement visualElement)
        {
            VisualStateManager.GoToState(visualElement, "_Hovered");
        }
    }

    private void TapGestureRecognizer_Tapped(object? sender, TappedEventArgs e)
    {
        if (sender is VisualElement visualElement)
        {
            VisualStateManager.GoToState(visualElement, "_Selected");
            SelectedItem = visualElement.BindingContext;
        }
    }

    protected override void OnChildAdded(Element child)
    {
        base.OnChildAdded(child);
    }
}