using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingPartAddData : buSerilization5
{
	public Color SelectionColor = Color.Blue;

	public bool UseLayerForSelection = false;

	public bool DeleteSelectedEntities = true;

	public bool DeleteSelectedAuxEntities = true;

	public bool DeleteSelectedTextEntities = false;

	public bool DeleteCamAfterAdding = false;

	public bool AddCam = false;

	public bool AddAuxEntities = true;

	public int Priority = 10;

	public double Thickness = 10.0;

	public double Width = 10.0;

	public double Height = 10.0;

	public int Quantity = 1;

	public string Name = "Part";

	public int MirrorQuantity = 0;

	public double PartDistance = 0.0;

	public double AdditionalRotation = 0.0;

	public DirectionXandY MirrorAxis = DirectionXandY.XDirection;

	public nestPartRotateType Rotation = nestPartRotateType.Increment90;

	public bool MirrorEnable = false;

	public string OutterContourLayerName = "";

	public double LastPartWidth = 500.0;

	public double LastPartHeight = 250.0;

	public int LastPartQuantity = 10;

	public static List<string> Captions = new List<string>();

	public buNestingPartAddData()
	{
	}

	public buNestingPartAddData(buNestingPartAddData data)
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
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
