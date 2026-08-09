using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum OpticParamsSurfaceType
{
	StNurbs,
	StPointgrid,
	StParametric,
	StRotationalProfile,
	StRadialPointgrid,
	StPointProfile
}
