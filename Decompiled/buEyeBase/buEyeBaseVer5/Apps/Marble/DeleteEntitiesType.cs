using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class DeleteEntitiesType : buSerilization5
{
	public bool Machine = false;

	public bool Simulation = false;

	public bool Base = false;

	public bool Operation = false;

	public bool Cam = false;

	public bool Drawings = false;

	public bool Tool = false;

	public static List<string> Captions = new List<string>();

	public DeleteEntitiesType()
	{
	}

	public DeleteEntitiesType(bool machine, bool simulation, bool basemat, bool operation, bool cam, bool draw, bool tool)
	{
		Base = basemat;
		Machine = machine;
		Simulation = simulation;
		Operation = operation;
		Cam = cam;
		Drawings = draw;
		Tool = tool;
	}

	public DeleteEntitiesType(DeleteEntitiesType data)
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
