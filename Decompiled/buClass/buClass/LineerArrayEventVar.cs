using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class LineerArrayEventVar : buSerilization
{
	public int ColomnsCountX = 2;

	public double ColomnsDistanceX = 10.0;

	public int RowsCountY = 2;

	public double RowDistanceY = 10.0;

	public int LevelCountZ = 1;

	public double LevelDistanceZ = 10.0;

	public bool MoveByMouse = false;

	public ContentAlignment Alingement = ContentAlignment.BottomLeft;

	public static List<string> Captions = new List<string>();

	public LineerArrayEventVar()
	{
	}

	public LineerArrayEventVar(LineerArrayEventVar data)
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
