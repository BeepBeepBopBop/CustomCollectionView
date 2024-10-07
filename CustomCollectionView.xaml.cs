using System.Collections;
using UraniumUI.Views;

namespace CustomCollectionView;

public partial class CustomCollectionView : ContentView
{
    private VisualElement? _latestSelectedVisualElement;

    public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CustomCollectionView));
    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
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

        var child = customCollectionView.rootLayout.GetVisualTreeDescendants();
    }

    private void OnRootLayoutChildAdded(object sender, ElementEventArgs e)
    {
        if (e.Element is View view)
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 1,
            };

            PointerGestureRecognizer pointerGestureRecognizer = new PointerGestureRecognizer();

            pointerGestureRecognizer.PointerEntered += OnPointerGestureRecognizePointerEntered;
            pointerGestureRecognizer.PointerExited += OnPointerGestureRecognizePointerExited;
            tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;

            view.GestureRecognizers.Add(tapGestureRecognizer);
            view.GestureRecognizers.Add(pointerGestureRecognizer);
        }
    }

    private void rootLayout_Loaded(object sender, EventArgs e)
    {
        if (SelectedItem != null)
        {
            foreach (var child in rootLayout.Children)
            {
                if (child is VisualElement visualElement)
                {
                    if (visualElement.BindingContext == SelectedItem)
                    {
                        SetSelectedElement(visualElement);
                    }
                    else
                    {
                        VisualStateManager.GoToState(visualElement, "_Normal");
                    }
                }
            }
        }
    }

    private void SetSelectedElement(VisualElement visualElement)
    {
        if (_latestSelectedVisualElement != null)
        {
            VisualStateManager.GoToState(_latestSelectedVisualElement, "_Normal");
        }

        _latestSelectedVisualElement = visualElement;
        VisualStateManager.GoToState(visualElement, "_Selected");
        SelectedItem = visualElement.BindingContext;
    }

    private void OnPointerGestureRecognizePointerExited(object? sender, PointerEventArgs e)
    {
        if (sender is VisualElement visualElement)
        {
            bool isSelected = ((VisualElement)sender).BindingContext == SelectedItem;

            VisualStateManager.GoToState(visualElement, isSelected ? "_Selected" : "_Normal");
        }
    }

    private void OnPointerGestureRecognizePointerEntered(object? sender, PointerEventArgs e)
    {
        bool isSelected = ((VisualElement)sender).BindingContext == SelectedItem;

        if (sender is VisualElement visualElement)
        {
            VisualStateManager.GoToState(visualElement, "_Hovered");
        }
    }

    private void OnTapGestureRecognizerTapped(object? sender, TappedEventArgs e)
    {
        if (sender is VisualElement visualElement)
        {
            SetSelectedElement(visualElement);
        }
    }
}