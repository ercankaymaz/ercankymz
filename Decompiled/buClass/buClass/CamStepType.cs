using System;

namespace buClass;

[Serializable]
public enum CamStepType
{
	StartToDistanceByCount,
	StartToEndByCount,
	StartToEndByStep,
	StartToDistanceByStep,
	StartByCountAndStep,
	StartToDistanceByTrueStep
}
