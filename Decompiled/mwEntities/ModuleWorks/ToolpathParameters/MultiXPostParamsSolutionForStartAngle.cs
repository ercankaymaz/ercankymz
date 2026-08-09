using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MultiXPostParamsSolutionForStartAngle
{
	SsaUseFirstRotationAxisPositive,
	SsaUseFirstRotationAxisNegative,
	SsaUseSecondRotationAxisPositive,
	SsaUseSecondRotationAxisNegative,
	SsaUseThirdRotationAxisPositive,
	SsaUseThirdRotationAxisNegative
}
