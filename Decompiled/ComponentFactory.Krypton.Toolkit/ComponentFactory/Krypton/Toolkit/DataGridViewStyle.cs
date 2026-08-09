using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(DataGridViewStyleConverter))]
public enum DataGridViewStyle
{
	List,
	Sheet,
	Custom1,
	Mixed
}
