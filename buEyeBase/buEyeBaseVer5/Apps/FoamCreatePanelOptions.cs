// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamCreatePanelOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamCreatePanelOptions : buSerilization5
{
  public static List<string> LangRouterCommands;
  public static byte f003B7B;
  public string ItemName;
  public string FileName;

  public abstract void m001AB2();

  public FoamCreatePanelOptions()
  {
    ((FoamBlock) this).SimStep = 1;
    ((FoamBlock) this).StepRun = false;
    ((FoamBlock) this).CircleDiameter = 150.0;
    ((FoamBlock) this).CircleLength = 1000.0;
    ((FoamBlock) this).CircleThickness = 6.0;
    ((FoamBlock) this).RectangleRadius = 300.0;
    ((FoamBlock) this).RectangleWidth = 1000.0;
    ((FoamBlock) this).RectangleHeight = 800.0;
    ((FoamPattern) this).RectangleLength = 1000.0;
    ((FoamPattern) this).RectangleThickness = 6.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public FoamCreatePanelOptions(RollerBendRuntimeSettings data)
  {
    ((FoamBlock) this).SimStep = 1;
    ((FoamBlock) this).StepRun = false;
    ((FoamBlock) this).CircleDiameter = 150.0;
    ((FoamBlock) this).CircleLength = 1000.0;
    ((FoamBlock) this).CircleThickness = 6.0;
    ((FoamBlock) this).RectangleRadius = 300.0;
    ((FoamBlock) this).RectangleWidth = 1000.0;
    ((FoamBlock) this).RectangleHeight = 800.0;
    ((FoamPattern) this).RectangleLength = 1000.0;
    ((FoamPattern) this).RectangleThickness = 6.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
}
