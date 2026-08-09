using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(GridStyleConverter))]
public enum GridStyle
{
	List,
	Sheet,
	Custom1
}
