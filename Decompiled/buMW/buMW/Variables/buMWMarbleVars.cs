using ModuleWorks;

namespace buMW.Variables;

public class buMWMarbleVars
{
	public static MWParameters varCamMarbleMesh5AxisRotaryRough;

	public static MWParameters varCamMarbleMesh5AxisRotaryFinish;

	public static MWParameters varCamMarbleMesh4AxisRotaryFinish;

	public static MWParameters varCamMarbleSawMillingHorizontalRough;

	public static MWParameters varCamMarbleSawMillingHorizontalFinish;

	public static MWParameters varCamMarbleSawMillingVerticalRough;

	public static MWParameters varCamMarbleSawMillingVerticalFinish;

	public static MWParameters varCamMarbleSawCornerCleaning;

	public static MWParameters varCamMarbleMeshRough;

	public static MWParameters varCamMarbleMeshParelelCut;

	public static MWParameters varCamMarbleMeshConstantZ;

	public static MWParameters varCamMarbleMeshFlatland;

	public static MWParameters varCamMarbleMeshPencil;

	public static MWParameters varCamMarbleMeshConstantCusp;

	public static MWParameters varCamMarbleMeshProjectionAroundFinish;

	public static MWParameters varCamMarbleMeshProjectionAroundRough;

	public static MWParameters varCamMarbleMeshProjectionAlongFinish;

	public static MWParameters varCamMarbleMeshProjectionAlongRough;

	public static MWParameters varCamMarbleMesh5DParelelCut;

	public static MWParameters varCamMarbleMesh5DConstantZ;

	public static MWParameters varCamMarbleMesh5DGeodesic;

	public static MWParameters varCamMarbleMilling2DRough;

	public static MWParameters varCamMarbleMilling2DContour;

	public static MWParameters varCamMarbleMilling2DCenter;

	public static MWParameters varCamMarbleMilling2DFace;

	public static MWParameters varCamMarbleMilling2DFloorFinish;

	public static MWParameters varCamMarbleMilling2DChamfer;

	public static MWParameters varCamMarbleMilling2DEngrave;

	public static MWParameters varCamMarbleMilling2DTextEngrave;

	public static MWParameters varCamMarbleMilling2DTrochoidal;

	public static MWParameters varCamMarbleWaterJetContour;

	public static MWParameters varCamMarbleAirDry;

	public static MWParameters varCamMarbleMaterialClean;

	public static MWParameters varCamMarbleSurfaceClean;

	public static MWParameters varCamMarbleDrill;

	public static MWParameters varCamMarbleContour;

	public static MWParameters varCamMarbleProfileRough;

	public static MWParameters varCamMarbleProfileFinish;

	public static MWParameters varCamMarbleSweep;

	public static MWParameters varCamMarbleColumns;

	public static MWParameters varCamMarbleLatheHor;

	public static MWParameters varCamMarbleLatheVer;

	public static MWParameters varCamMarbleOpenContourSaw;

	public static MWParameters varCamMarbleClosedContourSaw;

	public static MWParameters varCamMarbleOpenContourMilling;

	public static MWParameters varCamMarbleClosedContourMilling;

	public static MWParameters varCamMarbleOpenContourWaterJet;

	public static MWParameters varCamMarbleClosedContourWaterJet;

	public static MWParameters varCamMarbleHole;

	public static MWParameters varCamMarbleHatch;

