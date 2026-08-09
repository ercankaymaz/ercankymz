using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

public class OperationOkArg
{
	public bool Updating = false;

	public bool Copy = false;

	public bool Reset = false;

	public bool Save = false;

	public bool JobUpdate = false;

	public bool DontAddOP = false;

	public List<List<eEntities>> Entities = new List<List<eEntities>>();

	public OperationOkArg()
	{
	}

	public OperationOkArg(bool updating, bool copy, bool reset, bool save, bool jobupdate)
	{
		Updating = updating;
		Copy = copy;
		Reset = reset;
		Save = save;
		JobUpdate = jobupdate;
	}

	public OperationOkArg(OperationOkArg data)
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
