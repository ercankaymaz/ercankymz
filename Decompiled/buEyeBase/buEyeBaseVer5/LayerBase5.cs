using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class LayerBase5 : buSerilization5
{
	public bool Enable = true;

	public bool Lock = false;

	public bool RealDrawMode = false;

	public bool Selectable = true;

	public string Name = "Layer";

	public string NameExtra = "";

	public string MaterialName = "";

	public string Tag = "";

	public string Option = "";

	public string Note = "";

	public string ShownName = "";

	public string Defination = "";

	public int Mode = 0;

	public Color LayerColor = Color.Black;

	public int Transparency = 255;

	public float LayerThickness = 1f;

	public drawingPattern Pattern = null;

	public LayerPurpose LayerPurposes = LayerPurpose.General;

	public ToolBase5 ToolSelected = null;

	public LayerCam Cam = null;

	public LayerTuftingProps Tufting = null;

	public LayerDiemakerProps Diemaker = null;

	public LayerJewelProps Jewelary = null;

	public LayerRouter3XProps Router3AX = null;

	public static List<string> Captions = new List<string>();

	public LayerBase5()
	{
	}

	public LayerBase5(string name)
	{
		Name = name;
	}

	public LayerBase5(string name, Color color, float thickness, int transparency)
	{
		Name = name;
		if (!(transparency > 0 && transparency <= 255))
		{
			LayerColor = Color.FromArgb(255, color);
		}
		else
		{
			LayerColor = Color.FromArgb(transparency, color);
		}
		LayerThickness = thickness;
	}

	public LayerBase5(LayerBase5 data)
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
		if (data.Pattern != null)
		{
			Pattern = new drawingPattern(data.Pattern);
		}
		if (data.ToolSelected != null)
		{
			ToolSelected = new ToolBase5(data.ToolSelected);
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
		if (data.Router3AX != null)
		{
			Router3AX = new LayerRouter3XProps(data.Router3AX);
		}
	}

	public LayerBase5(LayerBase data)
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
		if (data.ToolSelected != null)
		{
			ToolSelected = new ToolBase5(data.ToolSelected);
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

	public static ArrayList ToDef(LayerBase5 Layer)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buSerilization5.ClassToString(Layer));
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref LayerBase5 Layer)
	{
		Layer = new LayerBase5();
		if (AL.Count >= 1)
		{
			object ObjPar = Layer;
			buSerilization5.StringToClass(ref ObjPar, AL[0].ToString());
		}
	}

	public static void Copy(List<LayerBase5> Base, ref List<LayerBase5> Copied)
	{
		Copied.Clear();
		Copied = new List<LayerBase5>();
		for (int i = 0; i <= Base.Count - 1; i++)
		{
			Copied.Add(new LayerBase5(Base[i]));
		}
	}

	public override string ToString()
	{
		return Name + " , Enable = " + Enable + " , Color : " + LayerColor.ToString() + " , Thickness : " + LayerThickness;
	}
}
