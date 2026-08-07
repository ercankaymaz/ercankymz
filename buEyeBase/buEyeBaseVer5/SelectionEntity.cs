// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SelectionEntity
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class SelectionEntity
{
  public double FreeDrawAngle;
  public double TextWidth;
  public double TextHeight;
  public double TextDepth;
  public double TextAngle;
  public string TextString;
  public bool TextIsWire;
  public Font TextFont;
  public double HoleDiameter;
  public double HoleDiameterOutside;
  public double HoleDepth;
  public double HoleDistance;

  public SelectionEntity(MostClosestPointOption data)
  {
    ((SortbuMostClosedResult) this).UseStartEndPointCompositeCurve = true;
    ((SortbuMostClosedResult) this).Resolution = 0.01;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public SelectionEntity()
  {
    ((SortbuMostClosedResult) this).GapDistance = 0.02;
    ((SortbuMostClosedResult) this).SortResolution = 0.05;
    ((SortbuMostClosedResult) this).MinProfileFilterLength = 0.0;
    ((SortbuMostClosedResult) this).ConnectSmallGap = true;
    ((SortbuMostClosedResult) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SelectionEntity(SortResolutionSet data)
  {
    ((SortbuMostClosedResult) this).GapDistance = 0.02;
    ((SortbuMostClosedResult) this).SortResolution = 0.05;
    ((SortbuMostClosedResult) this).MinProfileFilterLength = 0.0;
    ((SortbuMostClosedResult) this).ConnectSmallGap = true;
    ((SortbuMostClosedResult) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
