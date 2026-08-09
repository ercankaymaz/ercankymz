using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(HeaderStyleConverter))]
public enum HeaderStyle
{
	Primary,
	Secondary,
	DockInactive,
	DockActive,
	Form,
	Calendar,
	Custom1,
	Custom2
}
