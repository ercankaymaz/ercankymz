using System;
using System.Collections.Generic;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.PanelCut;

public class buPanelCutCalc
{
	public int PanelCutDirToImageIndex(DirectionXandY Dir)
	{
		if (Dir != DirectionXandY.XDirection)
		{
			return 1;
		}
		return 0;
	}

	public string PanelCutToString(NestingPanelNode Node)
	{
		string result = Node.NodeType.ToString();
		if (Node.NodeType != nestPanelNodeType.CutLine)
		{
			if (Node.NodeType != nestPanelNodeType.Module)
			{
				if (Node.NodeType == nestPanelNodeType.Assembly)
				{
					result = "Assembly - X= " + Node.DimensionX.ToString("f2") + " , Y = " + Node.DimensionY.ToString("f2");
				}
			}
			else
			{
				result = "Module - X= " + Node.DimensionX.ToString("f2") + " , Y = " + Node.DimensionY.ToString("f2");
			}
		}
		else
		{
			if (Node.Direction == DirectionXandY.XDirection && Node.CutLine != null)
			{
				result = Node.CutLine.StartPoint.X.ToString("f2");
			}
			if (Node.Direction == DirectionXandY.YDirection && Node.CutLine != null)
			{
				result = Node.CutLine.StartPoint.Y.ToString("f2");
			}
		}
		return result;
	}

	public void GetPartFromPartListWithID(List<Rectangle2D> Parts, double PanelDepth, int ID, Color color, bool RotateToLongWidth, ref Mesh partEntity, ref Rectangle2D foundRect)
	{
		if ((ID >= 0) & (ID <= Parts.Count - 1))
		{
			if (!(Parts[ID].Width > Parts[ID].Height))
			{
				foundRect = new Rectangle2D(Parts[ID].Height, Parts[ID].Width);
			}
			else
			{
				foundRect = new Rectangle2D(Parts[ID].Width, Parts[ID].Height);
			}
			RectangleToMesh(foundRect, PanelDepth, color, 0, -1, -1, null, ref partEntity);
		}
	}

	public void RectangleToMesh(Rectangle2D rectangle, double PanelDepth, Color color, int DepthLevel, int xIndex, int yIndex, NestingPanelNode node, ref Mesh meshPanel)
	{
		List<Point3D> Vertices = new List<Point3D>();
		Rectangle2D.Rectangle3DToVertices(rectangle, ref Vertices);
		buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Vertices);
		if (Vertices.Count >= 3)
		{
			LinearPath outer = new LinearPath(Vertices);
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer);
			meshPanel = region.ExtrudeAsMesh(PanelDepth, 0.1, Mesh.natureType.RichSmooth);
			meshPanel.Color = color;
			meshPanel.ColorMethod = colorMethodType.byEntity;
			meshPanel.Selectable = false;
			PanelEntityData panelEntityData = new PanelEntityData();
			panelEntityData.Depth = DepthLevel;
			if (node != null)
			{
				panelEntityData.NodeType = node.NodeType;
				panelEntityData.NodeID = node.NodeID;
			}
			panelEntityData.XIndex = xIndex;
			panelEntityData.YIndex = yIndex;
			meshPanel.EntityData = panelEntityData;
		}
	}

	public void GetPanelPartArea(List<Rectangle2D> Parts, List<NestingPanelNode> Nodes, ref double Area)
	{
		for (int i = 0; i <= Nodes.Count - 1; i++)
		{
			if (Nodes[i].NodeType == nestPanelNodeType.CutLine && ((Nodes[i].PartID >= 0) & (Nodes[i].PartID <= Parts.Count - 1) & (Nodes[i].Node.Count == 0)))
			{
				Area += Parts[Nodes[i].PartID].Width * Parts[Nodes[i].PartID].Height;
			}
			if (Nodes[i].Node.Count > 0)
			{
				GetPanelPartArea(Parts, Nodes[i].Node, ref Area);
			}
		}
	}

	public int SimCountFromLength(double MaxLen, double SimLen)
	{
		int num = 3;
		double num2 = 3.0;
		if (SimLen > 0.0)
		{
			num2 = MaxLen / SimLen;
		}
		if (num2 < 3.0)
		{
			num2 = 3.0;
		}
		return Convert.ToInt32(num2);
	}
}
