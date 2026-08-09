using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class Cf2FileProperties : buSerilization
{
	public double PtIndex = 0.0;

	public double PtRealValue = 0.0;

	public double Cf2CodeMatchType = 0.0;

	public DiemakerType CodeType = DiemakerType.None;

	public string Explanation = "";

	public bool Selectable = true;

	public bool Visible = true;

	public Color MatchColor = Color.Black;

	public Color Color = Color.Black;

	public Color SelectedColor = Color.Black;

	public double Thickness = 1.0;

	public double SelectedThickness = 1.0;

	public int LayerIndex = 0;

	public int ToolNo = 1;

	public Cf2FileProperties()
	{
	}

	public Cf2FileProperties(Cf2FileProperties data)
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

	public static void Copy(Cf2FileProperties Base, ref Cf2FileProperties Copied)
	{
		Copied = new Cf2FileProperties(Base);
	}

	public static void Copy(List<Cf2FileProperties> Base, ref List<Cf2FileProperties> Copied)
	{
		Copied.Clear();
		Copied = new List<Cf2FileProperties>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			Copied.Add(new Cf2FileProperties(Base[i]));
		}
	}

	public override string ToString()
	{
		return "Pt Index: " + PtIndex + " - Pt Real: " + PtRealValue + " - Type: " + CodeType.ToString() + " - Color: " + Color.ToString();
	}
}
