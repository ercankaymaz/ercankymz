using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Primitives;

public abstract class InputBase : Control
{
	public static readonly DependencyProperty AllowTextInputProperty = DependencyProperty.Register("AllowTextInput", typeof(bool), typeof(InputBase), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnAllowTextInputChanged)));

	public static readonly DependencyProperty CultureInfoProperty = DependencyProperty.Register("CultureInfo", typeof(CultureInfo), typeof(InputBase), (PropertyMetadata)(object)new UIPropertyMetadata(CultureInfo.CurrentCulture, new PropertyChangedCallback(OnCultureInfoChanged)));

	public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(InputBase), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnReadOnlyChanged)));

	public static readonly DependencyProperty IsUndoEnabledProperty = DependencyProperty.Register("IsUndoEnabled", typeof(bool), typeof(InputBase), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnIsUndoEnabledChanged)));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(InputBase), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTextChanged), null, isAnimationProhibited: false, UpdateSourceTrigger.LostFocus));

	public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(InputBase), (PropertyMetadata)(object)new UIPropertyMetadata((object)TextAlignment.Left));

	public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(InputBase), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(InputBase), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public bool AllowTextInput
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowTextInputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowTextInputProperty, (object)value);
		}
	}

	public CultureInfo CultureInfo
	{
		get
		{
			return (CultureInfo)((DependencyObject)this).GetValue(CultureInfoProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CultureInfoProperty, (object)value);
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

	public bool IsUndoEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsUndoEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsUndoEnabledProperty, (object)value);
		}
	}

	public string Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public TextAlignment TextAlignment
	{
		get
		{
			return (TextAlignment)((DependencyObject)this).GetValue(TextAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextAlignmentProperty, (object)value);
		}
	}

	public object Watermark
	{
		get
		{
			return ((DependencyObject)this).GetValue(WatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkProperty, value);
		}
	}

	public DataTemplate WatermarkTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(WatermarkTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkTemplateProperty, (object)value);
		}
	}

	private static void OnAllowTextInputChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is InputBase inputBase)
		{
			inputBase.OnAllowTextInputChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnAllowTextInputChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnCultureInfoChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is InputBase inputBase)
		{
			inputBase.OnCultureInfoChanged((CultureInfo)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (CultureInfo)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnCultureInfoChanged(CultureInfo oldValue, CultureInfo newValue)
	{
	}

	private static void OnReadOnlyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is InputBase inputBase)
		{
			inputBase.OnReadOnlyChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnReadOnlyChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnIsUndoEnabledChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is InputBase inputBase)
		{
			inputBase.OnIsUndoEnabledChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsUndoEnabledChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is InputBase inputBase)
		{
			inputBase.OnTextChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnTextChanged(string oldValue, string newValue)
	{
	}
}
