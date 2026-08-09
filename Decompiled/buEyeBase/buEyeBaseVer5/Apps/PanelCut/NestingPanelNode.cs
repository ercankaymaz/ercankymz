using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.PanelCut;

[Serializable]
public class NestingPanelNode : buSerilization5
{
	public Point3D LowerLeft = new Point3D();

	public DirectionXandY Direction = DirectionXandY.XDirection;

	public nestPanelNodeType NodeType = nestPanelNodeType.Assembly;

	public int NodeID = -1;

	public int XQuantity = -1;

	public int YQuantity = -1;

	public int Depth = -1;

	public double DimensionX = 0.0;

	public double DimensionY = 0.0;

	public Point3D SubNodeLowerLeft = new Point3D();

	public Rectangle2D BaseRectangle = null;

	public Rectangle2D Rectangle = null;

	public Line2D CutLine = null;

	public double CutOffset = 0.0;

	public double CutFeedDistance = 0.0;

	public double CutSawDistance = 0.0;

	public int PartID = -1;

	public int ID = -1;

	public List<NestingPanelNode> Node = new List<NestingPanelNode>();

	public List<PanelCutMove> SimMoves = new List<PanelCutMove>();

	public NestingPanelNode()
	{
	}

	public NestingPanelNode(NestingPanelNode data)
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
		SubNodeLowerLeft = buVector5.ToPoint3D(data.SubNodeLowerLeft);
		if (data.Rectangle != null)
		{
			Rectangle = new Rectangle2D(data.Rectangle);
		}
		if (data.CutLine != null)
		{
			CutLine = new Line2D(data.CutLine);
		}
	}

	public override string ToString()
	{
		return "NodeType: " + NodeType.ToString() + " , Dir: " + Direction.ToString() + " , NodeID: " + NodeID + " , DimX: " + DimensionX + " , DimY: " + DimensionY + " , PartID: " + PartID;
	}
}
