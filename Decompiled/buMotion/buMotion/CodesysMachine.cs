using System;
using System.Collections.Generic;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buComm.FTP;
using buControls.Forms.buControlForms.AlarmWarning;

namespace buMotion;

public class CodesysMachine
{
	public static CommunicationType CommType;

	public FTPConnect Ftp = new FTPConnect();

	public static string RootGlobalString;

	public static string RootIOString;

	public static string RootHardwareString;

	public static string RootCNCString;

	public static string RootPersistentString;

	public static string RootRetainString;

	public static string strSysRun;

	public static string strSysSet;

	public List<DeviceAlarmWarningInfo> DriveAlarmDefinations = new List<DeviceAlarmWarningInfo>();

	public bool bWriteSettingsParameter = false;

	public bool bWriteCNCSettingsParameter = false;

	public bool bWriteG54Parameter = false;

	public bool bWriteParkParameters = false;

	public bool bWriteToolParameter = false;

	public bool bWriteAlarmActionParameters = false;

	public bool bWriteAppParameter = false;

	public bool bWriteCounterParameters = false;

	public bool bWriteIOParameter = false;

	public bool bVariablesImported = false;

	public bool bParameterWriting = false;

	public bool bWriteCncAutoListParameter = false;

	public bool bWriteSettingsParameterDone = false;

	public bool bWriteCNCSettingsParameterDone = false;

	public bool bWriteG54ParameterDone = false;

	public bool bWriteToolParameterDone = false;

	public bool bWriteAppParameterDone = false;

	public bool bReadInputs = false;

	public bool bReadOutputs = false;

	public double AnalogInputScaleValue = 27648.0;

	public double AnalogOutputScaleValue = 27648.0;

	public double EncoderScaleValue = 1.0;

	public int SelectedAxis = 0;

	public static List<WatchItem> WatchItems;

	public TechnicianLoginInfo ActiveTechnician = new TechnicianLoginInfo();

	public List<TechnicianLoginInfo> TechnicianList = new List<TechnicianLoginInfo>();

	public List<UserLoginInfo> UserList = new List<UserLoginInfo>();

	public List<AppAlarm> AlarmList = new List<AppAlarm>();

	public List<AppWarning> WarningList = new List<AppWarning>();

	public List<InfoType> InfoList = new List<InfoType>();

	public List<InfoType> WarningHistory = new List<InfoType>();

	public List<InfoType> AlarmHistory = new List<InfoType>();

	public Pnt9DS[] G54List = new Pnt9DS[11]
	{
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS()
	};

	public Pnt9DS[] ParkList = new Pnt9DS[11]
	{
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS(),
		new Pnt9DS()
	};

	public ToolBase[] ToolList = new ToolBase[20]
	{
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase(),
		new ToolBase()
	};

	public List<Pnt9DS> MaterialMeasureList = new List<Pnt9DS>();

	public bool[] SystemBoolBlock0 = null;

	public bool[] SystemBoolBlock1 = null;

	public bool[] SystemBoolBlock2 = null;

	public bool[] SystemBoolBlock3 = null;

	public bool[] SystemBoolBlock4 = null;

	public List<VariableLREALDef> ReadVarLReal = new List<VariableLREALDef>();

	public List<VariableLREALDef> ReadVarLRealAux1 = new List<VariableLREALDef>();

	public List<VariableLREALDef> ReadVarLRealAux2 = new List<VariableLREALDef>();

	public List<VariableREALDef> ReadVarReal = new List<VariableREALDef>();

	public List<VariableDINTDef> ReadVarDint = new List<VariableDINTDef>();

	public List<VariableBOOLDef> ReadVarBool = new List<VariableBOOLDef>();

	public List<VariableBOOLDef> ReadVarBoolAux1 = new List<VariableBOOLDef>();

	public List<VariableBOOLDef> ReadVarBoolAux2 = new List<VariableBOOLDef>();

	public List<VariableBOOLDef> ReadVarIOBool = new List<VariableBOOLDef>();

	public List<VariableBOOLDef> ReadVarInputBool = new List<VariableBOOLDef>();

