using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_AvailableColors", Type = typeof(ListBox))]
[TemplatePart(Name = "PART_StandardColors", Type = typeof(ListBox))]
[TemplatePart(Name = "PART_RecentColors", Type = typeof(ListBox))]
[TemplatePart(Name = "PART_ColorPickerToggleButton", Type = typeof(ToggleButton))]
[TemplatePart(Name = "PART_ColorPickerPalettePopup", Type = typeof(Popup))]
public class ColorPicker : Control
{
	private const string PART_AvailableColors = "PART_AvailableColors";

	private const string PART_StandardColors = "PART_StandardColors";

	private const string PART_RecentColors = "PART_RecentColors";

	private const string PART_ColorPickerToggleButton = "PART_ColorPickerToggleButton";

	private const string PART_ColorPickerPalettePopup = "PART_ColorPickerPalettePopup";

	private ListBox _availableColors;

	private ListBox _standardColors;

	private ListBox _recentColors;

	private ToggleButton _toggleButton;

	private Popup _popup;

	private Color? _initialColor;

	private bool _selectionChanged;

	public static readonly DependencyProperty AdvancedTabHeaderProperty;

	public static readonly DependencyProperty AvailableColorsProperty;

	public static readonly DependencyProperty AvailableColorsSortingModeProperty;

	public static readonly DependencyProperty AvailableColorsHeaderProperty;

	public static readonly DependencyProperty ButtonStyleProperty;

	public static readonly DependencyProperty DisplayColorAndNameProperty;

	public static readonly DependencyProperty DisplayColorTooltipProperty;

	public static readonly DependencyProperty ColorModeProperty;

	public static readonly DependencyProperty DropDownBackgroundProperty;

	public static readonly DependencyProperty DropDownBorderBrushProperty;

	public static readonly DependencyProperty DropDownBorderThicknessProperty;

	public static readonly DependencyProperty HeaderBackgroundProperty;

	public static readonly DependencyProperty HeaderForegroundProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty MaxDropDownWidthProperty;

	public static readonly DependencyProperty RecentColorsProperty;

	public static readonly DependencyProperty RecentColorsHeaderProperty;

	public static readonly DependencyProperty SelectedColorProperty;

	public static readonly DependencyProperty SelectedColorTextProperty;

	public static readonly DependencyProperty ShowTabHeadersProperty;

	public static readonly DependencyProperty ShowAvailableColorsProperty;

	public static readonly DependencyProperty ShowRecentColorsProperty;

	public static readonly DependencyProperty ShowStandardColorsProperty;

	public static readonly DependencyProperty ShowDropDownButtonProperty;

	public static readonly DependencyProperty StandardTabHeaderProperty;

	public static readonly DependencyProperty StandardColorsProperty;

	public static readonly DependencyProperty StandardColorsHeaderProperty;

	public static readonly DependencyProperty TabBackgroundProperty;

	public static readonly DependencyProperty TabForegroundProperty;

	public static readonly DependencyProperty UsingAlphaChannelProperty;

	public static readonly RoutedEvent SelectedColorChangedEvent;

	public static readonly RoutedEvent OpenedEvent;

	public static readonly RoutedEvent ClosedEvent;

