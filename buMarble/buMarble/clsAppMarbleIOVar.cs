// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleIOVar
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buEyeBaseVer5;
using buMarble.Forms;
using dummy_ptr;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace buMarble;

[Serializable]
public class clsAppMarbleIOVar : buSerilization5
{
  public bool Invert;
  public static byte f0001EC;
  public static byte f0001ED;
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

  static bool \u0001([In] \u0006.\u0005.\u0005 obj0, [In] \u0006.\u0005.\u0002 obj1)
  {
    while (true)
    {
      switch (((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001)
      {
        case 0:
          ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0002 = \u0005.\u0003.\u0001(obj1, 5);
          if (((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0002 >= 0)
          {
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0002 = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0002 + 257;
            \u0005.\u0003.\u0001(obj1, 5);
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = 1;
            goto case 1;
          }
          goto label_23;
        case 1:
          ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0003 = \u0005.\u0003.\u0001(obj1, 5);
          if (((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0003 >= 0)
          {
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0003 = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0003 + 1;
            \u0005.\u0003.\u0001(obj1, 5);
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0005 = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0002 + ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0003;
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0002 = new byte[((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0005];
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = 2;
            goto case 2;
          }
          goto label_24;
        case 2:
          ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0004 = \u0005.\u0003.\u0001(obj1, 4);
          if (((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0004 >= 0)
          {
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0004 = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0004 + 4;
            \u0005.\u0003.\u0001(obj1, 4);
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = new byte[19];
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007 = 0;
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = 3;
            goto case 3;
          }
          goto label_25;
        case 3:
          for (; ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007 < ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0004; ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007 = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007 + 1)
          {
            int num = \u0005.\u0003.\u0001(obj1, 3);
            if (num < 0)
              return false;
            \u0005.\u0003.\u0001(obj1, 3);
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001[\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D.\u0003[((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007]] = (byte) num;
          }
          ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = (\u0006.\u0005.\u0004) new \u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D(((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001);
          ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = (byte[]) null;
          ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007 = 0;
          ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = 4;
          goto case 4;
        case 4:
          int num1;
          while (((num1 = \u0005.\u0003.\u0001(((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001, obj1)) & -16) == 0)
          {
            byte[] numArray = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0002;
            \u0006.\u0005.\u0005 obj = obj0;
            int num2 = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007;
            int num3 = num2 + 1;
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj).\u0007 = num3;
            int index = num2;
            int num4 = (int) (((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = (byte) num1);
            numArray[index] = (byte) num4;
            if (((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007 == ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0005)
              return true;
          }
          if (num1 >= 0)
          {
            if (num1 >= 17)
              ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = (byte) 0;
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0006 = num1 - 16 /*0x10*/;
            ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = 5;
            goto case 5;
          }
          goto label_27;
        case 5:
          // ISSUE: reference to a compiler-generated field
          int num5 = \u0002.\u0002.\u0002[((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0006];
          int num6 = \u0005.\u0003.\u0001(obj1, num5);
          if (num6 >= 0)
          {
            \u0005.\u0003.\u0001(obj1, num5);
            // ISSUE: reference to a compiler-generated field
            int num7 = num6 + \u0002.\u0002.\u0001[((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0006];
            while (num7-- > 0)
            {
              byte[] numArray = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0002;
              \u0006.\u0005.\u0005 obj = obj0;
              int num8 = ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007;
              int num9 = num8 + 1;
              ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj).\u0007 = num9;
              int index = num8;
              int num10 = (int) ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001;
              numArray[index] = (byte) num10;
            }
            if (((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0007 != ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0005)
            {
              ((\u007B57420d5b\u002D5352\u002D4cdc\u002Da7c9\u002Dc2f32411cb5f\u007D) obj0).\u0001 = 4;
              continue;
            }
            goto label_30;
          }
          goto label_29;
        default:
          continue;
      }
    }
label_23:
    return false;
label_24:
    return false;
label_25:
    return false;
label_27:
    return false;
label_29:
    return false;
label_30:
    return true;
  }

  static void \u0001([In] F_MarbleGantryMove obj0)
  {
    string callMethod = "Profile Cut LoadLanguage";
    try
    {
      ((F_MarbleKinematic) obj0).buGround1.Text = buLangTranslate.preDef.Jog;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }
}
