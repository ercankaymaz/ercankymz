using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

[TemplatePart(Name = "PART_DragThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_PropertyItemsControl", Type = typeof(PropertyItemsControl))]
[StyleTypedProperty(Property = "PropertyContainerStyle", StyleTargetType = typeof(PropertyItemBase))]
public class PropertyGrid : Control, ISupportInitialize, IPropertyContainer, INotifyPropertyChanged
{
	private const string PART_DragThumb = "PART_DragThumb";

	internal const string PART_PropertyItemsControl = "PART_PropertyItemsControl";

	private static readonly ComponentResourceKey SelectedObjectAdvancedOptionsMenuKey;

	private Thumb _dragThumb;

	private bool _hasPendingSelectedObjectChanged;

	private int _initializationCount;

	private ContainerHelperBase _containerHelper;

	private WeakEventListener<NotifyCollectionChangedEventArgs> _propertyDefinitionsListener;

	private WeakEventListener<NotifyCollectionChangedEventArgs> _editorDefinitionsListener;

	public static readonly DependencyProperty AdvancedOptionsMenuProperty;

	public static readonly DependencyProperty AutoGeneratePropertiesProperty;

	public static readonly DependencyProperty CategoryGroupHeaderTemplateProperty;

	public static readonly DependencyProperty ShowDescriptionByTooltipProperty;

	public static readonly DependencyProperty ShowSummaryProperty;

	public static readonly DependencyProperty EditorDefinitionsProperty;

	public static readonly DependencyProperty FilterProperty;

	public static readonly DependencyProperty FilterWatermarkProperty;

	public static readonly DependencyProperty HideInheritedPropertiesProperty;

	public static readonly DependencyProperty IsCategorizedProperty;

	public static readonly DependencyProperty IsMiscCategoryLabelHiddenProperty;

	public static readonly DependencyProperty IsScrollingToTopAfterRefreshProperty;

	public static readonly DependencyProperty IsVirtualizingProperty;

	public static readonly DependencyProperty NameColumnWidthProperty;

	public static readonly DependencyProperty PropertyNameLeftPaddingProperty;

	public static readonly DependencyProperty PropertyNameTextWrappingProperty;

	public static readonly DependencyProperty PropertyContainerStyleProperty;

	public static readonly DependencyProperty PropertyDefinitionsProperty;

	public static readonly DependencyProperty IsReadOnlyProperty;

	public static readonly DependencyProperty SelectedObjectProperty;

	public static readonly DependencyProperty SelectedObjectTypeProperty;

	public static readonly DependencyProperty SelectedObjectTypeNameProperty;

	public static readonly DependencyProperty SelectedObjectNameProperty;

	private static readonly DependencyPropertyKey SelectedPropertyItemPropertyKey;

	public static readonly DependencyProperty SelectedPropertyItemProperty;

	public static readonly DependencyProperty SelectedPropertyProperty;

	public static readonly DependencyProperty ShowAdvancedOptionsProperty;

	public static readonly DependencyProperty ShowHorizontalScrollBarProperty;

	public static readonly DependencyProperty ShowPreviewProperty;

	public static readonly DependencyProperty ShowSearchBoxProperty;

	public static readonly DependencyProperty ShowSortOptionsProperty;

	public static readonly DependencyProperty ShowTitleProperty;

	public static readonly DependencyProperty UpdateTextBoxSourceOnEnterKeyProperty;

	public static readonly RoutedEvent PropertyValueChangedEvent;

	public static readonly RoutedEvent SelectedPropertyItemChangedEvent;

	public static readonly RoutedEvent SelectedObjectChangedEvent;

	public static readonly RoutedEvent PreparePropertyItemEvent;

	public static readonly RoutedEvent ClearPropertyItemEvent;

	public static readonly RoutedEvent PropertiesGeneratedEvent;

