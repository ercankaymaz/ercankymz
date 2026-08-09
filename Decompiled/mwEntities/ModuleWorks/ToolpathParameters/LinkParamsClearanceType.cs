using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum LinkParamsClearanceType
{
	ClearancePlane,
	ClearanceCylinder,
	ClearanceSphere,
	ClearanceAutomatic,
	ClearanceCone,
	ClearanceSurfaces,
	LastType
}
