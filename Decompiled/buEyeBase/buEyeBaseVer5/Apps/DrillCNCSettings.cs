using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillCNCSettings : buSerilization5
{
	public double ClamperCatchWidth = 30.0;

	public double ClamperSlotCatchWidth = 25.0;

	public double ClamperCatchWidthForBottom = 30.0;

	public double ClamperBetweenMinDistance = 50.0;

	public double ClamperLength = 180.0;

	public double ClamperOperationMinDistance = 30.0;

	public double ClamperSafeXDistance = 50.0;

	public double ClamperMinCatchXDistance = 40.0;

	public double ClamperCatchDistanceInsideFromMaterial = 30.0;

	public double ClamperFirstPositionOffset = 20.0;

	public double ClamperMillingFirstPositionOffset = 80.0;

	public double ClamperNextDrillExtraMoveDistance = 2.0;

	public double ClamperSingleLimit = 400.0;

	public double ClamperSingleMustLimit = 100.0;

	public double ClamperDualClamperMinLimit = 120.0;

	public double ClamperNextLookOperationDistance = 70.0;

	public double ClamperSmallMaterialCLampMinLengthPersc = 25.0;

	public double ClamperMediumMaterialCLampMinLengthPersc = 50.0;

	public double ClamperBigMaterialCLampMinLengthPersc = 100.0;

	public double ClamperThickness = 15.0;

	public double MaterialSmallLimit = 500.0;

	public double MaterialMediumLimit = 750.0;

	public double MaterialBigLimit = 1000.0;

	public bool MoveSafeDistanceAtClamperSideForTop = false;

	public bool ResetDrillPistonWhileMoveSafeAfterDrill = true;

	public bool SearchVerToolEvenMultiHorDrillAvailableForTop = false;

	public bool SearchVerToolEvenMultiHorDrillAvailableForBottom = false;

	public bool MoveSafeDistanceAtClamperSideForFront = false;

	public bool MoveSafeDistanceAtClamperSideForBack = false;

	public bool MoveSafeDistanceAtClamperSideForLeftRight = false;

	public bool MoveY3AxisToSafeIfOperationAtClamperSideFroBottom = true;

	public bool MirrorCalculationForFront = true;

	public bool MirrorCalculationForBack = true;

	public bool MirrorCalculationForTop = true;

	public bool MoveXYSameTimeForBottom = true;

	public bool LeaveClamperSideWhileClamperChangeForBottom = true;

	public double LeaveYDistanceWhileClamperChangeForBottom = 300.0;

	public bool BackOperationsAlwaysWillLastOperation = true;

	public double SlotClamperSideClamperMoveMinLength = 850.0;

	public bool FindFastestPattern = true;

	public double DoubleHeadWorkTogetherLimit = 200.0;

	public double DrillPlungeFeed = 4000.0;

	public double MillingFeed = 30.0;

	public double MillingPlungeFeed = 15.0;

	public double TopSpindleSpeed = 15000.0;

	public double BottomSpindleSpeed = 15000.0;

	public double distanceSafe = 50.0;

	public double distanceSmallSafe = 15.0;

	public double SlotSawPlungeSpeed = 1000.0;

	public double SlotSawCuttingSpeed = 4000.0;

	public bool SlotSawReverseDirection = false;

	public double SlotSawSafeDistance = 50.0;

	public double SlotSawRapidDistance = 30.0;

	public double ContourMinLimit = 300.0;

	public double ContourMidLimit = 600.0;

	public double MaterialZeroYMinPosition = 200.0;

	public double MaterialZeroYMaxPosition = 400.0;

	public double HorizontalTableTopSurfaceZLimit = 2.0;

	public double MaterialFeedMaxDistance = 1300.0;

	public double ProfilingLeadInDistance = 20.0;

	public double ProfilingLeadOutDistance = 20.0;

	public double ReclineDiameter = 24.0;

	public double ToolPistonVerticalDistance = 60.0;

	public double ToolPistonHorizontalDistance = 75.0;

	public double HorizontalToolHolderWidth = 40.0;

	public double ToolPistonSawDistance = 62.0;

	public double ToolTopSpindlePistonDistance = 85.0;

	public double ToolBottomSpindlePistonDistance = 85.0;

	public double ToolRepeatDistance = 32.0;

	public bool SimulationDevideEnable = true;

	public double SimulationDevideG0Length = 50.0;

	public double SimulationDevideG1Length = 20.0;

	public double SlotMinLengthForBottomSpindleAtClamperArea = 500.0;

	public double SlotMinLengthForTopSpindleAtClamperArea = 350.0;

	public double ContourMinLengthForBottomSpindleAtClamperArea = 500.0;

	public double ContourMinLengthForTopSpindleAtClamperArea = 350.0;

	public double ContourLimitLenForTopSpindleOneMove = 600.0;

	public double ContourLimitLenForBottomSpindleOneMove = 900.0;

	public ClockDirectionType ContourTopDirection = ClockDirectionType.CCW;

	public ClockDirectionType ContourBottomDirection = ClockDirectionType.CCW;

	public double ParkX1 = -1000.0;

	public double ParkX2 = -100.0;

	public double ParkY1 = 1400.0;

	public double ParkY2 = 100.0;

	public double ParkY3 = 500.0;

	public double ParkZ1 = 100.0;

	public double ParkZ2 = 100.0;

	public double ParkZ3 = 90.0;

	public double BottimPressZ1Position = 20.0;

	public double BottimPressZ2Position = 20.0;

	public double X1SafeDistance = 20.0;

	public double X1SmallSafeDistance = 10.0;

	public double X2SafeDistance = 20.0;

	public double X2SmallSafeDistance = 10.0;

	public double Y1SafeDistance = 20.0;

	public double Y1SmallSafeDistance = 10.0;

	public double Y2SafeDistance = 20.0;

	public double Y2SmallSafeDistance = 10.0;

	public double Z1SafeDistance = 140.0;

	public double Z1SmallSafeDistance = 20.0;

	public double Z2SafeDistance = 140.0;

	public double Z2SmallSafeDistance = 20.0;

	public double Z2SupportDistance = 10.0;

	public double Z3SafeDistance = 100.0;

	public double Z3SmallSafeDistance = 20.0;

	public double XSafeDistance = 40.0;

	public double XSmallSafeDistance = 20.0;

	public double YSafeDistance = 40.0;

	public double YSmallSafeDistance = 20.0;

	public double Y1MaxPosition = 1100.0;

	public double Y2MinPosition = -700.0;

	public double BottomDrillPressLimitForEndMaterial = 80.0;

	public double BottomDrillPressDisForY1AndY2FromMatTop = -2.0;

	public double BottomDrillBothY1AndY2PressLimit = 400.0;

	public double BottomDrillPressMinLimit = 100.0;

	public double BottomKorukXMinusDistance = 65.0;

	public double BottomKorukXPlusDistance = 65.0;

	public double BottomKorukYMinusDistance = 100.0;

	public double BottomKorukYPlusDistance = 100.0;

	public double SpindlePensDiameter = 80.0;

	public double TopSpindleYOffsetForBottomOperation = 25.0;

	public double Press61_65YDistanceFromY1Center = -204.0;

	public double Press66_71YDistanceFromY1Center = -284.0;

	public double Press72_74YDistanceFromY1Center = -290.0;

	public double Press77_79YDistanceFromY1Center = -220.0;

	public double Press161_165YDistanceFromY2Center = 204.0;

	public double Press166_171YDistanceFromY2Center = 284.0;

	public double Press172_174YDistanceFromY2Center = 290.0;

	public double Press177_179YDistanceFromY2Center = 220.0;

	public double Y1AndY2MinDistance = 100.0;

	public double Y1AndY2HorizontalToolMinDistance = 150.0;

	public double Y1GroupToolVerticalXOffset = 467.85;

	public double Y1GroupToolVerticalYOffset = 1769.5;

	public double Y1GroupToolVerticalZOffset = 265.1;

	public double Y1GroupToolHorizontalXOffset = 467.85;

	public double Y1GroupToolHorizontalYOffset = 1769.5;

	public double Y1GroupToolHorizontalZOffset = 226.0;

	public double Y1GroupToolMillingZOffset = 265.1;

	public double Y1GroupToolSawZOffset = 265.1;

	public double Y1GroupXOffset = 0.0;

	public double Y1GroupYOffset = 0.0;

	public double Y1GroupZOffset = 0.0;

	public double Y1MinLimit = 400.0;

	public double Y1ToolBlockWidth = 425.0;

	public double Y2GroupToolVerticalXOffset = 12.35;

	public double Y2GroupToolVerticalYOffset = 0.0;

	public double Y2GroupToolVerticalZOffset = 179.13;

	public double Y2GroupToolHorizontalXOffset = 12.35;

	public double Y2GroupToolHorizontalYOffset = 0.0;

	public double Y2GroupToolHorizontalZOffset = 138.13;

	public double Y2GroupToolSawZOffset = 179.13;

	public double Y2GroupXOffset = 0.0;

	public double Y2GroupYOffset = 0.0;

	public double Y2GroupZOffset = 0.0;

	public double Y2MaxLimit = 800.0;

	public double Y2ToolBlockWidth = 350.0;

	public double Y3GroupToolVerticalXOffset = 466.85;

	public double Y3GroupToolVerticalYOffset = 0.0;

	public double Y3GroupToolVerticalZOffset = -70.64;

	public double Y3GroupToolMillingZOffset = -14.64;

	public double Y3GroupXOffset = 0.0;

	public double Y3GroupYOffset = 0.0;

	public double Y3GroupZOffset = 0.0;

	public double Tool61XZeroOffset = 422.0;

	public double Tool62XZeroOffset = 422.0;

	public double Tool63XZeroOffset = 422.0;

	public double Tool64XZeroOffset = 422.0;

	public double Tool65XZeroOffset = 422.0;

	public double Tool66XZeroOffset = 422.0;

	public double Tool67XZeroOffset = 390.01;

	public double Tool68XZeroOffset = 358.02;

	public double Tool69XZeroOffset = 294.05;

	public double Tool70XZeroOffset = 262.06;

	public double Tool71XZeroOffset = 230.07;

	public double Tool72XZeroOffset = 485.97;

	public double Tool73XZeroOffset = 485.97;

	public double Tool74XZeroOffset = 453.98;

	public double Tool75XZeroOffset = 453.98;

	public double Tool76XZeroOffset = 285.07;

	public double Tool77XZeroOffset = 175.07;

	public double Tool78XZeroOffset = 285.07;

	public double Tool79XZeroOffset = 175.07;

	public double Tool80XZeroOffset = 175.07;

	public double Tool85XZeroOffset = 175.07;

	public double Tool270XZeroOffset = 400.0;

	public double Tool61YZeroOffset = 0.0;

	public double Tool62YZeroOffset = 0.0;

	public double Tool63YZeroOffset = 0.0;

	public double Tool64YZeroOffset = 0.0;

	public double Tool65YZeroOffset = 0.0;

	public double Tool66YZeroOffset = 0.0;

	public double Tool67YZeroOffset = 0.0;

	public double Tool68YZeroOffset = 0.0;

	public double Tool69YZeroOffset = 0.0;

	public double Tool70YZeroOffset = 0.0;

	public double Tool71YZeroOffset = 0.0;

	public double Tool72YZeroOffset = 0.0;

	public double Tool73YZeroOffset = 0.0;

	public double Tool74YZeroOffset = 0.0;

	public double Tool75YZeroOffset = 0.0;

	public double Tool76YZeroOffset = 0.0;

	public double Tool77YZeroOffset = 0.0;

	public double Tool78YZeroOffset = 0.0;

	public double Tool79YZeroOffset = 0.0;

	public double Tool80YZeroOffset = 0.0;

	public double Tool85YZeroOffset = 0.0;

	public double Tool161YZeroOffset = 0.0;

	public double Tool162YZeroOffset = 0.0;

	public double Tool163YZeroOffset = 0.0;

	public double Tool164YZeroOffset = 0.0;

	public double Tool165YZeroOffset = 0.0;

	public double Tool166YZeroOffset = 0.0;

	public double Tool167YZeroOffset = 0.0;

	public double Tool168YZeroOffset = 0.0;

	public double Tool169YZeroOffset = 0.0;

	public double Tool170YZeroOffset = 0.0;

	public double Tool171YZeroOffset = 0.0;

	public double Tool172YZeroOffset = 0.0;

	public double Tool173YZeroOffset = 0.0;

	public double Tool174YZeroOffset = 0.0;

	public double Tool175YZeroOffset = 0.0;

	public double Tool176YZeroOffset = 0.0;

	public double Tool177YZeroOffset = 0.0;

	public double Tool178YZeroOffset = 0.0;

	public double Tool179YZeroOffset = 0.0;

	public double Tool185YZeroOffset = 0.0;

	public double Tool261YZeroOffset = 0.0;

	public double Tool262YZeroOffset = 0.0;

	public double Tool263YZeroOffset = 0.0;

	public double Tool264YZeroOffset = 0.0;

	public double Tool265YZeroOffset = 0.0;

	public double Tool266YZeroOffset = 0.0;

	public double Tool267YZeroOffset = 0.0;

	public double Tool268YZeroOffset = 0.0;

	public double Tool269YZeroOffset = 0.0;

	public double Tool270YZeroOffset = 0.0;

	public DrillCNCSettings()
	{
	}

	public DrillCNCSettings(DrillCNCSettings data)
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
