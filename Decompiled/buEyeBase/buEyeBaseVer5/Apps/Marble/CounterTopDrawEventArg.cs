using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class CounterTopDrawEventArg
{
	public bool ZoomFit = false;

	public bool UpdateTree = false;

	public CounterTopDrawEventArg()
	{
	}

	public CounterTopDrawEventArg(bool zoomfit, bool updatetree)
	{
		ZoomFit = zoomfit;
		UpdateTree = updatetree;
	}
}
