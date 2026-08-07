// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingMain
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class SewingMain : buSerilization5
{
  public double Length;
  public static byte f003C63;
  public double BlockPipeDiameter;

  public SewingMain(bool drawall, bool deletestock = false, bool deletetool = false, bool drawpreview = true)
  {
    ((FoamRuntimeSettings) this).DrawAll = false;
    ((FoamRuntimeSettings) this).DeleteStock = false;
    ((FoamRuntimeSettings) this).DeleteTool = false;
    ((FoamRuntimeSettings) this).DeletePlane = false;
    ((FoamRuntimeSettings) this).DrawPreview = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((FoamRuntimeSettings) this).DrawAll = drawall;
    ((FoamRuntimeSettings) this).DeleteStock = deletestock;
    ((FoamRuntimeSettings) this).DeleteTool = deletetool;
    ((FoamRuntimeSettings) this).DrawPreview = drawpreview;
  }

  public SewingMain(DrawOptions data)
  {
    ((FoamRuntimeSettings) this).DrawAll = false;
    ((FoamRuntimeSettings) this).DeleteStock = false;
    ((FoamRuntimeSettings) this).DeleteTool = false;
    ((FoamRuntimeSettings) this).DeletePlane = false;
    ((FoamRuntimeSettings) this).DrawPreview = false;
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
