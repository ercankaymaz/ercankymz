using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbLayerState_ImportResult
{
	kImported = 0,
	kAlreadyExists = 1
}
