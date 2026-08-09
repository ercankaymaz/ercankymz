using System;

namespace ACadSharp.Classes;

[Flags]
public enum ProxyFlags : ushort
{
	None = 0,
	EraseAllowed = 1,
	TransformAllowed = 2,
	ColorChangeAllowed = 4,
	LayerChangeAllowed = 8,
	LinetypeChangeAllowed = 0x10,
	LinetypeScaleChangeAllowed = 0x20,
	VisibilityChangeAllowed = 0x40,
	CloningAllowed = 0x80,
	LineweightChangeAllowed = 0x100,
	PlotStyleNameChangeAllowed = 0x200,
	AllOperationsExceptCloningAllowed = 0x37F,
	AllOperationsAllowed = 0x3FF,
	DisablesProxyWarningDialog = 0x400,
	R13FormatProxy = 0x8000
}
