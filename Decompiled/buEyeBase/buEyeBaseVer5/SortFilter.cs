using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5;

[Serializable]
public class SortFilter : buSerilization5
{
	public List<Entity> NotSelectEntities = new List<Entity>();

	public List<Entity> SelectableEntities = new List<Entity>();

	public List<int> NotSelectIndex = new List<int>();

	public List<int> SelectableIndex = new List<int>();

	public List<Color> NotSelectColor = new List<Color>();

	public List<Color> SelectableColor = new List<Color>();

	public MostClosestPointType MostClosestType = MostClosestPointType.OnlyNotCamSelectedEntities;

	public bool UsePointEntities = false;

	public SortFilter()
	{
	}

	public SortFilter(SortFilter data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		NotSelectColor = new List<Color>();
		for (int j = 0; j <= data.NotSelectColor.Count - 1; j++)
		{
			NotSelectColor.Add(data.NotSelectColor[j]);
		}
		SelectableColor = new List<Color>();
		for (int k = 0; k <= data.SelectableColor.Count - 1; k++)
		{
			SelectableColor.Add(data.SelectableColor[k]);
		}
		NotSelectIndex = new List<int>();
		for (int l = 0; l <= data.NotSelectIndex.Count - 1; l++)
		{
			NotSelectIndex.Add(data.NotSelectIndex[l]);
		}
		SelectableIndex = new List<int>();
		for (int m = 0; m <= data.SelectableIndex.Count - 1; m++)
		{
			SelectableIndex.Add(data.SelectableIndex[m]);
		}
		NotSelectEntities = new List<Entity>();
		for (int n = 0; n <= data.NotSelectEntities.Count - 1; n++)
		{
			NotSelectEntities.Add((Entity)data.NotSelectEntities[n].Clone());
		}
		SelectableEntities = new List<Entity>();
		for (int num = 0; num <= data.SelectableEntities.Count - 1; num++)
		{
			SelectableEntities.Add((Entity)data.SelectableEntities[num].Clone());
		}
	}
}
