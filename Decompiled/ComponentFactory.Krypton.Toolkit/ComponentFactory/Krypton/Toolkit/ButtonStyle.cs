using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(ButtonStyleConverter))]
public enum ButtonStyle
{
	Standalone,
	Alternate,
	LowProfile,
	ButtonSpec,
	BreadCrumb,
	CalendarDay,
	Cluster,
	Gallery,
	NavigatorStack,
	NavigatorOverflow,
	NavigatorMini,
	InputControl,
	ListItem,
	Form,
	FormClose,
	Command,
	Custom1,
	Custom2,
	Custom3
}
