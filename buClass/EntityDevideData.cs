// Decompiled with JetBrains decompiler
// Type: buClass.EntityDevideData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass;

public class EntityDevideData : buSerilization
{
  public double LineLength = 1.0;
  public double PolylineLength = 1.0;
  public double ArcLength = 1.0;
  public double CircleLength = 1.0;
  public double CurveLength = 1.0;
  public double EllipseLength = 1.0;
  public bool DevideEnable = false;
  public bool Polyline = false;
  public bool Line = false;
  public bool Arc = false;
  public bool Circle = false;
  public bool Ellipse = false;
  public bool Curve = false;
  public bool CompositeCurve = false;

  public EntityDevideData()
  {
  }

  public EntityDevideData(EntityDevideData data)
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
