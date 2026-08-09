using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buText : buEntity
{
	public Plane Plane = Plane.XY;

	public string TextString = "";

	public double Height = 0.0;

	public string StyleName = "";

	public bool Simplify = false;

	public Text.alignmentType Alignment = Text.alignmentType.MiddleCenter;

	public Point3D InsertionPoint = new Point3D();

	public buText()
	{
	}

	public buText(Point3D insPoint, string textString, double height)
	{
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		TextString = textString;
		Height = height;
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane textPlane, string textString, double height)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane textPlane, string textString, double height, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		Alignment = alignment;
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane sketchPlane, Point2D insPoint, string textString, double height)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)sketchPlane.Clone();
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
		Update(buEntityUpdateType.Text);
	}

	public buText(Point3D insPoint, string textString, double height, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane textPlane, Point3D insPoint, string textString, double height)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		Update(buEntityUpdateType.Text);
	}

	public buText(double x, double y, string textString, double height)
	{
		TextString = textString;
		Height = height;
		InsertionPoint = new Point3D(x, y);
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane sketchPlane, Point2D insPoint, string textString, double height, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)sketchPlane.Clone();
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
		Alignment = alignment;
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane textPlane, Point3D insPoint, string textString, double height, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		Alignment = alignment;
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane textPlane, string textString, double height, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Height = height;
		Plane = (Plane)textPlane.Clone();
		Alignment = alignment;
		StyleName = styleName;
		Update(buEntityUpdateType.Text);
	}

	public buText(Point3D insPoint, string textString, double height, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		Update(buEntityUpdateType.Text);
	}

	public buText(double x, double y, double z, string textString, double height)
	{
		TextString = textString;
		Height = height;
		InsertionPoint = new Point3D(x, y, z);
		Update(buEntityUpdateType.Text);
	}

	public buText(Point3D insPoint, string textString, double height, Text.alignmentType alignment, string styleName, bool simplify)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(Plane textPlane, string textString, double height, Text.alignmentType alignment, string styleName, bool simplify)
	{
		TextString = textString;
		Plane = (Plane)textPlane.Clone();
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(Plane textPlane, Point3D insPoint, string textString, double height, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Plane = (Plane)textPlane.Clone();
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(double x, double y, double z, string textString, double height, Text.alignmentType alignment)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		InsertionPoint = new Point3D(x, y, z);
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane sketchPlane, Point2D insPoint, string textString, double height, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Plane = (Plane)sketchPlane.Clone();
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(Plane textPlane, Point3D insPoint, string textString, double height, Text.alignmentType alignment, string styleName, bool simplify)
	{
		TextString = textString;
		Plane = (Plane)textPlane.Clone();
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y, insPoint.Z);
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(double x, double y, double z, string textString, double height, Text.alignmentType alignment, string styleName)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		InsertionPoint = new Point3D(x, y, z);
		Update(buEntityUpdateType.Text);
	}

	public buText(Plane sketchPlane, Point2D insPoint, string textString, double height, Text.alignmentType alignment, string styleName, bool simplify)
	{
		TextString = textString;
		Plane = (Plane)sketchPlane.Clone();
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		InsertionPoint = new Point3D(insPoint.X, insPoint.Y);
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(double x, double y, double z, string textString, double height, Text.alignmentType alignment, string styleName, bool simplify)
	{
		TextString = textString;
		Height = height;
		Alignment = alignment;
		StyleName = styleName;
		Simplify = simplify;
		InsertionPoint = new Point3D(x, y, z);
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(Text another)
	{
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		TextString = another.TextString;
		Height = another.Height;
		Alignment = another.Alignment;
		StyleName = another.StyleName;
		Simplify = another.Simplify;
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
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(MultilineText another)
	{
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		TextString = another.TextString;
		Height = another.Height;
		Alignment = another.Alignment;
		StyleName = another.StyleName;
		Simplify = another.Simplify;
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
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(buText another)
	{
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		TextString = another.TextString;
		Height = another.Height;
		Alignment = another.Alignment;
		StyleName = another.StyleName;
		Simplify = another.Simplify;
		Plane = (Plane)another.Plane.Clone();
		LayerName = another.LayerName;
		ToolName = another.ToolName;
		LayerIndex = another.LayerIndex;
		Color = another.Color;
		Update(buEntityUpdateType.TextStyle);
	}

	public buText(buMultilineText another)
	{
		InsertionPoint = new Point3D(another.InsertionPoint.X, another.InsertionPoint.Y, another.InsertionPoint.Z);
		TextString = another.TextString;
		Height = another.Height;
		Alignment = another.Alignment;
		StyleName = another.StyleName;
		Simplify = another.Simplify;
		Plane = (Plane)another.Plane.Clone();
		ToolName = another.ToolName;
		LayerName = another.LayerName;
		LayerIndex = another.LayerIndex;
		Color = another.Color;
		Update(buEntityUpdateType.TextStyle);
	}

	public override string ToString()
	{
		string text = "Text ";
		return text + " = " + TextString + " Height : " + Height + " Alignment : " + Alignment.ToString() + " Pnt : ( " + InsertionPoint.X.ToString("f1") + " , " + InsertionPoint.Y.ToString("f1") + " , " + InsertionPoint.Y.ToString("f1");
	}
}
