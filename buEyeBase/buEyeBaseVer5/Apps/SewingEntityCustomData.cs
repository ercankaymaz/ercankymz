// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingEntityCustomData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingEntityCustomData : buSerilization5
{
  public double DiskDiameter;
  public double DiskHeight;
  public double DiskThickness;
  public double DiskBlockWidth;
  public double DiskBlockLength;
  public double BlockWidth;
  public double BlockHeight;

  public SewingEntityCustomData()
  {
    ((FoamRuntimeSettings) this).DrawAll = false;
    ((FoamRuntimeSettings) this).CamCreate = false;
    ((FoamRuntimeSettings) this).SelectedSheet = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SewingEntityCustomData(CamCreateSettings data)
  {
    ((FoamRuntimeSettings) this).DrawAll = false;
    ((FoamRuntimeSettings) this).CamCreate = false;
    ((FoamRuntimeSettings) this).SelectedSheet = -1;
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

  public SewingEntityCustomData()
  {
    if (!buVector5.\u0001("buDoor"))
      throw new RegisterException("buDoor");
  }
}
