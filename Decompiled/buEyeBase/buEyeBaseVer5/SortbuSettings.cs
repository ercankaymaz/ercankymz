using System;

namespace buEyeBaseVer5;

[Serializable]
public class SortbuSettings : buSerilization5
{
	public SortbuFilter Filter = new SortbuFilter();

	public SortbuOptions Option = new SortbuOptions();

	public SortbuCamData CamData = new SortbuCamData();

	public MostClosestPointOption ClosestPoint = new MostClosestPointOption();

	public SortbuSettings()
	{
	}

	public SortbuSettings(SortbuSettings data)
	{
		CamData = new SortbuCamData(data.CamData);
		Filter = new SortbuFilter(data.Filter);
		Option = new SortbuOptions(data.Option);
	}
}
