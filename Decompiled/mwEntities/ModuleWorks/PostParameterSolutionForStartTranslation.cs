using System;

namespace ModuleWorks;

[Serializable]
public enum PostParameterSolutionForStartTranslation
{
	UseFirstPositive,
	UseFirstNegative,
	UseSecondPositive,
	UseSecondNegative,
	UseThirdPositive,
	UseThirdNegative,
	UseCustom
}
