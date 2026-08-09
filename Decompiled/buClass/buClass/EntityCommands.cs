using System;

namespace buClass;

[Serializable]
public enum EntityCommands
{
	FirstStep = 1,
	NormalStep,
	LastStep,
	BackwardCut,
	ForwardCut,
	CircularMove,
	NoneCircularMove,
	DontMoveSafe
}
