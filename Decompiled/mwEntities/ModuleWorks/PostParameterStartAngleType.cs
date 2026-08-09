using System;

namespace ModuleWorks;

[Serializable]
public enum PostParameterStartAngleType
{
	SelectBetweenTwoSolutions,
	UseFirstRotationAngle,
	UseSecondRotationAngle,
	ProvideAxis,
	UseThirdRotationAngle
}
