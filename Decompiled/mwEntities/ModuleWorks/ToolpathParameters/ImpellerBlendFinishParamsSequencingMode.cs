using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ImpellerBlendFinishParamsSequencingMode
{
	SeqInsideOut,
	SeqOutsideIn,
	SeqSteepLast,
	SeqSteepFirst,
	SeqInsideOutAlt,
	SeqOutsideInAlt
}
