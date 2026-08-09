using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class TheoJob : buSerilization
{
	public double Length = 100.0;

	public double OffsetedLength = 100.0;

	public double Width = 23.8;

	public double Pt = 2.0;

	public int Count = 0;

	public int Index = 0;

	public bool BendMark = false;

	public bool Done = false;

	public double StartOffset = 0.0;

	public double EndOffset = 0.0;

	public bool Mirrored = false;

	public double ToolWidth = 0.0;

	public List<Pnt3D> AllPoints = new List<Pnt3D>();

	public ArrayList Codes = new ArrayList();

	public ArrayList FullCodes = new ArrayList();

	public List<eEntities> Entities = new List<eEntities>();

	public List<TheoItem> Items = new List<TheoItem>();

	public static List<string> Captions = new List<string>();

	public TheoJob()
	{
	}

	public TheoJob(TheoJob data)
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
		Codes = new ArrayList();
		Entities.Clear();
		Items.Clear();
		AllPoints.Clear();
		for (int j = 0; j <= data.AllPoints.Count - 1; j++)
		{
		}
		for (int k = 0; k <= data.Items.Count - 1; k++)
		{
			if (data.Items[k].GetType() == typeof(TheoBridgeItem))
			{
				TheoBridgeItem item = new TheoBridgeItem((TheoBridgeItem)data.Items[k]);
				Items.Add(item);
			}
			if (data.Items[k].GetType() == typeof(TheoBendItem))
			{
				TheoBendItem item2 = new TheoBendItem((TheoBendItem)data.Items[k]);
				Items.Add(item2);
			}
			if (data.Items[k].GetType() == typeof(TheoBroachItem))
			{
				TheoBroachItem item3 = new TheoBroachItem((TheoBroachItem)data.Items[k]);
				Items.Add(item3);
			}
			if (data.Items[k].GetType() == typeof(TheoNickItem))
			{
				TheoNickItem item4 = new TheoNickItem((TheoNickItem)data.Items[k]);
				Items.Add(item4);
			}
		}
		for (int l = 0; l <= data.Codes.Count - 1; l++)
		{
			Codes.Add(data.Codes[l]);
		}
		for (int m = 0; m <= data.FullCodes.Count - 1; m++)
		{
			FullCodes.Add(data.FullCodes[m]);
		}
		for (int n = 0; n <= data.Entities.Count - 1; n++)
		{
			eEntities copiedEnt = new eEntities();
			eEntities.CopyEntity(data.Entities[n], ref copiedEnt);
			Entities.Add(copiedEnt);
		}
	}

	public override string ToString()
	{
		return "Len: " + Length + " , Width: " + Width + " , Pt: " + Pt + " Cnt: " + Count;
	}
}
