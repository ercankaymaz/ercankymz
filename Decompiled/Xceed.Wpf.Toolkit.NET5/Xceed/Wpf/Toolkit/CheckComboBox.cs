using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
public class CheckComboBox : SelectAllSelector
{
	private const string PART_Popup = "PART_Popup";

	private ValueChangeHelper _displayMemberPathValuesChangeHelper;

	private bool _ignoreTextValueChanged;

	private Popup _popup;

	private List<object> _initialValue = new List<object>();

	public static readonly DependencyProperty IsEditableProperty;

	public static readonly DependencyProperty TextProperty;

	public static readonly DependencyProperty IsDropDownOpenProperty;

	public static readonly DependencyProperty MaxDropDownHeightProperty;

	public static readonly RoutedEvent ClosedEvent;

	public static readonly RoutedEvent OpenedEvent;

	public bool IsEditable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsEditableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsEditableProperty, (object)value);
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

	public bool IsDropDownOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsDropDownOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsDropDownOpenProperty, (object)value);
		}
	}

	public double MaxDropDownHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxDropDownHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxDropDownHeightProperty, (object)value);
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

	static CheckComboBox()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		IsEditableProperty = DependencyProperty.Register("IsEditable", typeof(bool), typeof(CheckComboBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CheckComboBox), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnTextChanged)));
		IsDropDownOpenProperty = DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(CheckComboBox), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsDropDownOpenChanged)));
		MaxDropDownHeightProperty = DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(CheckComboBox), (PropertyMetadata)(object)new UIPropertyMetadata(SystemParameters.PrimaryScreenHeight / 3.0, new PropertyChangedCallback(OnMaxDropDownHeightChanged)));
		ClosedEvent = EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(EventHandler), typeof(CheckComboBox));
		OpenedEvent = EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Bubble, typeof(EventHandler), typeof(CheckComboBox));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckComboBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(CheckComboBox)));
	}

	public CheckComboBox()
	{
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, OnMouseDownOutsideCapturedElement);
		_displayMemberPathValuesChangeHelper = new ValueChangeHelper(OnDisplayMemberPathValuesChanged);
	}

	private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CheckComboBox checkComboBox)
		{
			checkComboBox.OnTextChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnTextChanged(string oldValue, string newValue)
	{
		if (base.IsInitialized && !_ignoreTextValueChanged && IsEditable)
		{
			UpdateFromText();
		}
	}

	private static void OnIsDropDownOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CheckComboBox checkComboBox)
		{
			checkComboBox.OnIsDropDownOpenChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsDropDownOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			_initialValue.Clear();
			foreach (object selectedItem in base.SelectedItems)
			{
				_initialValue.Add(selectedItem);
			}
			RaiseEvent(new RoutedEventArgs(OpenedEvent, this));
		}
		else
		{
			_initialValue.Clear();
			RaiseEvent(new RoutedEventArgs(ClosedEvent, this));
		}
	}

	private static void OnMaxDropDownHeightChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CheckComboBox checkComboBox)
		{
			checkComboBox.OnMaxDropDownHeightChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnMaxDropDownHeightChanged(double oldValue, double newValue)
	{
	}

	protected override void OnSelectedValueChanged(string oldValue, string newValue)
	{
		base.OnSelectedValueChanged(oldValue, newValue);
		UpdateText();
	}

	protected override void OnDisplayMemberPathChanged(string oldDisplayMemberPath, string newDisplayMemberPath)
	{
		base.OnDisplayMemberPathChanged(oldDisplayMemberPath, newDisplayMemberPath);
		UpdateDisplayMemberPathValuesBindings();
	}

	protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
		base.OnItemsSourceChanged(oldValue, newValue);
		UpdateDisplayMemberPathValuesBindings();
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

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseDropDown(isFocusOnComboBox: true);
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		if (!IsDropDownOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsDropDownOpen = true;
				e.Handled = true;
			}
		}
		else if (KeyboardUtilities.IsKeyModifyingPopupState(e))
		{
			CloseDropDown(isFocusOnComboBox: true);
			e.Handled = true;
		}
		else if ((int)e.Key == 6)
		{
			CloseDropDown(isFocusOnComboBox: true);
			e.Handled = true;
		}
		else
		{
			if ((int)e.Key != 13)
			{
				return;
			}
			base.SelectedItems.Clear();
			foreach (object item in _initialValue)
			{
				base.SelectedItems.Add(item);
			}
			CloseDropDown(isFocusOnComboBox: true);
			e.Handled = true;
		}
	}

	private void Popup_Opened(object sender, EventArgs e)
	{
		UIElement uIElement = base.ItemContainerGenerator.ContainerFromItem(base.SelectedItem) as UIElement;
		if (uIElement == null && base.Items.Count > 0)
		{
			uIElement = base.ItemContainerGenerator.ContainerFromItem(base.Items[0]) as UIElement;
		}
		uIElement?.Focus();
	}

	protected virtual void UpdateText()
	{
		if (base.Items.Count == base.SelectedItems.Count)
		{
			((DependencyObject)this).SetCurrentValue(TextProperty, (object)base.AllItemsSelectedContent);
			return;
		}
		string text = string.Join(base.Delimiter, from object x in base.SelectedItems
			select GetItemDisplayValue(x));
		if (string.IsNullOrEmpty(Text) || !Text.Equals(text))
		{
			_ignoreTextValueChanged = true;
			((DependencyObject)this).SetCurrentValue(TextProperty, (object)text);
			_ignoreTextValueChanged = false;
		}
	}

	private void UpdateDisplayMemberPathValuesBindings()
	{
		_displayMemberPathValuesChangeHelper.UpdateValueSource(base.ItemsCollection, base.DisplayMemberPath);
	}

	private void OnDisplayMemberPathValuesChanged()
	{
		UpdateText();
	}

	private void UpdateFromText()
	{
		List<string> selectedValues = null;
		if (!string.IsNullOrEmpty(Text))
		{
			selectedValues = Text.Replace(" ", string.Empty).Split(new string[1] { base.Delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
		}
		UpdateFromList(selectedValues, GetItemDisplayValue);
	}

	protected object GetItemDisplayValue(object item)
	{
		if (string.IsNullOrEmpty(base.DisplayMemberPath))
		{
			return item;
		}
		string[] array = base.DisplayMemberPath.Split('.');
		if (array.Length == 1)
		{
			PropertyInfo property = item.GetType().GetProperty(base.DisplayMemberPath);
			if (property != null)
			{
				return property.GetValue(item, null);
			}
			return item;
		}
		for (int i = 0; i < array.Count(); i++)
		{
			PropertyInfo property2 = item.GetType().GetProperty(array[i]);
			if (property2 == null)
			{
				return item;
			}
			if (i == array.Count() - 1)
			{
				return property2.GetValue(item, null);
			}
			item = property2.GetValue(item, null);
		}
		return item;
	}

	private void CloseDropDown(bool isFocusOnComboBox)
	{
		if (IsDropDownOpen)
		{
			IsDropDownOpen = false;
		}
		ReleaseMouseCapture();
		if (isFocusOnComboBox)
		{
			Focus();
		}
	}
}
