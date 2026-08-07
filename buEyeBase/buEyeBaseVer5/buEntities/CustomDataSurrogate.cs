// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.CustomDataSurrogate
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class CustomDataSurrogate : Surrogate<CustomData>
{
  public entityTypeDefination typeDefination;
  public OrientationAngle Orientation;
  public string ToolName;
  public string LayerName;
  public int LayerIndex;
  public Color Color;
  public double Thickness;
  public List<Point3D> Vertices;
  public static byte f00384F;
  public static byte f003850;
  public static byte f003851;
  public Point3D Center;
  public double Radius;
  public double StartAngle;
  public double EndAngle;
  public bool Flip;
  public Plane Plane;
  public static byte f003858;
  public Point3D Center;
  public double Radius;
  public Plane Plane;
  public static byte f00385C;
  public Point3D Center;
  public double RadiusX;
  public double RadiusY;
  public double Angle;
  public Plane Plane;
  public static byte f003862;
  public static byte f003863;
  public List<Point4D> ControlPoints;
  public List<double> KnotVector;
  public int Degree;
  public bool isRational;
  public static byte f003868;
  public List<buEntity> CurveList;
  internal bool \u0001;
  internal double \u0001;
  public static byte f00386C;
  public List<buEntity> CurveList;
  public bool SortAndOrient;
  public Plane Plane;
  public static byte f003870;

  public virtual bool IsInFrustum(FrustumParams data, Point3D center, double radius) => true;

  public CustomDataSurrogate(string blockName)
  {
    ((RollerBendMoveCommand) this).xPos = 0.0;
    ((RollerBendMoveCommand) this).yPos = 0.0;
    ((RollerBendMoveCommand) this).zPos = 0.0;
    ((RollerBendMoveCommand) this).aPos = 0.0;
    ((RollerBendMoveCommand) this).bPos = 0.0;
    ((buRouter3AX) this).cPos = 0.0;
    ((buRouter3AX) this).xRot = 0.0;
    ((buRouter3AX) this).yRot = 0.0;
    ((buRouter3AX) this).zRot = 0.0;
    ((Router3AXItem) this).XMove = false;
    ((Router3AXItem) this).YMove = false;
    ((Router3AXItem) this).ZMove = false;
    ((Router3AXItem) this).ARotation = false;
    ((Router3AXItem) this).BRotation = false;
    ((Router3AXItem) this).CRotation = false;
    // ISSUE: explicit constructor call
    ((BlockReference) this).\u002Ector(0.0, 0.0, 0.0, blockName, 1.0, 1.0, 1.0, 0.0);
  }

  protected virtual void Animate(int frameNumber)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Entity) this).Animate(frameNumber));
  }

  public virtual void Rotate(double angleInRadians, Vector3D axis, Point3D center)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Entity) this).Rotate(angleInRadians, axis, center));
  }

  public virtual void MoveTo(DrawParams data)
  {
    // ISSUE: explicit non-virtual call
    __nonvirtual (((BlockReference) this).MoveTo(data));
    double x = ((RollerBendMoveCommand) this).xPos;
    double y = ((RollerBendMoveCommand) this).yPos;
    double z = ((RollerBendMoveCommand) this).zPos;
    if (((Router3AXItem) this).CRotation)
    {
      ((Router3AXItem) this).\u0001 = (Transformation) new Rotation(Utility.DegToRad(((buRouter3AX) this).cPos), new Vector3D(0.0, 0.0, 1.0), new Point3D(((buRouter3AX) this).xRot, ((buRouter3AX) this).yRot, ((buRouter3AX) this).zRot));
      data.RenderContext.MultMatrixModelView(((Router3AXItem) this).\u0001);
    }
    if (((Router3AXItem) this).BRotation)
    {
      ((Router3AXItem) this).\u0001 = (Transformation) new Rotation(Utility.DegToRad(((RollerBendMoveCommand) this).bPos), new Vector3D(0.0, 1.0, 0.0), new Point3D(((buRouter3AX) this).xRot, ((buRouter3AX) this).yRot, ((buRouter3AX) this).zRot));
      data.RenderContext.MultMatrixModelView(((Router3AXItem) this).\u0001);
    }
    if (((Router3AXItem) this).ARotation)
    {
      ((Router3AXItem) this).\u0001 = (Transformation) new Rotation(Utility.DegToRad(((RollerBendMoveCommand) this).aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(((buRouter3AX) this).xRot, ((buRouter3AX) this).yRot, ((buRouter3AX) this).zRot));
      data.RenderContext.MultMatrixModelView(((Router3AXItem) this).\u0001);
      Point3D point3D = new Point3D(x, y, z);
      point3D.TransformBy((Transformation) new Rotation(Utility.DegToRad(-((RollerBendMoveCommand) this).aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
      x = point3D.X;
      y = point3D.Y;
      z = point3D.Z;
    }
    this.ToString();
    if (!((Router3AXItem) this).XMove)
      x = 0.0;
    if (!((Router3AXItem) this).YMove)
      y = 0.0;
    if (!((Router3AXItem) this).ZMove)
      z = 0.0;
    ((Router3AXItem) this).\u0001 = (Transformation) new Translation(x, y, z);
    data.RenderContext.MultMatrixModelView(((Router3AXItem) this).\u0001);
  }

  public virtual bool IsInFrustum(FrustumParams data, Point3D center, double radius) => true;
}
