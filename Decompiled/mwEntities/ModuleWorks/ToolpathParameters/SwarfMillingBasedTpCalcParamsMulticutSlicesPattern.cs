using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum SwarfMillingBasedTpCalcParamsMulticutSlicesPattern
{
	Morph,
	StepFromTop,
	StepFromBottom,
	AlignWithCuttingPart,
	AlignWithLongestContactLine
}
