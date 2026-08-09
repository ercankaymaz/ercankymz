using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class buMotionErrorLang : buSerilization
{
	public string NoAlarm = _001D(107389239);

	public string EmergencyStop = _001D(107389258);

	public string HomingTimeout = _001D(107389205);

	public string MACMismatch = _001D(107389216);

	public string InitFailure = _001D(107389167);

	public string GantryError = _001D(107389660);

	public string LowAirPressure = _001D(107389150);

	public string SpindleFault = _001D(107389157);

	public string ToolChangeTimeout = _001D(107389104);

	public string ToolMeasureTimeout = _001D(107389075);

	public string ToolMeasureFailure = _001D(107389046);

	public string ParkTimeout = _001D(107388505);

	public string CompileError = _001D(107388520);

	public string ShortToolError = _001D(107388467);

	public string LongToolError = _001D(107388442);

	public string ToolClamperNotEmpty = _001D(107388453);

	public string ToolNotAvailable = _001D(107388420);

	public string ToolNoActive = _001D(107388395);

	public string ReadNCFBError = _001D(107388342);

	public string DecodeNCFBError = _001D(107388353);

	public string SmootMergeFBError = _001D(107388328);

	public string SmoothPathFBError = _001D(107388299);

	public string ExtendeVelocityFBError = _001D(107388782);

	public string LimitDynamicsFBError = _001D(107388749);

	public string CheckVelocityFBError = _001D(107388716);

	public string ToolCoverNotOpen = _001D(107388683);

	public string ToolCoverNotClosed = _001D(107388654);

	public string ToolMagazineNotForwardPosition = _001D(107388593);

	public string ToolMagazineNotBackwardPosition = _001D(107388576);

	public string WaterLowLevel = _001D(107387983);

	public string DoorOpen = _001D(107387962);

	public string ToolStillinSpindle = _001D(107387981);

	public string ToolChangeNextToolWrong = _001D(107387920);

	public string CNCIpoFBError = _001D(107387915);

	public string CNCReadNCFBError = _001D(107387862);

	public string CNCDecodeNCFBError = _001D(107387837);

	public string BBBActivated = _001D(107387840);

	public string ToolGetError = _001D(107387819);

	public string ClamperNotClosed = _001D(107387766);

	public string ClamperNotEmpty = _001D(107388253);

	public string ToolChangeFailure = _001D(107388260);

	public string CalculationError = _001D(107388231);

	public string FileOpenError = _001D(107388206);

	public string FileSaveError = _001D(107388153);

	public string NoProduct = _001D(107388164);

	public string PhaseError = _001D(107388115);

	public string EthercatInitFailure = _001D(107388130);

	public string AxesParameterUpdateFailure = _001D(107388101);

	[NonSerialized]
	internal static GetString _001D;

	static buMotionErrorLang()
	{
		Strings.CreateGetStringDelegate(typeof(buMotionErrorLang));
	}
}
