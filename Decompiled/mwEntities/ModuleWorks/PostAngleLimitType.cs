using System;

namespace ModuleWorks;

[Serializable]
public enum PostAngleLimitType
{
	NoLimit,
	Between0And360,
	BetweenMin180AndPlus180,
	ValuesBasedOnMachineLimits,
	CustomValues
}
