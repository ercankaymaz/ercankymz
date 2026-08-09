using ModuleWorks;

namespace buMW.Variables;

public class buMWTuftingVars
{
	public static MWParameters varCamRough;

	public static MWParameters varCamContour;

	public static void Init()
	{
		varCamRough = new MWParameters(Unit.Metric, 0);
		varCamContour = new MWParameters(Unit.Metric, 0);
	}
}
