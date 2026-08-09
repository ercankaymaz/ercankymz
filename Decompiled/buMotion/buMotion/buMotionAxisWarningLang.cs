using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class buMotionAxisWarningLang : buSerilization
{
	public string AxisDisable = _0012(107387273);

	public string AxisinError = _0012(107387224);

	public string AxisNeedHoming = _0012(107387203);

	public string AxisinMove = _0012(107387210);

	public string AxisFeedoverrideZero = _0012(107387161);

	public string AxisVelocityZero = _0012(107387132);

	public string AxisAccelerationZero = _0012(107387107);

	public string AxisDecelerationZero = _0012(107387110);

	public string AxisJerkZero = _0012(107387081);

	public string AxisHoming = _0012(107386548);

	public string AxisinAction = _0012(107386499);

	public string GainError = _0012(107386510);

	public string DriveError = _0012(107387561);

	public string ScaleParameterError = _0012(107386461);

	public string UnitParameterNotCorrect = _0012(107386432);

	public string EncoderParamterNotCorrect = _0012(107386395);

	public string MaxAccelerationParameterNotCorrect = _0012(107386386);

	public string MaxDecelerationParameterNotCorrect = _0012(107386301);

	public string MaxVelocityParameterNotCorrect = _0012(107386792);

	public string GantryModeError = _0012(107386711);

	public string NotMoveableAxis = _0012(107386686);

	public string MaxJerkParameterNotCorrect = _0012(107386661);

	public string DriveSetEnocderModeError = _0012(107386620);

	public string DriveSetAbsoluteSetError = _0012(107386611);

	public string DriveSetControlModeError = _0012(107386570);

	public string DriveSetVelocityModeError = _0012(107385985);

	public string DriveSetFollowError = _0012(107385944);

	public string DriveSetNegativeCurrentError = _0012(107385911);

	public string DriveSetPositiveCurrentError = _0012(107385898);

	public string DriveSetAnalogOutError = _0012(107385821);

	public string DriveSetAnalogInputError = _0012(107385784);

	public string DriveSetVelocityLoopKPError = _0012(107386287);

	public string DriveSetVelocityLoopKIError = _0012(107386210);

	public string DriveSetVelocityLoopFFError = _0012(107386197);

	public string DriveSetPositionLoopKPError = _0012(107386152);

	public string DriveSetPositionLoopKIError = _0012(107386075);

	public string DenumeratorZero = _0012(107386062);

	public string NumeratorZero = _0012(107385497);

	[NonSerialized]
	internal static GetString _0012;

	static buMotionAxisWarningLang()
	{
		Strings.CreateGetStringDelegate(typeof(buMotionAxisWarningLang));
	}
}
