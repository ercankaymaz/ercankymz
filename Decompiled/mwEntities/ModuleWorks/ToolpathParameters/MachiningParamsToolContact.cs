using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsToolContact
{
	RunAuto,
	RunCenter,
	RunRadius,
	RunFront,
	RunAtUserGivePoint,
	RunUserDefined
}
