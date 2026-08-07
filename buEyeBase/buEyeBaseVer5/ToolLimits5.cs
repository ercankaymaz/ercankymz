// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ToolLimits5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ToolLimits5 : buSerilization5
{
  public int GroupItemIndex;
  public int HeadNumber;
  public static byte f00041E;
  public double DepthConstant;
  public int DepthSliceCount;
  public CamDepthType DepthType;
  public double Stepover;
  public double Cutover;
  public double OperationHeight;
  public double AreaClearanceSpeed;
  public double FinishSpeed;
  public double RetractSpeed;
  public double FeedSpeed;

  public static void Copy(List<ToolBase5> RefTools, ref List<ToolBase5> CopiedTools)
  {
    CopiedTools.Clear();
    for (int index = 0; index <= RefTools.Count - 1; ++index)
    {
      ToolBase5 CopiedTool = (ToolBase5) new ToolGeometry5();
      ToolCamData5.Copy(RefTools[index], ref CopiedTool);
      CopiedTools.Add(CopiedTool);
    }
  }

  public static List<ToolBase5> Copy(List<ToolBase5> RefTools)
  {
    List<ToolBase5> toolBase5List = new List<ToolBase5>();
    for (int index = 0; index <= RefTools.Count - 1; ++index)
    {
      ToolBase5 CopiedTool = (ToolBase5) new ToolGeometry5();
      ToolCamData5.Copy(RefTools[index], ref CopiedTool);
      toolBase5List.Add(CopiedTool);
    }
    return toolBase5List;
  }

  public override string ToString()
  {
    return $"{((ToolCamData5) ((ToolGeometry5) this).Data).Name} - No: {((ToolCamData5) ((ToolGeometry5) this).Data).No.ToString()} , Type: {((ToolData5) ((ToolGeometry5) this).Geometry).GeometryType.ToString()} , D: {((ToolGeometry5) this).Geometry.Diameter.ToString()} , L: {((ToolGeometry5) this).Geometry.Length.ToString()} , Thickness: {((ToolDisplay5) ((ToolGeometry5) this).Geometry).Thickness.ToString()}";
  }

  static ToolLimits5() => ToolGeometry5.Captions = new List<string>();
}
