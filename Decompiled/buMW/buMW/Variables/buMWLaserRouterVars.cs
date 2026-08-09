using ModuleWorks;

namespace buMW.Variables;

public class buMWLaserRouterVars
{
	public static MWParameters varCamLaserWFContour;

	public static MWParameters varCamPertinaxInCut;

	public static MWParameters varCamPertinaxOutCut;

	public static MWParameters varCamPertinaxHoleCut;

	public static MWParameters varCamPertinaxTextCut;

	public static MWParameters varCamSteelContour;

	public static MWParameters varCamSteelPocket;

	public static MWParameters varCamSteelText;

	public static MWParameters varCamWoodTop;

	public static MWParameters varCamWoodBottom;

	public static void Init()
	{
		int num;
		int num2;
		while (true)
		{
			varCamLaserWFContour = new MWParameters(Unit.Metric, 0);
			if (1 == 0)
			{
				continue;
			}
			varCamPertinaxInCut = new MWParameters(Unit.Metric, 0);
			num = 1;
			if (num != 0)
			{
				num2 = 0;
				if (num2 != 0)
				{
					break;
				}
				varCamPertinaxOutCut = new MWParameters((Unit)num, num2);
				if (0 == 0)
				{
					varCamPertinaxHoleCut = new MWParameters(Unit.Metric, 0);
				}
				varCamPertinaxTextCut = new MWParameters(Unit.Metric, 0);
				if (2 == 0)
				{
					continue;
				}
				num = 1;
			}
			varCamSteelContour = new MWParameters((Unit)num, 0);
			varCamSteelPocket = new MWParameters(Unit.Metric, 0);
			num = 1;
			num2 = 0;
			break;
		}
		varCamSteelText = new MWParameters((Unit)num, num2);
		varCamWoodTop = new MWParameters(Unit.Metric, 0);
		varCamWoodBottom = new MWParameters(Unit.Metric, 0);
	}
}
