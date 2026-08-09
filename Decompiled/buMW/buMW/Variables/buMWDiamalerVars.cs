using ModuleWorks;
using buEyeBaseVer5;

namespace buMW.Variables;

public class buMWDiamalerVars
{
	public static GeoLib varMWDiemakerCamMeshRoughPars;

	public static camParameters5 varbuDiemakerCamMeshRoughPars;

	public static GeoLib varMWDiemakerCamMeshParalelPars;

	public static camParameters5 varbuDiemakerCamMeshParallelPars;

	public static GeoLib varMWDiemakerCamMeshContantZPars;

	public static camParameters5 varbuDiemakerCamMeshConstantZPars;

	public static GeoLib varMWDiemakerCamMeshPencilPars;

	public static camParameters5 varbuDiemakerCamMeshPencilPars;

	public static GeoLib varMWDiemakerCamMeshProjectionPars;

	public static camParameters5 varbuDiemakerCamMeshProjectionPars;

	public static GeoLib varMWDiemakerCamMeshFlatlandPars;

	public static camParameters5 varbuDiemakerCamMeshFlatlandsPars;

	public static GeoLib varMWDiemakerCamMeshContantCuspPars;

	public static camParameters5 varbuDiemakerCamMeshConstantCuspPars;

	public static GeoLib varMWDiemakerCamWFPocketPars;

	public static camParameters5 varbuDiemakerCamWFPocketPars;

	public static GeoLib varMWDiemakerCamWFContourPars;

	public static camParameters5 varbuDiemakerCamWFContourPars;

	public static GeoLib varMWDiemakerCamWFContour4XPars;

	public static camParameters5 varbuDiemakerCamWFContour4XPars;

	public static GeoLib varMWDiemakerCamDrillPars;

	public static camParameters5 varbuDiemakerCamDrillPars;

	public static GeoLib varMWDiemakerCamScanPars;

	public static camParameters5 varbuDiemakerCamScanPars;

	public static void Init()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_0029: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		if (8u != 0)
		{
			varMWDiemakerCamMeshRoughPars = new GeoLib(Unit.Metric, 0);
			varbuDiemakerCamMeshRoughPars = new camParameters5();
			goto IL_001d;
		}
		goto IL_0091;
		IL_007d:
		int num;
		int num2;
		varMWDiemakerCamMeshFlatlandPars = new GeoLib((Unit)num, num2);
		varbuDiemakerCamMeshFlatlandsPars = new camParameters5();
		goto IL_0091;
		IL_001d:
		varMWDiemakerCamMeshParalelPars = new GeoLib(Unit.Metric, 0);
		varbuDiemakerCamMeshParallelPars = new camParameters5();
		varMWDiemakerCamMeshContantZPars = new GeoLib(Unit.Metric, 0);
		if (7 == 0)
		{
			goto IL_0091;
		}
		varbuDiemakerCamMeshConstantZPars = new camParameters5();
		varMWDiemakerCamMeshPencilPars = new GeoLib(Unit.Metric, 0);
		varbuDiemakerCamMeshPencilPars = new camParameters5();
		int num3 = 1;
		if (num3 != 0)
		{
			varMWDiemakerCamMeshProjectionPars = new GeoLib((Unit)num3, 0);
			varbuDiemakerCamMeshProjectionPars = new camParameters5();
			num = 1;
			num2 = 0;
			goto IL_007d;
		}
		goto IL_00b1;
		IL_0091:
		num = 1;
		num2 = 0;
		if (num2 != 0)
		{
			goto IL_007d;
		}
		varMWDiemakerCamMeshContantCuspPars = new GeoLib((Unit)num, num2);
		if (7 == 0)
		{
			goto IL_001d;
		}
		varbuDiemakerCamMeshConstantCuspPars = new camParameters5();
		num3 = 1;
		goto IL_00b1;
		IL_00b1:
		varMWDiemakerCamWFPocketPars = new GeoLib((Unit)num3, 0);
		varbuDiemakerCamWFPocketPars = new camParameters5();
		varMWDiemakerCamWFContourPars = new GeoLib(Unit.Metric, 0);
		varbuDiemakerCamWFContourPars = new camParameters5();
		varMWDiemakerCamWFContour4XPars = new GeoLib(Unit.Metric, 0);
		varbuDiemakerCamWFContour4XPars = new camParameters5();
		do
		{
			varMWDiemakerCamDrillPars = new GeoLib(Unit.Metric, 0);
			varbuDiemakerCamDrillPars = new camParameters5();
			varMWDiemakerCamScanPars = new GeoLib(Unit.Metric, 0);
		}
		while (8 == 0);
		varbuDiemakerCamScanPars = new camParameters5();
	}
}
