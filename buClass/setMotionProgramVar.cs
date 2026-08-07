// Decompiled with JetBrains decompiler
// Type: buClass.setMotionProgramVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class setMotionProgramVar : buSerilization
{
  public bool TouchPad = false;
  public bool ThreatRead = true;
  public bool ThreatWrite = true;
  public bool CameraEnable = false;
  public int TimerReadTick = 500;
  public int TimerGeneralTick = 100;
  public bool WindowsMaximize = false;
  public double Resolution = 0.01;
  public bool DeleteFinishedJobFile = false;
  public bool DeleteFinishedJobFileWithProgramClosed = false;
  public bool ShowPasswordPageIfNoAccessLevel = true;
  public bool ShowGCode = true;
  public double FeedOverrideMax = 100.0;
  public double FeedOverrideMin = 0.0;
  public double FeedCOverrideMax = 100.0;
  public double FeedCOverrideMin = 0.0;
  public bool ClearOperationTimeWhenStop = false;
  public LoadFileFormType LoadFileFromWindowsDialogbox = LoadFileFormType.ProgramWindowWithPreview;
  public CoordinateShowMode MachineCoordinateShowMode = CoordinateShowMode.Machine;
  public CoordinateShowMode PartCoordinateShowMode = CoordinateShowMode.Part;

  public setMotionProgramVar()
  {
  }

  public setMotionProgramVar(setMotionProgramVar data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }
}
