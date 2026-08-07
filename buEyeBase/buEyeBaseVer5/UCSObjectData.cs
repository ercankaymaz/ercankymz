// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.UCSObjectData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class UCSObjectData : buSerilization5
{
  public double COffset;
  public double FOffset;
  public double SOffset;
  public double XMultiply;
  public double YMultiply;
  public double ZMultiply;
  public double AMultiply;
  public double BMultiply;
  public double CMultiply;

  public UCSObjectData(
    string action,
    double rad,
    double width,
    double height,
    double length,
    double angle)
  {
    ((GCodeChars5) this).Action = "";
    ((GCodeChars5) this).Radius = 0.0;
    ((GCodeChars5) this).HeadRadius = 0.0;
    ((GCodeChars5) this).MajorRadius = 0.0;
    ((GCodeChars5) this).MinorRadius = 0.0;
    ((GCodeChars5) this).Width = 0.0;
    ((GCodeChars5) this).Height = 0.0;
    ((GCodeGraphPoint5) this).Length = 0.0;
    ((GCodeGraphPoint5) this).Angle = 0.0;
    ((GCodeGraphPoint5) this).Side = 0;
    ((GCodeGraphPoint5) this).Point = new Pnt3D();
    ((GCodeResult5) this).SceneName = "";
    ((GCodeResult5) this).ActionName = "";
    ((GCodeSetting5) this).TextString = "";
    ((GCodeSetting5) this).TextFont = (Font) null;
    ((GCodeSetting5) this).FileName = Application.StartupPath;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((GCodeChars5) this).Action = action;
    ((GCodeChars5) this).Radius = rad;
    ((GCodeChars5) this).Width = width;
    ((GCodeChars5) this).Height = height;
    ((GCodeGraphPoint5) this).Length = length;
    ((GCodeGraphPoint5) this).Angle = angle;
  }

  public UCSObjectData(
    string action,
    double rad,
    double width,
    double height,
    double length,
    double angle,
    double majorrad,
    double minorrad,
    int side)
  {
    ((GCodeChars5) this).Action = "";
    ((GCodeChars5) this).Radius = 0.0;
    ((GCodeChars5) this).HeadRadius = 0.0;
    ((GCodeChars5) this).MajorRadius = 0.0;
    ((GCodeChars5) this).MinorRadius = 0.0;
    ((GCodeChars5) this).Width = 0.0;
    ((GCodeChars5) this).Height = 0.0;
    ((GCodeGraphPoint5) this).Length = 0.0;
    ((GCodeGraphPoint5) this).Angle = 0.0;
    ((GCodeGraphPoint5) this).Side = 0;
    ((GCodeGraphPoint5) this).Point = new Pnt3D();
    ((GCodeResult5) this).SceneName = "";
    ((GCodeResult5) this).ActionName = "";
    ((GCodeSetting5) this).TextString = "";
    ((GCodeSetting5) this).TextFont = (Font) null;
    ((GCodeSetting5) this).FileName = Application.StartupPath;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((GCodeChars5) this).Action = action;
    ((GCodeChars5) this).Radius = rad;
    ((GCodeChars5) this).Width = width;
    ((GCodeChars5) this).Height = height;
    ((GCodeGraphPoint5) this).Length = length;
    ((GCodeGraphPoint5) this).Angle = angle;
    ((GCodeGraphPoint5) this).Side = side;
    ((GCodeChars5) this).MajorRadius = majorrad;
    ((GCodeChars5) this).MinorRadius = minorrad;
  }

  public abstract void m00034D();
}
