using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buClass;

[Serializable]
public class LayerBase : buSerilization
{
	public bool Enable = true;

	public bool Lock = false;

	public bool RealDrawMode = false;

	public string Name = "Layer";

	public string MaterialName = "";

	public string Tag = "";

	public string Option = "";

	public string Note = "";

	public string ShownName = "";

	public int Mode = 0;

	public Color LayerColor = Color.Black;

	public int Transparency = 255;

	public float LayerThickness = 1f;

	public drawingPattern Pattern = new drawingPattern();

	public LayerPurpose LayerPurposes = LayerPurpose.General;

	public ToolBase ToolSelected = new ToolBase();

	public LayerCam Cam = new LayerCam();

	public LayerTuftingProps Tufting = new LayerTuftingProps();

	public LayerDiemakerProps Diemaker = new LayerDiemakerProps();

	public LayerJewelProps Jewelary = new LayerJewelProps();

	public static List<string> Captions = new List<string>();

	public LayerBase()
	{
	}

	public LayerBase(string name)
	{
		Name = name;
	}

	public LayerBase(LayerBase data)
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
		if (data.ToolSelected != null)
		{
			ToolSelected = new ToolBase(data.ToolSelected);
		}
		if (data.Cam != null)
		{
			Cam = new LayerCam(data.Cam);
		}
		if (data.Tufting != null)
		{
			Tufting = new LayerTuftingProps(data.Tufting);
		}
		if (data.Diemaker != null)
		{
			Diemaker = new LayerDiemakerProps(data.Diemaker);
		}
		if (data.Jewelary != null)
		{
			Jewelary = new LayerJewelProps(data.Jewelary);
		}
	}

	public static void Copy(List<LayerBase> Base, ref List<LayerBase> Copied)
	{
		Copied.Clear();
		Copied = new List<LayerBase>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			Copied.Add(new LayerBase(Base[i]));
		}
	}

	public override string ToString()
	{
		return Name + " , Enable = " + Enable + " , Color : " + LayerColor.ToString() + " , Thickness : " + LayerThickness;
	}
}
