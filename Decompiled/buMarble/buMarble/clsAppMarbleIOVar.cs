using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buEyeBaseVer5;

namespace buMarble;

[Serializable]
public class clsAppMarbleIOVar : buSerilization5
{
	public static clsAppMarbleIODef ME_XPlus;

	public static clsAppMarbleIODef ME_XMinus;

	public static clsAppMarbleIODef ME_YPlus;

	public static clsAppMarbleIODef ME_YMinus;

	public static clsAppMarbleIODef ME_ZPlus;

	public static clsAppMarbleIODef ME_ZMinus;

	public static clsAppMarbleIODef ME_CPlus;

	public static clsAppMarbleIODef ME_CMinus;

	public static clsAppMarbleIODef ME_APlus;

	public static clsAppMarbleIODef ME_AMinus;

	public static clsAppMarbleIODef ME_CycleStart;

	public static clsAppMarbleIODef ME_CycleStop;

	public static clsAppMarbleIODef ME_SystemStart;

	public static clsAppMarbleIODef ME_SystemStop;

	public static clsAppMarbleIODef ME_ResetButton;

	public static clsAppMarbleIODef ME_Emergency;

	public static clsAppMarbleIODef ME_Auto;

	public static clsAppMarbleIODef ME_LaserButton;

	public static clsAppMarbleIODef ME_SpindleDriveError;

	public static clsAppMarbleIODef ME_SpindleDownSensor;

	public static clsAppMarbleIODef ME_SpindleAtSpeed;

	public static clsAppMarbleIODef ME_SpindleStoped;

	public static clsAppMarbleIODef ME_SpindleUpSensor;

	public static clsAppMarbleIODef ME_SpindleRun;

	public static clsAppMarbleIODef ME_SawDriveError;

	public static clsAppMarbleIODef ME_SawAtSpeed;

	public static clsAppMarbleIODef ME_SawStoped;

	public static clsAppMarbleIODef ME_PhaseError;

	public static clsAppMarbleIODef ME_HidroFault;

	public static clsAppMarbleIODef ME_XPlusLimit;

	public static clsAppMarbleIODef ME_XMinusLimit;

	public static clsAppMarbleIODef ME_XPlusMinusLimit;

	public static clsAppMarbleIODef ME_YPlusLimit;

	public static clsAppMarbleIODef ME_YMinusLimit;

	public static clsAppMarbleIODef ME_YPlusMinusLimit;

	public static clsAppMarbleIODef ME_ZMinusLimit;

	public static clsAppMarbleIODef ME_ZPlusLimit;

	public static clsAppMarbleIODef ME_LubricationLevelSensor;

	public static clsAppMarbleIODef ME_LubricationBlockSensor;

	public static clsAppMarbleIODef ME_ToolMeasure;

	public static clsAppMarbleIODef ME_ToolMeasureLimit;

	public static clsAppMarbleIODef ME_ToolAvailable;

	public static clsAppMarbleIODef ME_ToolNotAvailable;

	public static clsAppMarbleIODef ME_ToolMissing;

	public static clsAppMarbleIODef ME_WagonDownSensor;

	public static clsAppMarbleIODef ME_WagonDownButton;

	public static clsAppMarbleIODef ME_WagonUpButton;

	public static clsAppMarbleIODef ME_HandWheelX;

	public static clsAppMarbleIODef ME_HandWheelY;

	public static clsAppMarbleIODef ME_HandWheelZ;

	public static clsAppMarbleIODef ME_HandWheelC;

	public static clsAppMarbleIODef ME_HandWheelA;

	public static clsAppMarbleIODef ME_HandWheelX1;

	public static clsAppMarbleIODef ME_HandWheelX10;

	public static clsAppMarbleIODef ME_HandWheelX100;

	public static clsAppMarbleIODef ME_LeftVacuumInSensor;

	public static clsAppMarbleIODef ME_RightVacuumInSensor;

	public static clsAppMarbleIODef ME_LeftRightVacumDownLimit;

	public static clsAppMarbleIODef ME_LeftRightVacumUpLimit;

	public static clsAppMarbleIODef ME_LeftVacuumOutSensor;

	public static clsAppMarbleIODef ME_RightVacuumOutSensor;

	public static clsAppMarbleIODef ME_LeftVacuumDown;

