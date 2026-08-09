using System;

namespace ComponentFactory.Krypton.Toolkit;

[Flags]
public enum TaskDialogButtons
{
	None = 0,
	OK = 1,
	Cancel = 2,
	Yes = 4,
	No = 8,
	Retry = 0x10,
	Close = 0x20
}
