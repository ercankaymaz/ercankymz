using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdDb_GripStat
{
	kGripsDone = 0,
	kGripsToBeDeleted = 1,
	kDimDataToBeDeleted = 2
}
