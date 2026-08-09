using System;

namespace buClass;

[Serializable]
public enum CamPlungeActionType
{
	None,
	GoDown,
	GoUp,
	GoDownAproach,
	GoUpFirstPoint,
	GoUpLastPoint
}