	public string AdvancedTabHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AdvancedTabHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedTabHeaderProperty, (object)value);
		}
	}

	public ObservableCollection<ColorItem> AvailableColors
	{
		get
		{
			return (ObservableCollection<ColorItem>)((DependencyObject)this).GetValue(AvailableColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableColorsProperty, (object)value);
		}
	}

	public ColorSortingMode AvailableColorsSortingMode
	{
		get
		{
			return (ColorSortingMode)((DependencyObject)this).GetValue(AvailableColorsSortingModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableColorsSortingModeProperty, (object)value);
		}
	}

	public string AvailableColorsHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(AvailableColorsHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableColorsHeaderProperty, (object)value);
		}
	}

	public Style ButtonStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(ButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonStyleProperty, (object)value);
		}
	}

	public bool DisplayColorAndName
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DisplayColorAndNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayColorAndNameProperty, (object)value);
		}
	}

	public bool DisplayColorTooltip
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DisplayColorTooltipProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DisplayColorTooltipProperty, (object)value);
		}
	}

	public ColorMode ColorMode
	{
		get
		{
			return (ColorMode)((DependencyObject)this).GetValue(ColorModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ColorModeProperty, (object)value);
		}
	}

	public Brush DropDownBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(DropDownBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownBackgroundProperty, (object)value);
		}
	}

	public Brush DropDownBorderBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(DropDownBorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownBorderBrushProperty, (object)value);
		}
	}

	public Thickness DropDownBorderThickness
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(DropDownBorderThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownBorderThicknessProperty, (object)value);
		}
	}

	public Brush HeaderBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(HeaderBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderBackgroundProperty, (object)value);
		}
	}

	public Brush HeaderForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(HeaderForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderForegroundProperty, (object)value);
		}
	}

	public bool IsOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsOpenProperty, (object)value);
		}
	}

	public double MaxDropDownWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxDropDownWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxDropDownWidthProperty, (object)value);
		}
	}

	public ObservableCollection<ColorItem> RecentColors
	{
		get
		{
			return (ObservableCollection<ColorItem>)((DependencyObject)this).GetValue(RecentColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RecentColorsProperty, (object)value);
		}
	}

	public string RecentColorsHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(RecentColorsHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RecentColorsHeaderProperty, (object)value);
		}
	}

	public Color? SelectedColor
	{
		get
		{
			return (Color?)((DependencyObject)this).GetValue(SelectedColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedColorProperty, (object)value);
		}
	}

	public string SelectedColorText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SelectedColorTextProperty);
		}
		protected set
		{
			((DependencyObject)this).SetValue(SelectedColorTextProperty, (object)value);
		}
	}

	public bool ShowTabHeaders
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTabHeadersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTabHeadersProperty, (object)value);
		}
	}

	public bool ShowAvailableColors
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowAvailableColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowAvailableColorsProperty, (object)value);
		}
	}

	public bool ShowRecentColors
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowRecentColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowRecentColorsProperty, (object)value);
		}
	}

	public bool ShowStandardColors
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowStandardColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowStandardColorsProperty, (object)value);
		}
	}

	public bool ShowDropDownButton
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowDropDownButtonProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowDropDownButtonProperty, (object)value);
		}
	}

	public string StandardTabHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(StandardTabHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StandardTabHeaderProperty, (object)value);
		}
	}

	public ObservableCollection<ColorItem> StandardColors
	{
		get
		{
			return (ObservableCollection<ColorItem>)((DependencyObject)this).GetValue(StandardColorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StandardColorsProperty, (object)value);
		}
	}

	public string StandardColorsHeader
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(StandardColorsHeaderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StandardColorsHeaderProperty, (object)value);
		}
	}

	public Brush TabBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TabBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TabBackgroundProperty, (object)value);
		}
	}

	public Brush TabForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(TabForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TabForegroundProperty, (object)value);
		}
	}

	public bool UsingAlphaChannel
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(UsingAlphaChannelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UsingAlphaChannelProperty, (object)value);
		}
	}

	public event RoutedPropertyChangedEventHandler<Color?> SelectedColorChanged
	{
		add
		{
			AddHandler(SelectedColorChangedEvent, value);
		}
		remove
		{
			RemoveHandler(SelectedColorChangedEvent, value);
		}
	}

	public event RoutedEventHandler Opened
	{
		add
		{
			AddHandler(OpenedEvent, value);
		}
		remove
		{
			RemoveHandler(OpenedEvent, value);
		}
	}

	public event RoutedEventHandler Closed
	{
		add
		{
			AddHandler(ClosedEvent, value);
		}
		remove
		{
			RemoveHandler(ClosedEvent, value);
		}
	}

	private static void OnAvailableColorsSortingModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ColorPicker)(object)d)?.OnAvailableColorsSortingModeChanged((ColorSortingMode)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (ColorSortingMode)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private void OnAvailableColorsSortingModeChanged(ColorSortingMode oldValue, ColorSortingMode newValue)
	{
		ListCollectionView listCollectionView = (ListCollectionView)(object)CollectionViewSource.GetDefaultView(AvailableColors);
		if (listCollectionView != null)
		{
			listCollectionView.CustomSort = ((AvailableColorsSortingMode == ColorSortingMode.HueSaturationBrightness) ? new ColorSorter() : null);
		}
	}

	private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ColorPicker)(object)d)?.OnIsOpenChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			_initialColor = SelectedColor;
		}
		RoutedEventArgs e = new RoutedEventArgs(newValue ? OpenedEvent : ClosedEvent, this);
		RaiseEvent(e);
	}

	private static void OnMaxDropDownWidthChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorPicker colorPicker)
		{
			colorPicker.OnMaxDropDownWidthChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnMaxDropDownWidthChanged(double oldValue, double newValue)
	{
	}

	private static void OnSelectedColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ColorPicker)(object)d)?.OnSelectedColorChanged((Color?)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Color?)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private void OnSelectedColorChanged(Color? oldValue, Color? newValue)
	{
		SelectedColorText = GetFormatedColorString(newValue);
		RoutedPropertyChangedEventArgs<Color?> e = new RoutedPropertyChangedEventArgs<Color?>(oldValue, newValue);
		e.RoutedEvent = SelectedColorChangedEvent;
		RaiseEvent(e);
	}

	private static void OnUsingAlphaChannelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ColorPicker)(object)d)?.OnUsingAlphaChannelChanged();
	}

	private void OnUsingAlphaChannelChanged()
	{
		SelectedColorText = GetFormatedColorString(SelectedColor);
	}

	static ColorPicker()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		AdvancedTabHeaderProperty = DependencyProperty.Register("AdvancedTabHeader", typeof(string), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Advanced"));
		AvailableColorsProperty = DependencyProperty.Register("AvailableColors", typeof(ObservableCollection<ColorItem>), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)CreateAvailableColors()));
		AvailableColorsSortingModeProperty = DependencyProperty.Register("AvailableColorsSortingMode", typeof(ColorSortingMode), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata(ColorSortingMode.Alphabetical, new PropertyChangedCallback(OnAvailableColorsSortingModeChanged)));
		AvailableColorsHeaderProperty = DependencyProperty.Register("AvailableColorsHeader", typeof(string), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Available Colors"));
		ButtonStyleProperty = DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(ColorPicker));
		DisplayColorAndNameProperty = DependencyProperty.Register("DisplayColorAndName", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		DisplayColorTooltipProperty = DependencyProperty.Register("DisplayColorTooltip", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		ColorModeProperty = DependencyProperty.Register("ColorMode", typeof(ColorMode), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)ColorMode.ColorPalette));
		DropDownBackgroundProperty = DependencyProperty.Register("DropDownBackground", typeof(Brush), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		DropDownBorderBrushProperty = DependencyProperty.Register("DropDownBorderBrush", typeof(Brush), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		DropDownBorderThicknessProperty = DependencyProperty.Register("DropDownBorderThickness", typeof(Thickness), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		HeaderBackgroundProperty = DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		HeaderForegroundProperty = DependencyProperty.Register("HeaderForeground", typeof(Brush), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)Brushes.Black));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsOpenChanged)));
		MaxDropDownWidthProperty = DependencyProperty.Register("MaxDropDownWidth", typeof(double), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)214.0));
		RecentColorsProperty = DependencyProperty.Register("RecentColors", typeof(ObservableCollection<ColorItem>), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		RecentColorsHeaderProperty = DependencyProperty.Register("RecentColorsHeader", typeof(string), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Recent Colors"));
		SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color?), typeof(ColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSelectedColorPropertyChanged)));
		SelectedColorTextProperty = DependencyProperty.Register("SelectedColorText", typeof(string), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)""));
		ShowTabHeadersProperty = DependencyProperty.Register("ShowTabHeaders", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		ShowAvailableColorsProperty = DependencyProperty.Register("ShowAvailableColors", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		ShowRecentColorsProperty = DependencyProperty.Register("ShowRecentColors", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		ShowStandardColorsProperty = DependencyProperty.Register("ShowStandardColors", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		ShowDropDownButtonProperty = DependencyProperty.Register("ShowDropDownButton", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		StandardTabHeaderProperty = DependencyProperty.Register("StandardTabHeader", typeof(string), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Standard"));
		StandardColorsProperty = DependencyProperty.Register("StandardColors", typeof(ObservableCollection<ColorItem>), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)CreateStandardColors()));
		StandardColorsHeaderProperty = DependencyProperty.Register("StandardColorsHeader", typeof(string), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Standard Colors"));
		TabBackgroundProperty = DependencyProperty.Register("TabBackground", typeof(Brush), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		TabForegroundProperty = DependencyProperty.Register("TabForeground", typeof(Brush), typeof(ColorPicker), (PropertyMetadata)(object)new UIPropertyMetadata((object)Brushes.Black));
		UsingAlphaChannelProperty = DependencyProperty.Register("UsingAlphaChannel", typeof(bool), typeof(ColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnUsingAlphaChannelPropertyChanged)));
		SelectedColorChangedEvent = EventManager.RegisterRoutedEvent("SelectedColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color?>), typeof(ColorPicker));
		OpenedEvent = EventManager.RegisterRoutedEvent("OpenedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorPicker));
		ClosedEvent = EventManager.RegisterRoutedEvent("ClosedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorPicker));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ColorPicker)));
	}

	public ColorPicker()
	{
		((DependencyObject)this).SetCurrentValue(RecentColorsProperty, (object)new ObservableCollection<ColorItem>());
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, OnMouseDownOutsideCapturedElement);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_availableColors != null)
		{
			_availableColors.SelectionChanged -= Color_SelectionChanged;
		}
		_availableColors = GetTemplateChild("PART_AvailableColors") as ListBox;
		if (_availableColors != null)
		{
			_availableColors.SelectionChanged += Color_SelectionChanged;
		}
		if (_standardColors != null)
		{
			_standardColors.SelectionChanged -= Color_SelectionChanged;
		}
		_standardColors = GetTemplateChild("PART_StandardColors") as ListBox;
		if (_standardColors != null)
		{
			_standardColors.SelectionChanged += Color_SelectionChanged;
		}
		if (_recentColors != null)
		{
			_recentColors.SelectionChanged -= Color_SelectionChanged;
		}
		_recentColors = GetTemplateChild("PART_RecentColors") as ListBox;
		if (_recentColors != null)
		{
			_recentColors.SelectionChanged += Color_SelectionChanged;
		}
		if (_popup != null)
		{
			_popup.Opened -= Popup_Opened;
		}
		_popup = GetTemplateChild("PART_ColorPickerPalettePopup") as Popup;
		if (_popup != null)
		{
			_popup.Opened += Popup_Opened;
		}
		_toggleButton = base.Template.FindName("PART_ColorPickerToggleButton", this) as ToggleButton;
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		base.OnMouseUp(e);
		if (_selectionChanged)
		{
			CloseColorPicker(isFocusOnColorPicker: true);
			_selectionChanged = false;
		}
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		if (!IsOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsOpen = true;
				e.Handled = true;
			}
		}
		else if (KeyboardUtilities.IsKeyModifyingPopupState(e))
		{
			CloseColorPicker(isFocusOnColorPicker: true);
			e.Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			SelectedColor = _initialColor;
			CloseColorPicker(isFocusOnColorPicker: true);
			e.Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseColorPicker(isFocusOnColorPicker: true);
	}

	private void Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		ListBox listBox = (ListBox)sender;
		if (e.AddedItems.Count > 0)
		{
			ColorItem colorItem = (ColorItem)e.AddedItems[0];
			SelectedColor = colorItem.Color;
			if (!string.IsNullOrEmpty(colorItem.Name))
			{
				SelectedColorText = colorItem.Name;
			}
			UpdateRecentColors(colorItem);
			_selectionChanged = true;
			listBox.SelectedIndex = -1;
		}
	}

	private void Popup_Opened(object sender, EventArgs e)
	{
		if (_availableColors != null && ShowAvailableColors)
		{
			FocusOnListBoxItem(_availableColors);
		}
		else if (_standardColors != null && ShowStandardColors)
		{
			FocusOnListBoxItem(_standardColors);
		}
		else if (_recentColors != null && ShowRecentColors)
		{
			FocusOnListBoxItem(_recentColors);
		}
	}

	private void FocusOnListBoxItem(ListBox listBox)
	{
		ListBoxItem listBoxItem = (ListBoxItem)(object)listBox.ItemContainerGenerator.ContainerFromItem(listBox.SelectedItem);
		if (listBoxItem == null && listBox.Items.Count > 0)
		{
			listBoxItem = (ListBoxItem)(object)listBox.ItemContainerGenerator.ContainerFromItem(listBox.Items[0]);
		}
		listBoxItem?.Focus();
	}

	private void CloseColorPicker(bool isFocusOnColorPicker)
	{
		if (IsOpen)
		{
			IsOpen = false;
		}
		ReleaseMouseCapture();
		if (isFocusOnColorPicker && _toggleButton != null)
		{
			_toggleButton.Focus();
		}
		UpdateRecentColors(new ColorItem(SelectedColor, SelectedColorText));
	}

	private void UpdateRecentColors(ColorItem colorItem)
	{
		if (!RecentColors.Contains(colorItem))
		{
			RecentColors.Add(colorItem);
		}
		if (RecentColors.Count > 10)
		{
			RecentColors.RemoveAt(0);
		}
	}

	private string GetFormatedColorString(Color? colorToFormat)
	{
		if (!colorToFormat.HasValue || !colorToFormat.HasValue)
		{
			return string.Empty;
		}
		return ColorUtilities.FormatColorString(colorToFormat.Value.GetColorName(), UsingAlphaChannel);
	}

	private static ObservableCollection<ColorItem> CreateStandardColors()
	{
		return new ObservableCollection<ColorItem>
		{
			new ColorItem(Colors.Transparent, "Transparent"),
			new ColorItem(Colors.White, "White"),
			new ColorItem(Colors.Gray, "Gray"),
			new ColorItem(Colors.Black, "Black"),
			new ColorItem(Colors.Red, "Red"),
			new ColorItem(Colors.Green, "Green"),
			new ColorItem(Colors.Blue, "Blue"),
			new ColorItem(Colors.Yellow, "Yellow"),
			new ColorItem(Colors.Orange, "Orange"),
			new ColorItem(Colors.Purple, "Purple")
		};
	}

	private static ObservableCollection<ColorItem> CreateAvailableColors()
	{
		ObservableCollection<ColorItem> observableCollection = new ObservableCollection<ColorItem>();
		foreach (KeyValuePair<string, Color> knownColor in ColorUtilities.KnownColors)
		{
			if (!string.Equals(knownColor.Key, "Transparent"))
			{
				ColorItem item = new ColorItem(knownColor.Value, knownColor.Key);
				if (!observableCollection.Contains(item))
				{
					observableCollection.Add(item);
				}
			}
		}
		return observableCollection;
	}
}
