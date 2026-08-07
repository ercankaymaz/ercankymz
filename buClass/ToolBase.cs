// Decompiled with JetBrains decompiler
// Type: buClass.ToolBase
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using buClass.Apps;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class ToolBase : buSerilization
{
  public ToolData Data = new ToolData();
  public ToolGeometry Geometry = new ToolGeometry();
  public ToolCamData CamData = new ToolCamData();
  public ToolDisplay Display = new ToolDisplay();
  public ToolPositions Positions = new ToolPositions();
  public ToolDiemaker Diemaker = new ToolDiemaker();
  public ToolLimits Limits = new ToolLimits();
  public ToolPurpose Purpose = ToolPurpose.General;
  public ArrayList Aux = new ArrayList();
  public static List<string> Captions = new List<string>();

  public ToolBase()
  {
  }

  public ToolBase(ToolBase tool)
  {
    this.Data = new ToolData(tool.Data);
    this.Geometry = new ToolGeometry(tool.Geometry);
    this.CamData = new ToolCamData(tool.CamData);
    this.Positions = new ToolPositions(tool.Positions);
    this.Display = new ToolDisplay(tool.Display);
    this.Diemaker = new ToolDiemaker(tool.Diemaker);
    this.Limits = new ToolLimits(tool.Limits);
    this.Purpose = tool.Purpose;
    this.Aux = new ArrayList();
    for (int index = 0; index <= tool.Aux.Count - 1; ++index)
      this.Aux.Add(tool.Aux[index]);
  }

  public static void Copy(ToolBase RefTools, ref ToolBase CopiedTool)
  {
    if (RefTools.GetType() == typeof (ToolBase))
      CopiedTool = new ToolBase(RefTools);
    if (RefTools.GetType() == typeof (BendingPunchTool))
      CopiedTool = (ToolBase) new BendingPunchTool((BendingPunchTool) RefTools);
    if (RefTools.GetType() == typeof (BendingBroachTool))
      CopiedTool = (ToolBase) new BendingBroachTool((BendingBroachTool) RefTools);
    if (!(RefTools.GetType() == typeof (BendingNickTool)))
      return;
    CopiedTool = (ToolBase) new BendingNickTool((BendingNickTool) RefTools);
  }

  public static void Copy(List<ToolBase> RefTools, ref List<ToolBase> CopiedTools)
  {
    CopiedTools.Clear();
    for (int index = 0; index <= RefTools.Count - 1; ++index)
    {
      ToolBase CopiedTool = new ToolBase();
      ToolBase.Copy(RefTools[index], ref CopiedTool);
      CopiedTools.Add(CopiedTool);
    }
  }

  public static List<ToolBase> Copy(List<ToolBase> RefTools)
  {
    List<ToolBase> toolBaseList = new List<ToolBase>();
    for (int index = 0; index <= RefTools.Count - 1; ++index)
    {
      ToolBase CopiedTool = new ToolBase();
      ToolBase.Copy(RefTools[index], ref CopiedTool);
      toolBaseList.Add(CopiedTool);
    }
    return toolBaseList;
  }

  public override string ToString()
  {
    return $"{this.Data.Name} - No: {this.Data.No.ToString()} , Type: {this.Geometry.GeometryType.ToString()} , D: {this.Geometry.Diameter.ToString()} , L: {this.Geometry.Length.ToString()} , Thickness: {this.Geometry.Thickness.ToString()}";
  }
}
