using System;
using System.ComponentModel;
using DevAge.ComponentModel.Converter;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBoxCurrency : TextBoxNumeric
{
	public TextBoxCurrency(Type p_Type)
		: base(p_Type)
	{
		base.TypeConverter = new CurrencyTypeConverter(p_Type);
	}
}
