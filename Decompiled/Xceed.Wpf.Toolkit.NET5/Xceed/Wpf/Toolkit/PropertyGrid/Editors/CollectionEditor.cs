using System;
using System.Collections.Generic;
using System.Windows;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class CollectionEditor : TypeEditor<CollectionControlButton>
{
	protected override void SetValueDependencyProperty()
	{
		base.ValueProperty = CollectionControlButton.ItemsSourceProperty;
	}

	protected override CollectionControlButton CreateEditor()
	{
		return new PropertyGridEditorCollectionControl();
	}

	protected override void SetControlProperties(PropertyItem propertyItem)
	{
		PropertyGrid parentPropertyGrid = GetParentPropertyGrid(propertyItem.ParentElement);
		if (parentPropertyGrid != null)
		{
			base.Editor.EditorDefinitions = parentPropertyGrid.EditorDefinitions;
			base.Editor.CollectionUpdated += Editor_CollectionUpdated;
		}
	}

	private PropertyGrid GetParentPropertyGrid(FrameworkElement element)
	{
		PropertyGrid propertyGrid = element as PropertyGrid;
		if (propertyGrid == null)
		{
			PropertyItem propertyItem = element as PropertyItem;
			while (propertyItem != null && propertyGrid == null)
			{
				propertyGrid = propertyItem.ParentElement as PropertyGrid;
				if (propertyGrid == null)
				{
					propertyItem = propertyItem.ParentElement as PropertyItem;
				}
			}
		}
		return propertyGrid;
	}

	private void Editor_CollectionUpdated(object sender, RoutedEventArgs e)
	{
		if (sender is PropertyGridEditorCollectionControl { DataContext: PropertyItem dataContext })
		{
			GetParentPropertyGrid(dataContext.ParentElement)?.RaiseEvent(new PropertyValueChangedEventArgs(PropertyGrid.PropertyValueChangedEvent, dataContext, null, dataContext.Instance));
		}
	}

	protected override void ResolveValueBinding(PropertyItem propertyItem)
	{
		Type propertyType = propertyItem.PropertyType;
		base.Editor.ItemsSourceType = propertyType;
		if (propertyType.BaseType == typeof(Array))
		{
			base.Editor.NewItemTypes = new List<Type> { propertyType.GetElementType() };
		}
		else if (propertyItem.DescriptorDefinition != null && propertyItem.DescriptorDefinition.NewItemTypes != null && propertyItem.DescriptorDefinition.NewItemTypes.Count > 0)
		{
			base.Editor.NewItemTypes = propertyItem.DescriptorDefinition.NewItemTypes;
		}
		else
		{
			Type[] dictionaryItemsType = ListUtilities.GetDictionaryItemsType(propertyType);
			if (dictionaryItemsType != null && dictionaryItemsType.Length == 2)
			{
				Type item = ListUtilities.CreateEditableKeyValuePairType(dictionaryItemsType[0], dictionaryItemsType[1]);
				base.Editor.NewItemTypes = new List<Type> { item };
			}
			else
			{
				Type listItemType = ListUtilities.GetListItemType(propertyType);
				if (listItemType != null)
				{
					base.Editor.NewItemTypes = new List<Type> { listItemType };
				}
				else
				{
					Type collectionItemType = ListUtilities.GetCollectionItemType(propertyType);
					if (collectionItemType != null)
					{
						base.Editor.NewItemTypes = new List<Type> { collectionItemType };
					}
				}
			}
		}
		base.ResolveValueBinding(propertyItem);
	}
}
