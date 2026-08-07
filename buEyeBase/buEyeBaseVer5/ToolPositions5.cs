// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ToolPositions5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ToolPositions5 : buSerilization5
{
  public double PlungeSpeed;
  public double LeaveSpeed;
  public double SpindleSpeed;
  public double OperationHeigthForSecond;
  public double ExtraOffset;

  public ToolPositions5()
  {
    ((ToolGeometry5) this).Diameter = 2.0;
    ((ToolGeometry5) this).SocketThickness = 4.0;
    ((ToolGeometry5) this).DiameterLeft = 10.0;
    ((ToolGeometry5) this).DiameterRight = 10.0;
    ((ToolGeometry5) this).DiameterBody = 10.0;
    ((ToolGeometry5) this).ShoulderThickness = 0.0;
    ((ToolGeometry5) this).ShoulderDiameter = 0.0;
    ((ToolGeometry5) this).ShoulderLength = 0.0;
    ((ToolGeometry5) this).BottomDiameter = 10.0;
    ((ToolGeometry5) this).TopDiameter = 10.0;
    ((ToolGeometry5) this).RoundRadius = 2.0;
    ((ToolGeometry5) this).Length = 50.0;
    ((ToolGeometry5) this).TotalLength = 0.0;
    ((ToolGeometry5) this).LengthLeft = 50.0;
    ((ToolGeometry5) this).LengthRigth = 50.0;
    ((ToolGeometry5) this).LengthDiameter = 10.0;
    ((ToolGeometry5) this).CutLength = 20.0;
    ((ToolGeometry5) this).CutLengthLeft = 20.0;
    ((ToolGeometry5) this).CutLengthRight = 20.0;
    ((ToolGeometry5) this).ArborLength = 50.0;
    ((ToolGeometry5) this).ArborTopDiameter = 78.0;
    ((ToolGeometry5) this).ArborBottomDiameter = 45.0;
    ((ToolGeometry5) this).HolderLength = 30.0;
    ((ToolGeometry5) this).HolderDiameter = 100.0;
    ((ToolGeometry5) this).HolderInDiameter = 90.0;
    ((ToolGeometry5) this).TaperAngle = 8.0;
    ((ToolGeometry5) this).LowerRadius = 2.0;
    ((ToolDisplay5) this).UpperRadius = 2.0;
    ((ToolDisplay5) this).UpperDiameter = 10.0;
    ((ToolDisplay5) this).ProfileRadius = 12.0;
    ((ToolDisplay5) this).OutsideDiameter = 10.0;
    ((ToolDisplay5) this).ProfileDiameter = 10.0;
    ((ToolDisplay5) this).MaxDiameter = 10.0;
    ((ToolDisplay5) this).FlatnessDiameter = 0.0;
    ((ToolDisplay5) this).ConvexTipRadius = 2.0;
    ((ToolDisplay5) this).Thickness = 4.0;
    ((ToolDisplay5) this).MinLength = 0.0;
    ((ToolDisplay5) this).SizeWidth = 0.0;
    ((ToolDisplay5) this).SizeDepth = 0.0;
    ((ToolDisplay5) this).SizeHeight = 0.0;
    ((ToolData5) this).PositionAngle = 0.0;
    ((ToolData5) this).AddHalfOfToolThicknessToDistance = true;
    ((ToolData5) this).PlaneDirection = new Vec3D(0.0, 0.0, 1.0);
    ((ToolData5) this).ToolDirection = new Vec3D(0.0, 0.0, -1.0);
    ((ToolData5) this).DistanceForOrientation = new Vec3D(0.0, 0.0, 0.0);
    ((ToolData5) this).GeometryType = ToolType.Flat;
    ((ToolData5) this).FlatGeometry = ToolFlatGeometryType.None;
    ((ToolData5) this).CornerRadiusType = ToolCornerRadiusType.None;
    ((ToolData5) this).LengthReverseDirection = false;
    ((ToolData5) this).DrawHolder = true;
    ((ToolData5) this).DrawArbor = true;
    ((ToolData5) this).DrawLength = true;
    ((ToolData5) this).AgregateLeftEnable = true;
    ((ToolData5) this).AgregateRightEnable = true;
    ((ToolData5) this).AgregateVerticalLength = 150.0;
    ((ToolData5) this).AgregateToolCenterLength = 100.0;
    ((ToolData5) this).AgregateCircleBody = true;
    ((ToolData5) this).FromFileEnable = false;
    ((ToolData5) this).FromFileFileName = Application.StartupPath;
    ((ToolCamData5) this).FromFileAngle = 0.0;
    ((ToolCamData5) this).ArborPoints = new List<Pnt3D>()
    {
      new Pnt3D(0.0, 0.0),
      new Pnt3D(15.0, 0.0),
      new Pnt3D(17.5, 8.0),
      new Pnt3D(17.5, 25.0),
      new Pnt3D(20.0, 30.0),
      new Pnt3D(0.0, 30.0)
    };
    ((ToolCamData5) this).HolderPoints = new List<Pnt3D>()
    {
      new Pnt3D(0.0, 0.0),
      new Pnt3D(30.0, 0.0),
      new Pnt3D(30.0, 4.0),
      new Pnt3D(25.0, 8.0),
      new Pnt3D(25.0, 28.0),
      new Pnt3D(30.0, 32.0),
      new Pnt3D(30.0, 36.0),
      new Pnt3D(0.0, 36.0)
    };
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ToolPositions5(ToolGeometry5 geo)
  {
    ((ToolGeometry5) this).Diameter = 2.0;
    ((ToolGeometry5) this).SocketThickness = 4.0;
    ((ToolGeometry5) this).DiameterLeft = 10.0;
    ((ToolGeometry5) this).DiameterRight = 10.0;
    ((ToolGeometry5) this).DiameterBody = 10.0;
    ((ToolGeometry5) this).ShoulderThickness = 0.0;
    ((ToolGeometry5) this).ShoulderDiameter = 0.0;
    ((ToolGeometry5) this).ShoulderLength = 0.0;
    ((ToolGeometry5) this).BottomDiameter = 10.0;
    ((ToolGeometry5) this).TopDiameter = 10.0;
    ((ToolGeometry5) this).RoundRadius = 2.0;
    ((ToolGeometry5) this).Length = 50.0;
    ((ToolGeometry5) this).TotalLength = 0.0;
    ((ToolGeometry5) this).LengthLeft = 50.0;
    ((ToolGeometry5) this).LengthRigth = 50.0;
    ((ToolGeometry5) this).LengthDiameter = 10.0;
    ((ToolGeometry5) this).CutLength = 20.0;
    ((ToolGeometry5) this).CutLengthLeft = 20.0;
    ((ToolGeometry5) this).CutLengthRight = 20.0;
    ((ToolGeometry5) this).ArborLength = 50.0;
    ((ToolGeometry5) this).ArborTopDiameter = 78.0;
    ((ToolGeometry5) this).ArborBottomDiameter = 45.0;
    ((ToolGeometry5) this).HolderLength = 30.0;
    ((ToolGeometry5) this).HolderDiameter = 100.0;
    ((ToolGeometry5) this).HolderInDiameter = 90.0;
    ((ToolGeometry5) this).TaperAngle = 8.0;
    ((ToolGeometry5) this).LowerRadius = 2.0;
    ((ToolDisplay5) this).UpperRadius = 2.0;
    ((ToolDisplay5) this).UpperDiameter = 10.0;
    ((ToolDisplay5) this).ProfileRadius = 12.0;
    ((ToolDisplay5) this).OutsideDiameter = 10.0;
    ((ToolDisplay5) this).ProfileDiameter = 10.0;
    ((ToolDisplay5) this).MaxDiameter = 10.0;
    ((ToolDisplay5) this).FlatnessDiameter = 0.0;
    ((ToolDisplay5) this).ConvexTipRadius = 2.0;
    ((ToolDisplay5) this).Thickness = 4.0;
    ((ToolDisplay5) this).MinLength = 0.0;
    ((ToolDisplay5) this).SizeWidth = 0.0;
    ((ToolDisplay5) this).SizeDepth = 0.0;
    ((ToolDisplay5) this).SizeHeight = 0.0;
    ((ToolData5) this).PositionAngle = 0.0;
    ((ToolData5) this).AddHalfOfToolThicknessToDistance = true;
    ((ToolData5) this).PlaneDirection = new Vec3D(0.0, 0.0, 1.0);
    ((ToolData5) this).ToolDirection = new Vec3D(0.0, 0.0, -1.0);
    ((ToolData5) this).DistanceForOrientation = new Vec3D(0.0, 0.0, 0.0);
    ((ToolData5) this).GeometryType = ToolType.Flat;
    ((ToolData5) this).FlatGeometry = ToolFlatGeometryType.None;
    ((ToolData5) this).CornerRadiusType = ToolCornerRadiusType.None;
    ((ToolData5) this).LengthReverseDirection = false;
    ((ToolData5) this).DrawHolder = true;
    ((ToolData5) this).DrawArbor = true;
    ((ToolData5) this).DrawLength = true;
    ((ToolData5) this).AgregateLeftEnable = true;
    ((ToolData5) this).AgregateRightEnable = true;
    ((ToolData5) this).AgregateVerticalLength = 150.0;
    ((ToolData5) this).AgregateToolCenterLength = 100.0;
    ((ToolData5) this).AgregateCircleBody = true;
    ((ToolData5) this).FromFileEnable = false;
    ((ToolData5) this).FromFileFileName = Application.StartupPath;
    ((ToolCamData5) this).FromFileAngle = 0.0;
    ((ToolCamData5) this).ArborPoints = new List<Pnt3D>()
    {
      new Pnt3D(0.0, 0.0),
      new Pnt3D(15.0, 0.0),
      new Pnt3D(17.5, 8.0),
      new Pnt3D(17.5, 25.0),
      new Pnt3D(20.0, 30.0),
      new Pnt3D(0.0, 30.0)
    };
    ((ToolCamData5) this).HolderPoints = new List<Pnt3D>()
    {
      new Pnt3D(0.0, 0.0),
      new Pnt3D(30.0, 0.0),
      new Pnt3D(30.0, 4.0),
      new Pnt3D(25.0, 8.0),
      new Pnt3D(25.0, 28.0),
      new Pnt3D(30.0, 32.0),
      new Pnt3D(30.0, 36.0),
      new Pnt3D(0.0, 36.0)
    };
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) geo, ref CopiedClass);
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

  public ToolPositions5(ToolGeometry geo)
  {
    ((ToolGeometry5) this).Diameter = 2.0;
    ((ToolGeometry5) this).SocketThickness = 4.0;
    ((ToolGeometry5) this).DiameterLeft = 10.0;
    ((ToolGeometry5) this).DiameterRight = 10.0;
    ((ToolGeometry5) this).DiameterBody = 10.0;
    ((ToolGeometry5) this).ShoulderThickness = 0.0;
    ((ToolGeometry5) this).ShoulderDiameter = 0.0;
    ((ToolGeometry5) this).ShoulderLength = 0.0;
    ((ToolGeometry5) this).BottomDiameter = 10.0;
    ((ToolGeometry5) this).TopDiameter = 10.0;
    ((ToolGeometry5) this).RoundRadius = 2.0;
    ((ToolGeometry5) this).Length = 50.0;
    ((ToolGeometry5) this).TotalLength = 0.0;
    ((ToolGeometry5) this).LengthLeft = 50.0;
    ((ToolGeometry5) this).LengthRigth = 50.0;
    ((ToolGeometry5) this).LengthDiameter = 10.0;
    ((ToolGeometry5) this).CutLength = 20.0;
    ((ToolGeometry5) this).CutLengthLeft = 20.0;
    ((ToolGeometry5) this).CutLengthRight = 20.0;
    ((ToolGeometry5) this).ArborLength = 50.0;
    ((ToolGeometry5) this).ArborTopDiameter = 78.0;
    ((ToolGeometry5) this).ArborBottomDiameter = 45.0;
    ((ToolGeometry5) this).HolderLength = 30.0;
    ((ToolGeometry5) this).HolderDiameter = 100.0;
    ((ToolGeometry5) this).HolderInDiameter = 90.0;
    ((ToolGeometry5) this).TaperAngle = 8.0;
    ((ToolGeometry5) this).LowerRadius = 2.0;
    ((ToolDisplay5) this).UpperRadius = 2.0;
    ((ToolDisplay5) this).UpperDiameter = 10.0;
    ((ToolDisplay5) this).ProfileRadius = 12.0;
    ((ToolDisplay5) this).OutsideDiameter = 10.0;
    ((ToolDisplay5) this).ProfileDiameter = 10.0;
    ((ToolDisplay5) this).MaxDiameter = 10.0;
    ((ToolDisplay5) this).FlatnessDiameter = 0.0;
    ((ToolDisplay5) this).ConvexTipRadius = 2.0;
    ((ToolDisplay5) this).Thickness = 4.0;
    ((ToolDisplay5) this).MinLength = 0.0;
    ((ToolDisplay5) this).SizeWidth = 0.0;
    ((ToolDisplay5) this).SizeDepth = 0.0;
    ((ToolDisplay5) this).SizeHeight = 0.0;
    ((ToolData5) this).PositionAngle = 0.0;
    ((ToolData5) this).AddHalfOfToolThicknessToDistance = true;
    ((ToolData5) this).PlaneDirection = new Vec3D(0.0, 0.0, 1.0);
    ((ToolData5) this).ToolDirection = new Vec3D(0.0, 0.0, -1.0);
    ((ToolData5) this).DistanceForOrientation = new Vec3D(0.0, 0.0, 0.0);
    ((ToolData5) this).GeometryType = ToolType.Flat;
    ((ToolData5) this).FlatGeometry = ToolFlatGeometryType.None;
    ((ToolData5) this).CornerRadiusType = ToolCornerRadiusType.None;
    ((ToolData5) this).LengthReverseDirection = false;
    ((ToolData5) this).DrawHolder = true;
    ((ToolData5) this).DrawArbor = true;
    ((ToolData5) this).DrawLength = true;
    ((ToolData5) this).AgregateLeftEnable = true;
    ((ToolData5) this).AgregateRightEnable = true;
    ((ToolData5) this).AgregateVerticalLength = 150.0;
    ((ToolData5) this).AgregateToolCenterLength = 100.0;
    ((ToolData5) this).AgregateCircleBody = true;
    ((ToolData5) this).FromFileEnable = false;
    ((ToolData5) this).FromFileFileName = Application.StartupPath;
    ((ToolCamData5) this).FromFileAngle = 0.0;
    ((ToolCamData5) this).ArborPoints = new List<Pnt3D>()
    {
      new Pnt3D(0.0, 0.0),
      new Pnt3D(15.0, 0.0),
      new Pnt3D(17.5, 8.0),
      new Pnt3D(17.5, 25.0),
      new Pnt3D(20.0, 30.0),
      new Pnt3D(0.0, 30.0)
    };
    ((ToolCamData5) this).HolderPoints = new List<Pnt3D>()
    {
      new Pnt3D(0.0, 0.0),
      new Pnt3D(30.0, 0.0),
      new Pnt3D(30.0, 4.0),
      new Pnt3D(25.0, 8.0),
      new Pnt3D(25.0, 28.0),
      new Pnt3D(30.0, 32.0),
      new Pnt3D(30.0, 36.0),
      new Pnt3D(0.0, 36.0)
    };
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) geo, ref CopiedClass);
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
    return $"{((ToolData5) this).GeometryType.ToString()} - Dia: {((ToolGeometry5) this).Diameter.ToString()} - Len: {((ToolGeometry5) this).Length.ToString()} - Thickness: {((ToolDisplay5) this).Thickness.ToString()}";
  }
}
