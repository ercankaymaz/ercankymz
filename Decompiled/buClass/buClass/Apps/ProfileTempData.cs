using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileTempData : buSerilization
{
	public List<Pnt3D> SortedEntitiesPoints = new List<Pnt3D>();

	public List<Pnt3D> SortedAndScaledEntitiesPoints = new List<Pnt3D>();

	public List<Pnt3D> SortedAndScaledAndRotatedEntitiesPoints = new List<Pnt3D>();

	public List<Pnt3D> ScaledEntitiesPoints = new List<Pnt3D>();

	public List<eEntities> SortedEntities = new List<eEntities>();

	public List<eEntities> SortedAndScaledEntities = new List<eEntities>();

	public List<eEntities> SortedAndScaledAndRotaredEntities = new List<eEntities>();

	public List<List<Pnt3D>> SortedEntitiesPointsList = new List<List<Pnt3D>>();

	public List<List<Pnt3D>> SortedAndScaledEntitiesPointsList = new List<List<Pnt3D>>();

	public List<List<Pnt3D>> SortedAndScaledAndRotatedEntitiesPointsList = new List<List<Pnt3D>>();

	public List<List<Pnt3D>> ScaledEntitiesPointsList = new List<List<Pnt3D>>();

	public List<List<eEntities>> SortedEntitiesList = new List<List<eEntities>>();

	public List<List<eEntities>> SortedAndScaledEntitiesList = new List<List<eEntities>>();

	public List<List<eEntities>> SortedAndScaledAndRotatedEntitiesList = new List<List<eEntities>>();

	public static List<string> Captions = new List<string>();

	public ProfileTempData()
	{
	}

	public ProfileTempData(ProfileTempData data)
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
		return "SortedEntitiesPoints : " + SortedEntitiesPoints.Count;
	}
}
