// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Utility.Point2D
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System;

#nullable disable
namespace Poly2Tri.Utility;

public class Point2D : IComparable<Point2D>
{
  private double x;
  private double y;

  public virtual double X
  {
    get => this.x;
    set => this.x = value;
  }

  public virtual double Y
  {
    get => this.y;
    set => this.y = value;
  }

  public float Xf => (float) this.X;

  public float Yf => (float) this.Y;

  public Point2D()
  {
    this.x = 0.0;
    this.y = 0.0;
  }

  public Point2D(double x, double y)
  {
    this.x = x;
    this.y = y;
  }

  public override string ToString() => $"[{this.X},{this.Y}]";

  public override int GetHashCode()
  {
    return 378163771 * this.x.GetHashCode() + 113137337 * this.y.GetHashCode();
  }

  public override bool Equals(object obj) => obj is Point2D p && this.Equals(p);

  public bool Equals(Point2D p, double epsilon = 0.0)
  {
    return (p == null || !MathUtil.AreValuesEqual(this.X, p.X, epsilon) ? 1 : (!MathUtil.AreValuesEqual(this.Y, p.Y, epsilon) ? 1 : 0)) == 0;
  }

  public int CompareTo(Point2D other)
  {
    return this.Y >= other.Y ? (this.Y <= other.Y ? (this.X >= other.X ? (this.X <= other.X ? 0 : 1) : -1) : 1) : -1;
  }

  public virtual void Set(double x, double y)
  {
    this.X = x;
    this.Y = y;
  }

  public void Subtract(Point2D p)
  {
    this.X -= p.X;
    this.Y -= p.Y;
  }

  public double Magnitude() => Math.Sqrt(this.MagnitudeSquared());

  public double MagnitudeSquared() => this.X * this.X + this.Y * this.Y;

  public void Normalize() => Class30.smethod_58(this, Class30.smethod_217(this));

  public double Dot(Point2D p) => this.X * p.X + this.Y * p.Y;

  public double Cross(Point2D p) => this.X * p.Y - this.Y * p.X;

  public static double Dot(Point2D lhs, Point2D rhs) => lhs.X * rhs.X + lhs.Y * rhs.Y;

  public static double Cross(Point2D lhs, Point2D rhs) => lhs.X * rhs.Y - lhs.Y * rhs.X;

  public static Point2D Perpendicular(Point2D lhs, double scalar)
  {
    return new Point2D(lhs.Y * scalar, lhs.X * -scalar);
  }

  public static Point2D Perpendicular(double scalar, Point2D rhs)
  {
    return new Point2D(-scalar * rhs.Y, scalar * rhs.X);
  }

  public static Point2D operator +(Point2D lhs, Point2D rhs)
  {
    return new Point2D(lhs.X + rhs.X, lhs.Y + rhs.Y);
  }

  public static Point2D operator +(Point2D lhs, double scalar)
  {
    return new Point2D(lhs.X + scalar, lhs.Y + scalar);
  }

  public static Point2D operator -(Point2D lhs, Point2D rhs)
  {
    return new Point2D(lhs.X - rhs.X, lhs.Y - rhs.Y);
  }

  public static Point2D operator -(Point2D lhs, double scalar)
  {
    return new Point2D(lhs.X - scalar, lhs.Y - scalar);
  }

  public static Point2D operator *(Point2D lhs, Point2D rhs)
  {
    return new Point2D(lhs.X * rhs.X, lhs.Y * rhs.Y);
  }

  public static Point2D operator *(Point2D lhs, double scalar)
  {
    return new Point2D(lhs.X * scalar, lhs.Y * scalar);
  }

  public static Point2D operator *(double scalar, Point2D rhs) => rhs * scalar;

  public static Point2D operator /(Point2D lhs, Point2D rhs)
  {
    return new Point2D(lhs.X / rhs.X, lhs.Y / rhs.Y);
  }

  public static Point2D operator /(Point2D lhs, double scalar)
  {
    return new Point2D(lhs.X / scalar, lhs.Y / scalar);
  }

  public static Point2D operator -(Point2D p) => new Point2D(-p.X, -p.Y);

  public static bool operator <(Point2D lhs, Point2D rhs) => lhs.CompareTo(rhs) == -1;

  public static bool operator >(Point2D lhs, Point2D rhs) => lhs.CompareTo(rhs) == 1;

  public static bool operator <=(Point2D lhs, Point2D rhs) => lhs.CompareTo(rhs) <= 0;

  public static bool operator >=(Point2D lhs, Point2D rhs) => lhs.CompareTo(rhs) >= 0;
}
