// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TuftCircularFillVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TuftCircularFillVar : buSerilization
{
  public double RowDistance = 10.0;
  public double FillOffset = 2.0;
  public bool OutterEnable = true;
  public double OutterOffset = 2.0;
  public int OutterCount = 1;
  public bool InnerEnable = true;
  public int InnerCount = 1;
  public double InnerOffset = 2.0;
  public ClockDirectionType OutterDirection = ClockDirectionType.CW;
  public tuftingFillOffsetType OutterType = tuftingFillOffsetType.Contour;
  public ClockDirectionType InnerDirection = ClockDirectionType.CW;
  public tuftingFillOffsetType InnerType = tuftingFillOffsetType.Contour;
  public double OffsetCheckFilter = 2.0;
  public InOutDirection Type = InOutDirection.OutsideToInside;
  public int TargetLayerIndex = 0;
  public bool RunCommandAfterFinish = true;
  public bool AskMe = true;
  public static List<string> Captions = new List<string>();

  public TuftCircularFillVar()
  {
  }

  public TuftCircularFillVar(TuftCircularFillVar data)
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
