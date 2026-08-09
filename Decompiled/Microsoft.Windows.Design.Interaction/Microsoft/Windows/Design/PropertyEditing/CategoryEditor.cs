using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.PropertyEditing;

public abstract class CategoryEditor
{
	public abstract string TargetCategory { get; }

	public abstract DataTemplate EditorTemplate { get; }

	public abstract bool ConsumesProperty(PropertyEntry propertyEntry);

	public abstract object GetImage(Size desiredSize);

	public static EditorAttribute CreateEditorAttribute(CategoryEditor editor)
	{
		if (editor == null)
		{
			throw new ArgumentNullException("editor");
		}
		return CreateEditorAttribute(editor.GetType());
	}

	public static EditorAttribute CreateEditorAttribute(Type categoryEditorType)
	{
		if ((object)categoryEditorType == null)
		{
			throw new ArgumentNullException("categoryEditorType");
		}
		if (!typeof(CategoryEditor).IsAssignableFrom(categoryEditorType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ArgIncorrectType, new object[2]
			{
				"categoryEditorType",
				typeof(CategoryEditor).Name
			}));
		}
		return new EditorAttribute(categoryEditorType, categoryEditorType);
	}
}
