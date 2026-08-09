using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal class ObjectContainerHelper : ObjectContainerHelperBase
{
	private object _selectedObject;

	private object SelectedObject => _selectedObject;

	public ObjectContainerHelper(IPropertyContainer propertyContainer, object selectedObject)
		: base(propertyContainer)
	{
		_selectedObject = selectedObject;
	}

	protected override string GetDefaultPropertyName()
	{
		if (SelectedObject == null)
		{
			return null;
		}
		return ObjectContainerHelperBase.GetDefaultPropertyName(SelectedObject);
	}

	protected override void GenerateSubPropertiesCore(Action<IEnumerable<PropertyItem>> updatePropertyItemsCallback)
	{
		List<PropertyItem> list = new List<PropertyItem>();
		if (SelectedObject != null)
		{
			try
			{
				new List<PropertyDescriptor>();
				foreach (PropertyDescriptor propertyDescriptor in ObjectContainerHelperBase.GetPropertyDescriptors(SelectedObject, PropertyContainer.HideInheritedProperties))
				{
					PropertyDefinition propertyDefinition = GetPropertyDefinition(propertyDescriptor);
					bool flag = false;
					bool? flag2 = PropertyContainer.IsPropertyVisible(propertyDescriptor);
					if (flag2.HasValue)
					{
						flag = flag2.Value;
					}
					else
					{
						DisplayAttribute attribute = PropertyGridUtilities.GetAttribute<DisplayAttribute>(propertyDescriptor);
						if (attribute != null)
						{
							bool? autoGenerateField = attribute.GetAutoGenerateField();
							flag = PropertyContainer.AutoGenerateProperties && ((autoGenerateField.HasValue && autoGenerateField.Value) || !autoGenerateField.HasValue);
						}
						else
						{
							flag = propertyDescriptor.IsBrowsable && PropertyContainer.AutoGenerateProperties;
						}
						if (propertyDefinition != null)
						{
							flag = propertyDefinition.IsBrowsable ?? flag;
						}
					}
					if (flag)
					{
						PropertyItem propertyItem = CreatePropertyItem(propertyDescriptor, propertyDefinition);
						if (propertyItem != null)
						{
							list.Add(propertyItem);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
		updatePropertyItemsCallback(list);
	}

	private PropertyItem CreatePropertyItem(PropertyDescriptor property, PropertyDefinition propertyDef)
	{
		DescriptorPropertyDefinition descriptorPropertyDefinition = new DescriptorPropertyDefinition(property, SelectedObject, PropertyContainer);
		descriptorPropertyDefinition.InitProperties();
		InitializeDescriptorDefinition(descriptorPropertyDefinition, propertyDef);
		return new PropertyItem(descriptorPropertyDefinition)
		{
			Instance = SelectedObject,
			CategoryOrder = GetCategoryOrder(descriptorPropertyDefinition.CategoryValue),
			WillRefreshPropertyGrid = GetWillRefreshPropertyGrid(property)
		};
	}

	private int GetCategoryOrder(object categoryValue)
	{
		if (categoryValue == null)
		{
			return int.MaxValue;
		}
		int result = int.MaxValue;
		CategoryOrderAttribute categoryOrderAttribute = TypeDescriptor.GetAttributes(SelectedObject).OfType<CategoryOrderAttribute>().FirstOrDefault((CategoryOrderAttribute attribute) => object.Equals(attribute.CategoryValue, categoryValue));
		if (categoryOrderAttribute != null)
		{
			result = categoryOrderAttribute.Order;
		}
		return result;
	}
}
