// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortbuFilter
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortbuFilter : buSerilization5
{
  public List<double> DepthLevel;
  public SizeObject Size;
  public static byte f0006F2;
  public SortFilter Filter;
  public SortOptions Option;
  public SortCamData CamData;
  public MostClosestPointOption ClosestPoint;
  public List<Entity> NotSelectEntities;

  public override string ToString()
  {
    int count = ((FlatViewSettings) this).Outter.Count;
    string str1 = count.ToString();
    count = ((FlatViewSettings) this).Inside.Count;
    string str2 = count.ToString();
    return $"Out Count: {str1} - Inside Count: {str2}";
  }

  public abstract void m0002B2();
}
