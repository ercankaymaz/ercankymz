using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdCmEntityColor_ACIcolorMethod
{
	kACIbyBlock = 0,
	kACIforeground = 7,
	kACIbyLayer = 0x100,
	kACIclear = 0,
	kACIRed = 1,
	kACIYellow = 2,
	kACIGreen = 3,
	kACICyan = 4,
	kACIBlue = 5,
	kACIMagenta = 6,
	kACIWhite = 7,
	kACIstandard = 7,
	kACImaximum = 0xFF,
	kACInone = 0x101,
	kACIminimum = -255
}