	public ContextMenu AdvancedOptionsMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(AdvancedOptionsMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedOptionsMenuProperty, (object)value);
		}
	}

	public bool AutoGenerateProperties
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoGeneratePropertiesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoGeneratePropertiesProperty, (object)value);
		}
	}

	public DataTemplate CategoryGroupHeaderTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(CategoryGroupHeaderTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CategoryGroupHeaderTemplateProperty, (object)value);
		}
	}

	public bool ShowDescriptionByTooltip
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowDescriptionByTooltipProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowDescriptionByTooltipProperty, (object)value);
		}
	}

	public bool ShowSummary
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSummaryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSummaryProperty, (object)value);
		}
	}

	public EditorDefinitionCollection EditorDefinitions
	{
		get
		{
			return (EditorDefinitionCollection)((DependencyObject)this).GetValue(EditorDefinitionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditorDefinitionsProperty, (object)value);
		}
	}

	public string Filter
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FilterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FilterProperty, (object)value);
		}
	}

	public string FilterWatermark
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FilterWatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FilterWatermarkProperty, (object)value);
		}
	}

	public bool HideInheritedProperties
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideInheritedPropertiesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideInheritedPropertiesProperty, (object)value);
		}
	}

	public bool IsCategorized
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCategorizedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCategorizedProperty, (object)value);
		}
	}

	public bool IsMiscCategoryLabelHidden
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMiscCategoryLabelHiddenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsMiscCategoryLabelHiddenProperty, (object)value);
		}
	}

	public bool IsScrollingToTopAfterRefresh
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsScrollingToTopAfterRefreshProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsScrollingToTopAfterRefreshProperty, (object)value);
		}
	}

	public bool IsVirtualizing
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsVirtualizingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsVirtualizingProperty, (object)value);
		}
	}

	public double NameColumnWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(NameColumnWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NameColumnWidthProperty, (object)value);
		}
	}

	public double PropertyNameLeftPadding
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PropertyNameLeftPaddingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertyNameLeftPaddingProperty, (object)value);
		}
	}

	public TextWrapping PropertyNameTextWrapping
	{
		get
		{
			return (TextWrapping)((DependencyObject)this).GetValue(PropertyNameTextWrappingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertyNameTextWrappingProperty, (object)value);
		}
	}

	public IList Properties
	{
		get
		{
			if (_containerHelper == null)
			{
				return null;
			}
			return _containerHelper.Properties;
		}
	}

	public Style PropertyContainerStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(PropertyContainerStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertyContainerStyleProperty, (object)value);
		}
	}

	public PropertyDefinitionCollection PropertyDefinitions
	{
		get
		{
			return (PropertyDefinitionCollection)((DependencyObject)this).GetValue(PropertyDefinitionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertyDefinitionsProperty, (object)value);
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsReadOnlyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsReadOnlyProperty, (object)value);
		}
	}

	public object SelectedObject
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectedObjectProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedObjectProperty, value);
		}
	}

	public Type SelectedObjectType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(SelectedObjectTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedObjectTypeProperty, (object)value);
		}
	}

	public string SelectedObjectTypeName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedObjectTypeNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedObjectTypeNameProperty, (object)value);
		}
	}

	public string SelectedObjectName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedObjectNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedObjectNameProperty, (object)value);
		}
	}

	public PropertyItemBase SelectedPropertyItem
	{
		get
		{
			return (PropertyItemBase)((DependencyObject)this).GetValue(SelectedPropertyItemProperty);
		}
		internal set
		{
			((DependencyObject)this).SetValue(SelectedPropertyItemPropertyKey, (object)value);
		}
	}

	public object SelectedProperty
	{
		get
		{
			return ((DependencyObject)this).GetValue(SelectedPropertyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPropertyProperty, value);
		}
	}

	public bool ShowAdvancedOptions
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowAdvancedOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowAdvancedOptionsProperty, (object)value);
		}
	}

	public bool ShowHorizontalScrollBar
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowHorizontalScrollBarProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowHorizontalScrollBarProperty, (object)value);
		}
	}

	public bool ShowPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowPreviewProperty, (object)value);
		}
	}

	public bool ShowSearchBox
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSearchBoxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSearchBoxProperty, (object)value);
		}
	}

	public bool ShowSortOptions
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSortOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSortOptionsProperty, (object)value);
		}
	}

	public bool ShowTitle
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTitleProperty, (object)value);
		}
	}

	public bool UpdateTextBoxSourceOnEnterKey
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(UpdateTextBoxSourceOnEnterKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UpdateTextBoxSourceOnEnterKeyProperty, (object)value);
		}
	}

	FilterInfo IPropertyContainer.FilterInfo => new FilterInfo
	{
		Predicate = CreateFilter(Filter),
		InputString = Filter
	};

	ContainerHelperBase IPropertyContainer.ContainerHelper => _containerHelper;

	bool IPropertyContainer.IsSortedAlphabetically
	{
		get
		{
			CategoryPropertyOrderAttribute categoryPropertyOrderAttribute = TypeDescriptor.GetAttributes(SelectedObject).OfType<CategoryPropertyOrderAttribute>().FirstOrDefault();
			if (IsCategorized && categoryPropertyOrderAttribute != null && categoryPropertyOrderAttribute.CategoryPropertyOrder == CategoryPropertyOrderEnum.Declaration)
			{
				return false;
			}
			return true;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public event PropertyValueChangedEventHandler PropertyValueChanged
	{
		add
		{
			AddHandler(PropertyValueChangedEvent, value);
		}
		remove
		{
			RemoveHandler(PropertyValueChangedEvent, value);
		}
	}

	public event RoutedPropertyChangedEventHandler<PropertyItemBase> SelectedPropertyItemChanged
	{
		add
		{
			AddHandler(SelectedPropertyItemChangedEvent, value);
		}
		remove
		{
			RemoveHandler(SelectedPropertyItemChangedEvent, value);
		}
	}

	public event RoutedPropertyChangedEventHandler<object> SelectedObjectChanged
	{
		add
		{
			AddHandler(SelectedObjectChangedEvent, value);
		}
		remove
		{
			RemoveHandler(SelectedObjectChangedEvent, value);
		}
	}

	public event IsPropertyBrowsableHandler IsPropertyBrowsable;

	public event PropertyItemEventHandler PreparePropertyItem
	{
		add
		{
			AddHandler(PreparePropertyItemEvent, value);
		}
		remove
		{
			RemoveHandler(PreparePropertyItemEvent, value);
		}
	}

	public event PropertyItemEventHandler ClearPropertyItem
	{
		add
		{
			AddHandler(ClearPropertyItemEvent, value);
		}
		remove
		{
			RemoveHandler(ClearPropertyItemEvent, value);
		}
	}

	public event RoutedEventHandler PropertiesGenerated
	{
		add
		{
			AddHandler(PropertiesGeneratedEvent, value);
		}
		remove
		{
			RemoveHandler(PropertiesGeneratedEvent, value);
		}
	}

	private static void OnEditorDefinitionsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnEditorDefinitionsChanged((EditorDefinitionCollection)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (EditorDefinitionCollection)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnEditorDefinitionsChanged(EditorDefinitionCollection oldValue, EditorDefinitionCollection newValue)
	{
		if (oldValue != null)
		{
			CollectionChangedEventManager.RemoveListener((INotifyCollectionChanged)oldValue, (IWeakEventListener)(object)_editorDefinitionsListener);
		}
		if (newValue != null)
		{
			CollectionChangedEventManager.AddListener((INotifyCollectionChanged)newValue, (IWeakEventListener)(object)_editorDefinitionsListener);
		}
		this.Notify(this.PropertyChanged, () => EditorDefinitions);
	}

	private void OnEditorDefinitionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (_containerHelper != null)
		{
			_containerHelper.NotifyEditorDefinitionsCollectionChanged();
		}
	}

	private static void OnFilterChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnFilterChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnFilterChanged(string oldValue, string newValue)
	{
		this.Notify(this.PropertyChanged, () => ((IPropertyContainer)this).FilterInfo);
	}

	private static void OnIsCategorizedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnIsCategorizedChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsCategorizedChanged(bool oldValue, bool newValue)
	{
		UpdateThumb();
	}

	private static void OnIsVirtualizingChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnIsVirtualizingChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsVirtualizingChanged(bool oldValue, bool newValue)
	{
		UpdateContainerHelper();
	}

	private static void OnNameColumnWidthChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnNameColumnWidthChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnNameColumnWidthChanged(double oldValue, double newValue)
	{
		if (_dragThumb != null)
		{
			((TranslateTransform)_dragThumb.RenderTransform).X = newValue;
		}
	}

	private static void OnPropertyContainerStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnPropertyContainerStyleChanged((Style)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Style)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnPropertyContainerStyleChanged(Style oldValue, Style newValue)
	{
	}

	private static void OnPropertyDefinitionsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnPropertyDefinitionsChanged((PropertyDefinitionCollection)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (PropertyDefinitionCollection)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnPropertyDefinitionsChanged(PropertyDefinitionCollection oldValue, PropertyDefinitionCollection newValue)
	{
		if (oldValue != null)
		{
			CollectionChangedEventManager.RemoveListener((INotifyCollectionChanged)oldValue, (IWeakEventListener)(object)_propertyDefinitionsListener);
		}
		if (newValue != null)
		{
			CollectionChangedEventManager.AddListener((INotifyCollectionChanged)newValue, (IWeakEventListener)(object)_propertyDefinitionsListener);
		}
		this.Notify(this.PropertyChanged, () => PropertyDefinitions);
	}

	private void OnPropertyDefinitionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (_containerHelper != null)
		{
			_containerHelper.NotifyPropertyDefinitionsCollectionChanged();
		}
		if (base.IsLoaded)
		{
			UpdateContainerHelper();
		}
	}

	private static void OnIsReadOnlyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnIsReadOnlyChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsReadOnlyChanged(bool oldValue, bool newValue)
	{
		UpdateContainerHelper();
	}

	private static void OnSelectedObjectChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnSelectedObjectChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnSelectedObjectChanged(object oldValue, object newValue)
	{
		if (_initializationCount != 0)
		{
			_hasPendingSelectedObjectChanged = true;
			return;
		}
		UpdateContainerHelper();
		RaiseEvent(new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, SelectedObjectChangedEvent));
	}

	private static void OnSelectedObjectTypeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnSelectedObjectTypeChanged((Type)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Type)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnSelectedObjectTypeChanged(Type oldValue, Type newValue)
	{
	}

	private static object OnCoerceSelectedObjectName(DependencyObject o, object baseValue)
	{
		if (o is PropertyGrid propertyGrid && propertyGrid.SelectedObject is FrameworkElement && string.IsNullOrEmpty((string)baseValue))
		{
			return "<no name>";
		}
		return baseValue;
	}

	private static void OnSelectedObjectNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.SelectedObjectNameChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void SelectedObjectNameChanged(string oldValue, string newValue)
	{
	}

	private static void OnSelectedPropertyItemChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyGrid propertyGrid)
		{
			propertyGrid.OnSelectedPropertyItemChanged((PropertyItemBase)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (PropertyItemBase)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnSelectedPropertyItemChanged(PropertyItemBase oldValue, PropertyItemBase newValue)
	{
		if (oldValue != null)
		{
			oldValue.IsSelected = false;
		}
		if (newValue != null)
		{
			newValue.IsSelected = true;
		}
		SelectedProperty = ((newValue != null && _containerHelper != null) ? _containerHelper.ItemFromContainer(newValue) : null);
		RaiseEvent(new RoutedPropertyChangedEventArgs<PropertyItemBase>(oldValue, newValue, SelectedPropertyItemChangedEvent));
	}

	private static void OnSelectedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is PropertyGrid propertyGrid)
		{
			propertyGrid.OnSelectedPropertyChanged(((DependencyPropertyChangedEventArgs)(ref args)).OldValue, ((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
		}
	}

	private void OnSelectedPropertyChanged(object oldValue, object newValue)
	{
		if (_containerHelper != null && !object.Equals(_containerHelper.ItemFromContainer(SelectedPropertyItem), newValue))
		{
			SelectedPropertyItem = _containerHelper.ContainerFromItem(newValue);
		}
	}

	static PropertyGrid()
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Expected O, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_04a0: Expected O, but got Unknown
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Expected O, but got Unknown
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Expected O, but got Unknown
		SelectedObjectAdvancedOptionsMenuKey = new ComponentResourceKey(typeof(PropertyGrid), "SelectedObjectAdvancedOptionsMenu");
		AdvancedOptionsMenuProperty = DependencyProperty.Register("AdvancedOptionsMenu", typeof(ContextMenu), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		AutoGeneratePropertiesProperty = DependencyProperty.Register("AutoGenerateProperties", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		CategoryGroupHeaderTemplateProperty = DependencyProperty.Register("CategoryGroupHeaderTemplate", typeof(DataTemplate), typeof(PropertyGrid));
		ShowDescriptionByTooltipProperty = DependencyProperty.Register("ShowDescriptionByTooltip", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		ShowSummaryProperty = DependencyProperty.Register("ShowSummary", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		EditorDefinitionsProperty = DependencyProperty.Register("EditorDefinitions", typeof(EditorDefinitionCollection), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnEditorDefinitionsChanged)));
		FilterProperty = DependencyProperty.Register("Filter", typeof(string), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnFilterChanged)));
		FilterWatermarkProperty = DependencyProperty.Register("FilterWatermark", typeof(string), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Search"));
		HideInheritedPropertiesProperty = DependencyProperty.Register("HideInheritedProperties", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		IsCategorizedProperty = DependencyProperty.Register("IsCategorized", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnIsCategorizedChanged)));
		IsMiscCategoryLabelHiddenProperty = DependencyProperty.Register("IsMiscCategoryLabelHidden", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		IsScrollingToTopAfterRefreshProperty = DependencyProperty.Register("IsScrollingToTopAfterRefresh", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		IsVirtualizingProperty = DependencyProperty.Register("IsVirtualizing", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsVirtualizingChanged)));
		NameColumnWidthProperty = DependencyProperty.Register("NameColumnWidth", typeof(double), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(150.0, new PropertyChangedCallback(OnNameColumnWidthChanged)));
		PropertyNameLeftPaddingProperty = DependencyProperty.Register("PropertyNameLeftPadding", typeof(double), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)15.0));
		PropertyNameTextWrappingProperty = DependencyProperty.Register("PropertyNameTextWrapping", typeof(TextWrapping), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)TextWrapping.NoWrap));
		PropertyContainerStyleProperty = DependencyProperty.Register("PropertyContainerStyle", typeof(Style), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnPropertyContainerStyleChanged)));
		PropertyDefinitionsProperty = DependencyProperty.Register("PropertyDefinitions", typeof(PropertyDefinitionCollection), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnPropertyDefinitionsChanged)));
		IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsReadOnlyChanged)));
		SelectedObjectProperty = DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnSelectedObjectChanged)));
		SelectedObjectTypeProperty = DependencyProperty.Register("SelectedObjectType", typeof(Type), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnSelectedObjectTypeChanged)));
		SelectedObjectTypeNameProperty = DependencyProperty.Register("SelectedObjectTypeName", typeof(string), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)string.Empty));
		SelectedObjectNameProperty = DependencyProperty.Register("SelectedObjectName", typeof(string), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(string.Empty, new PropertyChangedCallback(OnSelectedObjectNameChanged), new CoerceValueCallback(OnCoerceSelectedObjectName)));
		SelectedPropertyItemPropertyKey = DependencyProperty.RegisterReadOnly("SelectedPropertyItem", typeof(PropertyItemBase), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnSelectedPropertyItemChanged)));
		SelectedPropertyItemProperty = SelectedPropertyItemPropertyKey.DependencyProperty;
		SelectedPropertyProperty = DependencyProperty.Register("SelectedProperty", typeof(object), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnSelectedPropertyChanged)));
		ShowAdvancedOptionsProperty = DependencyProperty.Register("ShowAdvancedOptions", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		ShowHorizontalScrollBarProperty = DependencyProperty.Register("ShowHorizontalScrollBar", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		ShowPreviewProperty = DependencyProperty.Register("ShowPreview", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		ShowSearchBoxProperty = DependencyProperty.Register("ShowSearchBox", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		ShowSortOptionsProperty = DependencyProperty.Register("ShowSortOptions", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		ShowTitleProperty = DependencyProperty.Register("ShowTitle", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		UpdateTextBoxSourceOnEnterKeyProperty = DependencyProperty.Register("UpdateTextBoxSourceOnEnterKey", typeof(bool), typeof(PropertyGrid), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		PropertyValueChangedEvent = EventManager.RegisterRoutedEvent("PropertyValueChanged", RoutingStrategy.Bubble, typeof(PropertyValueChangedEventHandler), typeof(PropertyGrid));
		SelectedPropertyItemChangedEvent = EventManager.RegisterRoutedEvent("SelectedPropertyItemChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<PropertyItemBase>), typeof(PropertyGrid));
		SelectedObjectChangedEvent = EventManager.RegisterRoutedEvent("SelectedObjectChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(PropertyGrid));
		PreparePropertyItemEvent = EventManager.RegisterRoutedEvent("PreparePropertyItem", RoutingStrategy.Bubble, typeof(PropertyItemEventHandler), typeof(PropertyGrid));
		ClearPropertyItemEvent = EventManager.RegisterRoutedEvent("ClearPropertyItem", RoutingStrategy.Bubble, typeof(PropertyItemEventHandler), typeof(PropertyGrid));
		PropertiesGeneratedEvent = EventManager.RegisterRoutedEvent("PropertiesGenerated", RoutingStrategy.Bubble, typeof(EventHandler), typeof(PropertyGrid));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyGrid), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PropertyGrid)));
	}

	public PropertyGrid()
	{
		_propertyDefinitionsListener = new WeakEventListener<NotifyCollectionChangedEventArgs>(OnPropertyDefinitionsCollectionChanged);
		_editorDefinitionsListener = new WeakEventListener<NotifyCollectionChangedEventArgs>(OnEditorDefinitionsCollectionChanged);
		UpdateContainerHelper();
		((DependencyObject)this).SetCurrentValue(EditorDefinitionsProperty, (object)new EditorDefinitionCollection());
		PropertyDefinitions = new PropertyDefinitionCollection();
		PropertyValueChanged += PropertyGrid_PropertyValueChanged;
		AddHandler(PropertyItemBase.ItemSelectionChangedEvent, new RoutedEventHandler(OnItemSelectionChanged));
		AddHandler(PropertyItemsControl.PreparePropertyItemEvent, new PropertyItemEventHandler(OnPreparePropertyItemInternal));
		AddHandler(PropertyItemsControl.ClearPropertyItemEvent, new PropertyItemEventHandler(OnClearPropertyItemInternal));
		base.CommandBindings.Add(new CommandBinding(PropertyGridCommands.ClearFilter, ClearFilter, CanClearFilter));
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_dragThumb != null)
		{
			_dragThumb.DragDelta -= DragThumb_DragDelta;
			_dragThumb.MouseWheel -= DragThumb_MouseWheel;
		}
		_dragThumb = GetTemplateChild("PART_DragThumb") as Thumb;
		if (_dragThumb != null)
		{
			_dragThumb.DragDelta += DragThumb_DragDelta;
			_dragThumb.MouseWheel += DragThumb_MouseWheel;
		}
		if (_containerHelper != null)
		{
			_containerHelper.ChildrenItemsControl = GetTemplateChild("PART_PropertyItemsControl") as PropertyItemsControl;
		}
		TranslateTransform translateTransform = new TranslateTransform();
		translateTransform.X = NameColumnWidth;
		if (_dragThumb != null)
		{
			_dragThumb.RenderTransform = translateTransform;
		}
		UpdateThumb();
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		TextBox textBox = e.OriginalSource as TextBox;
		if (SelectedPropertyItem != null && (int)e.Key == 6 && UpdateTextBoxSourceOnEnterKey && textBox != null && !textBox.AcceptsReturn)
		{
			textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
		}
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		base.OnPropertyChanged(e);
		if (ReflectionHelper.IsPublicInstanceProperty(((object)this).GetType(), ((DependencyPropertyChangedEventArgs)(ref e)).Property.Name))
		{
			this.Notify(this.PropertyChanged, ((DependencyPropertyChangedEventArgs)(ref e)).Property.Name);
		}
	}

	private void OnItemSelectionChanged(object sender, RoutedEventArgs args)
	{
		PropertyItemBase propertyItemBase = (PropertyItemBase)args.OriginalSource;
		if (propertyItemBase.IsSelected)
		{
			SelectedPropertyItem = propertyItemBase;
		}
		else if (propertyItemBase == SelectedPropertyItem)
		{
			SelectedPropertyItem = null;
		}
	}

	private void OnPreparePropertyItemInternal(object sender, PropertyItemEventArgs args)
	{
		if (_containerHelper != null)
		{
			_containerHelper.PrepareChildrenPropertyItem(args.PropertyItem, args.Item);
		}
		args.Handled = true;
	}

	private void OnClearPropertyItemInternal(object sender, PropertyItemEventArgs args)
	{
		if (_containerHelper != null)
		{
			_containerHelper.ClearChildrenPropertyItem(args.PropertyItem, args.Item);
		}
		args.Handled = true;
	}

	private void DragThumb_DragDelta(object sender, DragDeltaEventArgs e)
	{
		NameColumnWidth = Math.Min(Math.Max(base.ActualWidth * 0.1, NameColumnWidth + e.HorizontalChange), base.ActualWidth * 0.9);
	}

	private void DragThumb_MouseWheel(object sender, MouseWheelEventArgs e)
	{
		ScrollToPosition(GetScrollPosition() - (double)e.Delta * 0.4);
	}

	private void PropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		if (e.OriginalSource is PropertyItem propertyItem)
		{
			if (propertyItem.WillRefreshPropertyGrid)
			{
				UpdateContainerHelper();
			}
			PropertyItem propertyItem2 = propertyItem.ParentNode as PropertyItem;
			while (propertyItem2 != null && propertyItem2.IsExpandable)
			{
				RebuildPropertyItemEditor(propertyItem2);
				propertyItem2 = propertyItem2.ParentNode as PropertyItem;
			}
		}
	}

	private void ClearFilter(object sender, ExecutedRoutedEventArgs e)
	{
		Filter = string.Empty;
	}

	private void CanClearFilter(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = !string.IsNullOrEmpty(Filter);
	}

	public double GetScrollPosition()
	{
		return GetScrollViewer()?.VerticalOffset ?? 0.0;
	}

	public void ScrollToPosition(double position)
	{
		GetScrollViewer()?.ScrollToVerticalOffset(position);
	}

	public void ScrollToTop()
	{
		GetScrollViewer()?.ScrollToTop();
	}

	public void ScrollToBottom()
	{
		GetScrollViewer()?.ScrollToBottom();
	}

	public void CollapseAllProperties()
	{
		if (_containerHelper != null)
		{
			_containerHelper.SetPropertiesExpansion(isExpanded: false);
		}
	}

	public void ExpandAllProperties()
	{
		if (_containerHelper != null)
		{
			_containerHelper.SetPropertiesExpansion(isExpanded: true);
		}
	}

	public void ExpandProperty(string propertyName)
	{
		if (_containerHelper != null)
		{
			_containerHelper.SetPropertiesExpansion(propertyName, isExpanded: true);
		}
	}

	public void CollapseProperty(string propertyName)
	{
		if (_containerHelper != null)
		{
			_containerHelper.SetPropertiesExpansion(propertyName, isExpanded: false);
		}
	}

	private ScrollViewer GetScrollViewer()
	{
		if (_containerHelper != null && _containerHelper.ChildrenItemsControl != null)
		{
			return TreeHelper.FindChild<ScrollViewer>((DependencyObject)(object)_containerHelper.ChildrenItemsControl);
		}
		return null;
	}

	private void RebuildPropertyItemEditor(PropertyItem propertyItem)
	{
		propertyItem?.RebuildEditor();
	}

	private void UpdateContainerHelper()
	{
		if (_containerHelper != null)
		{
			_ = _containerHelper.ChildrenItemsControl;
		}
		ObjectContainerHelper objectContainerHelper = new ObjectContainerHelper(this, SelectedObject);
		objectContainerHelper.ObjectsGenerated += ObjectContainerHelper_ObjectsGenerated;
		objectContainerHelper.GenerateProperties();
	}

	private void SetContainerHelper(ContainerHelperBase containerHelper)
	{
		if (_containerHelper != null)
		{
			_containerHelper.ClearHelper();
		}
		_containerHelper = containerHelper;
	}

	private void FinalizeUpdateContainerHelper(ItemsControl childrenItemsControl)
	{
		if (_containerHelper != null)
		{
			_containerHelper.ChildrenItemsControl = childrenItemsControl;
		}
		if (IsScrollingToTopAfterRefresh)
		{
			ScrollToTop();
		}
		this.Notify(this.PropertyChanged, () => Properties);
	}

	private void UpdateThumb()
	{
		if (_dragThumb != null)
		{
			if (IsCategorized)
			{
				_dragThumb.Margin = new Thickness(6.0, 0.0, 0.0, 0.0);
			}
			else
			{
				_dragThumb.Margin = new Thickness(-1.0, 0.0, 0.0, 0.0);
			}
		}
	}

	protected virtual Predicate<object> CreateFilter(string filter)
	{
		return null;
	}

	public void Update()
	{
		if (_containerHelper != null)
		{
			_containerHelper.UpdateValuesFromSource();
		}
	}

	private void ObjectContainerHelper_ObjectsGenerated(object sender, EventArgs e)
	{
		if (sender is ObjectContainerHelperBase objectContainerHelperBase)
		{
			objectContainerHelperBase.ObjectsGenerated -= ObjectContainerHelper_ObjectsGenerated;
			SetContainerHelper(objectContainerHelperBase);
			FinalizeUpdateContainerHelper(objectContainerHelperBase.ChildrenItemsControl);
			RaiseEvent(new RoutedEventArgs(PropertiesGeneratedEvent, this));
		}
	}

	public static void AddPreparePropertyItemHandler(UIElement element, PropertyItemEventHandler handler)
	{
		element.AddHandler(PreparePropertyItemEvent, handler);
	}

	public static void RemovePreparePropertyItemHandler(UIElement element, PropertyItemEventHandler handler)
	{
		element.RemoveHandler(PreparePropertyItemEvent, handler);
	}

	internal static void RaisePreparePropertyItemEvent(UIElement source, PropertyItemBase propertyItem, object item)
	{
		source.RaiseEvent(new PropertyItemEventArgs(PreparePropertyItemEvent, source, propertyItem, item));
	}

	public static void AddClearPropertyItemHandler(UIElement element, PropertyItemEventHandler handler)
	{
		element.AddHandler(ClearPropertyItemEvent, handler);
	}

	public static void RemoveClearPropertyItemHandler(UIElement element, PropertyItemEventHandler handler)
	{
		element.RemoveHandler(ClearPropertyItemEvent, handler);
	}

	internal static void RaiseClearPropertyItemEvent(UIElement source, PropertyItemBase propertyItem, object item)
	{
		source.RaiseEvent(new PropertyItemEventArgs(ClearPropertyItemEvent, source, propertyItem, item));
	}

	public override void BeginInit()
	{
		base.BeginInit();
		_initializationCount++;
	}

	public override void EndInit()
	{
		base.EndInit();
		if (--_initializationCount == 0)
		{
			if (_hasPendingSelectedObjectChanged)
			{
				UpdateContainerHelper();
				_hasPendingSelectedObjectChanged = false;
			}
			if (_containerHelper != null)
			{
				_containerHelper.OnEndInit();
			}
		}
	}

	bool? IPropertyContainer.IsPropertyVisible(PropertyDescriptor pd)
	{
		IsPropertyBrowsableHandler isPropertyBrowsableHandler = this.IsPropertyBrowsable;
		if (isPropertyBrowsableHandler != null)
		{
			IsPropertyBrowsableArgs isPropertyBrowsableArgs = new IsPropertyBrowsableArgs(pd);
			isPropertyBrowsableHandler(this, isPropertyBrowsableArgs);
			return isPropertyBrowsableArgs.IsBrowsable;
		}
		return null;
	}
}
