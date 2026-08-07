// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.screenInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class screenInfo : buSerilization5
{
  public static List<string> ExceptionalVariables = new List<string>();
  public static byte f000113;
  public Point3D EntitiesBoxSize = new Point3D();
  public Point3D pntMin;
}
