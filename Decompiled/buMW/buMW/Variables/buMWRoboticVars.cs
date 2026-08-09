using ModuleWorks;

namespace buMW.Variables;

public class buMWRoboticVars
{
	public static MWParameters varCamMeshRough3Axis;

	public static MWParameters varCamMeshRough4Axis;

	public static MWParameters varCamMeshParallel3Axis;

	public static MWParameters varCamMeshParallel4Axis;

	public static MWParameters varCamMeshParallel5Axis;

	public static MWParameters varCamMeshConstantZ3Axis;

	public static MWParameters varCamMeshConstantZ4Axis;

	public static MWParameters varCamMeshConstantZ5Axis;

	public static MWParameters varCamWFPocket;

	public static MWParameters varCamWFContour;

	public static MWParameters varCamDrill;

	public static MWParameters varCamContouring;

	public static MWParameters varCamSurface4Axis;

	public static MWParameters varCamSurface5Axis;

	public static void Init()
	{
		int num;
		if (0 == 0)
		{
			num = 1;
			goto IL_0008;
		}
		goto IL_00a3;
		IL_005e:
		int unit = 1;
		int num2 = 0;
		goto IL_0105;
		IL_0008:
		varCamMeshRough3Axis = new MWParameters((Unit)num, 0);
		varCamMeshRough4Axis = new MWParameters(Unit.Metric, 0);
		varCamMeshParallel3Axis = new MWParameters(Unit.Metric, 0);
		int num3 = 1;
		do
		{
			varCamMeshParallel4Axis = new MWParameters((Unit)num3, 0);
			varCamMeshParallel5Axis = new MWParameters(Unit.Metric, 0);
			num3 = 1;
		}
		while (num3 == 0);
		varCamMeshConstantZ3Axis = new MWParameters((Unit)num3, 0);
		int unit2 = 1;
		int num4 = 0;
		goto IL_00fb;
		IL_00a3:
		unit = 1;
		num2 = 0;
		if (num2 != 0)
		{
			goto IL_0105;
		}
		varCamSurface4Axis = new MWParameters((Unit)unit, num2);
		varCamSurface5Axis = new MWParameters(Unit.Metric, 0);
		return;
		IL_0105:
		varCamMeshConstantZ5Axis = new MWParameters((Unit)unit, num2);
		varCamWFContour = new MWParameters(Unit.Metric, 0);
		if (false)
		{
			goto IL_005e;
		}
		num = 1;
		if (num == 0)
		{
			goto IL_0008;
		}
		varCamWFPocket = new MWParameters((Unit)num, 0);
		unit2 = 1;
		num4 = 0;
		if (num4 != 0)
		{
			goto IL_00fb;
		}
		varCamDrill = new MWParameters((Unit)unit2, num4);
		varCamContouring = new MWParameters(Unit.Metric, 0);
		goto IL_00a3;
		IL_00fb:
		varCamMeshConstantZ4Axis = new MWParameters((Unit)unit2, num4);
		goto IL_005e;
	}
}
