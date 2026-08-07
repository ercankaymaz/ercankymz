// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleJob : buSerilization5
{
  public List<buEntity> OutterEntitites;
  public List<List<buEntity>> InnerEntities;
  public List<Point3D> OutterPoints;
  public List<List<Point3D>> InnerPoints;
  public bool SupportBlockEnable;
  public double SupportBlockZWidth;
  public double SupportBlockZHeight;
  public double SupportBlockZLength;
  public double SupportBlockY1FrontWidth;
  public double SupportBlockY1FrontHeight;
  public double SupportBlockY1FrontLength;
  public double SupportBlockY2BackWidth;
  public double SupportBlockY2BackHeight;
  public double SupportBlockY2BackLength;
  public bool ProfileMultiplyEnable;
  public bool ProfileMultiplyMirror;
  public double ProfileMultiplySpace;
  public int ProfileMultiplyCount;
  public static byte f0045CA;
  public static string strRectangle;
  public static string strCircle;
  public static string strEllipse;
  public static string strHole;
  public static string strKeyHole;

  public MarbleJob(ProfileOperationDataFreeDraw data)
  {
    ((NestingPanelNode) this).FreeDrawWidth = 0.0;
    ((NestingPanelNode) this).FreeDrawHeight = 0.0;
    ((NestingPanelNode) this).FreeDrawAngle = 0.0;
    ((NestingPanelNode) this).FreeDrawScaleCenter = ProfileScaleCenterType.Center;
    ((NestingPanelNode) this).FreeDrawColor = Color.Blue;
    ((NestingPanelNode) this).FreeDrawThickness = 1.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    return $"Width : {((NestingPanelNode) this).FreeDrawWidth.ToString()} - EllipseHeight : {((NestingPanelNode) this).FreeDrawHeight.ToString()}";
  }

  public static ArrayList ToDefPars(ProfileOperationDataFreeDraw P, string Char, int Space)
  {
    string str = "ProfileOperationDataFreeDrawPars";
    if (Char.Trim().Length > 0)
      str = Char;
    return new ArrayList()
    {
      (object) $"{buImage5.SpaceChar(Space)}<{str}",
      (object) (buImage5.SpaceChar(Space + 2) + MarbleJob.ToDefPars(P)),
      (object) $"{buImage5.SpaceChar(Space)}</{str}"
    };
  }

  public static ArrayList ToDefPars(ProfileOperationDataFreeDraw P, int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + "<ProfileOperationDataFreeDrawPars>"),
      (object) (buImage5.SpaceChar(Space + 2) + MarbleJob.ToDefPars(P)),
      (object) (buImage5.SpaceChar(Space) + "</ProfileOperationDataFreeDrawPars>")
    };
  }

  public static string ToDefPars(ProfileOperationDataFreeDraw P)
  {
    return buSerilization5.ClassToString((object) P);
  }
}
