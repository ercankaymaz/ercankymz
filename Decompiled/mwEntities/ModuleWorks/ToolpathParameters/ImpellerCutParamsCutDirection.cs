using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ImpellerCutParamsCutDirection
{
	CdZigStartFromLeadEdge,
	CdZigStartFromTrailEdge,
	CdZigZagStartFromLeadEdge,
	CdZigZagStartFromTrailEdge,
	CdHelicalStartFromLeadingEdge,
	CdHelicalStartFromTrailingEdge
}
