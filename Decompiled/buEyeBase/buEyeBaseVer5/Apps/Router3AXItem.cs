using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXItem : buSerilization5
{
	public string ItemName = "Job";

	public string FileName = "";

	public string FileNameFull = "";

	public int Index = -1;

	public bool isError = false;

	public bool isGCodeCreated = false;

	public bool CreatedFromDrawing = false;

	public MaterialBase5 Material = new MaterialBase5();

	public string TextureName = "";

	public Color colorFoam = Color.DarkGray;

	public int Transparency = 120;

	public Point3D MinPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public CamStock Stock = null;

	public MachineGCodeExecutionResult GCodeResult = null;

	public List<Router3AXCAM> CamList = new List<Router3AXCAM>();

	public Router3AXItem()
	{
	}

	public Router3AXItem(Router3AXItem data)
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
		if (data.GCodeResult != null)
		{
			GCodeResult = new MachineGCodeExecutionResult(data.GCodeResult);
		}
		if (data.Stock != null)
		{
			Stock = new CamStock();
			Stock = new CamStock(data.Stock);
		}
		for (int j = 0; j <= data.CamList.Count - 1; j++)
		{
			CamList.Add(new Router3AXCAM(data.CamList[j]));
		}
	}

	public static ArrayList ToDef(FoamItem refItem, int Space)
	{
		return new ArrayList();
	}

	public static void Decode(ArrayList AL, ref FoamItem Item)
	{
	}

	public override string ToString()
	{
		return ItemName.ToString();
	}
}
