using System;

namespace ModuleWorks;

[Serializable]
public enum CollisionDetectionMode
{
	KeepThisFirstValue,
	DiscreteChecking,
	RTCPContinousCheckToolContainingPairs,
	NonRTCPCheckToolContainingPairs,
	NonRTCPContinousCheckAllPair,
	KeepThisLastValue
}
