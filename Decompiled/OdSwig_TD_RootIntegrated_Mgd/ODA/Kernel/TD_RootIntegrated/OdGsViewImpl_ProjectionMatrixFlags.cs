using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGsViewImpl_ProjectionMatrixFlags
{
	kProjectionIncludeDept = 1,
	kProjectionIncludeClip = 2,
	kProjectionIncludePerspective = 4,
	kProjectionIncludeRotation = 8,
	kProjectionIncludeAll = 0xF,
	kProjectionIncludeAllNoDept = 0xE
}
