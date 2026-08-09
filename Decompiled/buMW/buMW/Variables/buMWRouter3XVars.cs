using ModuleWorks;

namespace buMW.Variables;

public class buMWRouter3XVars
{
	public static MWParameters varCamWireframeCompCutting;

	public static MWParameters varCamWireframeCompGrove;

	public static MWParameters varCamWireframeCompCutInside;

	public static MWParameters varCamWireframeCompCutOutside;

	public static MWParameters varCamWireframeCompCutCenter;

	public static MWParameters varCamWireframeCompPocket;

	public static MWParameters varCamWireframeCompText;

	public static MWParameters varCamWireframeRough;

	public static MWParameters varCamWireframeContour;

	public static MWParameters varCamWireframeFace;

	public static MWParameters varCamWireframeEngrave;

	public static MWParameters varCamWireframeTextEngrave;

	public static MWParameters varCamWireframeFloorFinish;

	public static MWParameters varCamWireframeCenterPath;

	public static MWParameters varCamWireframeTrochoidial;

	public static MWParameters varCamWireframeDrill;

	public static MWParameters varCamWireframeChamfer;

	public static MWParameters varCamMeshRough;

	public static MWParameters varCamMeshParallel;

	public static MWParameters varCamMeshConstantZ;

	public static MWParameters varCamMeshPencil;

	public static MWParameters varCamMeshFlatLand;

	public static MWParameters varCamMeshProjectCurves;

	public static MWParameters varCamMeshConstantCusp;

	public static MWParameters varCamMeshProjection;

	public static MWParameters varCamMeshRotary;

	public static MWParameters varCamMeshParallel5AX;

	public static MWParameters varCamMeshConstantZ5AX;

	public static MWParameters varCamMeshRough5AX;

	public static MWParameters varCamSurfaceParallel;

	public static void Init()
	{
		int unit = 1;
		int num = 0;
		if (num == 0)
		{
			varCamWireframeRough = new MWParameters((Unit)unit, num);
			int num2 = 1;
			while (true)
			{
				varCamWireframeContour = new MWParameters((Unit)num2, 0);
				varCamWireframeFace = new MWParameters(Unit.Metric, 0);
				varCamWireframeEngrave = new MWParameters(Unit.Metric, 0);
				if (4u != 0)
				{
					varCamWireframeTextEngrave = new MWParameters(Unit.Metric, 0);
					if (8 == 0)
					{
						break;
					}
					int unit2 = 1;
					int num3 = 0;
					int num4;
					while (true)
					{
						varCamWireframeFloorFinish = new MWParameters((Unit)unit2, num3);
						num4 = 1;
						while (true)
						{
							varCamWireframeCenterPath = new MWParameters((Unit)num4, 0);
							varCamWireframeTrochoidial = new MWParameters(Unit.Metric, 0);
							unit2 = 1;
							num3 = 0;
							if (num3 != 0)
							{
								break;
							}
							varCamWireframeDrill = new MWParameters((Unit)unit2, num3);
							varCamWireframeChamfer = new MWParameters(Unit.Metric, 0);
							varCamWireframeCompCutCenter = new MWParameters(Unit.Metric, 0);
							num4 = 1;
							if (num4 != 0)
							{
								goto end_IL_01bd;
							}
						}
						continue;
						end_IL_01bd:
						break;
					}
					varCamWireframeCompCutInside = new MWParameters((Unit)num4, 0);
					varCamWireframeCompCutOutside = new MWParameters(Unit.Metric, 0);
					varCamWireframeCompCutting = new MWParameters(Unit.Metric, 0);
					varCamWireframeCompGrove = new MWParameters(Unit.Metric, 0);
					varCamWireframeCompPocket = new MWParameters(Unit.Metric, 0);
					varCamWireframeCompText = new MWParameters(Unit.Metric, 0);
					if (false)
					{
						goto IL_0112;
					}
					varCamMeshRough = new MWParameters(Unit.Metric, 0);
					num2 = 1;
					if (num2 == 0)
					{
						continue;
					}
					varCamMeshParallel = new MWParameters((Unit)num2, 0);
				}
				varCamMeshConstantZ = new MWParameters(Unit.Metric, 0);
				goto IL_0112;
				IL_0112:
				varCamMeshPencil = new MWParameters(Unit.Metric, 0);
				varCamMeshFlatLand = new MWParameters(Unit.Metric, 0);
				break;
			}
			varCamMeshProjectCurves = new MWParameters(Unit.Metric, 0);
			unit = 1;
			num = 0;
		}
		varCamMeshConstantCusp = new MWParameters((Unit)unit, num);
		varCamMeshProjection = new MWParameters(Unit.Metric, 0);
		varCamMeshRotary = new MWParameters(Unit.Metric, 0);
		varCamSurfaceParallel = new MWParameters(Unit.Metric, 0);
		varCamMeshParallel5AX = new MWParameters(Unit.Metric, 0);
		varCamMeshConstantZ5AX = new MWParameters(Unit.Metric, 0);
		varCamMeshRough5AX = new MWParameters(Unit.Metric, 0);
	}
}
