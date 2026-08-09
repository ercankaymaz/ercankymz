using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class SelectedEntities : buSerilization
{
	public List<Selection> SelectedList = new List<Selection>();

	public List<List<Selection>> SelectedListArr = new List<List<Selection>>();

	public AlingmentPoints AlingPoints = new AlingmentPoints();

	public List<eEntities> SelectableEntities = new List<eEntities>();

	public SelectedPointOfEntity ClickPointOfEntity = new SelectedPointOfEntity();

	public Pnt3D pntMin = new Pnt3D();

	public Pnt3D pntMax = new Pnt3D();

	public SelectedEntities()
	{
	}

	public SelectedEntities(SelectedEntities data)
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
		ClickPointOfEntity = new SelectedPointOfEntity(data.ClickPointOfEntity);
		AlingPoints = new AlingmentPoints(data.AlingPoints);
		SelectedList.Clear();
		SelectedList = new List<Selection>();
		for (int j = 0; j <= data.SelectedList.Count - 1; j++)
		{
			SelectedList.Add(new Selection(data.SelectedList[j]));
		}
		SelectableEntities.Clear();
		SelectableEntities = new List<eEntities>();
		for (int k = 0; k <= data.SelectableEntities.Count - 1; k++)
		{
			eEntities item = new eEntities();
			eEntities.CopyEntity(data.SelectableEntities[k]);
			SelectableEntities.Add(item);
		}
	}
}
