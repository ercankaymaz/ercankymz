using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

public class RichTextBoxFormatBar : Control, IRichTextBoxFormatBar
{
	private ComboBox _cmbFontFamilies;

	private ComboBox _cmbFontSizes;

	private ColorPicker _cmbFontBackgroundColor;

	private ColorPicker _cmbFontColor;

	private ToggleButton _btnNumbers;

	private ToggleButton _btnBullets;

	private ToggleButton _btnBold;

	private ToggleButton _btnItalic;

	private ToggleButton _btnUnderline;

	private ToggleButton _btnAlignLeft;

	private ToggleButton _btnAlignCenter;

	private ToggleButton _btnAlignRight;

	private Thumb _dragWidget;

	private bool _waitingForMouseOver;

	public static readonly DependencyProperty TargetProperty;

	public static double[] FontSizes => new double[54]
	{
		3.0, 4.0, 5.0, 6.0, 6.5, 7.0, 7.5, 8.0, 8.5, 9.0,
		9.5, 10.0, 10.5, 11.0, 11.5, 12.0, 12.5, 13.0, 13.5, 14.0,
		15.0, 16.0, 17.0, 18.0, 19.0, 20.0, 22.0, 24.0, 26.0, 28.0,
		30.0, 32.0, 34.0, 36.0, 38.0, 40.0, 44.0, 48.0, 52.0, 56.0,
		60.0, 64.0, 68.0, 72.0, 76.0, 80.0, 88.0, 96.0, 104.0, 112.0,
		120.0, 128.0, 136.0, 144.0
	};

	public System.Windows.Controls.RichTextBox Target
	{
		get
		{
			return (System.Windows.Controls.RichTextBox)((DependencyObject)this).GetValue(TargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetProperty, (object)value);
		}
	}

	public bool PreventDisplayFadeOut
	{
		get
		{
			if ((_cmbFontFamilies == null || !_cmbFontFamilies.IsDropDownOpen) && (_cmbFontSizes == null || !_cmbFontSizes.IsDropDownOpen) && (_cmbFontBackgroundColor == null || !_cmbFontBackgroundColor.IsOpen) && (_cmbFontColor == null || !_cmbFontColor.IsOpen))
			{
				return _waitingForMouseOver;
			}
			return true;
		}
	}

