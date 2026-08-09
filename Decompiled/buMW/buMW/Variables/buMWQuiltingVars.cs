using ModuleWorks;

namespace buMW.Variables;

public class buMWQuiltingVars
{
	public static MWParameters varCamQuilting;

	public static void Init()
	{
		varCamQuilting = new MWParameters(Unit.Metric, 0);
	}
}
