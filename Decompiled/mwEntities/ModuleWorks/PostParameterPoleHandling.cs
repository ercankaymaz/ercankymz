using System;

namespace ModuleWorks;

[Serializable]
public enum PostParameterPoleHandling
{
	FreezeAngleAroundPole,
	UseRotationAngleAroundPole,
	LinearInterpolation,
	SmoothInterpolation,
	ForceTableRotation,
	FindHeadOrTableFixPosition
}
