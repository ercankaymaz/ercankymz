using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDbUndoController_UndoBlockMarkers
{
	kDefault = 0,
	kBlockBegin = 1,
	kBlockEnd = 2,
	kMarker = 3
}
