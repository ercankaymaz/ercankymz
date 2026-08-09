using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(PaletteButtonSpecStyleConverter))]
public enum PaletteButtonSpecStyle
{
	Generic,
	Close,
	Context,
	Next,
	Previous,
	ArrowLeft,
	ArrowRight,
	ArrowUp,
	ArrowDown,
	DropDown,
	PinVertical,
	PinHorizontal,
	FormClose,
	FormMin,
	FormMax,
	FormRestore,
	PendantClose,
	PendantMin,
	PendantRestore,
	WorkspaceMaximize,
	WorkspaceRestore,
	RibbonMinimize,
	RibbonExpand
}
