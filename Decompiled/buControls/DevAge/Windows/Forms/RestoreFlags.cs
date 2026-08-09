using System;

namespace DevAge.Windows.Forms;

[Flags]
public enum RestoreFlags
{
	None = 0,
	WindowState = 1,
	Size = 2,
	Location = 4,
	Minimized = 8
}
