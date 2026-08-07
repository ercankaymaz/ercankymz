// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ToolDisplay5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ToolDisplay5 : buSerilization5
{
  public double UpperRadius;
  public double UpperDiameter;
  public double ProfileRadius;
  public double OutsideDiameter;
  public double ProfileDiameter;
  public double MaxDiameter;
  public double FlatnessDiameter;
  public double ConvexTipRadius;
  public double Thickness;
  public double MinLength;
  public double SizeWidth;
  public double SizeDepth;
  public double SizeHeight;

  public static void MmToInch(ref List<ToolBase5> Tools)
  {
    for (int index = 0; index <= Tools.Count - 1; ++index)
      ((ToolData5) Tools[index]).MmToInch();
  }

  public static void InchToMm(ref List<ToolBase5> Tools)
  {
    for (int index = 0; index <= Tools.Count - 1; ++index)
      ((ToolData5) Tools[index]).InchToMm();
  }

  public static void SaveToolHolder(ToolBase5 Tool, string FileName)
  {
    List<string> StringList = new List<string>();
    StringList.Add("<ToolHolder>");
    if (((ToolCamData5) ((ToolGeometry5) Tool).Geometry).HolderPoints.Count > 0)
    {
      for (int index = 0; index <= ((ToolCamData5) ((ToolGeometry5) Tool).Geometry).HolderPoints.Count - 1; ++index)
        StringList.Add("  " + ((ToolCamData5) ((ToolGeometry5) Tool).Geometry).HolderPoints[index].ToDef());
    }
    StringList.Add("</ToolHolder>");
    StringList.Add("<ToolArbor>");
    if (((ToolCamData5) ((ToolGeometry5) Tool).Geometry).ArborPoints.Count > 0)
    {
      for (int index = 0; index <= ((ToolCamData5) ((ToolGeometry5) Tool).Geometry).ArborPoints.Count - 1; ++index)
        StringList.Add("  " + ((ToolCamData5) ((ToolGeometry5) Tool).Geometry).ArborPoints[index].ToDef());
    }
    StringList.Add("</ToolArbor>");
    if (FileName.Length >= 2)
      buVector5.SaveToFile(StringList, FileName);
    StringList.Clear();
  }

  public static void OpenToolHolder(ref ToolBase5 Tool, string FileName)
  {
    if (FileName.Length < 2 || !new FileInfo(FileName).Exists)
      return;
    List<string> StringList = new List<string>();
    List<string> CalcList = new List<string>();
    buVector5.OpenFromFile(FileName, ref StringList);
    ((ToolCamData5) ((ToolGeometry5) Tool).Geometry).HolderPoints.Clear();
    ((ToolCamData5) ((ToolGeometry5) Tool).Geometry).ArborPoints.Clear();
    buImage5.ListToSpecificList("<ToolHolder>", "</ToolHolder>", false, StringList, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
      ((ToolCamData5) ((ToolGeometry5) Tool).Geometry).HolderPoints.Add(Pnt3D.DecodeFromString(CalcList[index]));
    CalcList.Clear();
    buImage5.ListToSpecificList("<ToolArbor>", "</ToolArbor>", false, StringList, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
      ((ToolCamData5) ((ToolGeometry5) Tool).Geometry).ArborPoints.Add(Pnt3D.DecodeFromString(CalcList[index]));
    CalcList.Clear();
    StringList.Clear();
  }
}
