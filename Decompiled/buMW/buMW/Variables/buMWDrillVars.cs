using ModuleWorks;

namespace buMW.Variables;

public class buMWDrillVars
{
	public static MWParameters varCamRough;

	public static MWParameters varCamContour;

	public static MWParameters varCamMeshParalelCut;

	public static MWParameters varCamMeshRough;

	public static void Init()
	{
		int num;
		int num2;
		while (true)
		{
			num = 1;
			if (num != 0)
			{
				num2 = 0;
				if (num2 != 0)
				{
					break;
				}
				varCamRough = new MWParameters((Unit)num, num2);
				if (4 == 0)
				{
					continue;
				}
				num = 1;
			}
			else if (num == 0)
			{
				goto IL_0020;
			}
			varCamContour = new MWParameters((Unit)num, 0);
			num = 1;
			goto IL_0020;
			IL_0020:
			varCamMeshParalelCut = new MWParameters((Unit)num, 0);
			num = 1;
			num2 = 0;
			break;
		}
		varCamMeshRough = new MWParameters((Unit)num, num2);
	}
}
