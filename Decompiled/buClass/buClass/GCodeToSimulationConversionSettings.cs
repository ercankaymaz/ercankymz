using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class GCodeToSimulationConversionSettings : buSerilization
{
	public Pnt6D StartPositions = new Pnt6D(0.0, 0.0, 200.0, 0.0, 0.0, 0.0);

	public Pnt6D G53Positions = new Pnt6D(0.0, 0.0, 200.0, 0.0, 0.0, 0.0);

	public Pnt6D OffsetPositions = new Pnt6D(0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

	public bool AddMCodes = false;

	public bool UseStartPosition = false;

	public int ClamperCount = 0;

	public bool ReverseG3 = false;

	public bool ReverseG2 = false;

	public string CommentChar = "";

	public List<string> CommandList = null;

	public GCodeToSimulationConversionSettings()
	{
	}

	public GCodeToSimulationConversionSettings(GCodeToSimulationConversionSettings data)
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
}
