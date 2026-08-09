using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_ColorShadingCanvas", Type = typeof(Canvas))]
[TemplatePart(Name = "PART_ColorShadeSelector", Type = typeof(Canvas))]
[TemplatePart(Name = "PART_SpectrumSlider", Type = typeof(ColorSpectrumSlider))]
[TemplatePart(Name = "PART_HexadecimalTextBox", Type = typeof(TextBox))]
public class ColorCanvas : Control
{
	private const string PART_ColorShadingCanvas = "PART_ColorShadingCanvas";

	private const string PART_ColorShadeSelector = "PART_ColorShadeSelector";

	private const string PART_SpectrumSlider = "PART_SpectrumSlider";

	private const string PART_HexadecimalTextBox = "PART_HexadecimalTextBox";

	private TranslateTransform _colorShadeSelectorTransform = new TranslateTransform();

	private Canvas _colorShadingCanvas;

	private Canvas _colorShadeSelector;

	private ColorSpectrumSlider _spectrumSlider;

	private TextBox _hexadecimalTextBox;

	private Point? _currentColorPosition;

	private bool _surpressPropertyChanged;

	private bool _updateSpectrumSliderValue = true;

	public static readonly DependencyProperty SelectedColorProperty;

	public static readonly DependencyProperty AProperty;

	public static readonly DependencyProperty RProperty;

	public static readonly DependencyProperty GProperty;

	public static readonly DependencyProperty BProperty;

	public static readonly DependencyProperty HexadecimalStringProperty;

	public static readonly DependencyProperty UsingAlphaChannelProperty;

	public static readonly RoutedEvent SelectedColorChangedEvent;

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

	public byte A
	{
		get
		{
			return (byte)((DependencyObject)this).GetValue(AProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AProperty, (object)value);
		}
	}

	public byte R
	{
		get
		{
			return (byte)((DependencyObject)this).GetValue(RProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RProperty, (object)value);
		}
	}

	public byte G
	{
		get
		{
			return (byte)((DependencyObject)this).GetValue(GProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GProperty, (object)value);
		}
	}

	public byte B
	{
		get
		{
			return (byte)((DependencyObject)this).GetValue(BProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BProperty, (object)value);
		}
	}

	public string HexadecimalString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(HexadecimalStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HexadecimalStringProperty, (object)value);
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

	private static void OnSelectedColorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnSelectedColorChanged((Color?)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Color?)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnSelectedColorChanged(Color? oldValue, Color? newValue)
	{
		SetHexadecimalStringProperty(GetFormatedColorString(newValue), modifyFromUI: false);
		UpdateRGBValues(newValue);
		UpdateColorShadeSelectorPosition(newValue);
		RoutedPropertyChangedEventArgs<Color?> e = new RoutedPropertyChangedEventArgs<Color?>(oldValue, newValue);
		e.RoutedEvent = SelectedColorChangedEvent;
		RaiseEvent(e);
	}