	public static void Init()
	{
		varCamMarbleProfileRough = new MWParameters(Unit.Metric, 0);
		varCamMarbleProfileFinish = new MWParameters(Unit.Metric, 0);
		varCamMarbleSweep = new MWParameters(Unit.Metric, 0);
		varCamMarbleContour = new MWParameters(Unit.Metric, 0);
		int num = 1;
		while (true)
		{
			int num2 = 0;
			do
			{
				varCamMarbleColumns = new MWParameters((Unit)num, num2);
				int num3 = 1;
				if (num3 != 0)
				{
					varCamMarbleLatheHor = new MWParameters((Unit)num3, 0);
					varCamMarbleLatheVer = new MWParameters(Unit.Metric, 0);
					varCamMarbleMilling2DRough = new MWParameters(Unit.Metric, 0);
					varCamMarbleMilling2DCenter = new MWParameters(Unit.Metric, 0);
					num3 = 1;
				}
				varCamMarbleMilling2DChamfer = new MWParameters((Unit)num3, 0);
				varCamMarbleMilling2DContour = new MWParameters(Unit.Metric, 0);
				varCamMarbleMilling2DEngrave = new MWParameters(Unit.Metric, 0);
				num = 1;
				num2 = 0;
			}
			while (num2 != 0);
			varCamMarbleMilling2DFace = new MWParameters((Unit)num, num2);
			varCamMarbleMilling2DFloorFinish = new MWParameters(Unit.Metric, 0);
			varCamMarbleMilling2DTextEngrave = new MWParameters(Unit.Metric, 0);
			varCamMarbleMilling2DTrochoidal = new MWParameters(Unit.Metric, 0);
			varCamMarbleWaterJetContour = new MWParameters(Unit.Metric, 0);
			varCamMarbleAirDry = new MWParameters(Unit.Metric, 0);
			while (true)
			{
				varCamMarbleDrill = new MWParameters(Unit.Metric, 0);
				varCamMarbleMaterialClean = new MWParameters(Unit.Metric, 0);
				num = 1;
				if (num == 0)
				{
					break;
				}
				int num4 = 0;
				int num5;
				if (num4 == 0)
				{
					varCamMarbleSurfaceClean = new MWParameters((Unit)num, num4);
					varCamMarbleOpenContourSaw = new MWParameters(Unit.Metric, 0);
					varCamMarbleOpenContourMilling = new MWParameters(Unit.Metric, 0);
					varCamMarbleClosedContourSaw = new MWParameters(Unit.Metric, 0);
					varCamMarbleClosedContourMilling = new MWParameters(Unit.Metric, 0);
					varCamMarbleOpenContourWaterJet = new MWParameters(Unit.Metric, 0);
					varCamMarbleClosedContourWaterJet = new MWParameters(Unit.Metric, 0);
					varCamMarbleHole = new MWParameters(Unit.Metric, 0);
					if (false)
					{
						continue;
					}
					varCamMarbleHatch = new MWParameters(Unit.Metric, 0);
					varCamMarbleMeshRough = new MWParameters(Unit.Metric, 0);
					varCamMarbleMeshParelelCut = new MWParameters(Unit.Metric, 0);
					varCamMarbleMeshConstantZ = new MWParameters(Unit.Metric, 0);
					varCamMarbleMeshFlatland = new MWParameters(Unit.Metric, 0);
					num5 = 1;
					goto IL_01a6;
				}
				goto IL_01ef;
				IL_01ef:
				varCamMarbleMesh5DParelelCut = new MWParameters((Unit)num, num4);
				varCamMarbleMesh5DConstantZ = new MWParameters(Unit.Metric, 0);
				varCamMarbleMesh5DGeodesic = new MWParameters(Unit.Metric, 0);
				varCamMarbleSawMillingHorizontalRough = new MWParameters(Unit.Metric, 0);
				varCamMarbleSawMillingHorizontalFinish = new MWParameters(Unit.Metric, 0);
				varCamMarbleSawMillingVerticalRough = new MWParameters(Unit.Metric, 0);
				varCamMarbleSawMillingVerticalFinish = new MWParameters(Unit.Metric, 0);
				varCamMarbleSawCornerCleaning = new MWParameters(Unit.Metric, 0);
				varCamMarbleMesh5AxisRotaryRough = new MWParameters(Unit.Metric, 0);
				num5 = 1;
				if (num5 == 0)
				{
					goto IL_01a6;
				}
				int num6 = 0;
				if (num6 == 0)
				{
					varCamMarbleMesh5AxisRotaryFinish = new MWParameters((Unit)num5, num6);
					varCamMarbleMesh4AxisRotaryFinish = new MWParameters(Unit.Metric, 0);
					return;
				}
				goto IL_01d7;
				IL_01a6:
				varCamMarbleMeshPencil = new MWParameters((Unit)num5, 0);
				varCamMarbleMeshConstantCusp = new MWParameters(Unit.Metric, 0);
				varCamMarbleMeshProjectionAlongFinish = new MWParameters(Unit.Metric, 0);
				varCamMarbleMeshProjectionAlongRough = new MWParameters(Unit.Metric, 0);
				num5 = 1;
				num6 = 0;
				goto IL_01d7;
				IL_01d7:
				varCamMarbleMeshProjectionAroundFinish = new MWParameters((Unit)num5, num6);
				varCamMarbleMeshProjectionAroundRough = new MWParameters(Unit.Metric, 0);
				num = 1;
				num4 = 0;
				goto IL_01ef;
			}
		}
	}
}
