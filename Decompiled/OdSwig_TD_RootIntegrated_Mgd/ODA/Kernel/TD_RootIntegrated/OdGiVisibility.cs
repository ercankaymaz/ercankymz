using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisibility
{
	kOdGiInvisible = 0,
	kOdGiVisible = 1,
	kOdGiSilhouette = 2,
	kOdGiJoint = 4
}
