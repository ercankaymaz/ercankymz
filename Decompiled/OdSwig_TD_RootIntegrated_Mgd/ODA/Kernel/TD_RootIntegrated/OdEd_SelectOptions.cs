using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdEd_SelectOptions
{
	kSelDefault = 0,
	kSelPickLastPoint = 1,
	kSelSingleEntity = 2,
	kSelIgnorePickFirst = 4,
	kSelSinglePass = 8,
	kSelAllowEmpty = 0x10,
	kSelRemove = 0x20,
	kSelLeaveHighlighted = 0x40,
	kSelAllowInactSpaces = 0x80,
	kSelAllowObjects = 0x100,
	kSelAllowPSVP = 0x200,
	kSelAllowSubents = 0x400,
	kSelAllowLocked = 0x800,
	kSelAllowSubentsAlways = 0x1000
}
