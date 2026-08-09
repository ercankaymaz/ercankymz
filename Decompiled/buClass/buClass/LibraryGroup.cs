using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class LibraryGroup
{
	public string Name = "";

	public int Index = 0;

	public int TypeIndex = 0;

	public List<int> EntityID = new List<int>();

	public List<eEntities> GroupEntities = new List<eEntities>();

	public LibraryItem Items = new LibraryItem();

	public camBase CamOperation = new camBase();

	public ToolBase Tool = new ToolBase();

	public object Data = null;

	public LibraryGroup()
	{
	}

	public LibraryGroup(LibraryGroup data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		CamOperation = new camBase(data.CamOperation);
		Tool = new ToolBase(data.Tool);
		GroupEntities.Clear();
		GroupEntities = new List<eEntities>();
		eEntities.CopyEntities(data.GroupEntities, ref GroupEntities);
	}
}
