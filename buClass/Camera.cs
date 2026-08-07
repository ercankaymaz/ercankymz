// Decompiled with JetBrains decompiler
// Type: buClass.Camera
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

public class Camera
{
  private Pnt3D loc = new Pnt3D(0.0, 0.0, 0.0);
  private double _d = 500.0;
  private Quaternion quan = new Quaternion(1.0, 0.0, 0.0, 0.0);

  public Pnt3D Location
  {
    set => this.loc = value;
    get => this.loc;
  }

  public double FocalDistance
  {
    set => this._d = value;
    get => this._d;
  }

  public Quaternion Quaternion
  {
    set => this.quan = value;
    get => this.quan;
  }

  public void MoveRight(double d) => this.loc.X += d;

  public void MoveLeft(double d) => this.loc.X -= d;

  public void MoveUp(double d) => this.loc.Y -= d;

  public void MoveDown(double d) => this.loc.Y += d;

  public void MoveIn(double d) => this.loc.Z += d;

  public void MoveOut(double d) => this.loc.Z -= d;

  public void Roll(int degree)
  {
    Quaternion quaternion = new Quaternion();
    quaternion.FromAxisAngle(new Vec3D(0.0, 0.0, 1.0), (double) degree * Math.PI / 180.0);
    this.quan = quaternion * this.quan;
  }

  public void Yaw(int degree)
  {
    Quaternion quaternion = new Quaternion();
    quaternion.FromAxisAngle(new Vec3D(0.0, 1.0, 0.0), (double) degree * Math.PI / 180.0);
    this.quan = quaternion * this.quan;
  }

  public void Pitch(int degree)
  {
    Quaternion quaternion = new Quaternion();
    quaternion.FromAxisAngle(new Vec3D(1.0, 0.0, 0.0), (double) degree * Math.PI / 180.0);
    this.quan = quaternion * this.quan;
  }

  public void TurnUp(int degree) => this.Pitch(-degree);

  public void TurnDown(int degree) => this.Pitch(degree);

  public void TurnLeft(int degree) => this.Yaw(degree);

  public void TurnRight(int degree) => this.Yaw(-degree);

  public PointF[] GetProjection(Pnt3D[] pts)
  {
    PointF[] projection = new PointF[pts.Length];
    Pnt3D[] pts1 = Pnt3D.Copy(pts);
    Pnt3D.Offset(ref pts1, -this.loc.X, -this.loc.Y, -this.loc.Z);
    this.quan.Rotate(pts1);
    for (int index = 0; index < pts.Length; ++index)
      projection[index] = pts1[index].Z <= 0.1 ? new PointF(float.MaxValue, float.MaxValue) : new PointF((float) (this.loc.X + pts1[index].X * this._d / pts1[index].Z), (float) (this.loc.Y + pts1[index].Y * this._d / pts1[index].Z));
    return projection;
  }

  public PointF GetProjection(Pnt3D pts)
  {
    PointF projection = new PointF();
    Pnt3D pts1 = new Pnt3D(pts);
    Pnt3D.Offset(ref pts1, -this.loc.X, -this.loc.Y, -this.loc.Z);
    this.quan.Rotate(pts1);
    projection = pts1.Z <= 0.1 ? new PointF(float.MaxValue, float.MaxValue) : new PointF((float) (this.loc.X + pts1.X * this._d / pts1.Z), (float) (this.loc.Y + pts1.Y * this._d / pts1.Z));
    return projection;
  }
}
