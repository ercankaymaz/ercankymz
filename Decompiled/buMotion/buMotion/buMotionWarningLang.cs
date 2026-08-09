using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class buMotionWarningLang : buSerilization
{
	public string NoWarning = _0003(107390058);

	public string SystemOffline = _0003(107390073);

	public string HomingMissing = _0003(107390020);

	public string SysteminAlarm = _0003(107390031);

	public string SystemisRunning = _0003(107389498);

	public string DrivesareDisable = _0003(107389441);

	public string SystemisMoving = _0003(107389416);

	public string SsytemisPaused = _0003(107389423);

	public string NoAxisSelected = _0003(107389398);

	public string CanNotdoThisCommand = _0003(107389373);

	public string FileNotLoaded = _0003(107389340);

	public string AccelerationZero = _0003(107389287);

	public string DecelerationZero = _0003(107389294);

	public string JerkZero = _0003(107389269);

	public string WaitTimeLowerThen0 = _0003(107389736);

	public string VelocityZero = _0003(107389703);

	public string AxisinSimulationMode = _0003(107389718);

	public string IOinSimulationMode = _0003(107389685);

	public string AutoMode = _0003(107389656);

	public string GantryError = _0003(107389611);

	public string LevelisnotEnoughtThisOperation = _0003(107389626);

	public string DoorisOpen = _0003(107389545);

	public string MacError = _0003(107389560);

	public string SystemisNotRunning = _0003(107389515);

	public string CNCStepZero = _0003(107389518);

	public string PartZeronotSet = _0003(107388989);

	public string DoorisClosed = _0003(107388932);

	public string HandWheelisActive = _0003(107388943);

	public string SystemisnotReady = _0003(107388914);

	public string NotConnected = _0003(107388885);

	public string ParameterWritingtoSystemPleaseTryAfewSecoondLater = _0003(107388832);

	public string ParameterHasNotDownloadedPleaseUpdateParameter = _0003(107388783);

	[NonSerialized]
	internal static GetString _0003;

	static buMotionWarningLang()
	{
		Strings.CreateGetStringDelegate(typeof(buMotionWarningLang));
	}
}
