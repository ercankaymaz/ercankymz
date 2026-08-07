// Decompiled with JetBrains decompiler
// Type: buClass.EntitiesResolution
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class EntitiesResolution : buSerilization
{
  public EntityResolution CircleResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.ByLnRadius);
  public EntityResolution ArcResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.ByLnRadius);
  public EntityResolution EllipseResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.ByLnRadius);
  public EntityResolution CurveResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.ByLnRadius);
  public EntityResolution LineResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.None);
  public EntityResolution PolylineResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.None);
  public EntityResolution OtherResolution = new EntityResolution(2.0, 20, 20.0, EntityResolutionType.None);
  public static List<string> Captions = new List<string>();

  public EntitiesResolution()
  {
  }

  public EntitiesResolution(
    EntityResolutionType LineTypes,
    EntityResolutionType PolylineTypes,
    EntityResolutionType ArcTypes,
    EntityResolutionType CircleTypes,
    EntityResolutionType EllipseTypes,
    EntityResolutionType CurveTypes,
    EntityResolutionType OtherTypes)
  {
    this.LineResolution.ResolutionTypes = LineTypes;
    this.PolylineResolution.ResolutionTypes = LineTypes;
    this.ArcResolution.ResolutionTypes = LineTypes;
    this.CircleResolution.ResolutionTypes = LineTypes;
    this.EllipseResolution.ResolutionTypes = LineTypes;
    this.CurveResolution.ResolutionTypes = LineTypes;
    this.OtherResolution.ResolutionTypes = LineTypes;
  }

  public EntitiesResolution(EntitiesResolution data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
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
    this.ArcResolution = new EntityResolution(data.ArcResolution);
    this.CircleResolution = new EntityResolution(data.CircleResolution);
    this.EllipseResolution = new EntityResolution(data.EllipseResolution);
    this.CurveResolution = new EntityResolution(data.CurveResolution);
    this.LineResolution = new EntityResolution(data.LineResolution);
    this.PolylineResolution = new EntityResolution(data.PolylineResolution);
    this.OtherResolution = new EntityResolution(data.OtherResolution);
  }

  public override string ToString()
  {
    return "Circle Len = " + this.CircleResolution.GeometricLength.ToString();
  }
}
