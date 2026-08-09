using System;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class CounterTopCreateEventArg
{
	public bool DrawCountertop = false;

	public bool ZoomFit = false;

	public bool UpdateTree = false;

	public CounterTopCreateEventArg()
	{
	}

	public CounterTopCreateEventArg(bool drawcountertop, bool zoomfit, bool updatetree)
	{
		DrawCountertop = drawcountertop;
		ZoomFit = zoomfit;
		UpdateTree = updatetree;
	}
}
