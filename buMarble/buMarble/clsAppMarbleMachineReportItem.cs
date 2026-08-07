// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleMachineReportItem
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
public class clsAppMarbleMachineReportItem : buSerilization5
{
  public int ZoomY1;
  public int ZoomX2;
  public int ZoomY2;
  public double ZoomRatio;

  public clsAppMarbleMachineReportItem(clsAppMarbleProgramSetVar data)
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

  public clsAppMarbleMachineReportItem()
  {
    // ISSUE: unable to decompile the method.
  }

  public clsAppMarbleMachineReportItem(clsAppMarbleInterfaceVar data)
  {
    // ISSUE: unable to decompile the method.
  }
}
