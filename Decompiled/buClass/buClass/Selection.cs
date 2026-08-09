using System;
using System.Collections.Generic;
using System.Reflection;

namespace buClass;

[Serializable]
public class Selection : buSerilization
{
	public eEntities Entity = new eEntities();

	public eEntities SubEntity = new eEntities();

	public List<Pnt3D> Vertices = new List<Pnt3D>();

	public List<Pnt3D> ControlPoints = new List<Pnt3D>();

	public List<int> VerticeIndex = new List<int>();

	public List<int> ControlPointsIndex = new List<int>();

	public int Index = -1;

	public int EntityIndex = -1;

	public int ID = -1;

	public int SubIndex = -1;

	public int CloseIndex = -1;

	public int GroupIndex = -1;

	public Pnt3D ClickPoint = new Pnt3D();

	public SelectionClosestType ClosePointType = SelectionClosestType.Start;

	public SelectionType SelectType = SelectionType.None;

	public Selection()
	{
	}

	public Selection(int index)
	{
		Index = index;
	}

	public Selection(Selection data)
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
		ClickPoint = new Pnt3D(data.ClickPoint);
		eEntities copiedEnt = new eEntities();
		eEntities.CopyEntity(data.Entity, ref copiedEnt);
		Entity = copiedEnt;
		copiedEnt = new eEntities();
		eEntities.CopyEntity(data.SubEntity, ref copiedEnt);
		SubEntity = copiedEnt;
		Vertices.Clear();
		Pnt3D.Copy(data.Vertices, ref Vertices);
		ControlPoints.Clear();
		Pnt3D.Copy(data.ControlPoints, ref ControlPoints);
		VerticeIndex.Clear();
		for (int j = 0; j <= data.VerticeIndex.Count - 1; j++)
		{
			VerticeIndex.Add(data.VerticeIndex[j]);
		}
		ControlPointsIndex.Clear();
		for (int k = 0; k <= data.ControlPointsIndex.Count - 1; k++)
		{
			ControlPointsIndex.Add(data.ControlPointsIndex[k]);
		}
	}

	public override string ToString()
	{
		return "Index: " + Index + " , Entitiy : " + Entity.GetType().ToString();
	}
}
