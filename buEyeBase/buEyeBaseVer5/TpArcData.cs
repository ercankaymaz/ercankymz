// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.TpArcData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class TpArcData
{
  public Pnt9D P9;
  public Pnt9D Offsets;
  public Pnt9D PostOffsets;
  public string XChar;
  public string YChar;
  public string ZChar;
  public static byte f0001A7;
  public Point3D StartPoint;
  public Point3D EndPoint;
  public Point3D CenterPoint;

  public static List<TpPnt9D> Copy(List<TpPnt9D> pts)
  {
    List<TpPnt9D> tpPnt9DList = new List<TpPnt9D>();
    for (int index = 0; index < pts.Count; ++index)
      tpPnt9DList.Add(TpPnt9D.Copy(pts[index]));
    return tpPnt9DList;
  }

  public static Pnt6DSimMove ToPnt6DSim(TpPnt9D pnt)
  {
    Pnt6DSimMove pnt6Dsim = (Pnt6DSimMove) new PointAndIndex(((TpArcData) pnt).P9.X, ((TpArcData) pnt).P9.Y, ((TpArcData) pnt).P9.Z, ((TpArcData) pnt).P9.A, ((TpArcData) pnt).P9.B, ((TpArcData) pnt).P9.C);
    ((MeshToSurfacePointsSettings) pnt6Dsim).FeedRate = pnt.Feed;
    ((MeshToSurfacePointsCalculations) pnt6Dsim).SpindleRpm = pnt.SpindleSpeed;
    ((MeshToSurfacePointsCalculations) pnt6Dsim).ToolNo = pnt.ToolNo;
    ((MeshToSurfacePointsCalculations) pnt6Dsim).ToolName = pnt.ToolName;
    ((MeshToSurfacePointsCalculations) pnt6Dsim).GCode = pnt.Type;
    return pnt6Dsim;
  }

  public override string ToString()
  {
    string str1 = $"X:{this.P9.X.ToString("f4")} ; Y:{this.P9.Y.ToString("f4")} ; Z:{this.P9.Z.ToString("f4")}";
    if (((TpPnt9D) this).EnableAxes.A | this.P9.A != 0.0)
      str1 = $"{str1} ; A:{this.P9.A.ToString("f4")}";
    if (((TpPnt9D) this).EnableAxes.B | this.P9.B != 0.0)
      str1 = $"{str1} ; B:{this.P9.B.ToString("f4")}";
    if (((TpPnt9D) this).EnableAxes.C | this.P9.C != 0.0)
      str1 = $"{str1} ; C:{this.P9.C.ToString("f4")}";
    if (((TpPnt9D) this).EnableAxes.U | this.P9.U != 0.0)
      str1 = $"{str1} ; U:{this.P9.U.ToString("f4")}";
    if (((TpPnt9D) this).EnableAxes.V | this.P9.V != 0.0)
      str1 = $"{str1}; V:{this.P9.V.ToString("f4")}";
    if (((TpPnt9D) this).EnableAxes.V | this.P9.W != 0.0)
      str1 = $"{str1}; W:{this.P9.W.ToString("f4")}";
    if (((TpPnt9D) this).Radius != 0.0)
      str1 = $"{str1}; R:{((TpPnt9D) this).Radius.ToString("f3")}";
    string str2 = $"{str1}; Feed: {((TpPnt9D) this).Feed.ToString()} ; Type: {((TpPnt9D) this).Type.ToString()}";
    string str3 = "";
    if (((TpPnt9D) this).EnableAxes.X)
      str3 += "X";
    if (((TpPnt9D) this).EnableAxes.Y)
      str3 += "Y";
    if (((TpPnt9D) this).EnableAxes.Z)
      str3 += "Z";
    if (((TpPnt9D) this).EnableAxes.A)
      str3 += "A";
    if (((TpPnt9D) this).EnableAxes.B)
      str3 += "B";
    if (((TpPnt9D) this).EnableAxes.C)
      str3 += "C";
    if (((TpPnt9D) this).EnableAxes.U)
      str3 += "U";
    if (((TpPnt9D) this).EnableAxes.V)
      str3 += "V";
    if (((TpPnt9D) this).EnableAxes.W)
      str3 += "W";
    if (str3.Length > 0)
      str2 = $"{str2} ; {str3}";
    if (((TpPnt9D) this).PlungeAxisMovement)
      str2 = $"{str2}; Plunge: {((TpPnt9D) this).PlungeAxis}";
    if (((TpPnt9D) this).LeaveAxisMovement)
      str2 = $"{str2}; Leave: {((TpPnt9D) this).LeaveAxis}";
    if (((TpPnt9D) this).PreCodes.Count > 0)
      str2 = $"{str2}; Pre: {((TpPnt9D) this).PreCodes[0].ToString()}";
    if (((TpPnt9D) this).AfterCodes.Count > 0)
      str2 = $"{str2}; After: {((TpPnt9D) this).AfterCodes[0].ToString()}";
    if (((TpPnt9D) this).IsSafePosition)
      str2 += "; isSafePos";
    return str2;
  }

  public static Pnt9D DecodeFromString(string Value)
  {
    try
    {
      CultureInfo provider = new CultureInfo("en-US", false);
      if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
        Value = Value.Replace(",", ".");
      Pnt9D pnt9D = new Pnt9D();
      Value = Value.Replace("X:", "");
      Value = Value.Replace("Y:", "");
      Value = Value.Replace("Z:", "");
      Value = Value.Replace("(", "");
      Value = Value.Replace(")", "");
      string[] strArray = Value.Split(';');
      if (strArray.Length == 2)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = 0.0;
      }
      if (strArray.Length == 3)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
      }
      if (strArray.Length == 4)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
      }
      if (strArray.Length == 5)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
      }
      if (strArray.Length == 6)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
      }
      if (strArray.Length == 7)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
      }
      if (strArray.Length == 8)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9D.V = double.Parse(strArray[7], (IFormatProvider) provider);
      }
      if (strArray.Length >= 9)
      {
        pnt9D.X = double.Parse(strArray[0], (IFormatProvider) provider);
        pnt9D.Y = double.Parse(strArray[1], (IFormatProvider) provider);
        pnt9D.Z = double.Parse(strArray[2], (IFormatProvider) provider);
        pnt9D.A = double.Parse(strArray[3], (IFormatProvider) provider);
        pnt9D.B = double.Parse(strArray[4], (IFormatProvider) provider);
        pnt9D.C = double.Parse(strArray[5], (IFormatProvider) provider);
        pnt9D.U = double.Parse(strArray[6], (IFormatProvider) provider);
        pnt9D.V = double.Parse(strArray[7], (IFormatProvider) provider);
        pnt9D.W = double.Parse(strArray[8], (IFormatProvider) provider);
      }
      return pnt9D;
    }
    catch (Exception ex)
    {
      return new Pnt9D();
    }
  }

  public string ToDef()
  {
    return $"X:{this.P9.X.ToString()}; Y:{this.P9.Y.ToString()}; Z:{this.P9.Z.ToString()}; A:{this.P9.A.ToString()}; B:{this.P9.B.ToString()}; C:{this.P9.C.ToString()}; U:{this.P9.U.ToString()}; V:{this.P9.V.ToString()}; W:{this.P9.W.ToString()}";
  }
}
