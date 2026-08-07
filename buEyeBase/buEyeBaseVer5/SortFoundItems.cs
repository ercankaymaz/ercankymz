// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortFoundItems
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class SortFoundItems : buSerilization5
{
  public double dZ;
  public double OffsetX;
  public double OffsetY;
  public bool TopIsZeroPosition;
  public string FileName;
  public string FileNameImage;

  public SortFoundItems(PointABC data)
  {
    ((ViewportSettings) this).A = 0.0;
    ((ViewportSettings) this).B = 0.0;
    ((ViewportSettings) this).C = 0.0;
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

  public override string ToString()
  {
    return $"A: {((ViewportSettings) this).A.ToString()} ; B: {((ViewportSettings) this).B.ToString()} ; C: {((ViewportSettings) this).C.ToString()}";
  }

  public abstract void m0002A8();
}
