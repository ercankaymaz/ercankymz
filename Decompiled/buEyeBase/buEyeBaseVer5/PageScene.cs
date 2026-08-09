using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class PageScene : buSerilization5, IDisposable
{
	private bool bool_0 = false;

	public Plane ScenePlane = new Plane();

	public string SceneName = "";

	public string SceneFileName = Application.StartupPath;

	public int EntitiesCount = 0;

	public bool Visible = true;

	public PageScene()
	{
	}

	public PageScene(PageScene data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
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
		ScenePlane = (Plane)data.ScenePlane.Clone();
	}

	public static void DecodeLocal(List<string> SL, string Char, ref PageScene scene)
	{
		scene = new PageScene();
		buSerilization5.Decode(SL, Char, SerilizationMode5.MultiLine, scene);
		new ArrayList();
		List<string> CalcList = new List<string>();
		buString5.ListToSpecificList("<Origine>", "</Origine>", AddStartEndKey: false, SL, ref CalcList);
		Point3D p = new Point3D();
		Vector3D n = Vector3D.AxisZ;
		if (CalcList.Count >= 1)
		{
			string[] array = CalcList[0].Split(';');
			if (array != null && array.Length >= 3)
			{
				p = new Point3D(double.Parse(array[0]), double.Parse(array[1]), double.Parse(array[2]));
			}
		}
		CalcList = new List<string>();
		buString5.ListToSpecificList("<Equation>", "</Equation>", AddStartEndKey: false, SL, ref CalcList);
		if (CalcList.Count >= 1)
		{
			string[] array2 = CalcList[0].Split(';');
			if (array2 != null && array2.Length >= 3)
			{
				n = new Vector3D(double.Parse(array2[0]), double.Parse(array2[1]), double.Parse(array2[2]));
			}
		}
		scene.ScenePlane = new Plane(p, n);
	}

	public ArrayList ToDef(string Char, int Space)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(ToDefAll(Char, Space, SerilizationMode5.MultiLine).ToArray());
		string value = "";
		if (arrayList.Count > 1)
		{
			arrayList[0].ToString();
			value = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
		}
		arrayList.Add("<Origine>");
		arrayList.Add(ScenePlane.Origin.X + ";" + ScenePlane.Origin.Y + ";" + ScenePlane.Origin.Z);
		arrayList.Add("</Origine>");
		arrayList.Add("<Equation>");
		arrayList.Add(ScenePlane.Equation.X + ";" + ScenePlane.Equation.Y + ";" + ScenePlane.Equation.Z);
		arrayList.Add("</Equation>");
		arrayList.Add(value);
		return arrayList;
	}

	~PageScene()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!bool_0 && disposing)
		{
			ScenePlane = null;
		}
		bool_0 = true;
	}
}
