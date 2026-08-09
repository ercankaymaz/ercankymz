using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buEyeBaseVer5;

namespace buMW;

public class MWParameters
{
	public camParameters5 buPar = new camParameters5();

	public GeoLib mwPar = new GeoLib(Unit.Metric);

	public MWParameters()
	{
	}//IL_000d: Unknown result type (might be due to invalid IL or missing references)
	//IL_0017: Expected O, but got Unknown


	public MWParameters(Unit unit, int ifVersion)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		buPar = new camParameters5();
		mwPar = new GeoLib(unit, ifVersion);
	}

	public MWParameters(MWParameters data)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		buPar = new camParameters5(data.buPar);
		data.mwPar.Copy(mwPar);
		mwPar.MachParam = new MachiningParams(data.mwPar.MachParam);
	}
}
