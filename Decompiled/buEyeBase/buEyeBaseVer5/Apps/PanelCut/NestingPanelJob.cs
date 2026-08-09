using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class NestingPanelJob : buSerilization5
{
	public List<NestingPanel> Panels = new List<NestingPanel>();

	public List<buNestingPart> usedParts = new List<buNestingPart>();

	public List<Rectangle2D> Parts = new List<Rectangle2D>();

	public List<Rectangle2D> Sheets = new List<Rectangle2D>();

	public List<PanelCutMove> SimulationMoves = new List<PanelCutMove>();

	public List<string> SimulationCodes = new List<string>();

	public List<buEntity> MovingEntities = new List<buEntity>();

	public List<PanelWaitAssembly> WaitingAssembly = new List<PanelWaitAssembly>();

	public List<PanelDonePart> DoneParts = new List<PanelDonePart>();

	public NestingPanelJob()
	{
	}

	public NestingPanelJob(NestingPanelJob data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
