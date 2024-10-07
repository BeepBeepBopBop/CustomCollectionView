This is a basic custom implementation of a MAUI "CollectionView" control. 

It provides the very basic features of displaying elements vertically based on a DataTemplate, selecting elements, and setting their appearance upon hovering and selection... minus the randomness and nightmarish visual states-related issues and the inevitable urge to destroy your computer with bare hands and say bad things about the family of people you have never met :(

** Usage **

Very straightforward: the CustomCollectionView offers 3 bindable properties: SelectedItem, ItemsSource, ItemTemplate, similar to a regular CollectionView.
In order to customize the appearance of your items, we have to use VisualStates. 

The issue is that those are utterly broken and can not be relied one, so we have to use custom ones: "_Normal", "_Selected", "_Hovered".

You can see in the MainPage.xaml file how those are used and you can do the same thing to style your DataTemplate root element. 

** Disclaimer **

This is just a very quick and basic implementation, and intentionnaly so. It is simply intended to be an entry-point for anybody that needs a functional basic CollectionView control on Windows (or other platforms but I personally needed Windows in priority). You will probably have to modify the code to make it work for your use case, for example if you want multiple selection, or arranging elements horizontally...
