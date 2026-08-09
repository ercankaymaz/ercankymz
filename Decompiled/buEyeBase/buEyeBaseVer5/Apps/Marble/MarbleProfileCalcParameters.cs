using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleProfileCalcParameters
{
	public double PlungeSpeed = 40.0;

	public double ForwardCutSpeed = 40.0;

	public double BackwardSpeed = 40.0;

	public double SafeDistance = 100.0;

	public double RapidDistance = 50.0;

	public bool ZigzagMode = true;

	public bool MoveUpSafe = true;

	public MarbleCamAreaMode RoughAreaMode = MarbleCamAreaMode.Level;

	public bool isRough = false;

	public bool isFinish = false;

	public bool isOffset = false;

	public MarbleProfileCalcParameters()
	{
	}

	public MarbleProfileCalcParameters(double plungespeed, double fwdcutspeed, double bwdcutspeed, double safedis, double rapiddis, bool zigzagmode, MarbleCamAreaMode areamode, bool moveupsafedis, bool isrough, bool isfinish, bool isoffset)
	{
		isOffset = isoffset;
		isFinish = isfinish;
		isOffset = isoffset;
		PlungeSpeed = plungespeed;
		ForwardCutSpeed = fwdcutspeed;
		BackwardSpeed = bwdcutspeed;
		SafeDistance = safedis;
		RapidDistance = rapiddis;
		ZigzagMode = zigzagmode;
		RoughAreaMode = areamode;
		MoveUpSafe = moveupsafedis;
	}
}