	public static clsAppMarbleIODef ME_RightVacuumDown;

	public static clsAppMarbleIODef ME_LeftVacuumUp;

	public static clsAppMarbleIODef ME_RightVacuumUp;

	public static clsAppMarbleIODef ME_LeftVacuumOk;

	public static clsAppMarbleIODef ME_RightVacuumOk;

	public static clsAppMarbleIODef ME_DoorSwitch;

	public static clsAppMarbleIODef ME_WaterSwitch;

	public static clsAppMarbleIODef ME_WaterSpindleLeak;

	public static clsAppMarbleIODef ME_MaterialMeasure;

	public static clsAppMarbleIODef ME_MaterialMeasureUp;

	public static clsAppMarbleIODef ME_MaterialMeasureDown;

	public static clsAppMarbleIODef ME_AirPreasure;

	public static clsAppMarbleIODef ME_ATCDown;

	public static clsAppMarbleIODef ME_ATCUp;

	public static clsAppMarbleIODef ME_ATCForward;

	public static clsAppMarbleIODef ME_ATCBackward;

	public static clsAppMarbleIODef ME_ATCCoverOpen;

	public static clsAppMarbleIODef ME_ATCClose;

	public static clsAppMarbleIODef ME_ATCOpen;

	public static clsAppMarbleIODef ME_PensOpen;

	public static clsAppMarbleIODef ME_PensClose;

	public static clsAppMarbleIODef ME_AxisA0;

	public static clsAppMarbleIODef ME_AxisA45;

	public static clsAppMarbleIODef ME_AxisAFault;

	public static clsAppMarbleIODef ME_XHome;

	public static clsAppMarbleIODef ME_YHome;

	public static clsAppMarbleIODef ME_ZHome;

	public static clsAppMarbleIODef ME_Y2Home;

	public static clsAppMarbleIODef MO_SystemStart;

	public static clsAppMarbleIODef MO_SpindleFwd;

	public static clsAppMarbleIODef MO_SpindleBwd;

	public static clsAppMarbleIODef MO_CycleStartLed;

	public static clsAppMarbleIODef MO_CycleStopLed;

	public static clsAppMarbleIODef MO_WagonUp;

	public static clsAppMarbleIODef MO_WagonDown;

	public static clsAppMarbleIODef MO_WaterMainValf;

	public static clsAppMarbleIODef MO_WaterHeadValf;

	public static clsAppMarbleIODef MO_RedLed;

	public static clsAppMarbleIODef MO_GreenLed;

	public static clsAppMarbleIODef MO_YellowLed;

	public static clsAppMarbleIODef MO_HidroRun;

	public static clsAppMarbleIODef MO_LaserOn;

	public static clsAppMarbleIODef MO_SystemReady;

	public static clsAppMarbleIODef MO_CameraValf;

	public static clsAppMarbleIODef MO_CameraEnable;

	public static clsAppMarbleIODef MO_ResetLed;

	public static clsAppMarbleIODef MO_VacuumPistons;

	public static clsAppMarbleIODef MO_VacuumLeftValf;

	public static clsAppMarbleIODef MO_VacuumRightValf;

	public static clsAppMarbleIODef MO_VacuumValf;

	public static clsAppMarbleIODef MO_VacuumLeftBlowValf;

	public static clsAppMarbleIODef MO_VacuumLeftDownValf;

	public static clsAppMarbleIODef MO_VacuumLeftUpValf;

	public static clsAppMarbleIODef MO_VacuumRightBlowValf;

	public static clsAppMarbleIODef MO_VacuumRightDownValf;

	public static clsAppMarbleIODef MO_VacuumRightUpValf;

	public static clsAppMarbleIODef MO_MaterialMeasureDownValf;

	public static clsAppMarbleIODef MO_MaterialMeasureUpValf;

	public static clsAppMarbleIODef MO_MaterialMeasureValf;

	public static clsAppMarbleIODef MO_ToolMeasurValf;

	public static clsAppMarbleIODef MO_SawStart;

	public static clsAppMarbleIODef MO_SawFwd;

	public static clsAppMarbleIODef MO_SawBwd;

	public static clsAppMarbleIODef MO_SpindleStart;

	public static clsAppMarbleIODef MO_SpindleDownValf;

