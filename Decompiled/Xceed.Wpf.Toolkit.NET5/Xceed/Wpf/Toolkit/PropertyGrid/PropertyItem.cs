using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

[TemplatePart(Name = "content", Type = typeof(ContentControl))]
public class PropertyItem : CustomPropertyItem
{
	private class InvalidValueValidationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			return new ValidationResult(isValid: false, null);
		}
	}

	public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(PropertyItem), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsReadOnlyChanged)));

	public static readonly DependencyProperty IsInvalidProperty = DependencyProperty.Register("IsInvalid", typeof(bool), typeof(PropertyItem), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsInvalidChanged)));

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

	public bool IsInvalid
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsInvalidProperty);
		}
		internal set
		{
			((DependencyObject)this).SetValue(IsInvalidProperty, (object)value);
		}
	}

	public PropertyDescriptor PropertyDescriptor { get; internal set; }

	public string PropertyName
	{
		get
		{
			if (DescriptorDefinition == null)
			{
				return null;
			}
			return DescriptorDefinition.PropertyName;
		}
	}

	public Type PropertyType
	{
		get
		{
			if (PropertyDescriptor == null)
			{
				return null;
			}
			return PropertyDescriptor.PropertyType;
		}
	}

	internal DescriptorPropertyDefinitionBase DescriptorDefinition { get; private set; }

	public object Instance { get; internal set; }

	private static void OnIsReadOnlyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyItem propertyItem)
		{
			propertyItem.OnIsReadOnlyChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsReadOnlyChanged(bool oldValue, bool newValue)
	{
		if (base.IsLoaded)
		{
			RebuildEditor();
		}
	}

	private static void OnIsInvalidChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is PropertyItem propertyItem)
		{
			propertyItem.OnIsInvalidChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsInvalidChanged(bool oldValue, bool newValue)
	{
		BindingExpression bindingExpression = GetBindingExpression(CustomPropertyItem.ValueProperty);
		if (newValue)
		{
			ValidationError validationError = new ValidationError(new InvalidValueValidationRule(), bindingExpression);
			validationError.ErrorContent = "Value could not be converted.";
			Validation.MarkInvalid(bindingExpression, validationError);
		}
		else
		{
			Validation.ClearInvalid(bindingExpression);
		}
	}

	protected override string GetPropertyItemName()
	{
		return PropertyName;
	}

	protected override Type GetPropertyItemType()
	{
		return PropertyType;
	}

	protected override void OnIsExpandedChanged(bool oldValue, bool newValue)
	{
		if (newValue && base.IsLoaded)
		{
			GenerateExpandedPropertyItems();
		}
	}

	protected override object OnCoerceValueChanged(object baseValue)
	{
		BindingExpression bindingExpression = GetBindingExpression(CustomPropertyItem.ValueProperty);
		SetRedInvalidBorder(bindingExpression);
		return baseValue;
	}

	protected override void OnValueChanged(object oldValue, object newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		if (newValue == null && DescriptorDefinition != null && DescriptorDefinition.DefaultValue != null)
		{
			((DependencyObject)this).SetCurrentValue(CustomPropertyItem.ValueProperty, DescriptorDefinition.DefaultValue);
		}
	}

	internal void SetRedInvalidBorder(BindingExpression be)
	{
		if (be == null || !(be.DataItem is DescriptorPropertyDefinitionBase))
		{
			return;
		}
		((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)5, (Delegate)(Action)delegate
		{
			if (be.DataItem is DescriptorPropertyDefinitionBase element && Validation.GetHasError((DependencyObject)(object)element))
			{
				ReadOnlyObservableCollection<ValidationError> errors = Validation.GetErrors((DependencyObject)(object)element);
				Validation.MarkInvalid(be, errors[0]);
			}
		});
	}

	internal void RebuildEditor()
	{
		FrameworkElement frameworkElement = (base.ContainerHelper as ObjectContainerHelperBase).GenerateChildrenEditorElement(this);
		if (frameworkElement != null)
		{
			ContainerHelperBase.SetIsGenerated((DependencyObject)(object)frameworkElement, value: true);
			base.Editor = frameworkElement;
			BindingExpression bindingExpression = GetBindingExpression(CustomPropertyItem.ValueProperty);
			if (bindingExpression != null)
			{
				bindingExpression.UpdateSource();
				SetRedInvalidBorder(bindingExpression);
			}
		}
	}

	private void OnDefinitionContainerHelperInvalidated(object sender, EventArgs e)
	{
		if (base.ContainerHelper != null)
		{
			base.ContainerHelper.ClearHelper();
		}
		ObjectContainerHelperBase objectContainerHelperBase = (ObjectContainerHelperBase)(base.ContainerHelper = DescriptorDefinition.CreateContainerHelper(this));
		if (base.IsExpanded)
		{
			objectContainerHelperBase.GenerateProperties();
		}
	}

	private void Init(DescriptorPropertyDefinitionBase definition)
	{
		if (definition == null)
		{
			throw new ArgumentNullException("definition");
		}
		if (base.ContainerHelper != null)
		{
			base.ContainerHelper.ClearHelper();
		}
		DescriptorDefinition = definition;
		base.ContainerHelper = definition.CreateContainerHelper(this);
		definition.ContainerHelperInvalidated += OnDefinitionContainerHelperInvalidated;
		base.Loaded += PropertyItem_Loaded;
	}

	private void GenerateExpandedPropertyItems()
	{
		if (base.IsExpanded && base.ContainerHelper is ObjectContainerHelperBase objectContainerHelperBase)
		{
			objectContainerHelperBase.GenerateProperties();
		}
	}

	private void PropertyItem_Loaded(object sender, RoutedEventArgs e)
	{
		GenerateExpandedPropertyItems();
	}

	internal PropertyItem(DescriptorPropertyDefinitionBase definition)
		: base(definition.IsPropertyGridCategorized, !definition.PropertyType.IsArray)
	{
		Init(definition);
	}
}
