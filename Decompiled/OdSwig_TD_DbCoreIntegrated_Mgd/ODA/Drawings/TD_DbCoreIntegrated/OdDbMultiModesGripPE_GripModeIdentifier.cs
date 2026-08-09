using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbMultiModesGripPE_GripModeIdentifier
{
	kNone = 0,
	kMove = 1,
	kCustomStart = 0x64
}
