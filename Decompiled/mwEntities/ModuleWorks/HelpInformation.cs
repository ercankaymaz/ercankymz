using System;
using System.Drawing;

namespace ModuleWorks;

public struct HelpInformation
{
	public int ContextType { get; set; }

	public int ControlType { get; set; }

	public IntPtr ItemHandle { get; set; }

	[CLSCompliant(false)]
	public uint ContextID { get; set; }

	public Point MousePoint { get; set; }

	public bool IsValid { get; set; }
}
