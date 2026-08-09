using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDbRenderGlobal_Procedure
{
	krView = 0,
	krCrop = 1,
	krSelected = 2
}
