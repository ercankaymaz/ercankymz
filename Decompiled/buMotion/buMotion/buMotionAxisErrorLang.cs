using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class buMotionAxisErrorLang : buSerilization
{
	public string SoftwareLimitError = _001F(107388060);

	public string HardwareLimitError = _001F(107388063);

	public string DriveError = _001F(107387522);

	public string ErrorStop = _001F(107387473);

	public string FollowingError = _001F(107387488);

	public string HomingTimeout = _001F(107389237);

	public string AxisCommunicationError = _001F(107387467);

	public string PositiveDataLimitError = _001F(107387434);

	public string NegativeDataLimitError = _001F(107387397);

	public string PositiveSoftwareLimitError = _001F(107387360);

	public string NegativeSoftwareLimitError = _001F(107387287);

	public string MCStopFBError = _001F(107387790);

	public string MCResetFBError = _001F(107387737);

	public string MCPowerFBError = _001F(107387744);

	public string MCMoveAbsoluteFBError = _001F(107387719);

	public string MCMoveRelativeFBError = _001F(107387686);

	public string MCHomeFBError = _001F(107387653);

	public string MCSetPositionFBError = _001F(107387600);

	public string MCSetHomeFBError = _001F(107387567);

	public string MCJogFBError = _001F(107387542);

	public string MCLimitDynamicsFBError = _001F(107387553);

	public string MCGearInFBError = _001F(107387008);

	public string MCGearOutFBError = _001F(107386983);

	public string AxisOutofLimits = _001F(107386958);

	public string SMCChangeDynamicLimitsFBError = _001F(107386901);

	public string SMCChangeRatioFBError = _001F(107386888);

	public string SMCHomeFBError = _001F(107386855);

	public string SMCSoftLimitFBError = _001F(107386830);

	public string SMCRampTypeFBError = _001F(107386769);

	public string SMCMoveTypeFBError = _001F(107387252);

	public string ReInitFBError = _001F(107387223);

	[NonSerialized]
	internal static GetString _001F;

	static buMotionAxisErrorLang()
	{
		Strings.CreateGetStringDelegate(typeof(buMotionAxisErrorLang));
	}
}
