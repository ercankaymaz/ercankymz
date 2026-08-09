using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum LeadParamsProfileRampDefinitionMode
{
	PrdmByAngle,
	PrdmByLength,
	PrdmByLengthAndWidth
}
