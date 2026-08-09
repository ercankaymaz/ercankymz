using System;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleCamParameterSetArg
{
	public MarbleToolType ToolType = MarbleToolType.Saw;

	public MarbleCamType MarbleCamType = MarbleCamType.Contour;

	public MarbleCamMode MarbleCamMode = MarbleCamMode.Contour;

	public CamType GeneralCamType = CamType.Contour;

	public double ZOffset = 0.0;

	public double SafeDistance = 80.0;

	public double RapidDistance = 25.0;

	public double CuttingVel = 20.0;

	public double PlungeVel = 4.0;

	public double PlungeFirstVel = 2.0;

	public double CuttingStep = 2.0;

	public double CuttingFirstStep = 1.0;

	public double TargetZ = 0.0;

	public double MaterialThickness = 20.0;

	public MarbleCamParameterSetArg()
	{
	}

	public MarbleCamParameterSetArg(int indexEntity, int indexEdge, int iD, int edgeID, int camID)
	{
	}
}
