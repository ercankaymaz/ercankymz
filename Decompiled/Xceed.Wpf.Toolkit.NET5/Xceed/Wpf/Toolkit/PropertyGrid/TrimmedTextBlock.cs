using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class TrimmedTextBlock : TextBlock
{
	public static readonly DependencyProperty IsTextTrimmedProperty = DependencyProperty.Register("IsTextTrimmed", typeof(bool), typeof(TrimmedTextBlock), new PropertyMetadata((object)false, new PropertyChangedCallback(OnIsTextTrimmedChanged)));

	public static readonly DependencyProperty HighlightedBrushProperty = DependencyProperty.Register("HighlightedBrush", typeof(Brush), typeof(TrimmedTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Yellow));

	public static readonly DependencyProperty HighlightedTextProperty = DependencyProperty.Register("HighlightedText", typeof(string), typeof(TrimmedTextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(HighlightedTextChanged)));

	public bool IsTextTrimmed
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTextTrimmedProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(IsTextTrimmedProperty, (object)value);
		}
	}

	public Brush HighlightedBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(HighlightedBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HighlightedBrushProperty, (object)value);
		}
	}

	public string HighlightedText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(HighlightedTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HighlightedTextProperty, (object)value);
		}
	}

	public TrimmedTextBlock()
	{
		base.SizeChanged += TrimmedTextBlock_SizeChanged;
	}

	private static void OnIsTextTrimmedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is TrimmedTextBlock trimmedTextBlock)
		{
			trimmedTextBlock.OnIsTextTrimmedChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private void OnIsTextTrimmedChanged(bool oldValue, bool newValue)
	{
		base.ToolTip = (newValue ? base.Text : null);
	}

	private static void HighlightedTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is TrimmedTextBlock trimmedTextBlock)
		{
			trimmedTextBlock.HighlightedTextChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void HighlightedTextChanged(string oldValue, string newValue)
	{
		if (base.Text.Length != 0)
		{
			if (newValue == null)
			{
				Run item = new Run(base.Text);
				base.Inlines.Clear();
				base.Inlines.Add(item);
				return;
			}
			int num = base.Text.IndexOf(newValue, StringComparison.InvariantCultureIgnoreCase);
			int num2 = num + newValue.Length;
			string text = base.Text.Substring(0, num);
			string text2 = base.Text.Substring(num, newValue.Length);
			string text3 = base.Text.Substring(num2, base.Text.Length - num2);
			base.Inlines.Clear();
			Run item2 = new Run(text);
			base.Inlines.Add(item2);
			item2 = new Run(text2);
			item2.Background = HighlightedBrush;
			base.Inlines.Add(item2);
			item2 = new Run(text3);
			base.Inlines.Add(item2);
		}
	}

	private void TrimmedTextBlock_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		if (sender is TextBlock textBlock)
		{
			IsTextTrimmed = GetIsTextTrimmed(textBlock);
		}
	}

	private bool GetIsTextTrimmed(TextBlock textBlock)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (textBlock == null)
		{
			return false;
		}
		if (textBlock.TextTrimming == TextTrimming.None)
		{
			return false;
		}
		if (textBlock.TextWrapping != TextWrapping.NoWrap)
		{
			return false;
		}
		double actualWidth = textBlock.ActualWidth;
		textBlock.Measure(new Size(double.MaxValue, double.MaxValue));
		Size desiredSize = textBlock.DesiredSize;
		double width = ((Size)(ref desiredSize)).Width;
		return actualWidth < width;
	}
}
