using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamSettings : buSerilization5
{
	public double RegenDeviation = 0.05;

	public double MaxDevideLen = 2.0;

	public double AngleLimitOnlyCRotation = 20.0;

	public bool ShowOperationInfo = false;

	public double DirectionArrowHeadLength = 20.0;

	public double DirectionArrowHeadAngle = 20.0;

	public double StartPointDiameter = 8.0;

	public double LastPointDiameter = 5.0;

	public double EqualValue = 2.0;

	public double TangentMaxAngle = 0.0;

	public double TangentMinAngle = 0.0;

	public double GCodeRegenDEviation = 0.01;

	public bool ContiniousTangent = false;

	public double PatternDistancesWidth = 5.0;

	public double PatternDistancesHeight = 5.0;

	public double PartDistances = 5.0;

	public double EntryFeed = 1000.0;

	public double CuttingFeed = 1000.0;

	public double LeaveFeed = 1000.0;

	public double CRotationFeed = 5000.0;

	public double ConnectionFeed = 5000.0;

	public double BlockSpace = 5.0;

	public double LeadInLength = 10.0;

	public double LeadOutLength = 10.0;

	public FoamSequenceHor SequenceHorizontal = FoamSequenceHor.HorizontalStartThenEnd;

	public FoamSequenceVer SequenceVertical = FoamSequenceVer.VerticalStartThenEnd;

	public UpToDownType ZDirection = UpToDownType.DownToUp;

	public bool ComplateClosedDrawingAfterFirstSelect = false;

	public bool RotateCBeforeCutting = true;

	public bool FromFileKeepRatio = true;

	public bool NonLinearCAxis = false;

	public bool LeaveAlwaysFromStart = true;

	public double LeaveAlwaysZeroZOffsetFromBlockHeight = 10.0;

	public bool MoveZUpPosition = true;

	public bool Draw3D = true;

	public bool UseG1InsteadOfG0 = true;

	public bool UseCRotationAsG0Always = true;

	public bool UseMultiColor = true;

	public bool CheckFoamSize = true;

	public bool CheckMachineSize = true;

	public bool UseRadiusFeedTable = true;

	public bool UseLengthFeedTable = true;

	public bool ShowInfoAtGCodes = true;

	public double CAngleOffset = 0.0;

	public double MachineInitialAngle = 0.0;

	public double MachineLimitX = 4000.0;

	public double MachineLimitY = 2500.0;

	public double MachineLimitZ = 3000.0;

	public double MachineLimitMinX = 0.0;

	public double MachineLimitMinY = 0.0;

	public double MachineLimitMinZ = 15.0;

	public double MachineG0Speed = 100.0;

	public double MachineG0TangentSpeed = 200.0;

	public string pathFromFile = "C:\\";

	public int FoamBaseTransparency = 150;

	public double OnlineBorderDrawOffset = 1.0;

	public Color FoamBaseColor = Color.Gray;

	public Color MarkColor = Color.DarkOrange;

	public Color MarkLastColor = Color.Lavender;

	public Color SortUpperColor = Color.Red;

	public Color SortCutColor = Color.Blue;

	public Color LeadInColor = Color.Lime;

	public Color LeadOutColor = Color.DarkMagenta;

	public Color ConenctionColor = Color.Cyan;

	public Color LimitExceedColor = Color.Pink;

	public Color RotationMoreThen180 = Color.DeepPink;

	public LengthUnit UnitLength = LengthUnit.mm;

	public SpeedUnit UnitSpeed = SpeedUnit.mmPerSec;

	public ProfileOperationWindowType OperationWindow = ProfileOperationWindowType.AutoHideDock;

	public ProfileOperationWindowCloseType OperationWindowClose = ProfileOperationWindowCloseType.Hide;

	public FoamSettings()
	{
	}

	public FoamSettings(FoamSettings data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
