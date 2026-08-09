using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

public class RichTextBoxFormatBarManager : DependencyObject
{
	private System.Windows.Controls.RichTextBox _richTextBox;

	private UIElementAdorner<Control> _adorner;

	private IRichTextBoxFormatBar _toolbar;

	private Window _parentWindow;

	private const double _hideAdornerDistance = 150.0;

	public static readonly DependencyProperty FormatBarProperty = DependencyProperty.RegisterAttached("FormatBar", typeof(IRichTextBoxFormatBar), typeof(RichTextBox), new PropertyMetadata((object)null, new PropertyChangedCallback(OnFormatBarPropertyChanged)));

	public bool IsAdornerVisible => _adorner.Visibility == Visibility.Visible;

	public static void SetFormatBar(UIElement element, IRichTextBoxFormatBar value)
	{
		((DependencyObject)element).SetValue(FormatBarProperty, (object)value);
	}

	public static IRichTextBoxFormatBar GetFormatBar(UIElement element)
	{
		return (IRichTextBoxFormatBar)((DependencyObject)element).GetValue(FormatBarProperty);
	}

	private static void OnFormatBarPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (!(d is System.Windows.Controls.RichTextBox richTextBox))
		{
			throw new Exception("A FormatBar can only be applied to a RichTextBox.");
		}
		new RichTextBoxFormatBarManager().AttachFormatBarToRichtextBox(richTextBox, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IRichTextBoxFormatBar);
	}

	private void RichTextBox_MouseButtonUp(object sender, MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Released)
		{
			if (!_richTextBox.IsReadOnly)
			{
				TextRange textRange = new TextRange(_richTextBox.Selection.Start, _richTextBox.Selection.End);
				if (textRange.Text.Length > 0 && !string.IsNullOrWhiteSpace(textRange.Text))
				{
					ShowAdorner();
				}
				else
				{
					HideAdorner();
				}
				e.Handled = true;
			}
		}
		else
		{
			HideAdorner();
		}
	}

	private void OnPreviewMouseMoveParentWindow(object sender, MouseEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Point position = e.GetPosition(_adorner);
		double val = 0.0;
		if ((_adorner.Child != null && _adorner.Child is IRichTextBoxFormatBar && ((IRichTextBoxFormatBar)_adorner.Child).PreventDisplayFadeOut) || (((Point)(ref position)).X >= 0.0 && ((Point)(ref position)).X <= _adorner.ActualWidth && ((Point)(ref position)).Y >= 0.0 && ((Point)(ref position)).Y <= _adorner.ActualHeight))
		{
			return;
		}
		if (((Point)(ref position)).X < -150.0 || ((Point)(ref position)).X > _adorner.ActualWidth + 150.0 || ((Point)(ref position)).Y < -150.0 || ((Point)(ref position)).Y > _adorner.ActualHeight + 150.0)
		{
			HideAdorner();
			return;
		}
		if (((Point)(ref position)).X < 0.0)
		{
			val = 0.0 - ((Point)(ref position)).X;
		}
		else if (((Point)(ref position)).X > _adorner.ActualWidth)
		{
			val = ((Point)(ref position)).X - _adorner.ActualWidth;
		}
		if (((Point)(ref position)).Y < 0.0)
		{
			val = Math.Max(val, 0.0 - ((Point)(ref position)).Y);
		}
		else if (((Point)(ref position)).Y > _adorner.ActualHeight)
		{
			val = Math.Max(val, ((Point)(ref position)).Y - _adorner.ActualHeight);
		}
		_adorner.Opacity = 1.0 - Math.Min(val, 100.0) / 100.0;
	}

	private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (!_richTextBox.IsFocused && !_richTextBox.Selection.IsEmpty)
		{
			_richTextBox.Focus();
		}
	}

	private void AttachFormatBarToRichtextBox(System.Windows.Controls.RichTextBox richTextBox, IRichTextBoxFormatBar formatBar)
	{
		_richTextBox = richTextBox;
		_richTextBox.AddHandler(Mouse.MouseUpEvent, new MouseButtonEventHandler(RichTextBox_MouseButtonUp), handledEventsToo: true);
		_richTextBox.TextChanged += RichTextBox_TextChanged;
		_adorner = new UIElementAdorner<Control>(_richTextBox);
		formatBar.Target = _richTextBox;
		_toolbar = formatBar;
	}

	private void ShowAdorner()
	{
		if (_adorner.Visibility == Visibility.Visible)
		{
			HideAdorner();
		}
		VerifyAdornerLayer();
		Control control = _toolbar as Control;
		if (_adorner.Child == null)
		{
			_adorner.Child = control;
		}
		control.ApplyTemplate();
		_toolbar.Update();
		_adorner.Visibility = Visibility.Visible;
		PositionFormatBar(control);
		_parentWindow = TreeHelper.FindParent<Window>((DependencyObject)(object)_adorner);
		if (_parentWindow != null)
		{
			Mouse.AddMouseMoveHandler((DependencyObject)(object)_parentWindow, OnPreviewMouseMoveParentWindow);
		}
	}

	private void PositionFormatBar(Control adorningEditor)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		Point position = Mouse.GetPosition(_richTextBox);
		double num = ((Point)(ref position)).X;
		double num2 = ((Point)(ref position)).Y;
		if (num2 < 0.0)
		{
			num2 = 5.0;
		}
		if (num < 0.0)
		{
			num = 5.0;
		}
		if (num + adorningEditor.ActualWidth > _richTextBox.ActualWidth - 10.0)
		{
			num = _richTextBox.ActualWidth - adorningEditor.ActualWidth - 10.0;
		}
		if (num2 + adorningEditor.ActualHeight > _richTextBox.ActualHeight - 10.0)
		{
			num2 = _richTextBox.ActualHeight - adorningEditor.ActualHeight - 10.0;
		}
		_adorner.SetOffsets(num, num2);
	}

	private bool VerifyAdornerLayer()
	{
		if (_adorner.Parent != null)
		{
			return true;
		}
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(_richTextBox);
		if (adornerLayer == null)
		{
			return false;
		}
		adornerLayer.Add(_adorner);
		return true;
	}

	private void HideAdorner()
	{
		if (IsAdornerVisible)
		{
			_adorner.Visibility = Visibility.Collapsed;
			if (_parentWindow != null)
			{
				Mouse.RemoveMouseMoveHandler((DependencyObject)(object)_parentWindow, OnPreviewMouseMoveParentWindow);
			}
		}
	}
}