	static RichTextBoxFormatBar()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		TargetProperty = DependencyProperty.Register("Target", typeof(System.Windows.Controls.RichTextBox), typeof(RichTextBoxFormatBar), new PropertyMetadata((object)null, new PropertyChangedCallback(OnRichTextBoxPropertyChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(RichTextBoxFormatBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(RichTextBoxFormatBar)));
	}

	private void FontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Count != 0)
		{
			FontFamily fontFamily = FontUtilities.GetFontFamily((string)e.AddedItems[0]);
			ApplyPropertyValueToSelectedText(TextElement.FontFamilyProperty, fontFamily);
			_waitingForMouseOver = true;
		}
	}

	private void FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Count != 0)
		{
			ApplyPropertyValueToSelectedText(TextElement.FontSizeProperty, e.AddedItems[0]);
			_waitingForMouseOver = true;
		}
	}

	private void FontColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
	{
		Color? newValue = e.NewValue;
		ApplyPropertyValueToSelectedText(TextElement.ForegroundProperty, newValue.HasValue ? new SolidColorBrush(newValue.Value) : null);
		_waitingForMouseOver = true;
	}

	private void FontBackgroundColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
	{
		Color? newValue = e.NewValue;
		ApplyPropertyValueToSelectedText(TextElement.BackgroundProperty, newValue.HasValue ? new SolidColorBrush(newValue.Value) : null);
		_waitingForMouseOver = true;
	}

	private void Bullets_Clicked(object sender, RoutedEventArgs e)
	{
		if (BothSelectionListsAreChecked() && _btnNumbers != null)
		{
			_btnNumbers.IsChecked = false;
		}
	}

	private void Numbers_Clicked(object sender, RoutedEventArgs e)
	{
		if (BothSelectionListsAreChecked() && _btnBullets != null)
		{
			_btnBullets.IsChecked = false;
		}
	}

	private void DragWidget_DragDelta(object sender, DragDeltaEventArgs e)
	{
		ProcessMove(e);
	}

	protected override void OnMouseEnter(MouseEventArgs e)
	{
		base.OnMouseEnter(e);
		_waitingForMouseOver = false;
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_dragWidget != null)
		{
			_dragWidget.DragDelta -= DragWidget_DragDelta;
		}
		if (_cmbFontFamilies != null)
		{
			_cmbFontFamilies.SelectionChanged -= FontFamily_SelectionChanged;
		}
		if (_cmbFontSizes != null)
		{
			_cmbFontSizes.SelectionChanged -= FontSize_SelectionChanged;
		}
		if (_btnBullets != null)
		{
			_btnBullets.Click -= Bullets_Clicked;
		}
		if (_btnNumbers != null)
		{
			_btnNumbers.Click -= Numbers_Clicked;
		}
		if (_cmbFontBackgroundColor != null)
		{
			_cmbFontBackgroundColor.SelectedColorChanged -= FontBackgroundColor_SelectedColorChanged;
		}
		if (_cmbFontColor != null)
		{
			_cmbFontColor.SelectedColorChanged -= FontColor_SelectedColorChanged;
		}
		GetTemplateComponent(ref _cmbFontFamilies, "_cmbFontFamilies");
		GetTemplateComponent(ref _cmbFontSizes, "_cmbFontSizes");
		GetTemplateComponent(ref _cmbFontBackgroundColor, "_cmbFontBackgroundColor");
		GetTemplateComponent(ref _cmbFontColor, "_cmbFontColor");
		GetTemplateComponent(ref _btnNumbers, "_btnNumbers");
		GetTemplateComponent(ref _btnBullets, "_btnBullets");
		GetTemplateComponent(ref _btnBold, "_btnBold");
		GetTemplateComponent(ref _btnItalic, "_btnItalic");
		GetTemplateComponent(ref _btnUnderline, "_btnUnderline");
		GetTemplateComponent(ref _btnAlignLeft, "_btnAlignLeft");
		GetTemplateComponent(ref _btnAlignCenter, "_btnAlignCenter");
		GetTemplateComponent(ref _btnAlignRight, "_btnAlignRight");
		GetTemplateComponent(ref _dragWidget, "_dragWidget");
		if (_dragWidget != null)
		{
			_dragWidget.DragDelta += DragWidget_DragDelta;
		}
		if (_cmbFontFamilies != null)
		{
			_cmbFontFamilies.ItemsSource = from fontFamily in FontUtilities.Families
				orderby FontUtilities.GetFontFamilyName(fontFamily)
				select FontUtilities.GetFontFamilyName(fontFamily);
			_cmbFontFamilies.SelectionChanged += FontFamily_SelectionChanged;
		}
		if (_cmbFontSizes != null)
		{
			_cmbFontSizes.ItemsSource = FontSizes;
			_cmbFontSizes.SelectionChanged += FontSize_SelectionChanged;
		}
		if (_btnBullets != null)
		{
			_btnBullets.Click += Bullets_Clicked;
		}
		if (_btnNumbers != null)
		{
			_btnNumbers.Click += Numbers_Clicked;
		}
		if (_cmbFontBackgroundColor != null)
		{
			_cmbFontBackgroundColor.SelectedColorChanged += FontBackgroundColor_SelectedColorChanged;
		}
		if (_cmbFontColor != null)
		{
			_cmbFontColor.SelectedColorChanged += FontColor_SelectedColorChanged;
		}
		Update();
	}

	private void GetTemplateComponent<T>(ref T partMember, string partName) where T : class
	{
		partMember = ((base.Template != null) ? (base.Template.FindName(partName, this) as T) : null);
	}

	private void UpdateToggleButtonState()
	{
		UpdateItemCheckedState(_btnBold, TextElement.FontWeightProperty, FontWeights.Bold);
		UpdateItemCheckedState(_btnItalic, TextElement.FontStyleProperty, FontStyles.Italic);
		UpdateItemCheckedState(_btnUnderline, Inline.TextDecorationsProperty, TextDecorations.Underline);
		UpdateItemCheckedState(_btnAlignLeft, Block.TextAlignmentProperty, TextAlignment.Left);
		UpdateItemCheckedState(_btnAlignCenter, Block.TextAlignmentProperty, TextAlignment.Center);
		UpdateItemCheckedState(_btnAlignRight, Block.TextAlignmentProperty, TextAlignment.Right);
	}

	private void UpdateItemCheckedState(ToggleButton button, DependencyProperty formattingProperty, object expectedValue)
	{
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = Target.Selection.GetPropertyValue(formattingProperty);
		}
		if (obj != DependencyProperty.UnsetValue && button != null)
		{
			button.IsChecked = obj != null && (obj?.Equals(expectedValue) ?? false);
		}
	}

	private void UpdateSelectedFontFamily()
	{
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = Target.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
		}
		if (obj != DependencyProperty.UnsetValue)
		{
			FontFamily fontFamily = (FontFamily)obj;
			if (fontFamily != null && _cmbFontFamilies != null)
			{
				_cmbFontFamilies.SelectedItem = FontUtilities.GetFontFamilyName(fontFamily);
			}
		}
	}

	private void UpdateSelectedFontSize()
	{
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = Target.Selection.GetPropertyValue(TextElement.FontSizeProperty);
		}
		if (obj != DependencyProperty.UnsetValue && _cmbFontSizes != null)
		{
			_cmbFontSizes.SelectedValue = obj;
		}
	}

	private void UpdateFontColor()
	{
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = Target.Selection.GetPropertyValue(TextElement.ForegroundProperty);
		}
		if (obj != DependencyProperty.UnsetValue)
		{
			Color? selectedColor = ((obj == null) ? ((Color?)null) : new Color?(((SolidColorBrush)obj).Color));
			if (_cmbFontColor != null)
			{
				_cmbFontColor.SelectedColor = selectedColor;
			}
		}
	}

	private void UpdateFontBackgroundColor()
	{
		object obj = DependencyProperty.UnsetValue;
		if (Target != null && Target.Selection != null)
		{
			obj = Target.Selection.GetPropertyValue(TextElement.BackgroundProperty);
		}
		if (obj != DependencyProperty.UnsetValue)
		{
			Color? selectedColor = ((obj == null) ? ((Color?)null) : new Color?(((SolidColorBrush)obj).Color));
			if (_cmbFontBackgroundColor != null)
			{
				_cmbFontBackgroundColor.SelectedColor = selectedColor;
			}
		}
	}

	private void UpdateSelectionListType()
	{
		if (_btnNumbers == null || _btnBullets == null)
		{
			return;
		}
		_btnBullets.IsChecked = false;
		_btnNumbers.IsChecked = false;
		Paragraph paragraph = ((Target != null && Target.Selection != null) ? Target.Selection.Start.Paragraph : null);
		Paragraph paragraph2 = ((Target != null && Target.Selection != null) ? Target.Selection.End.Paragraph : null);
		if (paragraph != null && paragraph2 != null && paragraph.Parent is ListItem && paragraph2.Parent is ListItem && ((ListItem)(object)paragraph.Parent).List == ((ListItem)(object)paragraph2.Parent).List)
		{
			switch (((ListItem)(object)paragraph.Parent).List.MarkerStyle)
			{
			case TextMarkerStyle.Disc:
				_btnBullets.IsChecked = true;
				break;
			case TextMarkerStyle.Decimal:
				_btnNumbers.IsChecked = true;
				break;
			}
		}
	}

	private bool BothSelectionListsAreChecked()
	{
		if (_btnBullets != null && _btnBullets.IsChecked == true)
		{
			if (_btnNumbers != null)
			{
				return _btnNumbers.IsChecked == true;
			}
			return false;
		}
		return false;
	}

	private void ApplyPropertyValueToSelectedText(DependencyProperty formattingProperty, object value)
	{
		if (Target != null && Target.Selection != null)
		{
			if (value is SolidColorBrush { Color: var color } && color.Equals(Colors.Transparent))
			{
				Target.Selection.ApplyPropertyValue(formattingProperty, null);
			}
			else
			{
				Target.Selection.ApplyPropertyValue(formattingProperty, value);
			}
		}
	}

	private void ProcessMove(DragDeltaEventArgs e)
	{
		UIElementAdorner<Control> uIElementAdorner = AdornerLayer.GetAdornerLayer(Target).GetAdorners(Target).OfType<UIElementAdorner<Control>>()
			.First();
		uIElementAdorner.SetOffsets(uIElementAdorner.OffsetLeft + e.HorizontalChange, uIElementAdorner.OffsetTop + e.VerticalChange);
	}

	private static void OnRichTextBoxPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
	}

	public void Update()
	{
		UpdateToggleButtonState();
		UpdateSelectedFontFamily();
		UpdateSelectedFontSize();
		UpdateFontColor();
		UpdateFontBackgroundColor();
		UpdateSelectionListType();
	}
}
