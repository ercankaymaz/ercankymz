using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class SourceComboBoxEditor : ComboBoxEditor
{
	internal static string ComboBoxNullValue = "Null";

	private ICollection _collection;

	private TypeConverter _typeConverter;

	public SourceComboBoxEditor(ICollection collection, TypeConverter typeConverter)
	{
		ICollection collection2;
		if (!(typeConverter is NullableConverter))
		{
			collection2 = collection;
		}
		else
		{
			ICollection collection3 = (from object x in collection
				select x ?? ComboBoxNullValue).ToArray();
			collection2 = collection3;
		}
		_collection = collection2;
		_typeConverter = typeConverter;
	}

	protected override IEnumerable CreateItemsSource(PropertyItem propertyItem)
	{
		return _collection;
	}

	protected override IValueConverter CreateValueConverter()
	{
		if (_typeConverter != null)
		{
			if (_typeConverter is StringConverter)
			{
				return new SourceComboBoxEditorStringConverter(_typeConverter);
			}
			if (_typeConverter is NullableConverter)
			{
				return new SourceComboBoxEditorNullableConverter();
			}
		}
		return null;
	}
}
