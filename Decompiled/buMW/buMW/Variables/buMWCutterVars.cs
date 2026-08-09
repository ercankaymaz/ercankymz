using ModuleWorks;

namespace buMW.Variables;

public class buMWCutterVars
{
	public static MWParameters varCamCutter;

	public static void Init()
	{
		varCamCutter = new MWParameters(Unit.Metric, 0);
	}
}
