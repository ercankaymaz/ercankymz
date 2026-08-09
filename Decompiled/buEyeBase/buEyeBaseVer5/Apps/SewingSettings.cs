using System;
using System.Drawing;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingSettings : buSerilization5
{
	public double defaultStitchLength = 3.0;

	public MoveVertexType VertexMoveType = MoveVertexType.MoveOnlyVertex;

	public string layerNameGeneral = "General";

	public string layerNameOriginal = "Original";

	public string layerNameDrawing = "Drawing";

	public string layerNamePoint = "Point";

	public string layerNameDrawingPoints = "DrawingPoints";

	public string layerNameDrawingDevided = "DrawingDevided";

	public double CatchResolution = 0.2;

	public Color colorGeneral = Color.Black;

	public Color colorOriginalDrawing = Color.DarkOrange;

	public Color colorDrawing = Color.Red;

	public Color colorPoints = Color.Blue;

	public Color colorDrawingPoints = Color.IndianRed;

	public Color colorDrawingDevided = Color.Purple;

	public Color colorSimulation = Color.WhiteSmoke;

	public Color colorStitched = Color.Green;

	public Color colorJump = Color.DarkOrange;

	public Color colorLockStitch = Color.DarkRed;

	public Color colorPunterez = Color.DarkCyan;

	public Color colorVertex = Color.Blue;

	public Color colorNoStitch = Color.Green;

	public Color colorVertexHasCode = Color.Gold;

	public double thicknessGeneral = 1.0;

	public double thicknessStitched = 2.0;

	public double thicknessJump = 2.0;

	public double thicknessOriginalDrawing = 1.0;

	public double thicknessDrawing = 1.0;

	public double thicknessPoints = 5.0;

	public double thicknessDrawingPoints = 5.0;

	public double thicknessDrawingDevided = 2.0;

	public int SimulationTransparency = 150;

	public int SimulationTick = 20;

	public int SimulationStep = 1;

	public bool SimulationSolid = true;

	public bool SimulationRotate = true;

	public bool DevideEntitiesAfterSort = false;

	public double thicknessVertex = 1.0;

	public double thicknessNoStitch = 1.0;

	public double thicknessVertexHasCode = 1.0;

	public Point3D FoldingPostion1 = new Point3D();

	public Point3D FoldingPostion2 = new Point3D();

	public Point3D NeedlePostion = new Point3D();

	public SewingSettings()
	{
	}

	public SewingSettings(SewingSettings data)
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
