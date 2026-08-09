using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal abstract class DescriptorPropertyDefinitionBase : DependencyObject
{
	private string _category;

	private string _categoryValue;

	private string _description;

	private string _displayName;

	private object _defaultValue;

	private int _displayOrder;

	private bool _expandableAttribute;

	private bool _isReadOnly;

	private IList<Type> _newItemTypes;

	private IEnumerable<CommandBinding> _commandBindings;

	public static readonly DependencyProperty AdvancedOptionsIconProperty = DependencyProperty.Register("AdvancedOptionsIcon", typeof(ImageSource), typeof(DescriptorPropertyDefinitionBase), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty AdvancedOptionsTooltipProperty = DependencyProperty.Register("AdvancedOptionsTooltip", typeof(object), typeof(DescriptorPropertyDefinitionBase), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	public static readonly DependencyProperty IsExpandableProperty = DependencyProperty.Register("IsExpandable", typeof(bool), typeof(DescriptorPropertyDefinitionBase), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(DescriptorPropertyDefinitionBase), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnValueChanged)));

	internal abstract PropertyDescriptor PropertyDescriptor { get; }

	public ImageSource AdvancedOptionsIcon
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(AdvancedOptionsIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedOptionsIconProperty, (object)value);
		}
	}

	public object AdvancedOptionsTooltip
	{
		get
		{
			return ((DependencyObject)this).GetValue(AdvancedOptionsTooltipProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedOptionsTooltipProperty, value);
		}
	}

	public bool IsExpandable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsExpandableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsExpandableProperty, (object)value);
		}
	}

	public string Category
	{
		get
		{
			return _category;
		}
		internal set
		{
			_category = value;
		}
	}

	public string CategoryValue
	{
		get
		{
			return _categoryValue;
		}
		internal set
		{
			_categoryValue = value;
		}
	}

	public IEnumerable<CommandBinding> CommandBindings => _commandBindings;

	public string DisplayName
	{
		get
		{
			return _displayName;
		}
		internal set
		{
			_displayName = value;
		}
	}

	public object DefaultValue
	{
		get
		{
			return _defaultValue;
		}
		set
		{
			_defaultValue = value;
		}
	}

	public string Description
	{
		get
		{
			return _description;
		}
		internal set
		{
			_description = value;
		}
	}

	public int DisplayOrder
	{
		get
		{
			return _displayOrder;
		}
		internal set
		{
			_displayOrder = value;
		}
	}

	public bool IsReadOnly => _isReadOnly;

	public IList<Type> NewItemTypes => _newItemTypes;

	public string PropertyName => PropertyDescriptor.Name;

	public Type PropertyType => PropertyDescriptor.PropertyType;

	internal bool ExpandableAttribute
	{
		get
		{
			return _expandableAttribute;
		}
		set
		{
			_expandableAttribute = value;
			UpdateIsExpandable();
		}
	}

	internal bool IsPropertyGridCategorized { get; set; }

	public object Value
	{
		get
		{
			return ((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, value);
		}
	}

	public event EventHandler ContainerHelperInvalidated;

	internal DescriptorPropertyDefinitionBase(bool isPropertyGridCategorized)
	{
		IsPropertyGridCategorized = isPropertyGridCategorized;
	}

	protected virtual string ComputeCategory()
	{
		return null;
	}

	protected virtual string ComputeCategoryValue()
	{
		return null;
	}

	protected virtual string ComputeDescription()
	{
		return null;
	}

	protected virtual int ComputeDisplayOrder(bool isPropertyGridCategorized)
	{
		return int.MaxValue;
	}

	protected virtual bool ComputeExpandableAttribute()
	{
		return false;
	}

	protected virtual object ComputeDefaultValueAttribute()
	{
		return null;
	}

	protected abstract bool ComputeIsExpandable();

	protected virtual IList<Type> ComputeNewItemTypes()
	{
		return null;
	}

	protected virtual bool ComputeIsReadOnly()
	{
		return false;
	}

	protected virtual bool ComputeCanResetValue()
	{
		return false;
	}

	protected virtual object ComputeAdvancedOptionsTooltip()
	{
		return null;
	}

	protected virtual void ResetValue()
	{
		BindingOperations.GetBindingExpressionBase((DependencyObject)(object)this, ValueProperty)?.UpdateTarget();
	}

	protected abstract void CreateValueBinding();

	internal abstract ObjectContainerHelperBase CreateContainerHelper(IPropertyContainer parent);

	internal void RaiseContainerHelperInvalidated()
	{
		if (this.ContainerHelperInvalidated != null)
		{
			this.ContainerHelperInvalidated(this, EventArgs.Empty);
		}
	}

	internal virtual ITypeEditor CreateDefaultEditor(PropertyItem propertyItem)
	{
		return null;
	}

	internal virtual ITypeEditor CreateAttributeEditor()
	{
		return null;
	}

	internal void UpdateAdvanceOptionsForItem(DependencyObject dependencyObject, DependencyPropertyDescriptor dpDescriptor, out object tooltip)
	{
		tooltip = StringConstants.Default;
		bool flag = false;
		bool num = typeof(Style).IsAssignableFrom(PropertyType);
		flag = typeof(DynamicResourceExtension).IsAssignableFrom(PropertyType);
		if (num || flag)
		{
			tooltip = StringConstants.Resource;
		}
		else if (dependencyObject != null && dpDescriptor != null)
		{
			if (BindingOperations.GetBindingExpressionBase(dependencyObject, dpDescriptor.DependencyProperty) != null)
			{
				tooltip = StringConstants.Databinding;
				return;
			}
			switch (DependencyPropertyHelper.GetValueSource(dependencyObject, dpDescriptor.DependencyProperty).BaseValueSource)
			{
			case BaseValueSource.Inherited:
			case BaseValueSource.DefaultStyle:
			case BaseValueSource.ImplicitStyleReference:
				tooltip = StringConstants.Inheritance;
				break;
			case BaseValueSource.Style:
				tooltip = StringConstants.StyleSetter;
				break;
			case BaseValueSource.Local:
				tooltip = StringConstants.Local;
				break;
			case BaseValueSource.DefaultStyleTrigger:
			case BaseValueSource.TemplateTrigger:
			case BaseValueSource.StyleTrigger:
			case BaseValueSource.ParentTemplate:
			case BaseValueSource.ParentTemplateTrigger:
				break;
			}
		}
		else
		{
			if (object.Equals(Value, DefaultValue))
			{
				return;
			}
			if (DefaultValue != null)
			{
				tooltip = StringConstants.Local;
			}
			else if (PropertyType.IsValueType)
			{
				object objB = Activator.CreateInstance(PropertyType);
				if (!object.Equals(Value, objB))
				{
					tooltip = StringConstants.Local;
				}
			}
			else if (Value != null)
			{
				tooltip = StringConstants.Local;
			}
		}
	}

	internal void UpdateAdvanceOptions()
	{
		AdvancedOptionsTooltip = ComputeAdvancedOptionsTooltip();
	}

	internal void UpdateIsExpandable()
	{
		IsExpandable = ComputeIsExpandable() && ExpandableAttribute;
	}

	internal void UpdateValueFromSource()
	{
		BindingOperations.GetBindingExpressionBase((DependencyObject)(object)this, ValueProperty)?.UpdateTarget();
	}

	internal object ComputeDescriptionForItem(object item)
	{
		PropertyDescriptor propertyDescriptor = item as PropertyDescriptor;
		DisplayAttribute attribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(propertyDescriptor);
		if (attribute != null)
		{
			return attribute.GetDescription();
		}
		DescriptionAttribute attribute2 = PropertyGridUtilities.GetAttribute<DescriptionAttribute>(propertyDescriptor);
		if (attribute2 == null)
		{
			return propertyDescriptor.Description;
		}
		return attribute2.Description;
	}

	internal object ComputeNewItemTypesForItem(object item)
	{
		return PropertyGridUtilities.GetAttribute<NewItemTypesAttribute>(item as PropertyDescriptor)?.Types;
	}

	internal object ComputeDisplayOrderForItem(object item)
	{
		PropertyDescriptor propertyDescriptor = item as PropertyDescriptor;
		DisplayAttribute attribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(PropertyDescriptor);
		if (attribute != null && attribute.GetOrder().HasValue)
		{
			return attribute.GetOrder();
		}
		List<PropertyOrderAttribute> list = propertyDescriptor.Attributes.OfType<PropertyOrderAttribute>().ToList();
		if (list.Count > 0)
		{
			ValidatePropertyOrderAttributes(list);
			if (IsPropertyGridCategorized)
			{
				PropertyOrderAttribute propertyOrderAttribute = list.FirstOrDefault((PropertyOrderAttribute x) => x.UsageContext == UsageContextEnum.Categorized || x.UsageContext == UsageContextEnum.Both);
				if (propertyOrderAttribute != null)
				{
					return propertyOrderAttribute.Order;
				}
			}
			else
			{
				PropertyOrderAttribute propertyOrderAttribute2 = list.FirstOrDefault((PropertyOrderAttribute x) => x.UsageContext == UsageContextEnum.Alphabetical || x.UsageContext == UsageContextEnum.Both);
				if (propertyOrderAttribute2 != null)
				{
					return propertyOrderAttribute2.Order;
				}
			}
		}
		return int.MaxValue;
	}

	internal object ComputeExpandableAttributeForItem(object item)
	{
		return PropertyGridUtilities.GetAttribute<ExpandableObjectAttribute>((PropertyDescriptor)item) != null;
	}

	internal int ComputeDisplayOrderInternal(bool isPropertyGridCategorized)
	{
		return ComputeDisplayOrder(isPropertyGridCategorized);
	}

	internal object GetValueInstance(object sourceObject)
	{
		if (sourceObject is ICustomTypeDescriptor customTypeDescriptor)
		{
			sourceObject = customTypeDescriptor.GetPropertyOwner(PropertyDescriptor);
		}
		return sourceObject;
	}

	internal object ComputeDefaultValueAttributeForItem(object item)
	{
		return PropertyGridUtilities.GetAttribute<DefaultValueAttribute>((PropertyDescriptor)item)?.Value;
	}

	private static void ExecuteResetValueCommand(object sender, ExecutedRoutedEventArgs e)
	{
		PropertyItem propertyItem = e.Parameter as PropertyItem;
		if (propertyItem == null)
		{
			propertyItem = sender as PropertyItem;
		}
		if (propertyItem != null && propertyItem.DescriptorDefinition != null && propertyItem.DescriptorDefinition.ComputeCanResetValue())
		{
			propertyItem.DescriptorDefinition.ResetValue();
		}
	}

	private static void CanExecuteResetValueCommand(object sender, CanExecuteRoutedEventArgs e)
	{
		PropertyItem propertyItem = e.Parameter as PropertyItem;
		if (propertyItem == null)
		{
			propertyItem = sender as PropertyItem;
		}
		e.CanExecute = propertyItem != null && propertyItem.DescriptorDefinition != null && propertyItem.DescriptorDefinition.ComputeCanResetValue();
	}

	private string ComputeDisplayName()
	{
		DisplayAttribute attribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(PropertyDescriptor);
		string text = ((attribute != null) ? attribute.GetName() : PropertyDescriptor.DisplayName);
		ParenthesizePropertyNameAttribute attribute2 = PropertyGridUtilities.GetAttribute<ParenthesizePropertyNameAttribute>(PropertyDescriptor);
		if (attribute2 != null && attribute2.NeedParenthesis)
		{
			text = "(" + text + ")";
		}
		return text;
	}

	private void ValidatePropertyOrderAttributes(List<PropertyOrderAttribute> list)
	{
		if (list.Count > 0 && list.FirstOrDefault((PropertyOrderAttribute x) => x.UsageContext == UsageContextEnum.Both) != null)
		{
			_ = list.Count;
			_ = 1;
		}
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((DescriptorPropertyDefinitionBase)(object)o).OnValueChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	internal virtual void OnValueChanged(object oldValue, object newValue)
	{
		UpdateIsExpandable();
		UpdateAdvanceOptions();
		CommandManager.InvalidateRequerySuggested();
	}

	public virtual void InitProperties()
	{
		_isReadOnly = ComputeIsReadOnly();
		_category = ComputeCategory();
		_categoryValue = ComputeCategoryValue();
		_description = ComputeDescription();
		_displayName = ComputeDisplayName();
		_defaultValue = ComputeDefaultValueAttribute();
		_displayOrder = ComputeDisplayOrder(IsPropertyGridCategorized);
		_expandableAttribute = ComputeExpandableAttribute();
		_newItemTypes = ComputeNewItemTypes();
		_commandBindings = new CommandBinding[1]
		{
			new CommandBinding(PropertyItemCommands.ResetValue, ExecuteResetValueCommand, CanExecuteResetValueCommand)
		};
		CreateValueBinding();
	}
}
