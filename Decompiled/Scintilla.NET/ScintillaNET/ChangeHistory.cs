using System;

namespace ScintillaNET;

[Flags]
public enum ChangeHistory
{
	Disabled = 0,
	Enabled = 1,
	Markers = 2,
	Indicators = 4
}
