using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.PanelCut;

public class PanelCutMove : buSerilization5
{
	public Point3D Position = new Point3D();

	public double MaterialLength = 0.0;

	public double XPosition = 0.0;

	public Rectangle2D Panel = new Rectangle2D();

	public List<Line2D> CutLines = new List<Line2D>();

	public List<Rectangle2D> SawCutRectangles = new List<Rectangle2D>();

	public bool FinalProduct = false;

	public int Index = 0;

	public int NodeID = -1;

	public int PartID = -1;

	public nestPanelNodeType NodeType = nestPanelNodeType.Assembly;

	public PanelCutMoveCommand Command = PanelCutMoveCommand.AxisMove;

	public bool isActive = false;

	public PanelCutMove()
	{
	}

	public PanelCutMove(PanelCutMove data)
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
		Position = buVector5.ToPoint3D(data.Position);
	}

	public override string ToString()
	{
		return Command.ToString() + " | X : " + Position.X.ToString("f1") + " , Y : " + Position.Y.ToString("f1") + " , Z : " + Position.Z.ToString("f1");
	}
}
