// Decompiled with JetBrains decompiler
// Type: buClass.EntityDevideSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class EntityDevideSettings : buSerilization
{
  public PolylineDevideType Polyline = PolylineDevideType.DontDevide;
  public ArcDevideType Arc = ArcDevideType.ArcToArcIfBig;
  public CircleDevideType Circle = CircleDevideType.CircleToQuadraticArc;
  public EllipseDevideType Ellipse = EllipseDevideType.EllipseToPolyLine;
  public CurveDevideType Curve = CurveDevideType.CurveToPolyLine;

  public EntityDevideSettings()
  {
  }

  public EntityDevideSettings(EntityDevideSettings data)
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

  public EntityDevideSettings(
    PolylineDevideType polyline,
    ArcDevideType arc,
    CircleDevideType circle,
    EllipseDevideType ellipse,
    CurveDevideType curve)
  {
    this.Polyline = polyline;
    this.Arc = arc;
    this.Circle = circle;
    this.Ellipse = ellipse;
    this.Curve = curve;
  }
}
