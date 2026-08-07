// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buSerilization5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Variables;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class buSerilization5
{
  public bool Visible;

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!((PageScene) this).\u0001 && disposing)
      ((PageScene) this).ScenePlane = (Plane) null;
    ((PageScene) this).\u0001 = true;
  }

  public abstract void m00006E();

  public static string ToDef(IndexTriangle P)
  {
    return $"{P.V1.ToString()} ; {P.V2.ToString()} ; {P.V3.ToString()}";
  }

  public static string ToDef(Point3D P)
  {
    return $"{P.X.ToString()} ; {P.Y.ToString()} ; {P.Z.ToString()}";
  }

  public static string ToDef(Point4D P)
  {
    return $"{P.X.ToString()} ; {P.Y.ToString()} ; {P.Z.ToString()} ; {P.W.ToString()}";
  }

  public static string ToDef(Vector3D P)
  {
    return $"{P.X.ToString()} ; {P.Y.ToString()} ; {P.Z.ToString()}";
  }

  public static string ToDef(OrientationAngle P)
  {
    return $"{P.A.ToString()} ; {P.B.ToString()} ; {P.C.ToString()}";
  }

  public static ArrayList ToDef(Plane P, string Char, int Space)
  {
    ArrayList def = new ArrayList();
    string str = Char;
    if (str.Length <= 0)
      str = "WorkPlane";
    def.Add((object) $"{buImage5.SpaceChar(Space)}<{str}>");
    def.Add((object) (buImage5.SpaceChar(Space) + buSerilization5.ToDef(P)));
    def.Add((object) $"{buImage5.SpaceChar(Space)}</{str}>");
    return def;
  }

  public static string ToDef(Plane P)
  {
    return $"{P.Origin.X.ToString()} ; {P.Origin.Y.ToString()} ; {P.Origin.Z.ToString()} # {P.AxisX.X.ToString()} ; {P.AxisX.Y.ToString()} ; {P.AxisX.Z.ToString()} # {P.AxisY.X.ToString()} ; {P.AxisY.Y.ToString()} ; {P.AxisY.Z.ToString()} # {P.Equation.X.ToString()} ; {P.Equation.Y.ToString()} ; {P.Equation.Z.ToString()}";
  }

  public static double DecoderFromDouble(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
        {
          double result = 0.0;
          double.TryParse(strArray[0], out result);
          return result;
        }
        if (strArray.Length == 2)
        {
          double result = 0.0;
          double.TryParse(strArray[1], out result);
          return result;
        }
      }
      return 0.0;
    }
    catch (Exception ex)
    {
      return 0.0;
    }
  }

  public static int DecoderFromInt(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
        {
          int result = 0;
          int.TryParse(strArray[0], out result);
          return result;
        }
        if (strArray.Length == 2)
        {
          int result = 0;
          int.TryParse(strArray[1], out result);
          return result;
        }
      }
      return 0;
    }
    catch (Exception ex)
    {
      return 0;
    }
  }

  public static float DecoderFromFloat(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
        {
          float result = 0.0f;
          float.TryParse(strArray[0], out result);
          return result;
        }
        if (strArray.Length == 2)
        {
          float result = 0.0f;
          float.TryParse(strArray[1], out result);
          return result;
        }
      }
      return 0.0f;
    }
    catch (Exception ex)
    {
      return 0.0f;
    }
  }

  public static bool DecoderFromBool(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
        {
          bool result = false;
          bool.TryParse(strArray[0], out result);
          return result;
        }
        if (strArray.Length == 2)
        {
          bool result = false;
          bool.TryParse(strArray[1], out result);
          return result;
        }
      }
      return false;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static string DecoderFromString(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return strArray[0];
        if (strArray.Length == 2)
          return strArray[1];
        if (strArray.Length == 3)
          return $"{strArray[1]}:{strArray[2]}";
      }
      return "";
    }
    catch (Exception ex)
    {
      return "";
    }
  }

  public static IndexTriangle DecoderFromTriangleIndex(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            int result1 = 0;
            int result2 = 0;
            int result3 = 0;
            int.TryParse(strArray2[0], out result1);
            int.TryParse(strArray2[1], out result2);
            int.TryParse(strArray2[2], out result3);
            return new IndexTriangle(result1, result2, result3);
          }
        }
      }
      return new IndexTriangle();
    }
    catch (Exception ex)
    {
      return new IndexTriangle();
    }
  }

  public static Point3D DecoderFromPoint3D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            return new Point3D(result1, result2, result3);
          }
        }
      }
      return new Point3D();
    }
    catch (Exception ex)
    {
      return new Point3D();
    }
  }

  public static Point4D DecoderFromPoint4D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            return new Point4D(result1, result2, result3, 0.0);
          }
          if (strArray2.Length == 4)
          {
            double result4 = 0.0;
            double result5 = 0.0;
            double result6 = 0.0;
            double result7 = 0.0;
            double.TryParse(strArray2[0], out result4);
            double.TryParse(strArray2[1], out result5);
            double.TryParse(strArray2[2], out result6);
            double.TryParse(strArray2[3], out result7);
            return new Point4D(result4, result5, result6, result7);
          }
        }
      }
      return new Point4D();
    }
    catch (Exception ex)
    {
      return new Point4D();
    }
  }

  public static Vector3D DecoderFromVector3D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            return new Vector3D(result1, result2, result3);
          }
        }
      }
      return new Vector3D();
    }
    catch (Exception ex)
    {
      return new Vector3D();
    }
  }

  public static Plane DecoderFromPlane(string Line)
  {
    try
    {
      Plane plane = (Plane) null;
      Point3D P = (Point3D) null;
      Vector3D X = (Vector3D) null;
      Vector3D Y = (Vector3D) null;
      Vector3D N = (Vector3D) null;
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split('#');
          if (strArray2 != null & strArray2.Length >= 1)
          {
            string[] strArray3 = strArray2[0].Split(';');
            if (strArray3.Length == 3)
            {
              double result1 = 0.0;
              double result2 = 0.0;
              double result3 = 0.0;
              double.TryParse(strArray3[0], out result1);
              double.TryParse(strArray3[1], out result2);
              double.TryParse(strArray3[2], out result3);
              P = new Point3D(result1, result2, result3);
            }
          }
          if (strArray2 != null & strArray2.Length >= 2)
          {
            string[] strArray4 = strArray2[1].Split(';');
            if (strArray4.Length == 3)
            {
              double result4 = 0.0;
              double result5 = 0.0;
              double result6 = 0.0;
              double.TryParse(strArray4[0], out result4);
              double.TryParse(strArray4[1], out result5);
              double.TryParse(strArray4[2], out result6);
              X = new Vector3D(result4, result5, result6);
            }
          }
          if (strArray2 != null & strArray2.Length >= 3)
          {
            string[] strArray5 = strArray2[2].Split(';');
            if (strArray5.Length == 3)
            {
              double result7 = 0.0;
              double result8 = 0.0;
              double result9 = 0.0;
              double.TryParse(strArray5[0], out result7);
              double.TryParse(strArray5[1], out result8);
              double.TryParse(strArray5[2], out result9);
              Y = new Vector3D(result7, result8, result9);
            }
          }
          if (strArray2 != null & strArray2.Length >= 4)
          {
            string[] strArray6 = strArray2[3].Split(';');
            if (strArray6.Length == 3)
            {
              double result10 = 0.0;
              double result11 = 0.0;
              double result12 = 0.0;
              double.TryParse(strArray6[0], out result10);
              double.TryParse(strArray6[1], out result11);
              double.TryParse(strArray6[2], out result12);
              N = new Vector3D(result10, result11, result12);
            }
          }
          if (P != (Point3D) null & X != (Vector3D) null & Y != (Vector3D) null)
            plane = new Plane(P, X, Y);
          else if (N != (Vector3D) null)
            plane = new Plane(N);
        }
      }
      return plane;
    }
    catch (Exception ex)
    {
      return Plane.XY;
    }
  }

  public static OrientationAngle DecoderFromOrientationAngle(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            return new OrientationAngle(result1, result2, result3);
          }
        }
      }
      return new OrientationAngle();
    }
    catch (Exception ex)
    {
      return new OrientationAngle();
    }
  }

  public static Pnt3D DecoderFromPnt3D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 3)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            return new Pnt3D(result1, result2, result3);
          }
        }
      }
      return new Pnt3D();
    }
    catch (Exception ex)
    {
      return new Pnt3D();
    }
  }

  public static Pnt6D DecoderFromPnt6D(string Line)
  {
    try
    {
      string[] strArray1 = Line.Split(':');
      if (strArray1 != null)
      {
        string str = "";
        if (strArray1.Length == 1)
          str = strArray1[0];
        if (strArray1.Length == 2)
          str = strArray1[1];
        if (str.Length > 0)
        {
          string[] strArray2 = str.Split(';');
          if (strArray2.Length == 6)
          {
            double result1 = 0.0;
            double result2 = 0.0;
            double result3 = 0.0;
            double result4 = 0.0;
            double result5 = 0.0;
            double result6 = 0.0;
            double.TryParse(strArray2[0], out result1);
            double.TryParse(strArray2[1], out result2);
            double.TryParse(strArray2[2], out result3);
            double.TryParse(strArray2[3], out result4);
            double.TryParse(strArray2[4], out result5);
            double.TryParse(strArray2[5], out result6);
            return new Pnt6D(result1, result2, result3, result4, result5, result6);
          }
        }
      }
      return new Pnt6D();
    }
    catch (Exception ex)
    {
      return new Pnt6D();
    }
  }

  public static entitySortDirection DecoderFromSortDirection(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (entitySortDirection) new EnumConverter(typeof (entitySortDirection)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (entitySortDirection) new EnumConverter(typeof (entitySortDirection)).ConvertFromString(strArray[1].ToString());
      }
      return entitySortDirection.Normal;
    }
    catch (Exception ex)
    {
      return entitySortDirection.Normal;
    }
  }

  public static entityTypeDefination DecoderFromDefinationType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (entityTypeDefination) new EnumConverter(typeof (entityTypeDefination)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (entityTypeDefination) new EnumConverter(typeof (entityTypeDefination)).ConvertFromString(strArray[1].ToString());
      }
      return entityTypeDefination.None;
    }
    catch (Exception ex)
    {
      return entityTypeDefination.None;
    }
  }

  public static EntityInfo DecoderFromEntityInfo(List<string> Lines)
  {
    try
    {
      EntityInfo entityInfo = (EntityInfo) new CharLibrary5();
      List<string> CalcList = new List<string>();
      buImage5.ListToSpecificList("<EntInfo>", "</EntInfo>", false, Lines, ref CalcList);
      if (CalcList.Count > 0)
      {
        for (int index = 0; index <= CalcList.Count - 1; ++index)
        {
          if (CalcList[index].ToLower().IndexOf("sequence") >= 0)
          {
            ((AnalyseEntitiesSetting) entityInfo).Sequence = buSerilization5.DecoderFromInt(CalcList[index]);
            ((AnalyseEntitiesSetting) entityInfo).OriginalEntityIndex = buSerilization5.DecoderFromInt(CalcList[index + 1]);
            ((EntityDataSet) entityInfo).CamID = buSerilization5.DecoderFromInt(CalcList[index + 2]);
            ((AnalyseEntitiesResultError) entityInfo).CamSelectable = buSerilization5.DecoderFromBool(CalcList[index + 3]);
            ((AnalyseEntitiesResult) entityInfo).CamSelected = buSerilization5.DecoderFromBool(CalcList[index + 4]);
            ((DirectionArrowSetting) entityInfo).DontUseForCalculation = buSerilization5.DecoderFromBool(CalcList[index + 5]);
            ((AnalyseEntitiesSetting) entityInfo).RefIndex = buSerilization5.DecoderFromInt(CalcList[index + 6]);
            ((EntityDataSet) entityInfo).Tags = buSerilization5.DecoderFromString(CalcList[index + 7]);
          }
        }
      }
      return (EntityInfo) new CharLibrary5();
    }
    catch (Exception ex)
    {
      return (EntityInfo) new CharLibrary5();
    }
  }

  public static drillTypes DecoderFromDrillType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (drillTypes) new EnumConverter(typeof (drillTypes)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (drillTypes) new EnumConverter(typeof (drillTypes)).ConvertFromString(strArray[1].ToString());
      }
      return drillTypes.SingleHole;
    }
    catch (Exception ex)
    {
      return drillTypes.SingleHole;
    }
  }

  public static CutTypes DecoderFromCutType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (CutTypes) new EnumConverter(typeof (CutTypes)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (CutTypes) new EnumConverter(typeof (CutTypes)).ConvertFromString(strArray[1].ToString());
      }
      return CutTypes.CutFree;
    }
    catch (Exception ex)
    {
      return CutTypes.CutFree;
    }
  }

  public static ProfilingTypes DecoderFromProfilingType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (ProfilingTypes) new EnumConverter(typeof (ProfilingTypes)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (ProfilingTypes) new EnumConverter(typeof (ProfilingTypes)).ConvertFromString(strArray[1].ToString());
      }
      return ProfilingTypes.ProfilingRectangle;
    }
    catch (Exception ex)
    {
      return ProfilingTypes.ProfilingRectangle;
    }
  }

  public static JunctionTypes DecoderFromJunctionType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (JunctionTypes) new EnumConverter(typeof (JunctionTypes)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (JunctionTypes) new EnumConverter(typeof (JunctionTypes)).ConvertFromString(strArray[1].ToString());
      }
      return JunctionTypes.Junction2HoleNearByHorizontal;
    }
    catch (Exception ex)
    {
      return JunctionTypes.Junction2HoleNearByHorizontal;
    }
  }

  public static UpDownLocationType DecoderFromUpDownLocationType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (UpDownLocationType) new EnumConverter(typeof (UpDownLocationType)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (UpDownLocationType) new EnumConverter(typeof (UpDownLocationType)).ConvertFromString(strArray[1].ToString());
      }
      return UpDownLocationType.Down;
    }
    catch (Exception ex)
    {
      return UpDownLocationType.Down;
    }
  }

  public static FrontBackType DecoderFromFrontBackType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (FrontBackType) new EnumConverter(typeof (FrontBackType)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (FrontBackType) new EnumConverter(typeof (FrontBackType)).ConvertFromString(strArray[1].ToString());
      }
      return FrontBackType.Back;
    }
    catch (Exception ex)
    {
      return FrontBackType.Back;
    }
  }

  public static ProfileNotchLocationType DecoderFromProfileNotchLocationType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (ProfileNotchLocationType) new EnumConverter(typeof (ProfileNotchLocationType)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (ProfileNotchLocationType) new EnumConverter(typeof (ProfileNotchLocationType)).ConvertFromString(strArray[1].ToString());
      }
      return ProfileNotchLocationType.Back;
    }
    catch (Exception ex)
    {
      return ProfileNotchLocationType.Back;
    }
  }

  public static ProfileNotchOperationType DecoderFromProfileNotchOperationType(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (ProfileNotchOperationType) new EnumConverter(typeof (ProfileNotchOperationType)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (ProfileNotchOperationType) new EnumConverter(typeof (ProfileNotchOperationType)).ConvertFromString(strArray[1].ToString());
      }
      return ProfileNotchOperationType.Side;
    }
    catch (Exception ex)
    {
      return ProfileNotchOperationType.Side;
    }
  }

  public static planeNames DecoderFromPlaneNames(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (planeNames) new EnumConverter(typeof (planeNames)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (planeNames) new EnumConverter(typeof (planeNames)).ConvertFromString(strArray[1].ToString());
      }
      return planeNames.Top;
    }
    catch (Exception ex)
    {
      return planeNames.Top;
    }
  }

  public static planeBoxNames DecoderFromPlaneBoxNames(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (planeBoxNames) new EnumConverter(typeof (planeBoxNames)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (planeBoxNames) new EnumConverter(typeof (planeBoxNames)).ConvertFromString(strArray[1].ToString());
      }
      return planeBoxNames.Top;
    }
    catch (Exception ex)
    {
      return planeBoxNames.Top;
    }
  }

  public static ShapeGroup DecoderFromShapeGroup(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (ShapeGroup) new EnumConverter(typeof (ShapeGroup)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (ShapeGroup) new EnumConverter(typeof (ShapeGroup)).ConvertFromString(strArray[1].ToString());
      }
      return ShapeGroup.Shape;
    }
    catch (Exception ex)
    {
      return ShapeGroup.Shape;
    }
  }

  public static CornerLocation DecoderFromCornerLocation(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (CornerLocation) new EnumConverter(typeof (CornerLocation)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (CornerLocation) new EnumConverter(typeof (CornerLocation)).ConvertFromString(strArray[1].ToString());
      }
      return CornerLocation.LeftBottom;
    }
    catch (Exception ex)
    {
      return CornerLocation.LeftBottom;
    }
  }

  public static ObjectAlignment DecoderFromObjectAlignment(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (ObjectAlignment) new EnumConverter(typeof (ObjectAlignment)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (ObjectAlignment) new EnumConverter(typeof (ObjectAlignment)).ConvertFromString(strArray[1].ToString());
      }
      return ObjectAlignment.MiddleCenter;
    }
    catch (Exception ex)
    {
      return ObjectAlignment.MiddleCenter;
    }
  }

  public static ShapeTypes DecoderFromShapeTypes(string Line)
  {
    try
    {
      string[] strArray = Line.Split(':');
      if (strArray != null)
      {
        if (strArray.Length == 1)
          return (ShapeTypes) new EnumConverter(typeof (ShapeTypes)).ConvertFromString(strArray[0].ToString());
        if (strArray.Length == 2)
          return (ShapeTypes) new EnumConverter(typeof (ShapeTypes)).ConvertFromString(strArray[1].ToString());
      }
      return ShapeTypes.None;
    }
    catch (Exception ex)
    {
      return ShapeTypes.None;
    }
  }

  public string ToDefLine(int Space)
  {
    try
    {
      string str1 = new string(' ', Space);
      List<cParameter5> Vars = new List<cParameter5>();
      buSerilization5.GetClassVariables((object) this, ref Vars);
      string defLine = str1;
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        string str2 = "";
        if (index < Vars.Count - 1)
          str2 = " ; ";
        defLine = $"{defLine}{((EditorRuntimeSettings) Vars[index]).Name} = {((EditorRuntimeSettings) Vars[index]).ValueAsString}{str2}";
      }
      return defLine;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return "";
    }
  }

  public ArrayList ToDefNewLine(int Space)
  {
    try
    {
      string str1 = new string(' ', Space);
      List<cParameter5> Vars = new List<cParameter5>();
      buSerilization5.GetClassVariables((object) this, ref Vars);
      ArrayList defNewLine = new ArrayList();
      for (int index1 = 0; index1 <= Vars.Count - 1; ++index1)
      {
        if (index1 == 28)
          ;
        if (Vars[index1] != null)
        {
          string str2 = ((EditorRuntimeSettings) Vars[index1]).Value.GetType().ToString();
          bool flag1 = false;
          Type type = ((EditorRuntimeSettings) Vars[index1]).Value.GetType();
          if (((EditorRuntimeSettings) Vars[index1]).Value.GetType() != typeof (ArrayList) & str2.IndexOf("Generic.List") < 0 & !type.IsArray)
          {
            bool flag2 = true;
            for (int index2 = 0; index2 <= screenInfo.ExceptionalVariables.Count - 1; ++index2)
            {
              if (screenInfo.ExceptionalVariables[index2].Trim().ToLower() == ((EditorRuntimeSettings) Vars[index1]).Name.Trim().ToLower())
              {
                flag2 = false;
                index2 = screenInfo.ExceptionalVariables.Count;
              }
            }
            if (flag2)
            {
              if (type.BaseType != (Type) null && (type.Namespace == "buClass" | type.BaseType.Namespace == "buClass" | type.Namespace == "buEyeBaseVer5" | type.BaseType.Namespace == "buEyeBaseVer5" | type.Namespace == "buMW" | type.BaseType.Namespace == "buMW" | type.BaseType.Name == nameof (buSerilization5)) & !type.IsEnum && ((EditorRuntimeSettings) Vars[index1]).Value.GetType().BaseType != typeof (eEntities))
              {
                string str3 = new string(' ', Space);
                defNewLine.Add((object) $"{str3}<{((EditorRuntimeSettings) Vars[index1]).Name}>");
                defNewLine.AddRange((ICollection) \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((EditorRuntimeSettings) Vars[index1]).Value, this, Space + 2).ToArray());
                defNewLine.Add((object) $"{str3}</{((EditorRuntimeSettings) Vars[index1]).Name}>");
                flag1 = true;
              }
              if (((EditorRuntimeSettings) Vars[index1]).Value.GetType().BaseType == typeof (eEntities))
                flag1 = true;
              if (((EditorRuntimeSettings) Vars[index1]).Value.GetType().BaseType == typeof (buEntity))
                flag1 = true;
              if (!flag1)
              {
                string str4 = this.GetType().Name + ".";
                defNewLine.Add((object) $"{str1}{str4}{((EditorRuntimeSettings) Vars[index1]).Name} = {((EditorRuntimeSettings) Vars[index1]).ValueAsString.ToString()}");
              }
            }
          }
          else if (type.IsArray)
            defNewLine.AddRange((ICollection) ((pageInfo) this).\u0002(((EditorRuntimeSettings) Vars[index1]).Name.ToString(), ((EditorRuntimeSettings) Vars[index1]).Value, Space).ToArray());
          else if (((EditorRuntimeSettings) Vars[index1]).Value.GetType() == typeof (ArrayList))
          {
            ArrayList arrayList = defNewLine;
            string str5 = ((EditorRuntimeSettings) Vars[index1]).Name.ToString();
            object[] array = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((ArrayList) ((EditorRuntimeSettings) Vars[index1]).Value, str5, this, Space).ToArray();
            arrayList.AddRange((ICollection) array);
          }
          else if (str2.IndexOf("Generic.List") >= 0)
          {
            string[] strArray = str2.Split(new string[1]
            {
              "Generic.List"
            }, StringSplitOptions.None);
            bool flag3 = true;
            for (int index3 = 0; index3 <= screenInfo.ExceptionalVariables.Count - 1; ++index3)
            {
              if (screenInfo.ExceptionalVariables[index3].Trim().ToLower() == ((EditorRuntimeSettings) Vars[index1]).Name.Trim().ToLower())
              {
                flag3 = false;
                index3 = screenInfo.ExceptionalVariables.Count;
              }
            }
            if (flag3)
            {
              if (strArray.Length == 2)
                defNewLine.AddRange((ICollection) this.\u0001(((EditorRuntimeSettings) Vars[index1]).Name.ToString(), ((EditorRuntimeSettings) Vars[index1]).Value, Space).ToArray());
              if (strArray.Length == 3)
              {
                ArrayList arrayList = defNewLine;
                string str6 = ((EditorRuntimeSettings) Vars[index1]).Name.ToString();
                object[] array = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((EditorRuntimeSettings) Vars[index1]).Value, Space, this, str6).ToArray();
                arrayList.AddRange((ICollection) array);
              }
            }
          }
        }
      }
      return defNewLine;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }

  public ArrayList ToDefAll(string Char, int Space)
  {
    return this.ToDefAll(Char, Space, (SerilizationMode5) 1);
  }

  public ArrayList ToDefAll(string Char, int Space, SerilizationMode5 DefMode)
  {
    // ISSUE: unable to decompile the method.
  }

  public ArrayList ToDefAll(
    string Char,
    int Space,
    SerilizationMode5 DefMode,
    string DefClassName)
  {
    // ISSUE: unable to decompile the method.
  }

  public static object Decode(ArrayList AL, string Char, SerilizationMode5 Mode, object Obj)
  {
    object obj = (object) null;
    List<string> CalcList = new List<string>();
    List<string> stringList = new List<string>();
    buStatics.ListToSpecificList($"<{Obj.GetType().Name}{Char}>", $"</{Obj.GetType().Name}{Char}>", AL, ref CalcList);
    if (CalcList.Count > 0)
    {
      List<cParameter5> Vars = new List<cParameter5>();
      buSerilization5.GetClassVariableValuesFromStringCodes(CalcList, Obj, ref Vars);
      if (Vars.Count > 0)
        buSerilization5.SetClassVariables(ref Obj, Vars);
    }
    return obj;
  }

  public static object Decode(List<string> SL, string Char, SerilizationMode5 Mode, object Obj)
  {
    // ISSUE: unable to decompile the method.
  }

  public static void ClassToString(object ObjPar, ref string Line)
  {
    List<cParameter5> Vars = new List<cParameter5>();
    buSerilization5.GetClassVariables(ObjPar, false, false, false, false, ref Vars);
    if (Vars.Count <= 0)
      return;
    for (int index = 0; index <= Vars.Count - 1; ++index)
    {
      if (Vars[index] != null && ((EditorRuntimeSettings) Vars[index]).Value != null)
      {
        string str = ((EditorRuntimeSettings) Vars[index]).Value.ToString();
        if (((EditorRuntimeSettings) Vars[index]).Field.FieldType == typeof (Point3D))
          str = buSerilization5.ToDef((Point3D) ((EditorRuntimeSettings) Vars[index]).Value);
        else if (((EditorRuntimeSettings) Vars[index]).Field.FieldType == typeof (Vector3D))
          str = buSerilization5.ToDef((Vector3D) ((EditorRuntimeSettings) Vars[index]).Value);
        else if (((EditorRuntimeSettings) Vars[index]).Field.FieldType == typeof (OrientationAngle))
          str = buSerilization5.ToDef((OrientationAngle) ((EditorRuntimeSettings) Vars[index]).Value);
        else if (((EditorRuntimeSettings) Vars[index]).Field.FieldType == typeof (Pnt3D))
          str = ((Pnt3D) ((EditorRuntimeSettings) Vars[index]).Value).ToDefNumber();
        else if (((EditorRuntimeSettings) Vars[index]).Field.FieldType == typeof (Pnt6D))
          str = ((Pnt6D) ((EditorRuntimeSettings) Vars[index]).Value).ToDefNumber();
        else if (((EditorRuntimeSettings) Vars[index]).Field.FieldType == typeof (Vec3D))
          str = ((Vec3D) ((EditorRuntimeSettings) Vars[index]).Value).ToDefNumber();
        else if (((EditorRuntimeSettings) Vars[index]).Field.FieldType == typeof (Plane))
          str = buSerilization5.ToDef((Plane) ((EditorRuntimeSettings) Vars[index]).Value);
        if (Line.Length == 0)
          Line = $"{((EditorRuntimeSettings) Vars[index]).Name}: {str}";
        else
          Line = $"{Line} | {((EditorRuntimeSettings) Vars[index]).Name}: {str}";
      }
    }
  }

  public static string ClassToString(object ObjPar)
  {
    string Line = "";
    buSerilization5.ClassToString(ObjPar, ref Line);
    return Line;
  }

  public static void StringToClass(ref object ObjPar, string Line)
  {
    if (Line.Trim().Length <= 0)
      return;
    string[] strArr = Line.Split('|');
    if (strArr == null || strArr.Length == 0)
      return;
    string[] strArray = strArr[0].Split('=');
    if ((strArray == null ? 0 : (strArray.Length >= 2 ? 1 : 0)) != 0)
      strArr[0] = strArray[1];
    List<cParameter5> Vars = new List<cParameter5>();
    buSerilization5.GetClassVariables(ObjPar, false, false, false, false, ref Vars);
    for (int index = 0; index <= Vars.Count - 1; ++index)
    {
      if (Vars[index] != null)
      {
        string stringArrayByName = buSerilization5.GetValueFromStringArrayByName(strArr, ((EditorRuntimeSettings) Vars[index]).Name);
        FieldInfo field = ((EditorRuntimeSettings) Vars[index]).Field;
        if (stringArrayByName.Length > 0)
        {
          buSerilization5.SetObjectValueByType(ref field, ref ObjPar, (object) stringArrayByName);
          ((EditorRuntimeSettings) Vars[index]).ValueAsString = stringArrayByName;
        }
      }
    }
  }

  public static string GetValueFromLineByName(string Line, string ParName)
  {
    return buSerilization5.GetValueFromStringArrayByName(Line.Split('|'), ParName);
  }

  public static string GetValueFromStringArrayByName(string[] strArr, string ParName)
  {
    string str1 = "";
    string stringArrayByName;
    if (strArr != null && strArr.Length != 0)
    {
      for (int index = 0; index <= strArr.Length - 1; ++index)
      {
        string[] strArray = strArr[index].Split(':');
        if (strArray != null && strArray.Length == 2)
        {
          string str2 = strArray[0].Trim();
          string str3 = strArray[1].Trim();
          if (str2.Trim().ToLower() == ParName.Trim().ToLower())
          {
            stringArrayByName = str3;
            goto label_8;
          }
        }
      }
    }
    stringArrayByName = str1;
label_8:
    return stringArrayByName;
  }

  public static void GetClassVariables(object ObjPar, ref List<cParameter5> Vars)
  {
    buSerilization5.GetClassVariables(ObjPar, true, true, true, true, ref Vars);
  }

  public static void GetClassVariables(
    object ObjPar,
    bool UseSubClass,
    bool UseArrayList,
    bool UseList,
    bool UseArray,
    ref List<cParameter5> Vars)
  {
    try
    {
      Vars.Clear();
      if (ObjPar == null)
        return;
      FieldInfo[] fields = ObjPar.GetType().GetFields();
      if (fields == null)
        return;
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        if (index == 8)
          ;
        cParameter5 cParameter5_1 = (cParameter5) null;
        object obj = (object) null;
        FieldInfo field = fields[index];
        string name1 = field.Name;
        string name2 = field.Name;
        if (ObjPar == null)
          ;
        obj = field.GetValue(ObjPar);
        if (obj == null)
          buSerilization5.NullToValue(ref obj, field);
        if (obj != null)
        {
          Type type = obj.GetType();
          if (field.FieldType.ToString().IndexOf("Generic.List") < 0 & field.FieldType.ToString().IndexOf("ArrayList") < 0 & !type.IsArray)
          {
            if (obj.GetType() == typeof (double))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (int))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (float))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (long))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (uint))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (bool))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (byte))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (string))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Color))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = buStatics.ColorToString((Color) obj, ColorConvertType.String);
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Font))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = buStatics.FontToString((Font) obj);
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (DateTime))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((DateTime) obj).ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Size))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              cParameter5 cParameter5_2 = cParameter5_1;
              Size size = (Size) obj;
              string str1 = size.Width.ToString();
              size = (Size) obj;
              string str2 = size.Height.ToString();
              string str3 = $"{str1};{str2}";
              ((EditorRuntimeSettings) cParameter5_2).ValueAsString = str3;
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (SizeF))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              cParameter5 cParameter5_3 = cParameter5_1;
              SizeF sizeF = (SizeF) obj;
              string str4 = sizeF.Width.ToString();
              sizeF = (SizeF) obj;
              string str5 = sizeF.Height.ToString();
              string str6 = $"{str4};{str5}";
              ((EditorRuntimeSettings) cParameter5_3).ValueAsString = str6;
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Point))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              cParameter5 cParameter5_4 = cParameter5_1;
              Point point = (Point) obj;
              string str7 = point.X.ToString();
              point = (Point) obj;
              string str8 = point.Y.ToString();
              string str9 = $"{str7};{str8}";
              ((EditorRuntimeSettings) cParameter5_4).ValueAsString = str9;
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (PointF))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              cParameter5 cParameter5_5 = cParameter5_1;
              PointF pointF = (PointF) obj;
              string str10 = pointF.X.ToString();
              pointF = (PointF) obj;
              string str11 = pointF.Y.ToString();
              string str12 = $"{str10};{str11}";
              ((EditorRuntimeSettings) cParameter5_5).ValueAsString = str12;
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Pnt2D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Pnt2D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Pnt3D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Pnt3D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Point3D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = F_AnalyseResult.Point3DToDef((Point3D) obj);
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Vector3D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = F_AnalyseResult.Vector3DToDef((Vector3D) obj);
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Pnt6D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Pnt6D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Pnt9D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Pnt9D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Vec3D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Vec3D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Length3D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Length3D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (OrientationAngle))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((OrientationAngle) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Line3D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Line3D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Triangle3D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Triangle3D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Quad3D))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = ((Quad3D) obj).ToDef();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (Plane))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = buSerilization5.ToDef((Plane) obj);
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (obj.GetType() == typeof (object))
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = "";
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else
            {
              if (type.IsEnum)
              {
                cParameter5_1 = (cParameter5) new buVector5();
                ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
                ((EditorRuntimeSettings) cParameter5_1).Value = obj;
                ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
                ((EditorRuntimeSettings) cParameter5_1).Field = field;
                ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
              }
              if (field.FieldType.BaseType != (Type) null && type.IsClass & (field.FieldType.BaseType.Namespace.IndexOf("buClass") >= 0 | field.FieldType.BaseType.Namespace.IndexOf("buMW") >= 0 | field.FieldType.BaseType.Namespace.IndexOf("buEyeBaseVer5") >= 0 | field.FieldType.Namespace.IndexOf("buClass") >= 0 | field.FieldType.Namespace.IndexOf("buEyeBaseVer5") >= 0) & UseSubClass)
              {
                cParameter5_1 = (cParameter5) new buVector5();
                List<cParameter5> Vars1 = new List<cParameter5>();
                buSerilization5.GetClassVariables(obj, ref Vars1);
                ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
                ((EditorRuntimeSettings) cParameter5_1).Value = obj;
                ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
                ((EditorRuntimeSettings) cParameter5_1).Field = field;
                ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
                ((EditorRuntimeSettings) cParameter5_1).SubParameter = (object) Vars1;
              }
            }
          }
          else
          {
            if (type.IsArray & UseArray)
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            if (field.FieldType.ToString().IndexOf("ArrayList") >= 0 & !type.IsArray & UseArrayList)
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
            else if (field.FieldType.ToString().IndexOf("Generic.List") >= 0 & !type.IsArray & UseList && !field.IsStatic)
            {
              cParameter5_1 = (cParameter5) new buVector5();
              ((EditorRuntimeSettings) cParameter5_1).Name = field.Name;
              ((EditorRuntimeSettings) cParameter5_1).Value = obj;
              ((EditorRuntimeSettings) cParameter5_1).ValueAsString = obj.ToString();
              ((EditorRuntimeSettings) cParameter5_1).Field = field;
              ((EditorRuntimeSettings) cParameter5_1).Types = obj.GetType();
            }
          }
        }
        if (cParameter5_1 != null)
          Vars.Add(cParameter5_1);
        else
          Vars.Add(cParameter5_1);
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetCaptionsOfClass(object ObjPar, ref List<string> Captions)
  {
    FieldInfo[] fields = ObjPar.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      if (fields[index].IsStatic && fields[index].Name == "Caption" | fields[index].Name == nameof (Captions))
        Captions.AddRange((IEnumerable<string>) ((List<string>) fields[index].GetValue(ObjPar)).ToArray());
    }
  }

  public static void NullToValue(ref object Obj, FieldInfo field)
  {
    if (field.FieldType == typeof (double))
    {
      double num = 0.0;
      Obj = (object) num;
    }
    if (field.FieldType == typeof (int))
      Obj = (object) 0;
    if (field.FieldType == typeof (float))
    {
      float num = 0.0f;
      Obj = (object) num;
    }
    if (field.FieldType == typeof (long))
      Obj = (object) 0L;
    if (field.FieldType == typeof (uint))
      Obj = (object) 0U;
    if (field.FieldType == typeof (bool))
      Obj = (object) false;
    if (field.FieldType == typeof (byte))
      Obj = (object) (byte) 0;
    if (field.FieldType == typeof (string))
    {
      string str = "";
      Obj = (object) str;
    }
    if (field.FieldType == typeof (Color))
    {
      Color white = Color.White;
      Obj = (object) white;
    }
    if (field.FieldType == typeof (Font))
    {
      Font font = new Font("Arial", 10f);
      Obj = (object) font;
    }
    if (field.FieldType == typeof (DateTime))
    {
      DateTime dateTime = new DateTime();
      Obj = (object) dateTime;
    }
    if (field.FieldType == typeof (Size))
    {
      Size size = new Size();
      Obj = (object) size;
    }
    if (field.FieldType == typeof (SizeF))
    {
      SizeF sizeF = new SizeF();
      Obj = (object) sizeF;
    }
    if (field.FieldType == typeof (Point))
    {
      Point point = new Point();
      Obj = (object) point;
    }
    if (field.FieldType == typeof (PointF))
    {
      PointF pointF = new PointF();
      Obj = (object) pointF;
    }
    if (field.FieldType == typeof (Pnt2D))
    {
      Pnt2D pnt2D = new Pnt2D();
      Obj = (object) pnt2D;
    }
    if (field.FieldType == typeof (Pnt3D))
    {
      Pnt3D pnt3D = new Pnt3D();
      Obj = (object) pnt3D;
    }
    if (field.FieldType == typeof (Point3D))
    {
      Point3D point3D = new Point3D();
      Obj = (object) point3D;
    }
    if (field.FieldType == typeof (Vector3D))
    {
      Vector3D vector3D = new Vector3D();
      Obj = (object) vector3D;
    }
    if (field.FieldType == typeof (Pnt6D))
    {
      Pnt6D pnt6D = new Pnt6D();
      Obj = (object) pnt6D;
    }
    if (field.FieldType == typeof (Pnt9D))
    {
      Pnt9D pnt9D = new Pnt9D();
      Obj = (object) pnt9D;
    }
    if (field.FieldType == typeof (Vec3D))
    {
      Vec3D vec3D = new Vec3D();
      Obj = (object) vec3D;
    }
    if (field.FieldType == typeof (Length3D))
    {
      Length3D length3D = new Length3D();
      Obj = (object) length3D;
    }
    if (field.FieldType == typeof (OrientationAngle))
    {
      OrientationAngle orientationAngle = new OrientationAngle();
      Obj = (object) orientationAngle;
    }
    if (field.FieldType == typeof (Line3D))
    {
      Line3D line3D = new Line3D();
      Obj = (object) line3D;
    }
    if (field.FieldType == typeof (Triangle3D))
    {
      Triangle3D triangle3D = new Triangle3D();
      Obj = (object) triangle3D;
    }
    if (!(field.FieldType == typeof (Quad3D)))
      return;
    Quad3D quad3D = new Quad3D();
    Obj = (object) quad3D;
  }

  public static void SetClassVariable(ref object ObjPar, cParameter5 Var)
  {
    try
    {
      if (ObjPar == null)
        return;
      FieldInfo[] fields = ObjPar.GetType().GetFields();
      if (fields == null)
        return;
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        object ObjPar1 = (object) null;
        FieldInfo FI = fields[index];
        string name1 = FI.Name;
        string name2 = FI.Name;
        Type fieldType = FI.FieldType;
        if (FI.FieldType.ToString().IndexOf("List") < 0 & !fieldType.IsArray)
        {
          if (FI.Name == ((EditorRuntimeSettings) Var).Name)
          {
            ObjPar1 = ((EditorRuntimeSettings) Var).Value;
            if ((fieldType.Namespace == "buClass" | fieldType.BaseType.Namespace == "buClass" | fieldType.Namespace == "buEyeBaseVer5" | fieldType.BaseType.Namespace == "buEyeBaseVer5" | fieldType.Namespace == "buMW" | fieldType.BaseType.Namespace == nameof (buSerilization5)) & !fieldType.IsEnum & fieldType.IsClass && (List<cParameter5>) ((EditorRuntimeSettings) Var).SubParameter != null)
            {
              buSerilization5.SetClassVariables(ref ObjPar1, (List<cParameter5>) ((EditorRuntimeSettings) Var).SubParameter);
              FI.SetValue(ObjPar, ObjPar1);
            }
            if (ObjPar1 != null)
              buSerilization5.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
          }
        }
        else if (FI.FieldType.ToString().IndexOf("ArrayList") >= 0 & !fieldType.IsArray)
        {
          if (FI.Name == ((EditorRuntimeSettings) Var).Name)
          {
            \u0007.\u0001.\u0001(ref ObjPar1, ((EditorRuntimeSettings) Var).Value);
            ObjPar1 = ((EditorRuntimeSettings) Var).Value;
            if (ObjPar1 != null)
              buSerilization5.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
          }
        }
        else if (FI.FieldType.ToString().IndexOf("Generic.List") >= 0 & !fieldType.IsArray)
        {
          if (FI.Name == ((EditorRuntimeSettings) Var).Name)
          {
            \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((EditorRuntimeSettings) Var).Value, ref ObjPar1);
            ObjPar1 = ((EditorRuntimeSettings) Var).Value;
            if (ObjPar1 != null)
              buSerilization5.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
          }
        }
        else if (fieldType.IsArray && FI.Name == ((EditorRuntimeSettings) Var).Name)
        {
          \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((EditorRuntimeSettings) Var).Value, ref ObjPar1);
          ObjPar1 = ((EditorRuntimeSettings) Var).Value;
          if (ObjPar1 != null)
            buSerilization5.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void SetClassVariables(ref object ObjPar, List<cParameter5> Vars)
  {
    try
    {
      if (ObjPar == null)
        return;
      FieldInfo[] fields = ObjPar.GetType().GetFields();
      if (fields == null)
        return;
      for (int index1 = 0; index1 <= fields.Length - 1; ++index1)
      {
        if (index1 == 14)
          ;
        object ObjPar1 = (object) null;
        FieldInfo FI = fields[index1];
        string name1 = FI.Name;
        string name2 = FI.Name;
        Type fieldType = FI.FieldType;
        if (FI.FieldType.ToString().IndexOf("List") < 0 & !fieldType.IsArray)
        {
          for (int index2 = 0; index2 <= Vars.Count - 1; ++index2)
          {
            if (Vars[index2] != null && FI.Name == ((EditorRuntimeSettings) Vars[index2]).Name.ToString())
            {
              ObjPar1 = ((EditorRuntimeSettings) Vars[index2]).Value;
              index2 = Vars.Count + 1;
            }
          }
          if (fieldType.BaseType != (Type) null)
          {
            if ((fieldType.Namespace == "buClass" | fieldType.BaseType.Namespace == "buClass" | fieldType.Namespace == "buEyeBaseVer5" | fieldType.BaseType.Namespace == "buEyeBaseVer5" | fieldType.Namespace == "buMW" | fieldType.BaseType.Namespace == nameof (buSerilization5)) & !fieldType.IsEnum & fieldType.IsClass && index1 <= Vars.Count - 1 && (Vars[index1] == null ? 0 : ((List<cParameter5>) ((EditorRuntimeSettings) Vars[index1]).SubParameter != null ? 1 : 0)) != 0)
            {
              buSerilization5.SetClassVariables(ref ObjPar1, (List<cParameter5>) ((EditorRuntimeSettings) Vars[index1]).SubParameter);
              FI.SetValue(ObjPar, ObjPar1);
            }
          }
          else if ((fieldType.Namespace == "buClass" | fieldType.Namespace == "buEyeBaseVer5" | fieldType.Namespace == "buMW") & !fieldType.IsEnum & fieldType.IsClass && index1 <= Vars.Count - 1 && (Vars[index1] == null ? 0 : ((List<cParameter5>) ((EditorRuntimeSettings) Vars[index1]).SubParameter != null ? 1 : 0)) != 0)
          {
            buSerilization5.SetClassVariables(ref ObjPar1, (List<cParameter5>) ((EditorRuntimeSettings) Vars[index1]).SubParameter);
            FI.SetValue(ObjPar, ObjPar1);
          }
          if (ObjPar1 != null)
            buSerilization5.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
        }
        else if (FI.FieldType.ToString().IndexOf("ArrayList") >= 0 & !fieldType.IsArray)
        {
          for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
          {
            if ((Vars[index3] == null ? 0 : (FI.Name == ((EditorRuntimeSettings) Vars[index3]).Name ? 1 : 0)) != 0)
            {
              \u0007.\u0001.\u0001(ref ObjPar1, ((EditorRuntimeSettings) Vars[index3]).Value);
              ObjPar1 = ((EditorRuntimeSettings) Vars[index3]).Value;
              index3 = Vars.Count + 1;
            }
          }
          if (ObjPar1 != null)
            buSerilization5.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
        }
        else if (FI.FieldType.ToString().IndexOf("Generic.List") >= 0 & !fieldType.IsArray)
        {
          string[] strArray = FI.FieldType.ToString().Split(new string[1]
          {
            "Generic.List"
          }, StringSplitOptions.None);
          ArrayList arrayList = new ArrayList();
          List<cParameter5> cParameter5List = new List<cParameter5>();
          if (strArray.Length == 2 | strArray.Length == 3)
          {
            for (int index4 = 0; index4 <= Vars.Count - 1; ++index4)
            {
              if (Vars[index4] != null && FI.Name == ((EditorRuntimeSettings) Vars[index4]).Name)
              {
                \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((EditorRuntimeSettings) Vars[index4]).Value, ref ObjPar1);
                ObjPar1 = ((EditorRuntimeSettings) Vars[index4]).Value;
                index4 = Vars.Count + 1;
              }
            }
            if (ObjPar1 != null)
              buSerilization5.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
          }
        }
        else if (fieldType.IsArray)
        {
          for (int index5 = 0; index5 <= Vars.Count - 1; ++index5)
          {
            if (FI.Name == ((EditorRuntimeSettings) Vars[index5]).Name)
            {
              \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(((EditorRuntimeSettings) Vars[index5]).Value, ref ObjPar1);
              ObjPar1 = ((EditorRuntimeSettings) Vars[index5]).Value;
              index5 = Vars.Count + 1;
            }
          }
          if (ObjPar1 != null)
            buSerilization5.SetObjectValueByType(ref FI, ref ObjPar, ObjPar1);
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void CopyClass(object RefClass, ref object CopiedClass)
  {
    if (RefClass == null)
      return;
    List<cParameter5> Vars = new List<cParameter5>();
    buSerilization5.GetClassVariables(RefClass, ref Vars);
    CopiedClass = new object();
    CopiedClass = Activator.CreateInstance(RefClass.GetType());
    buSerilization5.SetClassVariables(ref CopiedClass, Vars);
  }

  public static void SetObjectValueByType(ref FieldInfo FI, ref object Obj, object Value)
  {
    try
    {
      if (!(FI != (FieldInfo) null))
        return;
      if (FI.FieldType == typeof (double))
      {
        double result = 0.0;
        if (double.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (float))
      {
        float result = 0.0f;
        if (float.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (int))
      {
        int result = 0;
        if (int.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (long))
      {
        long result = 0;
        if (long.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (uint))
      {
        uint result = 0;
        if (uint.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (bool))
      {
        bool result = false;
        if (bool.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (short))
      {
        short result = 0;
        if (short.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (string))
        FI.SetValue(Obj, (object) Value.ToString());
      if (FI.FieldType == typeof (long))
      {
        long result = 0;
        if (long.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (uint))
      {
        uint result = 0;
        if (uint.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (byte))
      {
        byte result = 0;
        if (byte.TryParse(Value.ToString(), out result))
          FI.SetValue(Obj, (object) result);
      }
      if (FI.FieldType == typeof (Size))
      {
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToSize(Value.ToString()));
        if (Value.GetType() == typeof (Size))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType == typeof (SizeF))
      {
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToSizeF(Value.ToString()));
        if (Value.GetType() == typeof (SizeF))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType == typeof (Point))
      {
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToPoint(Value.ToString()));
        if (Value.GetType() == typeof (Point))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType == typeof (PointF))
      {
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToPointF(Value.ToString()));
        if (Value.GetType() == typeof (PointF))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType.BaseType == typeof (Enum))
      {
        EnumConverter enumConverter = new EnumConverter(FI.FieldType);
        FI.SetValue(Obj, enumConverter.ConvertFromString(Value.ToString()));
      }
      if (FI.FieldType == typeof (Color))
        FI.SetValue(Obj, (object) buStatics.StringToColor(Value.ToString(), ColorConvertType.String));
      if (FI.FieldType == typeof (Font))
      {
        FontConverter fontConverter = new FontConverter();
        if (Value.GetType() == typeof (string))
          FI.SetValue(Obj, (object) buStatics.StringToFont(Value.ToString()));
        if (Value.GetType() == typeof (Font))
          FI.SetValue(Obj, Value);
      }
      if (FI.FieldType == typeof (DateTime))
        FI.SetValue(Obj, (object) buStatics.StringToDateTime(Value.ToString()));
      if (FI.FieldType == typeof (Pnt2D))
      {
        Pnt2D pnt2D1 = new Pnt2D();
        Pnt2D pnt2D2 = Pnt2D.DecodeFromString(((Pnt2D) Value).ToDef());
        FI.SetValue(Obj, (object) pnt2D2);
      }
      if (FI.FieldType == typeof (Pnt3D))
      {
        Pnt3D pnt3D1 = new Pnt3D();
        Pnt3D pnt3D2 = Pnt3D.DecodeFromString(Value.ToString());
        FI.SetValue(Obj, (object) pnt3D2);
      }
      if (FI.FieldType == typeof (Plane))
      {
        if (Value.GetType() == typeof (Plane))
        {
          Plane plane1 = new Plane();
          Plane plane2 = (Plane) ((Plane) Value).Clone();
          FI.SetValue(Obj, (object) plane2);
        }
        else
        {
          Plane plane3 = new Plane();
          Plane plane4 = buSerilization5.DecoderFromPlane(Convert.ToString(Value));
          FI.SetValue(Obj, (object) plane4);
        }
      }
      if (FI.FieldType == typeof (Point3D))
      {
        Point3D point3D1 = new Point3D();
        Point3D point3D2 = F_AnalyseResult.Point3DDecodeFromString(Convert.ToString(Value));
        FI.SetValue(Obj, (object) point3D2);
      }
      if (FI.FieldType == typeof (Vector3D))
      {
        Vector3D vector3D1 = new Vector3D();
        Vector3D vector3D2 = F_AnalyseResult.Vector3DDecodeFromString(Convert.ToString(Value));
        FI.SetValue(Obj, (object) vector3D2);
      }
      if (FI.FieldType == typeof (Pnt6D))
      {
        Pnt6D pnt6D1 = new Pnt6D();
        Pnt6D pnt6D2 = Pnt6D.DecodeFromString(Value.ToString());
        FI.SetValue(Obj, (object) pnt6D2);
      }
      if (FI.FieldType == typeof (Pnt9D))
      {
        Pnt9D pnt9D1 = new Pnt9D();
        Pnt9D pnt9D2 = Pnt9D.DecodeFromString(((Pnt9D) Value).ToDef());
        FI.SetValue(Obj, (object) pnt9D2);
      }
      if (FI.FieldType == typeof (Vec3D))
      {
        Vec3D vec3D1 = new Vec3D();
        Vec3D vec3D2 = Vec3D.DecodeFromString(Value.ToString());
        FI.SetValue(Obj, (object) vec3D2);
      }
      if (FI.FieldType == typeof (Length3D))
      {
        Length3D length3D1 = new Length3D();
        Length3D length3D2 = Length3D.DecodeFromString(((Length3D) Value).ToDef());
        FI.SetValue(Obj, (object) length3D2);
      }
      if (FI.FieldType == typeof (OrientationAngle))
      {
        OrientationAngle orientationAngle1 = new OrientationAngle();
        if (Value.GetType() == typeof (string))
        {
          FI.SetValue(Obj, (object) orientationAngle1);
        }
        else
        {
          OrientationAngle orientationAngle2 = OrientationAngle.DecodeFromString(((OrientationAngle) Value).ToDef());
          FI.SetValue(Obj, (object) orientationAngle2);
        }
      }
      if (FI.FieldType == typeof (Line3D))
      {
        Line3D line3D1 = new Line3D();
        Line3D line3D2 = Line3D.DecodeFromString(((Line3D) Value).ToDef());
        FI.SetValue(Obj, (object) line3D2);
      }
      if (FI.FieldType == typeof (Triangle3D))
      {
        Triangle3D triangle3D1 = new Triangle3D();
        Triangle3D triangle3D2 = Triangle3D.DecodeFromString(((Triangle3D) Value).ToDef());
        FI.SetValue(Obj, (object) triangle3D2);
      }
      if (FI.FieldType == typeof (Quad3D))
      {
        Quad3D quad3D1 = new Quad3D();
        Quad3D quad3D2 = Quad3D.DecodeFromString(((Quad3D) Value).ToDef());
        FI.SetValue(Obj, (object) quad3D2);
      }
      if (FI.FieldType == typeof (object))
      {
        object obj1 = new object();
        object obj2 = Value;
        FI.SetValue(Obj, obj2);
      }
      if (FI.FieldType == typeof (ArrayList))
      {
        ArrayList arrayList = new ArrayList();
        if (Value.GetType() == typeof (ArrayList))
          arrayList.AddRange((ICollection) ((ArrayList) Value).ToArray());
        FI.SetValue(Obj, (object) arrayList);
      }
      if (FI.FieldType == typeof (List<double>))
      {
        List<double> doubleList = new List<double>();
        if (Value.GetType() == typeof (List<double>))
          doubleList.AddRange((IEnumerable<double>) ((List<double>) Value).ToArray());
        FI.SetValue(Obj, (object) doubleList);
      }
      if (FI.FieldType == typeof (List<int>))
      {
        List<int> intList = new List<int>();
        if (Value.GetType() == typeof (List<int>))
          intList.AddRange((IEnumerable<int>) ((List<int>) Value).ToArray());
        FI.SetValue(Obj, (object) intList);
      }
      if (FI.FieldType == typeof (List<float>))
      {
        List<float> floatList = new List<float>();
        if (Value.GetType() == typeof (List<float>))
          floatList.AddRange((IEnumerable<float>) ((List<float>) Value).ToArray());
        FI.SetValue(Obj, (object) floatList);
      }
      if (FI.FieldType == typeof (List<bool>))
      {
        List<bool> boolList = new List<bool>();
        if (Value.GetType() == typeof (List<bool>))
          boolList.AddRange((IEnumerable<bool>) ((List<bool>) Value).ToArray());
        FI.SetValue(Obj, (object) boolList);
      }
      if (FI.FieldType == typeof (List<string>))
      {
        List<string> stringList = new List<string>();
        if (Value.GetType() == typeof (List<string>))
          stringList.AddRange((IEnumerable<string>) ((List<string>) Value).ToArray());
        FI.SetValue(Obj, (object) stringList);
      }
      if (FI.FieldType == typeof (List<Pnt2D>))
      {
        List<Pnt2D> pnt2DList = new List<Pnt2D>();
        if (Value.GetType() == typeof (List<Pnt2D>))
          pnt2DList.AddRange((IEnumerable<Pnt2D>) ((List<Pnt2D>) Value).ToArray());
        FI.SetValue(Obj, (object) pnt2DList);
      }
      if (FI.FieldType == typeof (List<Pnt3D>))
      {
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        if (Value.GetType() == typeof (List<Pnt3D>))
          pnt3DList.AddRange((IEnumerable<Pnt3D>) ((List<Pnt3D>) Value).ToArray());
        FI.SetValue(Obj, (object) pnt3DList);
      }
      if (FI.FieldType == typeof (List<Point3D>))
      {
        List<Point3D> point3DList = new List<Point3D>();
        if (Value.GetType() == typeof (List<Point3D>))
          point3DList.AddRange((IEnumerable<Point3D>) ((List<Point3D>) Value).ToArray());
        FI.SetValue(Obj, (object) point3DList);
      }
      if (FI.FieldType == typeof (List<Pnt6D>))
      {
        List<Pnt6D> pnt6DList = new List<Pnt6D>();
        if (Value.GetType() == typeof (List<Pnt6D>))
          pnt6DList.AddRange((IEnumerable<Pnt6D>) ((List<Pnt6D>) Value).ToArray());
        FI.SetValue(Obj, (object) pnt6DList);
      }
      if (FI.FieldType == typeof (List<Pnt9D>))
      {
        List<Pnt9D> pnt9DList = new List<Pnt9D>();
        if (Value.GetType() == typeof (List<Pnt9D>))
          pnt9DList.AddRange((IEnumerable<Pnt9D>) ((List<Pnt9D>) Value).ToArray());
        FI.SetValue(Obj, (object) pnt9DList);
      }
      if (FI.FieldType == typeof (List<Vec3D>))
      {
        List<Vec3D> vec3DList = new List<Vec3D>();
        if (Value.GetType() == typeof (List<Vec3D>))
          vec3DList.AddRange((IEnumerable<Vec3D>) ((List<Vec3D>) Value).ToArray());
        FI.SetValue(Obj, (object) vec3DList);
      }
      if (FI.FieldType == typeof (List<OrientationAngle>))
      {
        List<OrientationAngle> orientationAngleList = new List<OrientationAngle>();
        if (Value.GetType() == typeof (List<OrientationAngle>))
          orientationAngleList.AddRange((IEnumerable<OrientationAngle>) ((List<OrientationAngle>) Value).ToArray());
        FI.SetValue(Obj, (object) orientationAngleList);
      }
      if (FI.FieldType == typeof (List<Line3D>))
      {
        List<Line3D> line3DList = new List<Line3D>();
        if (Value.GetType() == typeof (List<Line3D>))
          line3DList.AddRange((IEnumerable<Line3D>) ((List<Line3D>) Value).ToArray());
        FI.SetValue(Obj, (object) line3DList);
      }
      if (FI.FieldType == typeof (List<Triangle3D>))
      {
        List<Triangle3D> triangle3DList = new List<Triangle3D>();
        if (Value.GetType() == typeof (List<Triangle3D>))
          triangle3DList.AddRange((IEnumerable<Triangle3D>) ((List<Triangle3D>) Value).ToArray());
        FI.SetValue(Obj, (object) triangle3DList);
      }
      if (FI.FieldType == typeof (List<Quad3D>))
      {
        List<Quad3D> quad3DList = new List<Quad3D>();
        if (Value.GetType() == typeof (List<Quad3D>))
          quad3DList.AddRange((IEnumerable<Quad3D>) ((List<Quad3D>) Value).ToArray());
        FI.SetValue(Obj, (object) quad3DList);
      }
      if (FI.FieldType == typeof (List<List<Pnt3D>>))
      {
        List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
        if (Value.GetType() == typeof (List<List<Pnt3D>>))
        {
          for (int index = 0; index <= ((List<List<Pnt3D>>) Value).Count - 1; ++index)
          {
            List<Pnt3D> pnt3DList = new List<Pnt3D>();
            pnt3DList.AddRange((IEnumerable<Pnt3D>) ((List<List<Pnt3D>>) Value)[index].ToArray());
            pnt3DListList.Add(pnt3DList);
          }
          FI.SetValue(Obj, (object) pnt3DListList);
        }
      }
      if (FI.FieldType == typeof (List<List<Point3D>>))
      {
        List<List<Point3D>> point3DListList = new List<List<Point3D>>();
        if (Value.GetType() == typeof (List<List<Point3D>>))
        {
          for (int index = 0; index <= ((List<List<Point3D>>) Value).Count - 1; ++index)
          {
            List<Point3D> point3DList = new List<Point3D>();
            point3DList.AddRange((IEnumerable<Point3D>) ((List<List<Point3D>>) Value)[index].ToArray());
            point3DListList.Add(point3DList);
          }
          FI.SetValue(Obj, (object) point3DListList);
        }
      }
      if (FI.FieldType == typeof (double[]))
      {
        try
        {
          double[] numArray = new double[((double[]) Value).Length];
          if (Value.GetType() == typeof (double[]))
          {
            for (int index = 0; index <= ((double[]) Value).Length - 1; ++index)
              numArray[index] = ((double[]) Value)[index];
          }
          FI.SetValue(Obj, (object) numArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (float[]))
      {
        if (Value != null)
        {
          try
          {
            float[] numArray = new float[((float[]) Value).Length];
            if (Value.GetType() == typeof (float[]))
            {
              for (int index = 0; index <= ((float[]) Value).Length - 1; ++index)
                numArray[index] = ((float[]) Value)[index];
            }
            FI.SetValue(Obj, (object) numArray);
          }
          catch (Exception ex)
          {
          }
        }
      }
      if (FI.FieldType == typeof (int[]))
      {
        try
        {
          int[] numArray = new int[((int[]) Value).Length];
          if (Value.GetType() == typeof (int[]))
          {
            for (int index = 0; index <= ((int[]) Value).Length - 1; ++index)
              numArray[index] = ((int[]) Value)[index];
          }
          FI.SetValue(Obj, (object) numArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (bool[]))
      {
        try
        {
          bool[] flagArray = new bool[((bool[]) Value).Length];
          if (Value.GetType() == typeof (bool[]))
          {
            for (int index = 0; index <= ((bool[]) Value).Length - 1; ++index)
              flagArray[index] = ((bool[]) Value)[index];
          }
          FI.SetValue(Obj, (object) flagArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (string[]))
      {
        try
        {
          string[] strArray = new string[((string[]) Value).Length];
          if (Value.GetType() == typeof (string[]))
          {
            for (int index = 0; index <= ((string[]) Value).Length - 1; ++index)
              strArray[index] = ((string[]) Value)[index];
          }
          FI.SetValue(Obj, (object) strArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Pnt2D[]))
      {
        try
        {
          Pnt2D[] pnt2DArray = new Pnt2D[((Pnt2D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt2D[]))
          {
            for (int index = 0; index <= ((Pnt2D[]) Value).Length - 1; ++index)
              pnt2DArray[index] = ((Pnt2D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) pnt2DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Point3D[]))
      {
        try
        {
          Point3D[] point3DArray = new Point3D[((Point3D[]) Value).Length];
          if (Value.GetType() == typeof (Point3D[]))
          {
            for (int index = 0; index <= ((Point3D[]) Value).Length - 1; ++index)
              point3DArray[index] = ((Point3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) point3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Pnt6D[]))
      {
        try
        {
          Pnt6D[] pnt6DArray = new Pnt6D[((Pnt6D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt6D[]))
          {
            for (int index = 0; index <= ((Pnt6D[]) Value).Length - 1; ++index)
              pnt6DArray[index] = ((Pnt6D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) pnt6DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Pnt9D[]))
      {
        try
        {
          Pnt9D[] pnt9DArray = new Pnt9D[((Pnt9D[]) Value).Length];
          if (Value.GetType() == typeof (Pnt9D[]))
          {
            for (int index = 0; index <= ((Pnt9D[]) Value).Length - 1; ++index)
              pnt9DArray[index] = ((Pnt9D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) pnt9DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Vec3D[]))
      {
        try
        {
          Vec3D[] vec3DArray = new Vec3D[((Vec3D[]) Value).Length];
          if (Value.GetType() == typeof (Vec3D[]))
          {
            for (int index = 0; index <= ((Vec3D[]) Value).Length - 1; ++index)
              vec3DArray[index] = ((Vec3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) vec3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (OrientationAngle[]))
      {
        try
        {
          OrientationAngle[] orientationAngleArray = new OrientationAngle[((OrientationAngle[]) Value).Length];
          if (Value.GetType() == typeof (OrientationAngle[]))
          {
            for (int index = 0; index <= ((OrientationAngle[]) Value).Length - 1; ++index)
              orientationAngleArray[index] = ((OrientationAngle[]) Value)[index];
          }
          FI.SetValue(Obj, (object) orientationAngleArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Line3D[]))
      {
        try
        {
          Line3D[] line3DArray = new Line3D[((Line3D[]) Value).Length];
          if (Value.GetType() == typeof (Line3D[]))
          {
            for (int index = 0; index <= ((Line3D[]) Value).Length - 1; ++index)
              line3DArray[index] = ((Line3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) line3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (FI.FieldType == typeof (Triangle3D[]))
      {
        try
        {
          Triangle3D[] triangle3DArray = new Triangle3D[((Triangle3D[]) Value).Length];
          if (Value.GetType() == typeof (Triangle3D[]))
          {
            for (int index = 0; index <= ((Triangle3D[]) Value).Length - 1; ++index)
              triangle3DArray[index] = ((Triangle3D[]) Value)[index];
          }
          FI.SetValue(Obj, (object) triangle3DArray);
        }
        catch (Exception ex)
        {
        }
      }
      if (!(FI.FieldType == typeof (Quad3D[])))
        return;
      try
      {
        Quad3D[] quad3DArray = new Quad3D[((Quad3D[]) Value).Length];
        if (Value.GetType() == typeof (Quad3D[]))
        {
          for (int index = 0; index <= ((Quad3D[]) Value).Length - 1; ++index)
            quad3DArray[index] = ((Quad3D[]) Value)[index];
        }
        FI.SetValue(Obj, (object) quad3DArray);
      }
      catch (Exception ex)
      {
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetClassVariableValuesFromStringCodes(
    string Code,
    object RefObject,
    ref List<cParameter5> Vars)
  {
    try
    {
      string[] strArray1 = Code.Split(';');
      if (strArray1 == null)
        return;
      Vars = new List<cParameter5>();
      buSerilization5.GetClassVariables(RefObject, ref Vars);
      for (int index1 = 0; index1 <= Vars.Count - 1; ++index1)
      {
        bool flag = false;
        string str1 = "";
        for (int index2 = 0; index2 <= strArray1.Length - 1; ++index2)
        {
          string[] strArray2 = strArray1[index2].Split('=');
          if (strArray2 != null)
          {
            if (strArray2.Length == 2 && strArray2[0].ToString().Trim() == ((EditorRuntimeSettings) Vars[index1]).Name.ToString().Trim())
            {
              str1 = strArray2[1].Trim();
              flag = true;
              index2 = strArray1.Length + 1;
            }
            if (strArray2.Length > 2 && strArray2[0].ToString().Trim() == ((EditorRuntimeSettings) Vars[index1]).Name.ToString().Trim())
            {
              string str2 = "";
              for (int index3 = 1; index3 <= strArray2.Length - 1; ++index3)
              {
                string str3 = strArray2[index3].Trim();
                if (index3 > 1)
                  str3 = "=" + str3;
                if (str3.Length == 0)
                  str3 = "=";
                str2 += str3;
              }
              str1 = str2;
              flag = true;
              index2 = strArray1.Length + 1;
            }
          }
        }
        if (flag)
          ((EditorRuntimeSettings) Vars[index1]).Value = (object) str1;
        else
          ((EditorRuntimeSettings) Vars[index1]).Value = (object) "0";
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetClassVariableValuesFromStringCodes(
    ArrayList Codes,
    object RefObject,
    ref List<cParameter5> Vars)
  {
    try
    {
      List<string> Codes1 = new List<string>();
      for (int index = 0; index <= Codes.Count - 1; ++index)
        Codes1.Add(Codes[index].ToString());
      buSerilization5.GetClassVariableValuesFromStringCodes(Codes1, RefObject, ref Vars);
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetSubClassVariableValuesFromStringCodes(
    List<string> Codes,
    ref object RefObject,
    ref List<cParameter5> Vars)
  {
    try
    {
      List<string> RefList = new List<string>();
      for (int index1 = 0; index1 <= Codes.Count - 1; ++index1)
      {
        string[] strArray = Codes[index1].Split(new string[2]
        {
          "\r\n",
          "\n"
        }, StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
            RefList.Add(strArray[index2]);
        }
      }
      if (RefList.Count <= 0)
        return;
      Vars = new List<cParameter5>();
      buSerilization5.GetClassVariables(RefObject, ref Vars);
      for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
      {
        if (Vars[index3] != null)
        {
          Type type = ((EditorRuntimeSettings) Vars[index3]).Value.GetType();
          string str1 = ((EditorRuntimeSettings) Vars[index3]).Name.ToString().Trim();
          bool flag1 = false;
          bool flag2 = false;
          string str2 = "";
          ArrayList arrayList = new ArrayList();
          if (index3 == 25)
            ;
          if ((type.IsClass | type.IsValueType & !type.IsEnum) & !type.IsArray)
          {
            string str3 = "";
            if (type.BaseType != (Type) null && type.BaseType.BaseType != (Type) null)
              str3 = type.BaseType.BaseType.Namespace;
            if (type.BaseType != (Type) null && type.Namespace == "buClass" | type.BaseType.Namespace == "buClass" | str3 == "buClass" | type.Namespace == "buEyeBaseVer5" | type.BaseType.Namespace == "buEyeBaseVer5" | str3 == "buEyeBaseVer5" | type.Namespace == "buMW" | type.BaseType.Namespace == "buMW" | str3 == "buMW")
            {
              List<string> CalcList = new List<string>();
              List<cParameter5> Vars1 = new List<cParameter5>();
              buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
              buSerilization5.GetSubClassVariableValuesFromStringCodes(CalcList, ref ((EditorRuntimeSettings) Vars[index3]).Value, ref Vars1);
              ((EditorRuntimeSettings) Vars[index3]).SubParameter = (object) Vars1;
              object ObjPar = ((EditorRuntimeSettings) Vars[index3]).Field.GetValue(RefObject);
              buSerilization5.SetClassVariables(ref ObjPar, Vars1);
              ((EditorRuntimeSettings) Vars[index3]).Value = ObjPar;
              flag2 = true;
              flag1 = true;
            }
          }
          if (type.IsArray)
          {
            ArrayList CalcList = new ArrayList();
            List<cParameter5> cParameter5List = new List<cParameter5>();
            buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
            \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(ref ((EditorRuntimeSettings) Vars[index3]).Value, CalcList);
            flag2 = true;
            flag1 = true;
          }
          if (!type.IsArray && ((EditorRuntimeSettings) Vars[index3]).Types.Name.IndexOf("List`1") >= 0)
          {
            ArrayList CalcList = new ArrayList();
            List<cParameter5> cParameter5List = new List<cParameter5>();
            buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
            \u0007.\u0001.\u0001(CalcList, ref ((EditorRuntimeSettings) Vars[index3]).Value);
            flag2 = true;
            flag1 = true;
          }
          if (!type.IsArray && ((EditorRuntimeSettings) Vars[index3]).Types.Name.IndexOf("ArrayList") >= 0)
          {
            ArrayList CalcList = new ArrayList();
            List<cParameter5> cParameter5List = new List<cParameter5>();
            buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
            \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(CalcList, ref ((EditorRuntimeSettings) Vars[index3]).Value);
            flag2 = true;
            flag1 = true;
          }
          if (!flag2)
          {
            for (int index4 = 0; index4 <= RefList.Count - 1; ++index4)
            {
              string str4 = "";
              string str5 = "";
              if (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(ref str4, ref str5, RefList[index4]))
              {
                string str6 = RefObject.GetType().Name + ".";
                if (str5.Trim() == str1 | str5.Trim() == str6 + str1)
                {
                  str2 = str4.Trim();
                  flag1 = true;
                  index4 = RefList.Count + 1;
                }
              }
            }
          }
          if (flag1 && !flag2)
            ((EditorRuntimeSettings) Vars[index3]).Value = (object) str2;
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetClassVariableValuesFromStringCodes(
    List<string> Codes,
    object RefObject,
    ref List<cParameter5> Vars)
  {
    try
    {
      List<string> RefList = new List<string>();
      for (int index1 = 0; index1 <= Codes.Count - 1; ++index1)
      {
        string[] strArray = Codes[index1].Split(new string[2]
        {
          "\r\n",
          "\n"
        }, StringSplitOptions.None);
        if (strArray != null)
        {
          for (int index2 = 0; index2 <= strArray.Length - 1; ++index2)
            RefList.Add(strArray[index2]);
        }
      }
      if (RefList.Count <= 0)
        return;
      Vars = new List<cParameter5>();
      buSerilization5.GetClassVariables(RefObject, ref Vars);
      for (int index3 = 0; index3 <= Vars.Count - 1; ++index3)
      {
        if (Vars[index3] != null)
        {
          Type type = ((EditorRuntimeSettings) Vars[index3]).Value.GetType();
          string str1 = ((EditorRuntimeSettings) Vars[index3]).Name.ToString().Trim();
          bool flag1 = false;
          bool flag2 = false;
          string str2 = "";
          ArrayList arrayList = new ArrayList();
          if (index3 == 55)
            ;
          if ((type.IsClass | type.IsValueType & !type.IsEnum) & !type.IsArray && type.Namespace == "buClass" | type.BaseType.Namespace == "buClass" | type.Namespace == "buEyeBaseVer5" | type.BaseType.Namespace == "buEyeBaseVer5" | type.Namespace == "buMW" | type.BaseType.Namespace == "buMW")
          {
            List<string> CalcList = new List<string>();
            List<cParameter5> Vars1 = new List<cParameter5>();
            buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
            buSerilization5.GetSubClassVariableValuesFromStringCodes(CalcList, ref ((EditorRuntimeSettings) Vars[index3]).Value, ref Vars1);
            if (Vars1.Count == 0 && (List<cParameter5>) ((EditorRuntimeSettings) Vars[index3]).SubParameter != null)
            {
              for (int index4 = 0; index4 <= ((List<cParameter5>) ((EditorRuntimeSettings) Vars[index3]).SubParameter).Count - 1; ++index4)
                Vars1.Add(((List<cParameter5>) ((EditorRuntimeSettings) Vars[index3]).SubParameter)[index4]);
            }
            ((EditorRuntimeSettings) Vars[index3]).SubParameter = (object) Vars1;
            if (Vars1.Count > 0)
            {
              object ObjPar = ((EditorRuntimeSettings) Vars[index3]).Field.GetValue(RefObject);
              buSerilization5.SetClassVariables(ref ObjPar, Vars1);
              ((EditorRuntimeSettings) Vars[index3]).Value = ObjPar;
              flag1 = true;
            }
            flag2 = true;
          }
          if (type.IsArray)
          {
            ArrayList CalcList = new ArrayList();
            List<cParameter5> cParameter5List = new List<cParameter5>();
            buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
            \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(ref ((EditorRuntimeSettings) Vars[index3]).Value, CalcList);
            flag2 = true;
            flag1 = true;
          }
          if (!type.IsArray && ((EditorRuntimeSettings) Vars[index3]).Types.FullName.IndexOf("Generic.List") >= 0)
          {
            string[] strArray = ((EditorRuntimeSettings) Vars[index3]).Types.FullName.Split(new string[1]
            {
              "Generic.List"
            }, StringSplitOptions.None);
            ArrayList CalcList = new ArrayList();
            List<cParameter5> cParameter5List = new List<cParameter5>();
            if (strArray.Length == 2)
            {
              buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
              \u0007.\u0001.\u0001(CalcList, ref ((EditorRuntimeSettings) Vars[index3]).Value);
              flag2 = true;
              flag1 = true;
            }
            if (strArray.Length == 3)
            {
              buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
              \u0007.\u0001.\u0001(CalcList, ref ((EditorRuntimeSettings) Vars[index3]).Value, str1);
              flag2 = true;
              flag1 = true;
            }
          }
          if (!type.IsArray && ((EditorRuntimeSettings) Vars[index3]).Types.Name.IndexOf("ArrayList") >= 0)
          {
            ArrayList CalcList = new ArrayList();
            List<cParameter5> cParameter5List = new List<cParameter5>();
            buStatics.ListToSpecificList($"<{str1}>", $"</{str1}>", RefList, ref CalcList);
            \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(CalcList, ref ((EditorRuntimeSettings) Vars[index3]).Value);
            flag2 = true;
            flag1 = true;
          }
          if (!flag2)
          {
            for (int index5 = 0; index5 <= RefList.Count - 1; ++index5)
            {
              string str3 = "";
              string str4 = "";
              if (\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(ref str3, ref str4, RefList[index5]))
              {
                string str5 = RefObject.GetType().Name + ".";
                if (str4.Trim() == str1 | str4.Trim() == str5 + str1)
                {
                  str2 = str3.Trim();
                  flag1 = true;
                  index5 = RefList.Count + 1;
                }
              }
            }
          }
          if (flag1 && !flag2)
            ((EditorRuntimeSettings) Vars[index3]).Value = (object) str2;
        }
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal ArrayList \u0001([In] string obj0, [In] object obj1, [In] int obj2)
  {
    try
    {
      string str1 = new string(' ', obj2);
      ArrayList arrayList = new ArrayList();
      if (obj1 == null)
        return arrayList;
      obj1.GetType().ToString();
      Type type = obj1.GetType();
      if (type == typeof (List<double>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str2 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<double>) obj1).Count - 1; ++index)
        {
          double num = ((List<double>) obj1)[index];
          arrayList.Add((object) $"{str2}{obj0} = {num.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<int>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str3 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<int>) obj1).Count - 1; ++index)
        {
          int num = ((List<int>) obj1)[index];
          arrayList.Add((object) $"{str3}{obj0} = {num.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<float>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str4 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<float>) obj1).Count - 1; ++index)
        {
          float num = ((List<float>) obj1)[index];
          arrayList.Add((object) $"{str4}{obj0} = {num.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<bool>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str5 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<bool>) obj1).Count - 1; ++index)
        {
          bool flag = ((List<bool>) obj1)[index];
          arrayList.Add((object) $"{str5}{obj0} = {flag.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<string>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str6 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<string>) obj1).Count - 1; ++index)
        {
          string str7 = ((List<string>) obj1)[index];
          arrayList.Add((object) $"{str6}{obj0} = {str7.ToString()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Pnt2D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str8 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Pnt2D>) obj1).Count - 1; ++index)
        {
          Pnt2D pnt2D1 = new Pnt2D();
          Pnt2D pnt2D2 = ((List<Pnt2D>) obj1)[index];
          arrayList.Add((object) $"{str8}{obj0} = {pnt2D2.ToDef()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Pnt3D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str9 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Pnt3D>) obj1).Count - 1; ++index)
        {
          Pnt3D pnt3D1 = new Pnt3D();
          Pnt3D pnt3D2 = ((List<Pnt3D>) obj1)[index];
          arrayList.Add((object) $"{str9}{obj0} = {pnt3D2.ToDef()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Point3D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str10 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Point3D>) obj1).Count - 1; ++index)
        {
          Point3D point3D = new Point3D();
          Point3D Pnt = ((List<Point3D>) obj1)[index];
          arrayList.Add((object) $"{str10}{obj0} = {F_AnalyseResult.Point3DToDef(Pnt)}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Pnt6D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str11 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Pnt6D>) obj1).Count - 1; ++index)
        {
          Pnt6D pnt6D1 = new Pnt6D();
          Pnt6D pnt6D2 = ((List<Pnt6D>) obj1)[index];
          arrayList.Add((object) $"{str11}{obj0} = {pnt6D2.ToDef()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Pnt9D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str12 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Pnt9D>) obj1).Count - 1; ++index)
        {
          Pnt9D pnt9D1 = new Pnt9D();
          Pnt9D pnt9D2 = ((List<Pnt9D>) obj1)[index];
          arrayList.Add((object) $"{str12}{obj0} = {pnt9D2.ToDef()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Vec3D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str13 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Vec3D>) obj1).Count - 1; ++index)
        {
          Vec3D vec3D1 = new Vec3D();
          Vec3D vec3D2 = ((List<Vec3D>) obj1)[index];
          arrayList.Add((object) $"{str13}{obj0} = {vec3D2.ToDef()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<OrientationAngle>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str14 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<OrientationAngle>) obj1).Count - 1; ++index)
        {
          OrientationAngle orientationAngle1 = new OrientationAngle();
          OrientationAngle orientationAngle2 = ((List<OrientationAngle>) obj1)[index];
          arrayList.Add((object) $"{str14}{obj0} = {orientationAngle2.ToDef()}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Line3D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str15 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Line3D>) obj1).Count - 1; ++index)
        {
          Line3D line3D1 = new Line3D();
          Line3D line3D2 = ((List<Line3D>) obj1)[index];
          arrayList.Add((object) $"{str15}{obj0} = {line3D2.ToDef(2)}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Triangle3D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str16 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Triangle3D>) obj1).Count - 1; ++index)
        {
          Triangle3D triangle3D1 = new Triangle3D();
          Triangle3D triangle3D2 = ((List<Triangle3D>) obj1)[index];
          arrayList.Add((object) $"{str16}{obj0} = {triangle3D2.ToDef(2)}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      if (type == typeof (List<Quad3D>))
      {
        arrayList.Add((object) $"{str1}<{obj0}>");
        string str17 = new string(' ', obj2 + 2);
        for (int index = 0; index <= ((List<Quad3D>) obj1).Count - 1; ++index)
        {
          Quad3D quad3D1 = new Quad3D();
          Quad3D quad3D2 = ((List<Quad3D>) obj1)[index];
          arrayList.Add((object) $"{str17}{obj0} = {quad3D2.ToDef(2)}");
        }
        arrayList.Add((object) $"{str1}</{obj0}>");
      }
      return arrayList;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new ArrayList();
    }
  }
}
