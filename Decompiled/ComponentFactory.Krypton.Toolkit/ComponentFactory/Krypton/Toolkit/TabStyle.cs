using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(TabStyleConverter))]
public enum TabStyle
{
	HighProfile,
	StandardProfile,
	LowProfile,
	OneNote,
	Dock,
	DockAutoHidden,
	Custom1,
	Custom2,
	Custom3
}
