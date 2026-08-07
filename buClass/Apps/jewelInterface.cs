// Decompiled with JetBrains decompiler
// Type: buClass.Apps.jewelInterface
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class jewelInterface : buSerilization
{
  public double MaterialWidth = 10.0;
  public double MaterialRadius = 10.0;
  public double MaterialDiameter = 10.0;
  public double FrameWidth = 10.0;
  public double FrameHeight = 100.0;
  public jewelCurveType MaterialFormMode = jewelCurveType.Flat;
  public jewelMaterialShapeType MaterialShape = jewelMaterialShapeType.Circle;
  public bool OilEnable = false;
  public bool ReadSurface = false;
  public bool DiameterMeasue = false;
  public int ToolSpindleIndex = 0;
  public int ToolDiaCut1Index = 0;
  public int ToolDiaCut2Index = 0;
  public int ToolEngraveIndex = 0;
  public int ToolLaserIndex = 0;
  public int ToolLatheIndex = 0;
  public string ModeFolder = Application.StartupPath;

  public jewelInterface()
  {
  }

  public jewelInterface(jewelInterface data)
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

  public override string ToString()
  {
    return $"Width: {this.MaterialWidth.ToString()} , Radius: {this.MaterialRadius.ToString()} , Dia: {this.MaterialDiameter.ToString()} , Form: {this.MaterialFormMode.ToString()}";
  }
}
