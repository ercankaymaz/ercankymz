using ModuleWorks;

namespace buMW.Variables;

public class buMWFoamVars
{
	public static MWParameters varCamFoam;

	public static void Init()
	{
		varCamFoam = new MWParameters(Unit.Metric, 0);
	}
}
