using System;
using System.Drawing;
using System.Reflection;
using buClass;
using buControls.Controls;

namespace buEyeBaseVer5;

[Serializable]
public class hmiUIPars : buSerilization
{
	public ContentAlignment ImageAlignment = ContentAlignment.MiddleLeft;

	public ShapeType GeometryType = ShapeType.Arc;

	public int GeometryArcDiameer = 10;

	public bool SpinButtonShow = true;

	public int CheckBoxSize = 20;

	public bool CheckBoxVisible = true;

	public bool CheckBoxCheckIsRectangle = true;

	public bool CheckColorMode = false;

	public int ObjectWidth = 20;

	public bool DrawerRectangle = true;

	public bool ShowPersentage = true;

	public int TopHeight = 20;

	public int BottomHeight = 0;

	public Color LineColor = Color.Black;

	public Color ArrowColor = Color.Silver;

	public Color DropColor = Color.LightGray;

	public Color ValueColor = Color.WhiteSmoke;

	public hmiUIPars()
	{
	}

	public hmiUIPars(hmiUIPars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
