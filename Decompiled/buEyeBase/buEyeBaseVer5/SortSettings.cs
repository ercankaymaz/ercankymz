using System;

namespace buEyeBaseVer5;

[Serializable]
public class SortSettings : buSerilization5
{
	public SortFilter Filter = new SortFilter();

	public SortOptions Option = new SortOptions();

	public SortCamData CamData = new SortCamData();

	public MostClosestPointOption ClosestPoint = new MostClosestPointOption();

	public SortSettings()
	{
	}

	public SortSettings(SortSettings data)
	{
		CamData = new SortCamData(data.CamData);
		Filter = new SortFilter(data.Filter);
		Option = new SortOptions(data.Option);
	}
}
