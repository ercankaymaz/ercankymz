// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.RobotToolPath
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class RobotToolPath : buSerilization5
{
  public const MarbleCamAreaMode Region = ; // Unable to render the field
  [SpecialName]
  public int value__;

  static RobotToolPath() => marbleMatrialCleanPars.Captions = new List<string>();

  public RobotToolPath()
  {
    ((marbleMatrialCleanPars) this).colorDataFocus = Color.LightGreen;
    ((marbleMatrialCleanPars) this).colorAxesDisable = Color.Red;
    ((marbleMatrialCleanPars) this).colorAxesNoHoming = Color.DarkOrange;
    ((marbleMatrialCleanPars) this).colorCoordinateColor = Color.Black;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public RobotToolPath(MarbleControlColorSettings data)
  {
    ((marbleMatrialCleanPars) this).colorDataFocus = Color.LightGreen;
    ((marbleMatrialCleanPars) this).colorAxesDisable = Color.Red;
    ((marbleMatrialCleanPars) this).colorAxesNoHoming = Color.DarkOrange;
    ((marbleMatrialCleanPars) this).colorCoordinateColor = Color.Black;
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
}
