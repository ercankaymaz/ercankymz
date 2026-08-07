// Decompiled with JetBrains decompiler
// Type: buMotion.CodesysMachine
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using \u0001;
using buClass;
using buComm.FTP;
using buControls.Forms.buControlForms.AlarmWarning;
using System.Collections.Generic;

#nullable disable
namespace buMotion;

public class CodesysMachine
{
  public static CommunicationType CommType = CommunicationType.PlcHandler;
  public FTPConnect Ftp = new FTPConnect();
  public static string RootGlobalString = "Application.gvlGlobal.";
  public static string RootIOString = "Application.gvlIO.";
  public static string RootHardwareString = "Application.gvlHardware.";
  public static string RootCNCString = "Application.gvlCNC.";
  public static string RootPersistentString = "Application.PersistentVars.";
  public static string RootRetainString = "Application.PersistentVars.";
  public static string strSysRun = "sysRun";
  public static string strSysSet = "sysSet";
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
  public static List<WatchItem> WatchItems = new List<WatchItem>();
  public TechnicianLoginInfo ActiveTechnician = (TechnicianLoginInfo) new \u0002();
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
  public bool[] SystemBoolBlock0 = (bool[]) null;
  public bool[] SystemBoolBlock1 = (bool[]) null;
  public bool[] SystemBoolBlock2 = (bool[]) null;
  public bool[] SystemBoolBlock3 = (bool[]) null;
  public bool[] SystemBoolBlock4 = (bool[]) null;
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
  public AxesGroupIndex AxesIndex = (AxesGroupIndex) new AxesGroupChar();
  public AxesGroupChar AxesChar = (AxesGroupChar) new buMotionLangDefination();
  public ToolBase varToolActive1 = new ToolBase();
  public ToolBase varToolActive2 = new ToolBase();
  public ToolBase varToolActive3 = new ToolBase();
  public ToolBase varToolActive4 = new ToolBase();
  public ToolBase varToolActive5 = new ToolBase();
  public ToolBase varToolActive6 = new ToolBase();
  public ToolBase varToolActive7 = new ToolBase();
  public ToolBase varToolActive8 = new ToolBase();
  public CodesysCNCSets varCNC = new CodesysCNCSets();
  public CodesysCNCSets varCNC2 = (CodesysCNCSets) null;
  public CodesysCNCSets varCNC3 = (CodesysCNCSets) null;
  public CodesysCNCSets varCNC4 = (CodesysCNCSets) null;
  public CodesysCNCSets varCNC5 = (CodesysCNCSets) null;
  public CodesysCNCSets varCNC6 = (CodesysCNCSets) null;
  public CodesysCNCSets varCNC7 = (CodesysCNCSets) null;
  public CodesysCNCSets varCNC8 = (CodesysCNCSets) null;
  public KinematicBase KinematicOrjinal = new KinematicBase();
  public SystemRuntime runSystem = new SystemRuntime();
  public TempVariables tempVars = new TempVariables();
  public CncRuntime runCNC = new CncRuntime();
  public PostProcessor Post = new PostProcessor();
  public ReadWriteData ReadWriteStatus = new ReadWriteData();
  public miscVars miscVar = (miscVars) new AlarmActionSettings();
  public preBoolVars preVar = (preBoolVars) new miscVars();
  public buMotionCommands Commands = new buMotionCommands();
  public static F_AlarmV2 frmAlarm = (F_AlarmV2) null;
}