	private static void OnAChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnAChanged((byte)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (byte)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnAChanged(byte oldValue, byte newValue)
	{
		if (!_surpressPropertyChanged)
		{
			UpdateSelectedColor();
		}
	}

	private static void OnRChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnRChanged((byte)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (byte)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnRChanged(byte oldValue, byte newValue)
	{
		if (!_surpressPropertyChanged)
		{
			UpdateSelectedColor();
		}
	}

	private static void OnGChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnGChanged((byte)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (byte)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnGChanged(byte oldValue, byte newValue)
	{
		if (!_surpressPropertyChanged)
		{
			UpdateSelectedColor();
		}
	}

	private static void OnBChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnBChanged((byte)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (byte)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnBChanged(byte oldValue, byte newValue)
	{
		if (!_surpressPropertyChanged)
		{
			UpdateSelectedColor();
		}
	}

	private static void OnHexadecimalStringChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnHexadecimalStringChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnHexadecimalStringChanged(string oldValue, string newValue)
	{
		string formatedColorString = GetFormatedColorString(newValue);
		if (!GetFormatedColorString(SelectedColor).Equals(formatedColorString))
		{
			Color? color = null;
			if (!string.IsNullOrEmpty(formatedColorString))
			{
				color = (Color)ColorConverter.ConvertFromString(formatedColorString);
			}
			UpdateSelectedColor(color);
		}
		SetHexadecimalTextBoxTextProperty(newValue);
	}

	private static object OnCoerceHexadecimalString(DependencyObject d, object basevalue)
	{
		ColorCanvas colorCanvas = (ColorCanvas)(object)d;
		if (colorCanvas == null)
		{
			return basevalue;
		}
		return colorCanvas.OnCoerceHexadecimalString(basevalue);
	}

	private object OnCoerceHexadecimalString(object newValue)
	{
		string text = newValue as string;
		try
		{
			if (!string.IsNullOrEmpty(text))
			{
				if (int.TryParse(text, NumberStyles.HexNumber, null, out var _))
				{
					text = "#" + text;
				}
				ColorConverter.ConvertFromString(text);
			}
		}
		catch
		{
			throw new InvalidDataException("Color provided is not in the correct format.");
		}
		return text;
	}

	private static void OnUsingAlphaChannelPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ColorCanvas colorCanvas)
		{
			colorCanvas.OnUsingAlphaChannelChanged();
		}
	}

	protected virtual void OnUsingAlphaChannelChanged()
	{
		SetHexadecimalStringProperty(GetFormatedColorString(SelectedColor), modifyFromUI: false);
	}

	static ColorCanvas()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0161: Expected O, but got Unknown
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		SelectedColorProperty = DependencyProperty.Register("SelectedColor", typeof(Color?), typeof(ColorCanvas), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSelectedColorChanged)));
		AProperty = DependencyProperty.Register("A", typeof(byte), typeof(ColorCanvas), (PropertyMetadata)(object)new UIPropertyMetadata(byte.MaxValue, new PropertyChangedCallback(OnAChanged)));
		RProperty = DependencyProperty.Register("R", typeof(byte), typeof(ColorCanvas), (PropertyMetadata)(object)new UIPropertyMetadata((byte)0, new PropertyChangedCallback(OnRChanged)));
		GProperty = DependencyProperty.Register("G", typeof(byte), typeof(ColorCanvas), (PropertyMetadata)(object)new UIPropertyMetadata((byte)0, new PropertyChangedCallback(OnGChanged)));
		BProperty = DependencyProperty.Register("B", typeof(byte), typeof(ColorCanvas), (PropertyMetadata)(object)new UIPropertyMetadata((byte)0, new PropertyChangedCallback(OnBChanged)));
		HexadecimalStringProperty = DependencyProperty.Register("HexadecimalString", typeof(string), typeof(ColorCanvas), (PropertyMetadata)(object)new UIPropertyMetadata("", new PropertyChangedCallback(OnHexadecimalStringChanged), new CoerceValueCallback(OnCoerceHexadecimalString)));
		UsingAlphaChannelProperty = DependencyProperty.Register("UsingAlphaChannel", typeof(bool), typeof(ColorCanvas), (PropertyMetadata)(object)new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnUsingAlphaChannelPropertyChanged)));
		SelectedColorChangedEvent = EventManager.RegisterRoutedEvent("SelectedColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color?>), typeof(ColorCanvas));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorCanvas), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ColorCanvas)));
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_colorShadingCanvas != null)
		{
			_colorShadingCanvas.MouseLeftButtonDown -= ColorShadingCanvas_MouseLeftButtonDown;
			_colorShadingCanvas.MouseLeftButtonUp -= ColorShadingCanvas_MouseLeftButtonUp;
			_colorShadingCanvas.MouseMove -= ColorShadingCanvas_MouseMove;
			_colorShadingCanvas.SizeChanged -= ColorShadingCanvas_SizeChanged;
		}
		_colorShadingCanvas = GetTemplateChild("PART_ColorShadingCanvas") as Canvas;
		if (_colorShadingCanvas != null)
		{
			_colorShadingCanvas.MouseLeftButtonDown += ColorShadingCanvas_MouseLeftButtonDown;
			_colorShadingCanvas.MouseLeftButtonUp += ColorShadingCanvas_MouseLeftButtonUp;
			_colorShadingCanvas.MouseMove += ColorShadingCanvas_MouseMove;
			_colorShadingCanvas.SizeChanged += ColorShadingCanvas_SizeChanged;
		}
		_colorShadeSelector = GetTemplateChild("PART_ColorShadeSelector") as Canvas;
		if (_colorShadeSelector != null)
		{
			_colorShadeSelector.RenderTransform = _colorShadeSelectorTransform;
		}
		if (_spectrumSlider != null)
		{
			_spectrumSlider.ValueChanged -= SpectrumSlider_ValueChanged;
		}
		_spectrumSlider = GetTemplateChild("PART_SpectrumSlider") as ColorSpectrumSlider;
		if (_spectrumSlider != null)
		{
			_spectrumSlider.ValueChanged += SpectrumSlider_ValueChanged;
		}
		if (_hexadecimalTextBox != null)
		{
			_hexadecimalTextBox.LostFocus -= HexadecimalTextBox_LostFocus;
		}
		_hexadecimalTextBox = GetTemplateChild("PART_HexadecimalTextBox") as TextBox;
		if (_hexadecimalTextBox != null)
		{
			_hexadecimalTextBox.LostFocus += HexadecimalTextBox_LostFocus;
		}
		UpdateRGBValues(SelectedColor);
		UpdateColorShadeSelectorPosition(SelectedColor);
		SetHexadecimalTextBoxTextProperty(GetFormatedColorString(SelectedColor));
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		base.OnKeyDown(e);
		if ((int)e.Key == 6 && e.OriginalSource is TextBox)
		{
			TextBox textBox = (TextBox)e.OriginalSource;
			if (textBox.Name == "PART_HexadecimalTextBox")
			{
				SetHexadecimalStringProperty(textBox.Text, modifyFromUI: true);
			}
		}
	}

	private void ColorShadingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (_colorShadingCanvas != null)
		{
			Point position = e.GetPosition(_colorShadingCanvas);
			UpdateColorShadeSelectorPositionAndCalculateColor(position, calculateColor: true);
			_colorShadingCanvas.CaptureMouse();
			e.Handled = true;
		}
	}

	private void ColorShadingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		if (_colorShadingCanvas != null)
		{
			_colorShadingCanvas.ReleaseMouseCapture();
		}
	}

	private void ColorShadingCanvas_MouseMove(object sender, MouseEventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (_colorShadingCanvas != null && e.LeftButton == MouseButtonState.Pressed)
		{
			Point position = e.GetPosition(_colorShadingCanvas);
			UpdateColorShadeSelectorPositionAndCalculateColor(position, calculateColor: true);
			Mouse.Synchronize();
		}
	}

	private void ColorShadingCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		if (_currentColorPosition.HasValue)
		{
			Point val = default(Point);
			Point value = _currentColorPosition.Value;
			double x = ((Point)(ref value)).X;
			Size newSize = e.NewSize;
			((Point)(ref val)).X = x * ((Size)(ref newSize)).Width;
			value = _currentColorPosition.Value;
			double y = ((Point)(ref value)).Y;
			newSize = e.NewSize;
			((Point)(ref val)).Y = y * ((Size)(ref newSize)).Height;
			Point p = val;
			UpdateColorShadeSelectorPositionAndCalculateColor(p, calculateColor: false);
		}
	}

	private void SpectrumSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (_currentColorPosition.HasValue && SelectedColor.HasValue)
		{
			CalculateColor(_currentColorPosition.Value);
		}
	}

	private void HexadecimalTextBox_LostFocus(object sender, RoutedEventArgs e)
	{
		TextBox textBox = sender as TextBox;
		SetHexadecimalStringProperty(textBox.Text, modifyFromUI: true);
	}

	private void UpdateSelectedColor()
	{
		SelectedColor = Color.FromArgb(A, R, G, B);
	}

	private void UpdateSelectedColor(Color? color)
	{
		SelectedColor = ((color.HasValue && color.HasValue) ? new Color?(Color.FromArgb(color.Value.A, color.Value.R, color.Value.G, color.Value.B)) : ((Color?)null));
	}

	private void UpdateRGBValues(Color? color)
	{
		if (color.HasValue && color.HasValue)
		{
			_surpressPropertyChanged = true;
			A = color.Value.A;
			R = color.Value.R;
			G = color.Value.G;
			B = color.Value.B;
			_surpressPropertyChanged = false;
		}
	}

	private void UpdateColorShadeSelectorPositionAndCalculateColor(Point p, bool calculateColor)
	{
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		if (_colorShadingCanvas != null && _colorShadeSelector != null)
		{
			if (((Point)(ref p)).Y < 0.0)
			{
				((Point)(ref p)).Y = 0.0;
			}
			if (((Point)(ref p)).X < 0.0)
			{
				((Point)(ref p)).X = 0.0;
			}
			if (((Point)(ref p)).X > _colorShadingCanvas.ActualWidth)
			{
				((Point)(ref p)).X = _colorShadingCanvas.ActualWidth;
			}
			if (((Point)(ref p)).Y > _colorShadingCanvas.ActualHeight)
			{
				((Point)(ref p)).Y = _colorShadingCanvas.ActualHeight;
			}
			_colorShadeSelectorTransform.X = ((Point)(ref p)).X - _colorShadeSelector.Width / 2.0;
			_colorShadeSelectorTransform.Y = ((Point)(ref p)).Y - _colorShadeSelector.Height / 2.0;
			((Point)(ref p)).X = ((Point)(ref p)).X / _colorShadingCanvas.ActualWidth;
			((Point)(ref p)).Y = ((Point)(ref p)).Y / _colorShadingCanvas.ActualHeight;
			_currentColorPosition = p;
			if (calculateColor)
			{
				CalculateColor(p);
			}
		}
	}

	private void UpdateColorShadeSelectorPosition(Color? color)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		if (_spectrumSlider != null && _colorShadingCanvas != null && color.HasValue && color.HasValue)
		{
			_currentColorPosition = null;
			HsvColor hsvColor = ColorUtilities.ConvertRgbToHsv(color.Value.R, color.Value.G, color.Value.B);
			if (_updateSpectrumSliderValue)
			{
				_spectrumSlider.Value = 360.0 - hsvColor.H;
			}
			Point value = default(Point);
			((Point)(ref value))._002Ector(hsvColor.S, 1.0 - hsvColor.V);
			_currentColorPosition = value;
			_colorShadeSelectorTransform.X = ((Point)(ref value)).X * _colorShadingCanvas.Width - 5.0;
			_colorShadeSelectorTransform.Y = ((Point)(ref value)).Y * _colorShadingCanvas.Height - 5.0;
		}
	}

	private void CalculateColor(Point p)
	{
		if (_spectrumSlider != null)
		{
			HsvColor hsvColor = new HsvColor(360.0 - _spectrumSlider.Value, 1.0, 1.0);
			hsvColor.S = ((Point)(ref p)).X;
			hsvColor.V = 1.0 - ((Point)(ref p)).Y;
			HsvColor hsvColor2 = hsvColor;
			Color value = ColorUtilities.ConvertHsvToRgb(hsvColor2.H, hsvColor2.S, hsvColor2.V);
			value.A = A;
			_updateSpectrumSliderValue = false;
			SelectedColor = value;
			_updateSpectrumSliderValue = true;
			SetHexadecimalStringProperty(GetFormatedColorString(SelectedColor), modifyFromUI: false);
		}
	}

	private string GetFormatedColorString(Color? colorToFormat)
	{
		if (!colorToFormat.HasValue || !colorToFormat.HasValue)
		{
			return string.Empty;
		}
		return ColorUtilities.FormatColorString(colorToFormat.ToString(), UsingAlphaChannel);
	}

	private string GetFormatedColorString(string stringToFormat)
	{
		return ColorUtilities.FormatColorString(stringToFormat, UsingAlphaChannel);
	}

	private void SetHexadecimalStringProperty(string newValue, bool modifyFromUI)
	{
		if (modifyFromUI)
		{
			try
			{
				if (!string.IsNullOrEmpty(newValue))
				{
					if (int.TryParse(newValue, NumberStyles.HexNumber, null, out var _))
					{
						newValue = "#" + newValue;
					}
					ColorConverter.ConvertFromString(newValue);
				}
				HexadecimalString = newValue;
				return;
			}
			catch
			{
				SetHexadecimalTextBoxTextProperty(HexadecimalString);
				return;
			}
		}
		HexadecimalString = newValue;
	}

	private void SetHexadecimalTextBoxTextProperty(string newValue)
	{
		if (_hexadecimalTextBox != null)
		{
			_hexadecimalTextBox.Text = newValue;
		}
	}
}
