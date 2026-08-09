using System;
using System.Reflection;
using System.Windows.Forms;

namespace buClass.Apps;

[Serializable]
public class jewelInterface : buSerilization
{
	public double MaterialWidth = 10.0;

	public double MaterialRadius = 10.0;

	public double MaterialDiameter = 10.0;

	public double FrameWidth = 10.0;

	public double FrameHeight = 100.0;

	public jewelCurveType MaterialFormMode = jewelCurveType.Flat;

	public jewelMaterialShapeType MaterialShape = jewelMaterialShapeType.Circle;

	public bool OilEnable = false;

	public bool ReadSurface = false;

	public bool DiameterMeasue = false;

	public int ToolSpindleIndex = 0;

	public int ToolDiaCut1Index = 0;

	public int ToolDiaCut2Index = 0;

	public int ToolEngraveIndex = 0;

	public int ToolLaserIndex = 0;

	public int ToolLatheIndex = 0;

	public string ModeFolder = Application.StartupPath;

	public jewelInterface()
	{
	}

	public jewelInterface(jewelInterface data)
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
		return "Width: " + MaterialWidth + " , Radius: " + MaterialRadius + " , Dia: " + MaterialDiameter + " , Form: " + MaterialFormMode;
	}
}
