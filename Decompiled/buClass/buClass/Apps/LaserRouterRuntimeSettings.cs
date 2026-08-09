using System;
using System.Reflection;
using System.Windows.Forms;

namespace buClass.Apps;

[Serializable]
public class LaserRouterRuntimeSettings : buSerilization
{
	public int SelectedMaterial = -1;

	public bool VerticalSelection = false;

	public bool HorizontalSelection = false;

	public bool AngleSelection = false;

	public string PathMaterialSave = Application.StartupPath;

	public string LastSelectedWoodChamferTopToolName = "";

	public string LastSelectedWoodChamferBottomToolName = "";

	public string LastSelectedPertinaxInCutToolName = "";

	public string LastSelectedPertinaxOutCutToolName = "";

	public string LastSelectedPertinaxHoleToolName = "";

	public string LastSelectedPertinaxHoleCutToolName = "";

	public string LastSelectedPertinaxTextToolName = "";

	public string LastSelectedSteelContourToolName = "";

	public string LastSelectedSteelPocketToolName = "";

	public string LastSelectedSteelTextToolName = "";

	public LaserRouterRuntimeSettings()
	{
	}

	public LaserRouterRuntimeSettings(LaserRouterRuntimeSettings data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public static void Copy(LaserRouterRuntimeSettings Source, ref LaserRouterRuntimeSettings Target)
	{
		Target = new LaserRouterRuntimeSettings(Source);
	}

	public override string ToString()
	{
		return "Sel Mat : " + SelectedMaterial;
	}
}
