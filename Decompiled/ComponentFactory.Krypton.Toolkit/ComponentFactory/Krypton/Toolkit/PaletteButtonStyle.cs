using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(PaletteButtonStyleConverter))]
public enum PaletteButtonStyle
{
	Inherit,
	Standalone,
	Alternate,
	LowProfile,
	ButtonSpec,
	BreadCrumb,
	Cluster,
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
