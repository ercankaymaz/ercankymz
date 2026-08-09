using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum CutterRadiusCompParamsCompensationType
{
	CtInComputer,
	CtInControl,
	CtWear,
	CtInverseWear,
	CtOff
}
