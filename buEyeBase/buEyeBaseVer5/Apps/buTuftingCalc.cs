// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buTuftingCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buTuftingCalc
{
  public static byte f003FF7;

  public buTuftingCalc(bool drawall, bool deletesort, bool deletetool, bool drawpreview)
  {
    ((DrillItem) this).DrawAll = false;
    ((DrillItem) this).DeleteSort = false;
    ((DrillItem) this).DeleteTool = false;
    ((DrillItem) this).DrawPreview = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((DrillItem) this).DrawAll = drawall;
    ((DrillItem) this).DeleteSort = deletesort;
    ((DrillItem) this).DeleteTool = deletetool;
    ((DrillItem) this).DrawPreview = drawpreview;
  }

  public buTuftingCalc(FoamCreatePanelOptions data)
  {
    ((DrillItem) this).DrawAll = false;
    ((DrillItem) this).DeleteSort = false;
    ((DrillItem) this).DeleteTool = false;
    ((DrillItem) this).DrawPreview = false;
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

  public buTuftingCalc()
  {
    ((DrillItem) this).GroupEntity = new buEntitiesGroup();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
