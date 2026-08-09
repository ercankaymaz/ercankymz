using System.ComponentModel;
using System.Windows.Forms;
using DevAge.ComponentModel.Converter;

namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TimePicker : DateTimePicker
{
	public new System.Windows.Forms.DateTimePicker Control => base.Control;

	public TimePicker()
		: this("T", new string[1] { "T" })
	{
	}

	public TimePicker(string toStringFormat, string[] p_ParseFormats)
	{
		DateTimeTypeConverter typeConverter = new DateTimeTypeConverter(toStringFormat, p_ParseFormats);
		base.TypeConverter = typeConverter;
	}

	protected override Control CreateControl()
	{
		System.Windows.Forms.DateTimePicker dateTimePicker = new System.Windows.Forms.DateTimePicker();
		dateTimePicker.Format = DateTimePickerFormat.Time;
		dateTimePicker.ShowUpDown = true;
		return dateTimePicker;
	}
}
