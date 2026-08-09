using System;
using System.Reflection;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class PanelCutTempVars
{
	public bool simRelease = false;

	public int acliveLine = -1;

	public int OffcutCount = 0;

	public string layerPanel = "Panel";

	public string layerOperation = "Operation";

	public string layerGeneral = "General";

	public string layerSelected = "Selected";

	public string layerCam = "Cam";

	public PanelCutTempVars()
	{
	}

	public PanelCutTempVars(PanelCutTempVars data)
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