	public static clsAppMarbleIODef MO_VacuumBlow;

	public static clsAppMarbleIODef MO_HoleBlow;

	public static clsAppMarbleIODef MO_Lubrication;

	public static clsAppMarbleIODef MO_MachineLight;

	public static clsAppMarbleIODef MO_SpindleUpValf;

	public static clsAppMarbleIODef MO_PensOpen;

	public static clsAppMarbleIODef MO_ToolAir;

	public static clsAppMarbleIODef MO_ATCPistonUp;

	public static clsAppMarbleIODef MO_ATCPistonDown;

	public static clsAppMarbleIODef MO_AxisA0;

	public static clsAppMarbleIODef MO_AxisA45;

	public static clsAppMarbleIODef MO_Buzzer;

	[NonSerialized]
	internal static GetString _001D;

	static clsAppMarbleIOVar()
	{
		Strings.CreateGetStringDelegate(typeof(clsAppMarbleIOVar));
		ME_XPlus = new clsAppMarbleIODef(_001D(107376158));
		ME_XMinus = new clsAppMarbleIODef(_001D(107376177));
		ME_YPlus = new clsAppMarbleIODef(_001D(107376132));
		ME_YMinus = new clsAppMarbleIODef(_001D(107376151));
		ME_ZPlus = new clsAppMarbleIODef(_001D(107376138));
		ME_ZMinus = new clsAppMarbleIODef(_001D(107376093));
		ME_CPlus = new clsAppMarbleIODef(_001D(107376112));
		ME_CMinus = new clsAppMarbleIODef(_001D(107376067));
		ME_APlus = new clsAppMarbleIODef(_001D(107376086));
		ME_AMinus = new clsAppMarbleIODef(_001D(107376073));
		ME_CycleStart = new clsAppMarbleIODef(_001D(107376028));
		ME_CycleStop = new clsAppMarbleIODef(_001D(107376007));
		ME_SystemStart = new clsAppMarbleIODef(_001D(107376022));
		ME_SystemStop = new clsAppMarbleIODef(_001D(107375457));
		ME_ResetButton = new clsAppMarbleIODef(_001D(107375468));
		ME_Emergency = new clsAppMarbleIODef(_001D(107375447));
		ME_Auto = new clsAppMarbleIODef(_001D(107375398));
		ME_LaserButton = new clsAppMarbleIODef(_001D(107375385));
		ME_SpindleDriveError = new clsAppMarbleIODef(_001D(107375364));
		ME_SpindleDownSensor = new clsAppMarbleIODef(_001D(107375335));
		ME_SpindleAtSpeed = new clsAppMarbleIODef(_001D(107375338));
		ME_SpindleStoped = new clsAppMarbleIODef(_001D(107375313));
		ME_SpindleUpSensor = new clsAppMarbleIODef(_001D(107375288));
		ME_SpindleRun = new clsAppMarbleIODef(_001D(107375231));
		ME_SawDriveError = new clsAppMarbleIODef(_001D(107375242));
		ME_SawAtSpeed = new clsAppMarbleIODef(_001D(107375729));
		ME_SawStoped = new clsAppMarbleIODef(_001D(107375676));
		ME_PhaseError = new clsAppMarbleIODef(_001D(107375691));
		ME_HidroFault = new clsAppMarbleIODef(_001D(107375670));
		ME_XPlusLimit = new clsAppMarbleIODef(_001D(107375617));
		ME_XMinusLimit = new clsAppMarbleIODef(_001D(107375628));
		ME_XPlusMinusLimit = new clsAppMarbleIODef(_001D(107375607));
		ME_YPlusLimit = new clsAppMarbleIODef(_001D(107375550));
		ME_YMinusLimit = new clsAppMarbleIODef(_001D(107375561));
		ME_YPlusMinusLimit = new clsAppMarbleIODef(_001D(107375540));
		ME_ZMinusLimit = new clsAppMarbleIODef(_001D(107375483));
		ME_ZPlusLimit = new clsAppMarbleIODef(_001D(107374950));
		ME_LubricationLevelSensor = new clsAppMarbleIODef(_001D(107374961));
		ME_LubricationBlockSensor = new clsAppMarbleIODef(_001D(107374924));
		ME_ToolMeasure = new clsAppMarbleIODef(_001D(107374855));
		ME_ToolMeasureLimit = new clsAppMarbleIODef(_001D(107374866));
		ME_ToolAvailable = new clsAppMarbleIODef(_001D(107374837));
		ME_ToolNotAvailable = new clsAppMarbleIODef(_001D(107374780));
		ME_ToolMissing = new clsAppMarbleIODef(_001D(107374751));
		ME_WagonDownSensor = new clsAppMarbleIODef(_001D(107374762));
		ME_WagonDownButton = new clsAppMarbleIODef(_001D(107374737));
		ME_WagonUpButton = new clsAppMarbleIODef(_001D(107375224));
		ME_HandWheelX = new clsAppMarbleIODef(_001D(107375167));
		ME_HandWheelY = new clsAppMarbleIODef(_001D(107375178));
		ME_HandWheelZ = new clsAppMarbleIODef(_001D(107375157));
		ME_HandWheelC = new clsAppMarbleIODef(_001D(107375104));
		ME_HandWheelA = new clsAppMarbleIODef(_001D(107375115));
		ME_HandWheelX1 = new clsAppMarbleIODef(_001D(107375094));
		ME_HandWheelX10 = new clsAppMarbleIODef(_001D(107375041));
		ME_HandWheelX100 = new clsAppMarbleIODef(_001D(107375052));
		ME_LeftVacuumInSensor = new clsAppMarbleIODef(_001D(107375027));
		ME_RightVacuumInSensor = new clsAppMarbleIODef(_001D(107374998));
		ME_LeftRightVacumDownLimit = new clsAppMarbleIODef(_001D(107374453));
		ME_LeftRightVacumUpLimit = new clsAppMarbleIODef(_001D(107374416));
		ME_LeftVacuumOutSensor = new clsAppMarbleIODef(_001D(107374383));
		ME_RightVacuumOutSensor = new clsAppMarbleIODef(_001D(107374350));
		ME_LeftVacuumDown = new clsAppMarbleIODef(_001D(107374317));
		ME_RightVacuumDown = new clsAppMarbleIODef(_001D(107374292));
		ME_LeftVacuumUp = new clsAppMarbleIODef(_001D(107374235));
		ME_RightVacuumUp = new clsAppMarbleIODef(_001D(107374214));
		ME_LeftVacuumOk = new clsAppMarbleIODef(_001D(107374221));
		ME_RightVacuumOk = new clsAppMarbleIODef(_001D(107374712));
		ME_DoorSwitch = new clsAppMarbleIODef(_001D(107374655));
		ME_WaterSwitch = new clsAppMarbleIODef(_001D(107374666));
		ME_WaterSpindleLeak = new clsAppMarbleIODef(_001D(107374645));
		ME_MaterialMeasure = new clsAppMarbleIODef(_001D(107374616));
		ME_MaterialMeasureUp = new clsAppMarbleIODef(_001D(107374559));
		ME_MaterialMeasureDown = new clsAppMarbleIODef(_001D(107374530));
		ME_AirPreasure = new clsAppMarbleIODef(_001D(107374497));
		ME_ATCDown = new clsAppMarbleIODef(_001D(107374508));
		ME_ATCUp = new clsAppMarbleIODef(_001D(107374459));
		ME_ATCForward = new clsAppMarbleIODef(_001D(107374478));
		ME_ATCBackward = new clsAppMarbleIODef(_001D(107373913));
		ME_ATCCoverOpen = new clsAppMarbleIODef(_001D(107373892));
		ME_ATCClose = new clsAppMarbleIODef(_001D(107373903));
		ME_ATCOpen = new clsAppMarbleIODef(_001D(107373854));
		ME_PensOpen = new clsAppMarbleIODef(_001D(107373869));
		ME_PensClose = new clsAppMarbleIODef(_001D(107373820));
		ME_AxisA0 = new clsAppMarbleIODef(_001D(107373835));
		ME_AxisA45 = new clsAppMarbleIODef(_001D(107373790));
		ME_AxisAFault = new clsAppMarbleIODef(_001D(107373805));
		ME_XHome = new clsAppMarbleIODef(_001D(107373784));
		ME_YHome = new clsAppMarbleIODef(_001D(107373771));
		ME_ZHome = new clsAppMarbleIODef(_001D(107373726));
		ME_Y2Home = new clsAppMarbleIODef(_001D(107373745));
		MO_SystemStart = new clsAppMarbleIODef(_001D(107373700));
		MO_SpindleFwd = new clsAppMarbleIODef(_001D(107373711));
		MO_SpindleBwd = new clsAppMarbleIODef(_001D(107374170));
		MO_CycleStartLed = new clsAppMarbleIODef(_001D(107374149));
		MO_CycleStopLed = new clsAppMarbleIODef(_001D(107374156));
		MO_WagonUp = new clsAppMarbleIODef(_001D(107374135));
		MO_WagonDown = new clsAppMarbleIODef(_001D(107374086));
		MO_WaterMainValf = new clsAppMarbleIODef(_001D(107374101));
		MO_WaterHeadValf = new clsAppMarbleIODef(_001D(107374044));
		MO_RedLed = new clsAppMarbleIODef(_001D(107374019));
		MO_GreenLed = new clsAppMarbleIODef(_001D(107374038));
		MO_YellowLed = new clsAppMarbleIODef(_001D(107373989));
		MO_HidroRun = new clsAppMarbleIODef(_001D(107374004));
		MO_LaserOn = new clsAppMarbleIODef(_001D(107373955));
		MO_SystemReady = new clsAppMarbleIODef(_001D(107373970));
		MO_CameraValf = new clsAppMarbleIODef(_001D(107373405));
		MO_CameraEnable = new clsAppMarbleIODef(_001D(107373384));
		MO_ResetLed = new clsAppMarbleIODef(_001D(107373395));
		MO_VacuumPistons = new clsAppMarbleIODef(_001D(107373346));
		MO_VacuumLeftValf = new clsAppMarbleIODef(_001D(107373353));
		MO_VacuumRightValf = new clsAppMarbleIODef(_001D(107373328));
		MO_VacuumValf = new clsAppMarbleIODef(_001D(107373303));
		MO_VacuumLeftBlowValf = new clsAppMarbleIODef(_001D(107373250));
		MO_VacuumLeftDownValf = new clsAppMarbleIODef(_001D(107373221));
		MO_VacuumLeftUpValf = new clsAppMarbleIODef(_001D(107373192));
		MO_VacuumRightBlowValf = new clsAppMarbleIODef(_001D(107373195));
		MO_VacuumRightDownValf = new clsAppMarbleIODef(_001D(107373674));
		MO_VacuumRightUpValf = new clsAppMarbleIODef(_001D(107373641));
		MO_MaterialMeasureDownValf = new clsAppMarbleIODef(_001D(107373612));
		MO_MaterialMeasureUpValf = new clsAppMarbleIODef(_001D(107373543));
		MO_MaterialMeasureValf = new clsAppMarbleIODef(_001D(107373510));
		MO_ToolMeasurValf = new clsAppMarbleIODef(_001D(107373477));
		MO_SawStart = new clsAppMarbleIODef(_001D(107373484));
		MO_SawFwd = new clsAppMarbleIODef(_001D(107373435));
		MO_SawBwd = new clsAppMarbleIODef(_001D(107373454));
		MO_SpindleStart = new clsAppMarbleIODef(_001D(107372897));
		MO_SpindleDownValf = new clsAppMarbleIODef(_001D(107372908));
		MO_VacuumBlow = new clsAppMarbleIODef(_001D(107372883));
		MO_HoleBlow = new clsAppMarbleIODef(_001D(107372830));
		MO_Lubrication = new clsAppMarbleIODef(_001D(107372845));
		MO_MachineLight = new clsAppMarbleIODef(_001D(107372824));
		MO_SpindleUpValf = new clsAppMarbleIODef(_001D(107372771));
		MO_PensOpen = new clsAppMarbleIODef(_001D(107372778));
		MO_ToolAir = new clsAppMarbleIODef(_001D(107372729));
		MO_ATCPistonUp = new clsAppMarbleIODef(_001D(107372712));
		MO_ATCPistonDown = new clsAppMarbleIODef(_001D(107372723));
		MO_AxisA0 = new clsAppMarbleIODef(_001D(107372666));
		MO_AxisA45 = new clsAppMarbleIODef(_001D(107372685));
		MO_Buzzer = new clsAppMarbleIODef(_001D(107373148));
	}
}
