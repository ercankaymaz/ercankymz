using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class miscVars : buSerilization
{
	public bool WarningAvailable = false;

	public int cntWarning = 0;

	public int cntGeneralTick = 0;

	public int cntCommunication = 0;

	public int tickCameraImage = 0;

	public int ImageCounter = 0;

	public int StartLine = 0;

	public int systemBool32BitValue = 0;

	public int appBool32BitValue1 = 0;

	public int appBool32BitValue2 = 0;

	public int appBool32BitValue3 = 0;

	public int appBool32BitValue4 = 0;

	public int appBool16BitValue1 = 0;

	public int appBool16BitValue2 = 0;

	public int appBool16BitValue3 = 0;

	public int appBool16BitValue4 = 0;

	public int DIBool32BitValue1 = 0;

	public int DIBool16BitValue1 = 0;

	public int DOBool32BitValue1 = 0;

	public int DOBool16BitValue1 = 0;

	public int DIBool32BitValue2 = 0;

	public int DIBool16BitValue2 = 0;

	public int DOBool32BitValue2 = 0;

	public int DOBool16BitValue2 = 0;

	public int DIBool32BitValue3 = 0;

	public int DIBool16BitValue3 = 0;

	public int DOBool16BitValue3 = 0;

	public int DOBool32BitValue4 = 0;

	public int DIBool32BitValue4 = 0;

	public int DIBool16BitValue4 = 0;

	public int DOBool32BitValue3 = 0;

	public int DOBool16BitValue4 = 0;

	public bool IsCNCViewportCreated = false;

	public bool IsCadCamViewportCreated = false;

	public bool IsDialogViewportCreated = false;

	public bool IsPreviewViewportCreated = false;

	public string LoadedFileName = _0005(107397197);

	public int ThreadCount = 0;

	public bool ThreadEnable = true;

	public bool InfoFlash = false;

	public int indexInfo = -1;

	public double TotalHour = 0.0;

	public double TotalEnergizedHour = 0.0;

	public double TotalAlarmHour = 0.0;

	public double TotalRunHour = 0.0;

	public double TotalFreeHour = 0.0;

	public double MaintenanceLubricateHour = 0.0;

	public double MaintenanceHydraulicHour = 0.0;

	public double MaintenanceFanHour = 0.0;

	public double MaintenanceCabinetHour = 0.0;

	public double MaintenanceAirHour = 0.0;

	public double MaintenanceMachineCleaningHour = 0.0;

	public int TotalProducedCount = 0;

	public int TotalStartCount = 0;

	public int TotalAlarmCount = 0;

	public int WarmUpSawPhase = 0;

	public int WarmUpSpindlePhase = 0;

	public Pnt6D MinMachinePoint = new Pnt6D();

	public Pnt6D MaxMachinePoint = new Pnt6D();

	public bool ProgramParameterFailure = false;

	public bool ProgramIOFailure = false;

	[NonSerialized]
	internal static GetString _0005;

	static miscVars()
	{
		Strings.CreateGetStringDelegate(typeof(miscVars));
	}
}
