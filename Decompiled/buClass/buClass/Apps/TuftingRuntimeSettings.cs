using System;
using System.Reflection;
using System.Windows.Forms;

namespace buClass.Apps;

[Serializable]
public class TuftingRuntimeSettings : buSerilization
{
	public int SelectedLayerIndex = 0;

	public string SelectedLayerName = "";

	public string ArrowDirLayerName = "";

	public bool BreakTuftCurve = false;

	public bool DirectionArrowAllLayer = true;

	public bool DirectionArrowSelectedLayer = true;

	public bool ShowSortedAllLayer = false;

	public bool ShowSortedSelectedLayer = false;

	public bool LineAsBorderLine = true;

	public string pathGCode = Application.StartupPath;

	public bool ThisIsTuftingOperation = false;

	public TuftingRuntimeSettings()
	{
	}

	public TuftingRuntimeSettings(TuftingRuntimeSettings data)
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

	public override string ToString()
	{
		return "Layer Index: " + SelectedLayerIndex;
	}
}
