using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiShellToolkit_ShellToolkitOption
{
	kUnifyVertices = 1,
	kTriangulateHoles = 2,
	kForceTriangulation = 4,
	kKeepInitialData = 8
}
