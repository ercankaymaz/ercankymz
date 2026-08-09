using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace Xceed.Wpf.Toolkit;

public class CollectionControlDialog : CollectionControlDialogBase, IComponentConnector
{
	private IList originalData = new List<object>();

	public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CollectionControlDialog), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty ItemsSourceTypeProperty = DependencyProperty.Register("ItemsSourceType", typeof(Type), typeof(CollectionControlDialog), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty NewItemTypesProperty = DependencyProperty.Register("NewItemTypes", typeof(IList), typeof(CollectionControlDialog), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(CollectionControlDialog), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty EditorDefinitionsProperty = DependencyProperty.Register("EditorDefinitions", typeof(EditorDefinitionCollection), typeof(CollectionControlDialog), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	internal CollectionControl _collectionControl;

	private bool _contentLoaded;

	public IEnumerable ItemsSource
	{
		get
		{
			return (IEnumerable)((DependencyObject)this).GetValue(ItemsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsSourceProperty, (object)value);
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

	public IList<Type> NewItemTypes
	{
		get
		{
			return (IList<Type>)((DependencyObject)this).GetValue(NewItemTypesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NewItemTypesProperty, (object)value);
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

	public EditorDefinitionCollection EditorDefinitions
	{
		get
		{
			return (EditorDefinitionCollection)((DependencyObject)this).GetValue(EditorDefinitionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditorDefinitionsProperty, (object)value);
		}
	}

	public CollectionControl CollectionControl => _collectionControl;

	public CollectionControlDialog()
	{
		InitializeComponent();
	}

	public CollectionControlDialog(Type itemsourceType)
		: this()
	{
		ItemsSourceType = itemsourceType;
	}

	public CollectionControlDialog(Type itemsourceType, IList<Type> newItemTypes)
		: this(itemsourceType)
	{
		NewItemTypes = newItemTypes;
	}

	protected override void OnSourceInitialized(EventArgs e)
	{
		base.OnSourceInitialized(e);
		if (ItemsSource == null)
		{
			return;
		}
		foreach (object item in ItemsSource)
		{
			originalData.Add(Clone(item));
		}
	}

	private void OkButton_Click(object sender, RoutedEventArgs e)
	{
		if (ItemsSource is IDictionary && !AreDictionaryKeysValid())
		{
			MessageBox.Show("All dictionary items should have distinct non-null Key values.", "Warning");
			return;
		}
		base.DialogResult = _collectionControl.PersistChanges();
		Close();
	}

	private void CancelButton_Click(object sender, RoutedEventArgs e)
	{
		_collectionControl.PersistChanges(originalData);
		base.DialogResult = false;
		Close();
	}

	[SecuritySafeCritical]
	private object Clone(object source)
	{
		if (source == null)
		{
			return null;
		}
		object obj = null;
		Type type = source.GetType();
		if (source is Array)
		{
			obj = (source as Array).Clone();
		}
		else if (ItemsSource is IDictionary && type.IsGenericType && typeof(KeyValuePair<, >).IsAssignableFrom(type.GetGenericTypeDefinition()))
		{
			obj = GenerateEditableKeyValuePair(source);
		}
		else
		{
			try
			{
				obj = FormatterServices.GetUninitializedObject(type);
			}
			catch (Exception)
			{
			}
			ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
			if (constructor != null)
			{
				constructor.Invoke(obj, null);
			}
			else
			{
				obj = source;
			}
		}
		if (obj != null)
		{
			PropertyInfo[] array = (typeof(ICollection).IsAssignableFrom(type) ? type.GetProperties(BindingFlags.Instance | BindingFlags.Public) : type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public));
			foreach (PropertyInfo propertyInfo in array)
			{
				try
				{
					if (!propertyInfo.CanWrite)
					{
						continue;
					}
					if (propertyInfo.GetIndexParameters().GetLength(0) == 0)
					{
						object value = propertyInfo.GetValue(source, null);
						GenerateValue(propertyInfo, value, obj);
						continue;
					}
					PropertyInfo property = type.GetProperty("Count");
					if (!(property != null))
					{
						continue;
					}
					int? num = property.GetValue(source, null) as int?;
					if (num.HasValue && num.HasValue)
					{
						for (int j = 0; j < num.Value; j++)
						{
							object value2 = propertyInfo.GetValue(source, new object[1] { j });
							GenerateValue(propertyInfo, value2, obj, isIndexed: true);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		return obj;
	}

	private void GenerateValue(PropertyInfo propertyInfo, object propertyInfoValue, object result, bool isIndexed = false)
	{
		if (IsCyclingDependency(propertyInfoValue))
		{
			return;
		}
		if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(Transform) && propertyInfo.PropertyType != typeof(ControlTemplate) && !propertyInfo.PropertyType.Equals(typeof(string)))
		{
			if (propertyInfo.PropertyType.IsGenericType)
			{
				Type type = propertyInfo.PropertyType.GetGenericArguments().FirstOrDefault();
				if (type != null && !type.IsPrimitive && !type.Equals(typeof(string)) && !type.IsEnum)
				{
					object value = Clone(propertyInfoValue);
					propertyInfo.SetValue(result, value, null);
				}
				else
				{
					propertyInfo.SetValue(result, propertyInfoValue, null);
				}
				return;
			}
			object obj = Clone(propertyInfoValue);
			if (obj != null)
			{
				if (isIndexed)
				{
					result.GetType().GetMethod("Add").Invoke(result, new object[1] { obj });
				}
				else
				{
					propertyInfo.SetValue(result, obj, null);
				}
			}
		}
		else if (isIndexed)
		{
			result.GetType().GetMethod("Add").Invoke(result, new object[1] { propertyInfoValue });
		}
		else
		{
			propertyInfo.SetValue(result, propertyInfoValue, null);
		}
	}

	private bool IsCyclingDependency(object propertyInfoValue)
	{
		if (propertyInfoValue == null)
		{
			return false;
		}
		if (propertyInfoValue == ItemsSource)
		{
			return true;
		}
		foreach (object item in ItemsSource)
		{
			if (propertyInfoValue == item)
			{
				return true;
			}
		}
		return false;
	}

	private object GenerateEditableKeyValuePair(object source)
	{
		Type type = source.GetType();
		if (type.GetGenericArguments() == null || type.GetGenericArguments().GetLength(0) != 2)
		{
			return null;
		}
		PropertyInfo property = type.GetProperty("Key");
		PropertyInfo property2 = type.GetProperty("Value");
		if (property != null && property2 != null)
		{
			return ListUtilities.CreateEditableKeyValuePair(property.GetValue(source, null), type.GetGenericArguments()[0], property2.GetValue(source, null), type.GetGenericArguments()[1]);
		}
		return null;
	}

	private bool AreDictionaryKeysValid()
	{
		IEnumerable<object> source = _collectionControl.Items.Select(delegate(object x)
		{
			PropertyInfo property = x.GetType().GetProperty("Key");
			return (property != null) ? property.GetValue(x, null) : null;
		});
		if (source.Distinct().Count() == _collectionControl.Items.Count)
		{
			return source.All((object x) => x != null);
		}
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri("/Xceed.Wpf.Toolkit.NET5;component/collectioncontrol/implementation/collectioncontroldialog.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "7.0.5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			_collectionControl = (CollectionControl)target;
			break;
		case 2:
			((Button)target).Click += OkButton_Click;
			break;
		case 3:
			((Button)target).Click += CancelButton_Click;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
