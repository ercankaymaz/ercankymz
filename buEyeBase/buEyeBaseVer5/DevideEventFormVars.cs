// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.DevideEventFormVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class DevideEventFormVars : buSerilization5
{
  public bool Selectable;
  public string Name;
  public string NameExtra;
  public string MaterialName;
  public string Tag;
  public string Option;
  public string Note;
  public string ShownName;
  public string Defination;
  public int Mode;
  public Color LayerColor;
  public int Transparency;
  public float LayerThickness;
  public drawingPattern Pattern;
  public LayerPurpose LayerPurposes;

  public DevideEventFormVars(ToolLimits cam)
  {
    ((LayerBase5) this).AxesMinLimits = new Pnt6D(0.0, 0.0, 0.0, -360.0, -360.0, -360.0);
    ((LayerBase5) this).AxesMaxLimits = new Pnt6D(0.0, 0.0, 0.0, 360.0, 360.0, 360.0);
    ((LayerBase5) this).PlaneTop = false;
    ((LayerBase5) this).PlaneBottom = false;
    ((LayerOverride) this).PlaneFront = false;
    ((LayerOverride) this).PlaneBack = false;
    ((LayerOverride) this).PlaneLeft = false;
    ((LayerOverride) this).PlaneRight = false;
    ((CopyEventFormVars) this).PlaneAll = true;
    ((CopyEventFormVars) this).PlaneSlope = false;
    ((CopyEventFormVars) this).RotationA = false;
    ((CopyEventFormVars) this).RotationB = false;
    ((CopyEventFormVars) this).RotationC = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) cam, ref CopiedClass);
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

  public override string ToString()
  {
    return $"PlaneAll: {((CopyEventFormVars) this).PlaneAll.ToString()} - PlaneTop: {((LayerBase5) this).PlaneTop.ToString()} - PlaneLeft: {((LayerOverride) this).PlaneLeft.ToString()} - PlaneRight: {((LayerOverride) this).PlaneRight.ToString()}";
  }
}
