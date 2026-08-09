using System;
using System.Collections;
using System.Collections.Generic;
using buClass.Apps;

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
		Data = new ToolData(tool.Data);
		Geometry = new ToolGeometry(tool.Geometry);
		CamData = new ToolCamData(tool.CamData);
		Positions = new ToolPositions(tool.Positions);
		Display = new ToolDisplay(tool.Display);
		Diemaker = new ToolDiemaker(tool.Diemaker);
		Limits = new ToolLimits(tool.Limits);
		Purpose = tool.Purpose;
		Aux = new ArrayList();
		for (int i = 0; i <= tool.Aux.Count - 1; i++)
		{
			Aux.Add(tool.Aux[i]);
		}
	}

	public static void Copy(ToolBase RefTools, ref ToolBase CopiedTool)
	{
		if (RefTools.GetType() == typeof(ToolBase))
		{
			CopiedTool = new ToolBase(RefTools);
		}
		if (RefTools.GetType() == typeof(BendingPunchTool))
		{
			CopiedTool = new BendingPunchTool((BendingPunchTool)RefTools);
		}
		if (RefTools.GetType() == typeof(BendingBroachTool))
		{
			CopiedTool = new BendingBroachTool((BendingBroachTool)RefTools);
		}
		if (RefTools.GetType() == typeof(BendingNickTool))
		{
			CopiedTool = new BendingNickTool((BendingNickTool)RefTools);
		}
	}

	public static void Copy(List<ToolBase> RefTools, ref List<ToolBase> CopiedTools)
	{
		CopiedTools.Clear();
		for (int i = 0; i <= RefTools.Count - 1; i++)
		{
			ToolBase CopiedTool = new ToolBase();
			Copy(RefTools[i], ref CopiedTool);
			CopiedTools.Add(CopiedTool);
		}
	}

	public static List<ToolBase> Copy(List<ToolBase> RefTools)
	{
		List<ToolBase> list = new List<ToolBase>();
		for (int i = 0; i <= RefTools.Count - 1; i++)
		{
			ToolBase CopiedTool = new ToolBase();
			Copy(RefTools[i], ref CopiedTool);
			list.Add(CopiedTool);
		}
		return list;
	}

	public override string ToString()
	{
		return Data.Name + " - No: " + Data.No + " , Type: " + Geometry.GeometryType.ToString() + " , D: " + Geometry.Diameter + " , L: " + Geometry.Length + " , Thickness: " + Geometry.Thickness;
	}
}
