using System;

namespace buClass;

[Serializable]
public enum SimulationCommands
{
	Start,
	Stop,
	Pause,
	Previous,
	Next,
	StepChanged
}
