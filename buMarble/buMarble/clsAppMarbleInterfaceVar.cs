// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleInterfaceVar
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buEyeBaseVer5;
using System;
using System.Reflection;

#nullable disable
namespace buMarble;

[Serializable]
public class clsAppMarbleInterfaceVar : buSerilization5
{
  public static clsAppMarbleIODef MO_Buzzer;
  public static byte f000279;
  public int GCodeFormWidth = 555;
  public int GCodeFormHeight = 575;
  public double OperationSpeed;
  public double QuickSpeed;
  public double SpindleSpeed;
  public double SawSpeed;
  public double SpindleSpeedOverride;
  public double SawSpeedOverride;
  public bool IncrementalMode;
  public bool AbsoluteMode;
  public bool PartZeroMode;
  public bool AddSawThicknessToMove;
  public double JogGantryY2Move;
  public double JogMoveValue;
  public double JogMoveXValue;
  public double JogMoveYValue;
  public double JogMoveZValue;
  public double JogMoveAValue;
  public double JogMoveCValue;
  public double KinCalcMatThickness;
  public double KinCalcOperationZ;
  public double KinCalcRectWidth;
  public double KinCalcRectHeight;
  public double KinCalcRectAngle;
  public double DataLimitSoftLimitDiff;
  public int IndexG54;
  public int IndexToolSaw;
  public int IndexToolMilling;
  public int IndexToolMillingHead;
  public double PointerCircleDia;
  public bool MachineInstallationAxesCalib;
  public bool MachineInstallationKinematic;
  public bool MachineInstallationSpeeds;
  public bool MachineInstallationPositions;
  public bool MachineInstallationSpindle;
  public bool MachineInstallationLimits;
  public int AutoProgramSaveDays;
  public MarblePartZeroType PartZeroType;
  public int ZoomX1;

  public clsAppMarbleInterfaceVar(clsAppMarbleFormVar data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public clsAppMarbleInterfaceVar()
  {
  }
}
