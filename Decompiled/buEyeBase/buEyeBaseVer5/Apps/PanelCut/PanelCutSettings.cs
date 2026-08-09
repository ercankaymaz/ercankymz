using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelCutSettings : buSerilization5
{
	public int simulationInterval = 10;

	public double SawThickness = 0.0;

	public int NestingExecuteTimeSec = 3;

	public bool ShowOperationButton = true;

	public double CutSimDevideLen = 100.0;

	public int CutSawZMoveCount = 2;

	public int MaxOptimisationDepth = 0;

	public double PanelThickness = 19.0;

	public double PanelMaxThickness = 90.0;

	public double GeneralTrimWidth = 0.0;

	public double GeneralTrimHeight = 0.0;

	public PanelCutSettings()
	{
	}

	public PanelCutSettings(PanelCutSettings data)
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
