using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class DiemakerProgramSettings : buSerilization
{
	public int VendorType = 0;

	public bool MotionCommunicationEnable = true;

	public double CompareLevel = 0.05;

	public double SlotDiameter = 1.0;

	public bool FindSameEntities = true;

	public bool FindMirrorEntities = true;

	public bool LayerFromCf2Settings = true;

	public bool DontResetAfterOperations = true;

	public bool DrawAllEntitiesAtCuttingListPage = true;

	public static List<string> Captions = new List<string>();

	public DiemakerProgramSettings()
	{
	}

	public DiemakerProgramSettings(DiemakerProgramSettings data)
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

	public static void Copy(DiemakerProgramSettings Source, ref DiemakerProgramSettings Target)
	{
		Target = new DiemakerProgramSettings(Source);
	}

	public override string ToString()
	{
		return "VendorType : " + VendorType;
	}
}
