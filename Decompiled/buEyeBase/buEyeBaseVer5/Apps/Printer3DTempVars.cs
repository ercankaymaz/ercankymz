using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Printer3DTempVars
{
	public string layerSliceName = "Slice";

	public string layerRegionName = "Region";

	public string layerOffsetSliceName = "OffsetSlice";

	public string layerSimulationName = "Simulation";

	public string layerTessellationName = "Tessellation";

	public string layerCamName = "Cam";

	public string layerOnlineSimulationName = "OnlineSimulation";

	public string layerInFill = "InFill";

	public Printer3DTempVars()
	{
	}

	public Printer3DTempVars(Printer3DTempVars data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
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
