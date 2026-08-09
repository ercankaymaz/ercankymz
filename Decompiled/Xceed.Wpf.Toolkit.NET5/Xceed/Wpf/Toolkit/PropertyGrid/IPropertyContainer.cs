using System.ComponentModel;
using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal interface IPropertyContainer
{
	ContainerHelperBase ContainerHelper { get; }

	Style PropertyContainerStyle { get; }

	EditorDefinitionCollection EditorDefinitions { get; }

	PropertyDefinitionCollection PropertyDefinitions { get; }

	bool IsCategorized { get; }

	bool IsSortedAlphabetically { get; }

	bool AutoGenerateProperties { get; }

	bool HideInheritedProperties { get; }

	FilterInfo FilterInfo { get; }

	bool? IsPropertyVisible(PropertyDescriptor pd);
}
