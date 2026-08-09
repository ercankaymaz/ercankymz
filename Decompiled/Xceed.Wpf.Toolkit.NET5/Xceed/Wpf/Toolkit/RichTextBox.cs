using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace Xceed.Wpf.Toolkit;

public class RichTextBox : System.Windows.Controls.RichTextBox
{
	private bool _preventDocumentUpdate;

	private bool _preventTextUpdate;

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(RichTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTextPropertyChanged), new CoerceValueCallback(CoerceTextProperty), isAnimationProhibited: true, UpdateSourceTrigger.LostFocus));

	public static readonly DependencyProperty TextFormatterProperty = DependencyProperty.Register("TextFormatter", typeof(ITextFormatter), typeof(RichTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new RtfFormatter(), new PropertyChangedCallback(OnTextFormatterPropertyChanged)));

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

	public ITextFormatter TextFormatter
	{
		get
		{
			return (ITextFormatter)((DependencyObject)this).GetValue(TextFormatterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextFormatterProperty, (object)value);
		}
	}

	public RichTextBox()
	{
	}

	public RichTextBox(FlowDocument document)
		: base(document)
	{
	}

	private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((RichTextBox)(object)d).UpdateDocumentFromText();
	}

	private static object CoerceTextProperty(DependencyObject d, object value)
	{
		return value ?? "";
	}

	private static void OnTextFormatterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is RichTextBox richTextBox)
		{
			richTextBox.OnTextFormatterPropertyChanged((ITextFormatter)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (ITextFormatter)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnTextFormatterPropertyChanged(ITextFormatter oldValue, ITextFormatter newValue)
	{
		UpdateTextFromDocument();
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		UpdateTextFromDocument();
		base.OnTextChanged(e);
	}

	private void UpdateTextFromDocument()
	{
		if (!_preventTextUpdate)
		{
			_preventDocumentUpdate = true;
			((DependencyObject)this).SetCurrentValue(TextProperty, (object)TextFormatter.GetText(base.Document));
			_preventDocumentUpdate = false;
		}
	}

	private void UpdateDocumentFromText()
	{
		if (!_preventDocumentUpdate)
		{
			_preventTextUpdate = true;
			TextFormatter.SetText(base.Document, Text);
			_preventTextUpdate = false;
		}
	}

	public void Clear()
	{
		base.Document.Blocks.Clear();
	}

	public override void BeginInit()
	{
		base.BeginInit();
		_preventTextUpdate = true;
		_preventDocumentUpdate = true;
	}

	public override void EndInit()
	{
		base.EndInit();
		_preventTextUpdate = false;
		_preventDocumentUpdate = false;
		if (!string.IsNullOrEmpty(Text))
		{
			UpdateDocumentFromText();
		}
		else
		{
			UpdateTextFromDocument();
		}
	}
}
