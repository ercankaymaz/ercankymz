using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buMultilineText : buEntity
{
	public Plane Plane = Plane.XY;

	public string TextString = "";

	public double RectWidth = 0.0;

	public double Height = 0.0;

	public double LineSpaceDistance = 0.0;

	public string StyleName = "";

	public bool Simplify = false;

	public bool Wrap = true;

	public Text.alignmentType Alignment = Text.alignmentType.MiddleCenter;

	public Point3D InsertionPoint = new Point3D();

	public buMultilineText()
	{
	}

	public buMultilineText(Point3D insPoint, string textString, double width, double height, double lineSpaceDistance)
	{
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		TextString = textString;
		Height = height;
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Plane textPlane, string textString, double width, double height, double lineSpaceDistance)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Plane textPlane, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		Alignment = alignment;
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Plane textPlane, Point3D insPoint, string textString, double width, double height, double lineSpaceDistance)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(double x, double y, string textString, double width, double height, double lineSpaceDistance)
	{
		TextString = textString;
		Height = height;
		InsertionPoint = new Point3D(x, y);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Plane sketchPlane, Point2D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)sketchPlane.Clone();
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
		Alignment = alignment;
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Plane textPlane, Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		Alignment = alignment;
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Plane textPlane, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		Alignment = alignment;
		StyleName = styleName;
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(double x, double y, double z, string textString, double width, double height, double lineSpaceDistance)
	{
		TextString = textString;
		Height = height;
		InsertionPoint = new Point3D(x, y, z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName, bool simplify, bool wrap = true)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Wrap = wrap;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(Plane textPlane, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName, bool simplify, bool wrap = true)
	{
		TextString = textString;
		Plane = (Plane)textPlane.Clone();
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		RectWidth = width;
		Wrap = wrap;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(Plane textPlane, Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Plane = (Plane)textPlane.Clone();
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(double x, double y, double z, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		InsertionPoint = new Point3D(x, y, z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Plane sketchPlane, Point2D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		if (!(sketchPlane != null))
		{
			Plane = Plane.XY;
		}
		else
		{
			Plane = (Plane)sketchPlane.Clone();
		}
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(Plane textPlane, Point3D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName, bool simplify, bool wrap = true)
	{
		TextString = textString;
		if (!(textPlane != null))
		{
			Plane = Plane.XY;
		}
		else
		{
			Plane = (Plane)textPlane.Clone();
		}
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Wrap = wrap;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(double x, double y, double z, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		InsertionPoint = new Point3D(x, y, z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Update(buEntityUpdateType.MultilineText);
	}

	public buMultilineText(Plane sketchPlane, Point2D insPoint, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName, bool simplify, bool wrap = true)
	{
		TextString = textString;
		Plane = (Plane)sketchPlane.Clone();
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Wrap = wrap;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(double x, double y, double z, string textString, double width, double height, double lineSpaceDistance, Text.alignmentType alignment, string styleName, bool simplify, bool wrap = true)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		InsertionPoint = new Point3D(x, y, z);
		RectWidth = width;
		LineSpaceDistance = lineSpaceDistance;
		Wrap = wrap;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(MultilineText another)
	{
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		TextString = another.TextString;
		Height = another.Height;
		RectWidth = another.RectWidth;
		LineSpaceDistance = another.LineSpaceDistance;
		Alignment = another.Alignment;
		StyleName = another.StyleName;
		Simplify = another.Simplify;
		Wrap = another.Wrap;
		Plane = (Plane)another.Plane.Clone();
		LayerName = another.LayerName;
		if (buCall.list_0 != null && buCall.list_0.Count > 0)
		{
			Color colorLayer = another.Color;
			if (buEyeShotFunctions.GetLayerColorFromName(another.LayerName, ref colorLayer))
			{
				Color = colorLayer;
			}
		}
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(buMultilineText another)
	{
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		TextString = another.TextString;
		Height = another.Height;
		LineSpaceDistance = another.LineSpaceDistance;
		RectWidth = another.RectWidth;
		Height = another.Height;
		Alignment = another.Alignment;
		StyleName = another.StyleName;
		Simplify = another.Simplify;
		Wrap = another.Wrap;
		Plane = (Plane)another.Plane.Clone();
		ToolName = another.ToolName;
		LayerName = another.LayerName;
		LayerIndex = another.LayerIndex;
		Color = another.Color;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(buText another)
	{
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		TextString = another.TextString;
		Height = another.Height;
		Height = another.Height;
		Alignment = another.Alignment;
		StyleName = another.StyleName;
		Simplify = another.Simplify;
		Wrap = true;
		Plane = (Plane)another.Plane.Clone();
		ToolName = another.ToolName;
		LayerName = another.LayerName;
		LayerIndex = another.LayerIndex;
		Color = another.Color;
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public buMultilineText(Text another)
	{
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		TextString = another.TextString;
		Height = another.Height;
		Alignment = another.Alignment;
		StyleName = another.StyleName;
		Simplify = another.Simplify;
		Wrap = true;
		Plane = (Plane)another.Plane.Clone();
		LayerName = another.LayerName;
		if (buCall.list_0 != null && buCall.list_0.Count > 0)
		{
			Color colorLayer = another.Color;
			if (buEyeShotFunctions.GetLayerColorFromName(another.LayerName, ref colorLayer))
			{
				Color = colorLayer;
			}
		}
		Update(buEntityUpdateType.MultilineTextStyle);
	}

	public override string ToString()
	{
		string text = "MultilineText ";
		return text + " = " + TextString + " Height : " + Height + " Alignment : " + Alignment.ToString() + " Pnt : ( " + InsertionPoint.X.ToString("f1") + " , " + InsertionPoint.Y.ToString("f1") + " , " + InsertionPoint.Y.ToString("f1");
	}
}
