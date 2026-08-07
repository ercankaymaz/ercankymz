// Decompiled with JetBrains decompiler
// Type: buClass.DimensionData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class DimensionData : buSerilization
{
  public string Chars = "";
  public string Explanation = "";
  public string TextOverride = "";
  public double Distance = 0.0;
  public double Angle = 0.0;
  public bool IsVertical = false;
  public DimensionType Type = DimensionType.None;
  public Pnt3D CatchPoint = new Pnt3D();
  public Pnt3D BasePoint = new Pnt3D();
  public Pnt3D CatchPointOfEntity = new Pnt3D();
  public Pnt3D BasePointOfEntity = new Pnt3D();
  public int ReSizedEntityIndex = -1;
  public int ReSizedEntitySubIndex = -1;
  public string SelectedEntities = "";

  public DimensionData()
  {
  }

  public DimensionData(
    string chars,
    string explanation,
    double distance,
    double angle,
    bool isvertical,
    DimensionType type)
  {
    this.Chars = chars;
    this.Explanation = explanation;
    this.Distance = distance;
    this.Angle = angle;
    this.IsVertical = isvertical;
    this.Type = type;
  }

  public DimensionData(DimensionData data)
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
    return $"{this.Chars} - Exp: {this.Explanation} - Dis: {this.Distance.ToString("f2")} - Type: {this.Type.ToString()} - Ent Index: {this.ReSizedEntityIndex.ToString()}";
  }
}
