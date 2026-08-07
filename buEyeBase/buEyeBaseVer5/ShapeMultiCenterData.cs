// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeMultiCenterData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ShapeMultiCenterData : buSerilization5
{
  public bool isFirstPointCatchFromStartPointForDrawSequence;
  public bool PreferLineIfAvailableForFirstTouch;

  public ShapeMultiCenterData(MaterialBase5 mat)
  {
    ((SortOptions) this).Name = "Material";
    ((SortOptions) this).Points = new List<Point3D>();
    ((SortOptions) this).InnerPoints = (List<List<Point3D>>) null;
    ((SortOptions) this).Display = new SolidItemDisplay(Color.Linen, 100, Color.Brown, 200);
    ((SortOptions) this).StartPoint = new Point3D();
    ((SortOptions) this).BoxMinPoint = new Point3D();
    ((SortCamData) this).BoxMaxPoint = new Point3D();
    ((SortResult) this).Sing = new Point3D(1.0, 1.0, 1.0);
    ((SortResult) this).matImage = (Image) null;
    ((SortResult) this).Size = new SizeObject(400.0, 200.0, 25.0);
    ((SortResult) this).FrontAngle = 0.0;
    ((SortResult) this).BackAngle = 0.0;
    ((SortResult) this).LeftAngle = 0.0;
    ((SortResult) this).RightAngle = 0.0;
    ((SortAskMe) this).Shapes = MaterialShapes.Rectangle;
    ((SortAskMe) this).Purpose = MaterialPurpose.Door;
    ((SortAskMe) this).Enable = true;
    ((SortAskMe) this).Angle = 0.0;
    ((SortAskMe) this).Radius = 10.0;
    ((SortAskMe) this).Diameter = 100.0;
    ((SortAskMe) this).MajorRadius = 100.0;
    ((SortAskMe) this).MinorRadius = 50.0;
    ((SortAskMe) this).RoundRadiue = 5.0;
    ((SortAskMe) this).ChamferLength = 5.0;
    ((SortAskMe) this).dX = 0.0;
    ((SortAskMe) this).dY = 0.0;
    ((SortFoundItems) this).dZ = 0.0;
    ((SortFoundItems) this).OffsetX = 0.0;
    ((SortFoundItems) this).OffsetY = 0.0;
    ((SortFoundItems) this).TopIsZeroPosition = false;
    ((SortFoundItems) this).FileName = Application.StartupPath;
    ((SortFoundItems) this).FileNameImage = Application.StartupPath;
    ((MostClosestPointOption) this).Entities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) mat, ref CopiedClass);
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
    if (((SortResult) mat).matImage != null)
      ((SortResult) this).matImage = (Image) ((SortResult) mat).matImage.Clone();
    ((SortOptions) this).Display = new SolidItemDisplay(((SortOptions) mat).Display);
    ((SortResult) this).Size = new SizeObject(((SortResult) mat).Size);
    ((SortOptions) this).StartPoint = F_NotchEdit.ToPoint3D(((SortOptions) mat).StartPoint);
    ((SortOptions) this).BoxMinPoint = F_NotchEdit.ToPoint3D(((SortOptions) mat).BoxMinPoint);
    ((SortCamData) this).BoxMaxPoint = F_NotchEdit.ToPoint3D(((SortCamData) mat).BoxMaxPoint);
    ((SortOptions) this).Points.Clear();
    buVector5.Copy(((SortOptions) mat).Points, ref ((SortOptions) this).Points);
    if (((SortOptions) mat).InnerPoints != null)
      buVector5.Copy(((SortOptions) mat).InnerPoints, ref ((SortOptions) this).InnerPoints);
    if (((MostClosestPointOption) mat).Entities == null)
      return;
    buVector5.CopyEntities(((MostClosestPointOption) mat).Entities, ref ((MostClosestPointOption) this).Entities);
  }

  public ShapeMultiCenterData(SizeObject size)
  {
    ((SortOptions) this).Name = "Material";
    ((SortOptions) this).Points = new List<Point3D>();
    ((SortOptions) this).InnerPoints = (List<List<Point3D>>) null;
    ((SortOptions) this).Display = new SolidItemDisplay(Color.Linen, 100, Color.Brown, 200);
    ((SortOptions) this).StartPoint = new Point3D();
    ((SortOptions) this).BoxMinPoint = new Point3D();
    ((SortCamData) this).BoxMaxPoint = new Point3D();
    ((SortResult) this).Sing = new Point3D(1.0, 1.0, 1.0);
    ((SortResult) this).matImage = (Image) null;
    ((SortResult) this).Size = new SizeObject(400.0, 200.0, 25.0);
    ((SortResult) this).FrontAngle = 0.0;
    ((SortResult) this).BackAngle = 0.0;
    ((SortResult) this).LeftAngle = 0.0;
    ((SortResult) this).RightAngle = 0.0;
    ((SortAskMe) this).Shapes = MaterialShapes.Rectangle;
    ((SortAskMe) this).Purpose = MaterialPurpose.Door;
    ((SortAskMe) this).Enable = true;
    ((SortAskMe) this).Angle = 0.0;
    ((SortAskMe) this).Radius = 10.0;
    ((SortAskMe) this).Diameter = 100.0;
    ((SortAskMe) this).MajorRadius = 100.0;
    ((SortAskMe) this).MinorRadius = 50.0;
    ((SortAskMe) this).RoundRadiue = 5.0;
    ((SortAskMe) this).ChamferLength = 5.0;
    ((SortAskMe) this).dX = 0.0;
    ((SortAskMe) this).dY = 0.0;
    ((SortFoundItems) this).dZ = 0.0;
    ((SortFoundItems) this).OffsetX = 0.0;
    ((SortFoundItems) this).OffsetY = 0.0;
    ((SortFoundItems) this).TopIsZeroPosition = false;
    ((SortFoundItems) this).FileName = Application.StartupPath;
    ((SortFoundItems) this).FileNameImage = Application.StartupPath;
    ((MostClosestPointOption) this).Entities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((SortResult) this).Size = new SizeObject(size);
  }

  public ShapeMultiCenterData(double width, double height, double depth)
  {
    ((SortOptions) this).Name = "Material";
    ((SortOptions) this).Points = new List<Point3D>();
    ((SortOptions) this).InnerPoints = (List<List<Point3D>>) null;
    ((SortOptions) this).Display = new SolidItemDisplay(Color.Linen, 100, Color.Brown, 200);
    ((SortOptions) this).StartPoint = new Point3D();
    ((SortOptions) this).BoxMinPoint = new Point3D();
    ((SortCamData) this).BoxMaxPoint = new Point3D();
    ((SortResult) this).Sing = new Point3D(1.0, 1.0, 1.0);
    ((SortResult) this).matImage = (Image) null;
    ((SortResult) this).Size = new SizeObject(400.0, 200.0, 25.0);
    ((SortResult) this).FrontAngle = 0.0;
    ((SortResult) this).BackAngle = 0.0;
    ((SortResult) this).LeftAngle = 0.0;
    ((SortResult) this).RightAngle = 0.0;
    ((SortAskMe) this).Shapes = MaterialShapes.Rectangle;
    ((SortAskMe) this).Purpose = MaterialPurpose.Door;
    ((SortAskMe) this).Enable = true;
    ((SortAskMe) this).Angle = 0.0;
    ((SortAskMe) this).Radius = 10.0;
    ((SortAskMe) this).Diameter = 100.0;
    ((SortAskMe) this).MajorRadius = 100.0;
    ((SortAskMe) this).MinorRadius = 50.0;
    ((SortAskMe) this).RoundRadiue = 5.0;
    ((SortAskMe) this).ChamferLength = 5.0;
    ((SortAskMe) this).dX = 0.0;
    ((SortAskMe) this).dY = 0.0;
    ((SortFoundItems) this).dZ = 0.0;
    ((SortFoundItems) this).OffsetX = 0.0;
    ((SortFoundItems) this).OffsetY = 0.0;
    ((SortFoundItems) this).TopIsZeroPosition = false;
    ((SortFoundItems) this).FileName = Application.StartupPath;
    ((SortFoundItems) this).FileNameImage = Application.StartupPath;
    ((MostClosestPointOption) this).Entities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((SortResult) this).Size = new SizeObject(width, height, depth);
  }

  public static void Copy(List<MaterialBase5> RefList, ref List<MaterialBase5> CopiedList)
  {
    try
    {
      if (RefList == null)
        return;
      if (CopiedList == null)
        CopiedList = new List<MaterialBase5>();
      for (int index = 0; index <= RefList.Count - 1; ++index)
        CopiedList.Add((MaterialBase5) new ShapeMultiCenterData(RefList[index]));
    }
    catch (Exception ex)
    {
      CopiedList = new List<MaterialBase5>();
    }
  }
}
