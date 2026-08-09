using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum LeadExtensionParamsType
{
	TpNone,
	TpTangentialLine,
	TpHorizontalTangArc,
	TpVerticalTangArc,
	TpOrthogonalLine,
	TpSlantLine
}
