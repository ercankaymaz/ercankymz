// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleDrawingSetting
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleDrawingSetting : buSerilization5
{
  public static List<MarbleItem> ItemsSlice;
  public static List<MarbleItem> ItemsContour;
  public static List<MarbleItem> ItemsProfile;
  public static List<MarbleItem> ItemsSweep;
  public static List<MarbleItem> ItemsDrill;
  public static List<MarbleItem> ItemsColumns;
  public static List<MarbleItem> ItemsLathe;
  public static List<MarbleItem> ItemsCavity;
  public static List<MarbleItem> ItemsTap;
  public static Entity CameraImage;
  public static List<Point3D> MaterialLimits;

  public override string ToString()
  {
    return $"MinThickness: {((MarbleRuntimeSettings) this).MinThickness.ToString()} - MaxThickness: {((MarbleRuntimeSettings) this).MaxThickness.ToString()}";
  }

  public abstract void m001EBE();

  public MarbleDrawingSetting()
  {
    ((MarbleRuntimeSettings) this).CircularEnable = false;
    ((MarbleRuntimeSettings) this).CircularCount = 1;
    ((MarbleRuntimeSettings) this).CircularAngle = 45.0;
    ((MarbleRuntimeSettings) this).LineerEnable = false;
    ((MarbleRuntimeSettings) this).LineerXCount = 1;
    ((MarbleRuntimeSettings) this).LineerXDistance = 100.0;
    ((MarbleRuntimeSettings) this).LineerYCount = 1;
    ((MarbleRuntimeSettings) this).LineerYDistance = 100.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleDrawingSetting(ProfileArray data)
  {
    ((MarbleRuntimeSettings) this).CircularEnable = false;
    ((MarbleRuntimeSettings) this).CircularCount = 1;
    ((MarbleRuntimeSettings) this).CircularAngle = 45.0;
    ((MarbleRuntimeSettings) this).LineerEnable = false;
    ((MarbleRuntimeSettings) this).LineerXCount = 1;
    ((MarbleRuntimeSettings) this).LineerXDistance = 100.0;
    ((MarbleRuntimeSettings) this).LineerYCount = 1;
    ((MarbleRuntimeSettings) this).LineerYDistance = 100.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    return $"Lineer :{((MarbleRuntimeSettings) this).LineerEnable.ToString()} , Circular : {((MarbleRuntimeSettings) this).CircularEnable.ToString()}";
  }
}
