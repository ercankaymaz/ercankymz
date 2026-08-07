// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using buMotion;
using dummy_ptr;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

#nullable disable
namespace \u0007;

internal class \u0003
{
  public \u0003()
  {
    ((buMotionWarningLang) this).NoWarning = "No Warning";
    ((buMotionWarningLang) this).SystemOffline = "System Offline";
    ((buMotionWarningLang) this).HomingMissing = "Homing Missing";
    ((buMotionWarningLang) this).SysteminAlarm = "System in Alarm";
    ((buMotionWarningLang) this).SystemisRunning = "System is Running";
    ((buMotionWarningLang) this).DrivesareDisable = "Drives are Disable";
    ((buMotionWarningLang) this).SystemisMoving = "System is Moving";
    ((buMotionWarningLang) this).SsytemisPaused = "Ssytem is Paused";
    ((buMotionWarningLang) this).NoAxisSelected = "No Axis Selected";
    ((buMotionWarningLang) this).CanNotdoThisCommand = "Can Not do This Command";
    ((buMotionWarningLang) this).FileNotLoaded = "File Not Loaded";
    ((buMotionWarningLang) this).AccelerationZero = "Acceleration = 0";
    ((buMotionWarningLang) this).DecelerationZero = "Deceleration = 0";
    ((buMotionWarningLang) this).JerkZero = "Jerk = 0";
    ((buMotionWarningLang) this).WaitTimeLowerThen0 = "Wait Time Lower Then 0";
    ((buMotionWarningLang) this).VelocityZero = "Velocity = 0";
    ((buMotionWarningLang) this).AxisinSimulationMode = "Axis in Simulation Mode";
    ((buMotionWarningLang) this).IOinSimulationMode = "IO in Simulation Mode";
    ((buMotionWarningLang) this).AutoMode = "Auto Mode";
    ((buMotionWarningLang) this).GantryError = "Gantry Error";
    ((buMotionWarningLang) this).LevelisnotEnoughtThisOperation = "Level is not Enought This Operation";
    ((buMotionWarningLang) this).DoorisOpen = "Door is Open";
    ((buMotionWarningLang) this).MacError = "Mac Error";
    ((buMotionErrorLang) this).SystemisNotRunning = "System is Not Running";
    ((buMotionErrorLang) this).CNCStepZero = "CNC Step = 0";
    ((buMotionErrorLang) this).PartZeronotSet = "Part Zero not Set";
    ((buMotionErrorLang) this).DoorisClosed = "Door is Closed";
    ((buMotionErrorLang) this).HandWheelisActive = "HandWheel is Active";
    ((buMotionErrorLang) this).SystemisnotReady = "System is not Ready";
    ((buMotionErrorLang) this).NotConnected = "Not Connected";
    ((buMotionErrorLang) this).ParameterWritingtoSystemPleaseTryAfewSecoondLater = "Parameter Writing to System, Please Try a few Secoond Later";
    ((buMotionErrorLang) this).ParameterHasNotDownloadedPleaseUpdateParameter = "Parameter Has Not Downloaded, Please Update Parameter";
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public abstract void m000087();

  public \u0003()
  {
    ((buMotionErrorLang) this).NoAlarm = "No Alarm";
    ((buMotionErrorLang) this).EmergencyStop = "Emergency Stop";
    ((buMotionErrorLang) this).HomingTimeout = "Homing Timeout";
    ((buMotionErrorLang) this).MACMismatch = "MAC Mismatch";
    ((buMotionErrorLang) this).InitFailure = "Init Failure";
    ((buMotionErrorLang) this).GantryError = "Gantry Error";
    ((buMotionErrorLang) this).LowAirPressure = "Low Air Pressure";
    ((buMotionErrorLang) this).SpindleFault = "Spindle Fault";
    ((buMotionErrorLang) this).ToolChangeTimeout = "Tool Change Timeout";
    ((buMotionErrorLang) this).ToolMeasureTimeout = "Tool Measure Timeout";
    ((buMotionErrorLang) this).ToolMeasureFailure = "Tool Measure Failure";
    ((buMotionErrorLang) this).ParkTimeout = "Park Timeout";
    ((buMotionErrorLang) this).CompileError = "Compile Error";
    ((buMotionErrorLang) this).ShortToolError = "Short Tool Error";
    ((buMotionErrorLang) this).LongToolError = "Long Tool Error";
    ((buMotionErrorLang) this).ToolClamperNotEmpty = "Tool Clamper Not Empty";
    ((buMotionErrorLang) this).ToolNotAvailable = "Tool Not Available";
    ((buMotionErrorLang) this).ToolNoActive = "Tool No Active";
    ((buMotionErrorLang) this).ReadNCFBError = "ReadNC FB Error";
    ((buMotionErrorLang) this).DecodeNCFBError = "DecodeNC FB Error";
    ((buMotionErrorLang) this).SmootMergeFBError = "SmootMerge FB Error";
    ((buMotionErrorLang) this).SmoothPathFBError = "SmoothPath FB Error";
    ((buMotionErrorLang) this).ExtendeVelocityFBError = "ExtendeVelocity FB Error";
    ((buMotionErrorLang) this).LimitDynamicsFBError = "Limit Dynamics FB Error";
    ((buMotionErrorLang) this).CheckVelocityFBError = "CheckVelocity FB Error";
    ((buMotionErrorLang) this).ToolCoverNotOpen = "Tool Cover Not Open";
    ((buMotionErrorLang) this).ToolCoverNotClosed = "Tool Cover Not Closed";
    ((buMotionErrorLang) this).ToolMagazineNotForwardPosition = "Tool Magazine Not Forward Position";
    ((buMotionErrorLang) this).ToolMagazineNotBackwardPosition = "Tool Magazine Not Backward Position";
    ((buMotionErrorLang) this).WaterLowLevel = "Water Low Level";
    ((buMotionErrorLang) this).DoorOpen = "Door Open";
    ((buMotionErrorLang) this).ToolStillinSpindle = "Tool Still in Spindle";
    ((buMotionErrorLang) this).ToolChangeNextToolWrong = "Tool Change Next Tool Wrong";
    ((buMotionErrorLang) this).CNCIpoFBError = "CNCIpo FB Error";
    ((buMotionErrorLang) this).CNCReadNCFBError = "CNCReadNC FB Error";
    ((buMotionErrorLang) this).CNCDecodeNCFBError = "CNCDecodeNC FB Error";
    ((buMotionErrorLang) this).BBBActivated = "BBB Activated";
    ((buMotionErrorLang) this).ToolGetError = "Tool Get Error";
    ((buMotionAxisErrorLang) this).ClamperNotClosed = "Clamper Not Closed";
    ((buMotionAxisErrorLang) this).ClamperNotEmpty = "Clamper Not Empty";
    ((buMotionAxisErrorLang) this).ToolChangeFailure = "Tool Change Failure";
    ((buMotionAxisErrorLang) this).CalculationError = "Calculation Error";
    ((buMotionAxisErrorLang) this).FileOpenError = "File Open Error";
    ((buMotionAxisErrorLang) this).FileSaveError = "File Save Error";
    ((buMotionAxisErrorLang) this).NoProduct = "No Product";
    ((buMotionAxisErrorLang) this).PhaseError = "Phase Error";
    ((buMotionAxisErrorLang) this).EthercatInitFailure = "Ethercat Init Failure";
    ((buMotionAxisErrorLang) this).AxesParameterUpdateFailure = "Axes Parameter Update Failure";
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public abstract void m000089();

  public \u0003()
  {
    ((buMotionAxisErrorLang) this).SoftwareLimitError = "Software Limit Error";
    ((buMotionAxisErrorLang) this).HardwareLimitError = "Hardware Limit Error";
    ((buMotionAxisErrorLang) this).DriveError = "Drive Error";
    ((buMotionAxisErrorLang) this).ErrorStop = "Error Stop";
    ((buMotionAxisErrorLang) this).FollowingError = "Following Error";
    ((buMotionAxisErrorLang) this).HomingTimeout = "Homing Timeout";
    ((buMotionAxisErrorLang) this).AxisCommunicationError = "Axis Communication Error";
    ((buMotionAxisErrorLang) this).PositiveDataLimitError = "Positive Data Limit Error";
    ((buMotionAxisErrorLang) this).NegativeDataLimitError = "Negative Data Limit Error";
    ((buMotionAxisErrorLang) this).PositiveSoftwareLimitError = "Positive Software Limit Error";
    ((buMotionAxisErrorLang) this).NegativeSoftwareLimitError = "Negative Software Limit Error";
    ((buMotionAxisErrorLang) this).MCStopFBError = "MCStop FB Error";
    ((buMotionAxisErrorLang) this).MCResetFBError = "MCReset FB Error";
    ((buMotionAxisErrorLang) this).MCPowerFBError = "MCPower FB Error";
    ((buMotionAxisErrorLang) this).MCMoveAbsoluteFBError = "MCMoveAbsolute FB Error";
    ((buMotionAxisErrorLang) this).MCMoveRelativeFBError = "MCMoveRelative FB Error";
    ((buMotionAxisErrorLang) this).MCHomeFBError = "MCHome FB Error";
    ((buMotionAxisErrorLang) this).MCSetPositionFBError = "MCSetPosition FB Error";
    ((buMotionAxisErrorLang) this).MCSetHomeFBError = "MCSetHome FB Error";
    ((buMotionAxisErrorLang) this).MCJogFBError = "MCJog FB Error";
    ((buMotionAxisWarningLang) this).MCLimitDynamicsFBError = "MCLimitDynamics FB Error";
    ((buMotionAxisWarningLang) this).MCGearInFBError = "MCGearIn FB Error";
    ((buMotionAxisWarningLang) this).MCGearOutFBError = "MCGearOut FB Error";
    ((buMotionAxisWarningLang) this).AxisOutofLimits = "Axis Out of Limits";
    ((buMotionAxisWarningLang) this).SMCChangeDynamicLimitsFBError = "SMCChangeDynamicLimits FB Error";
    ((buMotionAxisWarningLang) this).SMCChangeRatioFBError = "SMCChangeRatio FB Error";
    ((buMotionAxisWarningLang) this).SMCHomeFBError = "SMCHome FB Error";
    ((buMotionAxisWarningLang) this).SMCSoftLimitFBError = "SMCSoftLimit FB Error";
    ((buMotionAxisWarningLang) this).SMCRampTypeFBError = "SMCRampType FB Error";
    ((buMotionAxisWarningLang) this).SMCMoveTypeFBError = "SMCMoveType FB Error";
    ((buMotionAxisWarningLang) this).ReInitFBError = "ReInit FB Error";
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public abstract void m00008B();

  public \u0003()
  {
    ((buMotionAxisWarningLang) this).AxisDisable = "Axis Disable";
    ((buMotionAxisWarningLang) this).AxisinError = "Axis in Error";
    ((buMotionAxisWarningLang) this).AxisNeedHoming = "Axis Need Homing";
    ((buMotionAxisWarningLang) this).AxisinMove = "Axis in Move";
    ((buMotionAxisWarningLang) this).AxisFeedoverrideZero = "Axis Feedoverride = 0";
    ((buMotionAxisWarningLang) this).AxisVelocityZero = "Axis Velocity = 0";
    ((buMotionAxisWarningLang) this).AxisAccelerationZero = "Axis Acceleration = 0";
    ((buMotionAxisWarningLang) this).AxisDecelerationZero = "Axis Deceleration = 0";
    ((buMotionAxisWarningLang) this).AxisJerkZero = "Axis Jerk = 0";
    ((buMotionAxisWarningLang) this).AxisHoming = "Axis Homing";
    ((buMotionAxisWarningLang) this).AxisinAction = "Axis in Action";
    ((buMotionAxisWarningLang) this).GainError = "Gain Error";
    ((buMotionAxisWarningLang) this).DriveError = "Drive Error";
    ((buMotionAxisWarningLang) this).ScaleParameterError = "Scale Parameter Error";
    ((buMotionAxisWarningLang) this).UnitParameterNotCorrect = "Unit Parameter Not Correct";
    ((buMotionAxisWarningLang) this).EncoderParamterNotCorrect = "Encoder Paramter Not Correct";
    ((buMotionAxisWarningLang) this).MaxAccelerationParameterNotCorrect = "Max Acceleration Parameter Not Correct";
    ((buMotionAxisWarningLang) this).MaxDecelerationParameterNotCorrect = "Max Deceleration Parameter Not Correct";
    ((buMotionAxisWarningLang) this).MaxVelocityParameterNotCorrect = "Max Velocity Parameter Not Correct";
    ((buMotionAxisWarningLang) this).GantryModeError = "Gantry Mode Error";
    ((buMotionAxisWarningLang) this).NotMoveableAxis = "Not Moveable Axis";
    ((buMotionAxisWarningLang) this).MaxJerkParameterNotCorrect = "Max Jerk Parameter Not Correct";
    ((buMotionAxisWarningLang) this).DriveSetEnocderModeError = "Drive Set Enocder Mode Error";
    ((buMotionAxisWarningLang) this).DriveSetAbsoluteSetError = "Drive Set Absolute Set Error";
    ((buMotionAxisWarningLang) this).DriveSetControlModeError = "Drive Set Control Mode Error";
    ((buMotionAxisWarningLang) this).DriveSetVelocityModeError = "Drive Set Velocity Mode Error";
    ((buMotionMessageLang) this).DriveSetFollowError = "Drive Set Follow Error";
    ((buMotionMessageLang) this).DriveSetNegativeCurrentError = "Drive Set Negative Current Error";
    ((buMotionMessageLang) this).DriveSetPositiveCurrentError = "Drive Set Positive Current Error";
    ((buMotionMessageLang) this).DriveSetAnalogOutError = "Drive Set Analog Out Error";
    ((buMotionMessageLang) this).DriveSetAnalogInputError = "Drive Set Analog Input Error";
    ((buMotionMessageLang) this).DriveSetVelocityLoopKPError = "Drive Set Velocity Loop KP Error";
    ((buMotionMessageLang) this).DriveSetVelocityLoopKIError = "Drive Set Velocity Loop KI Error";
    ((buMotionMessageLang) this).DriveSetVelocityLoopFFError = "Drive Set Velocity Loop FF Error";
    ((buMotionMessageLang) this).DriveSetPositionLoopKPError = "Drive Set Position Loop KP Error";
    ((buMotionMessageLang) this).DriveSetPositionLoopKIError = "Drive Set Position Loop KI Error";
    ((buMotionMessageLang) this).DenumeratorZero = "Denumerator = 0";
    ((buMotionMessageLang) this).NumeratorZero = "Numerator = 0";
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public abstract void m00008D();

  public \u0003()
  {
    ((buMotionMessageLang) this).DoYoutoTurnDefault = "Do You to Turn Default";
    ((buMotionMessageLang) this).DoYouWanttoDeleteFile = "Do You Want to Delete  File";
    ((buMotionMessageLang) this).FileisLoading = "File is Loading";
    ((buMotionMessageLang) this).FileisLoaded = "File is Loaded";
    ((buMotionMessageLang) this).YourLevelNotEnoughtThisOperation = "Your Level Not Enought This Operation";
    ((buMotionMessageLang) this).DoYouWanttoClearAll = "Do You Want to Clear All?";
    ((buMotionMessageLang) this).PasswordError = "Password Error";
    ((buMotionMessageLang) this).DoYouWanttoRemove = "Do You Want to Remove";
    ((buMotionMessageLang) this).DoYouWanttoRemoveAll = "Do You Want to Remove All";
    ((buMotionMessageLang) this).GCodeLineNumberHigherthenMaxLimit = "G Code Line Number Higher then Max Limit";
    ((buMotionMessageLang) this).ExitFromPRogram = "Exit From PRogram";
    ((buMotionMessageLang) this).ValueIncorrectFormat = "Value Incorrect Format";
    ((buMotionMessageLang) this).DoYouWanttoDelete = "Do You Want to Delete";
    ((buMotionMessageLang) this).DoYouWanttoUpdate = "Do You Want to Update";
    ((buMotionMessageLang) this).ThisToolExist = "This Tool Exist";
    ((buMotionMessageLang) this).YouCantChangeParameterBeforeLoad = "You Can't Change Parameter Before Load";
    ((buMotionMessageLang) this).NoSelectedEntities = "No Selected Entities";
    ((buMotionMessageLang) this).DoYouWanttoRemoveTool = "Do You Want to Remove Tool";
    ((buMotionMessageLang) this).DoYouWanttoUpdateTool = "Do You Want to Update Tool";
    ((buMotionMessageLang) this).NoSelectedPoint = "No Selected Point";
    ((buMotionMessageLang) this).DoyouWanttoSavetoFile = "Do you Want to Save to File";
    ((buMotionMessageLang) this).DoYouWanttoClearList = "Do You Want to Clear List";
    ((buMotionMessageLang) this).DoYouWanttoSaveList = "Do You Want to Save List";
    ((buMotionMessageLang) this).DoYouWanttoRemoveAllEx = "Do You Want to Remove All?";
    ((buMotionMessageLang) this).DoYouWanttoRemoveEx = "Do You Want to Remove";
    ((buMotionMessageLang) this).XAxisValueGreatThanLimitDoYouWanttoContinue = "X Axis Value Great Than Limit, Do You Want to Continue";
    ((buMotionMessageLang) this).XAxisValueLowerThanLimitDoYouWanttoContinue = "X Axis Value Lower Than Limit, Do You Want to Continue";
    ((buMotionMessageLang) this).YAxisValueGreatThanLimitDoYouWanttoContinue = "Y Axis Value Great Than Limit, Do You Want to Continue";
    ((buMotionMessageLang) this).YAxisValueLowerThanLimitDoYouWanttoContinue = "Y Axis Value Lower Than Limit, Do You Want to Continue";
    ((buMotionMessageLang) this).DoYouWanttoStartFromMiddlePoint = "Do You Want to Start From Middle Point";
    ((buMotionMessageLang) this).ThereisAnotherOperationforThisIDDoYouWanttoRemoveThem = "There is Another Operation for This ID, Do You Want to Remove Them";
    ((buMotionMessageLang) this).NoDefinedIPAddressforController = "No Defined IP Address for Controller";
    ((buMotionMessageLang) this).AxisValueisHigherThanLimit = "Axis Value is Higher Than Limit";
    ((buMotionMessageLang) this).AxisValueisLowerThanLimit = "Axis Value is Lower Than Limit";
    ((buMotionMessageLang) this).DoYouWanttoClearTable = "Do You Want to Clear Table";
    ((buMotionMessageLang) this).DoYouWanttoDeleteItem = "Do You Want to Delete Item";
    ((buMotionMessageLang) this).DoYouWanttoAddItem = "Do You Want to Add Item";
    ((buMotionMessageLang) this).FileZMinValueLowerThanMachineMinValue = "File Z Min Value Lower Than Machine Min Value";
    ((buMotionMessageLang) this).FileAMinValueLowerThanMachineMinValue = "File A Min Value Lower Than Machine Min Value";
    ((buMotionMessageLang) this).FileZMaxValueGreaterThanMachineMinValue = "File Z Max Value Greater Than Machine Min Value";
    ((buMotionMessageLang) this).FileAMaxValueGreaterThanMachineMinValue = "File A Max Value Greater Than Machine Min Value";
    ((buMotionMessageLang) this).FileBMinValueLowerThanMachineMinValue = "File B Min Value Lower Than Machine Min Value";
    ((buMotionMessageLang) this).FileCMinValueLowerThanMachineMinValue = "File C Min Value Lower Than Machine Min Value";
    ((buMotionMessageLang) this).FileBMaxValueGreaterThanMachineMinValue = "File B Max Value Greater Than Machine Min Value";
    ((buMotionMessageLang) this).FileCMaxValueGreaterThanMachineMinValue = "File C Max Value Greater Than Machine Min Value";
    ((buMotionMessageLang) this).DoYouWanttoMakeThisOperation = "Do You Want to Make This Operation";
    ((buMotionMessageLang) this).YouMustSelectPattern = "You Must Select Pattern";
    ((buMotionMessageLang) this).YouMustSelectSingleBlock = "You Must Select Single Block";
    ((buMotionMessageLang) this).ReportHasBeenSentSuccesful = "Report Has Been Sent Succesful";
    ((buMotionMessageLang) this).ReportSendError = "Report Send Error";
    ((buMotionItems) this).ReportHasBeenCreated = "Report Has Been Created";
    ((buMotionItems) this).DoyouwanttoGoParkposition = "Do you want to Go Park position";
    ((buMotionMisc) this).DoyouwanttoGoServiceposition = "Do you want to Go Service position";
    ((buMotionMisc) this).DoyouwanttoGoDefinedposition = "Do you want to Go Defined position";
    ((buMotionMisc) this).DoyouwanttoShowLimits = "Do you want to Show Limits";
    ((buMotionLogVer5) this).DoyouwanttoMakeHoming = "Do you want to Make Homing";
    ((buMotionLogVer5) this).FileisNotAvailable = "File is Not Available";
    ((buMotionLogVer5) this).ParameterValueIncorrectFormat = "Parameter Value Incorrect Format";
    ((buMotionLogVer5) this).ToolValueIncorrectFormat = "Tool Value Incorrect Format";
    ((buMotionLogVer5) this).WrongToolNumber = "Wrong Tool Number";
    ((buMotionLogVer5) this).ItisAlreadyInchSystemDoYouWanttoContinue = "It is Already Inch System Do You Want to Continue";
    ((buMotionLogVer5) this).ItisAlreadymmSystemDoYouWanttoContinue = "It is Already mm System Do You Want to Continue";
    ((buMotionLogVer5) this).NoFileLoaded = "No File Loaded";
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public abstract void m00008F();

  static int \u0001([In] \u0003.\u0003.\u0007 obj0)
  {
    return \u0007.\u0003.\u0001(obj0) | \u0007.\u0003.\u0001(obj0) << 16 /*0x10*/;
  }

  static int \u0001([In] \u0003.\u0003.\u0003 obj0, [In] \u0003.\u0003.\u0002 obj1, [In] int obj2)
  {
    // ISSUE: reference to a compiler-generated field
    obj2 = Math.Min(Math.Min(obj2, 32768 /*0x8000*/ - ((\u0005.\u0001) obj0).\u0002), \u0007.\u0003.\u0001(obj1));
    // ISSUE: reference to a compiler-generated field
    int num1 = 32768 /*0x8000*/ - ((\u0005.\u0001) obj0).\u0001;
    int num2;
    if (obj2 > num1)
    {
      // ISSUE: reference to a compiler-generated field
      num2 = buMotionLogVer5.\u0001(obj1, ((\u0003.\u0003.\u0006) obj0).\u0001, ((\u0005.\u0001) obj0).\u0001, num1);
      if (num2 == num1)
        num2 += buMotionLogVer5.\u0001(obj1, ((\u0003.\u0003.\u0006) obj0).\u0001, 0, obj2 - num1);
    }
    else
    {
      // ISSUE: reference to a compiler-generated field
      num2 = buMotionLogVer5.\u0001(obj1, ((\u0003.\u0003.\u0006) obj0).\u0001, ((\u0005.\u0001) obj0).\u0001, obj2);
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    ((\u0005.\u0001) obj0).\u0001 = ((\u0005.\u0001) obj0).\u0001 + num2 & (int) short.MaxValue;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    ((\u0005.\u0001) obj0).\u0002 = ((\u0005.\u0001) obj0).\u0002 + num2;
    return num2;
  }

  static int \u0001([In] \u0003.\u0003.\u0002 obj0) => ((\u0003.\u0003.\u0006) obj0).\u0003;

  static byte[] \u0001([In] byte[] obj0)
  {
    \u0003.\u0003.\u0007 obj = (\u0003.\u0003.\u0007) new \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D(obj0);
    byte[] numArray = new byte[0];
    int num1 = \u0007.\u0003.\u0001(obj);
    int actualValue = num1 >> 24;
    if (num1 - (actualValue << 24) != 8223355)
      throw new FormatException("Unknown Header");
    switch (actualValue)
    {
      case 1:
        int length1 = \u0007.\u0003.\u0001(obj);
        numArray = new byte[length1];
        int num2;
        for (int index = 0; index < length1; index += num2)
        {
          int length2 = \u0007.\u0003.\u0001(obj);
          num2 = \u0007.\u0003.\u0001(obj);
          byte[] buffer = new byte[length2];
          obj.Read(buffer, 0, buffer.Length);
          \u0007.\u0003.\u0001(num2, (\u0003.\u0003.\u0001) new \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D(buffer), numArray, index);
        }
        break;
      case 3:
        using (ICryptoTransform cryptoTransform = buMotionLogVer5.\u0001(true, new byte[16 /*0x10*/]
        {
          (byte) 201,
          (byte) 80 /*0x50*/,
          (byte) 94,
          (byte) 114,
          (byte) 235,
          (byte) 160 /*0xA0*/,
          (byte) 51,
          (byte) 114,
          (byte) 247,
          (byte) 67,
          (byte) 48 /*0x30*/,
          (byte) 250,
          (byte) 50,
          (byte) 202,
          (byte) 208 /*0xD0*/,
          (byte) 95
        }, new byte[16 /*0x10*/]
        {
          (byte) 65,
          (byte) 118,
          (byte) 42,
          (byte) 16 /*0x10*/,
          (byte) 60,
          (byte) 135,
          (byte) 183,
          (byte) 161,
          (byte) 59,
          (byte) 70,
          (byte) 97,
          (byte) 95,
          (byte) 176 /*0xB0*/,
          (byte) 151,
          (byte) 119,
          (byte) 160 /*0xA0*/
        }))
        {
          numArray = \u0007.\u0003.\u0001(cryptoTransform.TransformFinalBlock(obj0, 4, obj0.Length - 4));
          break;
        }
      default:
        throw new ArgumentOutOfRangeException("version", (object) actualValue, "Selected compression algorithm is not supported.");
    }
    obj.Close();
    return numArray;
  }

  static void \u0001([In] \u0003.\u0003.\u0002 obj0)
  {
    ((\u0003.\u0003.\u0006) obj0).\u0001 = ((\u0003.\u0003.\u0006) obj0).\u0001 >> (((\u0003.\u0003.\u0006) obj0).\u0003 & 7);
    ((\u0003.\u0003.\u0006) obj0).\u0003 = ((\u0003.\u0003.\u0006) obj0).\u0003 & -8;
  }

  static int \u0001([In] \u0003.\u0003.\u0007 obj0) => obj0.ReadByte() | obj0.ReadByte() << 8;

  static int \u0001([In] \u0003.\u0003.\u0002 obj0, [In] int obj1)
  {
    if (((\u0003.\u0003.\u0006) obj0).\u0003 < obj1)
    {
      if (((\u0003.\u0003.\u0006) obj0).\u0001 == ((\u0003.\u0003.\u0006) obj0).\u0002)
        return -1;
      \u0003.\u0003.\u0002 obj2 = obj0;
      int num1 = (int) ((\u0003.\u0003.\u0006) obj0).\u0001;
      byte[] numArray1 = ((\u0003.\u0003.\u0006) obj0).\u0001;
      \u0003.\u0003.\u0002 obj3 = obj0;
      int num2 = ((\u0003.\u0003.\u0006) obj0).\u0001;
      int num3 = num2 + 1;
      ((\u0003.\u0003.\u0006) obj3).\u0001 = num3;
      int index1 = num2;
      int num4 = (int) numArray1[index1] & (int) byte.MaxValue;
      byte[] numArray2 = ((\u0003.\u0003.\u0006) obj0).\u0001;
      \u0003.\u0003.\u0002 obj4 = obj0;
      int num5 = ((\u0003.\u0003.\u0006) obj0).\u0001;
      int num6 = num5 + 1;
      ((\u0003.\u0003.\u0006) obj4).\u0001 = num6;
      int index2 = num5;
      int num7 = ((int) numArray2[index2] & (int) byte.MaxValue) << 8;
      int num8 = (num4 | num7) << ((\u0003.\u0003.\u0006) obj0).\u0003;
      int num9 = num1 | num8;
      ((\u0003.\u0003.\u0006) obj2).\u0001 = (uint) num9;
      ((\u0003.\u0003.\u0006) obj0).\u0003 = ((\u0003.\u0003.\u0006) obj0).\u0003 + 16 /*0x10*/;
    }
    return (int) ((long) ((\u0003.\u0003.\u0006) obj0).\u0001 & (long) ((1 << obj1) - 1));
  }

  static \u0003.\u0003.\u0004 \u0001([In] \u0003.\u0003.\u0005 obj0)
  {
    byte[] destinationArray = new byte[((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0002];
    // ISSUE: reference to a compiler-generated field
    Array.Copy((Array) ((\u0005.\u0001) obj0).\u0002, 0, (Array) destinationArray, 0, ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0002);
    return (\u0003.\u0003.\u0004) new \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D(destinationArray);
  }

  static bool \u0001([In] \u0003.\u0003.\u0001 obj0)
  {
    switch (((\u0003.\u0003.\u0005) obj0).\u0001)
    {
      case 2:
        if (((\u0003.\u0003.\u0005) obj0).\u0001)
        {
          ((\u0003.\u0003.\u0005) obj0).\u0001 = 12;
          return false;
        }
        int num1 = \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, 3);
        if (num1 < 0)
          return false;
        buMotionLogVer5.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, 3);
        if ((num1 & 1) != 0)
          ((\u0003.\u0003.\u0005) obj0).\u0001 = true;
        switch (num1 >> 1)
        {
          case 0:
            \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001);
            ((\u0003.\u0003.\u0005) obj0).\u0001 = 3;
            break;
          case 1:
            // ISSUE: reference to a compiler-generated field
            ((\u0003.\u0003.\u0005) obj0).\u0001 = \u0005.\u0001.\u0001;
            // ISSUE: reference to a compiler-generated field
            ((\u0003.\u0003.\u0005) obj0).\u0002 = \u0005.\u0001.\u0002;
            ((\u0003.\u0003.\u0005) obj0).\u0001 = 7;
            break;
          case 2:
            ((\u0003.\u0003.\u0005) obj0).\u0001 = (\u0003.\u0003.\u0005) new \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D();
            ((\u0003.\u0003.\u0005) obj0).\u0001 = 6;
            break;
        }
        return true;
      case 3:
        if ((((\u0003.\u0003.\u0005) obj0).\u0005 = \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, 16 /*0x10*/)) < 0)
          return false;
        buMotionLogVer5.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, 16 /*0x10*/);
        ((\u0003.\u0003.\u0005) obj0).\u0001 = 4;
        goto case 4;
      case 4:
        if (\u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, 16 /*0x10*/) < 0)
          return false;
        buMotionLogVer5.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, 16 /*0x10*/);
        ((\u0003.\u0003.\u0005) obj0).\u0001 = 5;
        goto case 5;
      case 5:
        int num2 = \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0005);
        ((\u0003.\u0003.\u0005) obj0).\u0005 = ((\u0003.\u0003.\u0005) obj0).\u0005 - num2;
        if (((\u0003.\u0003.\u0005) obj0).\u0005 != 0)
          return !buMotionLogVer5.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001);
        ((\u0003.\u0003.\u0005) obj0).\u0001 = 2;
        return true;
      case 6:
        if (!\u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001, ((\u0003.\u0003.\u0005) obj0).\u0001))
          return false;
        ((\u0003.\u0003.\u0005) obj0).\u0001 = \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001);
        ((\u0003.\u0003.\u0005) obj0).\u0002 = \u0007.\u0003.\u0001(((\u0003.\u0003.\u0005) obj0).\u0001);
        ((\u0003.\u0003.\u0005) obj0).\u0001 = 7;
        goto case 7;
      case 7:
      case 8:
      case 9:
      case 10:
        return buMotionLogVer5.\u0001(obj0);
      case 12:
        return false;
      default:
        return false;
    }
  }

  static string \u0001([In] int obj0)
  {
    // ISSUE: unable to decompile the method.
  }

  static bool \u0001([In] \u0003.\u0003.\u0005 obj0, [In] \u0003.\u0003.\u0002 obj1)
  {
    while (true)
    {
      switch (((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001)
      {
        case 0:
          ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0002 = \u0007.\u0003.\u0001(obj1, 5);
          if (((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0002 >= 0)
          {
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0002 = ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0002 + 257;
            buMotionLogVer5.\u0001(obj1, 5);
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001 = 1;
            goto case 1;
          }
          goto label_24;
        case 1:
          ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0003 = \u0007.\u0003.\u0001(obj1, 5);
          if (((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0003 >= 0)
          {
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0003 = ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0003 + 1;
            buMotionLogVer5.\u0001(obj1, 5);
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0005 = ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0002 + ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0003;
            // ISSUE: reference to a compiler-generated field
            ((\u0005.\u0001) obj0).\u0002 = new byte[((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0005];
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001 = 2;
            goto case 2;
          }
          goto label_25;
        case 2:
          ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0004 = \u0007.\u0003.\u0001(obj1, 4);
          if (((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0004 >= 0)
          {
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0004 = ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0004 + 4;
            buMotionLogVer5.\u0001(obj1, 4);
            // ISSUE: reference to a compiler-generated field
            ((\u0005.\u0001) obj0).\u0001 = new byte[19];
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007 = 0;
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001 = 3;
            goto case 3;
          }
          goto label_26;
        case 3:
          for (; ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007 < ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0004; ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007 = ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007 + 1)
          {
            int num = \u0007.\u0003.\u0001(obj1, 3);
            if (num < 0)
              return false;
            buMotionLogVer5.\u0001(obj1, 3);
            // ISSUE: reference to a compiler-generated field
            ((\u0005.\u0001) obj0).\u0001[\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D.\u0003[((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007]] = (byte) num;
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          ((\u0005.\u0001) obj0).\u0001 = (\u0003.\u0003.\u0004) new \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D(((\u0005.\u0001) obj0).\u0001);
          // ISSUE: reference to a compiler-generated field
          ((\u0005.\u0001) obj0).\u0001 = (byte[]) null;
          ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007 = 0;
          ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001 = 4;
          goto case 4;
        case 4:
          int num1;
          // ISSUE: reference to a compiler-generated field
          while (((num1 = buMotionLogVer5.\u0001(((\u0005.\u0001) obj0).\u0001, obj1)) & -16) == 0)
          {
            // ISSUE: reference to a compiler-generated field
            byte[] numArray = ((\u0005.\u0001) obj0).\u0002;
            \u0003.\u0003.\u0005 obj = obj0;
            int num2 = ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007;
            int num3 = num2 + 1;
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj).\u0007 = num3;
            int index = num2;
            int num4 = (int) (((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001 = (byte) num1);
            numArray[index] = (byte) num4;
            if (((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007 == ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0005)
              return true;
          }
          if (num1 >= 0)
          {
            if (num1 >= 17)
              ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001 = (byte) 0;
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0006 = num1 - 16 /*0x10*/;
            ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001 = 5;
            goto case 5;
          }
          goto label_28;
        case 5:
          // ISSUE: reference to a compiler-generated field
          int num5 = \u0005.\u0001.\u0002[((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0006];
          int num6 = \u0007.\u0003.\u0001(obj1, num5);
          if (num6 >= 0)
          {
            buMotionLogVer5.\u0001(obj1, num5);
            // ISSUE: reference to a compiler-generated field
            int num7 = num6 + \u0005.\u0001.\u0001[((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0006];
            while (num7-- > 0)
            {
              // ISSUE: reference to a compiler-generated field
              byte[] numArray = ((\u0005.\u0001) obj0).\u0002;
              \u0003.\u0003.\u0005 obj = obj0;
              int num8 = ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007;
              int num9 = num8 + 1;
              ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj).\u0007 = num9;
              int index = num8;
              int num10 = (int) ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001;
              numArray[index] = (byte) num10;
            }
            if (((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0007 != ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0005)
            {
              ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0001 = 4;
              continue;
            }
            goto label_31;
          }
          goto label_30;
        default:
          continue;
      }
    }
label_24:
    return false;
label_25:
    return false;
label_26:
    return false;
label_28:
    return false;
label_30:
    return false;
label_31:
    return true;
  }

  static int \u0001([In] \u0003.\u0003.\u0003 obj0) => ((\u0005.\u0001) obj0).\u0002;

  static \u0003.\u0003.\u0004 \u0001([In] \u0003.\u0003.\u0005 obj0)
  {
    byte[] destinationArray = new byte[((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0003];
    // ISSUE: reference to a compiler-generated field
    Array.Copy((Array) ((\u0005.\u0001) obj0).\u0002, ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0002, (Array) destinationArray, 0, ((\u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D) obj0).\u0003);
    return (\u0003.\u0003.\u0004) new \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D(destinationArray);
  }

  static int \u0001([In] \u0003.\u0003.\u0003 obj0) => 32768 /*0x8000*/ - ((\u0005.\u0001) obj0).\u0002;

  static void \u0001([In] \u0003.\u0003.\u0003 obj0, [In] int obj1)
  {
    \u0003.\u0003.\u0003 obj2 = obj0;
    // ISSUE: reference to a compiler-generated field
    int num1 = ((\u0005.\u0001) obj0).\u0002;
    int num2 = num1 + 1;
    // ISSUE: reference to a compiler-generated field
    ((\u0005.\u0001) obj2).\u0002 = num2;
    if (num1 == 32768 /*0x8000*/)
      throw new InvalidOperationException();
    byte[] numArray = ((\u0003.\u0003.\u0006) obj0).\u0001;
    \u0003.\u0003.\u0003 obj3 = obj0;
    // ISSUE: reference to a compiler-generated field
    int num3 = ((\u0005.\u0001) obj0).\u0001;
    int num4 = num3 + 1;
    // ISSUE: reference to a compiler-generated field
    ((\u0005.\u0001) obj3).\u0001 = num4;
    int index = num3;
    int num5 = (int) (byte) obj1;
    numArray[index] = (byte) num5;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    ((\u0005.\u0001) obj0).\u0001 = ((\u0005.\u0001) obj0).\u0001 & (int) short.MaxValue;
  }

  static int \u0001([In] \u0003.\u0003.\u0002 obj0)
  {
    return ((\u0003.\u0003.\u0006) obj0).\u0002 - ((\u0003.\u0003.\u0006) obj0).\u0001 + (((\u0003.\u0003.\u0006) obj0).\u0003 >> 3);
  }

  static void \u0001([In] int obj0, [In] int obj1, [In] \u0003.\u0003.\u0002 obj2, [In] byte[] obj3)
  {
    if (((\u0003.\u0003.\u0006) obj2).\u0001 < ((\u0003.\u0003.\u0006) obj2).\u0002)
      throw new InvalidOperationException();
    int num = obj0 + obj1;
    if (0 > obj0 || obj0 > num || num > obj3.Length)
      throw new ArgumentOutOfRangeException();
    if ((obj1 & 1) != 0)
    {
      ((\u0003.\u0003.\u0006) obj2).\u0001 = ((\u0003.\u0003.\u0006) obj2).\u0001 | (uint) (((int) obj3[obj0++] & (int) byte.MaxValue) << ((\u0003.\u0003.\u0006) obj2).\u0003);
      ((\u0003.\u0003.\u0006) obj2).\u0003 = ((\u0003.\u0003.\u0006) obj2).\u0003 + 8;
    }
    ((\u0003.\u0003.\u0006) obj2).\u0001 = obj3;
    ((\u0003.\u0003.\u0006) obj2).\u0001 = obj0;
    ((\u0003.\u0003.\u0006) obj2).\u0002 = num;
  }

  static void \u0001([In] \u0003.\u0003.\u0004 obj0, [In] byte[] obj1)
  {
    int[] numArray1 = new int[16 /*0x10*/];
    int[] numArray2 = new int[16 /*0x10*/];
    for (int index1 = 0; index1 < obj1.Length; ++index1)
    {
      int index2 = (int) obj1[index1];
      if (index2 > 0)
        ++numArray1[index2];
    }
    int num1 = 0;
    int length = 512 /*0x0200*/;
    for (int index = 1; index <= 15; ++index)
    {
      numArray2[index] = num1;
      num1 += numArray1[index] << 16 /*0x10*/ - index;
      if (index >= 10)
      {
        int num2 = numArray2[index] & 130944;
        int num3 = num1 & 130944;
        length += num3 - num2 >> 16 /*0x10*/ - index;
      }
    }
    // ISSUE: reference to a compiler-generated field
    ((\u0005.\u0001) obj0).\u0001 = new short[length];
    int num4 = 512 /*0x0200*/;
    for (int index3 = 15; index3 >= 10; --index3)
    {
      int num5 = num1 & 130944;
      num1 -= numArray1[index3] << 16 /*0x10*/ - index3;
      for (int index4 = num1 & 130944; index4 < num5; index4 += 128 /*0x80*/)
      {
        // ISSUE: reference to a compiler-generated field
        ((\u0005.\u0001) obj0).\u0001[(int) \u0007.\u0003.\u0001(index4)] = (short) (-num4 << 4 | index3);
        num4 += 1 << index3 - 9;
      }
    }
    for (int index5 = 0; index5 < obj1.Length; ++index5)
    {
      int index6 = (int) obj1[index5];
      if (index6 != 0)
      {
        int num6 = numArray2[index6];
        int index7 = (int) \u0007.\u0003.\u0001(num6);
        if (index6 <= 9)
        {
          do
          {
            // ISSUE: reference to a compiler-generated field
            ((\u0005.\u0001) obj0).\u0001[index7] = (short) (index5 << 4 | index6);
            index7 += 1 << index6;
          }
          while (index7 < 512 /*0x0200*/);
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          int num7 = (int) ((\u0005.\u0001) obj0).\u0001[index7 & 511 /*0x01FF*/];
          int num8 = 1 << (num7 & 15);
          int num9 = -(num7 >> 4);
          do
          {
            // ISSUE: reference to a compiler-generated field
            ((\u0005.\u0001) obj0).\u0001[num9 | index7 >> 9] = (short) (index5 << 4 | index6);
            index7 += 1 << index6;
          }
          while (index7 < num8);
        }
        numArray2[index6] = num6 + (1 << 16 /*0x10*/ - index6);
      }
    }
  }

  static short \u0001([In] int obj0)
  {
    return (short) ((int) \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D.\u0001[obj0 & 15] << 12 | (int) \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D.\u0001[obj0 >> 4 & 15] << 8 | (int) \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D.\u0001[obj0 >> 8 & 15] << 4 | (int) \u007B5b810e90\u002D7eb5\u002D4669\u002Dba2d\u002D9395d6969d67\u007D.\u0001[obj0 >> 12]);
  }

  static void \u0001([In] \u0003.\u0003.\u0003 obj0, [In] int obj1, [In] int obj2)
  {
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    if ((((\u0005.\u0001) obj0).\u0002 = ((\u0005.\u0001) obj0).\u0002 + obj1) > 32768 /*0x8000*/)
      throw new InvalidOperationException();
    // ISSUE: reference to a compiler-generated field
    int sourceIndex = ((\u0005.\u0001) obj0).\u0001 - obj2 & (int) short.MaxValue;
    int num1 = 32768 /*0x8000*/ - obj1;
    // ISSUE: reference to a compiler-generated field
    if (sourceIndex <= num1 && ((\u0005.\u0001) obj0).\u0001 < num1)
    {
      if (obj1 <= obj2)
      {
        // ISSUE: reference to a compiler-generated field
        Array.Copy((Array) ((\u0003.\u0003.\u0006) obj0).\u0001, sourceIndex, (Array) ((\u0003.\u0003.\u0006) obj0).\u0001, ((\u0005.\u0001) obj0).\u0001, obj1);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ((\u0005.\u0001) obj0).\u0001 = ((\u0005.\u0001) obj0).\u0001 + obj1;
      }
      else
      {
        while (obj1-- > 0)
        {
          byte[] numArray = ((\u0003.\u0003.\u0006) obj0).\u0001;
          \u0003.\u0003.\u0003 obj = obj0;
          // ISSUE: reference to a compiler-generated field
          int num2 = ((\u0005.\u0001) obj0).\u0001;
          int num3 = num2 + 1;
          // ISSUE: reference to a compiler-generated field
          ((\u0005.\u0001) obj).\u0001 = num3;
          int index = num2;
          int num4 = (int) ((\u0003.\u0003.\u0006) obj0).\u0001[sourceIndex++];
          numArray[index] = (byte) num4;
        }
      }
    }
    else
      buMotionLogVer5.\u0001(obj0, sourceIndex, obj1);
  }

  static int \u0001([In] int obj0, [In] \u0003.\u0003.\u0001 obj1, [In] byte[] obj2, [In] int obj3)
  {
    int num1 = 0;
    // ISSUE: reference to a compiler-generated field
    do
    {
      if (((\u0003.\u0003.\u0005) obj1).\u0001 != 11)
        goto label_2;
label_1:
      continue;
label_2:
      int num2 = buMotionLogVer5.\u0001(obj0, obj2, obj3, ((\u0003.\u0003.\u0005) obj1).\u0001);
      obj3 += num2;
      num1 += num2;
      obj0 -= num2;
      if (obj0 != 0)
        goto label_1;
      goto label_4;
    }
    while (\u0007.\u0003.\u0001(obj1) || ((\u0005.\u0001) ((\u0003.\u0003.\u0005) obj1).\u0001).\u0002 > 0 && ((\u0003.\u0003.\u0005) obj1).\u0001 != 11);
    goto label_5;
label_4:
    return num1;
label_5:
    return num1;
  }
}
