using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class buMotionStatusLang : buSerilization
{
	public string SystemisReady = _0095(107390186);

	public string SystemisRunning = _0095(107390201);

	public string SysteminAlarm = _0095(107390148);

	public string ToolMeasure = _0095(107390163);

	public string ToolChange = _0095(107390114);

	public string GoingPark = _0095(107390129);

	public string GoingHoming = _0095(107390080);

	public string SystemPaused = _0095(107390095);

	public string Calculating = _0095(107390074);

	[NonSerialized]
	internal static GetString _0095;

	static buMotionStatusLang()
	{
		Strings.CreateGetStringDelegate(typeof(buMotionStatusLang));
	}
}
