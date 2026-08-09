namespace buClass;

public enum mtAxisCmd
{
	NoCommand = 300,
	McStop,
	McMoveAbsolute,
	McMoveRelative,
	McJog,
	McReset,
	McPower,
	SmcHoming,
	McSetPosition,
	McSetHome,
	AutoPosition,
	WriteDrivePar,
	WriteGainSpeedPar,
	WriteGainPosPar,
	WriteGainCurrentPar,
	WriteGainFeedForwardPar,
	WriteGainSetPointPar,
	WriteGainOtherPar,
	SetScale,
	SetLimits,
	ReadDrivePar
}
