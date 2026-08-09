using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(InputControlStyleConverter))]
public enum InputControlStyle
{
	Standalone,
	Ribbon,
	Custom1
}
