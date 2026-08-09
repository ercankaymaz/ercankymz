using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(SeparatorStyleConverter))]
public enum SeparatorStyle
{
	LowProfile,
	HighProfile,
	HighInternalProfile,
	Custom1
}
