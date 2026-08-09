using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsGeodesicDriveInputType
{
	TmbGditMachining,
	TmbGditSurface,
	TmbGditCenter,
	TmbGditUserDefined,
	TmbGditUserDefinedMesh
}
