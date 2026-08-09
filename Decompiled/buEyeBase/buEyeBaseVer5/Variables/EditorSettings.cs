using System;
using System.Drawing;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Variables;

[Serializable]
public class EditorSettings : buSerilization5
{
	public double GridStep = 10.0;

	public double GridMinValue = -500.0;

	public double GridMaxValue = 500.0;

	public int GridMajorLineCount = 10;

	public int snapGridPixel = 5;

	public int snapSymbolSize = 12;

	public double DrawThickness = 2.0;

	public Color colorDraw = Color.Black;

	public Color colorGridLine = Color.Gray;

	public Color colorGridMajorLine = Color.DarkGray;

	public Color colorGridAxisX = Color.DarkGray;

	public Color colorGridAxisY = Color.DarkGray;

	public Color colorEntity = Color.Black;

	public Color colorDrawingPoints = Color.LightGreen;

	public Color colorSelected = Color.Tomato;

	public Color colorDynamic = Color.Black;

	public Color colorFirstPart = Color.Lime;

	public Color colorSecondPart = Color.Cyan;

	public Color colorEvent = Color.Blue;

	public double thicknessDrawingPoints = 2.0;

	public double thicknessEntityPoint = 4.0;

	public double thicknessEntity = 2.0;

	public double BoxSizeOffset = 10.0;

	public bool ExpandDrawingTree = true;

	public bool ExpandConstraintTree = true;

	public bool ShowConstraintTreeItem = true;

	public bool ShowPointsAtDrawingTreeItem = true;

	public bool DrawDirrectionArrow = true;

	public int EntityMagnetRange = 3;

	public bool OffsetByMouse = false;

	public bool isRectangleAsLine = true;

	public bool OsnapOver = true;

	public bool OsnapEntity = true;

	public bool OsnapGrid = true;

	public bool Ortho = true;

	public bool ShowPoints = true;

	public bool ShowBoxSize = true;

	public bool DeleteIfSameEntities = true;

	public bool BreakArcIfGreat180Degree = true;

	public SortingFirstCatchRulesType SortFirstCatchRule = SortingFirstCatchRulesType.FirstDirectionThenAuto;

	public double SimulationDevideLength = 8.0;

	public int SimulationStep = 1;

	public EditorSettings()
	{
	}

	public EditorSettings(EditorSettings data)
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
