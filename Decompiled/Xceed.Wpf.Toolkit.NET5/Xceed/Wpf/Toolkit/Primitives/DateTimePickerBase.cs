using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Primitives;

[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
public class DateTimePickerBase : DateTimeUpDown
{
	private const string PART_Popup = "PART_Popup";

	private Popup _popup;

	private DateTime? _initialValue;

	public static readonly DependencyProperty DropDownButtonContentProperty = DependencyProperty.Register("DropDownButtonContent", typeof(object), typeof(DateTimePickerBase), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty DropDownButtonDisabledContentProperty = DependencyProperty.Register("DropDownButtonDisabledContent", typeof(object), typeof(DateTimePickerBase), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty DropDownButtonHeightProperty = DependencyProperty.Register("DropDownButtonHeight", typeof(double), typeof(DateTimePickerBase), (PropertyMetadata)(object)new UIPropertyMetadata((object)double.NaN));

	public static readonly DependencyProperty DropDownButtonWidthProperty = DependencyProperty.Register("DropDownButtonWidth", typeof(double), typeof(DateTimePickerBase), (PropertyMetadata)(object)new UIPropertyMetadata((object)double.NaN));

	public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(DateTimePickerBase), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsOpenChanged)));

	public static readonly DependencyProperty ShowDropDownButtonProperty = DependencyProperty.Register("ShowDropDownButton", typeof(bool), typeof(DateTimePickerBase), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));

	public object DropDownButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(DropDownButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownButtonContentProperty, value);
		}
	}

	public object DropDownButtonDisabledContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(DropDownButtonDisabledContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownButtonDisabledContentProperty, value);
		}
	}

	public double DropDownButtonHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DropDownButtonHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownButtonHeightProperty, (object)value);
		}
	}

	public double DropDownButtonWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DropDownButtonWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownButtonWidthProperty, (object)value);
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

	private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((DateTimePickerBase)(object)d)?.OnIsOpenChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			_initialValue = base.Value;
		}
	}

	public DateTimePickerBase()
	{
		AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(HandleKeyDown), handledEventsToo: true);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, OnMouseDownOutsideCapturedElement);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_popup != null)
		{
			_popup.Opened -= Popup_Opened;
		}
		_popup = GetTemplateChild("PART_Popup") as Popup;
		if (_popup != null)
		{
			_popup.Opened += Popup_Opened;
		}
	}

	protected virtual void HandleKeyDown(object sender, KeyEventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
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
			ClosePopup(isFocusOnTextBox: true);
			e.Handled = true;
		}
		else if ((int)e.Key == 6)
		{
			ClosePopup(isFocusOnTextBox: true);
			e.Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			if (!object.Equals(base.Value, _initialValue))
			{
				base.Value = _initialValue;
			}
			ClosePopup(isFocusOnTextBox: true);
			e.Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		ClosePopup(isFocusOnTextBox: true);
	}

	protected virtual void Popup_Opened(object sender, EventArgs e)
	{
	}

	protected void ClosePopup(bool isFocusOnTextBox)
	{
		if (IsOpen)
		{
			IsOpen = false;
		}
		ReleaseMouseCapture();
		if (isFocusOnTextBox && base.TextBox != null)
		{
			base.TextBox.Focus();
		}
	}
}
