using System;

namespace Xceed.Wpf.AvalonDock.Layout;

[Flags]
public enum AnchorableShowStrategy : byte
{
	Most = 1,
	Left = 2,
	Right = 4,
	Top = 0x10,
	Bottom = 0x20
}