	public List<VariableBOOLDef> ReadVarOutputBool = new List<VariableBOOLDef>();

	public List<CodesysAxesData> AppAxis = new List<CodesysAxesData>();

	public List<DigitalOutputData> Outputs = new List<DigitalOutputData>();

	public List<DigitalInputData> Inputs = new List<DigitalInputData>();

	public List<AnalogOutputData> AnalogOutputs = new List<AnalogOutputData>();

	public List<AnalogInputData> AnalogInputs = new List<AnalogInputData>();

	public List<EncoderInputData> EncoderInputs = new List<EncoderInputData>();

	public MotionLanguages Languages = new MotionLanguages();

	public PlcDeviceData PLCSettings = new PlcDeviceData();

	public MachineSettings MachineSetting = new MachineSettings();

	public setMotionProgramVar ProgramSettings = new setMotionProgramVar();

	public setMotionRuntimeVar varRuntime = new setMotionRuntimeVar();

	public HandWheelSettings varHandWheel = new HandWheelSettings();

	public CodesysSystemSets varSystem = new CodesysSystemSets();

	public JogSettings varJog = new JogSettings();

	public AlarmActionSettings varAlarmActions = new AlarmActionSettings();

	public AxesGroupIndex AxesIndex = new AxesGroupIndex();

	public AxesGroupChar AxesChar = new AxesGroupChar();

	public ToolBase varToolActive1 = new ToolBase();

	public ToolBase varToolActive2 = new ToolBase();

	public ToolBase varToolActive3 = new ToolBase();

	public ToolBase varToolActive4 = new ToolBase();

	public ToolBase varToolActive5 = new ToolBase();

	public ToolBase varToolActive6 = new ToolBase();

	public ToolBase varToolActive7 = new ToolBase();

	public ToolBase varToolActive8 = new ToolBase();

	public CodesysCNCSets varCNC = new CodesysCNCSets();

	public CodesysCNCSets varCNC2 = null;

	public CodesysCNCSets varCNC3 = null;

	public CodesysCNCSets varCNC4 = null;

	public CodesysCNCSets varCNC5 = null;

	public CodesysCNCSets varCNC6 = null;

	public CodesysCNCSets varCNC7 = null;

	public CodesysCNCSets varCNC8 = null;

	public KinematicBase KinematicOrjinal = new KinematicBase();

	public SystemRuntime runSystem = new SystemRuntime();

	public TempVariables tempVars = new TempVariables();

	public CncRuntime runCNC = new CncRuntime();

	public PostProcessor Post = new PostProcessor();

	public ReadWriteData ReadWriteStatus = new ReadWriteData();

	public miscVars miscVar = new miscVars();

	public preBoolVars preVar = new preBoolVars();

	public buMotionCommands Commands = new buMotionCommands();

	public static F_AlarmV2 frmAlarm;

	[NonSerialized]
	internal static GetString _0006;

	static CodesysMachine()
	{
		while (true)
		{
			Type typeFromHandle = typeof(CodesysMachine);
			if (0 == 0)
			{
				Strings.CreateGetStringDelegate(typeFromHandle);
			}
			while (true)
			{
				if (4u != 0)
				{
					CommType = CommunicationType.PlcHandler;
					while (true)
					{
						RootGlobalString = _0006(107396785);
						while (true)
						{
							RootIOString = _0006(107396752);
							RootHardwareString = _0006(107396727);
							RootCNCString = _0006(107397206);
							if (2 == 0)
							{
								break;
							}
							if (false)
							{
								continue;
							}
							goto IL_0076;
						}
					}
					continue;
				}
				goto IL_00b5;
				IL_0076:
				if (5 == 0)
				{
					break;
				}
				RootPersistentString = _0006(107397177);
				RootRetainString = _0006(107397177);
				strSysRun = _0006(107397140);
				goto IL_00b5;
				IL_00b5:
				strSysSet = _0006(107397131);
				WatchItems = new List<WatchItem>();
				frmAlarm = null;
				return;
			}
		}
	}
}
