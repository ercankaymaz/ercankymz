using ModuleWorks;

namespace buMW.Variables;

public class buMWDoorVars
{
	public static MWParameters varCamCommon;

	public static void Init()
	{
		varCamCommon = new MWParameters(Unit.Metric, 0);
	}
}
