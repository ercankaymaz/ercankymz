// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeProfileData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

public class ShapeProfileData : buSerilization5
{
  public bool WhenFoundClosedCurveThenFinish;
  public bool Jump;
  public Point3D StartPoint;

  public static void Copy(
    List<List<MaterialBase5>> RefList,
    ref List<List<MaterialBase5>> CopiedList)
  {
    try
    {
      if (RefList == null)
        return;
      if (CopiedList == null)
        CopiedList = new List<List<MaterialBase5>>();
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        List<MaterialBase5> CopiedList1 = new List<MaterialBase5>();
        ShapeMultiCenterData.Copy(RefList[index], ref CopiedList1);
        if ((CopiedList1 == null ? 0 : (CopiedList1.Count > 0 ? 1 : 0)) != 0)
          CopiedList.Add(CopiedList1);
      }
    }
    catch (Exception ex)
    {
      CopiedList = new List<List<MaterialBase5>>();
    }
  }

  public override string ToString()
  {
    return $"X: {((SortOptions) this).BoxMinPoint.X.ToString("f2")} Y: {((SortOptions) this).BoxMinPoint.Y.ToString("f2")} W: {((SortResult) this).Size.Width.ToString("f2")} H: {((SortResult) this).Size.Height.ToString("f2")} {((SortOptions) this).Name}";
  }

  public abstract void m0002D4();
}
