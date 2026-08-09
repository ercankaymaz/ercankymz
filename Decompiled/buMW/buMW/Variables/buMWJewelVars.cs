using ModuleWorks;

namespace buMW.Variables;

public class buMWJewelVars
{
	public static MWParameters varCamMeshRough;

	public static MWParameters varCamMeshParelelCut;

	public static MWParameters varCamMeshConstantZ;

	public static MWParameters varCamWirePocket;

	public static MWParameters varCamWireContour;

	public static MWParameters varCamWireContour4X;

	public static MWParameters varCamWireDrill;

	public static MWParameters varCamWireDrill4X;

	public static MWParameters varCamWireSpin;

	public static void Init()
	{
		varCamMeshRough = new MWParameters(Unit.Metric, 0);
		while (true)
		{
			varCamMeshParelelCut = new MWParameters(Unit.Metric, 0);
			if (7u != 0)
			{
				varCamMeshConstantZ = new MWParameters(Unit.Metric, 0);
				if (4 == 0)
				{
					goto IL_0052;
				}
				varCamWirePocket = new MWParameters(Unit.Metric, 0);
				varCamWireContour = new MWParameters(Unit.Metric, 0);
			}
			if (false)
			{
				break;
			}
			if (0 == 0)
			{
				varCamWireContour4X = new MWParameters(Unit.Metric, 0);
				if (false)
				{
					continue;
				}
				varCamWireDrill = new MWParameters(Unit.Metric, 0);
			}
			goto IL_0052;
			IL_0052:
			varCamWireDrill4X = new MWParameters(Unit.Metric, 0);
			varCamWireSpin = new MWParameters(Unit.Metric, 0);
			break;
		}
	}
}
