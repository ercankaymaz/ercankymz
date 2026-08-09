using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class camOffsetEnable : buSerilization
{
	public bool Offset = true;

	public bool AdditionalOffset = false;

	public bool OffsetCount = false;

	public bool OverlapDistance = true;

	public bool Flow = true;

	public bool Corner = true;

	public bool OpenContour = true;

	public static List<string> Captions = new List<string>();

	public camOffsetEnable()
	{
	}

	public camOffsetEnable(bool offset, bool addtionaloffset, bool overlap, bool offsetcount, bool flow, bool corner, bool opentype)
	{
		Offset = offset;
		AdditionalOffset = addtionaloffset;
		OffsetCount = offsetcount;
		OverlapDistance = overlap;
		Flow = flow;
		Corner = corner;
		OpenContour = opentype;
	}

	public camOffsetEnable(camOffsetEnable Data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(Data, ref CopiedClass);
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
		return "Offset: " + Offset + " , Flow: " + Flow + " , OpenContour: " + OpenContour + " , OverlapDistance: " + OverlapDistance + " , OffsetCount: " + OffsetCount;
	}
}
