using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit;

public class PrimitiveTypeCollectionControl : ContentControl
{
	private bool _surpressTextChanged;

	private bool _conversionFailed;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty ItemsSourceProperty;

	public static readonly DependencyProperty IsReadOnlyProperty;

	public static readonly DependencyProperty ItemsSourceTypeProperty;

	public static readonly DependencyProperty ItemTypeProperty;

	public static readonly DependencyProperty TextProperty;

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

	public IList ItemsSource
	{
		get
		{
			return (IList)((DependencyObject)this).GetValue(ItemsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsSourceProperty, (object)value);
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

	public Type ItemsSourceType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(ItemsSourceTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsSourceTypeProperty, (object)value);
		}
	}

	public Type ItemType
	{
		get
		{
			return (Type)((DependencyObject)this).GetValue(ItemTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemTypeProperty, (object)value);
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

	private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PrimitiveTypeCollectionControl primitiveTypeCollectionControl)
		{
			primitiveTypeCollectionControl.OnIsOpenChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnItemsSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PrimitiveTypeCollectionControl primitiveTypeCollectionControl)
		{
			primitiveTypeCollectionControl.OnItemsSourceChanged((IList)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (IList)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnItemsSourceChanged(IList oldValue, IList newValue)
	{
		if (newValue != null)
		{
			if (ItemsSourceType == null)
			{
				ItemsSourceType = newValue.GetType();
			}
			if (ItemType == null && newValue.GetType().ContainsGenericParameters)
			{
				ItemType = newValue.GetType().GetGenericArguments()[0];
			}
			SetText(newValue);
		}
	}

	private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PrimitiveTypeCollectionControl primitiveTypeCollectionControl)
		{
			primitiveTypeCollectionControl.OnTextChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnTextChanged(string oldValue, string newValue)
	{
		if (!_surpressTextChanged)
		{
			PersistChanges();
		}
	}

	static PrimitiveTypeCollectionControl()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(PrimitiveTypeCollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsOpenChanged)));
		ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IList), typeof(PrimitiveTypeCollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnItemsSourceChanged)));
		IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(PrimitiveTypeCollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));
		ItemsSourceTypeProperty = DependencyProperty.Register("ItemsSourceType", typeof(Type), typeof(PrimitiveTypeCollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		ItemTypeProperty = DependencyProperty.Register("ItemType", typeof(Type), typeof(PrimitiveTypeCollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(PrimitiveTypeCollectionControl), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnTextChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PrimitiveTypeCollectionControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(PrimitiveTypeCollectionControl)));
	}

	private void PersistChanges()
	{
		IList list = ComputeItemsSource();
		if (list == null)
		{
			return;
		}
		IList list2 = ComputeItems();
		list.Clear();
		int num = 0;
		foreach (object item in list2)
		{
			if (list is Array)
			{
				((Array)list).SetValue(item, num++);
			}
			else
			{
				list.Add(item);
			}
		}
		if (_conversionFailed)
		{
			SetText(list);
		}
	}

	private IList ComputeItems()
	{
		IList list = new List<object>();
		if (ItemType == null)
		{
			return list;
		}
		string[] array = Text.Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			string value = array[i].TrimEnd('\r');
			if (!string.IsNullOrEmpty(value))
			{
				object obj = null;
				try
				{
					obj = ((!ItemType.IsEnum) ? Convert.ChangeType(value, ItemType) : Enum.Parse(ItemType, value));
				}
				catch
				{
					_conversionFailed = true;
				}
				if (obj != null)
				{
					list.Add(obj);
				}
			}
		}
		return list;
	}

	private IList ComputeItemsSource()
	{
		if (ItemsSource == null)
		{
			string text = Text;
			ItemsSource = CreateItemsSource();
			Text = text;
		}
		return ItemsSource;
	}

	private IList CreateItemsSource()
	{
		IList result = null;
		if (ItemsSourceType != null)
		{
			result = (IList)ItemsSourceType.GetConstructor(Type.EmptyTypes).Invoke(null);
		}
		return result;
	}

	private void SetText(IEnumerable collection)
	{
		_surpressTextChanged = true;
		StringBuilder stringBuilder = new StringBuilder();
		foreach (object item in collection)
		{
			stringBuilder.Append(item.ToString());
			stringBuilder.AppendLine();
		}
		Text = stringBuilder.ToString().Trim();
		_surpressTextChanged = false;
	}
}
